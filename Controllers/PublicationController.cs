﻿
using KIT206A3WPF.Database;
using KIT206A3WPF.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KIT206A3WPF.Controllers
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

        public static void LoadPublicationList(int startYear, int endYear)
        {
            var filtered =
                from Publication pub in PublicationList
                where pub.PublicationYear >= startYear && pub.PublicationYear <= endYear
                select pub;

            PublicationListFiltered = new List<Publication>(filtered);
        }

        /* fake data test */
        public static void LoadPublicationDetails(int listIndex)
        {
            SelectedPublication = PublicationListFiltered[listIndex];
            SelectedPublication = DatabaseAdaptor.CompletePublicationDetails(SelectedPublication);

            Console.WriteLine("====Publication Detail====");
            DisplayPublicationDetails();
            Console.WriteLine("========");
        }

        public static void InvertPublicationList()
        {
            PublicationListFiltered.Reverse();
        }
    }
}
