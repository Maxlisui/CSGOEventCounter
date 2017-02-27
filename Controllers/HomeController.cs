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
            ViewBag.AllEvents = DBConnector.Instance.SelectAllEvents();
            return View();
        }
    }
}