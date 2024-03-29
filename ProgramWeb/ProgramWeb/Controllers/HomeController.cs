﻿using Microsoft.AspNet.Identity;
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

		[Authorize]
		public ActionResult Index()
        {
            return RedirectToAction("Editor", "Project");
        }

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
    }
}


//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
//IEnumerable<Movie> model = MovieAppRepository.Instance.GetAllMovies(username);
//return View(model);