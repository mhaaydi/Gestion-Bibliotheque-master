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
    public class AuteursController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Auteurs
        //comment below if not working
        //[Authorize(Roles = "ADMIN")]

        public ActionResult Index()
        {
            var auteur = db.auteur.Include(a => a.ouvrage);
            return View(db.auteur.ToList());
        }

        // GET: Auteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auteur auteur = db.auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // GET: Auteurs/Create
        public ActionResult Create()
        {
            ViewBag.idouvrage = new SelectList(db.ouvrage, "Id", "titre");
            return View();
        }

        // POST: Auteurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nom,prenom,idouvrage")] auteur auteur)
        {
            if (ModelState.IsValid)
            {
                db.auteur.Add(auteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idouvrage = new SelectList(db.ouvrage, "Id", "titre", auteur.idouvrage);
            return View(auteur);
        }

        // GET: Auteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auteur auteur = db.auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            ViewBag.idouvrage = new SelectList(db.ouvrage, "Id", "titre", auteur.idouvrage);
            return View(auteur);
        }

        // POST: Auteurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nom,prenom,idouvrage")] auteur auteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idouvrage = new SelectList(db.ouvrage, "Id", "titre", auteur.idouvrage);
            return View(auteur);
        }

        // GET: Auteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auteur auteur = db.auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            auteur auteur = db.auteur.Find(id);
            db.auteur.Remove(auteur);
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
