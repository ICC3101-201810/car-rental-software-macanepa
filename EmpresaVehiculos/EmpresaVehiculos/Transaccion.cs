using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVehiculos
{
    class Transaccion
    {
        public Cliente cliente { get; private set; }
        public Vehiculo vehiculo { get; private set; }
        public Sucursal sucursal { get; private set; }
        public List<Accesorio> listaAccesorio { get; private set; }
        public int id { get; private set; }
        public int precio { get; private set; }
        public int tiempoArriendo { get; private set; }

        public DateTime fechaInicioTransaccion = DateTime.Now;


        public Transaccion(int id,Cliente cliente,Vehiculo vehiculo,
            Sucursal sucursal, List<Accesorio> listaAccesorio, int precio,int tiempoArriendo)
        {
            this.cliente = cliente;
            this.vehiculo = vehiculo;
            this.sucursal = sucursal;
            this.listaAccesorio = listaAccesorio;
            this.id = id;
            this.tiempoArriendo = tiempoArriendo;
            this.precio = precio*tiempoArriendo;


        }





    }
}
