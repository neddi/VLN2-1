using ProgramWeb.Services;
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
			var id = new int();
			object data;
			bool hasValue = dictionary.TryGetValue("id", out data);
			if (hasValue)
			{
				id = (int)data;
			}

			ProjectService service = new ProjectService(null);
			var projectInfo = service.GetProjectInfo(id);
			dictionary.Add("Name", projectInfo.Name);
			dictionary.Add("ProjectOwners", projectInfo.ProjectOwner);
			dictionary.Add("CreateDate", projectInfo.CreateDate);
			dictionary.Add("Description", projectInfo.Description);
			dictionary.Add("Users", projectInfo.Users);
			return dictionary;
		}
	}
}