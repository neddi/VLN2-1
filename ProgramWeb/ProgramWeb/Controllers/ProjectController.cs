using ProgramWeb.Models.ViewModel;
using ProgramWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramWeb.Controllers
{
	public class ProjectController : Controller
	{
		private ProjectService service = new ProjectService();
		// Action for Viewing Multiple tables
		public ActionResult ProjectInfo()
		{
			ProjectInfoViewModel viewModel = service.GetProjectInfo(2);

			return View(viewModel);
		}
	}
}