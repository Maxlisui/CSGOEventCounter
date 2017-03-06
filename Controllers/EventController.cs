using System;
using CSGO_Event_Recorder.Model;
using Microsoft.AspNetCore.Mvc;

namespace CSGO_Event_Recorder.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index(int id)
        {
            ViewBag.CurrentEvent = DBConnector.Instance.SelectEventFromId(id);
            ViewBag.TeamsInCurrentEvent = DBConnector.Instance.SelectAllTeamsFromEventId(id);
            return View();
        }

        public IActionResult New()
        {
            ViewBag.AllOrganizer = DBConnector.Instance.SelectAllOranizer();
            return View("New");
        }

        public IActionResult NewGame()
        {
            ViewBag.AllMaps = DBConnector.Instance.SelectAllMaps();
            ViewBag.AllTeams = DBConnector.Instance.SelectAllTeams();
            return View("NewGame");
        }

        public IActionResult Game(int map, int team1, int team2)
        {
            if(team1 == team2)
            {
                ViewBag.Message = "No 2 Teams";
                return NewGame();
            }
            ViewBag.Message = null;
            ViewBag.CurrentMap = DBConnector.Instance.SelectMapFromId(map);
            ViewBag.Team1 = DBConnector.Instance.SelectTeamFromId(team1);
            ViewBag.Team2 = DBConnector.Instance.SelectTeamFromId(team2);
            
            return View();
        }

        public IActionResult Add(string name, string date, string venue, string organizer)
        {
            if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(venue) )
            {
                DBConnector.Instance.InsertEvent(new Event(){
                    Id = DBConnector.Instance.SelectAllEvents().Count + 1,
                    Name = name,
                    Date = date,
                    Venue = venue,
                    OrganizerID = Convert.ToInt32(organizer),
                    Organizer = DBConnector.Instance.SelectOrganizerFromId(Convert.ToInt32(organizer))
                });

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "ForgotSomething";
                return New();
            }
        }
    }
}