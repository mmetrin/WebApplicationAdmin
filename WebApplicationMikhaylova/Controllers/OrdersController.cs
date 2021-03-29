using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationMikhaylova.Models;

namespace WebApplicationMikhaylova.Controllers
{
    public class OrdersController : Controller
    {
        private PateticoRPMEntities db = new PateticoRPMEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Basket).Include(o => o.Shops).Include(o => o.Status).Include(o => o.Users);
            return View(orders.ToList());
        }
        // GET: SweetinBasket
        public ActionResult SweetinBasket(int id)
        {
            var sweets = db.BasketProduct.Where(o => o.id_basket == id).Include(o => o.Products).Include(o => o.Products.Parameters);
            return PartialView(sweets);
        }
        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.id_basket = new SelectList(db.Basket, "id_basket", "id_basket");
            ViewBag.id_shop = new SelectList(db.Shops, "id_shop", "address");
            ViewBag.id_status = new SelectList(db.Status, "id_status", "status1");
            ViewBag.id_user = new SelectList(db.Users, "id_user", "email");
            return View();
        }

        // POST: Orders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_order,delivery_date,final_price,id_user,id_basket,id_shop,id_status")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_basket = new SelectList(db.Basket, "id_basket", "id_basket", orders.id_basket);
            ViewBag.id_shop = new SelectList(db.Shops, "id_shop", "address", orders.id_shop);
            ViewBag.id_status = new SelectList(db.Status, "id_status", "status1", orders.id_status);
            ViewBag.id_user = new SelectList(db.Users, "id_user", "email", orders.id_user);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_basket = new SelectList(db.Basket, "id_basket", "id_basket", orders.id_basket);
            ViewBag.id_shop = new SelectList(db.Shops, "id_shop", "address", orders.id_shop);
            ViewBag.id_status = new SelectList(db.Status, "id_status", "status1", orders.id_status);
            ViewBag.id_user = new SelectList(db.Users, "id_user", "email", orders.id_user);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_order,delivery_date,final_price,id_user,id_basket,id_shop,id_status")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_basket = new SelectList(db.Basket, "id_basket", "id_basket", orders.id_basket);
            ViewBag.id_shop = new SelectList(db.Shops, "id_shop", "address", orders.id_shop);
            ViewBag.id_status = new SelectList(db.Status, "id_status", "status1", orders.id_status);
            ViewBag.id_user = new SelectList(db.Users, "id_user", "email", orders.id_user);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
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
