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

        /* parse to T type based on name string */
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /* make connection with database */
        public static MySqlConnection GetConnection()
        {
            //connect if not yet
            if (_conn == null)
            {
                string conenctionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", _database, _dataSource, _userId, _password);
                _conn = new MySqlConnection(conenctionString);
            }
            return _conn;
        }

        /* fetch list of researcher basic information from the database */
        public static List<Researcher> FetchBasicResearcherList()
        {
            List<Researcher> basicResearcherList = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                /* select basic researcher information */
                //given_name, family_name, title used for display
                //level used for list filtering
                //supervisor_id used for staff record researcher SuperviseesList
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT id, given_name, family_name, title, level, supervisor_id FROM researcher",
                    conn
                );
                rdr = cmd.ExecuteReader();

                //for every result from the database
                while (rdr.Read())
                {
                    //researcher is student if level is null in database
                    EmplymentLevel level = !rdr.IsDBNull(4) ? ParseEnum<EmplymentLevel>(rdr.GetString(4)) : EmplymentLevel.Student;

                    //researcher is student
                    if (level == EmplymentLevel.Student)
                    {
                        basicResearcherList.Add(
                            new Student
                            {
                                Id = rdr.GetInt32(0),
                                FirstName = rdr.GetString(1),
                                LastName = rdr.GetString(2),
                                Title = rdr.GetString(3),
                                Level = level,
                                supervisor = rdr.GetInt32(5)
                            }
                        );
                    }
                    //researcher is staff
                    else
                    {
                        basicResearcherList.Add(
                            new Staff
                            {
                                Id = rdr.GetInt32(0),
                                FirstName = rdr.GetString(1),
                                LastName = rdr.GetString(2),
                                Title = rdr.GetString(3),
                                Level = level
                            }
                        );
                    }


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

        /* fetch selected researcher full information from the database */
        public static Researcher FetchFullResearcherDetails(int researcherId)
        {
            //researcher with full details
            Researcher selectedResearcher = null;

            List<Position> positions = new List<Position>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                /* select full details of researcher by researcher id */
                MySqlCommand cmdGetResearcher = new MySqlCommand(
                    "SELECT * FROM researcher WHERE id = ?id",
                    conn
                );
                cmdGetResearcher.Parameters.AddWithValue("id", researcherId);
                rdr = cmdGetResearcher.ExecuteReader();

                //for the result from the database
                if (rdr.Read())
                {
                    //researcher is student if level is null in database
                    EmplymentLevel level = !rdr.IsDBNull(11) ? ParseEnum<EmplymentLevel>(rdr.GetString(11)) : EmplymentLevel.Student;

                    //researcher is student
                    if (level == EmplymentLevel.Student)
                    {
                        //student researcher exclusive details
                        selectedResearcher = new Student
                        {
                            Degree = rdr.GetString(9),
                            supervisor = rdr.GetInt32(10)
                        };
                    }
                    //researcher is staff
                    else
                    {
                        selectedResearcher = new Staff();

                        //TODO: load funds from xml
                    }

                    /* assign general details */
                    selectedResearcher.Id = rdr.GetInt32(0);
                    selectedResearcher.Type = ParseEnum<ResearcherType>(rdr.GetString(1));
                    selectedResearcher.FirstName = rdr.GetString(2);
                    selectedResearcher.LastName = rdr.GetString(3);
                    selectedResearcher.Title = rdr.GetString(4);
                    selectedResearcher.SchoolUnit = rdr.GetString(5);
                    selectedResearcher.Campus = ParseEnum<Campus>(rdr.GetString(6).Replace(" ", ""));
                    selectedResearcher.Email = rdr.GetString(7);
                    selectedResearcher.PhotoURL = rdr.GetString(8);
                    //degree(9)             student
                    //supervisor id(10)     student
                    selectedResearcher.Level = level;
                    selectedResearcher.CommencedInstitution = rdr.GetDateTime(12);
                    selectedResearcher.CommencedPosition = rdr.GetDateTime(13);
                };
                rdr.Close();

                /* select previous position list of researcher by researcher id */
                MySqlCommand cmdGetPosition = new MySqlCommand(
                    "SELECT * FROM position WHERE id = ?id",
                    conn
                );
                cmdGetPosition.Parameters.AddWithValue("id", researcherId);
                rdr = cmdGetPosition.ExecuteReader();

                //for every result from the database
                while (rdr.Read())
                {
                    positions.Add(
                        new Position
                        {
                            //use the last char to determine the emplement level enum
                            PositionLevel = ParseEnum<EmplymentLevel>(rdr.GetString(1).Last().ToString()),
                            StartDate = rdr.GetDateTime(2),
                            //null from database treat as DateTime MinValue
                            EndDate = !rdr.IsDBNull(3) ? rdr.GetDateTime(3) : DateTime.MinValue
                        }
                    );
                }
                rdr.Close();

                //assign position to the selected researcher
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

        public static Researcher CompleteResearcherDetails(Researcher researcher)
        {
            //assign selected researcher full detail back to the researcher list
            return FetchFullResearcherDetails(researcher.Id);
        }

        public static List<Publication> FetchBasicPublicationDetails(Researcher researcher)
        {
            List<Publication> basicPublicationList = new List<Publication>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(
                    "SELECT publication.doi, publication.title, publication.year " +
                    "FROM publication " +
                    "INNER JOIN researcher_publication ON publication.doi = researcher_publication.doi " +
                    "WHERE researcher_publication.researcher_id = ?id",
                    conn
                );
                cmd.Parameters.AddWithValue("id", researcher.Id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    basicPublicationList.Add(
                        new Publication
                        {
                            Doi = rdr.GetString(0),
                            Title = rdr.GetString(1),
                            PublicationYear = rdr.GetInt32(2)
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

            return basicPublicationList;
        }

        public static Publication CompletePublicationDetails(Publication publication)
        {
            Publication selectedPublication = null;

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM publication WHERE doi = ?doi",
                    conn
                );
                cmd.Parameters.AddWithValue("doi", publication.Doi);
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    selectedPublication = new Publication
                    {
                        Doi = publication.Doi,
                        Title = publication.Title,
                        PublicationYear = publication.PublicationYear,
                        Rank = ParseEnum<Ranking>(rdr.GetString(2)),
                        Authors = rdr.GetString(3),
                        Type = ParseEnum<PublicationType>(rdr.GetString(5)),
                        Cite = rdr.GetString(6),
                        AvailabilityDate = rdr.GetDateTime(7)
                    };
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

            return selectedPublication;
        }

        public static int FetchPublicationCounts(DateTime from, DateTime to)
        {
            //when display commulative count, display each year publication count
            return 0;
        }
    }
}
