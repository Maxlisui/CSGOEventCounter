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
            return View("Index");
        }

        public IActionResult New()
        {
            ViewBag.AllOrganizer = DBConnector.Instance.SelectAllOranizer();
            return View("New");
        }

        public IActionResult NewGame(int eventId)
        {
            ViewBag.AllMaps = DBConnector.Instance.SelectAllMaps();
            ViewBag.AllTeams = DBConnector.Instance.SelectAllTeams();
            ViewBag.CurrentEvent = eventId;
            return View("NewGame");
        }

        public IActionResult Game(int map, int team1, int team2, int eventId)
        {
            if(team1 == team2)
            {
                ViewBag.Message = "No 2 Teams";
                return NewGame(eventId);
            }
            ViewBag.Message = null;
            ViewBag.CurrentMap = DBConnector.Instance.SelectMapFromId(map);
            ViewBag.Team1 = DBConnector.Instance.SelectTeamFromId(team1);
            ViewBag.Team2 = DBConnector.Instance.SelectTeamFromId(team2);
            ViewBag.CurrentEvent = eventId;
            
            return View();
        }

        public IActionResult FinishGame(int eventId, int mapId, int team1Id, int team2Id, int scoreTeam1, int scoreTeam2,
            int team1attckedA, int team1attackedB, int team1attackedAsuccess, int team1attckedBsuccess,
            int team1retakeA, int team1retakeB, int team2attckedA, int team2attackedB, 
            int team2attackedAsuccess, int team2attckedBsuccess, int team2retakeA, int team2retakeB)
        {
            var match = new Match()
            {
                Map = mapId,
                Team1 = team1Id,
                Team2 = team2Id,
                Team1Score = scoreTeam1,
                Team2Score = scoreTeam2,
                Team1AttackedA = team1attckedA,
                Team1AttackedB = team1attackedB,
                Team1AttackedASuccess = team1attackedAsuccess,
                Team1AttackedBSuccess = team1attckedBsuccess,
                Team1RetakeASuccess = team1retakeA,
                Team1RetakeBSuccess = team1retakeB,
                Team2AttackedA = team2attckedA,
                Team2AttackedB = team2attackedB,
                Team2AttackedASuccess = team2attackedAsuccess,
                Team2AttackedBSuccess = team2attckedBsuccess,
                Team2RetakeASuccess = team2retakeA,
                Team2RetakeBSuccess = team2retakeB
            };

            DBConnector.Instance.InsertNewmatch(match);

            return Index(eventId);
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