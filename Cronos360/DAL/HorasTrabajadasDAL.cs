using Cronos360.DAL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Cronos360.CENT;
using System.Collections.Generic;
using System.Windows;

namespace Cronos360.BLL
{
    public class HorasTrabajadasDAL
    {
        

        private string connectionString = "Data Source=TONYA\\SQLEXPRESS;Initial Catalog=SISDE;Integrated Security=True";

        public List <HorasTrabajadas> RegistrarHsTrabajadas()
        {
            List<HorasTrabajadas> listaHsTrabajadas = new List<HorasTrabajadas>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_horas, id_proyecto, fecha_diaria, horas_trabajadas " +
                        "FROM horas_trabajadas";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaHsTrabajadas.Add(new HorasTrabajadas
                                {
                                    Id_horas = reader.GetInt32(0),
                                    id_proyecto = reader.GetInt32(1),
                                    FechaDiaria = reader.GetDateTime(2),
                                    Horas = reader.GetDecimal(3),
                                    //comentarios = reader.GetString(5),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las horas trabajadas: " + ex.Message);
            }
            return listaHsTrabajadas;
        }

        public void AgregarHoras(HorasTrabajadas horas)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO horas_trabajadas (id_proyecto, fecha_diaria, horas_trabajadas) VALUES (@id_proyecto, @fecha_diaria, @horas_trabajadas)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_proyecto", horas.id_proyecto);
                cmd.Parameters.AddWithValue("@fecha_diaria", horas.FechaDiaria);
                cmd.Parameters.AddWithValue("@horas_trabajadas", horas.Horas);
                

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}