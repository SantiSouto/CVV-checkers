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
            connection.Open();
            SqlCommand command = new SqlCommand("sp_BUSCARPAIS", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", codigopais));


            SqlDataReader reader = command.ExecuteReader();



            Pais pais = null;

            while (reader.Read())
            {
                pais = new Pais(reader["CODIGOPAIS"].ToString(), reader["NOMBRE"].ToString());
            }


            reader.Close();
            connection.Close();

            return pais;

        }


        public int RegistrarPais(Pais pais)
        {

            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_AgregarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("NOMBRE", pais.Nombre));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);
            command.ExecuteNonQuery();

            connection.Close();

            return Convert.ToInt32(r.Value);
        }

        public int EditarPais(Pais pais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_ModificarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("NOMBRE", pais.Nombre));


            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);
            command.ExecuteNonQuery();

            connection.Close();

            return Convert.ToInt32(r.Value);


        }



        public List<Pais> TodosLosPaises()
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_LISTARTODOSLOSPAISES", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            List<Pais> paises = new List<Pais>();
            while (reader.Read())
            {
                Pais pais = new Pais(
                     reader["CODIGOPAIS"].ToString(),reader["NOMBRE"].ToString());
                paises.Add(pais);

            }
            reader.Close();
            connection.Close();
            return paises;

        }

        public int EliminarPais(Pais pais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_EliminarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("NOMBRE", pais.Nombre));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);
            command.ExecuteNonQuery();

            connection.Close();

            return Convert.ToInt32(r.Value);


        }


    }
}