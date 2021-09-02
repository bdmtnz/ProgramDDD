using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Logica
{
    public class CuentaService
    {
        CuentaRepo oCuentaRepo = new CuentaRepo();

        public CuentaService()
        {

        }

        public void Guardar(ICuenta pCuenta)
        {
            oCuentaRepo.Guardar(pCuenta);
        }

        public IEnumerable<ICuenta> Consultar()
        {
            return oCuentaRepo.Consultar();
        }

        public ICuenta Consultar(string pNumero)
        {
            return oCuentaRepo.Consultar(pNumero);
        }

        public ICuenta Consultar(ICliente pCliente)
        {
            return oCuentaRepo.Consultar(pCliente);
        }

        public ICuenta Modificar(ICuenta pCuenta)
        {
            var oCuenta = Consultar(pCuenta.Numero);
            if(oCuenta == null)
            {
                return null;
            }

            oCuentaRepo.Modificar(pCuenta);
            return pCuenta;
        }

    }

    public class ClienteService
    {
        ClienteRepo oClienteRepo = new ClienteRepo();

        public ClienteService()
        {

        }

        public void Guardar(ICliente pCliente)
        {
            oClienteRepo.Guardar(pCliente);
        }

        public IEnumerable<ICliente> Consultar()
        {
            return oClienteRepo.Consultar();
        }

        public ICliente Consultar(string pId)
        {
            return oClienteRepo.Consultar(pId);
        }
    }

    public class TransaccionService : ErrorHandle
    {
        public string ErrorDescripcion { get; set; }
        public bool HuboError { get; set; }

        TransaccionRepo oTransaccionRepo = new TransaccionRepo();
        CuentaRepo oCuentaRepo = new CuentaRepo();

        public TransaccionService()
        {

        }

        public void Guardar(ITransaccion pTransaccion)
        {
            HuboError = false;
            ErrorDescripcion = "";
            if(pTransaccion is Retiro)
            {
                if(pTransaccion.Origen.Saldo < pTransaccion.Saldo)
                {
                    HuboError = true;
                    ErrorDescripcion = "Fondos insuficientes";
                    return;
                }
                pTransaccion.Origen.Saldo -= pTransaccion.Saldo;
                oCuentaRepo.Modificar(pTransaccion.Origen);
            }
            else if(pTransaccion is Consignacion)
            {
                pTransaccion.Destino.Saldo += pTransaccion.Saldo;
                oCuentaRepo.Modificar(pTransaccion.Destino);
            }
            else if(pTransaccion is Transferencia)
            {
                if (pTransaccion.Origen.Saldo < pTransaccion.Saldo)
                {
                    HuboError = true;
                    ErrorDescripcion = "Fondos insuficientes";
                    return;
                }
                pTransaccion.Origen.Saldo -= pTransaccion.Saldo;
                oCuentaRepo.Modificar(pTransaccion.Origen);

                pTransaccion.Destino.Saldo += pTransaccion.Saldo;
                oCuentaRepo.Modificar(pTransaccion.Destino);
            }
            oTransaccionRepo.Guardar(pTransaccion);
        }

        public IEnumerable<ITransaccion> Consultar()
        {
            return oTransaccionRepo.Consultar();
        }

        public ITransaccion Consultar(double pId)
        {
            return oTransaccionRepo.Consultar(pId);
        }

        public IEnumerable<ITransaccion> Consultar(ICuenta pCuenta)
        {
            return oTransaccionRepo.Consultar(pCuenta);
        }
    }
}
