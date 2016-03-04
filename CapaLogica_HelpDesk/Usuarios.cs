using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using AccesoADatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaLogica_HelpDesk
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "Nombre de usuario no puede estar en blanco", AllowEmptyStrings = false)]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Primer Nombre no puede estar en blanco", AllowEmptyStrings = false)]
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage = "Contraseña no puede estar en blanco", AllowEmptyStrings = false)]
        public string Contrasena { get; set; }
        public string Email { get; set; }
         [Required(ErrorMessage = "Debe seleccionar un departamento", AllowEmptyStrings = false)]
        public int DeparmentId { get; set; }

         public static List<Usuarios> ListUsuarios()
        {
            List<Usuarios> listusers = new List<Usuarios>();
            Usuarios user;
            SqlServer db = new SqlServer();
            SqlCommand Comando = new SqlCommand("GetUsuarios");
            DataTable dt = db.get_tabla(Comando);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Consulta sin resultados");
            }

            foreach (DataRow f in dt.Rows)
            {
                user = new Usuarios();
                user.IdUsuario = int.Parse(f["IdUsuario"].ToString());
                user.NombreUsuario = f["NombreUsuario"].ToString();
                user.PrimerNombre = f["PrimerNombre"].ToString();
                user.Email = f["Email"].ToString();
                user.DeparmentId = int.Parse(f["DepartamentId"].ToString());

                listusers.Add(user);
            }
            return listusers;

        }

        public void InsertUsuario()
        {
            SqlCommand cmd = new SqlCommand("InsertUsuario");
            cmd.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
            cmd.Parameters.AddWithValue("@IdTipoUsuario", IdTipoUsuario);
            cmd.Parameters.AddWithValue("@PrimerNombre", PrimerNombre);
            cmd.Parameters.AddWithValue("@SegundoNombre", SegundoNombre);
            cmd.Parameters.AddWithValue("@Email",Email);
            cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
            cmd.Parameters.AddWithValue("@DepartmentId", DeparmentId);

            SqlParameter OutputParam = new SqlParameter();
            OutputParam.ParameterName = "@NewId";
            OutputParam.SqlDbType = SqlDbType.Int;
            OutputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(OutputParam);
            SqlServer db = new SqlServer();
            db.ejecutar_Sp(cmd);

            this.IdUsuario = (int)OutputParam.Value;
        }

        public void UpdateUsuario()
        {
            SqlCommand cmd = new SqlCommand("UpdateUsuario");
            cmd.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
            cmd.Parameters.AddWithValue("@PrimerNombre", PrimerNombre);
            cmd.Parameters.AddWithValue("@SegundoNombre", SegundoNombre);
            cmd.Parameters.AddWithValue("@DepartmentId", DeparmentId);

            SqlServer db = new SqlServer();
            db.ejecutar_Sp(cmd);
        }

        public void Login(string username, string pass)
        {
            SqlServer db = new SqlServer();
            SqlCommand cmd = new SqlCommand("LoginUser");
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pass", pass);
            db.ejecutar_Sp(cmd);


        }


    }
}
