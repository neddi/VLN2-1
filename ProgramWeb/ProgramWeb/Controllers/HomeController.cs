using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramWeb.Models.ViewModel;
using ProgramWeb.Services;
using Microsoft.AspNet.Identity.EntityFramework;

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

		//Temporary Action for testing of tables
		public ActionResult TableTesting()
		{
			UserService service = new UserService();
			ViewBag.Message = "Your table testing page.";

			List<IdentityUser> data = service.ListAllUsers();

			return View(data);
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

//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
//IEnumerable<Movie> model = MovieAppRepository.Instance.GetAllMovies(username);
//return View(model);