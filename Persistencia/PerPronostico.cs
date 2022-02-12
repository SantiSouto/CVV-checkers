using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Persistencia
{

   public class PerPronostico
    {


        public List<Pronostico> PronosticoDiario()
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            connection.Open();
            SqlCommand command = new SqlCommand("sp_ListarPronosticosDehoy", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;


            PerCiudad perciudad = new PerCiudad();
            PerUsuario perusuario = new PerUsuario();


            SqlDataReader reader = command.ExecuteReader();
            List<Pronostico> pronosticos = new List<Pronostico>();


             while (reader.Read())

             {


                Ciudad ciudadbuscada = perciudad.Buscar(reader["CODIGOCIUDAD"].ToString());
                Usuario usuariobuscado = perusuario.Buscar(reader["NOMBRELOGUEO"].ToString());



                Pronostico pronostico = new Pronostico(Convert.ToInt32(reader["CODIGOINTERNO"].ToString()), ciudadbuscada, usuariobuscado,
                Convert.ToInt32(reader["TMAXIMA"].ToString()), Convert.ToInt32(reader["TMINIMA"].ToString()), Convert.ToDateTime(reader["FECHAHORA"].ToString()), Convert.ToInt32(reader["VELOCIDADVIENTO"].ToString()), reader["TIPODECIELO"].ToString(), Convert.ToInt32(reader["PROBLLUVIA"].ToString()), Convert.ToInt32(reader["PROBTORMENTA"].ToString()));



                pronosticos.Add(pronostico);

             }

            reader.Close();
                connection.Close();

             return pronosticos;
        }

        public int RegistrarPronostico(Pronostico pronostico,Usuario usuario,Ciudad ciudad)

        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_RegistrarPronostico", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("NOMBRELOGUEO", usuario.NombreLogueo));
            command.Parameters.Add(new SqlParameter("CIUDAD", ciudad.Codigociudad));
            command.Parameters.Add(new SqlParameter("TMAXIMA", pronostico.Tmaxima));
            command.Parameters.Add(new SqlParameter("Tminima", pronostico.Tminima));
            command.Parameters.Add(new SqlParameter("VELOCIDADVIENTO", pronostico.VelocidadViento));
            command.Parameters.Add(new SqlParameter("TIPODECIELO", pronostico.TipoDeCielo));
            command.Parameters.Add(new SqlParameter("PROBLLUVIA", pronostico.ProbabilidadLluvia));
            command.Parameters.Add(new SqlParameter("PROBTORMENTA", pronostico.Probabilidadtormenta));


            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);
            command.ExecuteNonQuery();

            connection.Close();

            return Convert.ToInt32(r.Value);

        }


        public List<Pronostico> PronosticoPorCiudad()

        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);


            connection.Open();
            SqlCommand command = new SqlCommand("sp_PRONOSTICOPORCIUDAD", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            PerCiudad perciudad = new PerCiudad();
            PerUsuario perusuario = new PerUsuario();

            SqlDataReader reader = command.ExecuteReader();
            List<Pronostico> pronosticos = new List<Pronostico>();


            while (reader.Read())

            {
                 Ciudad ciudadbuscada = perciudad.Buscar(reader["CODIGOCIUDAD"].ToString());
                Usuario usuariobuscado = perusuario.Buscar(reader["NOMBRELOGUEO"].ToString());

                Pronostico pronostico = new Pronostico(Convert.ToInt32(reader["CODIGOINTERNO"].ToString()), ciudadbuscada, usuariobuscado,
                Convert.ToInt32(reader["TMAXIMA"].ToString()), Convert.ToInt32(reader["TMINIMA"].ToString()), Convert.ToDateTime(reader["FECHAHORA"].ToString()), Convert.ToInt32(reader["VELOCIDADVIENTO"].ToString()), reader["TIPODECIELO"].ToString(), Convert.ToInt32(reader["PROBLLUVIA"].ToString()), Convert.ToInt32(reader["PROBTORMENTA"].ToString()));



                pronosticos.Add(pronostico);

            }
            reader.Close();
            connection.Close();

            return pronosticos;
        }

        public List<Pronostico> PronosticoPorFecha()

        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);


            connection.Open();
            SqlCommand command = new SqlCommand("sp_PRONOSTICOPORFECHA", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            PerCiudad perciudad = new PerCiudad();
            PerUsuario perusuario = new PerUsuario();

            SqlDataReader reader = command.ExecuteReader();
            List<Pronostico> pronosticos = new List<Pronostico>();


            while (reader.Read())

            {
                Ciudad ciudadbuscada = perciudad.Buscar(reader["CODIGOCIUDAD"].ToString());
                Usuario usuariobuscado = perusuario.Buscar(reader["NOMBRELOGUEO"].ToString());

                Pronostico pronostico = new Pronostico(Convert.ToInt32(reader["CODIGOINTERNO"].ToString()), ciudadbuscada, usuariobuscado,
                Convert.ToInt32(reader["TMAXIMA"].ToString()), Convert.ToInt32(reader["TMINIMA"].ToString()), Convert.ToDateTime(reader["FECHAHORA"].ToString()), Convert.ToInt32(reader["VELOCIDADVIENTO"].ToString()), reader["TIPODECIELO"].ToString(), Convert.ToInt32(reader["PROBLLUVIA"].ToString()), Convert.ToInt32(reader["PROBTORMENTA"].ToString()));



                pronosticos.Add(pronostico);

            }
            reader.Close();
            connection.Close();

            return pronosticos;
        }


    }
}
