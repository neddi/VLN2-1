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
		public string Email { get; set; }
		public string UserName { get; set; }
	}
}