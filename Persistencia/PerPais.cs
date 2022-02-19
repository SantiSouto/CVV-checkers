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
    public class PerPais
    {
        public Pais BuscarPais(string codigopais)
        {
            Pais pais = null;
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_BUSCARPAIS", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", codigopais));

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    pais = new Pais(reader["CODIGOPAIS"].ToString(), reader["NOMBRE"].ToString());
                reader.Close();

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally

            {
                connection.Close();


            }
            if (pais == null)
                throw new Exception("El país que busca no existe en la base de datos.");
            return pais;

        }


        public void RegistrarPais(Pais pais)
        {

            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_AgregarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("NOMBRE", pais.Nombre));

            SqlParameter r = new SqlParameter("@Retorno", SqlDbType.Int);
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int retorno = (int)command.Parameters["@Retorno"].Value;

                if (retorno == -1)
                    throw new Exception("El país que intenta agrear no existe en la base de datos");
                else if (retorno == -2)
                    throw new Exception("Error al registrar país.");

                else if (retorno == 1)
                    throw new Exception("El país fue registrado con éxito.");

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

        public void EditarPais(Pais pais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_ModificarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("NOMBRE", pais.Nombre));


            SqlParameter r = new SqlParameter("@Retorno", SqlDbType.Int);
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int retorno = (int)command.Parameters["@Retorno"].Value;

                if (retorno == -1)
                    throw new Exception("El país que intenta editar no existe.");
                else if (retorno == 1)
                    throw new Exception("El país fue modificado con éxito ");
                else if (retorno == -2)
                    throw new Exception("Error al modificar el país");
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



        public List<Pais> TodosLosPaises()
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_LISTARTODOSLOSPAISES", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<Pais> paises = new List<Pais>();



            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pais pais = new Pais(
                         reader["CODIGOPAIS"].ToString(), reader["NOMBRE"].ToString());
                    paises.Add(pais);

                }
                reader.Close();
                return paises;


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

        public void EliminarPais(string  codpais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_EliminarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", codpais));
           
            SqlParameter r = new SqlParameter("@Retorno", SqlDbType.Int);
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);



            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = (int)command.Parameters["@Retorno"].Value;

                if (retorno == -1)
                    throw new Exception("El país que intenta eliminar no existe");
                else if (retorno == 1)
                    throw new Exception("El país fue eliminado con éxito");
                else if (retorno == -2)
                    throw new Exception("No se puede eliminar el país, posee ciudades con pronósticos asosciados.");
                else if (retorno == -3)
                    throw new Exception("Error al eliminar país.");

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