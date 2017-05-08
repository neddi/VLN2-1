using ProgramWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.ViewModel
{
	public class ProjectViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Files> ProjectFiles { get; set; }
		public List<string> ProjectUsers { get; set; }
	}
}