using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Pronostico
    {
        private int _codigointerno;
        private Ciudad _ciudad;
        private Usuario _usuario;
        private int _tmaxima;
        private int _tminima;
        private int _velocidadviento;
        private DateTime _fechahora;
        private string _tipodecielo;
        private int _probabilidadlluvia;
        private int _probabilidadtormenta;
        
        

        public int CodigoInterno
        {
            get { return _codigointerno; }
            set { _codigointerno = value; }
        }

        public Ciudad Ciudad
        {
            get
            {
                return _ciudad;

            }
            set
            {
                if (value == null)
                    throw new Exception("\n" + "----DEBE HABER UNA CIUDAD----");
                _ciudad = value;

            }
        }




        public Usuario Usuario
        {
            get
            {
                return _usuario;

            }
            set
            {
                if (value == null)
                    throw new Exception("\n" + "----DEBE HABER UN USUARIO----");
                _usuario = value;

            }
        }


        public int Tmaxima
        {
            get { return _tmaxima; }
            set {if ((value < -100) || (value > 100))
                         throw new Exception("\n" + "ERROR EN LA TEMPERATURA");

                _tmaxima = value; }
        }

        public int Tminima
        {
            get { return _tminima; }
            set {
                if ((value < -100) || (value > 100))
                    throw new Exception("\n" + "ERROR EN LA TEMPERATURA");
                _tminima = value; }
        }

        public int VelocidadViento
        {
            get
            {
                return _velocidadviento;

            }
            set
            {
                if (value < 0)
                    throw new Exception("\n" + "---ERROR EN LA VELOCIDAD DE VIENTO----");
                _velocidadviento = value;

            }

        }

        public DateTime FechaHora
        {
            get { return _fechahora; }
            set { _fechahora = value;}
        }
    

        public string TipoDeCielo
        {
            get { return _tipodecielo; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                { throw new Exception("\n" + "----DEBE HABER UN TIPO DE CIELO----"); }
                else if(value.Trim().ToUpper() != "NUBOSO" && value.Trim().ToUpper() != "PARCIALMENTE NUBOSO" && value.Trim().ToUpper() != "DESPEJADO")
                { throw new Exception("\n" + "----eL TIPO DE CIELO NO ES VALIDO----"); }

                _tipodecielo = value;

            }

        }

        public int ProbabilidadLluvia
        {
            get { return _probabilidadlluvia; }
            set {
                 if ((value < 0 || value > 100))
                    throw new Exception("\n" + "---ERROR----");
                 _probabilidadlluvia = value; 
            }
        }

        public int Probabilidadtormenta
        {
            get { return _probabilidadtormenta; }
            set {
                 if ((value < 0 || value > 100))
                    throw new Exception("\n" + "---ERROR----");
                 _probabilidadtormenta = value;   
            }
        }

        public Pronostico(int codigointerno, Ciudad ciudad,  Usuario usuario, int tmaxima, int tminima, DateTime fechahora,int velocidaviento, string tipodecielo, int problluvia, int probtormenta)

        {
            CodigoInterno = codigointerno;
            Ciudad = ciudad;
            Usuario = usuario;
            Tmaxima = tmaxima;
            Tminima = tminima;
            FechaHora = fechahora;          
            VelocidadViento = velocidaviento;
            TipoDeCielo = tipodecielo;
            ProbabilidadLluvia = problluvia;
            Probabilidadtormenta = probtormenta;

        }
        

        public override string ToString()
        {
            return "CODIGO INTERNO: " + CodigoInterno + "\n" + "CIUDAD: " + "\n" + Ciudad.NombreCiudad +"\n" + "USUARIO" + Usuario.Nombre + "\n" + Usuario.Apellido + "\n" + "TEMPERATURA MAXIMA: " + Tmaxima + "°C" +"TEMPERATURA MINIMA: " + Tminima + "°C" + "FECHA Y HORA:" + FechaHora.ToString() + "Velocidad del Viento:" + VelocidadViento + "\n" + "\n" + "TIPO DE CIELO: " + TipoDeCielo + "\n" + "PROBABILIDAD DE LLUVIA: " + ProbabilidadLluvia + "%"+ "PROBABILIDAD DE TORMENTA: " + Probabilidadtormenta + "%";
        }
    }
}

