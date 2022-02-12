using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;



namespace Persistencia
{
    public class PerCiudad
    {
        public Ciudad Buscar(string codigociudad)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_BUSCARCIUDAD", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOCIUDAD ", codigociudad));

            SqlDataReader reader = command.ExecuteReader();

            Ciudad ciudad = null;

            PerPais perpais = new PerPais();

            while (reader.Read())
            {
                Pais pais = perpais.BuscarPais(reader["CODIGOPAIS"].ToString());
                ciudad = new Ciudad(
                reader["CODIGOCIUDAD"].ToString(), pais, reader["NOMBRE"].ToString());
            }

            reader.Close();
            connection.Close();

            return ciudad;
        }


        public int RegistrarCiudad(Ciudad ciudad, Pais pais)
        {

            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_IngresarCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOCIUDAD", ciudad.Codigociudad));
            command.Parameters.Add(new SqlParameter("NOMBRE", ciudad.NombreCiudad));
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", pais.CodigoPais));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);
            command.ExecuteNonQuery();

            connection.Close();

            return Convert.ToInt32(r.Value);
        }


        public int EditarCiudad(Ciudad ciudad,Pais pais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_ModificarCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOCIUDAD", ciudad.Codigociudad)); 
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("NOMBRE", ciudad.NombreCiudad));


            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);
            command.ExecuteNonQuery();

            connection.Close();

            return Convert.ToInt32(r.Value);


        }

        public int EliminarCiudad(Ciudad ciudad,Pais pais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_EliminarCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CODIGOCIUDAD", ciudad.Codigociudad));
            command.Parameters.Add(new SqlParameter("CODIGOPAIS", ciudad.NombreCiudad));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);
            command.ExecuteNonQuery();

            connection.Close();

            return Convert.ToInt32(r.Value);


        }

        public List<Ciudad> TodosLasCiudades()
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_ListarCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;


            PerPais perpais = new PerPais();

            SqlDataReader reader = command.ExecuteReader();

            List<Ciudad> ciudades = new List<Ciudad>();

       
            while (reader.Read())
            {
                Pais paisbuscado = perpais.BuscarPais(reader["CODIGOPAIS"].ToString());

               Ciudad ciudad = new Ciudad(  reader["CODIGOCIUDAD"].ToString(),paisbuscado, reader["NOMBRE"].ToString());

               ciudad.Add(ciudades);

            }
            reader.Close();
            connection.Close();
            return ciudades;

        }



    }
}
