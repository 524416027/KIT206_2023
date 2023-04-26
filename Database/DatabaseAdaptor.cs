using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using KIT206_A3.Objects;
using KIT206_A3.Controllers;

namespace KIT206_A3.Database
{
    class DatabaseAdaptor
    {
        private string _database = "kit206";
        private string _userId = "kit206";
        private string _password = "kit206";
        private string _dataSource = "alacritas.cis.utas.edu.au";

        public static void DatabaseConnect()
        {

        }

        public static List<Researcher> FetchBasicResearcherList()
        {
            //name, title, level for display in ResearcherList
            return null;
        }

        public static Researcher FetchCompleteResearcherDetails(int researcherId)
        {
            //full details for display in ResearcherDetails after select
            return null;
        }

        public static List<Publication> FetchPublicationList(Researcher researcher)
        {
            //basic publication name for display in PublicationList
            return null;
        }

        public static Publication FetchCompletePublicationDetails(Publication publication)
        {
            return null;
        }

        public static int FetchPublicationCounts(DateTime from, DateTime to)
        {
            //when display commulative count, display each year publication count
            return 0;
        }
    }

    abstract class DataGenerator
    {
        public static List<Researcher> ResearcherListData;

        public static List<Researcher> FetchBasicResearcherList()
        {
            List<Researcher> returnResearchers = new List<Researcher>();

            foreach (Researcher researcher in ResearcherListData)
            {
                Researcher toAdd = new Researcher
                {
                    Id = researcher.Id,
                    FirstName = researcher.FirstName,
                    LastName = researcher.LastName,
                    Title = researcher.Title,
                    Level = researcher.Level
                };

                returnResearchers.Add(toAdd);
            }

            return returnResearchers;
        }

        public static Researcher FetchCompleteResearcherDetails(int researcherId)
        {
            Researcher returnResearcher = null;

            foreach (Researcher researcherData in ResearcherListData)
            {
                if (researcherData.Id == researcherId)
                {
                    returnResearcher = new Researcher
                    {
                        Id = researcherData.Id,
                        FirstName = researcherData.FirstName,
                        LastName = researcherData.LastName,
                        Title = researcherData.Title,
                        Level = researcherData.Level,
                        SchoolUnit = researcherData.SchoolUnit,
                        Campus = researcherData.Campus,
                        Email = researcherData.Email,
                        JobTitle = researcherData.JobTitle,
                        CommencedInstitution = researcherData.CommencedInstitution,
                        CommencedPosition = researcherData.CommencedPosition,
                        PreviousPositions = researcherData.PreviousPositions,
                        PublicationCount = researcherData.PublicationCount,
                        PublicationList = null
                    };
                }
            }
            return returnResearcher;
        }

        public static List<Publication> FetchBasicPublicationList(Researcher researcher)
        {
            /* fake data test */
            List<Publication> returnPublications = new List<Publication>();

            foreach (Researcher data in ResearcherListData)
            {
                if (data.Id == researcher.Id)
                {
                    foreach (Publication pub in data.PublicationList)
                    {
                        Publication newPub = new Publication
                        {
                            PublicationYear = pub.PublicationYear,
                            Title = pub.Title
                        };

                        returnPublications.Add(newPub);
                    }
                }
            }
            return returnPublications;
        }

        public static List<Publication> FetchBasicPublicationList(Researcher researcher, int startYear, int endYear)
        {
            /* fake data test */
            List<Publication> returnPublications = new List<Publication>();

            foreach (Researcher data in ResearcherListData)
            {
                if (data.Id == researcher.Id)
                {
                    foreach (Publication pub in data.PublicationList)
                    {
                        if (pub.PublicationYear >= startYear && pub.PublicationYear <= endYear)
                        {
                            Publication newPub = new Publication
                            {
                                PublicationYear = pub.PublicationYear,
                                Title = pub.Title
                            };

                            returnPublications.Add(newPub);
                        }
                    }
                }
            }
            return returnPublications;
        }

        public static Publication FetchCompletePublicationDetails(Publication publication)
        {
            foreach (Researcher researcherData in ResearcherListData)
            {
                foreach (Publication publicationData in researcherData.PublicationList)
                {
                    if (publicationData.Title == publication.Title && publicationData.PublicationYear == publication.PublicationYear)
                    {
                        publication.Doi = publicationData.Doi;
                        publication.Authors = publicationData.Authors;
                        publication.Ranking = publicationData.Ranking;
                        publication.Type = publicationData.Type;
                        publication.Cite = publicationData.Cite;
                        publication.AvailabilityDate = publicationData.AvailabilityDate;
                        publication.Age = publicationData.Age;
                    }
                }
            }
            return publication;
        }

