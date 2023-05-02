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
        private static MySqlConnection _conn = null;

        private static string _database = "kit206";
        private static string _userId = "kit206";
        private static string _password = "kit206";
        private static string _dataSource = "alacritas.cis.utas.edu.au";

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static MySqlConnection GetConnection()
        {
            if (_conn == null)
            {
                string conenctionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", _database, _dataSource, _userId, _password);
                _conn = new MySqlConnection(conenctionString);
            }
            return _conn;
        }

        public static List<Researcher> FetchBasicResearcherList()
        {
            //name, title, level for display in ResearcherList
            List<Researcher> basicResearcherList = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(
                    "SELECT id, given_name, family_name, title FROM researcher",
                    conn
                );
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    basicResearcherList.Add(
                        new Researcher
                        {
                            Id = rdr.GetInt32(0),
                            FirstName = rdr.GetString(1),
                            LastName = rdr.GetString(2),
                            Title = rdr.GetString(3)
                        }
                    );
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return basicResearcherList;
        }

        public static Researcher FetchCompleteResearcherDetails(int researcherId)
        {
            //full details for display in ResearcherDetails after select
            Researcher selectedResearcher = null;
            List<Position> positions = new List<Position>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                /* fetch researcher details by id of selected researcher */
                MySqlCommand cmdGetResearcher = new MySqlCommand(
                    "SELECT * FROM researcher WHERE id = ?id",
                    conn
                );
                cmdGetResearcher.Parameters.AddWithValue("id", researcherId);
                rdr = cmdGetResearcher.ExecuteReader();

                if (rdr.Read())
                {
                    selectedResearcher = new Researcher
                    {
                        Id = rdr.GetInt32(0),
                        Type = ParseEnum<ResearcherType>(rdr.GetString(1)),
                        FirstName = rdr.GetString(2),
                        LastName = rdr.GetString(3),
                        Title = rdr.GetString(4),
                        SchoolUnit = rdr.GetString(5),
                        Campus = ParseEnum<Campus>(rdr.GetString(6).Replace(" ", "")),
                        Email = rdr.GetString(7),
                        PhotoURL = rdr.GetString(8),
                        //degree(9)
                        //supervisor id(10)
                        Level = ParseEnum<EmplymentLevel>(rdr.GetString(11)),
                        CommencedInstitution = rdr.GetDateTime(12),
                        CommencedPosition = rdr.GetDateTime(13)
                    };

                    //researcher is staff
                    if (selectedResearcher.Type == ResearcherType.Staff)
                    {

                    }
                    //researcher is student
                    else
                    {
                        Student studentResearcher = selectedResearcher as Student;

                        studentResearcher.Degree = rdr.GetString(9);
                        studentResearcher.supervisor = rdr.GetInt32(10);

                        selectedResearcher = studentResearcher;
                    }
                };
                rdr.Close();

                /* fetch researcher previous position list by id of selected researcher */
                MySqlCommand cmdGetPosition = new MySqlCommand(
                    "SELECT * FROM position WHERE id = ?id",
                    conn
                );
                cmdGetPosition.Parameters.AddWithValue("id", researcherId);
                rdr = cmdGetPosition.ExecuteReader();

                while (rdr.Read())
                {
                    positions.Add(
                        new Position
                        {
                            //use the last char to determine the emplement level enum
                            PositionLevel = ParseEnum<EmplymentLevel>(rdr.GetString(1).Last().ToString()),
                            StartDate = rdr.GetDateTime(2),
                            //DateTime MinValue treat as null
                            EndDate = !rdr.IsDBNull(3) ? rdr.GetDateTime(3) : DateTime.MinValue
                        }
                    );
                }
                rdr.Close();

                selectedResearcher.PreviousPositions = positions;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return selectedResearcher;
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
                    }
                }
            }
            return publication;
        }

        public static void Generate()
        {
            /*
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
                    Campus = Campus.Hobart,
                    Email = "test.utas.edu.au",
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
                            AvailabilityDate = DateTime.Today
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
                            AvailabilityDate = DateTime.Today
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
                            AvailabilityDate = DateTime.Today
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
                            AvailabilityDate = DateTime.Today
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
                    Campus = Campus.Launceston,
                    Email = "test2.utas.edu.au",
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
                            AvailabilityDate = DateTime.Today
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
                            AvailabilityDate = DateTime.Today
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
                            AvailabilityDate = DateTime.Today
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
                            AvailabilityDate = DateTime.Today
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
                            AvailabilityDate = DateTime.Today
                        }
                    },
                    Degree = "phd",
                    supervisor = null
                }
            };
            */
        }
    }
}
