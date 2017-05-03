using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.Entities
{
	public class UserProjects
	{
        [Key]
        public int UserId { get; set; }
		public int ProjectId { get; set; }
		public bool IsOwner { get; set; }
	}
}