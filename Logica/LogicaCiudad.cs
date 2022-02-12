using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Persistencia;

namespace Logica
{
    class LogicaCiudad
    {
        private PerCiudad perciudad = new PerCiudad();
        public bool RegistrarCiudad(Ciudad ciudad, Pais pais)
        {
            int retorno = perciudad.RegistrarCiudad(ciudad,pais);
            if (retorno == -1)
                throw new Exception("YA EXISTE ESA CIUDAD EN LA BASE DE DATOS");
            else if (retorno == -2)
                throw new Exception("ERROR AL REGISTRAR");
            return true;
        }

        public bool EditarCiudad(Ciudad ciudad,Pais pais)
        {
            int retorno = perciudad.EditarCiudad(ciudad,pais);
            if (retorno == -1)
                throw new Exception("NO EXISTE EL PAIS");
            else if (retorno == -2)
                throw new Exception("NO EXISTE LA CIUDAD");
            else if (retorno == -3)
                throw new Exception("ERROR AL MODIFICAR, TIENE PRONOSTICO ASOCIADO");
            else if (retorno == -3)
                throw new Exception("ERROR DESCONOCIDO");
            return true;
        }

        public void Eliminar(Ciudad ciudad,Pais pais)
        {
            int retorno = perciudad.EliminarCiudad(ciudad, pais);
            if (retorno == -1)
                throw new Exception("NO EXISTE EL PAIS");
            else if (retorno == -2)
                throw new Exception("NO EXISTE LA CIUDAD");
            else if (retorno == -3)
                throw new Exception("ERROR AL ELIMINAR, TIENE PRONOSTICO ASOCIADO");
            else if (retorno == -3)
                throw new Exception("ERROR DESCONOCIDO");
        
        }
        public List<Ciudad> TodosLasCiudades()
        {
            return perciudad.TodosLasCiudades();

        }



    }
}
