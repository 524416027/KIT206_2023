using KIT206A3WPF.Objects;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KIT206A3WPF.Views
{
    /// <summary>
    /// Interaction logic for ResearcherDetailsView.xaml
    /// </summary>
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
            if (researcher.SchoolUnit != null)
            {
                lblschoolunit.Content = researcher.SchoolUnit.ToString();

            }
            if (researcher.Email != null)
            {
                lblemail.Content = researcher.Email.ToString();

            }
            if (researcher.FirstName != null)
            {
                lblname.Content = researcher.FirstName.ToString();

            }
            if (researcher.Title != null)
            {
                lbljobtitle.Content = researcher.Title.ToString();

            }
            if (researcher.PublicationCount != null)
            {
                lblpublications.Content = researcher.PublicationCount.ToString();

            }
            if (researcher.CommencedPosition != null)
            {
                lblcommencedcurrentposition.Content = researcher.CommencedPosition.ToString();

            }
            if (researcher.CalculateTenure != null)
            {
                lbltenure.Content = researcher.CalculateTenure().ToString();

            }

            // Assign the BitmapImage as the source of the PictureBox



            if (researcher is Staff staff)
            {
                lblsupervisions.Content = staff.Supervisees;
                lblcommencedwithinstitution.Content = staff.CommencedInstitution.ToString();
            }
            if (researcher is Student student)
            {
                lblsupervisor.Content = student.supervisor;

                lbldegree.Content = student.Degree.ToString();

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

    }
}
