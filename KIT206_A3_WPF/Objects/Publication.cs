using System;

namespace KIT206_A3.Objects
{
    public enum PublicationType { Conference, Journal, Other, EnumCount }
    public enum Ranking { Q1, Q2, Q3, Q4, EnumCount }

    public class Publication
    {
        public string Doi { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public int PublicationYear { get; set; }
        public Ranking Rank { get; set; }
        public PublicationType Type { get; set; }
        public string Cite { get; set; }
        public DateTime AvailabilityDate { get; set; }
        public int Age
        {
            get
            {
                return GetAge();
            }
        }

        public int GetAge()
        {
            return DateTime.Now.Year - PublicationYear;
        }
    }
}
