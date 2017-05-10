using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProgramWeb.Services;
using ProgramWeb.Models.Entities;
using ProgramWeb.Models.ViewModel;
using ProgramWeb.test;
using System.Collections.Generic;

namespace ProgramWeb.test.Services
{
	[TestClass]
	public class ProjectServices
	{
		private ProjectService _service;

		//[TestInitialize]
		//public void Initialize()
		//{
		//	var fakeDb = new FakeDatabase();
		//	var proj1 = new Projects()
		//	{
		//		Id = 2,
		//		Name = "TestProject1",
		//		Description = "Description for the project",
		//		ProjectTypeId = 1,
		//		CreateDate = DateTime.Now
		//	};
		//	fakeDb.Projects.Add(proj1);

		//	var proj2 = new Projects()
		//	{
		//		Id = 4,
		//		Name = "TestProject2",
		//		Description = "Description for the Second project",
		//		ProjectTypeId = 1,
		//		CreateDate = DateTime.Now
		//	};
		//	fakeDb.Projects.Add(proj2);

		//	var proj3 = new Projects()
		//	{
		//		Id = 5,
		//		Name = "TestProject3",
		//		Description = "Description for the Third project",
		//		ProjectTypeId = 1,
		//		CreateDate = DateTime.Now
		//	};
		//	fakeDb.Projects.Add(proj3);

		//	var proj4 = new Projects()
		//	{
		//		Id = 6,
		//		Name = "TestProject4",
		//		Description = "Description for the Fourth project",
		//		ProjectTypeId = 1,
		//		CreateDate = DateTime.Now
		//	};
		//	fakeDb.Projects.Add(proj4);

		//	var projUsers1 = new ProjectUsers
		//	{
		//		userId = "276e4436-e51d-4bfc-ac7d-986238dca852",
		//		FullName = "Gunnar Gunnarsson",
		//		ProjectId = 2,
		//		IsAdmin = true
		//	};
		//	fakeDb.ProjectUsers.Add(projUsers1);

		//	var projUsers2 = new ProjectUsers
		//	{
		//		userId = "432c6402-6801-4895-bdad-a04ea10b7175",
		//		FullName = "Davíð Valsson",
		//		ProjectId = 2,
		//		IsAdmin = false
		//	};
		//	fakeDb.ProjectUsers.Add(projUsers2);

		//	var file1 = new Files
		//	{
		//		ID = 1,
		//		Name = "index",
		//		FileType = "html",
		//		Content = "<!DOCTYPE html>"
		//	};
		//	fakeDb.Files.Add(file1);

		//	var file2 = new Files
		//	{
		//		ID = 2,
		//		Name = "style",
		//		FileType = "css",
		//		Content = "CSS Magic Happening"
		//	};
		//	fakeDb.Files.Add(file2);

		//	var file3 = new Files
		//	{
		//		ID = 3,
		//		Name = "scripts",
		//		FileType = "js",
		//		Content = "Scripting stuff for the gods"
		//	};
		//	fakeDb.Files.Add(file3);

		//	_service = new ProjectService(fakeDb);
		//}

		[TestMethod]
		public void TestGetProjectNo2()
		{
			// Assign: Breytur sem notaðar eru við testið
			const int projectId = 2;

			// Act: Kallar í fallið sem á að testa
			var result = _service.GetProject(projectId);

			// Assert: Prófar útkomuna
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void TestGetProjectNo2Content()
		{
			// Assign
			const int projectId = 2;

			// Act
			var result = _service.GetProject(projectId);

			// Assert
			Assert.AreEqual(result.Id, 2);
			Assert.AreEqual(result.Name, "TestProject1");
			Assert.AreEqual(result.Description, "Description for the project");
			foreach(var item in result.ProjectFiles)
			{
				Assert.IsNotNull(item);
			}
			foreach(var item in result.ProjectUsers)
			{
				Assert.IsNotNull(item);
			}
		}

		[TestMethod]
		public void TestGetProjectNotFound()
		{
			// Assign
			const int projectId = 0;

			

			try
			{
				// Act
				var result = _service.GetProject(projectId);
				// Assert
				Assert.Fail();
			}
			catch(Exception)
			{

			}
		}

		[TestMethod]
		public void TestNewProjectWrite()
		{
			// Assign
			const string userId = "276e4436-e51d-4bfc-ac7d-986238dca852";
			var project = new Projects
			{
				Id = 6,
				CreateDate = DateTime.Now,
				Name = "Unit Testing Project",
				Description = "Testing project write",
				ProjectTypeId = 1
			};



			try
			{
				// Act
				var result = _service.NewProject(project, userId);
				// Assert
				Assert.IsTrue(result);
			}
			catch (Exception)
			{

			}
		}

		[TestMethod]
		public void TestNewProjectWriteEmpty()
		{
			// Assign
			const string userId = "276e4436-e51d-4bfc-ac7d-986238dca852";
			var project = new Projects();
			project = null;

			// Act
			var result = _service.NewProject(project, userId);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestListAllProjectsSuccess()
		{
			// Assign

			// Act
			var result = _service.ListAllProjects();

			Assert.IsNotNull(result);
		}

		[TestInitialize]
		public void InitializeEmpty()
		{
			var fakeDb = new FakeDatabase();

			_service = new ProjectService(fakeDb);
		}

		[TestMethod]
		public void TestListAllProjectsEmpty()
		{
			// Assign

			// Act
			var result = _service.ListAllProjects();

			Assert.AreEqual(result.Count, 0);
		}
	}
}
