using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using loginProject.Models;

namespace loginProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            myDBEntities db = new myDBEntities();
            List<Student> s = db.Students.ToList();
            return View(s);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LoginPage(int? id)
        {
            if (id != 0)
            {
                myDBEntities db = new myDBEntities();
                Student s = db.Students.Find(id);
                return View(s);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult LoginPage(Student s)
        {
            myDBEntities db = new myDBEntities();
            if (s.Id != 0)
            {
                /*Update code*/
                Student ss = db.Students.Find(s.Id);
                ss.Username = s.Username;
                ss.Password = s.Password;
                ss.Name = s.Name;
                ss.City = s.City;
                ss.Gender = s.Gender;

            }
            else
            {
                /* Add code*/
                db.Students.Add(s);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}