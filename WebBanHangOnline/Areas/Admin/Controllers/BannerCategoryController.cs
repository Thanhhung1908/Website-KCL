using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class BannerCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/BannerCategory
        public ActionResult Index()
        {
            var items = db.bannerCategories.ToList();
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BannerCategory model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedrDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.bannerCategories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var item = db.bannerCategories.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BannerCategory model)
        {
            if (ModelState.IsValid)
            {

                model.ModifiedrDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.bannerCategories.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            var item = db.bannerCategories.Find(id);
            if (item != null)
            {
                db.bannerCategories.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
                //return RedirectToAction("Index");

            }
            return Json(new { success = false });
            //return View();

        }
        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!String.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.bannerCategories.Find(Convert.ToInt32(item));
                        db.bannerCategories.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });

            }


            return Json(new { success = false });

        }


    }
}