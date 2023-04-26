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
		public int SupervisionCount { get; set; }
		public List<Student> Supervisees { get; set; }

		public double CalculateAverage3Year()
		{
            return 0;
        }

		public double CalculatePublicationPerformance()
		{
            return 0;
        }

		public double CalculateFundReceivePerformance()
		{
            return 0;
        }
	}
}
