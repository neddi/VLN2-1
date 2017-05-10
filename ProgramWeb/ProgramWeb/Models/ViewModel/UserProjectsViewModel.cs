using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.ViewModel
{
	public class UserProjectsViewModel
	{
		[Required]
		public string Id { get; set; }

		[Required]
		[DataType(DataType.Text)]
		public string FullName { get; set; }
		public List<ProjectViewModel> ProjectList { get; set; }
	}
}