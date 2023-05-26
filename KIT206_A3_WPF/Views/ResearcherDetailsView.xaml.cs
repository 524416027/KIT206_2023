using KIT206_A3.Objects;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

using KIT206_A3.Controllers;


namespace KIT206_A3_WPF.Views
{

    public partial class ResearcherDetailsView : UserControl
    {
        private Researcher researcher;

        public ResearcherDetailsView()
        {
            InitializeComponent();
        }

        public void UpdateResearcherDetails(Researcher researcher)
        {
            this.researcher = researcher;
            DisplayResearcherDetails();
        }

        private void populateEntries()
        {
            // Researcher researcher = _researcherController.LoadResearcherDetails(selectedResearcher);
            // Assign the publications list to your desired control in the UI

            string uriString = researcher.PhotoURL;

            // Create a new Uri using the uriString
            try
            {
                Uri imageUri = new Uri(uriString);

                // Create a new BitmapImage
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = imageUri;
                bitmapImage.EndInit();
                imgpath.Width = 70;
                imgpath.Height = 150;

                imgpath.Source = bitmapImage;
            }
            catch (Exception)
            {

            }

            tbName.Text = researcher.FirstName + " " + researcher.LastName;
            tbTitle.Text = researcher.Title;
            tbSchoolUnit.Text = researcher.SchoolUnit;
            tbCampus.Text = researcher.Campus.ToString();
            tbEmail.Text = researcher.Email;
            tbJobTitle.Text = researcher.JobTitle;

            tbCommencedWithInstitution.Text = researcher.CommencedInstitution.ToString("dd'/'MM'/'yyyy");
            tbCommencedCurrentPosition.Text = researcher.CommencedPosition.ToString("dd'/'MM'/'yyyy");

            tbTenure.Text = researcher.CalculateTenure().ToString();

            

            tbPublicationCount.Text = researcher.PublicationCount.ToString();

            if(researcher is Staff staff)
			{
                //enable previous positions section
                tbPreviousPositionTitle.Visibility = Visibility.Visible;
                previous_position_list.Visibility = Visibility.Visible;
                //assign item source of previous positions
                previous_position_list.ItemsSource = researcher.PreviousPositions;

                //enable supervision section
                tbSuperviseeCountTitle.Visibility = Visibility.Visible;
                tbSuperviseeCount.Visibility = Visibility.Visible;
                tbSuperviseeCount.Text = staff.SupervisionCount.ToString();
                btnSupervisionDetail.Visibility = Visibility.Visible;

                //disable degree and supervisor section
                tbDegreeTitle.Visibility = Visibility.Collapsed;
                tbDegree.Visibility = Visibility.Collapsed;
                tbSupervisorTitle.Visibility = Visibility.Collapsed;
                tbSupervisor.Visibility = Visibility.Collapsed;
            }
            else
			{
                //disable previous positions section
                tbPreviousPositionTitle.Visibility = Visibility.Collapsed;
                previous_position_list.Visibility = Visibility.Collapsed;

                //disabble supervision section
                tbSuperviseeCountTitle.Visibility = Visibility.Collapsed;
                tbSuperviseeCount.Visibility = Visibility.Collapsed;
                btnSupervisionDetail.Visibility = Visibility.Collapsed;

                if (researcher is Student student)
				{
                    //enable degree section
                    tbDegreeTitle.Visibility = Visibility.Visible;
                    tbDegree.Visibility = Visibility.Visible;
                    //assign student degree
                    tbDegree.Text = student.Degree;

                    //enable supervisor section
                    tbSupervisorTitle.Visibility = Visibility.Visible;
                    tbSupervisor.Visibility = Visibility.Visible;
                    //assign supervisor name
                    tbSupervisor.Text = ResearcherController.FindResearcherName(student.supervisor);
				}
			}
        }

        public void DisplayResearcherDetails()
        {
            if (researcher != null)
            {
                populateEntries();
            }
            else
            {
                MessageBox.Show("Something wrong happened");
            }
        }

        public Researcher GetSelectedResearcher()
		{
            return ResearcherController.SelectedResearcher;
		}

        public List<Researcher> GetSelectedResearcherSupervieeList()
		{
            return (ResearcherController.SelectedResearcher as Staff).Supervisees;
		}

        private void OnSuperviseeButtonPress(object sender, RoutedEventArgs e)
        {
            SuperviseeListView superviseeListWindow = new SuperviseeListView();
            superviseeListWindow.Show();
        }

        private void OnPerformanceButtonPress(object sender, RoutedEventArgs e)
        {
            PerformanceDetailView performanceDetailWindow = new PerformanceDetailView();
            performanceDetailWindow.DisplayPerformanceDetails(ResearcherController.SelectedResearcher);
            performanceDetailWindow.Show();
		}
    }
}
