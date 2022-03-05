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

        public void RegistrarCiudad(Ciudad ciudad)
        {

            perciudad.RegistrarCiudad(ciudad);

        }

        public void EditarCiudad(Ciudad ciudad)
        {
            perciudad.EditarCiudad(ciudad);
  
        }

        public void Eliminar(Ciudad ciudad)
        {
            perciudad.EliminarCiudad(ciudad);
            
        
        }
        public List<Ciudad> TodosLasCiudades(Pais pais)
        {
            return perciudad.CiudadPorPais(pais);

        }


        public Ciudad Buscar(string codigociudad, string codigopais) 
        {
            Ciudad ciudad= perciudad.Buscar(codigociudad,codigopais);
            return ciudad;
        }

    }
}
