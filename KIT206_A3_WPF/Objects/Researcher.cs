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
        public Dictionary<EmplymentLevel, string> JobTitleNames = new Dictionary<EmplymentLevel, string>()
        {
            { EmplymentLevel.Student, "Student" },
            { EmplymentLevel.A, "Research Associate" },
            { EmplymentLevel.B, "Lecturer" },
            { EmplymentLevel.C, "Assistant Professor" },
            { EmplymentLevel.D, "Associate Professor" },
            { EmplymentLevel.E, "Professor" }
        };

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
                //return PreviousPositions == null ? null : GetCurrentJob().PositionLevel.ToString();
                return JobTitleNames[Level];
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

        public Position GetEarliestJob()
        {
            DateTime ealiestTime = DateTime.Now;
            Position ealiestPos = new Position();

            //loop through positions from previous position
            foreach (Position pos in PreviousPositions)
            {
                //compare to find ealierst position
                int compareTime = DateTime.Compare(ealiestTime, pos.StartDate);
                //compare result >1: pos.start ealier than ealiestTime
                if (compareTime > 1)
                {
                    //assign the new ealierst time and position
                    ealiestTime = pos.StartDate;
                    ealiestPos = pos;
                }
            }
            return ealiestPos;
        }

        public Position GetCurrentJob()
        {
            Position currentJob = new Position();

            //loop through positions from previous position
            foreach (Position pos in PreviousPositions)
            {
                //compare to find the date that now is later than start date and stop date is later than now
                int start = DateTime.Compare(DateTime.Now, pos.StartDate);
                int end = DateTime.Compare(DateTime.Now, pos.EndDate);
                //compare result >1: para1 later than para2
                //compare result <=1: para1 ealier or same time than para2
                if (start > 1 && end <= 1)
                {
                    //found the current job
                    currentJob = pos;
                }
            }
            return currentJob;
        }
    }
}
