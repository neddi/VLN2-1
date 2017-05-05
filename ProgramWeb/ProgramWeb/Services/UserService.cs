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
		public	List<IdentityUser> ListAllUsers()
		{

			var context = new IdentityDbContext();
			var users = context.Users.ToList();

			return users;
		}
	}

}

//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;