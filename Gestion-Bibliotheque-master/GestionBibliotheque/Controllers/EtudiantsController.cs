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
    public class EtudiantsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Etudiants
        public ActionResult Index()
        {
            var etudiant = db.etudiant.Include(e => e.Compte);
            return View(etudiant.ToList());
        }

        // GET: Etudiants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etudiant etudiant = db.etudiant.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        // GET: Etudiants/Create
        public ActionResult Create()
        {
            ViewBag.login = new SelectList(db.Compte, "login", "pwd");
            return View();
        }

        // POST: Etudiants/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nom,prenom,niveau,login")] etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.etudiant.Add(etudiant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.login = new SelectList(db.Compte, "login", "pwd", etudiant.login);
            return View(etudiant);
        }

        // GET: Etudiants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etudiant etudiant = db.etudiant.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            ViewBag.login = new SelectList(db.Compte, "login", "pwd", etudiant.login);
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nom,prenom,niveau,login")] etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etudiant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.login = new SelectList(db.Compte, "login", "pwd", etudiant.login);
            return View(etudiant);
        }

        // GET: Etudiants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etudiant etudiant = db.etudiant.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            etudiant etudiant = db.etudiant.Find(id);
            db.etudiant.Remove(etudiant);
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
