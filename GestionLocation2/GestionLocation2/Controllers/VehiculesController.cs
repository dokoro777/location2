using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionLocation2.DAL;
using GestionLocation2.Models;

namespace GestionLocation2.Controllers
{
    public class VehiculesController : Controller
    {
        private LocationContext db = new LocationContext();

        // GET: Vehicules
        public ActionResult Index()
        {
            return View(db.Vehicules.ToList());
        }

        // GET: Vehicules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicule vehicule = db.Vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // GET: Vehicules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicules/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Matricule,Marque,Modele,Couleur,PrixJour")] Vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                db.Vehicules.Add(vehicule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicule);
        }

        // GET: Vehicules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicule vehicule = db.Vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // POST: Vehicules/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Matricule,Marque,Modele,Couleur,PrixJour")] Vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicule);
        }

        // GET: Vehicules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicule vehicule = db.Vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // POST: Vehicules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicule vehicule = db.Vehicules.Find(id);
            db.Vehicules.Remove(vehicule);
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
