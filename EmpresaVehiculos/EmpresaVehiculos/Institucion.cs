using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVehiculos
{
    class Institucion:Cliente
    {
        string id;

        public Institucion(string id, List<string> listaAutorizacion):base(listaAutorizacion,id)
        {
            this.id = id;
        }
    }
}
