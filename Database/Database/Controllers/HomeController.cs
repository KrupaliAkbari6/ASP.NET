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
        public ActionResult Index(string searchTerm)
        {
            MydbEntities db = new MydbEntities();
            var std = db.Students.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                std = std.Where(s => s.Name.Contains(searchTerm) || s.City.Contains(searchTerm));
            }
            return View(std.ToList());
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
            
            if(id!=0)
            {
                MydbEntities db = new MydbEntities();
                Student s = db.Students.Find(id);
                return View(s);
            }
            else {
                return View(); 
            }
           
        }
        [HttpPost]
        public ActionResult Registration(Student s)
        {
            MydbEntities db = new MydbEntities();

            /*if(s.Id==0)
            {
                db.Students.Add(s);
            }
            else
            {
                Student ss = db.Students.Find(s.Id);
                ss.Name = s.Name;
                ss.City = s.City;
            }*/

            if (s.Id != 0)
            {
                /*Update code*/
                Student ss = db.Students.Find(s.Id);
                ss.Name = s.Name;
                ss.City = s.City;
               
            }
            else
            {
               /* Add code*/
                db.Students.Add(s);
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

        [HttpPost]
        public ActionResult DeleteSelected(int[] selectedIds)
        {
            MydbEntities db = new MydbEntities();
            if (selectedIds != null)
            {
                foreach (int id in selectedIds)
                {
                    Student stud = db.Students.Find(id);
                    if (stud != null)
                    {
                        db.Students.Remove(stud);
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}