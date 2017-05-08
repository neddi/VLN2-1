﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

        public ActionResult Index()
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
			Projects entity = new Projects();
            entity.Name = model.Name;
            entity.Description = model.Description;
            projectService = new ProjectService();
             if ( projectService.NewProject(entity) )
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
			{
				return RedirectToAction("Index");
			}
			return View(model);
		}
	}


}

//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
//IEnumerable<Movie> model = MovieAppRepository.Instance.GetAllMovies(username);
//return View(model);