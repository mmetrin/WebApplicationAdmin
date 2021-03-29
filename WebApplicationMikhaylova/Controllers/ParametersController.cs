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
    public class ParametersController : Controller
    {
        private PateticoRPMEntities db = new PateticoRPMEntities();

        // GET: Parameters
        public ActionResult Index()
        {
            return View(db.Parameters.ToList());
        }

        // GET: Parameters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parameters parameters = db.Parameters.Find(id);
            if (parameters == null)
            {
                return HttpNotFound();
            }
            return View(parameters);
        }

        // GET: Parameters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parameters/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_parameter,parameter")] Parameters parameters)
        {
            if (ModelState.IsValid)
            {
                db.Parameters.Add(parameters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parameters);
        }

        // GET: Parameters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parameters parameters = db.Parameters.Find(id);
            if (parameters == null)
            {
                return HttpNotFound();
            }
            return View(parameters);
        }

        // POST: Parameters/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_parameter,parameter")] Parameters parameters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parameters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parameters);
        }

        // GET: Parameters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parameters parameters = db.Parameters.Find(id);
            if (parameters == null)
            {
                return HttpNotFound();
            }
            return View(parameters);
        }

        // POST: Parameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parameters parameters = db.Parameters.Find(id);
            db.Parameters.Remove(parameters);
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
