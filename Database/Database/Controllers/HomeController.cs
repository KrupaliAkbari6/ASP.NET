using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database.Models;

namespace Database.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MydbEntities db = new MydbEntities();
            List<Student> std = db.Students.ToList();
            return View(std);
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

        public ActionResult Registration(int? id)
        {
            MydbEntities db = new MydbEntities();
            Student s = new Student();
            if(id.HasValue)
            {
                s = db.Students.Find(id);
            }

            return View(s);
        }
        [HttpPost]
        public ActionResult Registration(Student s)
        {
            MydbEntities db = new MydbEntities();   
            
            if(s.Id==0)
            {
                db.Students.Add(s);
            }
            else
            {
                Student ss = db.Students.Find(s.Id);
                ss.Name = s.Name;
                ss.City = s.City;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            MydbEntities db = new MydbEntities();
            Student stud = db.Students.Find(id);
            db.Students.Remove(stud);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}