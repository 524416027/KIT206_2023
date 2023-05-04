using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KIT206_A3.Controllers;
using KIT206_A3.Objects;
using KIT206_A3.Database;

namespace KIT206_A3
{
    class Program
    {
        public static void Main(string[] args)
        {
            DataGenerator.Generate();

            ResearcherController.LoadResearcherList();

            int userSelect = -1;

            while (userSelect != 0)
            {
                Console.WriteLine(
                    "Options to select:\n" +
                    "0. Quit console\n" +
                    "1. Display researcher list\n" +
                    "2. Enter ID to select a reasearcher\n" +
                    "3. Filter researcher with name\n" +
                    "4. Filter researcher with employment level\n" +
                    "5. Display publication list of selected researcher\n" +
                    "6. Invert publication order\n" +
                    "7. Filter publication by publish year\n" +
                    "8. Enter publication index display publication detail\n" +
                    "9. Coumulative count of selected researcher"
                    );
                userSelect = int.Parse(Console.ReadLine());
                switch (userSelect)
                {
                    case 1:
                        ResearcherController.DisplayResearcherList();
                        break;
                    case 2:
                        Console.Write("Select researcher by ID: ");
                        int selectResearcherId = int.Parse(Console.ReadLine());
                        ResearcherController.LoadResearcherDetail(selectResearcherId);
                        break;
                    case 3:
                        //filter researcher name
                        Console.Write("Filter researcher by name: ");
                        string filterName = Console.ReadLine();
                        ResearcherController.FilterResearcher(filterName);
                        break;
                    case 4:
                        //filter researcher level
                        Console.Write(
                            "Filter researcher by employment level:\n" +
                            "1. Student\n" +
                            "2. Level A\n" +
                            "3. Level B\n" +
                            "4. Level C\n" +
                            "5. Level D\n" +
                            "6. Level E\n"
                            );
                        int selectLevelIndex = int.Parse(Console.ReadLine());
                        EmplymentLevel selectLevel = (EmplymentLevel)selectLevelIndex - 1;
                        ResearcherController.FilterResearcher(selectLevel);
                        break;
                    case 5:
                        //PublicationController.DisplayPublicationList();
                        break;
                    case 6:
                        //invert order
                        PublicationController.InvertPublicationList();
                        break;
                    case 7:
                        //filter year
                        Console.Write("Publication year [startYear, endYear]: ");
                        string[] years = Console.ReadLine().Split(',');
                        PublicationController.LoadPublicationList(int.Parse(years[0]), int.Parse(years[1]));

                        Console.WriteLine("year input: " + int.Parse(years[0]) + " to " + int.Parse(years[1]));
                        break;
                    case 8:
                        Console.Write("Publication index select to display: ");
                        int selectPublicationIndex = int.Parse(Console.ReadLine());
                        PublicationController.LoadPublicationDetails(selectPublicationIndex - 1);
                        break;
                    case 9:
                        ResearcherController.CumulativeCount();
                        break;
                }
            }
            //List<Researcher> researchers = DataGenerator.Generate();

            //Console.WriteLine(researchers[0].ToString());
        }
    }
}
