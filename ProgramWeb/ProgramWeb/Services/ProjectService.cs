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

namespace ProgramWeb.Services
{
	public class ProjectService
	{
		private ApplicationDbContext _db;
		public ProjectService()
		{
			_db = new ApplicationDbContext();
		}

		public ProjectInfoViewModel GetProjectInfo(int projectid)
		{
			ProjectInfoViewModel viewModel = new ProjectInfoViewModel();

			var project = _db.Projects.SingleOrDefault(x => x.Id == projectid);
			viewModel.Name = project.Name;
			viewModel.CreateDate = project.CreateDate;
			viewModel.Description = project.Description;

			var allProjectUsers = _db.ProjectUsers.Where(x => x.ProjectId == projectid).ToList();
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
	}
}