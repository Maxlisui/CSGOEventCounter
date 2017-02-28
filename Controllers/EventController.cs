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