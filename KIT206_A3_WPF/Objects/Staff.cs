using System;
using System.Collections.Generic;
using System.Linq;

namespace KIT206_A3.Objects
{
    public class Staff : Researcher
    {
        public int FundingReceived { get; set; }
        public int SupervisionCount { get { return Supervisees.Count(); } }
        public List<Researcher> Supervisees { get; set; }

        /* calculate 3 year average of this staff researcher */
        public double CalculateAverage3Year()
        {
            //the minimum publish year accept to calculate
            int minYear = DateTime.Now.Year - 2;
            int publicationCount = 0;

            //loop through the publication list to count suitable publications
            for (int i = 0; i < PublicationList.Count; i++)
            {
                //if the year is current, current-1, current-2
                if (PublicationList[i].PublicationYear >= minYear)
                {
                    //increase publication count
                    publicationCount++;
                }
            }

            return Math.Round((double)publicationCount / 3, 2);
        }

        /* calculate performance by publication of this staff researcher */
        public double CalculatePublicationPerformance()
        {
            //number of years since commenced
            int commencementYearCount = (DateTime.Now.Year - CommencedPosition.Year) + 1;
            //average number of publication made each year
            return Math.Round((double)PublicationCount / commencementYearCount, 2);
        }

        /* calculate performance by funding received of this staff researcher */
        public double CalculateFundReceivePerformance()
        {
            //number of years since commenced
            int commencementYearCount = (DateTime.Now.Year - CommencedPosition.Year) + 1;
            //average amount of funding received each year
            return Math.Round((double)FundingReceived / commencementYearCount, 2);
        }
    }
}
