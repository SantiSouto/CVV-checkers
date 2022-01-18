using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Pais
    {
        private string _codigopais;
        private string _nombre;

        public string CodigoPais
        {

            get { return _codigopais; }
            set
            {
                if (value == null)
                    throw new Exception("\n" + "----DEBE INGRESAR UN CODIGO DE PAIS-----");
                _codigopais = value;
            }


        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value == null)
                    throw new Exception("\n" + "----DEBE INGRESAR UN NOMBRE DE PAIS-----");
                _nombre = value;
            }

        }


        public Pais(string codigopais, string nombre)
        {
            CodigoPais = codigopais;
            Nombre = nombre;


        }

        public override string ToString()
        {
            return "CODIGO PAIS:" + CodigoPais + "\t" + "NOMBRE" + Nombre;
        }

    }
}
}
