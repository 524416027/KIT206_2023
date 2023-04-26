using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_A3.Objects
{
    public enum EmplymentLevel { Student, A, B, C, D, E, EnumCount }

    public class Researcher
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public EmplymentLevel Level { get; set; }
        public string SchoolUnit { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }

        public string JobTitle { get; set; }
        
        public DateTime CommencedInstitution { get; set; }
        public DateTime CommencedPosition { get; set; }
        public List<Position> PreviousPositions { get; set; }
        public int PublicationCount { get; set; }
        public List<Publication> PublicationList { get; set; }

        public double CalculateTenure()
        {
            return DateTime.Now.Year - CommencedInstitution.Year;
        }

        public double CalculateQ1Percentage()
        {
            return 0;
        }

        /* fake data test */
        public string DisplayResearcherDetails()
		{
            string positions = "";
            foreach (Position item in PreviousPositions)
            {
                positions +=
                    "\tPositionTitle: " + item.PositionTitle + "\n" +
                    "\tStartDate: " + item.startDate.ToString() + "\n" +
                    "\tEndDate: " + item.endDate.ToString() + "\n" +
                    "\t====\n";
            }

            return
                "Name: " + FirstName + " " + LastName + "\n" +
                "Title: " + Title + "\n" +
                "School/Unit: " + SchoolUnit + "\n" +
                "Campus: " + Campus + "\n" +
                "Email: " + Email + "\n" +
                "Job Title: " + JobTitle + "\n" +
                "Commenced with institution: " + CommencedInstitution.ToString() + "\n" +
                "Commenced current position: " + CommencedPosition.ToString() + "\n" +
                "Tenure: " + CalculateTenure() + "\n" +
                "Previous positions:\n" + positions + "\n" +
                "Publication count: " + PublicationCount + "\n" +
                "Supervisions: " + "0?" + "\n" +
                "Degree: " + "x?" + "\n" +
                "Supervisor: " + "x?"
                ;
		}

        public override string ToString()
        {
            string positions = "";
            foreach (Position item in PreviousPositions)
            {
                positions +=
                    "\tPositionTitle: " + item.PositionTitle + "\n" +
					"\tStartDate: " + item.startDate.ToString() + "\n" +
					"\tEndDate: " + item.endDate.ToString() + "\n" +
					"\t====\n";
            }

            string publications = "";
			foreach (Publication item in PublicationList)
			{
                string authors = "";
                foreach (string author in item.Authors)
				{
                    authors += ", " + author;
                }

                publications +=
                    "\tDoi: " + item.Doi + "\n" +
					"\tTitle: " + item.Title + "\n" +
					"\tAuthor: " + authors + "\n" +
					"\tPublicationYear: " + item.PublicationYear + "\n" +
					"\tRanking: " + item.Ranking + "\n" +
					"\tType: " + item.Type.ToString() + "\n" +
					"\tCite: " + item.Cite + "\n" +
                    "\tAvailability date: " + item.AvailabilityDate.ToString() + "\n" +
					"\tAge: " + item.Age + "\n" +
					"\t====\n";
            }

            return
                "ResearcherId: " + Id + "\n" +
                "FirstName: " + FirstName + "\n" +
                "LstName: " + LastName + "\n" +
                "Title: " + Title + "\n" +
                "Level: " + Level.ToString() + "\n" +
                "SchoolUnit: " + SchoolUnit + "\n" +
                "Campus: " + Campus + "\n" +
                "Email: " + Email + "\n" +
                "JobTitle: " + JobTitle + "\n" +
                "CommencedInstitution: " + CommencedInstitution.ToString() + "\n" +
                "CommencedPosition: " + CommencedPosition.ToString() + "\n" +
                "PreviousPositions:\n" + positions + "\n" +
                "PublicationCount: " + PublicationCount + "\n" +
                "PublicationList: " + publications + "\n" +
				"========";
        }
    }
}
