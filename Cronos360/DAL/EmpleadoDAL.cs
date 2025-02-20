using Cronos360.CENT;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos360.DAL
{
    internal class EmpleadoDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static void InsertHoras(string nombre, int horas)
        {
            using (SqlConnection conn = new SqlConnection("DefaultConnection"))
            {
                string query = "INSERT INTO control_horas (Nombre, Horas) VALUES (@Nombre, @Horas)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Horas", horas);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void InsertarRegistro(Registro registro)
        {
            var empleadoDAL = new EmpleadoDAL(); // Instanciar la clase DAL
            empleadoDAL.InsertarRegistro(registro); // Llamar al método en DAL
        }

        public List<Empleados> ObtenerEmpleadosActivos()
        {
            List<Empleados> empleados = new List<Empleados>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_empleado, nombre, apellido FROM empleados"; // Ajusta según tu tabla

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Empleados empleado = new Empleados
                                {
                                    idEmpleado = Convert.ToInt32(reader["IdEmpleado"]),
                                    nombre = reader["Nombre"].ToString()
                                };

                                empleados.Add(empleado);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener empleados: " + ex.Message);
                // Puedes manejar el error de otra forma, como lanzarlo o registrarlo
            }

            return empleados;
        }

    }
}
