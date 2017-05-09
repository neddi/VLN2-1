using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ProgramWeb.Models;
using ProgramWeb.Models.ViewModel;
using System.Web.Mvc;
using ProgramWeb.Services;
using ProgramWeb.Models.Entities;

namespace ProgramWeb.Controllers
{
    public class HomeController : Controller
    {
        private ProjectService projectService;
        private UserService userService;

        public ActionResult Index()
<<<<<<< HEAD
        {
            return View();
        }
        [Authorize]
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
            ViewBag.Info = currentUser.Info;

            return View();
        }
=======
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
>>>>>>> refs/remotes/origin/master

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


<<<<<<< HEAD


=======
>>>>>>> refs/remotes/origin/master
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
            Projects entity = new Projects();
            entity.Name = model.Name;
            entity.Description = model.Description;
            var currentUser = System.Web.HttpContext.Current.User.Identity.GetUserId();
            projectService = new ProjectService();
<<<<<<< HEAD
            if (projectService.NewProject(entity))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateFile()
        {
            NewFileViewModel model = new NewFileViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateFile(NewFileViewModel model)
        {
            NewFileViewModel entity = new NewFileViewModel();
            //entity.ProjectId = model.ProjectId;
            entity.ProjectId = 2;
            Files newFile = model.File;
            entity.File = newFile;

            projectService = new ProjectService();
            if (projectService.NewFile(entity))
=======
            if ( projectService.NewProject(entity, currentUser) )
>>>>>>> refs/remotes/origin/master
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
<<<<<<< HEAD

        [HttpGet]
        public ActionResult GetGameListing()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
=======
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
		[HttpGet]
		public ActionResult CreateFile()
		{
			NewFileViewModel model = new NewFileViewModel();
			return View(model);
		}
		[HttpPost]
		public ActionResult CreateFile(NewFileViewModel model)
		{
			NewFileViewModel entity = new NewFileViewModel();
			//entity.ProjectId = model.ProjectId;
			entity.ProjectId = 2;
			Files newFile = model.File;
			entity.File = newFile;

			projectService = new ProjectService();
			if (projectService.NewFile(entity))
			{
				return RedirectToAction("Index");
			}
			return View(model);
		}
	}
>>>>>>> refs/remotes/origin/master

            // Recover the profile information about the logged in user
            ViewBag.Name = currentUser.UserName;
            ViewBag.FullName = currentUser.FullName;
            ViewBag.Email = currentUser.Email;
            ViewBag.Info = currentUser.Info;

<<<<<<< HEAD
            return View();
        }
    }
=======

>>>>>>> refs/remotes/origin/master
}

//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
//IEnumerable<Movie> model = MovieAppRepository.Instance.GetAllMovies(username);
//return View(model);