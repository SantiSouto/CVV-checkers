using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Persistencia;

namespace Logica
{
  public  class LogPronostico
    {
        PerPronostico perPronostico = new PerPronostico();
        public List<Pronostico> PronosticoDiario()
        {
            return perPronostico.PronosticoDiario();
        }


        public void RegistrarPronostico(Pronostico pronostico,Usuario usuario, Ciudad ciudad, Pais pais)
        {
            perPronostico.RegistrarPronostico(pronostico, usuario, ciudad, pais);
  
        }

        public List<Pronostico> PronosticosPorCiudad()
        {
            return perPronostico.PronosticoPorCiudad();
        }

        public List<Pronostico> PronosticosPorFecha()
        {
            return perPronostico.PronosticoPorFecha();
        }
    }
}
