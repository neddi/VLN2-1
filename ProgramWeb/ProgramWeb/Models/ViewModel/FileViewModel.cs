﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramWeb.Models.ViewModel
{
	public class FileViewModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[Display(Name = "File Name")]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[Display(Name = "File Type")]
		public string FileType { get; set; }

		[DataType(DataType.Html)]
		[Display(Name = "Content")]
		public string Content { get; set; }
	}
}