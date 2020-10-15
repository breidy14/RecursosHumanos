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
    public class NominasController : Controller
    {
        private ProyectoFinalEntities db = new ProyectoFinalEntities();

        // GET: Nominas
        public ActionResult Index(String busqueda)
        {
            if (string.IsNullOrEmpty(busqueda))
            {
                return View(db.Nomina.ToList());
            }
            else
            {
                var lista = from x in db.Nomina select x;
                lista = lista.Where(x => x.Agno.Contains(busqueda) || x.Mes.Contains(busqueda));

                return View(lista);
            }
        }

        // GET: Nominas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nomina.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // GET: Nominas/Create
        [AuthorizeUser()]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nominas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthorizeUser()]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NominaId,Agno,Mes,MontoTotal")] Nomina nomina)
        {

            if (ModelState.IsValid)
            {
                var lista = from x in db.Nomina select x;
                lista = lista.Where(a => a.Agno.Contains(nomina.Agno));
                var nom = (from c in lista where c.Mes.Equals(nomina.Mes) select c).FirstOrDefault();

                if (nom != null)
                {
                    ViewBag.Error = "Ya se agrego la nomina para el mes y año seleccionado";

                    return View(nomina);
                }
                else
                {
                    db.sp_Nomina(nomina.Agno, nomina.Mes);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            return View(nomina);
        }

        // GET: Nominas/Edit/5
        [AuthorizeUser()]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nomina.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthorizeUser()]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NominaId,Agno,Mes,MontoTotal")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nomina);
        }

        // GET: Nominas/Delete/5
        [AuthorizeUser()]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nomina.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [AuthorizeUser()]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nomina nomina = db.Nomina.Find(id);
            db.Nomina.Remove(nomina);
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
