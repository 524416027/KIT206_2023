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
            researcherDetailsView.Visibility = Visibility.Hidden;
        }
        private void OnResearcherSelected(object sender, ResearcherSelectedEventArgs e)
        {
            Researcher researcher = e.SelectedResearcher;
            researcherDetailsView.UpdateResearcherDetails(researcher: researcher);
            researcherDetailsView.DisplayResearcherDetails();
            researcherDetailsView.Visibility = Visibility.Visible;
        }
    }
}
