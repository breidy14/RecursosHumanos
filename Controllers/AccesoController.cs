using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usu, string pass)
        {
            try
            {
                using (Models.ProyectoFinalEntities db = new Models.ProyectoFinalEntities())
                {
                    var oUser = (from a in db.Usuarios
                                 where a.Usuario == usu.Trim() && a.Pass == pass.Trim()
                                 select a).FirstOrDefault();
                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }

                    Session["User"] = oUser;

                    ViewBag.Usu = usu;
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session["User"] = null;

            return RedirectToAction("Login");
        }
    }
}