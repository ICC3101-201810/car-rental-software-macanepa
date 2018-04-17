using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVehiculos
{
    class Cliente:IOperable
    {

        public List<string> listaPermisos { get; private set; }
        public string id { get; private set; }

        public Cliente(List<string> listaPermisos,string id)
        {
            this.listaPermisos = listaPermisos;
            this.id = id;
        }

        public bool Manejable(string tipoPermiso)
        {
            if (listaPermisos.Contains(tipoPermiso
                )) { return true; }
            else return false;
        }

   

    }
}
