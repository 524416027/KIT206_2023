using System.Windows;

using KIT206_A3.Objects;
using KIT206_A3_WPF.Views;

namespace KIT206_A3_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //subscribe to listeners when researcher or publication is selected
            researcherListView.OnResearcherSelectListeners += OnResearcherSelected;
            publicationListView.OnPublicationSelectListeners += OnPublicationSelected;

            //disable the display of researcher details and publication list view when first start the application
            researcherDetailsView.Visibility = Visibility.Hidden;
            publicationListView.Visibility = Visibility.Hidden;
        }

        private void OnResearcherSelected(Researcher selectedResearcher)
        {
            //update the view to display the current selected researcher
            researcherDetailsView.UpdateResearcherDetails(selectedResearcher);
            researcherDetailsView.DisplayResearcherDetails();

            //update the view to display the current selected researcher's publication
            publicationListView.UpdatePublicationList(selectedResearcher);

            //show the researcher detail and publication list view to the user
            researcherDetailsView.Visibility = Visibility.Visible;
            publicationListView.Visibility = Visibility.Visible;
        }

        private void OnPublicationSelected(Publication selectedPublication)
		{
            //update and display the selected publication detail in a new window
            PublicationDetailsView publicationDetailsWindow = new PublicationDetailsView();
            publicationDetailsWindow.DisplayResearcherDetails(selectedPublication);
            publicationDetailsWindow.Show();
        }

        private void OnGeneratePerformanceReportButtonPress(object sender, RoutedEventArgs e)
		{
            //create and display the performance report window
            PerformanceReportView performanceReportWindow = new PerformanceReportView();
            performanceReportWindow.Show();
		}
    }
}
