﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProyectoFinalEntities : DbContext
    {
        public ProyectoFinalEntities()
            : base("name=ProyectoFinalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<FuncionesRol> FuncionesRol { get; set; }
        public virtual DbSet<Licencias> Licencias { get; set; }
        public virtual DbSet<Nomina> Nomina { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<SalidaEmpleados> SalidaEmpleados { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vacaciones> Vacaciones { get; set; }
    
        public virtual int sp_Licencias(Nullable<int> empleadoId, Nullable<System.DateTime> desde, Nullable<System.DateTime> hasta, string motivo, string comentarios)
        {
            var empleadoIdParameter = empleadoId.HasValue ?
                new ObjectParameter("EmpleadoId", empleadoId) :
                new ObjectParameter("EmpleadoId", typeof(int));
    
            var desdeParameter = desde.HasValue ?
                new ObjectParameter("Desde", desde) :
                new ObjectParameter("Desde", typeof(System.DateTime));
    
            var hastaParameter = hasta.HasValue ?
                new ObjectParameter("Hasta", hasta) :
                new ObjectParameter("Hasta", typeof(System.DateTime));
    
            var motivoParameter = motivo != null ?
                new ObjectParameter("Motivo", motivo) :
                new ObjectParameter("Motivo", typeof(string));
    
            var comentariosParameter = comentarios != null ?
                new ObjectParameter("Comentarios", comentarios) :
                new ObjectParameter("Comentarios", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Licencias", empleadoIdParameter, desdeParameter, hastaParameter, motivoParameter, comentariosParameter);
        }
    
        public virtual int sp_Nomina(string agno, string mes)
        {
            var agnoParameter = agno != null ?
                new ObjectParameter("agno", agno) :
                new ObjectParameter("agno", typeof(string));
    
            var mesParameter = mes != null ?
                new ObjectParameter("mes", mes) :
                new ObjectParameter("mes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Nomina", agnoParameter, mesParameter);
        }
    
        public virtual int sp_Permisos(Nullable<int> empleadoId, Nullable<System.DateTime> desde, Nullable<System.DateTime> hasta, string comentarios)
        {
            var empleadoIdParameter = empleadoId.HasValue ?
                new ObjectParameter("EmpleadoId", empleadoId) :
                new ObjectParameter("EmpleadoId", typeof(int));
    
            var desdeParameter = desde.HasValue ?
                new ObjectParameter("Desde", desde) :
                new ObjectParameter("Desde", typeof(System.DateTime));
    
            var hastaParameter = hasta.HasValue ?
                new ObjectParameter("Hasta", hasta) :
                new ObjectParameter("Hasta", typeof(System.DateTime));
    
            var comentariosParameter = comentarios != null ?
                new ObjectParameter("Comentarios", comentarios) :
                new ObjectParameter("Comentarios", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Permisos", empleadoIdParameter, desdeParameter, hastaParameter, comentariosParameter);
        }
    
        public virtual int sp_SalidaEmpleados(Nullable<int> empleadoId, string tipoSalida, string motivo, Nullable<System.DateTime> fecha)
        {
            var empleadoIdParameter = empleadoId.HasValue ?
                new ObjectParameter("EmpleadoId", empleadoId) :
                new ObjectParameter("EmpleadoId", typeof(int));
    
            var tipoSalidaParameter = tipoSalida != null ?
                new ObjectParameter("TipoSalida", tipoSalida) :
                new ObjectParameter("TipoSalida", typeof(string));
    
            var motivoParameter = motivo != null ?
                new ObjectParameter("Motivo", motivo) :
                new ObjectParameter("Motivo", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_SalidaEmpleados", empleadoIdParameter, tipoSalidaParameter, motivoParameter, fechaParameter);
        }
    
        public virtual int sp_Vacaciones(Nullable<int> empleadoId, Nullable<System.DateTime> desde, Nullable<System.DateTime> hasta, string comentarios, string agno)
        {
            var empleadoIdParameter = empleadoId.HasValue ?
                new ObjectParameter("EmpleadoId", empleadoId) :
                new ObjectParameter("EmpleadoId", typeof(int));
    
            var desdeParameter = desde.HasValue ?
                new ObjectParameter("Desde", desde) :
                new ObjectParameter("Desde", typeof(System.DateTime));
    
            var hastaParameter = hasta.HasValue ?
                new ObjectParameter("Hasta", hasta) :
                new ObjectParameter("Hasta", typeof(System.DateTime));
    
            var comentariosParameter = comentarios != null ?
                new ObjectParameter("Comentarios", comentarios) :
                new ObjectParameter("Comentarios", typeof(string));
    
            var agnoParameter = agno != null ?
                new ObjectParameter("agno", agno) :
                new ObjectParameter("agno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Vacaciones", empleadoIdParameter, desdeParameter, hastaParameter, comentariosParameter, agnoParameter);
        }
    }
}