using ProgramWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.ViewModel
{
	public class NewFileViewModel
	{
		[Required]
		[Display(Name = "Project ID")]
		public int ProjectId { get; set; }
		public Files File { get; set; }
	}
}