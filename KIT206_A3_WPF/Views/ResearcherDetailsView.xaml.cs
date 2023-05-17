using KIT206_A3.Objects;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KIT206_A3_WPF.Views
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
            Uri imageUri = new Uri(uriString);

            // Create a new BitmapImage
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = imageUri;
            bitmapImage.EndInit();

            // Assign the BitmapImage as the source of the PictureBox
            imgpath.Width = 70;
            imgpath.Height = 150;

            imgpath.Source = bitmapImage;
            lblschoolunit.Content = researcher.SchoolUnit.ToString();
            lblemail.Content = researcher.Email.ToString();
            lbljobtitle.Content = researcher.GetCurrentJob();
            lblname.Content = researcher.FirstName.ToString();
            lblpublications.Content = researcher.PublicationCount.ToString();
            lblcommencedcurrentposition.Content = researcher.CommencedPosition.ToString();
            lbltenure.Content = researcher.CalculateTenure().ToString();


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

            }
        }


    }
}
