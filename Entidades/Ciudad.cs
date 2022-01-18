using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Ciudad
    {
        private string _codigociudad;
        private Pais _codigopais;
        private string _nombreciudad;

        public string Codigociudad
        {
            get { return _codigociudad; }
            set
            {
                if (value == string.Empty)
                    throw new Exception("\n" + "----EL CODIGO NO ES VALIDO----");
                _codigociudad = value;
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

        public string NombreCiudad
        {
            get { return _nombreciudad; }
            set
            {
                if (value == string.Empty)
                    throw new Exception("\n" + "----DEBE HABER UN NOBRE PARA LA CIUDAD----");
                _nombreciudad = value;
            }

        }



        public Ciudad(string codigociudad, Pais codigopais, string nombreciudad)
        {

            Codigociudad = codigociudad;
            Pais = codigopais;
            NombreCiudad = nombreciudad;
        }
        public override string ToString()
        {
            return "CODIGO CIUDAD:" + Codigociudad + "\t" + "CODIGOPAIS:" + Pais.ToString() + "\t" + "NOMBRECIUDAD" + NombreCiudad;
        }
    }
}

