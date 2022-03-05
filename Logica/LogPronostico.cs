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


        public void RegistrarPronostico(Pronostico pronostico)
        {
            perPronostico.RegistrarPronostico(pronostico);
  
        }

        public List<Pronostico> PronosticosPorCiudad(Ciudad ciudad)
        {
            return perPronostico.PronosticoPorCiudad(ciudad);
        }

        public List<Pronostico> PronosticosPorFecha(DateTime pronosticoporfecha)
        {
            return perPronostico.PronosticoPorFecha(pronosticoporfecha);
        }
    }
}
