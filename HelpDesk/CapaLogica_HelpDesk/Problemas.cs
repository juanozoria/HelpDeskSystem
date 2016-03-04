using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaLogica_HelpDesk
{
    public class Problemas
    {
        public int IdProblema { get; set; }
        public string Descripcion { get; set; }

        public static List<Problemas> ListProblems()
        {
            List<Problemas> listproblems = new List<Problemas>();
            Problemas problem;
            SqlServer db = new SqlServer();
            SqlCommand Comando = new SqlCommand("GetProblems");
            DataTable dt = db.get_tabla(Comando);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Consulta sin resultados");
            }

            foreach (DataRow f in dt.Rows)
            {
                problem = new Problemas();
                problem.IdProblema = int.Parse(f["IdProblema"].ToString());
                problem.Descripcion = f["Descripcion"].ToString();

                listproblems.Add(problem);
            }

            return listproblems;

        }

    }
}
