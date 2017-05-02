using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.Entities
{
	public class Projects
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int UserId { get; set; }
		public int ProjectTypeId { get; set; }
		public DateTime CreateDate { get; set; }
	}
}