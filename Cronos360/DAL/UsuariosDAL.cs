using Cronos360.CENT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos360.DAL
{
    public class UsuariosDAL
    {
        private string connectionString = "Data Source=TONYA\\SQLEXPRESS;Initial Catalog=SISDE;Integrated Security=True";
        public int ObtenerRolUsuario(string usuario, string contraseña)
        {
            int idRol = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT r.idRol FROM empleados e " +
                               "INNER JOIN Roles r ON e.idRol = r.idRol " +
                               "WHERE e.user_identif = @Usuario AND e.contraseña = @Contraseña";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if(result != null)
                    {
                        idRol = Convert.ToInt32(result);
                    }

                }
            }

            return idRol;
        }
    }
}
