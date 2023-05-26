using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using KIT206_A3.Database;
using KIT206_A3.Objects;

namespace KIT206_A3.Controllers
{
    [XmlRoot(ElementName = "Projects")]
    public class Projects
	{
        [XmlElement("Project")]
        public List<Project> ProjectList { get; set; }
	}

    public class Project
	{
        [XmlElement("Funding")]
        public int Funding { get; set; }

        [XmlElement("Year")]
        public int Year { get; set; }

        [XmlElement("Researchers")]
        public List<Researchers> researcherList { get; set; }
    }

    public class Researchers
	{
        [XmlElement("staff_id")]
        public List<int> staffIdList { get; set; }
	}

    class ResearcherController
    {
        public static List<Researcher> ResearcherList { get; set; }
        public static List<Researcher> ResearcherListFiltered { get; set; }
        public static Researcher SelectedResearcher { get; set; }
        private static Projects projects;

        public static List<Researcher> LoadResearcherList()
        {
            ResearcherList = DatabaseAdaptor.FetchBasicResearcherList();
            ResearcherListFiltered = ResearcherList;

            string fundingFileStr = System.IO.File.ReadAllText("../../../Data/Fundings_Rankings.xml");
            XmlSerializer ser = new XmlSerializer(typeof(Projects));

            using (TextReader reader = new StringReader(fundingFileStr))
            {
                projects = new Projects();
                projects = (Projects)ser.Deserialize(reader);
            }

            return ResearcherListFiltered;
        }

        public static void LoadResearcherDetail(int researcherId)
        {
            for (int i = 0; i < ResearcherList.Count; i++)
            {
                if (researcherId == ResearcherList[i].Id)
                {
                    //fetch completed researcher detail from the database
                    ResearcherList[i] = DatabaseAdaptor.CompleteResearcherDetails(ResearcherList[i]);
                    //load publication list from publication controller
                    ResearcherList[i].PublicationList = PublicationController.LoadPublicationList(ResearcherList[i]);
                    //count and store the publication number
                    ResearcherList[i].PublicationCount = ResearcherList[i].PublicationList.Count;

                    //find superviees if the selected researcher is staff
                    if (ResearcherList[i] is Staff)
                    {
                        //assign supervisee list for the selected staff
                        (ResearcherList[i] as Staff).Supervisees = LoadSuperviees(ResearcherList[i]);

                        //funding sum of selected researcher
                        int totalFunding = 0;
                        foreach(Project project in projects.ProjectList)
						{
                            foreach(Researchers researchers in project.researcherList)
							{
                                foreach(int staffId in researchers.staffIdList)
								{
                                    if(staffId == researcherId)
									{
                                        totalFunding += project.Funding;
									}
								}
							}
						}
                        (ResearcherList[i] as Staff).FundingReceived = totalFunding;
                    }

                    //current selected researcher
                    SelectedResearcher = ResearcherList[i];

                    //target found, stop the search loop
                    i = ResearcherList.Count;
                }
            }
        }

        /* find and create list of supervisees for the selected researcher */
        public static List<Researcher> LoadSuperviees(Researcher staffResearcher)
        {
            List<Researcher> supervisees = new List<Researcher>();

            //loop through researcher list
            foreach (Researcher researcher in ResearcherList)
            {
                //if the current is student, check it's supervisor id
                if (researcher is Student)
                {
                    Student studuentResearcher = researcher as Student;
                    //if the student's supervisor is the selected (staff)researcher
                    if (studuentResearcher.supervisor == staffResearcher.Id)
                    {
                        //add this student to the selected (staff)researcher superviee list
                        supervisees.Add(researcher);
                    }
                }
            }

            return supervisees;
        }

        /* filter researcher list by emplyment level */
        public static List<Researcher> FilterResearcher(EmplymentLevel level)
        {
            //filter by emplement level
            var filtered =
                from Researcher researcher in ResearcherList
                where researcher.Level == level
                select researcher;

            //store filtered result to display
            ResearcherListFiltered = new List<Researcher>(filtered);

            return ResearcherListFiltered;
        }

        /* filter researcher list by name */
        public static List<Researcher> FilterResearcher(string name)
        {
            //filter by name contained either in first or last name
            var filtered =
                from Researcher researcher in ResearcherList
                where researcher.FirstName.ToUpper().Contains(name.ToUpper()) || researcher.LastName.ToUpper().Contains(name.ToUpper())
                select researcher;

            //store filtered result to display
            ResearcherListFiltered = new List<Researcher>(filtered);

            return ResearcherListFiltered;
        }

        /* filter researcher list by both emplyment level and name */
        public static List<Researcher> FilterResearcher(EmplymentLevel level, string name)
        {
            //filter by name contained either in first or last name
            var filtered =
                from Researcher researcher in ResearcherList
                where researcher.Level == level && (researcher.FirstName.ToUpper().Contains(name.ToUpper()) || researcher.LastName.ToUpper().Contains(name.ToUpper()))
                select researcher;

            //store filtered result to display
            ResearcherListFiltered = new List<Researcher>(filtered);
            return ResearcherListFiltered;
        }

        public static string FindResearcherName(int id)
		{
            string name = "";
            for(int i = 0; i < ResearcherList.Count; i++)
			{
                if(ResearcherList[i].Id == id)
				{
                    name = ResearcherList[i].FirstName + ", " + ResearcherList[i].LastName + " (" + ResearcherList[i].Title + ")";

                    i = ResearcherList.Count;
				}
			}

            return name;
		}

        /* calculate cumulative count */
        public static List<(int, int)> CumulativeCount()
        {
            //list of cumulative count information to display
            List<(int, int)> cumulativeList = new List<(int, int)>();

            //list of the publication to be calculated by the current selected researcher
            List<Publication> yearOrderPublications = new List<Publication>(SelectedResearcher.PublicationList);
            //re-order by year
            yearOrderPublications.Sort(
                delegate (Publication pub1, Publication pub2)
                {
                    return pub1.PublicationYear.CompareTo(pub2.PublicationYear);
                }
            );

            int year = 0;
            int index = -1;
            //loop through the publication
            foreach (Publication publication in yearOrderPublications)
            {
                //if current publication on the new group of years
                if (publication.PublicationYear > year)
                {
                    //this is the current year for count
                    year = publication.PublicationYear;
                    //increase to a new index in the cumulative list to store count
                    index++;

                    //assign the starting value
                    (int, int) newPair = (year, 1);
                    //add to the list
                    cumulativeList.Add(newPair);
                }
                //other wise this is the same year as the last publication
                else
                {
                    //add count to the current year group into the list
                    cumulativeList[index] = (cumulativeList[index].Item1, cumulativeList[index].Item2 + 1);
                }
            }

            //FIXME: console output
            foreach ((int, int) child in cumulativeList)
            {
                Console.WriteLine("Year: " + child.Item1 + "\tPublication Count: " + child.Item2);
            }

            return cumulativeList;
        }
    }
}
