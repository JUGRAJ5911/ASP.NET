using PropensityTrackerCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PropensityTrackerCore.Controllers
{
    public class AccountsController : Controller
    {
        UserContext db = new UserContext();
        // GET: Accounts
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserMaster user)
        {

            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserMaster u)
        {
            if (ModelState.IsValid == true)
            {
                db.UserMasters.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted !!')</script>";
                    //TempData["InsertMessage"]= "<script>alert('Data Inserted !!')</script>";
                    TempData["Registered"] = "User Succesfullly Registered !!";
                    return RedirectToAction("HomePage");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('User not registered!!')</script>";
                }
            }
            return View();
        }
    }
}
