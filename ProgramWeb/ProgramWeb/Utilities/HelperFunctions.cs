using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramWeb.Utilities
{
	public static class HelperFunctions
	{
		public static ViewDataDictionary ToViewDataDictionary(this object values)
		{
			var dictionary = new ViewDataDictionary();
			foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(values))
			{
				dictionary.Add(property.Name, property.GetValue(values));
			}
			return dictionary;
		}
	}
}