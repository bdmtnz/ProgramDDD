using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Datos
{
    public class CuentaRepo
    {
        public CuentaRepo()
        {
            
        }

        public void Guardar(ICuenta pCuenta)
        {
            var oLista = Shared.Cuentas.ToList();
            oLista.Add(pCuenta);
            Shared.Cuentas = oLista;
        }

        public void Modificar(ICuenta pCuenta)
        {
            var oLista = Shared.Cuentas.ToList();
            var indice = oLista.FindIndex(x => x.Numero == pCuenta.Numero);

            if(indice != -1)
            {
                oLista[indice] = pCuenta;
                Shared.Cuentas = oLista;
            }
        }

        public IEnumerable<ICuenta> Consultar()
        {
            return Shared.Cuentas;
        }

        public ICuenta Consultar(string pNumero)
        {
            return Shared.Cuentas.Where(x => x.Numero == pNumero).FirstOrDefault();
        }

        public ICuenta Consultar(ICliente pCliente)
        {
            return Shared.Cuentas.Where(x => x.Cliente.Id == pCliente.Id).FirstOrDefault();
        }

    }

    public class ClienteRepo
    {
        public ClienteRepo()
        {
            
        }

        public void Guardar(ICliente pCliente)
        {
            var oLista = Shared.Clientes.ToList();
            oLista.Add(pCliente);
            Shared.Clientes = oLista;
        }

        public IEnumerable<ICliente> Consultar()
        {
            return Shared.Clientes;
        }

        public ICliente Consultar(string pId)
        {
            return Shared.Clientes.Where(x => x.Id == pId).FirstOrDefault();
        }
    }

    public class TransaccionRepo
    {

        public TransaccionRepo()
        {
            
        }

        public void Guardar(ITransaccion pTransaccion)
        {
            var oLista = Shared.Transaccions.ToList();
            pTransaccion.Id = oLista.Count + 1;
            oLista.Add(pTransaccion);
            Shared.Transaccions = oLista;
        }

        public IEnumerable<ITransaccion> Consultar()
        {
            return Shared.Transaccions;
        }

        public ITransaccion Consultar(double pId)
        {
            return Shared.Transaccions.Where(x => x.Id == pId).FirstOrDefault();
        }

        public IEnumerable<ITransaccion> Consultar(ICuenta pCuenta)
        {
            return Shared.Transaccions.Where(
                x => x.Origen.Numero == pCuenta.Numero || 
                x.Destino.Numero == pCuenta.Numero
            ).ToList();
        }
    }
}
