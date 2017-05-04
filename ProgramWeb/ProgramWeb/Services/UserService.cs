using ProgramWeb.Models;
using ProgramWeb.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramWeb.Services
{
	public class UserService
	{
		private ApplicationDbContext _db;

		public UserService()
		{
			_db = new ApplicationDbContext();
		}

		public TableTestingViewModel ReadDummy(int dummyId)
		{
			var TableTesting = _db.Dummy.SingleOrDefault(x => x.id == dummyId);

			var viewModel = new TableTestingViewModel
			{
				id = TableTesting.id,
				Name = TableTesting.Name,
				Text = TableTesting.Text
			};

			return viewModel;
		}
	}

}