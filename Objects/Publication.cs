using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_A3.Objects
{
	public enum PublicationType { Conference, Journal, Other, EnumCount }

	public class Publication
	{
		public string Doi { get; set; }
		public string Title { get; set; }
		public List<string> Authors { get; set; }
		public int PublicationYear { get; set; }
		public int Ranking { get; set; }
		public PublicationType Type { get; set; }
		public string Cite { get; set; }
		public DateTime AvailabilityDate { get; set; }
		public int Age { get; set; }

		public int CompareTo(Publication comparePublications)
		{
			return this.Title.CompareTo(comparePublications.Title);
		}

		public string DisplayPublicationList()
		{
			return "Publication year: " + PublicationYear + "\tTitle: " + Title;
		}

		public string DisplayPublicationDetails()
		{
			string authors = "";
			foreach (string author in Authors)
			{
				authors += ", " + author;
			}

			return
				"DOI: " + Doi + "\n" +
				"Title: " + Title + "\n" +
				"Authors: " + authors + "\n" +
				"Publication year: " + PublicationYear + "\n" +
				"Ranking: " + Ranking + "\n" +
				"Type: " + Type.ToString() + "\n" +
				"Cite: " + Cite + "\n" +
				"Availability: " + AvailabilityDate.ToString() + "\n" +
				"Age: " + Age;
		}
	}
}
