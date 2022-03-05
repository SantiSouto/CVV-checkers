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

    public class PerPronostico
    {

        PerCiudad perciudad = new PerCiudad();
        PerUsuario perusuario = new PerUsuario();

        public List<Pronostico> PronosticoDiario()
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);


            SqlCommand command = new SqlCommand("sp_ListarPronosticosDehoy", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            List<Pronostico> pronosticos = new List<Pronostico>();

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())

                    {

                        Ciudad ciudadbuscada = perciudad.Buscar(reader["CODIGOCIUDAD"].ToString(),reader["CODIGOPAIS"].ToString());
                        Usuario usuariobuscado = perusuario.Buscar(reader["NOMBRELOGUEO"].ToString());
                        Pronostico pronostico = new Pronostico(Convert.ToInt32(reader["CODIGOINTERNO"].ToString()), ciudadbuscada, usuariobuscado,
                        Convert.ToInt32(reader["TMAXIMA"].ToString()), Convert.ToInt32(reader["TMINIMA"].ToString()), Convert.ToDateTime(reader["FECHAHORA"].ToString()), Convert.ToInt32(reader["VELOCIDADVIENTO"].ToString()), reader["TIPODECIELO"].ToString(), Convert.ToInt32(reader["PROBLLUVIA"].ToString()), Convert.ToInt32(reader["PROBTORMENTA"].ToString()));
                        pronosticos.Add(pronostico);

                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }

            finally
            {
                connection.Close();
            }


            return pronosticos;
        }


        public void RegistrarPronostico(Pronostico pronostico)

        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_RegistrarPronostico", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("NOMBRELOGUEO",pronostico.Usuario.NombreLogueo));
            command.Parameters.Add(new SqlParameter("CIUDAD", pronostico.Ciudad.Codigociudad));
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", pronostico.Ciudad.Pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("TMAXIMA", pronostico.Tmaxima));
            command.Parameters.Add(new SqlParameter("Tminima", pronostico.Tminima));
            command.Parameters.Add(new SqlParameter("FECHAHORA", pronostico.FechaHora));
            command.Parameters.Add(new SqlParameter("VELOCIDADVIENTO", pronostico.VelocidadViento));
            command.Parameters.Add(new SqlParameter("TIPODECIELO", pronostico.TipoDeCielo));
            command.Parameters.Add(new SqlParameter("PROBLLUVIA", pronostico.ProbabilidadLluvia));
            command.Parameters.Add(new SqlParameter("PROBTORMENTA", pronostico.Probabilidadtormenta));


            SqlParameter r = new SqlParameter("@Retorno", SqlDbType.Int);
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int retorno = (int)command.Parameters["@Retorno"].Value;

                if (retorno == -1)
                    throw new Exception("El usuario ingresado no existe o no está registrado.");

                if (retorno == -2)
                    throw new Exception("La ciudad no existe o no está registrada.");

                if (retorno == -3)
                    throw new Exception("Ya existe un pronóstico para esa ciudad, día y hora.");
                if (retorno == -4)
                    throw new Exception("Error con la base de datos!!");

            
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


        public List<Pronostico> PronosticoPorCiudad(Ciudad ciudad)

        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_PRONOSTICOPORCIUDAD", connection);
            command.Parameters.Add(new SqlParameter("CODIGOCIUDAD", ciudad.Codigociudad));
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", ciudad.Pais.CodigoPais));
            command.CommandType = System.Data.CommandType.StoredProcedure;

            List<Pronostico> pronosticos = new List<Pronostico>();

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {


                    while (reader.Read())

                    {
                        Ciudad ciudadbuscada = perciudad.Buscar(reader["CODIGOCIUDAD"].ToString(), reader["CODIGOPAIS"].ToString());
                        Usuario usuariobuscado = perusuario.Buscar(reader["NOMBRELOGUEO"].ToString());


                        Pronostico pronostico = new Pronostico(Convert.ToInt32(reader["CODIGOINTERNO"].ToString()), ciudadbuscada, usuariobuscado,
                        Convert.ToInt32(reader["TMAXIMA"].ToString()), Convert.ToInt32(reader["TMINIMA"].ToString()), Convert.ToDateTime(reader["FECHAHORA"].ToString()), Convert.ToInt32(reader["VELOCIDADVIENTO"].ToString()), reader["TIPODECIELO"].ToString(), Convert.ToInt32(reader["PROBLLUVIA"].ToString()), Convert.ToInt32(reader["PROBTORMENTA"].ToString()));
                        pronosticos.Add(pronostico);

                    }

                }
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
            return pronosticos;
        }

        public List<Pronostico> PronosticoPorFecha(DateTime pronosticoporfecha)

        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);


            
            SqlCommand command = new SqlCommand("sp_PRONOSTICOPORFECHA", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("FECHAHORA",pronosticoporfecha));



            List<Pronostico> pronosticos = new List<Pronostico>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {

                    while (reader.Read())

                    {
                        Ciudad ciudadbuscada = perciudad.Buscar(reader["CODIGOCIUDAD"].ToString(), reader["CODIGOPAIS"].ToString());
                        Usuario usuariobuscado = perusuario.Buscar(reader["NOMBRELOGUEO"].ToString());


                      Pronostico pronostico = new Pronostico(Convert.ToInt32(reader["CODIGOINTERNO"].ToString()), ciudadbuscada, usuariobuscado,
                        Convert.ToInt32(reader["TMAXIMA"].ToString()), Convert.ToInt32(reader["TMINIMA"].ToString()), Convert.ToDateTime(reader["FECHAHORA"].ToString()), Convert.ToInt32(reader["VELOCIDADVIENTO"].ToString()), reader["TIPODECIELO"].ToString(), Convert.ToInt32(reader["PROBLLUVIA"].ToString()), Convert.ToInt32(reader["PROBTORMENTA"].ToString()));



                        pronosticos.Add(pronostico);

                    }
                }
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
            return pronosticos;
        }


    }
}
