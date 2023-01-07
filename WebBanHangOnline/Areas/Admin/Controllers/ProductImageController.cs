using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductImageController : Controller
    {
        // GET: Admin/ProductImage
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int id)
        {
            ViewBag.productid = id;
            var items = db.productImages.Where(x => x.ProductId == id).ToList();
            return View(items);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            var item = db.productImages.Find(id);
            if (item != null)
            {
                db.productImages.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
                //return RedirectToAction("Index");

            }
            return Json(new { success = false });
            //return View();

        }
        [HttpPost]
        public ActionResult AddImage(int productid ,string url)
        {

            db.productImages.Add(new ProductImage
            {
                ProductId = productid,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
            return Json(new { success = true });
            //return View();

        }
    }
}