using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgramWeb.Models.ViewModel;
using ProgramWeb.Models.Entities;
using ProgramWeb.Models;
using ProgramWeb.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Data.Entity;

namespace ProgramWeb.Services
{
	public class ProjectService
	{
		private ApplicationDbContext _db;
		private ManageController userService = new ManageController();
		public ProjectService()
		{
			_db = new ApplicationDbContext();
		}

		/// <summary>
		/// Get information about the active project
		/// </summary>
		/// <param name="projectid"></param>
		/// <returns></returns>
		public ProjectInfoViewModel GetProjectInfo(int projectid)
		{
			ProjectInfoViewModel viewModel = new ProjectInfoViewModel();

			var project = _db.Projects.SingleOrDefault(x => x.Id == projectid);
			viewModel.Id = project.Id;
			viewModel.Name = project.Name;
			viewModel.CreateDate = project.CreateDate;
			viewModel.Description = project.Description;

			var allProjectUsers = (from u in _db.ProjectUsers
								   where u.ProjectId == projectid
									select new { u.FullName, u.IsAdmin }).ToList();
			List<string> ProjectUsers = new List<string>();
			List<string> ProjectOwners = new List<string>();
			foreach (var item in allProjectUsers)
			{
				string tmpName = item.FullName;
				ProjectUsers.Add(tmpName);
				if(item.IsAdmin)
				{
					ProjectOwners.Add(tmpName);
				}
			}
			viewModel.Users = ProjectUsers;
			viewModel.ProjectOwners = ProjectOwners;


			return viewModel;
		}

		/// <summary>
		/// Updating project information
		/// </summary>
		/// <param name="info"></param>
		public void UpdateProjectInfo(ProjectInfoViewModel info)
		{
			var dbProject = _db.Projects.Find(info.Id);
			Projects project = new Projects();
			project.Id = info.Id;
			project.Name = info.Name;
			project.Description = info.Description;
			project.CreateDate = info.CreateDate;
			project.ProjectTypeId = dbProject.ProjectTypeId;
			_db.Entry(dbProject).CurrentValues.SetValues(project);
			_db.Entry(dbProject).State = EntityState.Modified;
			_db.SaveChanges();
		}

		public ProjectViewModel GetProject(int projectid)
		{
			ProjectViewModel viewModel = new ProjectViewModel();

			var project = _db.Projects.SingleOrDefault(x => x.Id == projectid);
			viewModel.Id = project.Id;
			viewModel.Name = project.Name;

			var allProjectUsers = (from u in _db.ProjectUsers
								   where u.ProjectId == projectid
								   select new { u.FullName }).ToList();

			List<string> users = new List<string>();
			foreach(var item in allProjectUsers)
			{
				string tmpName = item.FullName;

				users.Add(tmpName);
			}

			viewModel.ProjectUsers = users;

			var fileList = (from f in _db.Files
							 join p in _db.ProjectFiles on f.ID equals p.FileId
							 where p.ProjectId == projectid
							 select new { f.ID, f.Name, f.FileType, f.Content }).ToList();

			List<Files> files = new List<Files>();
			foreach(var fileItem in fileList)
			{
				Files tmpFile = new Files();
				tmpFile.ID = fileItem.ID;
				tmpFile.Name = fileItem.Name;
				tmpFile.FileType = fileItem.FileType;
				tmpFile.Content = fileItem.Content;
				files.Add(tmpFile);
			}
			viewModel.ProjectFiles = files;

			return viewModel;
		}

		public UserProjectsViewModel GetUserProject(string userId)
		{
			//UserProjectsViewModel projectList = new UserProjectsViewModel();

			//var projectUser = (from u in _db.ProjectUsers
			//					   where u.userId == userId
			//					   select new { u.FullName }).ToList();

			//List<string> users = new List<string>();
			//foreach (var item in projectUser)
			//{
			//	string tmpName = item.FullName;

			//	users.Add(tmpName);
			//}

			//viewModel.ProjectUsers = users;


			//return viewModel;
			return null;
		}
	}
}