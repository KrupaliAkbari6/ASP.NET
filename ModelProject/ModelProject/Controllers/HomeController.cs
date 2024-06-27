using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelProject.Models;

namespace ModelProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Student s = new Student();
            s.ID = 1;
            s.Name = "Krupali";
            s.City = "Rajkot";
            return View(s);
        }
    }
}