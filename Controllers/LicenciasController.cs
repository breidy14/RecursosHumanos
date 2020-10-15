using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Filters;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class LicenciasController : Controller
    {
        private ProyectoFinalEntities db = new ProyectoFinalEntities();

        // GET: Licencias
        public ActionResult Index()
        {
            var licencias = db.Licencias.Include(l => l.Empleados);
            return View(licencias.ToList());
        }

        // GET: Licencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencias licencias = db.Licencias.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            return View(licencias);
        }

        // GET: Licencias/Create
        [AuthorizeUser()]
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre");
            return View();
        }

        // POST: Licencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthorizeUser()]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermisoId,EmpleadoId,Desde,Hasta,Motivo,Comentarios")] Licencias licencias)
        {
            if (ModelState.IsValid)
            {
                db.sp_Licencias(licencias.EmpleadoId, licencias.Desde, licencias.Hasta, licencias.Motivo, licencias.Comentarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre", licencias.EmpleadoId);
            return View(licencias);
        }

        // GET: Licencias/Edit/5
        [AuthorizeUser()]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencias licencias = db.Licencias.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre", licencias.EmpleadoId);
            return View(licencias);
        }

        // POST: Licencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser()]
        public ActionResult Edit([Bind(Include = "PermisoId,EmpleadoId,Desde,Hasta,Motivo,Comentarios")] Licencias licencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre", licencias.EmpleadoId);
            return View(licencias);
        }

        // GET: Licencias/Delete/5
        [AuthorizeUser()]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencias licencias = db.Licencias.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            return View(licencias);
        }

        // POST: Licencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [AuthorizeUser()]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Licencias licencias = db.Licencias.Find(id);
            db.Licencias.Remove(licencias);
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
