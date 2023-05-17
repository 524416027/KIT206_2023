using System;
using System.Collections.Generic;
using System.Linq;

namespace KIT206A3WPF.Objects
{
    public class Staff : Researcher
    {
        public int FundingReceived { get; set; }
        public int SupervisionCount { get { return Supervisees.Count(); } }
        public List<Researcher> Supervisees { get; set; }

        public double CalculateAverage3Year()
        {
            int minYear = DateTime.Now.Year - 2;
            int publicationCount = 0;

            //loop through to searcher all publication
            for (int i = 0; i < PublicationList.Count; i++)
            {
                //if the year is current, current-1, current-2
                if (PublicationList[i].PublicationYear >= minYear)
                {
                    //increase publication count
                    publicationCount++;
                }
            }

            return (double)publicationCount / 3;
        }

        public double CalculatePublicationPerformance()
        {
            int commencementYearCount = (DateTime.Now.Year - CommencedPosition.Year) + 1;
            return (double)(PublicationCount / commencementYearCount);
        }

        public double CalculateFundReceivePerformance()
        {
            int commencementYearCount = (DateTime.Now.Year - CommencedPosition.Year) + 1;
            return (double)(FundingReceived / commencementYearCount);
        }
    }
}
