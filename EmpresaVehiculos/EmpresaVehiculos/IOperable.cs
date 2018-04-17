using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVehiculos
{
    interface IOperable
    {
        bool Manejable(string tipoLicencia);
    }
}
