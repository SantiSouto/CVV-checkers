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


        public bool RegistrarPronostico(Pronostico pronostico,Usuario usuario, Ciudad ciudad)
        {
            int retorno = perPronostico.RegistrarPronostico(pronostico, usuario, ciudad);
            if (retorno == -1)
                throw new Exception("NO EXISTE ESE USUARIO");
            else if (retorno == -2)
                throw new Exception("NO EXISTE LA CIUDAD REGISTRADA");
            else if (retorno == -3)
                throw new Exception("ERROR");
            return true;
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
