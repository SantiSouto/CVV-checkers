using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;



namespace Persistencia
{
    public class PerPais
    {
        public Pais BuscarPais(string codigopais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);


            SqlCommand command = new SqlCommand("sp_BUSCARPAIS", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", codigopais));
            Pais pais = null;


            try
            {
                connection.Open();



                SqlDataReader reader = command.ExecuteReader();



               
                while (reader.Read())
                {
                    pais = new Pais(reader["CODIGOPAIS"].ToString(), reader["NOMBRE"].ToString());

                }

                reader.Close();

            }

            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            finally { 
            connection.Close();
              

            }
            return pais;

        }


        public void RegistrarPais(Pais pais)
        {

            SqlConnection connection = new SqlConnection(Conexion.connectionString);
           
            SqlCommand command = new SqlCommand("sp_AgregarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("NOMBRE", pais.Nombre));

            SqlParameter r = new SqlParameter();
           
            command.Parameters.Add(r);
            



            try 
            {
                connection.Open();
                command.ExecuteNonQuery();
                int retorno = (int)command.Parameters[Convert.ToInt32(r.Value)].Value;

                if (retorno == -1)
                    throw new Exception("YA EXISTE ESE PAIS EN LA BASE DE DATOS");
                else if (retorno == -2)
                    throw new Exception("ERROR AL MODIFICAR");
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


            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);
   

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int retorno = (int)command.Parameters[Convert.ToInt32(r.Value)].Value;

                if (retorno == -1)
                    throw new Exception("NO EXISTE EL PAIS");
                else if (retorno == -2)
                    throw new Exception("NO SE PUEDE MODIFICAR, TIENE PRONOSTICOS ASOCIADOS");
                else if (retorno == -3)
                    throw new Exception("ERROR AL MODIFICAR");
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

        public void EliminarPais(Pais pais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            
            SqlCommand command = new SqlCommand("sp_EliminarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("NOMBRE", pais.Nombre));

            SqlParameter r = new SqlParameter();
            
            command.Parameters.Add(r);
           


            try
            { 
                connection.Open(); 
                command.ExecuteNonQuery();


                int retorno = (int)command.Parameters[Convert.ToInt32(r.Value)].Value;

                if (retorno == -1)
                    throw new Exception("NO EXISTE EL PAIS");
                else if (retorno == -2)
                    throw new Exception("NO SE PUEDE ELIMINAR EL PAIS, TIENE CIUDADES CON PRONOSTICOS ASOCIADOS");
                else if (retorno == -3)
                    throw new Exception("ERROR");

            } catch (Exception ex) 
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