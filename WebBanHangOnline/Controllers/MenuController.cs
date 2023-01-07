using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuTop()
        {
            var items = db.Categories.OrderBy(x => x.Position).Where(x=>x.IsActive).ToList();
            return PartialView("MenuTop",items);
        }
        public ActionResult Menu_DanhMuc_Header()
        {
           
            var items = db.ProductCategories.ToList();
            return PartialView("Menu_DanhMuc_Header", items);
        }
        public ActionResult MenuCategories()
        {
            var items = db.ProductCategories.ToList();
            return PartialView("MenuCategories", items);
        } 
        public ActionResult MenuLeft(int ?id)
        {
            if (id != null)
            {
                ViewBag.CateId = id;
            }
            var items = db.ProductCategories.ToList();
            return PartialView("MenuLeft", items);
        }
        public ActionResult MenuArrivals()
        {
            var items = db.ProductCategories.ToList();
            return PartialView("MenuArrivals", items);
        }
    }
}