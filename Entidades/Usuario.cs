using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Usuario
    {

        private string _nombrelogueo;
        private string _nombre;
        private string _apellido;
        private string _contrasenia;

        public string NombreLogueo
        {
            get { return _nombrelogueo; }
            set
            {
                if (value == string.Empty)
                    throw new Exception("\n" + "----DEBE HABER UN NOMBRE DE LOGUEO----");
                if (value.Length > 50)
                    throw new Exception("\n" + "EL NOMBRE DE LOGUEO NO PUEDE TENER MAS DE 50 CARACTERES");
                _nombrelogueo = value;
            }


        }

        public string Contrasenia
        {
            get { return _contrasenia; }
            set
            {
                if (value.Length > 10)
                { throw new Exception("\n" + "----LA CONTRASEÑA NO PUEDE TENER MAS DE 10 CARACTERES----"); }
                if (string.IsNullOrEmpty(value.Trim()))
                    throw new Exception("\n" + "----DEBE INGRESAR UNA CONTRASEÑA-----");

                _contrasenia = value;
            }


        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                    throw new Exception("\n" + "----DEBE INGRESAR UN NOMBRE-----");
                if (value.Length > 30)
                    throw new Exception("\n" + "EL NOMBRE  NO PUEDE TENER MAS DE 30 CARACTERES");
                _nombre = value;
            }

        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                    throw new Exception("\n" + "----DEBE INGRESAR UN APELLIDO-----");
                if (value.Length > 30)
                    throw new Exception("\n" + "EL APELLIDO  NO PUEDE TENER MAS DE 30 CARACTERES");
                _apellido = value;
            }

        }

        public Usuario(string nombrelogueo,string nombre, string apellido, string contrasenia )
        {
            NombreLogueo = nombrelogueo;
            
            Nombre = nombre;
            Apellido = apellido;
            Contrasenia = contrasenia;
        }

        public override string ToString()
        {
            return "NOMBRE DE LOGUEO:" + NombreLogueo + "\t" + "NOMBRE:" + Nombre + "\t" + "APELLIDO:" + Apellido +"\t" + "CONTRASENIA:" + Contrasenia ;


        }
    }
}

