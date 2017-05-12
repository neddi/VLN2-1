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
		public int Id { get; set; }

		[Required]
        [DataType(DataType.Text)]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Required]
        public string ProjectOwner { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:d MMMM yyyy}", ApplyFormatInEditMode = true)]
		public DateTime CreateDate { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Project Description")]
        public string Description { get; set; }

        public List<UserInfoViewModel> Users { get; set; }
	}
}