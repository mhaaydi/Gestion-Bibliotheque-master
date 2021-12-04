using GestionBibliotheque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionBibliotheque.Controllers
{
    public class HomeController : Controller
    {
        private Model1Container db = new Model1Container();
        public ActionResult Deconnect()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Compte model)
        {
            if (!ModelState.IsValid)
                return View();
            Compte c = db.Compte.Find(model.login);
            if (c != null && c.pwd == model.pwd)
            {
                FormsAuthentication.SetAuthCookie(model.login, false);
                return RedirectToAction("LoggedIn", "Comptes");
            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //return RedirectToAction("index", "ouvrages");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}