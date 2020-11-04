using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PromotionApp.Edmx;

namespace PromotionApp.Controllers
{
    public class PromotionDetailsController : Controller
    {
        private PromotionEngineEntities db = new PromotionEngineEntities();

        // GET: PromotionDetails
        public ActionResult Index()
        {
            var promotionMasters = db.PromotionMasters.Include(p => p.ProductMaster);
            return View(promotionMasters.ToList());
        }

        // GET: PromotionDetails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionMaster promotionMaster = db.PromotionMasters.Find(id);
            if (promotionMaster == null)
            {
                return HttpNotFound();
            }
            return View(promotionMaster);
        }

        // GET: PromotionDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.ProductMasters, "Id", "Name");
            return View();
        }

        // POST: PromotionDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,Quantity,Discount,ProductPrize,PromotionPrize")] PromotionMaster promotionMaster)
        {
            if (ModelState.IsValid)
            {
                db.PromotionMasters.Add(promotionMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.ProductMasters, "Id", "Name", promotionMaster.ProductId);
            return View(promotionMaster);
        }

        // GET: PromotionDetails/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionMaster promotionMaster = db.PromotionMasters.Find(id);
            if (promotionMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.ProductMasters, "Id", "Name", promotionMaster.ProductId);
            return View(promotionMaster);
        }

        // POST: PromotionDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,Quantity,Discount,ProductPrize,PromotionPrize")] PromotionMaster promotionMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promotionMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.ProductMasters, "Id", "Name", promotionMaster.ProductId);
            return View(promotionMaster);
        }

        // GET: PromotionDetails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionMaster promotionMaster = db.PromotionMasters.Find(id);
            if (promotionMaster == null)
            {
                return HttpNotFound();
            }
            return View(promotionMaster);
        }

        // POST: PromotionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PromotionMaster promotionMaster = db.PromotionMasters.Find(id);
            db.PromotionMasters.Remove(promotionMaster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
