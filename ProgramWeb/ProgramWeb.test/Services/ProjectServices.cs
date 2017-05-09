using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProgramWeb.Services;

namespace ProgramWeb.test.Services
{
	[TestClass]
	public class ProjectServices
	{
		[TestMethod]
		public void TestGetProject()
		{
			// Assign: Breytur sem notaðar eru við testið
			const int projectId = 2;
			var service = new ProjectService;

			// Act: Kallar í fallið sem á að testa
			var result = service.GetProject(projectId);

			// Assert: Prófar útkomuna
			Assert.IsNotNull(result);
		}
	}
}
