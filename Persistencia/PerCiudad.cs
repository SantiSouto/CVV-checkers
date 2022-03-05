using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;



namespace Persistencia
{
    public class PerCiudad
    {


        PerPais perpais = new PerPais();


        public Ciudad Buscar(string codigociudad,string codigopais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_BUSCARCIUDAD", connection);
            command.Parameters.Add(new SqlParameter("CODIGOCIUDAD", codigociudad));
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", codigopais));

            command.CommandType = System.Data.CommandType.StoredProcedure;
        


            Ciudad ciudad = null;
            Pais pais = null;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    pais = perpais.BuscarPais(reader["CODIGOPAIS"].ToString());
                    ciudad = new Ciudad(
                    reader["CODIGOCIUDAD"].ToString(), pais, reader["NOMBRE"].ToString());
                    reader.Close();
                }
                 
                    if (ciudad == null)
                {
                    throw new Exception("La ciudad que busca no existe en la base de datos.");
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

          
           
            return ciudad;
        }

        public void RegistrarCiudad(Ciudad ciudad)
        {


            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_IngresarCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOCIUDAD", ciudad.Codigociudad));
            command.Parameters.Add(new SqlParameter("NOMBRE", ciudad.NombreCiudad));
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", ciudad.Pais.CodigoPais));

            SqlParameter r = new SqlParameter("@Retorno", SqlDbType.Int);
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);


            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = (int)command.Parameters["@Retorno"].Value;

                if (retorno == -1)
                    throw new Exception("No existe la país en la Base de Datos.");
                else if (retorno == -2)
                    throw new Exception("La ciudad ya se encuentra registrada en la base de datos.");
                else if (retorno == -3)
                    throw new Exception("Error al registrar la ciudad en la base de datos.");

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


        public void EditarCiudad(Ciudad ciudad)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_ModificarCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOCIUDAD", ciudad.Codigociudad));
            command.Parameters.Add(new SqlParameter("NOMBRE", ciudad.NombreCiudad));
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", ciudad.Pais.CodigoPais));
            SqlParameter r = new SqlParameter("@Retorno", SqlDbType.Int);
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int retorno = (int)command.Parameters["@Retorno"].Value;


                if (retorno == -1)
                    throw new Exception("La ciudad que desea editar no existe. ");
              
                else if (retorno == -2)
                    throw new Exception("Error al editar la ciudad.");


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

        public void EliminarCiudad(Ciudad ciudad)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_EliminarCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOCIUDAD", ciudad.Codigociudad));
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", ciudad.Pais.CodigoPais));

            SqlParameter r = new SqlParameter("@Retorno", SqlDbType.Int);
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);
 

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int retorno = (int)command.Parameters["@Retorno"].Value;


                if (retorno == -1)
                    throw new Exception("La ciudad que intenta eliminar no existe.");
            
                else if (retorno == -2)
                    throw new Exception("Error al eliminar la ciudad");
            
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

        public List<Ciudad> CiudadPorPais(Pais pais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_CIUDADPORPAIS", connection);
            command.Parameters.Add(new SqlParameter("CODIGOPais", pais.CodigoPais));

            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<Ciudad> ciudades = new List<Ciudad>();
            

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pais paisbuscado = perpais.BuscarPais(reader["CODIGOPAIS"].ToString());

                    Ciudad ciudad = new Ciudad(reader["CODIGOCIUDAD"].ToString(), paisbuscado, reader["NOMBRE"].ToString());


                    ciudades.Add(ciudad);

                }

                reader.Close();
                return ciudades;

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

    }



}


