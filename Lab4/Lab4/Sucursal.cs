using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Sucursal
    {
        int idSucursal;
        List<Vehiculo> listaVehiculo = new List<Vehiculo>();

        public Sucursal(int idSucursal)
        {
            this.idSucursal = idSucursal;
        }

        public string GetIdSucursal() { return idSucursal.ToString(); }
        public List<Vehiculo> GetVehiculo() { return listaVehiculo; } 



        public string guardarRegistro(Cliente cliente,Vehiculo vehiculo)
        {
            string registro = $"Cliente: {cliente.GetNombre()} Vehiculo: {vehiculo.GetNombre()} Sucursal: {idSucursal}";
            Console.WriteLine(registro);
            return registro;
        }



        public void agnadirVehiculo(Vehiculo vehiculo)
        {
            listaVehiculo.Add(vehiculo);
        }

        

    }
}
