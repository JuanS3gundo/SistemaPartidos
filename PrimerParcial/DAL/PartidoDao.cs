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
    public class PartidoDao
    {
        public List<Partido> GetPartidos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ParcialDataSet"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    List<Partido> partidos = new List<Partido>();   
                    using(SqlCommand command = new SqlCommand("SELECT * FROM Partido",connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Partido partido = new Partido();
                                partido.IdPartido = Convert.ToInt32(reader["IdPartido"]);
                                partido.IdDeporte = Convert.ToInt32(reader["IdDeporte"]);
                                partido.EquipoLocal = Convert.ToString(reader["EquipoLocal"]);
                                partido.EquipoVisitante = Convert.ToString(reader["EquipoVisitante"]);
                                partido.MarcadorLocal = Convert.ToInt32(reader["MarcadorLocal"]);   
                                partido.MarcadorVisitante = Convert.ToInt32(reader["MarcadorVisitante"]);   
                                partidos.Add(partido);
                            }
                            return partidos;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);    
            }
            finally
            { 
                connection.Close(); 
            }    
        }
        public void CargarPartidos(Partido AgregoPartido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ParcialDataSet"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using(connection)
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Partido (IdDeporte, EquipoLocal, EquipoVisitante, FechaRegistro, FechaPartido ) VALUES ( @idDeporte, @equipoLocal, @equipoVisitante, @fechaRegistro, @fechaPartido)", connection))
                    {
                        command.Parameters.AddWithValue("@idDeporte", AgregoPartido.IdDeporte);
                        command.Parameters.AddWithValue("@equipoLocal", AgregoPartido.EquipoLocal);
                        command.Parameters.AddWithValue("@equipoVisitante", AgregoPartido.EquipoVisitante);
                        command.Parameters.AddWithValue("@fechaRegistro", AgregoPartido.FechaRegistro);
                        command.Parameters.AddWithValue("@fechaPartido", AgregoPartido.FechaPartido);
                        command.ExecuteNonQuery();  
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);   
            }
            finally
            {
                connection.Close(); 
            }
        }
        public void EliminarPartidos(int idPartido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ParcialDataSet"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using(connection)
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("DELETE Partido WHERE IdPartido = @idPartido", connection))
                    {
                        command.Parameters.AddWithValue ("@idPartido", idPartido);
                        command.ExecuteNonQuery (); 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);   
            }
            finally
            {
                connection.Close ();
            }
        }
        public void EditarPartidos(int marcadorLocal, int marcadorVisitante, int idPartido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ParcialDataSet"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                using (SqlCommand commnad = new SqlCommand("UPDATE Partido SET MarcadorLocal = @marcadorLocal , MarcadorVisitante = @marcadorVisitante WHERE IdPartido = @idPartido", connection))
                {
                    commnad.Parameters.AddWithValue("@marcadorLocal", marcadorLocal);
                    commnad.Parameters.AddWithValue("@marcadorVisitante", marcadorVisitante);
                    commnad.Parameters.AddWithValue("@idPartido", idPartido);
                }

            }catch(Exception ex)
            {
                throw new Exception (ex.Message);   
            }
            finally
            {
                connection.Close ();
            }
        }
    }
}
