using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Sucursal sucursal1 = new Sucursal(1001);
            Cliente cliente1 = new Cliente("Jose");
            Vehiculo moto = new Vehiculo("Moto");
            Accesorio GPS = new Accesorio(1000);

            List<string> registro = new List<string>();

            sucursal1.agnadirVehiculo(moto);
            sucursal1.agnadirVehiculo(moto);

            


            foreach (Vehiculo vehiculo in sucursal1.GetVehiculo())
            {
                Console.WriteLine(vehiculo.GetNombre());
            }



            string reg1 = sucursal1.guardarRegistro(cliente1, moto);

            registro.Add(reg1);


            foreach (string i in registro) { Console.WriteLine(i); }

            Console.ReadKey();

        }
    }
}
