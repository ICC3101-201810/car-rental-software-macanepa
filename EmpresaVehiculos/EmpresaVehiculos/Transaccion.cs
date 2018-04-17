using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVehiculos
{
    class Transaccion
    {
        Cliente cliente;
        Vehiculo vehiculo;
        Sucursal sucursal;
        List<Accesorio> listaAccesorio;
        public int id { get; private set; }

        public Transaccion(int id,Cliente cliente,Vehiculo vehiculo,
            Sucursal sucursal, List<Accesorio> listaAccesorio)
        {
            this.cliente = cliente;
            this.vehiculo = vehiculo;
            this.sucursal = sucursal;
            this.listaAccesorio = listaAccesorio;
            this.id = id;
        }





    }
}
