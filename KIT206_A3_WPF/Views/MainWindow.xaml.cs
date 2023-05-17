using KIT206_A3_WPF.Views;
using System.Windows;

namespace KIT206_A3_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // private ResearcherListView researcherListView;
        // private ResearcherDetailsView researcherDetailsView;

        public MainWindow()
        {
            InitializeComponent();



            researcherListView.ResearcherSelected += OnResearcherSelected;
            researcherDetailsView.Visibility = Visibility.Hidden;
        }

        private void OnResearcherSelected(object sender, ResearcherSelectedEventArgs e)
        {
            researcherDetailsView.Visibility = Visibility.Visible;
            researcherDetailsView.UpdateResearcherDetails(e.SelectedResearcher);
            researcherDetailsView.DisplayResearcherDetails();

        }
    }
}
