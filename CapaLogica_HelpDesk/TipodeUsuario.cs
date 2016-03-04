using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AccesoADatos;



namespace CapaLogica_HelpDesk
{
    public class TipodeUsuario
    {
        public int IdTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }

        public static List<TipodeUsuario> ListTipoUsuarios()
        {
            List<TipodeUsuario> listtipousers = new List<TipodeUsuario>();
            TipodeUsuario tipuser;
            SqlServer db = new SqlServer();
            SqlCommand cmd = new SqlCommand("GetListTipoUsers");
            DataTable dt = db.get_tabla(cmd);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Consulta sin resultado.");
            }
            foreach (DataRow f in dt.Rows)
            {
                tipuser = new TipodeUsuario();
                tipuser.IdTipoUsuario = int.Parse(f["IdTipoUsuario"].ToString());
                tipuser.TipoUsuario = f["TipoUsuario"].ToString();

                listtipousers.Add(tipuser);
            }
            return listtipousers;
        }


    }
}
