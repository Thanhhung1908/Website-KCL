using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models.EF;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class BannerController : Controller
    {
        // GET: Admin/Banner
        private ApplicationDbContext db = new ApplicationDbContext();
      
        public ActionResult Index(string SearchText, int? page)
        {
            IEnumerable<Banner> items = db.banners.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.Title.Contains(SearchText) || x.Alias.Contains(SearchText));
            }
            var pagesize = 3;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pagesize);
            ViewBag.pageSize = pagesize;
            ViewBag.page = page;
            return View(items);
        }
        public ActionResult Add()
        {
            ViewBag.productCategory = new SelectList(db.bannerCategories.ToList(), "Id", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Banner model)
        {
            if (ModelState.IsValid)
            {
                var bannnerCategory = db.bannerCategories.Find(Convert.ToInt32(model.BanerTypeID));
                model.bannerCategory = bannnerCategory;
                model.CreatedDate = DateTime.Now;
                model.ModifiedrDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.banners.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productCategory = new SelectList(db.bannerCategories.ToList(), "Id", "Title");

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.productCategory = new SelectList(db.bannerCategories.ToList(), "Id", "Title");

            var item = db.banners.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Banner model)
        {
            if (ModelState.IsValid)
            {

                model.ModifiedrDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.banners.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productCategory = new SelectList(db.bannerCategories.ToList(), "Id", "Title");
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            var item = db.banners.Find(id);
            if (item != null)
            {
                db.banners.Remove(item);
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
                        var obj = db.banners.Find(Convert.ToInt32(item));
                        db.banners.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });

            }


            return Json(new { success = false });

        }
    }
}