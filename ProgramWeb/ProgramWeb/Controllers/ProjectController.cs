using ProgramWeb.Models.Entities;
using ProgramWeb.Models.ViewModel;
using ProgramWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProgramWeb.Controllers
{
	public class ProjectController : Controller
	{
		private ProjectService service = new ProjectService();
		// Action for Viewing Multiple tables
		public ActionResult ProjectInfo(int id)
		{
			ProjectInfoViewModel viewModel = service.GetProjectInfo(id);

			return View(viewModel);
		}
        [HttpGet]
        public ActionResult File()
        {
            var projectService = new ProjectService();
            //hardcoded value for open file
            var fileModel = projectService.OpenFile(2);
            return View(fileModel);
        }

        [HttpPost]
        public ActionResult File(Files filefromView)
        {
            var projectService = new ProjectService();
            var fileToSave = new Files();
            fileToSave.ID = filefromView.ID;
            fileToSave.FileType = filefromView.FileType;
            fileToSave.Name = filefromView.Name;
            fileToSave.Content = filefromView.Content;

            if (projectService.SaveFile(fileToSave))
            {
                return RedirectToRoute("Index", "Home");
            }
            return View(fileToSave);
        }
		[HttpGet]
		public ActionResult UpdateProjectInfo(int id)
		{
			ProjectInfoViewModel data = service.GetProjectInfo(id);
			var viewModel = new UpdateProjectInfoViewModel();
			viewModel.Id = data.Id;
			viewModel.Name = data.Name;
			viewModel.Description = data.Description;

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult UpdateProjectInfo(UpdateProjectInfoViewModel model)
		{
			if(ModelState.IsValid)
			{
				ProjectInfoViewModel data = service.GetProjectInfo(model.Id);
				data.Name = model.Name;
				data.Description = model.Description;
				service.UpdateProjectInfo(data);
				return RedirectToAction("ProjectInfo", new { Message = "Project Updated succesfully" });
			}

			return View(model);
		}
	}
}