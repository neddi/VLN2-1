using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProgramWeb.Models.Entities
{
	public class ProjectFiles
	{//TODO cheack if implimentation is correct!
        
        [Key]
        [Column(Order = 1)]
        public int ProjectId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int FileId { get; set; }
	}
}