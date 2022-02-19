using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Persistencia;




namespace Logica
{
   public  class LogicaCiudad
    {

        private PerCiudad perciudad = new PerCiudad();

        public void RegistrarCiudad(Ciudad ciudad, Pais pais)
        {

            perciudad.RegistrarCiudad(ciudad, pais);

        }

        public void EditarCiudad(Ciudad ciudad, Pais pais)
        {
            perciudad.EditarCiudad(ciudad, pais);
  
        }

        public void Eliminar(Ciudad ciudad,Pais pais)
        {
            perciudad.EliminarCiudad(ciudad, pais);
            
        
        }
        public List<Ciudad> TodosLasCiudades()
        {
            return perciudad.TodosLasCiudades();

        }


        public Ciudad Buscar(string codciudad) 
        {
            Ciudad ciudad= perciudad.Buscar(codciudad);
            return ciudad;
        }

    }
}
