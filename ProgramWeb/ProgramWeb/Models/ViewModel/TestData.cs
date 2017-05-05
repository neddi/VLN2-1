using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramWeb.Models.ViewModel
{
    public class TestData
    { 
        public int ID { get; set; }
        public string Name { get; set; }
        public List<testFiles> Files { get; set; }

       
    }
    public class testFiles
    {
        public string Name { get; set; }
        public string Content { get; set; }

    }
}