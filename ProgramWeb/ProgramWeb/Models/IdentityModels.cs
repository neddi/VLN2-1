﻿using System.Data.Entity;
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

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Files> Files { get; set; }
		public DbSet<ProjectFiles> ProjectFiles { get; set; }
		public DbSet<ProjectTypes> ProjectTypes { get; set; }
		public DbSet<Projects> Projects { get; set; }
		public DbSet<UserProjects> UserProjects { get; set; }
		public DbSet<ProjectUsers> ProjectUsers { get; set; }
		public DbSet<Users> Users { get; set; }

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