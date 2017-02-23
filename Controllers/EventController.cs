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

        [Route("/event/organizer")]
        public IActionResult Organizer()
        {
            return Json(DBConnector.Instance.SelectAllOranizer());
        }

        [Route("/event/new")]
        public IActionResult New()
        {
            return View();
        }

        [Route("/event/add")]
        [HttpPost]
        public IActionResult Add(Event e)
        {
            return Content("Hans");
        }

    }
}