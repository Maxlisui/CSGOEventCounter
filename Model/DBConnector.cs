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

        public void InsertEvent(Event e)
        {
            using(var con = new MySqlConnection(_CONNECTIONSTRING))
            {
                using(var command = new MySqlCommand("", con))
                {
                    con.Open();
                    command.CommandText = "INSERT INTO event VALUES (@id, @name, @date, @venue, @organizer)";
                    command.Prepare();

                    command.Parameters.AddWithValue("@id", e.Id);
                    command.Parameters.AddWithValue("@name", e.Name);
                    command.Parameters.AddWithValue("@date", e.Date);
                    command.Parameters.AddWithValue("@venue", e.Venue);
                    command.Parameters.AddWithValue("@organizer", e.OrganizerID);

                    command.ExecuteNonQuery();
                }
            }
        }

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

        public Event SelectEventFromId(int id)
        {
            Event e = null;

            using(var con = new MySqlConnection(_CONNECTIONSTRING))
            {
                using(var command = new MySqlCommand("", con))
                {
                    con.Open();

                    command.CommandText = "SELECT * from event WHERE Id = @Id";
                    command.Prepare();

                    command.Parameters.AddWithValue("@Id", id);       

                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            e = new Event()
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Date = reader.GetDateTime("Date").ToString("d"),
                                Venue = reader.GetString("Venue"),
                                OrganizerID = reader.GetInt32("Organizer"),
                                Organizer = SelectOrganizerFromId(reader.GetInt32("Organizer")) ?? new Organizer()

                            };
                        }
                    }
                }
            }
            return e;
        }
        public List<Team> SelectAllTeamsFromEventId(int id)
        {
            List<Team> teams = new List<Team>();

            using(var con = new MySqlConnection(_CONNECTIONSTRING))
            {
                using(var command = new MySqlCommand("", con))
                {
                    con.Open();

                    command.CommandText = "SELECT DISTINCT team.Id, team.Name, team.logo, team.Country FROM  team join team_on_event on (TeamID = ID)" 
                        + "join event on (EventID = event.ID) where event.ID = @Id";
                    command.Prepare();

                    command.Parameters.AddWithValue("@Id", id);

                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            teams.Add(new Team(){
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Logo = reader.GetString("Logo"),
                                Country = reader.GetString("Country")
                            });
                        }
                    }
                }
            }
            return teams;
        }

        public Team SelectTeamFromId(int id)
        {
            Team team = new Team();

            using(var con = new MySqlConnection(_CONNECTIONSTRING))
            {
                using(var command = new MySqlCommand("", con))
                {
                    con.Open();
                    
                    command.CommandText = "SELECT * FROM team WHERE Id = @Id";
                    command.Prepare();

                    command.Parameters.AddWithValue("@Id", id);
                    
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            team = new Team(){
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Logo = reader.GetString("Logo"),
                                Country = reader.GetString("Country")
                            };
                        }
                    }
                }
            }
            return team;
        }

        public List<Team> SelectAllTeams()
        {
            List<Team> teams = new List<Team>();

            using(var con = new MySqlConnection(_CONNECTIONSTRING))
            {
                using(var command = new MySqlCommand("", con))
                {
                    con.Open();
                    
                    command.CommandText = "SELECT * FROM team";
                    
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            teams.Add(new Team(){
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Logo = reader.GetString("Logo"),
                                Country = reader.GetString("Country")
                            });
                        }
                    }
                }
            }
            return teams;
        }

        public void InsertTeamToEvent(int teamId, int eventId)
        {
            using(var con = new MySqlConnection(_CONNECTIONSTRING))
            {
                using(var command = new MySqlCommand("", con))
                {
                    con.Open();

                    command.CommandText = "INSERT INTO team_on_event VALUES(@teamId, @eventId)";
                    command.Prepare();

                    command.Parameters.AddWithValue("@teamId", teamId);
                    command.Parameters.AddWithValue("@eventId", eventId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}