using E_AuctionProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_AuctionProject.Controllers
{
    public class MenuPageController : Controller
    {
        public IActionResult Home()
        {
            int c_id = (int)HttpContext.Session.GetInt32("customer");
            List<ApplyBid> ab = new List<ApplyBid>();
            using (AuctionContext db = new AuctionContext())
            {
                TempData["msg"] = db.AddProducts.ToList();
                ab = db.ApplyBids.Where(x => x.CustomerID != c_id && x.BidAmount > 0 && x.Approval == "waiting").ToList();
                ViewData["count"] = ab.Count();
            }
            return View();
        }
        public IActionResult ViewUser()
        {
            int c_id = (int)HttpContext.Session.GetInt32("customer");
            using (AuctionContext db = new AuctionContext())
            {
                TempData["vu"] = db.UserMasters.Where(x => x.CustomerID != c_id).ToList();
            }
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(AddProduct ap)
        {
            int c_id = (int)HttpContext.Session.GetInt32("customer");
            ap.CustomerID = c_id;
            using (AuctionContext db = new AuctionContext())
            {
                db.AddProducts.Add(ap);
                if (db.SaveChanges() > 0)
                {
                    TempData["ap"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["ap"] = "0";
                }
            }
            return View();
        }
        public IActionResult ViewProduct(AddProduct ap)
        {
            int c_id = (int)HttpContext.Session.GetInt32("customer");
            using (AuctionContext db = new AuctionContext())
            {
                TempData["vp"] = db.AddProducts.Where(x => x.CustomerID == c_id).ToList();
            }
            return View();
        }
        public IActionResult ViewAuction()
        {
            int c_id = (int)HttpContext.Session.GetInt32("customer");
            //List<AddProduct> ap = new List<AddProduct>();
            using (AuctionContext db = new AuctionContext())
            {
                TempData["va"] = db.AddProducts.Where(x => x.CustomerID != c_id).ToList();
            }
            return View();
        }

        public IActionResult Apply(int id)
        {
            string c_name = HttpContext.Session.GetString("name");
            int c_id = (int)HttpContext.Session.GetInt32("customer");
            //List<AddProduct>? ap = new List<AddProduct>();
            AddProduct? pp = new AddProduct();
            ApplyBid ab = new ApplyBid();
            using (AuctionContext db = new AuctionContext())
            {
                TempData["apply"] = c_name;
                pp= db.AddProducts.Where(x => x.Sno == id).FirstOrDefault();
                ab.CustomerID = c_id;
                ab.BuyerName = c_name;
                ab.Pt_no = pp.Sno;
                ab.MinAmount = pp.Amount;
                ab.B_Product = pp.Product;
                ab.B_Details = pp.Details;
                ab.Owner = pp.Username;
                ab.BidAmount = 0;
                ab.status = "Applied";
                ab.Approval = "waiting";
                db.ApplyBids.Add(ab);
                db.SaveChanges();
                ab = db.ApplyBids.Where(x => x.Pt_no==id&& x.CustomerID==c_id).FirstOrDefault();

            }
            return View(ab);
        }
        [HttpPost]
        public IActionResult Apply(ApplyBid  a)
        {
            int c_id = (int)HttpContext.Session.GetInt32("customer");
            using (AuctionContext db = new AuctionContext())
                {
                    var Result = db.ApplyBids.Where(x => x.Pt_no == a.Pt_no&&x.CustomerID==c_id).FirstOrDefault();
                    Result.BidAmount = a.BidAmount;
                    
                int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["Apply"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["Apply"] = "0";
                    }

                }
            
            return View();
        }
        public IActionResult ViewProfile()
        {
            int c_id = (int)HttpContext.Session.GetInt32("customer");
            UserMaster? um = new UserMaster();
            using (AuctionContext db = new AuctionContext())
            {
                um = db.UserMasters.Where(x => x.CustomerID == c_id).FirstOrDefault();
            }
            return View(um);
        }
        public IActionResult Edit()
        {
            int c_id = (int)HttpContext.Session.GetInt32("customer");
            UserMaster? um = new UserMaster();
            using (AuctionContext db = new AuctionContext())
            {
                um = db.UserMasters.Where(x => x.CustomerID == c_id).FirstOrDefault();
            }
            return View(um);
        }
        [HttpPost]
        public IActionResult Edit(UserMaster um)
        {
            if(ModelState.IsValid)
            {
                using (AuctionContext db = new AuctionContext())
                {
                    var Result = db.UserMasters.Find(um.CustomerID);
                    Result.Firstname = um.Firstname;
                    Result.Lastname = um.Lastname;
                    Result.Password = um.Password;
                    Result.CPassword = um.CPassword;
                    Result.Email = um.Email;
                    Result.DOB = um.DOB;
                    Result.MobileNumber = um.MobileNumber;
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["EditMsg"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["EditMsg"] = "0";
                    }

                }
            }
            return RedirectToAction("ViewProfile", "MenuPage");
        }
        public IActionResult TV()
        {
            //List<AddProduct> ap = new List<AddProduct>();
            using (AuctionContext db = new AuctionContext())
            {
                TempData["TV"] = db.AddProducts.Where(x => x.Product =="TV").ToList();
            }
            return View();
        }
        public IActionResult Bike()
        {
            //List<AddProduct> ap = new List<AddProduct>();
            using (AuctionContext db = new AuctionContext())
            {
                TempData["Bike"] = db.AddProducts.Where(x => x.Product == "Bike").ToList();
            }
            return View();
        }
        public IActionResult House()
        {
            //List<AddProduct> ap = new List<AddProduct>();
            using (AuctionContext db = new AuctionContext())
            {
                TempData["House"] = db.AddProducts.Where(x => x.Product == "House").ToList();
            }
            return View();
        }
        public IActionResult Fridge()
        {
            //List<AddProduct> ap = new List<AddProduct>();
            using (AuctionContext db = new AuctionContext())
            {
                TempData["Fridge"] = db.AddProducts.Where(x => x.Product == "Fridge").ToList();
            }
            return View();
        }
        public IActionResult Car()
        {
            //List<AddProduct> ap = new List<AddProduct>();
            using (AuctionContext db = new AuctionContext())
            {
                TempData["Car"] = db.AddProducts.Where(x => x.Product == "Car").ToList();
            }
            return View();
        }

        public IActionResult ViewStatus()
        {
            int c_id = (int)HttpContext.Session.GetInt32("customer");
            //List<ApplyBid> ab = new List<ApplyBid>();
            using (AuctionContext db = new AuctionContext()) 
            {
                TempData["vs"] = db.ApplyBids.Where(x => x.CustomerID == c_id&& x.BidAmount>0).ToList();
            }
            return View();
        }
        public IActionResult ViewTendor()
        {
            int c_id = (int)HttpContext.Session.GetInt32("customer");
            List<ApplyBid> ab = new List<ApplyBid>();
            using (AuctionContext db = new AuctionContext())
            {
                ab = db.ApplyBids.Where(x => x.CustomerID != c_id && x.BidAmount>0 && x.status=="Applied").ToList();
            }
            return View(ab);
        }

        [HttpGet]
        public IActionResult Approved(int id)
        {
            ApplyBid ab = new ApplyBid();
            using (AuctionContext db = new AuctionContext())
            {
                ab = db.ApplyBids.Where(x => x.BidNo == id).FirstOrDefault();
                ab.Approval = "Approved";
                db.ApplyBids.Update(ab);    
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["Approved"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("ViewTendor", "MenuPage");
        }
        [HttpGet]
        public IActionResult Reject(int id)
        {
            ApplyBid ab = new ApplyBid();
            using (AuctionContext db = new AuctionContext())
            {
                ab = db.ApplyBids.Where(x => x.BidNo == id).FirstOrDefault();
                ab.Approval = "Rejected";
                db.ApplyBids.Update(ab);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["Rejected"] = "0";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("ViewTendor", "MenuPage");
        }

        public IActionResult Search(string Empsearch)
        {
            ViewData["search"] = Empsearch;
            using (AuctionContext db = new AuctionContext())
            {
                TempData["emp"] = db.AddProducts.Where(x => x.Product.Contains(Empsearch)).ToList();
            }
            return View();
        }

        public IActionResult UnViewAuction()
        {
            using (AuctionContext db = new AuctionContext())
            {
                TempData["Auction"] = db.AddProducts.ToList();
            }
            return View();
        }
    }
}
