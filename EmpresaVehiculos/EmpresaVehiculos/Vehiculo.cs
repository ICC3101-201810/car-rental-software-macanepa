using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVehiculos
{
    class Vehiculo
    {
        public string id { get; private set; }
        public string tipoVehiculo { get; private set; }
        public int precio { get; private set; }
        

        public Vehiculo(string id,string tipoVehiculo,int precio)
        {
            this.id = id;
            this.tipoVehiculo = tipoVehiculo;
            this.precio = precio;
        }
    }
}
