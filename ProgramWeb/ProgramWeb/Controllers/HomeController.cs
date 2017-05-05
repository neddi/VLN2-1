﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProgramWeb.Models;
using System.Web.Mvc;

namespace ProgramWeb.Controllers
{
	public class HomeController : Controller
	{
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
    }
}

//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
//IEnumerable<Movie> model = MovieAppRepository.Instance.GetAllMovies(username);
//return View(model);