using ProgramWeb.Models;
<<<<<<< HEAD
=======
using ProgramWeb.Models.ViewModel;
>>>>>>> ec97120f950b5b40c58a5a7d74da57ccb7792e7a
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