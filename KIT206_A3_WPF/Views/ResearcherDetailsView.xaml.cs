using KIT206_A3.Objects;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

            /*
            if (researcher.SchoolUnit != null)
            {
                tbSchoolUnit.Text = researcher.SchoolUnit.ToString();

            }
            if (researcher.Email != null)
            {
                tbEmail.Text = researcher.Email.ToString();

            }
            if (researcher.FirstName != null)
            {
                tbName.Text = researcher.FirstName.ToString();

            }
            if (researcher.Title != null)
            {
                tbJobTitle.Text = researcher.Title.ToString();

            }
            if (researcher.PublicationCount != null)
            {
                lblpublications.Content = researcher.PublicationCount.ToString();

            }
            if (researcher.CommencedPosition != null)
            {
                lblcommencedcurrentposition.Content = researcher.CommencedPosition.ToString();

            }
            if (researcher.CalculateTenure() != null)
            {
                lbltenure.Content = researcher.CalculateTenure().ToString();

            }
            */

            // Assign the BitmapImage as the source of the PictureBox


            /*
            if (researcher is Staff staff)
            {
                lblsupervisions.Content = staff.Supervisees;
                lblcommencedwithinstitution.Content = staff.CommencedInstitution.ToString();
                lbltenure.Content = staff.CalculateTenure();
                //lblsupervisions.Content = staff.SupervisionCount.ToString();
                //   lblpublications.Content = staff.PublicationCount;
                //   lblcommencedcurrentposition.Content = staff.CommencedPosition.ToString();
                lblcommencedwithinstitution.Content = staff.CommencedInstitution.ToString();
            }
            if (researcher is Student student)
            {
                lblsupervisor.Content = student.supervisor;

                lbldegree.Content = student.Degree.ToString();
            }
            */
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
