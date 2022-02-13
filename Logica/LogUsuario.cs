using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Persistencia;

namespace Logica
{
   public class LogUsuario
    {

        private PerUsuario perusuario = new PerUsuario();
        public void RegistrarUsuario(Usuario usuario)
        {
             perusuario.RegistrarUsuario(usuario);

  
        }

        public void Editar(Usuario usuario)
        {


            perusuario.EditarUsuario(usuario);
            
                
           


        }

        public void Eliminar(string logueo)
        {
            perusuario.EliminarUsuario(logueo);

           
        }

        public List<Usuario> ListarTodosLosUsuarios()
        {
           return  perusuario.TodosLosUsuarios();
          
        }

        public Usuario Buscar(string nombrelogueo)
        {
            Usuario usuario = perusuario.Buscar(nombrelogueo);       
            return usuario;
        }

    }
}
