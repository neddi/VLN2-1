using System;
using FakeDbSet;
using System.Data.Entity;
using ProgramWeb.Models;
using ProgramWeb.Models.Entities;

namespace ProgramWeb.test
{
	/// <summary>
	/// This is an example of how we'd create a fake database by implementing the 
	/// same interface that the BookeStoreEntities class implements.
	/// </summary>
	public class FakeDatabase : IAppDataContext
	{
		/// <summary>
		/// Sets up the fake database.
		/// </summary>
		public FakeDatabase()
		{
			// We're setting our DbSets to be InMemoryDbSets rather than using SQL Server.
			this.Files = new InMemoryDbSet<Files>();
			this.ProjectFiles = new InMemoryDbSet<ProjectFiles>();
			this.ProjectTypes = new InMemoryDbSet<ProjectTypes>();
			this.Projects = new InMemoryDbSet<Projects>();
			this.UserProjects = new InMemoryDbSet<UserProjects>();
			this.ProjectUsers = new InMemoryDbSet<ProjectUsers>();
			this.Users = new InMemoryDbSet<Users>();
		}

		public IDbSet<Files> Files { get; set; }
		public IDbSet<ProjectFiles> ProjectFiles { get; set; }
		public IDbSet<ProjectTypes> ProjectTypes { get; set; }
		public IDbSet<Projects> Projects { get; set; }
		public IDbSet<UserProjects> UserProjects { get; set; }
		public IDbSet<ProjectUsers> ProjectUsers { get; set; }
		public IDbSet<Users> Users { get; set; }

		public int SaveChanges()
		{
			// Pretend that each entity gets a database id when we hit save.
			int changes = 0;
//			changes += DbSetHelper.IncrementPrimaryKey<Author>(x => x.AuthorId, this.Authors);
//			changes += DbSetHelper.IncrementPrimaryKey<Book>(x => x.BookId, this.Books);

			return changes;
		}

		public void Dispose()
		{
			// Do nothing!
		}
	}
}