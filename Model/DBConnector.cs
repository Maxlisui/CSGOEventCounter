using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CSGO_Event_Recorder.Model
{
    public class DBConnector
    {
        private static DBConnector _instance;
        private static volatile object _lock = new object();
        private readonly string _CONNECTIONSTRING = "Server=localhost;Database=csgo;Uid=root;Pwd=root;";

        public static DBConnector Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_lock)
                    {
                        if(_instance == null)
                        {
                            _instance = new DBConnector();
                        }
                    }
                }
                return _instance;
            }
        }

        private DBConnector() {}

        public List<Event> SelectAllEvents()
        {
            List<Event> events = new List<Event>();

            using(var con = new MySqlConnection(_CONNECTIONSTRING))
            {
                using(var command = new MySqlCommand("", con))
                {
                    con.Open();
                    command.CommandText = "SELECT * FROM event";

                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            events.Add(new Event()
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Date = reader.GetDateTime("Date").ToString("d"),
                                Venue = reader.GetString("Venue"),
                                OrganizerID = reader.GetInt32("Organizer"),
                                Organizer = SelectOrganizerFromId(reader.GetInt32("Organizer")) ?? new Organizer()
                            });
                        }
                    }
                }
            }
            return events;
        }

        public Organizer SelectOrganizerFromId(int id)
        {
            Organizer organizer = null;

            using(var con = new MySqlConnection(_CONNECTIONSTRING))
            {
                using(var command = new MySqlCommand("", con))
                {
                    con.Open();
                    command.CommandText = "SELECT * FROM organizer WHERE Id = @Id";
                    command.Prepare();

                    command.Parameters.AddWithValue("@Id", id);

                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            organizer = new Organizer()
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Logo = reader.GetString("Logo")
                            };
                        }
                    }
                }
            }
            return organizer;
        }

        public List<Organizer> SelectAllOranizer()
        {
            List<Organizer> organizer = new List<Organizer>();

            using(var con = new MySqlConnection(_CONNECTIONSTRING))
            {
                using(var command = new MySqlCommand("", con))
                {
                    con.Open();
                    command.CommandText = "SELECT * FROM organizer";

                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            organizer.Add(new Organizer()
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Logo = reader.GetString("Logo")
                            });
                        }
                    }
                }
            }
            return organizer;
        }

    }
}