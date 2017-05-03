using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.Entities
{

	public class Users
	{
        [Key]
		public string Id { get; set; }
		public string FullName { get; set; }
		public DateTime CreateDate { get; set; }
		public string Info { get; set; }
	}
}