using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                ViewBag.ShoppingCart = cart;
            }
            return View();
        }
        public ActionResult CheckOutSuccess()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut( OrderViewModel req)
        {
            var code = new { Success = false, code = -1 };
            if (ModelState.IsValid)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart != null)
                {
                    Order order = new Order();
                    order.CustomerName = req.CustomerName;
                    order.Phone = req.Phone;
                    order.Address = req.Address;
                    cart.items.ForEach(x => order.OrderDetails.Add(new OrderDetail
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        Price = x.Price,
                    }));
                    order.TotalAmount = cart.items.Sum(x => (x.Price * x.Quantity));
                    order.TypePayment = req.TypePayment;
                    order.CreatedDate=DateTime.Now;
                    order.ModifiedrDate=DateTime.Now;
                    order.CreatedBy = req.Phone;
                    Random random = new Random();
                    order.Code = "DH" + random.Next(0, 9) + random.Next(0, 9) + random.Next(0, 9);
                    db.Orders.Add(order);
                    return RedirectToAction("CheckOutSuccess");
                }
            }
            else
            {
                //return View(order);
            }
            return Json(code);
        }
        public ActionResult patial_view_cart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return PartialView(cart.items);
            }
            return  PartialView();
        }
        public ActionResult patial_view_payment()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return PartialView(cart.items);
            }
            return PartialView();
        }
        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return Json(new { Count = cart.items.Count },JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0 }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost] 
        public ActionResult AddToCart(int id , int quantity)
        {
            var code = new { Success = false, msg = "", code = -1,Count=0 };
            var db = new ApplicationDbContext();
            var checkproduct = db.Products.FirstOrDefault(x => x.Id == id);
            if (checkproduct != null)
            {
                ShoppingCart cart = (ShoppingCart) Session["Cart"];
                if(cart == null)
                {
                    cart = new ShoppingCart();
                }
                ShoppingCartItem shoppingCartItem = new ShoppingCartItem
                {
                    ProductId = checkproduct.Id,
                    ProductName = checkproduct.Title,
                    CategoryName = checkproduct.ProductCategory.Title,
                    Quantity = quantity,
                    Alias = checkproduct.Alias,
                };

                var image = checkproduct.ProductImage.FirstOrDefault(x => x.IsDefault).Image;
                if (image != null)
                {
                    shoppingCartItem.ProductImg = image;
                }
                shoppingCartItem.Price = (decimal)checkproduct.Price;
                if (checkproduct.PriceSale > 0)
                {
                    shoppingCartItem.Price = (decimal)checkproduct.PriceSale;
                }
                shoppingCartItem.TotalPrice = shoppingCartItem.Quantity * shoppingCartItem.Price;
                cart.AddToCart(shoppingCartItem, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm sản phẩm vào giỏ hàng thành công!", code = 1, Count= cart.items.Count };
            }
            return Json(code);
        }
        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateQuantity(id,quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, code = -1, msg = "", Count = 0 };
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                var checkProduct = cart.items.FirstOrDefault(x => x.ProductId == id);
                if (checkProduct != null)
                {
                    cart.items.Remove(checkProduct);
                     code = new { Success = true, code = 1, msg = " Đã Xoá Sản phẩm thành công", Count = cart.items.Count };

                }
            }
            return Json(code);
        }
        [HttpPost]
        public ActionResult DeleteAll()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if(cart != null)
            {
                cart.ClearCart();
                return Json(new { Success = true });
            }
            return Json(new { Success = false });

        }

    }
}