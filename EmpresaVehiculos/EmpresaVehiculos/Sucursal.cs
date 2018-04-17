using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVehiculos
{
    class Sucursal
    {
        public string id { get; private set; }
        List<Vehiculo> listaVehiculos;
        public Dictionary<Vehiculo, int> diccionarioStock{ get; private set; }


        public Sucursal(string id,List<Vehiculo> listaVehiculos,Dictionary<Vehiculo,int> diccionarioStock)
        {
            this.id = id;
            this.listaVehiculos = listaVehiculos;
            this.diccionarioStock = diccionarioStock;

        }


        public bool Transaccion(Vehiculo vehiculo,Cliente cliente)
        {

            if (cliente.Manejable(vehiculo.tipoVehiculo))
            {

            }

            return true;
        }


    }
}
