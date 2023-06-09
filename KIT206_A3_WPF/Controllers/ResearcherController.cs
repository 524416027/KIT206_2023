﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

using KIT206_A3.Objects;
using KIT206_A3.Database;

namespace KIT206_A3.Controllers
{
	/* class objects for funding xml */
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

	/* class object for cumulative count */
	public class CumulativePair
	{
		public int Year { get; set; }
		public int Count { get; set; }
	}

	/* class object for performance report*/
	public class PerformancePair
	{
		public int Performance { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Title { get; set; }
	}

	class ResearcherController
	{
		public static List<Researcher> ResearcherList { get; set; }
		public static List<Researcher> ResearcherListFiltered { get; set; }
		public static Researcher SelectedResearcher { get; set; }
		private static Projects projects; //object for funding xml

		/* load basic researcher list */
		public static List<Researcher> LoadResearcherList()
		{
			/* load basic data from database */
			ResearcherList = DatabaseAdaptor.FetchBasicResearcherList();
			ResearcherListFiltered = ResearcherList;

			/* process funding xml file */
			//read xml file as plain text
			string fundingFileStr = System.IO.File.ReadAllText("../../../Data/Fundings_Rankings.xml");
			//deserilize plain xml text to C# objects
			XmlSerializer ser = new XmlSerializer(typeof(Projects));
			using (TextReader reader = new StringReader(fundingFileStr))
			{
				projects = new Projects();
				projects = (Projects)ser.Deserialize(reader);
			}

			return ResearcherListFiltered;
		}

		/* load full details for the target researcher by researcher's ID */
		public static void LoadResearcherDetail(int researcherId)
		{
			//search to find target researcher by ID from the list
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

						/* calculate the total funding received by target this researcher */
						//funding sum of selected researcher
						int totalFunding = 0;
						//locate projects made by this researcher
						foreach (Project project in projects.ProjectList)
						{
							foreach (Researchers researchers in project.researcherList)
							{
								foreach (int staffId in researchers.staffIdList)
								{
									if (staffId == researcherId)
									{
										//add the funding to the sum
										totalFunding += project.Funding;
									}
								}
							}
						}
						//assign the total funding result
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
			//if text entered into the search box
			if (name != "")
			{
				//filter by name contained either in first or last name
				var filtered =
					from Researcher researcher in ResearcherList
					where researcher.FirstName.ToUpper().Contains(name.ToUpper()) || researcher.LastName.ToUpper().Contains(name.ToUpper())
					select researcher;

				//store filtered result to display
				ResearcherListFiltered = new List<Researcher>(filtered);
			}
			//if the text box is empty, display defalt list
			else
			{
				ResearcherListFiltered = new List<Researcher>(ResearcherList);
			}

			return ResearcherListFiltered;
		}

		/* filter researcher list by both emplyment level and name */
		public static List<Researcher> FilterResearcher(EmplymentLevel level, string name)
		{
			//if text entered into the search box
			if (name != "")
			{
				//filter by name contained either in first or last name
				var filtered =
					from Researcher researcher in ResearcherList
					where researcher.Level == level && (researcher.FirstName.ToUpper().Contains(name.ToUpper()) || researcher.LastName.ToUpper().Contains(name.ToUpper()))
					select researcher;

				//store filtered result to display
				ResearcherListFiltered = new List<Researcher>(filtered);
			}
			//if the text box is empty, display defalt list
			else
			{
				ResearcherListFiltered = new List<Researcher>(FilterResearcher(level));
			}

			return ResearcherListFiltered;
		}

		/* search research by ID and return name in a format */
		public static string FindResearcherName(int id)
		{
			string name = "";
			//find the target researcher by ID from the list
			for (int i = 0; i < ResearcherList.Count; i++)
			{
				if (ResearcherList[i].Id == id)
				{
					//combine names to desired format
					name = ResearcherList[i].FirstName + ", " + ResearcherList[i].LastName + " (" + ResearcherList[i].Title + ")";

					//target found, stop the search
					i = ResearcherList.Count;
				}
			}

			return name;
		}

		/* calculate cumulative count */
		public static List<CumulativePair> GetCumulativeCount()
		{
			//list of cumulative count information to display
			List<CumulativePair> cumulativeList = new List<CumulativePair>();

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
					CumulativePair newPair = new CumulativePair
					{
						Year = year,
						Count = 1
					};

					//add to the list
					cumulativeList.Add(newPair);
				}
				//other wise this is the same year as the last publication
				else
				{
					//add count to the current year group into the list
					cumulativeList[index].Count++;
				}
			}

			return cumulativeList;
		}

		/* calculate performance for each staff researcher, group the result in order */
		public static List<PerformancePair>[] GetPerformanceReport()
		{
			List<PerformancePair>[] performanceListGroups = new List<PerformancePair>[4];
			List<PerformancePair> performanceList = new List<PerformancePair>();

			//initial performance list groups
			for(int i = 0; i < performanceListGroups.Length; i++)
			{
				performanceListGroups[i] = new List<PerformancePair>();
			}

			//load full details for all staffs to calculate performance
			for(int i = 0; i < ResearcherList.Count; i++)
			{
				//only for staff researcher
				if (ResearcherList[i] is Staff)
				{
					//load full detail for this researcher to calculate performance
					LoadResearcherDetail(ResearcherList[i].Id);

					//generate performance pair to order and group
					PerformancePair newPerformancePair = new PerformancePair
					{
						FirstName = ResearcherList[i].FirstName,
						LastName = ResearcherList[i].LastName,
						Title = ResearcherList[i].Title,
						Performance = (int)((ResearcherList[i] as Staff).CalculatePublicationPerformance() * 100)
					};

					//add the performance pair to general list for further process
					performanceList.Add(newPerformancePair);
				}
			}

			//re-order by performance
			performanceList.Sort(
				delegate (PerformancePair perf1, PerformancePair perf2)
				{
					return perf1.Performance.CompareTo(perf2.Performance);
				}
			);

			//group each performance in category
			foreach (PerformancePair performance in performanceList)
			{
				if (performance.Performance <= 70)
				{
					performanceListGroups[0].Add(performance);
				}
				else if (performance.Performance > 70 && performance.Performance < 110)
				{
					performanceListGroups[1].Add(performance);
				}
				else if (performance.Performance >= 110)
				{
					performanceListGroups[2].Add(performance);
				}
				else//(performance.Performance >= 200)
				{
					performanceListGroups[3].Add(performance);
				}
			}

			//meeting minimum and star performers in decrease order
			performanceListGroups[2].Reverse();
			performanceListGroups[3].Reverse();

			return performanceListGroups;
		}

		/* create plain text includes all staff researcher email to copy to clipboard */
		public static string GetAllResearcherEmail()
		{
			string emails = "";
			for(int i = 0; i < ResearcherList.Count; i++)
			{
				if(ResearcherList[i] is Staff)
				{
					//add semicolon in front of the email to separate between each emails
					if (i != 0)
					{
						emails += ", ";
					}
					//add email
					emails += ResearcherList[i].Email;
				}
			}

			return emails;
		}
	}
}
