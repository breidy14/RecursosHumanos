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
    public class EmpleadosController : Controller
    {
        private ProyectoFinalEntities db = new ProyectoFinalEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleados = db.Empleados.Include(e => e.Cargos).Include(e => e.Departamentos);
            return View(empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Estudiantes/Details/5
        [AuthorizeUser()]
        public ActionResult Permisos(int? id, string busqueda)
        {
            if (String.IsNullOrEmpty(busqueda) && id==null)
            {
                ViewBag.Error = "Inserte valor";
                return RedirectToAction("ListaP");
            }
            else
            {
                bool IsNum = int.TryParse(busqueda, out int result);
                if (IsNum || id!= null)
                {
                    if(IsNum)
                    id = int.Parse(busqueda);


                    Empleados empleados = new Empleados();
                    empleados = db.Empleados
                                .Include("Permisos")
                                .Where(x => x.EmpleadoId == id)
                                .Single();
                    return View(empleados);
                }
                else
                {
                    ViewBag.Error = "Inserte valor numerico";
                    return RedirectToAction("ListaP");
                }
            }

        }

        public ActionResult ListaP()
        {
            var empleados = db.Empleados.Include(e => e.Cargos).Include(e => e.Departamentos);
            return View(empleados.ToList());
        }

        public ActionResult ListarActivos(string bus)
        {

            var empleados = (db.Empleados.Include(e => e.Cargos).Include(e => e.Departamentos)).Where(e => e.Estatus.Equals("Activo"));
            if (String.IsNullOrEmpty(bus))
            {
                ViewBag.ErrorT = "Inserte el empleado o el departamento";
                
                
                return View(empleados.ToList());
            }
            else
            {
                var result = empleados.Where(e => e.Nombre.Contains(bus)|| e.Departamentos.Nombre.Contains(bus));
                if (result == null)
                {
                    ViewBag.ErrorT = "Datos Invalidos";
                    return View(empleados.ToList());
                }
                return View(result.ToList());
            }

            
        }

        public ActionResult ListarInactivos()
        {
            var empleados = (db.Empleados.Include(e => e.Cargos).Include(e => e.Departamentos)).Where(e => e.Estatus.Equals("Inactivo"));
            return View(empleados.ToList());
        }


        public ActionResult ListaEntradas(string mes)
        {
            var empleados = (db.Empleados.Include(e => e.Cargos).Include(e => e.Departamentos)).Where(e => e.Estatus.Equals("Activo"));
            int num;
            if (String.IsNullOrEmpty(mes))
            {
                
                return View(empleados.ToList());
            }
            else
            {
                if (mes.Equals("diciembre"))
                {
                    num = 12;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("noviembre"))
                {
                    num = 11;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("octubre"))
                {
                    num = 10;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("septiembre"))
                {
                    num = 9;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("agosto"))
                {
                    num = 8;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("julio"))
                {
                    num = 7;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("junio"))
                {
                    num = 6;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("mayo"))
                {
                    num = 5;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("abril"))
                {
                    num = 4;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("marzo"))
                {
                    num = 3;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("febrero"))
                {
                    num = 2;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("enero"))
                {
                    num = 1;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                return View(empleados.ToList());
            }
            
        }

        public ActionResult ListaSalidas(string mes)
        {
            var empleados = (db.Empleados.Include(e => e.Cargos).Include(e => e.Departamentos)).Where(e => e.Estatus.Equals("Inactivo"));
            int num;
            if (String.IsNullOrEmpty(mes))
            {

                return View(empleados.ToList());
            }
            else
            {
                if (mes.Equals("diciembre"))
                {
                    num = 12;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("noviembre"))
                {
                    num = 11;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("octubre"))
                {
                    num = 10;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("septiembre"))
                {
                    num = 9;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("agosto"))
                {
                    num = 8;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("julio"))
                {
                    num = 7;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("junio"))
                {
                    num = 6;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("mayo"))
                {
                    num = 5;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("abril"))
                {
                    num = 4;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("marzo"))
                {
                    num = 3;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("febrero"))
                {
                    num = 2;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                else if (mes.Equals("enero"))
                {
                    num = 1;
                    var res = empleados
                    .Where(e => e.FechaIngreso.Month.Equals(num));
                    return View(res.ToList());
                }
                return View(empleados.ToList());

            }

        }

        // GET: Empleados/Create
        [AuthorizeUser()]
        public ActionResult Create()
        {
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Nombre");
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser()]
        public ActionResult Create([Bind(Include = "EmpleadoId,Nombre,Apellido,Telefono,DepartamentoId,CargoId,FechaIngreso,Salario,Estatus")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Nombre", empleados.CargoId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre", empleados.DepartamentoId);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        [AuthorizeUser()]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Nombre", empleados.CargoId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre", empleados.DepartamentoId);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser()]
        public ActionResult Edit([Bind(Include = "EmpleadoId,Nombre,Apellido,Telefono,DepartamentoId,CargoId,FechaIngreso,Salario,Estatus")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Nombre", empleados.CargoId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre", empleados.DepartamentoId);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        [AuthorizeUser()]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeUser()]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
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
