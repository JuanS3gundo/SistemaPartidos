using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DeporteDao
    {
        public List<Deporte> GetDeportes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ParcialDataSet"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    List<Deporte> deportes = new List<Deporte>();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Deportes", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Deporte deporte = new Deporte();
                                deporte.TipoDeporte = Convert.ToString(reader["Tipo"]);
                                deporte.IdDeporte = Convert.ToInt32(reader["IdDeporte"]);
                                deportes.Add(deporte);  
                            }
                            return deportes;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                connection.Close(); 
            }
        }
    }
}
