using E_AuctionProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_AuctionProject.Controllers
{
    public class AuctionController : Controller
    {
        public IActionResult Frontpage()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login l)
        {
            if (ModelState.IsValid)
            {
                using (AuctionContext ac = new AuctionContext())
                {
                    var Result = ac.UserMasters.Where(x => x.CustomerID == l.CustomerID
                      && x.Password == l.Password);
                    if (Result.Count() > 0)
                    {
                        var user = Result.FirstOrDefault();
                        HttpContext.Session.SetInt32("role", user.RoleId);
                        HttpContext.Session.SetInt32("customer", user.CustomerID);
                        HttpContext.Session.SetString("name", user.Firstname);
                        TempData["msg"] = "1";
                        ModelState.Clear();
                        return RedirectToAction("Home", "MenuPage");
                    }
                    else
                    {
                        TempData["msg"] = "0";
                    }
                    
                }
            }
            return View();
        }
        public IActionResult ALogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ALogin(Login l)
        {
            if (ModelState.IsValid)
            {
                using (AuctionContext ac = new AuctionContext())
                {
                    var Result = ac.UserMasters.Where(x => x.CustomerID == l.CustomerID
                      && x.Password == l.Password);
                    if (Result.Count() > 0)
                    {
                        var user = Result.FirstOrDefault();
                        HttpContext.Session.SetInt32("role", user.RoleId);
                        HttpContext.Session.SetInt32("customer", user.CustomerID);
                        HttpContext.Session.SetString("name", user.Firstname);
                        TempData["msg"] = "1";
                        ModelState.Clear();
                        return RedirectToAction("Home", "MenuPage");
                    }
                    else
                    {
                        TempData["msg"] = "0";
                    }

                }
            }
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(UserMaster um)
        {
            um.RoleId = 902;

            using (AuctionContext db = new AuctionContext())
            {
                db.UserMasters.Add(um);
                if (db.SaveChanges() > 0)
                {
                    TempData["status"] = "1";
                    TempData["Code"]=um.CustomerID;
                    ModelState.Clear();
                }
                else
                {
                    TempData["status"] = "0";
                }
            }

            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auction");
        }
    }
}
