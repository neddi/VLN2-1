using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.Entities
{
	public class UserProjects
	{
		public int UserId { get; set; }
		public int ProjectId { get; set; }
		public bool IsOwner { get; set; }
	}
}