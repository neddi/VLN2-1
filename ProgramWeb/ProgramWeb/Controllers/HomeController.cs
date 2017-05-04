using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramWeb.Models.ViewModel;
using ProgramWeb.Services;



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

			return View();
		}
        public ActionResult Editor()
        {
            List<TestData> projects = new List<TestData>();
            {
                new TestData { ID = '1', Name = "First Project", Files = { "First File", "Second File" } };
                new TestData { ID = '2', Name = "Second Project", Files = { "First File", "Second File" } };
                new TestData { ID = '3', Name = "Third Project", Files = { "First File", "Second File" } };
                new TestData { ID = '4', Name = "Fourth Project", Files = { "First File", "Second File" } };
                new TestData { ID = '5', Name = "Fifth Project", Files = { "First File", "Second File" } };
            };
            return View(projects);
        }
	}
}

//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
//IEnumerable<Movie> model = MovieAppRepository.Instance.GetAllMovies(username);
//return View(model);