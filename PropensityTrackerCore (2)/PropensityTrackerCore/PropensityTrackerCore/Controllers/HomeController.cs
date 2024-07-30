using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropensityTrackerCore.Models;

namespace PropensityTrackerCore.Controllers
{
    public class HomeController : Controller
    {
        HabitContext db = new HabitContext();
        // GET: Home
        public IActionResult Index()
        {
            var data = db.Habits.ToList();
            try
            {
                if (HttpContext.Session == null)
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
        public IActionResult Create()
        {
            try
            {
                if (HttpContext.Session == null)
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
        public IActionResult Create(Habit h)
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
        public IActionResult Edit(int id)
        {
            try
            {
                if (HttpContext.Session == null)
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
        public IActionResult Edit(Habit h)
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

        public IActionResult Delete(int id)
        {
            try
            {
                if (HttpContext.Session == null)
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
        public IActionResult Delete(Habit h)
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