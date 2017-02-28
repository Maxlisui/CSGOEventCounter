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
    }
}