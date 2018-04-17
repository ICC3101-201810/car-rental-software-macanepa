using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVehiculos
{
    class Accesorio
    {
        public int precio { get; private set; }
        public string id { get; private set; }

        public Accesorio(string id,int precio)
        {
            this.id = id;
            this.precio = precio;
        }

    }
}
