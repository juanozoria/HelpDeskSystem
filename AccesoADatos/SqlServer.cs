using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AccesoADatos
{
    public class SqlServer : IDisposable
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataAdapter adp;
        private DataTable tabla;

        //al instanciar la clase se introducira el nombre de la cadena conexion a utilizar del web.config
        public SqlServer(string ConexionString)
        {
            conexion = new SqlConnection(ConexionString);
        }
        public SqlServer()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings["HelpDeskDBConnectionString"] != null)
            {
                conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HelpDeskDBConnectionString"].ToString());
            }
            else
            {
                conexion = new SqlConnection("Data Source=dbameta;Initial Catalog=HelpDeskDB;Integrated Security=False;User ID=dba;Password=Admin123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            }
        }

        //ejecuta una consulta string comandtext y devuelve las filas afectadas
        public int ejecutar_comando(string comandText)
        {
            int result;
            conexion.Open();
            comando = new SqlCommand(comandText, conexion);
            result = comando.ExecuteNonQuery();
            conexion.Close();
            return result;
        }

        //ejecuta una consulta sql y regresa con un DataTable;
        public DataTable GetTablaByQuery(SqlCommand cb)
        {
            conexion.Open();
            cb.Connection = conexion;
            adp = new SqlDataAdapter(cb);
            tabla = new DataTable();
            adp.Fill(tabla);
            conexion.Close();

            //si la tabla tiene datos la devuelve, de lo contrario devuelve un new DataTable
            if (tabla.Rows.Count > 0)
            {
                return tabla;
            }
            else
            {
                return new DataTable();
            }
        }

        //Ejecuta un storedProcedure
        public int ejecutar_Sp(SqlCommand cb)
        {
            int result;
            conexion.Open();
            cb.CommandType = CommandType.StoredProcedure;
            cb.Connection = conexion;
            result = cb.ExecuteNonQuery();
            conexion.Close();
            return result;
        }

        //Retorna una tabla, pasando un comando.
        public DataTable get_tabla(SqlCommand cb)
        {
            conexion.Open();
            cb.CommandType = CommandType.StoredProcedure;
            cb.Connection = conexion;
            adp = new SqlDataAdapter(cb);
            tabla = new DataTable();
            adp.Fill(tabla);
            conexion.Close();
            return tabla;
        }

        //Obtiene una fila
        public DataRow get_fila(SqlCommand cb)
        {
            return get_tabla(cb).Rows[0];
        }

        //release resource after conexion not being used anymore.
        public void Dispose()
        {
            if (adp != null)
                this.adp.Dispose();

            if (comando != null)
                this.comando.Dispose();

            if (conexion != null)
                this.conexion.Dispose();

            if (tabla != null)
                this.tabla.Dispose();
        }
    }
}
