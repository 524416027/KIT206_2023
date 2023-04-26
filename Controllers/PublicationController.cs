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

        public static void LoadPublicationList(Researcher researcher)
        {
            /* fake data test */
            PublicationList = DataGenerator.FetchBasicPublicationList(researcher);
            PublicationListFiltered = PublicationList;

            PublicationListFiltered.Sort(
                delegate(Publication pub1, Publication pub2)
                {
                    return pub1.Title.CompareTo(pub2.Title);
                }
            );

            researcher.PublicationList = PublicationListFiltered;
        }

        public static void LoadPublicationList(int startYear, int endYear)
		{
            /* fake data test */
            //assume the publication list is already loaded for the selected researcher
            PublicationList = DataGenerator.FetchBasicPublicationList(ResearcherController.SelectedResearcher, startYear, endYear);
            PublicationListFiltered = PublicationList;
        }

        /* fake data test */
        public static void DisplayPublicationList()
		{
            Console.WriteLine("====Publication List====");
            foreach (Publication publication in PublicationListFiltered)
			{
                Console.WriteLine(publication.DisplayPublicationList());
			}
            Console.WriteLine("========");
        }

        public static void LoadPublicationDetails(Publication publication)
        {
            //SelectedPublication = DatabaseAdaptor.FetchCompletePublicationDetails(publication);
        }

        /* fake data test */
        public static void LoadPublicationDetails(int listIndex)
        {
            SelectedPublication = PublicationListFiltered[listIndex];
            SelectedPublication = DataGenerator.FetchCompletePublicationDetails(SelectedPublication);

            Console.WriteLine("====Publication Detail====");
            Console.WriteLine(SelectedPublication.DisplayPublicationDetails());
            Console.WriteLine("========");
        }

        public static void InvertPublicationList()
        {
            PublicationListFiltered.Reverse();
        }
    }
}
