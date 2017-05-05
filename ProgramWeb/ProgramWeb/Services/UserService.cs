using ProgramWeb.Models;
using ProgramWeb.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProgramWeb.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramWeb.Services
{
	public class UserService
	{
		private ApplicationDbContext _db;

		public UserService()
		{
			_db = new ApplicationDbContext();
		}

		//public List<Users> ListAllUsers()
		public	List<TableTestingViewModel> ListAllUsers()
		{
			//var allUsers = new List<Users>();
			List<TableTestingViewModel> allUsers = new List<TableTestingViewModel>();

			var temp = (from us in _db.
							 select new { us.Id, us.Email, us.UserName }).ToList();

			foreach(var item in temp)
			{
				TableTestingViewModel tmp = new TableTestingViewModel();
				tmp.id = item.Id;
				tmp.Email = item.Email;
				tmp.UserName = item.Email;
				allUsers.Add(tmp);
			}

			return allUsers;
		}
	}

}

//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;