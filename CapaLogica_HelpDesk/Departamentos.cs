using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoADatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaLogica_HelpDesk
{
    public class Departamentos
    {
        public int IdDeparment { get; set; }
        public string Departamento { get; set; }

        public static List<Departamentos> ListDeparments()
        {
            List<Departamentos> listdeparment = new List<Departamentos>();
            Departamentos deparment;
            SqlServer db = new SqlServer();
            SqlCommand Comando = new SqlCommand("GetDeparments");
            DataTable dt = db.get_tabla(Comando);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Consulta no sin resultados");
            }

            foreach (DataRow f in dt.Rows)
            {
                deparment = new Departamentos();
                deparment.IdDeparment = int.Parse(f["IdDepartment"].ToString());
                deparment.Departamento = f["Departamento"].ToString();

                listdeparment.Add(deparment);
            }

            return listdeparment;

        }

    }
}
