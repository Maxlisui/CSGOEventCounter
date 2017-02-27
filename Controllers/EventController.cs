using CSGO_Event_Recorder.Model;
using Microsoft.AspNetCore.Mvc;

namespace CSGO_Event_Recorder.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            ViewBag.AllOrganizer = DBConnector.Instance.SelectAllOranizer();
            return View();
        }

        public string Add(Event e)
        {
            return "Anderes Hans";
        }
    }
}