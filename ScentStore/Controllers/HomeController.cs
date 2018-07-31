using ScentStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScentStore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        //Giving logged in users and admin access to contact page:
        [Authorize(Roles = "Admin, User")]
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult His(string searchString)
        {
            ViewBag.Message = "His page";

            var products = from p in db.Products
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            return View(products.Where(item => item.IsFemale == false).ToList()); //Only show items that is not female
        }

        public ActionResult Hers(string searchString)
        {
            ViewBag.Message = "Hers page";

            var products = from p in db.Products
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            return View(products.Where(item => item.IsFemale == true).ToList()); //Only show items that is for female
        }

        public ActionResult ProductDetails(int? id)
        {
            Product product;

            {
                product = db.Products.SingleOrDefault(p => p.ID == id);
            }

            if (product == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return PartialView("_ProductDetail", product);
        }
    }
}