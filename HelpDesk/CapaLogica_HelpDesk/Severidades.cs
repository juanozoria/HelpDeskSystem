using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AccesoADatos;

namespace CapaLogica_HelpDesk
{
    public class Severidades
    {
        public int IdSeveridad { get; set; }
        public string Severidad { get; set; }


        public static List<Severidades> ListSeveridad()
        {
            List<Severidades> listseveridad = new List<Severidades>();
            Severidades severidad;
            SqlServer db = new SqlServer();
            SqlCommand cmd = new SqlCommand("GetListSeverida");
            DataTable dt = db.get_tabla(cmd);
            if (dt.Rows.Count == 0)
            {
                throw new Exception("Consulta sin resultado.");
            }
            foreach (DataRow f in dt.Rows)
            {
                severidad = new Severidades();
                severidad.IdSeveridad = int.Parse(f["IdSeveridad"].ToString());
                severidad.Severidad = f["Severidad"].ToString();

                listseveridad.Add(severidad);
            }
            return listseveridad;
        }
    }
}
