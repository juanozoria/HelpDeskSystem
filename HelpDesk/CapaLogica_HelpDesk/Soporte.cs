using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AccesoADatos;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace CapaLogica_HelpDesk
{
    public class Soporte
    {
        public Soporte()
        {
            IdEstado = 1; //El estado siempre sera nuevo al inicio de crear una nueva solicitud.
        }
        public int IdSoporte { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        [StringLength(200, ErrorMessage = "La descripción no puede ser mayor a 200 caracteres.")]
        public string DescripcionProblema { get; set; }
        public int DepartamentId { get; set; }
        public string Departamento { get; set; }
        public int IdProblem { get; set; }
        public string Problema { get; set; }
        public int IdTipoSolicitud { get; set; }
        public string TipoSolicitud { get; set; }
        public int IdSeveridad { get; set; }
        public string Severidad { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdTecnico { get; set; }
        public string imagepath { get; set; }
        public string UsuarioAsignador { get; set; }
        public string TecnicoAsignado { get; set; }
        public string Cerrador { get; set; }



        public void RegistrarSoporte()
        {
            SqlCommand cmd = new SqlCommand("InsertSoporte");
            cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            cmd.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            cmd.Parameters.AddWithValue("@DescripcionProblema", DescripcionProblema);
            cmd.Parameters.AddWithValue("@DepartamentId", DepartamentId);
            cmd.Parameters.AddWithValue("@IdProblem", IdProblem);
            cmd.Parameters.AddWithValue("@IdTipoSolicitud", IdTipoSolicitud);
            cmd.Parameters.AddWithValue("@IdEstado", IdEstado);
            cmd.Parameters.AddWithValue("@IdPrioridad", IdSeveridad);
            cmd.Parameters.AddWithValue("@imagepath", imagepath);

            SqlParameter OutputParam = new SqlParameter();
            OutputParam.ParameterName = "@NewId";
            OutputParam.SqlDbType = SqlDbType.Int;
            OutputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(OutputParam);

            SqlServer db = new SqlServer();
            db.ejecutar_Sp(cmd);

            this.IdSoporte = (int)OutputParam.Value;


        }

        public void UpdateSoporte()
        {
            SqlCommand cmd = new SqlCommand("UpdateSoporte");
            cmd.Parameters.AddWithValue("@IdSoporte", IdSoporte);
            cmd.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            cmd.Parameters.AddWithValue("@DescripcionProblema", DescripcionProblema);
            cmd.Parameters.AddWithValue("@DepartamentId", DepartamentId);
            cmd.Parameters.AddWithValue("@IdProblem", IdProblem);
            cmd.Parameters.AddWithValue("@IdTipoSolicitud", IdTipoSolicitud);
            cmd.Parameters.AddWithValue("@IdEstado", IdEstado);
            cmd.Parameters.AddWithValue("@IdPrioridad", IdSeveridad);
            cmd.Parameters.AddWithValue("@imagepath", imagepath);
            SqlServer db = new SqlServer();
            db.ejecutar_Sp(cmd);

        }

        public static Soporte GetOneSoporte(int id)
        {
            Soporte soport;
            SqlServer db = new SqlServer();
            SqlCommand cmd = new SqlCommand("GetOneSoporte");
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = db.get_tabla(cmd);
            if (dt.Rows.Count == 0)
            {
                throw new Exception("Consulta sin resultados");
            }

            DataRow f = dt.Rows[0];
            soport = new Soporte();
            soport.IdSoporte = int.Parse(f["IdSoporte"].ToString());
            soport.IdUsuario = int.Parse(f["IdUsuario"].ToString());
            soport.FechaRegistro = DateTime.Parse(f["FechaRegistro"].ToString());
            soport.DescripcionProblema = f["DescripcionProblema"].ToString();
            soport.DepartamentId = int.Parse(f["DepartamentId"].ToString());
            soport.Departamento = f["Departamento"].ToString();
            soport.IdProblem = int.Parse(f["IdProblem"].ToString());
            soport.IdSeveridad = int.Parse(f["IdSeveridad"].ToString());
            soport.Severidad = f["Severidad"].ToString();
            soport.Estado = f["Estado"].ToString();
            soport.Problema = f["Problema"].ToString();
            soport.IdTipoSolicitud = int.Parse(f["IdTipoSolicitud"].ToString());
            soport.TipoSolicitud = f["TipoSolicitud"].ToString();

            soport.imagepath = f["imagepath"].ToString();
            if (string.IsNullOrEmpty(soport.imagepath))
                soport.imagepath = "nofoto.png";

                return soport;
        }

        public static List<Soporte> GetAllSoportes(int? idsoporte = null, string descripcion = null, int? department = null, int? status = null, DateTime? FechaRegistro = null, int? idtiposolicitud = null, int? idseveridad = null)
        {
            List<Soporte> soportlist = new List<Soporte>();
            Soporte soport;
            SqlCommand cb = new SqlCommand("ConsultaMasivaSoporte");
            cb.Parameters.AddWithValue("@IdSoporte", idsoporte);
            cb.Parameters.AddWithValue("@DescripcionProblema", descripcion);
            cb.Parameters.AddWithValue("@Department", department);
            cb.Parameters.AddWithValue("@IdEstado", status);
            cb.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            cb.Parameters.AddWithValue("@IdTipoSolicitud", idtiposolicitud);
            cb.Parameters.AddWithValue("@IdSeveridad", idseveridad);
            SqlServer db = new SqlServer();
            DataTable dt = db.get_tabla(cb);

            foreach (DataRow f in dt.Rows)
            {
                soport = new Soporte();
                soport.IdSoporte = int.Parse(f["IdSoporte"].ToString());
                soport.IdUsuario = int.Parse(f["IdUsuario"].ToString());
                soport.Usuario = f["NombreUsuario"].ToString();
                soport.DescripcionProblema = f["DescripcionProblema"].ToString();
                if (!string.IsNullOrEmpty(f["FechaRegistro"].ToString())) { soport.FechaRegistro = DateTime.Parse(f["FechaRegistro"].ToString()); }
                //soport.imagepath = f["imagepath"].ToString();
                soport.DepartamentId = int.Parse(f["DepartamentId"].ToString());
                soport.Departamento = f["Departamento"].ToString();
                soport.IdEstado = int.Parse(f["IdEstado"].ToString());
                soport.Estado = f["Estado"].ToString();
                soport.IdSeveridad = int.Parse(f["IdSeveridad"].ToString());
                soport.IdTipoSolicitud = int.Parse(f["IdTipoSolicitud"].ToString());
                soport.TipoSolicitud = f["TipoSolicitud"].ToString();
                soport.Severidad = f["Severidad"].ToString();
                soport.UsuarioAsignador = f["UsuarioAsignador"].ToString();
                soport.TecnicoAsignado = f["TecnicoAsignado"].ToString();
                soport.Cerrador = f["Cerrador"].ToString();




                soportlist.Add(soport);
            }



            return soportlist;

        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("DeleteSoporte");
            cmd.Parameters.AddWithValue("@id", id);
            SqlServer db = new SqlServer();
            db.ejecutar_Sp(cmd);
        }

        public static void AsginarTicket(int idticket, int idtecnico, int asignadodor)
        {
            SqlCommand cmd = new SqlCommand("AsingarTicketToTecnico");
            cmd.Parameters.AddWithValue("@idticket", idticket);
            cmd.Parameters.AddWithValue("@idtecnico", idtecnico);
            cmd.Parameters.AddWithValue("@asignadopor", asignadodor);
            SqlServer db = new SqlServer();
            db.ejecutar_Sp(cmd);

        }

        public static void CerrarTicket(int idticket)
        {
            SqlCommand cmd = new SqlCommand("CerrarTciket");
            cmd.Parameters.AddWithValue("@idsoporte", idticket);
            SqlServer db = new SqlServer();
            db.ejecutar_Sp(cmd);
        }
    }
}
