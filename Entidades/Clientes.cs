using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ICliente
    {
        string Id { get; }
        string TipoId { get; }
        string Nombre { get; }
        string Direccion { get; }
        string Telefono { get; }
    }

    public class Persona : ICliente
    {
        public string Id { get; set; }

        public string TipoId => "C.C.";

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }
    }

    public class Empresa : ICliente
    {
        public string Id { get; set; }

        public string TipoId => "N.I.T.";

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

    }
}
