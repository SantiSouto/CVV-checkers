using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using System.Data;


namespace Persistencia
{
    public class PerUsuario
    {

        public Usuario IdentificarUsuario(string nombrelogueo, string contrasenia)
        {
            Usuario usuario = null;

            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_IdentificarUsuario", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("NOMBRELOGUEO ", nombrelogueo));
            command.Parameters.Add(new SqlParameter("CONTRASENIA ", contrasenia));



            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                


                if (reader.Read())
                    usuario = new Usuario(
                 reader["NOMBRELOGUEO"].ToString(),  reader["NOMBRE"].ToString(), reader["APELLIDO"].ToString(), reader["CONTRASENIA"].ToString());


                reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR:" + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return usuario;
        }




        public Usuario Buscar(string nombrelogueo)
        {
            Usuario usuario = null;

            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_BuscarUsuario", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("NOMBRELOGUEO ", nombrelogueo));


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
               

                if (reader.Read())
                    usuario = new Usuario(
                 reader["NOMBRELOGUEO"].ToString(), reader["NOMBRE"].ToString(), reader["APELLIDO"].ToString(), reader["CONTRASENIA"].ToString());


                reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR:" + ex.Message);
            }
            finally
            {
                connection.Close();
        
            }
            if (usuario == null)
                throw new Exception("El usuario de logueo que busca no existe.");
            return usuario;
        }






        public void RegistrarUsuario(Usuario usuario)

        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_IngresarUsuario", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("NOMBRELOGUEO", usuario.NombreLogueo));
            command.Parameters.Add(new SqlParameter("NOMBRE", usuario.Nombre));
            command.Parameters.Add(new SqlParameter("APELLIDO", usuario.Apellido));
            command.Parameters.Add(new SqlParameter("CONTRASENIA", usuario.Contrasenia));
            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);


            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = (int)command.Parameters[Convert.ToInt32(r.Value)].Value;


                if (retorno == -1)
                    throw new Exception("YA EXISTE ESE USUARIO");
                else if (retorno == -2)
                    throw new Exception("ERROR AL REGISTRAR EL USUARIO");

            }
            catch (Exception ex)
            {
                throw new Exception ("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        public void EditarUsuario(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_ModificarUsuario", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("NOMBRELOGUEO", usuario.NombreLogueo));
            command.Parameters.Add(new SqlParameter("CONTRASENIA", usuario.Contrasenia));
            command.Parameters.Add(new SqlParameter("NOMBRE", usuario.Nombre));
            command.Parameters.Add(new SqlParameter("APELLIDO", usuario.Apellido));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);





            try
            {
                connection.Open();
                command.ExecuteNonQuery();



                int retorno = (int)command.Parameters[Convert.ToInt32(r.Value)].Value;

                if (retorno == -1)
                    throw new Exception("NO EXISTE ESE USUARIO");
                else if (retorno == -2)
                    throw new Exception("ERROR AL MODIFICAR EL USUARIO");


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

        public void EliminarUsuario(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_EliminarUsuario", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("NOMBRELOGUEO", usuario.NombreLogueo));
            command.Parameters.Add(new SqlParameter("CONTRASENIA", usuario.Contrasenia));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);
            command.ExecuteNonQuery();




            try
            {
                connection.Open();
                command.ExecuteNonQuery();



                int retorno = (int)command.Parameters[Convert.ToInt32(r.Value)].Value;

                if (retorno == -1)
                    throw new Exception("NO EXISTE EL USUARIO");
                else if (retorno == -2)
                    throw new Exception("NO SE PUEDE ELIMINAR EL USUARIO, TIENE PRONOSTICOS ASOCIADOS");
                else if (retorno == -3)
                    throw new Exception("ERROR");


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }


        }

        public List<Usuario> TodosLosUsuarios()
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_USUARIOSTODOS", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;


            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario(
                     reader["NOMBRELOGUEO"].ToString(), (reader["CONTRASENIA"].ToString()), reader["NOMBRE"].ToString(), reader["APELLIDO"].ToString());
                        usuarios.Add(usuario);
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

            return usuarios;


        }
    }
}

