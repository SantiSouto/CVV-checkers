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

        public void RegistrarPais(Pais pais)
        {
            perpais.RegistrarPais(pais);
       
        }
        public void EditarPais(Pais pais)
        {
            perpais.EditarPais(pais);
         
        }

        public List<Pais> TodosLosPaises()
        {
            return perpais.TodosLosPaises();

        }


        public void Eliminar(Pais pais)
        {
             perpais.EliminarPais(pais);

        }


    }
}
