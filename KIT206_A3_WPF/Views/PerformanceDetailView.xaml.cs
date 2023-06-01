using System.Windows;

using KIT206_A3.Objects;

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
				//calculate staff performance
				double threeYearAverage = (researcher as Staff).CalculateAverage3Year();
				double publicationPerformance = (researcher as Staff).CalculatePublicationPerformance();
				double fundingPerformance = (researcher as Staff).FundingReceived;
				//show staff performances
				tb3YearAverage.Text = threeYearAverage.ToString() + " Publications in 3 Years";
				tbFundingReceived.Text = "$" + fundingPerformance.ToString();
				tbPublicationPerformance.Text = publicationPerformance.ToString() + " Publications per Year(" + publicationPerformance * 100 + "%)";
				tbFundingPerformance.Text = "$" + (researcher as Staff).CalculateFundReceivePerformance().ToString() + " Fundings per Year";
			}
			//selected researcher is student
			else
			{
				//disable the performance section that is unavailable for student researcher
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
