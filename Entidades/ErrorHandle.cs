using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ErrorHandle
    {
        string ErrorDescripcion { get; set; }
        bool HuboError { get; set; }
    }
}
