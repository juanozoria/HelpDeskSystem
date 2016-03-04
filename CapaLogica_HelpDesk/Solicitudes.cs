using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaLogica_HelpDesk
{
    public class Solicitudes
    {
        public int IdSolicitud { get; set; }
        public string TipoSolicitud { get; set; }

        public static List<Solicitudes> TipoSolicitudes()
        {
            List<Solicitudes> listtiposolicitud = new List<Solicitudes>();
            Solicitudes solicitud;
            SqlServer db = new SqlServer();
            SqlCommand Comando = new SqlCommand("GetSolicitudes");
            DataTable dt = db.get_tabla(Comando);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Consulta no sin resultados");
            }

            foreach (DataRow f in dt.Rows)
            {
                solicitud = new Solicitudes();
                solicitud.IdSolicitud = int.Parse(f["IdSolicitud"].ToString());
                solicitud.TipoSolicitud = f["TipoSolicitud"].ToString();

                listtiposolicitud.Add(solicitud);
            }

            return listtiposolicitud;

        }
    }
}
