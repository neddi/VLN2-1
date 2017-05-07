using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.ViewModel
{
	public class ProjectInfoViewModel
	{
		public string Name { get; set; }
		public List<string> ProjectOwners { get; set; }
		public DateTime CreateDate { get; set; }
		public string Description { get; set; }
		public List<string> Users { get; set; }
	}
}