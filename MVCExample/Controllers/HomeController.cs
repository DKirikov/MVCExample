using MVCExample.Models;
using MVCExample.Models.BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExample.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            //set all objects into dynamic property Books in ViewBag
            ViewBag.Books = books;
            // return view:
            return View();
        }

        public JsonResult GetUsers()
        {
            List<User> users = new List<User> 
            { 
                new User {Id=1, Name="Tom", Age=23},
                new User {Id=2, Name="Alice", Age=28},
                new User {Id=3, Name="Bill", Age=32}
            };
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)//add to the DB
        {
            var count = db.Purchases.Count();
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();

            return "Thank you, " + purchase.Person + ", for the purchase!";
        }
    }
}