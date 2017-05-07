using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.ViewModel
{
	public class ProjectInfoViewModel
	{
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Required]
        public List<string> ProjectOwners { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Project Description")]
        public string Description { get; set; }

        public List<string> Users { get; set; }
	}
}