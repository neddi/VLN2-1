using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProgramWeb.Models.Entities;
using System.Collections.Generic;

namespace ProgramWeb.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Info { get; set; }
        public System.DateTime CreateDate { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {   
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

	public interface IAppDataContext
	{
		IDbSet<Files> Files { get; set; }
		IDbSet<ProjectFiles> ProjectFiles { get; set; }
		IDbSet<ProjectTypes> ProjectTypes { get; set; }
		IDbSet<Projects> Projects { get; set; }
		IDbSet<UserProjects> UserProjects { get; set; }
		IDbSet<ProjectUsers> ProjectUsers { get; set; }
		IDbSet<Users> Users { get; set; }
		int SaveChanges();
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IAppDataContext
	{
		public IDbSet<Files> Files { get; set; }
		public IDbSet<ProjectFiles> ProjectFiles { get; set; }
		public IDbSet<ProjectTypes> ProjectTypes { get; set; }
		public IDbSet<Projects> Projects { get; set; }
		public IDbSet<UserProjects> UserProjects { get; set; }
		public IDbSet<ProjectUsers> ProjectUsers { get; set; }
		public IDbSet<Users> Users { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}