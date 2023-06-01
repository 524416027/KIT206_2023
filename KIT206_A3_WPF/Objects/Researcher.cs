using System;
using System.Collections.Generic;

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
                return JobTitleNames[Level];
            }
        }
        public DateTime CommencedInstitution { get; set; }
        public DateTime CommencedPosition { get; set; }
        public List<Position> PreviousPositions { get; set; }
        public int PublicationCount { get; set; }
        public List<Publication> PublicationList { get; set; }

        /* calculate tenure of this researcher */
        public double CalculateTenure()
        {
            return DateTime.Now.Year - CommencedInstitution.Year;
        }

        /* calculate q1 percentage of this researcher */
        public double CalculateQ1Percentage()
        {
            //total number of Q1 publication / total number of publication * 100
            int q1Count = 0;

            //count the total Q1 publication
            foreach(Publication pub in PublicationList)
			{
                if(pub.Rank == Ranking.Q1)
				{
                    q1Count++;
				}
			}

            return Math.Round((double)q1Count / PublicationCount * 100, 2);
        }

        /* find the earliest job of this researcher */
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

        /* find the current job of this researcher under taking */
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
