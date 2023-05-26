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
