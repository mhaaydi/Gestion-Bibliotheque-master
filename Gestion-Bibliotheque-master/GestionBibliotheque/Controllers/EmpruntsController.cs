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
    public class EmpruntsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Emprunts
       // [Authorize]
        public ActionResult Index()
        {
            var emprunt = db.emprunt.Include(e => e.ouvrage).Include(e => e.etudiant);
            return View(emprunt.ToList());
        }

        // GET: Emprunts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emprunt emprunt = db.emprunt.Find(id);
            if (emprunt == null)
            {
                return HttpNotFound();
            }
            return View(emprunt);
        }

        // GET: Emprunts/Create
       //* [Authorize]
        public ActionResult Create()
        {
            ViewBag.idouvrage = new SelectList(db.ouvrage, "Id", "titre");
            ViewBag.idetudiant = new SelectList(db.etudiant, "Id", "nom");
            return View();
        }

        // POST: Emprunts/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       //* [Authorize]
        public ActionResult Create([Bind(Include = "Id,idouvrage,idetudiant,dateemprunt,dateretour")] emprunt emprunt)
        {
            if (ModelState.IsValid)
            {
                db.emprunt.Add(emprunt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idouvrage = new SelectList(db.ouvrage, "Id", "titre", emprunt.idouvrage);
            ViewBag.idetudiant = new SelectList(db.etudiant, "Id", "nom", emprunt.idetudiant);
            return View(emprunt);
        }

        // GET: Emprunts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emprunt emprunt = db.emprunt.Find(id);
            if (emprunt == null)
            {
                return HttpNotFound();
            }
            ViewBag.idouvrage = new SelectList(db.ouvrage, "Id", "titre", emprunt.idouvrage);
            ViewBag.idetudiant = new SelectList(db.etudiant, "Id", "nom", emprunt.idetudiant);
            return View(emprunt);
        }

        // POST: Emprunts/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      //*  [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,idouvrage,idetudiant,dateemprunt,dateretour")] emprunt emprunt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprunt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idouvrage = new SelectList(db.ouvrage, "Id", "titre", emprunt.idouvrage);
            ViewBag.idetudiant = new SelectList(db.etudiant, "Id", "nom", emprunt.idetudiant);
            return View(emprunt);
        }

        // GET: Emprunts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emprunt emprunt = db.emprunt.Find(id);
            if (emprunt == null)
            {
                return HttpNotFound();
            }
            return View(emprunt);
        }

        // POST: Emprunts/Delete/5
        [HttpPost, ActionName("Delete")]
       //* [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emprunt emprunt = db.emprunt.Find(id);
            db.emprunt.Remove(emprunt);
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
