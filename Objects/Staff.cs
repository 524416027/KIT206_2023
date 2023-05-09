using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_A3.Objects
{
    public class Staff : Researcher
    {
        public int FundingReceived { get; set; }
        public int SupervisionCount { get { return Supervisees.Count(); } }
        public List<Researcher> Supervisees { get; set; }

        public double CalculateAverage3Year()
        {
            //21 22 23
            int minYear = DateTime.Now.Year - 2;
            int publicationCount = 0;

            for (int i = 0; i < PublicationList.Count; i++)
            {
                if (PublicationList[i].PublicationYear >= minYear)
                {
                    publicationCount++;
                }
            }

            return (double)publicationCount / 3;
        }

        public double CalculatePublicationPerformance()
        {
            int commencementYearCount = (DateTime.Now.Year - CommencedPosition.Year) + 1;
            int publicationCount = PublicationList.Count;
            return (double)publicationCount / commencementYearCount;
        }

        public double CalculateFundReceivePerformance()
        {
			int commencementYearCount = (DateTime.Now.Year - CommencedPosition.Year) + 1;
            return FundingReceived / commencementYearCount;
        }
    }
}
