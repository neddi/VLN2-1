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
		private ProjectService service = new ProjectService(null);
		// Action for Viewing Multiple tables
		public ActionResult ProjectInfo(int id)
		{
			ProjectInfoViewModel viewModel = service.GetProjectInfo(id);

			return View(viewModel);
		}
        [HttpGet]
        public ActionResult File()
        {
            var projectService = new ProjectService(null);
            //hardcoded value for open file
            var fileModel = projectService.OpenFile(3);
            return View(fileModel);
        }

        [HttpPost]
        public ActionResult File(Files filefromView)
        {
            var projectService = new ProjectService(null);
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
        public ActionResult RemoveFile()
        {
            var projectService = new ProjectService(null);
            //hardcoded value for open file
            var fileModel = projectService.OpenFile(0);
            return View(fileModel);
        }
        [HttpPost]
        public ActionResult RemoveFile(Files fileFromView)
        {
            var projectService = new ProjectService(null);
            var fileToRm = new Files();
            fileToRm.ID = fileFromView.ID;
            //fileToRm.FileType = fileFromView.FileType;
            //fileToRm.Name = fileFromView.Name;
            //fileToRm.Content = fileFromView.Content;
            if (projectService.RemoveFile(fileToRm.ID))
            {
                return RedirectToRoute("Index", "Home");
            }
            return View(fileToRm);
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

		// Temporary for testing purposes only
		[HttpGet]
		public ActionResult UpdateFile(int id)
		{
			FileViewModel data = service.GetFile(id);
			var viewModel = new FileViewModel();
			viewModel.Id = data.Id;
			viewModel.Name = data.Name;
			viewModel.FileType = data.FileType;
			viewModel.Content = data.Content;

			return View(viewModel);
		}

		// Temporary for testing purposes only
		[HttpPost]
		public ActionResult UpdateFile(FileViewModel model)
		{
			if (ModelState.IsValid)
			{
				FileViewModel data = service.GetFile(model.Id);
				data.Id = model.Id;
				data.Name = model.Name;
				data.FileType = model.FileType;
				data.Content = model.Content;
				if(service.UpdateFile(data))
				{
					return RedirectToAction("ProjectInfo", new { Message = "Project Updated succesfully" });
				}
				
			}

			return View(model);
		}
	}
}