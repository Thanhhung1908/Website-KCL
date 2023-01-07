using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var items = db.Products.ToList();
            return View(items);
        }public ActionResult Details( string alias,int? id)
        {
            var item = db.Products.Find(id);
            return View(item);
        }
        public ActionResult ProductCategory(string alias,int? id)
        {
            var items = db.Products.ToList();
            if (id != null)
            {
                items = items.Where(x=>x.ProductCategoryID==id.ToString()).ToList();
                ViewBag.CateId = id;
                var cateName = db.ProductCategories.Find(id);
                ViewBag.cateName = cateName.Title;
            }
         
           
            return View(items);
        }
        public ActionResult Partial_ItemByCateId()
        {
            var items = db.Products.Where(x=>x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView( items);
        }
        public ActionResult ProductWebsite()
        {
            var items = db.Products.Where(x => x.IsHome && x.ProductCategory.Title.Trim()== "Sản Phẩm Chủ Đạo").Take(12).ToList();
            return View(items);
        }
        public ActionResult Partial_ProductSales()
        {
            var items = db.Products.Where(x=>x.IsSale && x.IsActive).Take(12).ToList();
            return PartialView( items);
        }
    }
}