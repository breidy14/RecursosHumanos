//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Permisos
    {
        public int PermisoId { get; set; }
        public int EmpleadoId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM/dd/yyyy}", ApplyFormatInEditMode =true)]
        public System.DateTime Desde { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Hasta { get; set; }
        public string Comentarios { get; set; }
    
        public virtual Empleados Empleados { get; set; }
    }
}
