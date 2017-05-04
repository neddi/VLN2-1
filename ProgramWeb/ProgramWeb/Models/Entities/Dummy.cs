using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.Entities
{
	// To be deleted
	public class Dummy
	{
		[Key]
		public int id { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }
	}
}