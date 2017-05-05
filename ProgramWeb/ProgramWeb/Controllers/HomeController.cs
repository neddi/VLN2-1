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
            
            for (int i = 0; i < 5; i++)
            {
                TestData newUser = new TestData();
                newUser.Files = new List<string>();
                newUser.ID = i;
                newUser.Name = "Project " + i;
                newUser.Files.Add("File 1");
                newUser.Files.Add("File 2");

                projects.Add(newUser);
            }
            return View(projects);
        }
        
	}
}

//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
//IEnumerable<Movie> model = MovieAppRepository.Instance.GetAllMovies(username);
//return View(model);