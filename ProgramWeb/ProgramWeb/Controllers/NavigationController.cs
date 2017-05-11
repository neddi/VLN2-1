using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramWeb.Models.ViewModel;
using ProgramWeb.Services;
using Microsoft.AspNet.Identity;

namespace ProgramWeb.Controllers
{
	public class NavigationController : Controller
	{
		// GET: Navigation
		public ActionResult Menu()
		{
			ProjectService thisUser = new ProjectService(null);

			UserProjectsViewModel projects = new UserProjectsViewModel();
			projects = thisUser.GetUserProject(User.Identity.GetUserId());

			return PartialView("_SideBarNavigation", projects);
		}

	}
}


