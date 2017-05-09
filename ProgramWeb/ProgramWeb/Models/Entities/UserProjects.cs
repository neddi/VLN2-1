using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.Entities
{
	public class UserProjects
	{
        [Key]
        public int ID { get; set; }
        public String UserId { get; set; }
        public int ProjectId { get; set; }
		public bool IsAdmin { get; set; }
	}
}