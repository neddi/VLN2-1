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
        public List<string> Files { get; set; }

    }
}