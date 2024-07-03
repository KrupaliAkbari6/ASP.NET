using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_Project.Models;

namespace Student_Project.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            student s = new student();
            s.Id = 1;
            s.Name = "Krupali";
            s.City = "Rajkot";
            s.Division = "A";
            return View(s);
        }
        public ActionResult About()
        {
            ViewBag.id = new List<int>() { 1, 2, 3, 4, 5 };
            ViewBag.name = new List<string>() { "Krupali", "Neha", "Vishakha", "Isha", "Kruti" };
            ViewBag.city = new List<string>() { "Rajkot", "Gondal", "Rajkot", "Gondal", "Rajkot" };
            ViewBag.division = new List<string>() { "A", "A", "A", "B", "B" };
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}