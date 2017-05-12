using Microsoft.AspNet.Identity;
using ProgramWeb.Models.Entities;
using ProgramWeb.Models.ViewModel;
using ProgramWeb.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProgramWeb.Controllers
{
	public class ProjectController : Controller
	{
		private ProjectService service = new ProjectService(null);
		private ProjectService projectService;
		private UserService userService;

		// Action for Viewing Multiple tables
		public ActionResult ProjectInfo(int infoId)
		{
			//ViewBag.projectInfoId = projectInfoId;
			ProjectInfoViewModel viewModel = service.GetProjectInfo(infoId);

			return View("ProjectInfo", viewModel);
		}
        // Hér byrjar Funi að breyta og bæta
        // Ég er að reyna að henda inn ID af File sem ég vil endilega fá

        [HttpPost]
        public ActionResult GetFileForEditor(int id)
        {
            ProjectService fileService = new ProjectService(null);
            FileViewModel fileContent;
            fileContent = (fileService.GetFile(id));
    
            return Json(fileContent);
        }
        [HttpPost]
        public void SaveFileForEditor(string id, string content)
        {
            //int x = Int32.Parse(id);
            ProjectService fileService = new ProjectService(null);
            fileService.SaveFile(id, content); 
        }
        [HttpPost]
        public ActionResult SaveProjectForEditor(string projectName, string projectDescription)
        {
            Projects entity = new Projects();
            entity.Name = projectName;
            entity.Description = projectDescription;
            var currentUser = System.Web.HttpContext.Current.User.Identity.GetUserId();
            projectService = new ProjectService(null);
            if (!projectService.NewProject(entity, currentUser))
            {
                return null; // Þarf að setja inn exception
            }

            var projectID = projectService.GetUserNewestProject(currentUser);
            var project = projectService.GetProject(projectID);
            var projectNameReturn = project.Name;
            var projectFileID = project.ProjectFiles[0].ID;
            var projectFileName = project.ProjectFiles[0].Name;

            
            return Json(new { pID = projectID, pName = projectNameReturn, fID = projectFileID, fName = projectFileName });
            //return View(model);
            //return View(); // Þarf að bæta einhverju við hérna klárlega!
        }

   /*     [HttpPost]
        public ActionResult GetProjectForEditor(int projectID)
        {

            //return Json();
        }
    */

        // Hér hættir Funi að fikta og tikka
        [HttpGet]
        public ActionResult File()
        {
            var projectService = new ProjectService(null);
            //hardcoded value for open file
            var fileModel = projectService.OpenFile(3);
            return View(fileModel);
        }

        [HttpPost]
		[ValidateInput(false)]
		public ActionResult File(Files filefromView)
        {
            var projectService = new ProjectService(null);
            var fileToSave = new Files();
			var tmpFile = service.GetFile(filefromView.ID);
			//fileToSave.ID = 7;
			fileToSave.ID = filefromView.ID;
			//fileToSave.FileType = "css";
			fileToSave.FileType = tmpFile.FileType;
			//fileToSave.Name = "prufa";
			fileToSave.Name = tmpFile.Name;
            fileToSave.Content = filefromView.Content;

            if (projectService.SaveFile(fileToSave))
            {
                return RedirectToRoute("Editor", "Project");
            }
            return View(fileToSave);
        }

        //[HttpGet]
        //public ActionResult RemoveFile()
        //{
        //    var projectService = new ProjectService(null);
        //    //hardcoded value for open file
        //    var fileModel = projectService.OpenFile(0);
        //    return View(fileModel);
        //}
        [HttpPost]
        public ActionResult RemoveFile(int? FileID)
        {
			var projectService = new ProjectService(null);
            if (FileID.HasValue)
            {
                if (projectService.RemoveFile(FileID.Value))
                {
                    return RedirectToAction("Editor", "Project");
                }
            }
            return RedirectToAction("Editor", "Project"); // TODO Errorstate
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
				return RedirectToAction("Editor");
			}

			return View(model);
		}
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Invite(int projectId)
        {
            UserService userServ = new UserService();
            ViewBag.Message = "Your testing page.";
            ViewBag.ProjectId = projectId;
            IEnumerable<UserInfoViewModel> users = userServ.ListAllUsers();
            if (users == null)
            {
                RedirectToAction("Index");
            }
            return View(users);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Invite(string userId, int projectId)
        {

            ProjectService projServ = new ProjectService(null);
            if (projServ.AddUserToProject(userId, projectId))
            {
                return RedirectToAction("Editor");
            }
            UserService userServ = new UserService();
            IEnumerable<UserInfoViewModel> users = userServ.ListAllUsers();
            ViewBag.Message = "An error occured, please try again";
            return View(users);
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

		public ActionResult Editor()
		{
			ViewBag.Message = "Editor";
			//fyrir signalR
			ViewBag.DocumentID = 17;

			return View();
		}

		[HttpGet]
		public ActionResult CreateFile()
		{
			NewFileViewModel model = new NewFileViewModel();

			return View(model);
		}

		//[HttpGet]
		//public ActionResult CreateFile(int id)
		//{
		//	NewFileViewModel model = new NewFileViewModel();
		//	model.ProjectId = id;

		//	return View("CreateFile", model);
		//}

		[HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateFile(NewFileViewModel model)
		{
			projectService = new ProjectService(null);
			if (projectService.NewFile(model))
			{
				return RedirectToAction("Editor", "Project");
			}
			return View(model);
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

			projectService = new ProjectService(null);
			if (projectService.NewProject(entity, currentUser))
			{
				return RedirectToAction("Editor", "Project");
			}
			return View(model);
		}

		public ActionResult UserInfo()
		{
			var currentUser = System.Web.HttpContext.Current.User.Identity.GetUserId();
			userService = new UserService();

			var userInfo = userService.GetUserInformation(currentUser);

			return View(userInfo);
		}
	}
}