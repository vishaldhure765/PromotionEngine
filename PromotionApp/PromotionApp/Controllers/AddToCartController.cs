using PromotionApp.Edmx;
using PromotionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromotionApp.Controllers
{
    public class AddToCartController : Controller
    {
        // GET: AddToCart
        private PromotionEngineEntities db = new PromotionEngineEntities();
        public ActionResult Index()
        {
            return View();
        }

      

        public ActionResult Add(ProductMaster model)
        {
            if (Session["cart"] == null)
            {
                List<ProductMaster> li = new List<ProductMaster>();
                li.Add(model);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = 1;
            }
            else
            {
                List<ProductMaster> li = (List<ProductMaster>)Session["cart"];
                li.Add(model);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }
            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public ActionResult MyOrder()
        {
            List<MyOrderViewModel> myOrder = null;
            List<ProductMaster> data = (List<ProductMaster>)Session["cart"];
            if (data != null)
            {
                myOrder = data.ToList().GroupBy(x => x.Id).Select(cl => new MyOrderViewModel
                {
                    Id = cl.FirstOrDefault().Id,
                    Name = cl.FirstOrDefault().Name,
                    Code = cl.FirstOrDefault().Code,
                    Prize = cl.FirstOrDefault().Prize,
                    ItemTotal = cl.Sum(c => c.Prize),
                    //cl.Sum(c => c.Prize),
                    Quantity = cl.Count()
                }).ToList();

                foreach (var order in myOrder)
                {
                    int promotionQuantity = 0;
                    decimal pramotionPrice = 0;
                    PromotionMaster promotionDetails = db.PromotionMasters.FirstOrDefault(x => x.ProductId == order.Id);
                    if (promotionDetails != null)
                    {
                        promotionQuantity = promotionDetails.Quantity;
                        pramotionPrice = (decimal)db.PromotionMasters.FirstOrDefault(x => x.ProductId == order.Id).PromotionPrize;
                        order.ItemTotal = (order.Quantity / promotionQuantity) * pramotionPrice + (order.Quantity % promotionQuantity * order.Prize);
                    }

                }
            }
            else
                return RedirectToAction("Index", "Products");

            return View(myOrder);
        }

        public ActionResult Remove(ProductMaster model)
        {
            List<ProductMaster> li = (List<ProductMaster>)Session["cart"];
            li.RemoveAll(x => x.Id == model.Id);
            Session["cart"] = li;
            Session["count"] = li.Count();
                //Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");
        }
    }
}