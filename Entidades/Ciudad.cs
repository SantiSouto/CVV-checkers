using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Ciudad
    {
        private string _codigociudad;
        private string _nombreciudad;
        private Pais _codigopais;

        public string Codigociudad
        {
            get { return _codigociudad; }
            set
            {
                if (value == string.Empty)
                    throw new Exception("\n" + "----EL CODIGO NO ES VALIDO----");
                if (value.Trim().Length != 3)
                    throw new Exception("\n" + "EL CODIGO DEBE SER DE 3 CARACTERES");
                _codigociudad = value;
            }

        }
  

        public string NombreCiudad
        {
            get { return _nombreciudad; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                    throw new Exception("\n" + "----DEBE HABER UN NOBRE PARA LA CIUDAD----");
                if (value.Length > 30)
                    throw new Exception("\n" + "EL NOMBRE DE LA CIUDAD NO PUEDE TENER MAS DE 30 CARACTERES");
                _nombreciudad = value;
            }

        }
        public Pais Pais
        {
            get { return _codigopais; }
            set
            {
                if (value == null)
                    throw new Exception("-----LA NOTICIA DEBE TENER UN PAIS ASOCIADO----");

                _codigopais = value;
            }

        }


        public Ciudad(string codigociudad, string nombreciudad, Pais codigopais)
        {

            Codigociudad = codigociudad;
            Pais = codigopais;
            NombreCiudad = nombreciudad;
           
        }
        public override string ToString()
        {
            return "CODIGO CIUDAD:" + Codigociudad + "\t" + "NOMBRECIUDAD" + NombreCiudad + "\t" + "CODIGOPAIS:" + Pais.ToString();
        }

    }
}

