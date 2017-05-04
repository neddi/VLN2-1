using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramWeb.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult TableTesting()
		{
			ViewBag.Message = "Your table testing page.";

			return View();
		}

        public ActionResult Editor()
        {
            ViewBag.Message = "Editor";

            return View();
        }
        public ActionResult EditorOnPage()
        {
            return View();
        }
    }
}