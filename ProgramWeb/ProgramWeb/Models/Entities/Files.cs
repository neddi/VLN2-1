using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.Entities
{
	public class Files
	{
        [Key]
        public int ID { get; set; }
		public string Name { get; set; }
		public string FileType { get; set; }
		public string Content { get; set; }
	}
}