using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_A3.Objects
{
    public enum EmplymentLevel { Student, A, B, C, D, E, EnumCount }
    public enum ResearcherType { Staff, Student, EnumCount }
    public enum Campus { Hobart, Launceston, CradleCoast, EnumCount }

    public class Researcher
    {
        public int Id { get; set; }
        public ResearcherType Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public EmplymentLevel Level { get; set; }
        public string SchoolUnit { get; set; }
        public Campus Campus { get; set; }
        public string Email { get; set; }
        public string PhotoURL { get; set; }
        public string JobTitle
        {
            get
            {
                return GetCurrentJob().PositionLevel.ToString();
            }
        }

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
            //number of publication published in the year / quarter 1 publications * 100
            return 0;
        }

        //get earliest
        public Position GetEarliestJob()
        {
            DateTime ealiestTime = DateTime.Now;
            Position ealiestPos = new Position();
            foreach (Position pos in PreviousPositions)
            {
                //>1: ealiestTime later than pos.start
                int compareTime = DateTime.Compare(ealiestTime, pos.StartDate);
                if (compareTime > 1)
                {
                    ealiestTime = pos.StartDate;
                    ealiestPos = pos;
                }
            }
            return ealiestPos;
        }

        //get current
        public Position GetCurrentJob()
        {
            Position currentJob = new Position();
            foreach (Position pos in PreviousPositions)
            {
                //>1: now later than start, <=1: now ealier than end
                int start = DateTime.Compare(DateTime.Now, pos.StartDate);
                int end = DateTime.Compare(DateTime.Now, pos.EndDate);
                if (start > 1 && end <= 1)
                {
                    currentJob = pos;
                }
            }

            return currentJob;
        }

        /* fake data test */
        public string DisplayResearcherDetails()
        {
            string positions = "";
            foreach (Position item in PreviousPositions)
            {
                positions +=
                    "\tPositionTitle: " + item.PositionLevel.ToString() + "\n" +
                    "\tStartDate: " + item.StartDate.ToString() + "\n" +
                    "\tEndDate: " + item.EndDate.ToString() + "\n" +
                    "\t====\n";
            }

            return
                "Name: " + FirstName + " " + LastName + "\n" +
                "Title: " + Title + "\n" +
                "School/Unit: " + SchoolUnit + "\n" +
                "Campus: " + Campus.ToString() + "\n" +
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
                    "\tPositionTitle: " + item.PositionLevel.ToString() + "\n" +
                    "\tStartDate: " + item.StartDate.ToString() + "\n" +
                    "\tEndDate: " + item.EndDate.ToString() + "\n" +
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
