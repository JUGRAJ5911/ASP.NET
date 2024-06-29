using PropensityTracker.Models;
using System.Linq;
using System.Web.Mvc;

namespace PropensityTracker.Controllers
{
    public class AccountsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: /Accounts/HomePage
        public ActionResult HomePage()
        {
            return View();
        }

        // GET: /Accounts/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Accounts/Login
        [HttpPost]
        public ActionResult Login(UserMaster user)
        {
            var result = db.UserMasters.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (result != null)
            {
                Session["userid"] = user.Username;
                TempData["msg"] = "Login Successful";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = "Incorrect UserId/Password";
                return View();
            }
        }


        // GET: /Accounts/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Accounts");
        }

        // GET: /Accounts/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Accounts/Register
        [HttpPost]
        public ActionResult Register(UserMaster u)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.UserMasters.FirstOrDefault(x => x.Username == u.Username);
                if (existingUser == null)
                {
                    db.UserMasters.Add(u);
                    int recordsAffected = db.SaveChanges();
                    if (recordsAffected > 0)
                    {
                        TempData["Registered"] = "User Successfully Registered!";
                        return RedirectToAction("HomePage", "Accounts");
                    }
                    else
                    {
                        ViewBag.InsertMessage = "<script>alert('User not registered!!')</script>";
                    }
                }
                else
                {
                    TempData["Registered"] = "User Already Exists!";
                    return RedirectToAction("HomePage", "Accounts");
                }
            }
            return View(u);
        }
    }
}
