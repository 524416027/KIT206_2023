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

			performance_starPerformers_list.ItemsSource = performanceList[3];
			performance_meetingMinimum_list.ItemsSource = performanceList[2];
			performance_belowExpectations_list.ItemsSource = performanceList[1];
			performance_poor_list.ItemsSource = performanceList[0];
		}

		private void OnCopyEmailButtonPress(object sender, RoutedEventArgs e)
		{
			Clipboard.SetText(ResearcherController.GetAllResearcherEmail());

			MessageBox.Show("All below researcher's email is copied to the clipboard.");
		}
	}
}
