using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramWeb.Models.ViewModel;
using ProgramWeb.Services;
using Microsoft.AspNet.Identity;

namespace ProgramWeb.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Menu()
        {
            /*
            List<TestData2> projects = new List<TestData2>();

            for (int i = 0; i < 5; i++)
            {
                TestData2 newUser = new TestData2();
                testFiles newFiles = new testFiles();

                newUser.ID = i;
                newUser.Name = "Project " + i;

                newUser.Files = new List<testFiles>();
                newFiles.Name = "File 1";
                newFiles.Content = "Funi er frábær!" + i;
                newUser.Files.Add(newFiles);

                //newUser.Files = new List<string>();
                // newUser.Files.Add("File 1");
                // newUser.Files.Add("File 2");

                projects.Add(newUser);
            }  */
            List<TestData2> projects = new List<TestData2>();

            List<UserProjectsViewModel> test = new List<UserProjectsViewModel>();
            string userString = User.Identity.ToString();
            List <UserProjectsViewModel> test2 = new List<UserProjectsViewModel>();
            
            
            ProjectService asdf = new ProjectService();
            asdf.GetUserProject(User.Identity.GetUserId());

            UserProjectsViewModel asdf2 = new UserProjectsViewModel();
            asdf2 = asdf.GetUserProject(User.Identity.GetUserId());




            return PartialView("_SideBarNavigation", asdf2);
        }



    }
    
    
}


