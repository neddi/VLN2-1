﻿using System;
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

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:d MMMM yyyy}", ApplyFormatInEditMode = true)]
		public DateTime CreateDate { get; set; }

		[Required]
		[DataType(DataType.Text)]
		public string FullName { get; set; }

		[DataType(DataType.Text)]
		public string Info { get; set; }

		[Required]
		[DataType(DataType.Text)]
		public string UserName { get; set; }
	}
}