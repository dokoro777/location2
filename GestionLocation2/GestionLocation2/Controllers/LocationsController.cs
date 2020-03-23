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
using Newtonsoft.Json;

namespace GestionLocation2.Controllers
{
    public class LocationsController : Controller
    {
        private LocationContext db = new LocationContext();
        private string matricule;

        // GET: Locations
        public ActionResult Index()
        {
            return View(db.Locations.ToList());
        }

        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            List<Vehicule> vehicules = db.Vehicules.ToList();
            ViewBag.vehicules = new SelectList(vehicules,"Id", "Matricule");
            return View();
        }

        // POST: Locations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Nbjour,Montantr")] Location location)
        {
            location.Vehicule = db.Vehicules.Find(location.Vehicule.Id);
            if(location.Client.Id != 0)
            {
                location.Client = db.Clients.Find(location.Client.Id);
            }
            try
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.message = "erreur :" + ex.Message;
                List<Vehicule> vehicules = db.Vehicules.ToList();
                ViewBag.vehicules = new SelectList(vehicules, "Id", "Matricule");
            }
            return View(location);
            

        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Nbjour,Montantr")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
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

        public JsonResult FindClient(int numpiece) {
            var c = (from cli in db.Clients where cli.Numpiece == numpiece select new { cli.Id, cli.Nom, cli.Prenom, cli.Numpiece, cli.Date, cli.Email,cli.Adresse });
            
            return Json(c, JsonRequestBehavior.AllowGet);
            
        }
        public JsonResult FindVehicule(int Id)
        {
            Vehicule v = (from vehi in db.Vehicules where vehi.Id == Id select vehi).FirstOrDefault();
            if (v == null)
            {
                v = new Vehicule();
            }
            return Json(new { v.Id, v.Marque, v.Matricule, v.Modele, v.PrixJour,v.Couleur }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult FindLocation()
        {
            ViewBag.input = "";
            return View("GetLocationByClient",db.Locations.Include("vehicule").ToList());

        }
        [HttpPost]
        public ActionResult FindLocation(int numpiece)
        {
            ViewBag.input = numpiece + "";
            List<Location> locations = db.Locations.Where(l=>l.Client.Numpiece==numpiece).ToList();
            return View("GetLocationByClient", locations);

        }

    }
}
