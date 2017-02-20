using Microsoft.AspNetCore.Mvc;

namespace CSGO_Event_Recorder.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/event/new")]
        public IActionResult New()
        {
            return View();
        }
    }
}