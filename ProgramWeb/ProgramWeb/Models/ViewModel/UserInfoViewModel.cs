using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.ViewModel
{
	public class UserInfoViewModel
	{
        public string Id { get; set; }
        public string FullName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Info { get; set; }
	}
}