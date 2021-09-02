using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ITransaccion
    {
        double Id { get; set; }
        ICuenta Origen { get; }
        ICuenta Destino { get; }
        double Saldo { get; }
        bool Resta { get; }
    }

    public class Transferencia : ITransaccion
    {
        public double Id { get; set; }
        public ICuenta Origen { get; set; }
        public ICuenta Destino { get; set; }
        public double Saldo { get; set; }
        public bool Resta => true;
    }

    public class Retiro : ITransaccion
    {
        public double Id { get; set; }
        public ICuenta Origen { get; set; }
        public ICuenta Destino => new SinCuenta();
        public double Saldo { get; set; }
        public bool Resta => true;

    }

    public class Consignacion : ITransaccion
    {
        public double Id { get; set; }
        public ICuenta Origen => new SinCuenta();
        public ICuenta Destino { get; set; }
        public double Saldo { get; set; }
        public bool Resta => false;

    }
}
