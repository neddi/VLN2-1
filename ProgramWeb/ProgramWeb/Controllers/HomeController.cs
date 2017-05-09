using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProgramWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramWeb.Models.ViewModel;
using ProgramWeb.Services;



namespace ProgramWeb.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return RedirectToAction("Editor");
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            // Get the current logged in User and look up the user in ASP.NET Identity
            var currentUser = manager.FindById(User.Identity.GetUserId());

            // Recover the profile information about the logged in user
            ViewBag.Name = currentUser.UserName;
            ViewBag.FullName = currentUser.FullName;
            ViewBag.Email = currentUser.Email;

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

			ViewBag.Name = "dabbitesterfucktard";

            return View(projects);
        }
        
	}
}

//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
//IEnumerable<Movie> model = MovieAppRepository.Instance.GetAllMovies(username);
//return View(model);