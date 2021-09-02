using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ICuenta
    {
        string Numero { get; }
        ICliente Cliente { get; }
        string Clave { get; }
        double Saldo { get; set; }
        string Tipo { get; }
        double Comision { get; }
        string ToString();
    }

    public class Ahorros : ICuenta
    {
        public string Numero { get; set; }
        public ICliente Cliente { get; set; }
        public string Clave { get; set; }
        public double Saldo { get; set; }
        public double Comision => 0;
        public string Tipo => "Ahorros";
        public override string ToString()
        {
            return Numero;
        }
    }

    public class Corriente : ICuenta
    {
        public string Numero { get; set; }
        public ICliente Cliente { get; set; }
        public string Clave { get; set; }
        public double Saldo { get; set; }
        public double Comision => 2;
        public string Tipo => "Corriente";
        public double Salvavidas { get; set; }
        public override string ToString()
        {
            return Numero;
        }

    }

    public class SinCuenta : ICuenta
    {
        public string Numero { get; set; }
        public ICliente Cliente { get; set; }
        public string Clave { get; set; }
        public double Saldo { get; set; }
        public double Comision => 0;
        public string Tipo => "Sin cuenta";
        public override string ToString()
        {
            return Numero;
        }

        public SinCuenta()
        {
            Numero = 0.ToString();
            Cliente = null;
            Clave = 0.ToString();
            Saldo = 0;
        }
    }
}
