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
		private ProjectService service = new ProjectService(null);
		// Action for Viewing Multiple tables
		public ActionResult ProjectInfo(int id)
		{
			ProjectInfoViewModel viewModel = service.GetProjectInfo(id);

			return View(viewModel);
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