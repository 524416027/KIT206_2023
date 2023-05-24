using KIT206_A3.Objects;
using KIT206_A3_WPF.Views;
using System.Windows;

namespace KIT206_A3_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            researcherListView.ResearcherSelected += OnResearcherSelected;
            publicationListView.OnPublicationSelectListeners += OnPublicationSelected;

            researcherDetailsView.Visibility = Visibility.Hidden;
            publicationListView.Visibility = Visibility.Hidden;
        }

        private void OnResearcherSelected(object sender, ResearcherSelectedEventArgs e)
        {
            Researcher researcher = e.SelectedResearcher;

            researcherDetailsView.UpdateResearcherDetails(researcher: researcher);
            researcherDetailsView.DisplayResearcherDetails();

            publicationListView.UpdatePublicationList(researcher);

            researcherDetailsView.Visibility = Visibility.Visible;
            publicationListView.Visibility = Visibility.Visible;
        }

        public void OnPublicationSelected(Publication selectedPublication)
		{
            PublicationDetailsView publicationDetailsWindow = new PublicationDetailsView();
            publicationDetailsWindow.DisplayResearcherDetails(selectedPublication);
            publicationDetailsWindow.Show();
        }
    }
}
