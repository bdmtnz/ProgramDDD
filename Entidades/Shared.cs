using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Shared
    {
        public static IEnumerable<ICuenta> Cuentas = new List<ICuenta>();
        public static IEnumerable<ICliente> Clientes = new List<ICliente>();
        public static IEnumerable<ITransaccion> Transaccions = new List<ITransaccion>();
    }
}
