using System.Collections.Generic;
using System.Linq;

using KIT206_A3.Objects;
using KIT206_A3.Database;

namespace KIT206_A3.Controllers
{
    class PublicationController
    {
        public static List<Publication> PublicationList { get; set; }
        public static List<Publication> PublicationListFiltered { get; set; }
        public static Publication SelectedPublication { get; set; }

        /* load publication list for target researcher */
        public static List<Publication> LoadPublicationList(Researcher researcher)
        {
            //fetch basic publication list from the database, store the original result
            PublicationList = DatabaseAdaptor.FetchBasicPublicationDetails(researcher);
            //create filtered publication list to store organized list for display
            PublicationListFiltered = new List<Publication>(PublicationList);
            //sort publications in alphabetical order
            PublicationListFiltered.Sort(
                delegate (Publication pub1, Publication pub2)
                {
                    return pub1.Title.CompareTo(pub2.Title);
                }
            );

            return new List<Publication>(PublicationListFiltered);
        }

        /* load publication list based on selected start and end publish year */
        public static List<Publication> LoadPublicationList(int startYear, int endYear)
		{
            //filter out target publications
            var filtered =
                from Publication pub in PublicationList
                where pub.PublicationYear >= startYear && pub.PublicationYear <= endYear
                select pub;

            //create filtered publication list to store organized list for display
            PublicationListFiltered = new List<Publication>(filtered);
            //sort publications in alphabetical order
            PublicationListFiltered.Sort(
                delegate (Publication pub1, Publication pub2)
                {
                    return pub1.Title.CompareTo(pub2.Title);
                }
            );

            return new List<Publication>(PublicationListFiltered);
        }
        
        /* load full details for the target publication by doi */
        public static void LoadPublicationDetails(string doi)
        {
            //find the target publication by doi
            for(int i = 0; i < PublicationList.Count; i++)
			{
                if(PublicationList[i].Doi == doi)
				{
                    //fetch full details from database for target publication
                    SelectedPublication = DatabaseAdaptor.CompletePublicationDetails(PublicationList[i]);
                    //target found, stop search
                    i = PublicationList.Count;
                }
			}
        }

        /* invert the display order of current filtered list */
        public static List<Publication> InvertPublicationList()
        {
            PublicationListFiltered.Reverse();

            return new List<Publication>(PublicationListFiltered);
        }
    }
}
