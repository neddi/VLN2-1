using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ProgramWeb.Models;
using ProgramWeb.Models.ViewModel;
using System.Web.Mvc;
using ProgramWeb.Services;

namespace ProgramWeb.Controllers
{
	public class HomeController : Controller
	{
        private ProjectService projectService;
        private UserService userService;

        public ActionResult Index()
		{
			return View();
		}

        [Authorize]
		public ActionResult About()
		{
			ViewBag.Message = "Your testing page.";
            projectService = new ProgramWeb.Services.ProjectService();
            System.Collections.Generic.IEnumerable<ProjectViewModel> projects = projectService.ListAllProjects();
            if (projects == null)
            {
                return RedirectToAction("Index");
            }
            return View(projects);
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

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

        [HttpGet]
        public ActionResult CreateProject()
        {
            ProjectViewModel model = new ProjectViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateProject(ProjectViewModel model)
        {
            ProgramWeb.Models.Entities.Projects entity = new Models.Entities.Projects();
            entity.Name = model.Name;
            entity.Description = model.Description;
            var currentUser = System.Web.HttpContext.Current.User.Identity.GetUserId();
            projectService = new ProjectService();
             if ( projectService.NewProject(entity, currentUser) )
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Invite()
        {
            UserService userServ = new UserService();
            ViewBag.Message = "Your testing page.";
            System.Collections.Generic.IEnumerable<UserInfoViewModel> users = userServ.ListAllUsers();
            if (users == null)
            {
                RedirectToAction("Index");
            }
            return View(users);
        }
        [HttpPost]
        public ActionResult Invite(string invUser)
        {
           string invitedUserId = "aa514bbb - 6278 - 429f - a285 - 851caab053a5";
            //TODO tengja við service
            ProjectService projServ = new ProjectService();
            if (projServ.AddUserToProject(invitedUserId))
            { 
                return RedirectToAction("Index");
            }
            return View();
        }
    }


}

//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
//IEnumerable<Movie> model = MovieAppRepository.Instance.GetAllMovies(username);
//return View(model);