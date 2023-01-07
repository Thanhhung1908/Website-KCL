using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Admin/Feedback
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string SearchText, int? page)
        {
            IEnumerable<Feedback> items = db.feedbacks.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.CusName.Contains(SearchText) || x.Email.Contains(SearchText));
            }
            var pagesize = 15;
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
      
        public ActionResult Edit(int id)
        {
            var item = db.feedbacks.Find(id);
            if (item!=null)
            {
                item.IsRespond = !item.IsRespond;
                db.feedbacks.Attach(item);
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(string cusName, string address, string email, string feedback)
        {
            Feedback feedback1 = new Feedback()
            {
                CusName = cusName,
                Address = address,
                Email = email,
                ContentFeedback = feedback
            };
            feedback1.CreatedDate = DateTime.Now;
            feedback1.ModifiedrDate = DateTime.Now;
            db.feedbacks.Add(feedback1);
            db.SaveChanges();
            return Json(new { msg = "Success", Success = true });

        }
    }

    }
