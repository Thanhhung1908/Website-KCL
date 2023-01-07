using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int ?page)
        {
            IEnumerable<Product > items = db.Products.OrderByDescending(x => x.Id);
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
            ViewBag.productCategory = new SelectList(db.ProductCategories.ToList(),"Id","Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(Product model ,List<String>Images,List<int>rDefault)
        {
            if (ModelState.IsValid)
            {
                if (Images!=null&& Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if(i+1 == rDefault[0])
                        {
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                IsDefault = true
                            });
                        }
                        else
                        {
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                IsDefault = false
                            });
                        }
                    }
                }
                model.CreatedDate = DateTime.Now;
                model.ModifiedrDate = DateTime.Now;
                var productCategory = db.ProductCategories.Find( Convert.ToInt32( model.ProductCategoryID));
                model.ProductCategory=productCategory;
                if (String.IsNullOrEmpty(model.Alias))
                {
                    model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                }
                if (String.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }

                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.productCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            var item = db.Products.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {

                model.ModifiedrDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                var productCategory = db.ProductCategories.Find(Convert.ToInt32(model.ProductCategoryID));
                model.ProductCategory = productCategory;
                db.Products.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            var item = db.Products.Find(id);
            if (item != null)
            {
                db.Products.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
                //return RedirectToAction("Index");

            }
            return Json(new { success = false });
            //return View();

        }
        [HttpPost]

        public ActionResult IsActive(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new {success=true, IsActive = item.IsActive });
            }
            return Json(new { success = false});

        } public ActionResult IsHome(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsHome = !item.IsHome;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new {success=true,IsHome=item.IsHome});
            }
            return Json(new { success = false});

        }

    }
}