using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Usuario
    {

        private string _nombrelogueo;
        private int _contrasenia;
        private string _nombre;
        private string _apellido;

        public string NombreLogueo
        {
            get { return _nombrelogueo; }
            set
            {
                if (value == string.Empty)
                    throw new Exception("\n" + "----DEBE HABER UN NOMBRE DE LOGUEO----");
                _nombrelogueo = value;
            }


        }

        public int Contrasenia
        {
            get { return _contrasenia; }
            set
            {
                _contrasenia = value;
            }


        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value == null)
                    throw new Exception("\n" + "----DEBE INGRESAR UN NOMBRE-----");
                _nombre = value;
            }

        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                if (value == null)
                    throw new Exception("\n" + "----DEBE INGRESAR UN APELLIDO-----");
                _apellido = value;
            }

        }

        public Usuario(string nombrelogueo, int contrasenia, string nombre, string apellido)
        {
            NombreLogueo = nombrelogueo;
            Contrasenia = contrasenia;
            Nombre = nombre;
            Apellido = apellido;
        }

        public override string ToString()
        {
            return "NOMBRE DE LOGUEO:" + NombreLogueo + "\t" + "CONTRASENIA:" + Contrasenia + "\t" + "NOMBRE:" + Nombre + "\t" + "APELLIDO:" + Apellido;

        }
    }
}

