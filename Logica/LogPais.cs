using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Persistencia;

namespace Logica
{
    class LogPais
    {
        PerPais perpais = new PerPais();

        public bool RegistrarPais(Pais pais)
        {
            int retorno = perpais.RegistrarPais(pais);
            if (retorno == -1)
                throw new Exception("YA EXISTE ESE PAIS EN LA BASE DE DATOS");
            else if (retorno == -2)
                throw new Exception("ERROR AL MODIFICAR");
            return true;
        }
        public bool EditarPais(Pais pais)
        {
            int retorno = perpais.EditarPais(pais);
            if (retorno == -1)
                throw new Exception("NO EXISTE EL PAIS");
            else if (retorno == -2)
                throw new Exception("NO SE PUEDE MODIFICAR, TIENE PRONOSTICOS ASOCIADOS");
            else if (retorno == -3)
                throw new Exception("ERROR AL MODIFICAR");
            return true;
        }

        public List<Pais> TodosLosPaises()
        {
            return perpais.TodosLosPaises();

        }


        public void Eliminar(Pais pais)
        {
            int r = perpais.EliminarPais(pais);

            if (r == -1)
                throw new Exception("NO EXISTE EL PAIS");
            else if (r == -2)
                throw new Exception("NO SE PUEDE ELIMINAR EL PAIS, TIENE CIUDADES ASOCIADAS");
            else if (r == -3)
                throw new Exception("ERROR");

        }


    }
}
