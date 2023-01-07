using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial_List_Product()
        {
            var items = db.Products.Where(x => x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView("Partial_List_Product",items);
        }   
        public ActionResult Partial_List_Main_Product()
        {
            var items = db.Products.Where(x => x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView("Partial_List_Main_Product", items);
        }  
        public ActionResult Partial_List_Banner()
        {
            var items = db.banners.Where(x=> x.IsActive).Take(5).ToList();
            return PartialView("Partial_List_Banner", items);
        } 
        public ActionResult Partial_List_News()
        {
            var items = db.News.Where(x=>x.IsActive).Take(12).ToList();
            return PartialView("Partial_List_News", items);
        }
        public ActionResult Partial_List_Solution()
        {
            var items = db.Posts.ToList();
             ViewBag.slogan = items[0].Description;
            return PartialView("Partial_List_Solution", items);
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
        public ActionResult Solution()
        {
            ViewBag.Message = "Your Solution page.";

            return View();
        } 
        public ActionResult Headquarter()
        {
            ViewBag.Message = "Your Headquarter page.";

            return View();
        }
        public ActionResult Vision()
        {
            ViewBag.Message = "Your Vision page.";

            return View();
        }
    }
}