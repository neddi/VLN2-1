using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.Entities
{
	public class ProjectTypes
	{
        [Key]
        public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}