using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSGO_Event_Recorder.Model;
using Microsoft.AspNetCore.Mvc;

namespace CSGO_Event_Recorder.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult NewToEvent(int id)
        {
            ViewBag.CurrentEventId = id;
            ViewBag.TeamsNotAttending = new List<Team>();
            List<Team> teamsInEvent = DBConnector.Instance.SelectAllTeamsFromEventId(id);
            List<Team> allTeams = DBConnector.Instance.SelectAllTeams();
            
            ViewBag.TeamsNotAttending = allTeams.Where(t => !teamsInEvent.Any(t2 => t2.Id == t.Id)).ToList();

            return View();
        }

        public IActionResult AddToEvent(int teamId, int eventId)
        {
            DBConnector.Instance.InsertTeamToEvent(teamId, eventId);

            return Redirect("/Event/?Id=" + eventId);
        }

        public IActionResult Details(int id)
        {
            ViewBag.TeamDetail = DBConnector.Instance.SelectTeamFromId(id);
            var allMaps = DBConnector.Instance.SelectAllMaps().ToArray();
            int[,] mapsInfo = new int[allMaps.Count(), 6];

            for(var i = 0; i < allMaps.Length; i++)
            {
                mapsInfo[i,0] = DBConnector.Instance.SelectAttackedOnA(id, allMaps[i].Id);
                mapsInfo[i,1] = DBConnector.Instance.SelectAttackedOnASuccess(id, allMaps[i].Id);
                mapsInfo[i,2] = DBConnector.Instance.SelectAttackedOnB(id, allMaps[i].Id);
                mapsInfo[i,3] = DBConnector.Instance.SelectAttackedOnBSuccess(id, allMaps[i].Id);
                mapsInfo[i,4] = DBConnector.Instance.SelectRetakeOnASuccess(id, allMaps[i].Id);
                mapsInfo[i,5] = DBConnector.Instance.SelectRetakeOnBSuccess(id, allMaps[i].Id);
            }

            ViewBag.AllMaps = allMaps;
            ViewBag.MapsInfo = mapsInfo;

            return View();
        }

        public IActionResult Statistics()
        {
            return View();
        }

        public IActionResult UpdateStatistics(string name)
        {
            return Json(DBConnector.Instance.SelectStatisticsFromName(name));
        }
    }
}