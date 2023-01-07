using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Authorize()]
        // GET: Admin/Home
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string today = DateTime.Now.ToString("dd/MM/yyyy");

            ViewBag.coutFeedBack = db.feedbacks.GroupBy(x=>x.Email).Count();
            return View();
        }
        string getDayFormat(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
    }
}