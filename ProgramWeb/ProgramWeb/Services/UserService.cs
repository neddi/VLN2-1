using ProgramWeb.Models;

namespace ProgramWeb.Services
{
	public class UserService
	{

		private ApplicationDbContext _db;
		public UserService()
		{
			_db = new ApplicationDbContext();
		}

		//public	List<UserInfoViewModel> ListAllUsers()
		//{
		//	var context = new IdentityDbContext();
		//	var users = context.Users.ToList();
		//	List<UserInfoViewModel> viewModel = new List<UserInfoViewModel>();

		//	foreach (var item in users)
		//	{
		//		var currentUser = ManageController.UserManager.FindById(item.Id);
		//		UserInfoViewModel temp = new UserInfoViewModel();
		//		temp.FullName = currentUser.FullName;
		//		viewModel.Add(temp);
		//	}

		//	return viewModel;
		//}
	}

}

//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;