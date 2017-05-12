using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProgramWeb.Models;
using ProgramWeb.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using ProgramWeb.Models.Entities;

namespace ProgramWeb.Services
{
	public class UserService
	{

		private ApplicationDbContext _db;
		public UserService()
		{
			_db = new ApplicationDbContext();
		}

        public List<UserInfoViewModel> ListAllUsers()
        {

            List<UserInfoViewModel> viewModels = new List<UserInfoViewModel>();
            using (var context = new IdentityDbContext())
            {

                viewModels =
                    context.Users

                    .Select(u =>
                        new UserInfoViewModel
                        {
                            Id = u.Id,
                            UserName = u.UserName,
                            Email = u.Email,
                        }
                    ).ToList();


                return viewModels;
            }
        }

		public Users GetUserInformation(string userId)
		{
			Users userData = new Users();

			userData = _db.Users.SingleOrDefault(x => x.Id == userId);

			return userData;
		}


    }
}


//string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;