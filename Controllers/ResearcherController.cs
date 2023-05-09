using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KIT206_A3.Database;
using KIT206_A3.Objects;

namespace KIT206_A3.Controllers
{
    class ResearcherController
    {
        public static List<Researcher> ResearcherList { get; set; }
        public static List<Researcher> ResearcherListFiltered { get; set; }
        public static Researcher SelectedResearcher { get; set; }

        public static void DisplayResearcherList()
        {
            Console.WriteLine("====Researcher List====");
            foreach (Researcher researcher in ResearcherListFiltered)
            {
                Console.WriteLine("ID:" + researcher.Id + " " + researcher.FirstName + " " + researcher.LastName + "(" + researcher.Title + ") " + researcher.GetType());
            }
            Console.WriteLine("========");
        }

        public static void DisplayResearcherDetails()
        {
            string printStr = "";

            //is student
            if (SelectedResearcher.Level == EmplymentLevel.Student)
            {
                Student studentResearcher = SelectedResearcher as Student;

                printStr =
                    "Name: " + studentResearcher.FirstName + " " + studentResearcher.LastName + "\n" +
                    "Title: " + studentResearcher.Title + "\n" +
                    "School/Unit: " + studentResearcher.SchoolUnit + "\n" +
                    "Campus: " + studentResearcher.Campus.ToString() + "\n" +
                    "Email: " + studentResearcher.Email + "\n" +
                    "Job Title: " + studentResearcher.JobTitle + "\n" +
                    "Commenced with institution: " + studentResearcher.CommencedInstitution.ToString() + "\n" +
                    "Commenced current position: " + studentResearcher.CommencedPosition.ToString() + "\n" +
                    "Tenure: " + studentResearcher.CalculateTenure() + "\n" +
                    "Publication count: " + studentResearcher.PublicationCount + "\n" +
                    "Degree: " + studentResearcher.Degree + "\n" +
                    "Supervisor: " + studentResearcher.supervisor
                    ;
            }
            //is staff
            else
            {
                Staff staffResearcher = SelectedResearcher as Staff;

                string positions = "";
                if (staffResearcher.PreviousPositions != null)
                {
                    foreach (Position item in staffResearcher.PreviousPositions)
                    {
                        positions +=
                            "\tPositionTitle: " + item.PositionLevel.ToString() + "\n" +
                            "\tStartDate: " + item.StartDate.ToString() + "\n" +
                            "\tEndDate: " + item.EndDate.ToString() + "\n" +
                            "\t====\n";
                    }
                }

                string superviseesStr = "";
                if (staffResearcher.Supervisees != null)
                {
                    foreach (Student supervisee in staffResearcher.Supervisees)
                    {
                        if (superviseesStr != "") { superviseesStr += ", "; }
                        superviseesStr += supervisee.FirstName + " " + supervisee.LastName;
                    }
                }

                printStr =
                    "Name: " + staffResearcher.FirstName + " " + staffResearcher.LastName + "\n" +
                    "Title: " + staffResearcher.Title + "\n" +
                    "School/Unit: " + staffResearcher.SchoolUnit + "\n" +
                    "Campus: " + staffResearcher.Campus.ToString() + "\n" +
                    "Email: " + staffResearcher.Email + "\n" +
                    "Job Title: " + staffResearcher.JobTitle + "\n" +
                    "Commenced with institution: " + staffResearcher.CommencedInstitution.ToString() + "\n" +
                    "Commenced current position: " + staffResearcher.CommencedPosition.ToString() + "\n" +
                    "Tenure: " + staffResearcher.CalculateTenure() + "\n" +
                    "Previous positions:\n" + positions + "\n" +
                    "Publication count: " + staffResearcher.PublicationCount + "\n" +
                    "Supervision count: " + staffResearcher.SupervisionCount + "\n" +
                    "Supervisees: " + superviseesStr
                    ;
            }
            Console.WriteLine(printStr);
            PublicationController.PublicationListFiltered = SelectedResearcher.PublicationList;
            PublicationController.DisplayPublicationList();
        }

        public static void LoadResearcherList()
        {
            ResearcherList = DatabaseAdaptor.FetchBasicResearcherList();
            ResearcherListFiltered = ResearcherList;

            //test display
            DisplayResearcherList();
        }

        public static void LoadResearcherDetail(int researcherId)
        {
            for (int i = 0; i < ResearcherList.Count; i++)
            {
                if (researcherId == ResearcherList[i].Id)
                {
                    ResearcherList[i] = DatabaseAdaptor.CompleteResearcherDetails(ResearcherList[i]);
                    PublicationController.LoadPublicationList(ResearcherList[i]);

                    if (ResearcherList[i] is Staff)
                    {
                        LoadSuperviees(ResearcherList[i]);
                    }

                    SelectedResearcher = ResearcherList[i];

                    i = ResearcherList.Count;
                }
            }

            Console.WriteLine("====Researcher Detail====");
            DisplayResearcherDetails();
            Console.WriteLine("========");
        }

        public static List<Researcher> LoadSuperviees(Researcher staffResearcher)
        {
            List<Researcher> supervisees = new List<Researcher>();
            foreach (Researcher researcher in ResearcherList)
            {
                if (researcher is Student)
                {
                    Student studuentResearcher = researcher as Student;
                    if (studuentResearcher.supervisor == staffResearcher.Id)
                    {
                        supervisees.Add(researcher);
                    }
                }
            }
            (staffResearcher as Staff).Supervisees = supervisees;

            return supervisees;
        }

        public static void FilterResearcher(EmplymentLevel level)
        {
            var filtered =
                from Researcher researcher in ResearcherList
                where researcher.Level == level
                select researcher;

            ResearcherListFiltered = new List<Researcher>(filtered);
        }

        public static void FilterResearcher(string name)
        {
            var filtered =
                from Researcher researcher in ResearcherList
                where researcher.LastName.Contains(name) || researcher.FirstName.Contains(name)
                select researcher;

            ResearcherListFiltered = new List<Researcher>(filtered);
            /*
            List<Researcher> newResearchers = new List<Researcher>();
            foreach (Researcher researcher in ResearcherList)
            {
                if (researcher.FirstName.Contains(name) || researcher.LastName.Contains(name))
                {
                    newResearchers.Add(researcher);
                }
            }

            ResearcherListFiltered = newResearchers;

            DisplayResearcherList();
            */
        }

        public static void FilterResearcher(EmplymentLevel level, string name)
        {

        }

        /* cumulative count */
        public static List<(int, int)> CumulativeCount()
        {
            List<Publication> yearOrderPublications = new List<Publication>();
            List<(int, int)> cumulativeList = new List<(int, int)>();
            yearOrderPublications = SelectedResearcher.PublicationList;
            yearOrderPublications.Sort(
                delegate (Publication pub1, Publication pub2)
                {
                    return pub1.PublicationYear.CompareTo(pub2.PublicationYear);
                }
            );

            int year = 0;
            int index = -1;
            foreach (Publication pub in yearOrderPublications)
            {
                if (pub.PublicationYear > year)
                {
                    year = pub.PublicationYear;
                    index++;
                    (int, int) newPair = (year, 1);
                    cumulativeList.Add(newPair);
                }
                else
                {
                    cumulativeList[index] = (cumulativeList[index].Item1, cumulativeList[index].Item2 + 1);
                }
            }

            foreach ((int, int) child in cumulativeList)
            {
                Console.WriteLine("Year: " + child.Item1 + "\tPublication Count: " + child.Item2);
            }

            return cumulativeList;
        }
    }
}
