using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionBibliotheque.Models;

namespace GestionBibliotheque.Controllers
{
    public class OuvragesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Ouvrages
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return View(db.ouvrage.ToList());
            else
                return View(db.ouvrage.ToList());
        }

        // GET: Ouvrages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ouvrage ouvrage = db.ouvrage.Find(id);
            if (ouvrage == null)
            {
                return HttpNotFound();
            }
            return View(ouvrage);
        }

        // GET: Ouvrages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ouvrages/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,titre,edition,nbExemplaires")] ouvrage ouvrage)
        {
            if (ModelState.IsValid)
            {
                db.ouvrage.Add(ouvrage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ouvrage);
        }

        // GET: Ouvrages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ouvrage ouvrage = db.ouvrage.Find(id);
            if (ouvrage == null)
            {
                return HttpNotFound();
            }
            return View(ouvrage);
        }

        // POST: Ouvrages/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,titre,edition,nbExemplaires")] ouvrage ouvrage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ouvrage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ouvrage);
        }

        // GET: Ouvrages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ouvrage ouvrage = db.ouvrage.Find(id);
            if (ouvrage == null)
            {
                return HttpNotFound();
            }
            return View(ouvrage);
        }

        // POST: Ouvrages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ouvrage ouvrage = db.ouvrage.Find(id);
            db.ouvrage.Remove(ouvrage);
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
