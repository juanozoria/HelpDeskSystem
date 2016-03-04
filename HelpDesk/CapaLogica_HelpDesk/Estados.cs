using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AccesoADatos;

namespace CapaLogica_HelpDesk
{
    public class Estados
    {
        public int IdEstado { get; set; }
        public string Estado { get; set; }

        public static List<Estados> ListEstados()
        {
            List<Estados> listestados = new List<Estados>();
            Estados estado;
            SqlServer db = new SqlServer();
            SqlCommand cmd = new SqlCommand("GetListEstados");
            DataTable dt = db.get_tabla(cmd);
            if (dt.Rows.Count == 0)
            {
                throw new Exception("Consulta sin resultados");
            }
            foreach (DataRow f in dt.Rows)
            {
                estado = new Estados();
                estado.IdEstado = int.Parse(f["IdEstado"].ToString());
                estado.Estado = f["Estado"].ToString();

                listestados.Add(estado);
            }
            return listestados;
        }
    }
}
