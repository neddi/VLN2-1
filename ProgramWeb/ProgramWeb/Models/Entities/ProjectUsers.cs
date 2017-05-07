using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.Entities
{
	public class ProjectUsers
	{
		public string FullName { get; set; }
		[Key]
		public int ProjectId { get; set; }
		public bool IsAdmin { get; set; }
	}
}