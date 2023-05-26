using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KIT206_A3.Objects;
using KIT206_A3.Controllers;

namespace KIT206_A3_WPF.Views
{
	public partial class PerformanceDetailView : Window
	{
		public PerformanceDetailView()
		{
			InitializeComponent();
		}

		public void DisplayPerformanceDetails(Researcher researcher)
		{
			//show commen performance stats for both staff and student
			tbName.Text = researcher.FirstName + " " + researcher.LastName;
			tbTitle.Text = researcher.Title;
			tbSchoolUnit.Text = researcher.SchoolUnit;
			tbCampus.Text = researcher.Campus.ToString();
			tbEmail.Text = researcher.Email;
			tbQ1Percentage.Text = researcher.CalculateQ1Percentage().ToString() + "%";

			//selected researcher is staff
			if(researcher is Staff)
			{
				//show staff performances
				tb3YearAverage.Text = (researcher as Staff).CalculateAverage3Year().ToString() + " Publications in 3 Years";
				tbFundingReceived.Text = "$" + (researcher as Staff).FundingReceived.ToString();
				tbPublicationPerformance.Text = (researcher as Staff).CalculatePublicationPerformance().ToString() + " Publications per Year";
				tbFundingPerformance.Text = "$" + (researcher as Staff).CalculateFundReceivePerformance().ToString() + " Fundings per Year";
			}
			//selected researcher is student
			else
			{
				//disable the performance section student doesn't have
				tb3YearAverageTitle.Visibility = Visibility.Collapsed;
				tb3YearAverage.Visibility = Visibility.Collapsed;
				tbFundingReceivedTitle.Visibility = Visibility.Collapsed;
				tbFundingReceived.Visibility = Visibility.Collapsed;
				tbPublicationPerformanceTitle.Visibility = Visibility.Collapsed;
				tbPublicationPerformance.Visibility = Visibility.Collapsed;
				tbFundingPerformanceTitle.Visibility = Visibility.Collapsed;
				tbFundingPerformance.Visibility = Visibility.Collapsed;
			}
		}
	}
}
