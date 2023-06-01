using System.Collections.Generic;
using System.Windows;

using KIT206_A3.Controllers;

namespace KIT206_A3_WPF.Views
{
	public partial class PerformanceReportView : Window
	{
		public PerformanceReportView()
		{
			InitializeComponent();

			OnGeneratePerformanceReport();
		}

		private void OnGeneratePerformanceReport()
		{
			List<PerformancePair>[] performanceList = ResearcherController.GetPerformanceReport();

			//assign item source to display performance of researchers in each group
			performance_starPerformers_list.ItemsSource = performanceList[3];
			performance_meetingMinimum_list.ItemsSource = performanceList[2];
			performance_belowExpectations_list.ItemsSource = performanceList[1];
			performance_poor_list.ItemsSource = performanceList[0];
		}

		private void OnCopyEmailButtonPress(object sender, RoutedEventArgs e)
		{
			//copy all staff researchers' email to clipboard
			Clipboard.SetText(ResearcherController.GetAllResearcherEmail());
			//feedback message
			MessageBox.Show("All below researcher's email is copied to the clipboard.");
		}
	}
}
