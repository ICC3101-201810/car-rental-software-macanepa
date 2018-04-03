using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    interface IArriendo
    {
        Cliente cliente();
        Vehiculo vehiculo();
        Sucursal sucursal();
        List<Accesorio> accesorios();
        string fechaInicio();
        string terminoContrato();
        int total();
    }
}
