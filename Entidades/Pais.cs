using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Pais
    {
        private string _codigopais;
        private string _nombre;

        public string CodigoPais
        {

            get { return _codigopais; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar un código de país");
                if (value.Trim().Length != 3)
                    throw new Exception("EL CODIGO DEBE SER DE 3 CARACTERES");
                _codigopais = value;
            }


        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                    throw new Exception("\n" + "----DEBE INGRESAR UN NOMBRE DE PAIS-----");
                if (value.Length > 30)
                    throw new Exception("\n" + "EL NOMBRE NO PUEDE TENER MAS DE 30 CARACTERES");

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
            return "CODIGO PAIS:" + CodigoPais.ToString() + "\t" + "NOMBRE" + Nombre.ToString();
        }

    }
}

