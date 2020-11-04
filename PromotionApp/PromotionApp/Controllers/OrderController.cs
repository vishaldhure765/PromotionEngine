using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromotionApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult PlaceOrder()
        {
            Session["cart"] = null;
            Session["count"] = 0;
            return View();
        }
    }
}