        public static void Generate()
        {
            ResearcherListData = new List<Researcher>()
            {
                new Staff
                {
                    Id = 1,
                    FirstName = "bill",
                    LastName = "zhao",
                    Title = "mr",
                    Level = EmplymentLevel.B,
                    SchoolUnit = "utas",
                    Campus = "newhamn",
                    Email = "test.utas.edu.au",
                    JobTitle = "lecturer",
                    CommencedInstitution = DateTime.Today,
                    CommencedPosition = DateTime.MinValue,
                    PreviousPositions = new List<Position>()
                    {
                        new Position {
                            PositionTitle = "pos1",
                            startDate = DateTime.Today,
                            endDate = DateTime.Today
                            },
                        new Position{
                            PositionTitle = "pos2",
                            startDate = DateTime.Today,
                            endDate = DateTime.Today
                            }
                    },
                    PublicationCount = 10,
                    PublicationList = new List<Publication>()
                    {
                        new Publication
                        {
                            Doi = "doi",
                            Title = "stitle",
                            Authors = new List<string>() { "author1", "autor2" },
                            PublicationYear = 2020,
                            Ranking = 9,
                            Type = PublicationType.Journal,
                            Cite = "cite",
                            AvailabilityDate = DateTime.Today,
                            Age = 3
                        },
                        new Publication
                        {
                            Doi = "doi2",
                            Title = "ftitle2",
                            Authors = new List<string>() { "author12", "autor22" },
                            PublicationYear = 2021,
                            Ranking = 29,
                            Type = PublicationType.Conference,
                            Cite = "cite2",
                            AvailabilityDate = DateTime.Today,
                            Age = 1
                        },
                        new Publication
                        {
                            Doi = "doi2",
                            Title = "ctitle2",
                            Authors = new List<string>() { "author12", "autor22" },
                            PublicationYear = 2009,
                            Ranking = 29,
                            Type = PublicationType.Conference,
                            Cite = "cite2",
                            AvailabilityDate = DateTime.Today,
                            Age = 1
                        },
                        new Publication
                        {
                            Doi = "doi2",
                            Title = "atitle2",
                            Authors = new List<string>() { "author12", "autor22" },
                            PublicationYear = 2014,
                            Ranking = 29,
                            Type = PublicationType.Conference,
                            Cite = "cite2",
                            AvailabilityDate = DateTime.Today,
                            Age = 1
                        }
                    },
                    FundingReceived = 1000,
                    SupervisionCount = 0,
                    Supervisees = null
                },
                new Student
                {
                    Id = 2,
                    FirstName = "haowei",
                    LastName = "sun",
                    Title = "mr2",
                    Level = EmplymentLevel.Student,
                    SchoolUnit = "utas2",
                    Campus = "newhamn2",
                    Email = "test2.utas.edu.au",
                    JobTitle = "student",
                    CommencedInstitution = DateTime.Today,
                    CommencedPosition = DateTime.MinValue,
                    PreviousPositions = new List<Position>()
                    {
                        new Position {
                            PositionTitle = "pos1",
                            startDate = DateTime.Today,
                            endDate = DateTime.Today
                            },
                        new Position{
                            PositionTitle = "pos2",
                            startDate = DateTime.Today,
                            endDate = DateTime.Today
                            }
                    },
                    PublicationCount = 10,
                    PublicationList = new List<Publication>()
                    {
                        new Publication
                        {
                            Doi = "doi",
                            Title = "stitle",
                            Authors = new List<string>() { "author1", "autor2" },
                            PublicationYear = 2021,
                            Ranking = 9,
                            Type = PublicationType.Journal,
                            Cite = "cite",
                            AvailabilityDate = DateTime.Today,
                            Age = 3
                        },
                        new Publication
                        {
                            Doi = "doi2",
                            Title = "ftitle2",
                            Authors = new List<string>() { "author12", "autor22" },
                            PublicationYear = 2021,
                            Ranking = 29,
                            Type = PublicationType.Conference,
                            Cite = "cite2",
                            AvailabilityDate = DateTime.Today,
                            Age = 1
                        },
                        new Publication
                        {
                            Doi = "doi2",
                            Title = "ctitle2",
                            Authors = new List<string>() { "author12", "autor22" },
                            PublicationYear = 2009,
                            Ranking = 29,
                            Type = PublicationType.Conference,
                            Cite = "cite2",
                            AvailabilityDate = DateTime.Today,
                            Age = 1
                        },
                        new Publication
                        {
                            Doi = "doi2",
                            Title = "atitle2",
                            Authors = new List<string>() { "author12", "autor22" },
                            PublicationYear = 2014,
                            Ranking = 29,
                            Type = PublicationType.Conference,
                            Cite = "cite2",
                            AvailabilityDate = DateTime.Today,
                            Age = 1
                        },
                        new Publication
                        {
                            Doi = "doi2",
                            Title = "atitle2",
                            Authors = new List<string>() { "author12", "autor22" },
                            PublicationYear = 2014,
                            Ranking = 29,
                            Type = PublicationType.Conference,
                            Cite = "cite2",
                            AvailabilityDate = DateTime.Today,
                            Age = 1
                        }
                    },
                    Degree = "phd",
                    supervisor = null
                }
            };
        }
    }
}
