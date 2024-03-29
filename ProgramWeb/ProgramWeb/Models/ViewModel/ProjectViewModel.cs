﻿using ProgramWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.ViewModel
{
	public class ProjectViewModel
	{
        [Key]
		public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Creation date")]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Project Description")]
        public string Description { get; set; }

        [Required]
        public int ProjectTypeId { get; set; }
        [Required]
        public List<Files> ProjectFiles { get; set; }

		public List<UserInfoViewModel> ProjectUsers { get; set; }

        public override bool Equals(object obj)
        {
            ProjectViewModel p = obj as ProjectViewModel;
            return p != null && p.Id == this.Id;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}