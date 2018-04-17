using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVehiculos
{
    class Persona:Cliente
    {
        string id;

        public Persona(string id, List<string> listaPermisos) : base(listaPermisos,id)
        {
            this.id = id;
        }


    }
}
