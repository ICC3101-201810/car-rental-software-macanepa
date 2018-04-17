using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVehiculos
{
    class Menu
    {

        List<Transaccion> listaTransacciones = new List<Transaccion>();
        List<Cliente> listaClientes = new List<Cliente>();
        List<Vehiculo> listaVehiculos = new List<Vehiculo>();
        List<Sucursal> listaSucursal = new List<Sucursal>();
        List<Accesorio> listaAccesorios = new List<Accesorio>();

        public void Main()
        {

            #region
            Vehiculo vehiculo1 = new Vehiculo("001","A", 1200);
            Vehiculo vehiculo2 = new Vehiculo("002", "C", 2300);
            Dictionary<Vehiculo, int> diccionarioStock = new Dictionary<Vehiculo, int>
            {
                {vehiculo1,3 },
                {vehiculo2,8 }
            };


            Sucursal sucursal1 = new Sucursal("S001",
                new List<Vehiculo>() { vehiculo1, vehiculo2 }, diccionarioStock);

            Persona persona1 = new Persona("P0001", new List<string> { "B" });
            Institucion institucion1 = new Institucion("I0001", new List<string> { "A", "B", "C" });

            listaClientes.Add(persona1);
            listaClientes.Add(institucion1);

            listaVehiculos.Add(vehiculo1);
            listaVehiculos.Add(vehiculo2);

            #endregion

            while (true){
                CommandInterface();
            }
        }

        public void RealizaTransaccion(Cliente cliente)
        {

            Console.WriteLine("Seleccione ID del Vehiculo:");
            ImprimirVehiculos();
            Console.Write(">: ");
            string idVehiculo = Console.ReadLine();

            Vehiculo vehiculo = (listaVehiculos.Find(x => x.id == idVehiculo));

            Console.WriteLine("Seleccione ID de Sucursal:");
            ImprimirVehiculos();
            Console.Write(">: ");
            string idSucursal = Console.ReadLine();

            Sucursal sucursal = (listaSucursal.Find(x => x.id == idSucursal));

            List<Accesorio> listaAccesorioArrendar = new List<Accesorio>();

            ImprimirAccesorios();
            while (true)
            {
                string idAccesorio = Console.ReadLine();
                if (idAccesorio == "0") { break; }
                Accesorio accesorio = (listaAccesorios.Find(x => x.id == idAccesorio));
                listaAccesorios.Add(accesorio);

                
            }

            bool manejable = cliente.Manejable(vehiculo.tipoVehiculo);
            bool stock = (sucursal.diccionarioStock[vehiculo] > 0);

            int id = 999;

            if (manejable && stock)
            {
                Transaccion transaccion = new Transaccion(id, cliente,
                    vehiculo, sucursal, listaAccesorioArrendar);

                listaTransacciones.Add(transaccion);
                Console.WriteLine("Transaccion Exitosa!");
            }
            else
            {
                Console.WriteLine("Transaccion Fallida!");
                return;
            }

        }


        public void CommandInterface()
        {
            List<int> opcionesValidas = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Console.Clear();
            Console.WriteLine("--Menu de Gestión--\n");
            Console.WriteLine("Selecciones:\n\n" +
                "\t(1) Realizar Arriendo\n" +
                "\t(2) Crear Cliente\n" +
                "\t(3) Crear Vehiculo\n" +
                "\t(4) Crear Accesorio\n" +
                "\t(5) Crear Sucursal\n" +
                "\t(6) Mostrar Informacion\n");

            Console.Write("\t>: ");

            int op = 0;

            try
            {
                int opcion = Convert.ToInt32(Console.ReadLine());
                if (!opcionesValidas.Contains(opcion)) { return; }
                op = opcion;
            }
            catch { Console.WriteLine("Introduce una opcion valida...");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine(op);
            if (op == 1)
            {
                Console.Write("ID Cliente >: ");
                string id = Console.ReadLine();
                Cliente cliente = listaClientes.Find(x => x.id == id);
                while (true)
                {
                    if (listaClientes.Contains(cliente))
                    {
                        RealizaTransaccion(cliente);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No existe cliente con ese id\nGenerar un nuevo cliente\n");
                        CrearCliente();
                    }
                }

                Console.WriteLine("\nVehiculo");
                Console.ReadKey();

            }

            if (op == 2) { CrearCliente(); }

            if(op == 3) { CrearVehiculo(); }


            if (op == 6)
            {
                Imprimir();
            }


        }

        public void CrearCliente()
        {
            Console.WriteLine("--Crear nuevo cliente--\n");
            Console.Write("Tipo Ciente:\n" +
                "\t(1) Persona\n" +
                "\t(2) Institucion\n\n" +
                "\t>: ");

            List<int> opciones = new List<int>() { 1, 2 };
            int tipoCliente = 0;
            try
            {
                tipoCliente = Convert.ToInt32(Console.ReadLine());
                if (!opciones.Contains(tipoCliente)) { Console.WriteLine("Opcion No Valida");return; }
            }
            catch { Console.WriteLine("Opcion No Valida"); return; }
            


            Console.Write("ID Cliente >: ");
            string id = Console.ReadLine();
            List<string> listaPermisos = new List<string>();

            while (true)
            {
                Console.Write("Tipo Permiso >: ");
                string permiso = Console.ReadLine();
                if (permiso == "0") { break; }
                listaPermisos.Add(permiso);
            }

            
            if (tipoCliente == 1) { Persona cliente = new Persona(id, listaPermisos);
                listaClientes.Add(cliente);
            }

            else if (tipoCliente == 2) { Institucion cliente = new Institucion(id, listaPermisos);
                listaClientes.Add(cliente);
            }



            
            return;
        }
        public void CrearVehiculo()
        {
            Console.WriteLine("--Crear nuevo vehiculo--\n");
            Console.Write("\nID Vehiculo >: ");
            string id = Console.ReadLine();

            Console.Write("Tipo Permiso >: ");
            string tipoVehiculo = Console.ReadLine();
            if (tipoVehiculo == "") { Console.WriteLine("Tipo Vehiculo No Valido!");return; }

            Console.Write("Precio >: ");
            int precio = Convert.ToInt32(Console.ReadLine());

            listaVehiculos.Add(new Vehiculo(id, tipoVehiculo, precio));
            Console.WriteLine("Vehiculo Añadido Exitosamente");
            return;

        }


        public void Imprimir()
        {
            Console.Clear();
            Console.WriteLine("Seleccione una opcion pra ver:\n" +
                "\t(1) Clientes\n" +
                "\t(2) Vehiculos\n" +
                "");
            Console.Write("opcion >: ");
            string opcion = Console.ReadLine();

            if (opcion == "1") { ImprimirClientes(); }
            else if (opcion == "2") { ImprimirVehiculos(); }


        }

        public void ImprimirClientes()
        {
            Console.Clear();
            foreach (Cliente cliente in listaClientes)
            {
                string stringPermisos = "";
                foreach(string permiso in cliente.listaPermisos) { stringPermisos += " "+permiso; }
                Console.WriteLine($"ID: {cliente.id}, Permisos: {stringPermisos}");
            }
            Console.Write("Enter para continar...");
            Console.ReadKey();
        }
        public void ImprimirVehiculos()
        {
            Console.Clear();
            foreach(Vehiculo vehiculo in listaVehiculos)
            {
                Console.WriteLine($"ID: {vehiculo.id} Permiso: {vehiculo.tipoVehiculo}" +
                    $" Precio: {vehiculo.precio}");
            }
            Console.Write("Enter para continar...");
            Console.ReadKey();
        }
        public void ImprimirAccesorios()
        {
            foreach(Accesorio accesorio in listaAccesorios)
            {
                Console.WriteLine($"ID Accesorio: {accesorio.id} Precio: {accesorio.precio}");
            }
        }

        

    }
}
