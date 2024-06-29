using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropensityTracker.Models;
using System.Data.Entity;

namespace PropensityTracker.Controllers
{
    public class HomeController : Controller
    {
        HabitContext db = new HabitContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Habits.ToList();
            try
            {
                if (Session["userid"] == null)
                {
                    return RedirectToAction("Login", "Accounts");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Accounts");
            }
            return View(data);
        }
        public ActionResult Create()
        {
            try
            {
                if (Session["userid"] == null)
                {
                    return RedirectToAction("Login", "Accounts");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Accounts");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(Habit h)
        {
            if (ModelState.IsValid == true)
            {
                db.Habits.Add(h);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted !!')</script>";
                    //TempData["InsertMessage"]= "<script>alert('Data Inserted !!')</script>";
                    TempData["InsertMessage"] = "Data Inserted !!";
                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted !!')</script>";
                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    return RedirectToAction("Login", "Accounts");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Accounts");
            }
            var row = db.Habits.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Habit h)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(h).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //UpdateMessage = "<script>alert('Data Updated !!')</script>";
                    TempData["UpdateMessage"] = "Data  Updated!!";
                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Not Updated !!')</script>";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    return RedirectToAction("Login", "Accounts");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Accounts");
            }
            var HabitIdRow = db.Habits.Where(model => model.Id == id).FirstOrDefault();

            return View(HabitIdRow);
        }
        [HttpPost]
        public ActionResult Delete(Habit h)
        {
            db.Entry(h).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                //UpdateMessage = "<script>alert('Data Updated !!')</script>";
                TempData["DeleteMessage"] = "Data  Deleted!!";
                return RedirectToAction("Index");
                //ModelState.Clear();
            }
            else
            {
                ViewBag.DeleteMessage = "<script>alert('Data Not Deleted !!')</script>";
                //TempData["DeleteMessage"] = "Data Not Deleted!!";
            }
            return View();
        }
    }
}