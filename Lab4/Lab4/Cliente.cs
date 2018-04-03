using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Cliente 
    {

        string nombre;

        public Cliente(string nombre)
        {
            this.nombre = nombre;
        }


        public string GetNombre() { return nombre; }

    }
}
