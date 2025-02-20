using Cronos360.BLL;
using Cronos360.CENT;
using Cronos360.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Cronos360.Data
{
    public class ProyectoDAL
    {
        private string connectionString = "Data Source=TONYA\\SQLEXPRESS;Initial Catalog=SISDE;Integrated Security=True";

        public List<Proyectos> ObtenerProyectosActivos()
        {
            List<Proyectos> listaProyectos = new List<Proyectos>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_proyecto, nombre, descripcion, fecha_inicio, fecha_fin, estado FROM proyectos WHERE estado = 'Activo'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaProyectos.Add(new Proyectos
                                {
                                    id_proyecto = reader.GetInt32(0),
                                    nombre = reader.GetString(1),
                                    descripcion = reader.GetString(2),
                                    fecha_inicio = reader.GetDateTime(3),
                                    fecha_fin = reader.GetDateTime(4),
                                    estado = reader.GetString(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los proyectos: " + ex.Message);
            }

            return listaProyectos;

        }

        public int AgregarProyecto(Proyectos proyecto)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Console.WriteLine("INSERT INTO proyectos (nombre, descripcion, fecha_inicio, fecha_fin) OUTPUT INSERTED.id_proyecto VALUES (" + proyecto.nombre + ", " + proyecto.descripcion + ", "+ proyecto.fecha_inicio + ", "+ proyecto.fecha_fin+")");

                string query = "INSERT INTO proyectos (nombre, descripcion, fecha_inicio, fecha_fin) OUTPUT INSERTED.id_proyecto VALUES (@nombre, @descripcion, @fecha_inicio, @fecha_fin)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", proyecto.nombre);
                cmd.Parameters.AddWithValue("@descripcion", proyecto.descripcion);
                cmd.Parameters.AddWithValue("@fecha_inicio", proyecto.fecha_inicio);
                cmd.Parameters.AddWithValue("@fecha_fin", proyecto.fecha_fin);


                conn.Open();
               // int id_proyecto = (int)cmd.ExecuteScalar(); // Obtiene el ID insertado
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int id_proyecto = Convert.ToInt32(result);
                    return id_proyecto;
                }
                else
                {
                    throw new Exception("Error al insertar el proyecto: No se obtuvo un ID.");
                }

                

            }

        }


    }
}
