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
    public class SalidaEmpleadosController : Controller
    {
        private ProyectoFinalEntities db = new ProyectoFinalEntities();

        // GET: SalidaEmpleados
        public ActionResult Index()
        {
            var salidaEmpleados = db.SalidaEmpleados.Include(s => s.Empleados);
            return View(salidaEmpleados.ToList());
        }

        // GET: SalidaEmpleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleados salidaEmpleados = db.SalidaEmpleados.Find(id);
            if (salidaEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleados);
        }

        // GET: SalidaEmpleados/Create
        [AuthorizeUser()]
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre");
            return View();
        }

        // POST: SalidaEmpleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthorizeUser()]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalidaId,EmpleadoId,TipoSalida,Motivo,FechaSalida")] SalidaEmpleados salidaEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.sp_SalidaEmpleados(salidaEmpleados.EmpleadoId, salidaEmpleados.TipoSalida, salidaEmpleados.Motivo, salidaEmpleados.FechaSalida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre", salidaEmpleados.EmpleadoId);
            return View(salidaEmpleados);
        }

        // GET: SalidaEmpleados/Edit/5
       /* public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleados salidaEmpleados = db.SalidaEmpleados.Find(id);
            if (salidaEmpleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre", salidaEmpleados.EmpleadoId);
            return View(salidaEmpleados);
        }

        // POST: SalidaEmpleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalidaId,EmpleadoId,TipoSalida,Motivo,FechaSalida")] SalidaEmpleados salidaEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidaEmpleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre", salidaEmpleados.EmpleadoId);
            return View(salidaEmpleados);
        }

        // GET: SalidaEmpleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleados salidaEmpleados = db.SalidaEmpleados.Find(id);
            if (salidaEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleados);
        }

        // POST: SalidaEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalidaEmpleados salidaEmpleados = db.SalidaEmpleados.Find(id);
            db.SalidaEmpleados.Remove(salidaEmpleados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

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
