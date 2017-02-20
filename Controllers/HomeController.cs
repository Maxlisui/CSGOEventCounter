using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSGO_Event_Recorder.Model;
using Microsoft.AspNetCore.Mvc;

namespace CSGO_Event_Recorder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("events")]
        public IActionResult Events()
        {
            return Json(DBConnector.Instance.SelectAllEvents());
        }
    }
}