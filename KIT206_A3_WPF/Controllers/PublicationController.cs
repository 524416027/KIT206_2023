using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KIT206_A3.Database;
using KIT206_A3.Objects;

namespace KIT206_A3.Controllers
{
    class PublicationController
    {
        public static List<Publication> PublicationList { get; set; }
        public static List<Publication> PublicationListFiltered { get; set; }
        public static Publication SelectedPublication { get; set; }

        public static void DisplayPublicationList()
		{
            Console.WriteLine("====Publication List====");
            foreach (Publication pub in PublicationListFiltered)
			{
                Console.WriteLine("\tTitle: " + pub.Title + " Year: " + pub.PublicationYear);
            }
            Console.WriteLine("========");
        }

        public static void DisplayPublicationDetails()
        {
            Console.WriteLine(
                "doi: " + SelectedPublication.Doi + "\n" +
                "title: " + SelectedPublication.Title + "\n" +
                "ranking: " + SelectedPublication.Rank.ToString() + "\n" +
                "authors: " + SelectedPublication.Authors + "\n" +
                "publication year: " + SelectedPublication.PublicationYear + "\n" +
                "publication type: " + SelectedPublication.Type.ToString() + "\n" +
                "cite: " + SelectedPublication.Cite + "\n" +
                "available date: " + SelectedPublication.AvailabilityDate.ToString()
            );
        }

        /* load publication list for target researcher */
        public static List<Publication> LoadPublicationList(Researcher researcher)
        {
            //fetch basic publication list from the database, store the original result
            PublicationList = DatabaseAdaptor.FetchBasicPublicationDetails(researcher);
            //create filtered publication list to store organized list for display
            PublicationListFiltered = new List<Publication>(PublicationList);
            PublicationListFiltered.Sort(
                delegate (Publication pub1, Publication pub2)
                {
                    return pub1.Title.CompareTo(pub2.Title);
                }
            );

            return new List<Publication>(PublicationListFiltered);
        }

        public static List<Publication> LoadPublicationList(int startYear, int endYear)
		{
            var filtered =
                from Publication pub in PublicationList
                where pub.PublicationYear >= startYear && pub.PublicationYear <= endYear
                select pub;

            PublicationListFiltered = new List<Publication>(filtered);
            PublicationListFiltered.Sort(
                delegate (Publication pub1, Publication pub2)
                {
                    return pub1.Title.CompareTo(pub2.Title);
                }
            );

            return new List<Publication>(PublicationListFiltered);
        }
        
        /* fake data test */
        public static void LoadPublicationDetails(string doi)
        {
            for(int i = 0; i < PublicationList.Count; i++)
			{
                if(PublicationList[i].Doi == doi)
				{
                    SelectedPublication = DatabaseAdaptor.CompletePublicationDetails(PublicationList[i]);
                }
			}
        }

        public static List<Publication> InvertPublicationList()
        {
            PublicationListFiltered.Reverse();

            return new List<Publication>(PublicationListFiltered);
        }
    }
}
