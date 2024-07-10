using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razor.Controllers
{
    public class HolaMundoCController : Controller
    {
        // GET: HolaMundoC
        public ActionResult Index()
        {
            return View();
        }
    }
}