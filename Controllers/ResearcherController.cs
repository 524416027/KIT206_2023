using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KIT206_A3.Database;
using KIT206_A3.Objects;

namespace KIT206_A3.Controllers
{
    class ResearcherController
    {
        public static List<Researcher> ResearcherList { get; set; }
        public static List<Researcher> ResearcherListFiltered { get; set; }
        public static Researcher SelectedResearcher { get; set; }

        public static void DisplayResearcherList()
        {
            Console.WriteLine("====Researcher List====");
            foreach (Researcher researcher in ResearcherListFiltered)
            {
                Console.WriteLine("ID:" + researcher.Id + " " + researcher.FirstName + " " + researcher.LastName + "(" + researcher.Title + ")");
            }
            Console.WriteLine("========");
        }

        public static void LoadResearcherList()
        {
            //ResearcherList = DatabaseAdaptor.FetchBasicResearcherList();

            /* fake data test */
            ResearcherList = DataGenerator.FetchBasicResearcherList();

            ResearcherListFiltered = ResearcherList;

            DisplayResearcherList();
        }

        public static void LoadResearcherDetail(int researcherId)
        {
            //SelectedResearcher = DatabaseAdaptor.FetchCompleteResearcherDetails(researcherId);

            /* fake data test */
            SelectedResearcher = DataGenerator.FetchCompleteResearcherDetails(researcherId);
            PublicationController.LoadPublicationList(SelectedResearcher);

            for (int i = 0; i < ResearcherList.Count; i++)
            {
                if (ResearcherList[i].Id == SelectedResearcher.Id)
                {
                    ResearcherList[i] = SelectedResearcher;
                    i = ResearcherList.Count;
                }
            }

            Console.WriteLine("====Researcher Detail====");
            Console.WriteLine(SelectedResearcher.DisplayResearcherDetails());
            Console.WriteLine("========");
        }

        public static void FilterResearcher(EmplymentLevel level)
        {
            List<Researcher> newResearchers = new List<Researcher>();
            foreach (Researcher researcher in ResearcherList)
            {
                if (researcher.Level == level)
                {
                    newResearchers.Add(researcher);
                }
            }

            ResearcherListFiltered = newResearchers;

            DisplayResearcherList();
        }

        public static void FilterResearcher(string name)
        {
            List<Researcher> newResearchers = new List<Researcher>();
            foreach (Researcher researcher in ResearcherList)
            {
                if (researcher.FirstName.Contains(name) || researcher.LastName.Contains(name))
                {
                    newResearchers.Add(researcher);
                }
            }

            ResearcherListFiltered = newResearchers;

            DisplayResearcherList();
        }

        public static void FilterResearcher(EmplymentLevel level, string name)
        {

        }
    }
}
