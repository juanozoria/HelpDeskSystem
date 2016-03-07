//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpDesk
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegistroSoporte
    {
        public int IdSoporte { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public string DescripcionProblema { get; set; }
        public Nullable<int> DepartamentId { get; set; }
        public Nullable<int> IdProblem { get; set; }
        public Nullable<int> IdTipoSolicitud { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<int> IdSeveridad { get; set; }
        public Nullable<int> IdTecnico { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> AsignadoPor { get; set; }
        public Nullable<int> CerradoPor { get; set; }
    
        public virtual Departamentos Departamentos { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Problemas Problemas { get; set; }
        public virtual Severidad Severidad { get; set; }
        public virtual TipoSolicitud TipoSolicitud { get; set; }
    }
}
