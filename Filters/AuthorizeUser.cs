using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private Usuarios oUsuario;
        private ProyectoFinalEntities db = new ProyectoFinalEntities();
        private int idOperacion;

        public AuthorizeUser(/*int idOperacion = 0*/)
        {
           // this.idOperacion = idOperacion;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";
            String nombreModulo = "";
            try
            {
                
                oUsuario = (Usuarios)HttpContext.Current.Session["User"];
                var lstMisOperaciones = from m in db.UsuarioRol
                                        where m.UsuarioId == oUsuario.UsuarioId
                                        select m;


                if (lstMisOperaciones.ToList().Count() == 0)
                {
                    var oOperacion = db.FuncionesRol.Find(idOperacion);
                    int? idModulo = oOperacion.ID;
                    nombreOperacion = getNombreDeOperacion(idOperacion);
                    filterContext.Result = new RedirectResult("~/Error/SinAutorizacion?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/SinAutorizacion?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=" + ex.Message);
            }
        }

        public string getNombreDeOperacion(int idOperacion)
        {
            var ope = from op in db.UsuarioRol
                      where op.ID == idOperacion
                      select op.Rol;
            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }

        public string getNombreDelModulo(int? idModulo)
        {
            var modulo = from m in db.FuncionesRol
                         where m.ID == idModulo
                         select m.NombreFun;
            String nombreModulo;
            try
            {
                nombreModulo = modulo.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }
            return nombreModulo;
        }
    }
}