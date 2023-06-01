using System.Windows;

using KIT206_A3.Objects;

namespace KIT206_A3_WPF.Views
{
	public partial class PublicationDetailsView : Window
	{
		public PublicationDetailsView()
		{
			InitializeComponent();
		}

		public void DisplayResearcherDetails(Publication publication)
		{
			//assign values to text box to display
			tbDoi.Text = publication.Doi;

			tbTitle.Text = publication.Title;
			tbAuthors.Text = publication.Authors;
			tbPublicationYear.Text = publication.PublicationYear.ToString();

			tbRanking.Text = publication.Rank.ToString();
			tbType.Text = publication.Type.ToString();
			tbCite.Text = publication.Cite;
			tbAvailabilityDate.Text = publication.AvailabilityDate.ToString("dd/MM/yyyy");
			tbAge.Text = publication.Age.ToString();
		}
	}
}
