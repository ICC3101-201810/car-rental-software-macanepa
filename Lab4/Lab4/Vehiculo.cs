using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Vehiculo
    {
        string nombre;

        public Vehiculo(string nombre)
        {
            this.nombre = nombre;
        }

        public string GetNombre() { return nombre; }

    }
}
