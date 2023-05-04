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

        public static void DisplayPublicationList(List<Publication> publication)
		{
            Console.WriteLine("====Publication List====");
            foreach (Publication pub in publication)
			{
                Console.WriteLine("\tTitle: " + pub.Title + " Year: " + pub.PublicationYear);
            }
            Console.WriteLine("========");
        }

        public static void DisplayPublicationDetails()
        {

        }

        public static void LoadPublicationList(Researcher researcher)
        {
            PublicationList = DatabaseAdaptor.FetchBasicPublicationDetails(researcher);
            researcher.PublicationList = PublicationList;
            researcher.PublicationCount = PublicationList.Count;

            PublicationListFiltered = new List<Publication>(PublicationList);
        }

        public static void LoadPublicationList(int startYear, int endYear)
		{
            /* fake data test 
            //assume the publication list is already loaded for the selected researcher
            PublicationList = DataGenerator.FetchBasicPublicationList(ResearcherController.SelectedResearcher, startYear, endYear);
            PublicationListFiltered = PublicationList;
            */
        }
        
        /* fake data test */
        public static void LoadPublicationDetails(int listIndex)
        {
            SelectedPublication = PublicationListFiltered[listIndex];
            SelectedPublication = DatabaseAdaptor.CompletePublicationDetails(SelectedPublication);

            /*
            for(int i = 0; i < ResearcherController.SelectedResearcher.PublicationList.Count; i++)
			{
                if(PublicationList[i] == PublicationListFiltered[listIndex])
				{
                    PublicationList[i] = PublicationListFiltered[listIndex];
                    PublicationList = ResearcherController.SelectedResearcher.PublicationList;
                }
			}
            */
            
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
