using ProgramWeb.Models;
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

	}

}