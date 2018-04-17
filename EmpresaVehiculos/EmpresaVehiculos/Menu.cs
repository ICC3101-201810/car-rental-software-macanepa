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
        List<int> listaIdTransaccion = new List<int>() { 1 };

        public void Main()
        {

            #region
            Vehiculo vehiculo1 = new Vehiculo("001","A", 1200);
            Vehiculo vehiculo2 = new Vehiculo("002", "F", 2300);
            Vehiculo vehiculo3 = new Vehiculo("003", "B", 2300);
            Vehiculo vehiculo4 = new Vehiculo("004", "E", 2300);
            Dictionary<Vehiculo, int> diccionarioStock = new Dictionary<Vehiculo, int>
            {
                {vehiculo1,3 },
                {vehiculo2,8 },
                {vehiculo3,8 },
                {vehiculo4,8 }
            };


            Sucursal sucursal1 = new Sucursal("S001",
                new List<Vehiculo>() { vehiculo1, vehiculo2 }, diccionarioStock);

            Persona persona1 = new Persona("P0001", new List<string> { "B" });
            Empresa empresa1 = new Empresa("E0001", new List<string> { "F","A","E" });



            Institucion institucion1 = new Institucion("I0001", new List<string> { "A", "B", "C" });
            Accesorio accesorio1 = new Accesorio("A001", 210);
            Accesorio accesorio2 = new Accesorio("A002", 2864);

            listaClientes.Add(persona1);
            listaClientes.Add(institucion1);
            listaClientes.Add(empresa1);

            listaVehiculos.Add(vehiculo1);
            listaVehiculos.Add(vehiculo2);
            listaVehiculos.Add(vehiculo3);
            listaVehiculos.Add(vehiculo4);


            listaAccesorios.Add(accesorio1);
            listaAccesorios.Add(accesorio2);


            listaSucursal.Add(sucursal1);


            Transaccion transaccion1 = new Transaccion(1, persona1, vehiculo1,
                sucursal1, listaAccesorios,2000,4);

            listaTransacciones.Add(transaccion1);


            #endregion

            while (true){
                CommandInterface();
            }
        }

        public void RealizaTransaccion(Cliente cliente)
        {
            Console.Clear();
            int precio = 0;

            Console.WriteLine("INICIO TRANSACCION");
            Console.WriteLine("Seleccione ID del Vehiculo:");
            ImprimirVehiculos();
            Console.Write(">: ");
            string idVehiculo = Console.ReadLine();

            Vehiculo vehiculo = (listaVehiculos.Find(x => x.id == idVehiculo));
            precio += vehiculo.precio;

            Console.WriteLine("Seleccione ID de Sucursal:");
            ImprimirSucursales();
            Console.Write(">: ");
            string idSucursal = Console.ReadLine();

            Sucursal sucursal = (listaSucursal.Find(x => x.id == idSucursal));

            List<Accesorio> listaAccesorioArrendar = new List<Accesorio>();



            ImprimirAccesorios();
            Console.WriteLine("0 Para detener");
            while (true)
            {
                errorAccesorio:
                string idAccesorio = Console.ReadLine();
                if (idAccesorio == "0") { break; }
                Accesorio accesorio = (listaAccesorios.Find(x => x.id == idAccesorio));

                if (accesorio == null) { Console.WriteLine("Error");goto errorAccesorio; }
                listaAccesorioArrendar.Add(accesorio);
                precio += accesorio.precio;

                
            }

            Console.Write("Tiempo de arriendo (dias) >: ");
            int tiempoArriendo =Convert.ToInt32(Console.ReadLine());

            bool manejable = cliente.Manejable(vehiculo.tipoVehiculo);
            bool stock = (sucursal.diccionarioStock[vehiculo] > 0);




            if (vehiculo.tipoVehiculo == "F")
            {

                if ((cliente.GetType() == typeof(Organizacion)) ||
                    (cliente.GetType() == typeof(Institucion)))
                {
                    manejable = false;
                }

                if (cliente.GetType() == typeof(Empresa))
                {
                    if (manejable)
                    {
                        double probabilidad = (new Random()).NextDouble();
                        Console.WriteLine("PROB: " + probabilidad.ToString());
                        if (!(probabilidad <= 0.63)) { manejable = false; }
                    }
                }

            }


            if (vehiculo.tipoVehiculo == "E")
            {
                if (cliente.GetType() == typeof(Persona))
                {
                    manejable = false;
                    Console.WriteLine("Persona No puede Arrendar!");
                }

                if ((cliente.GetType() == typeof(Empresa)) ||
                    (cliente.GetType() == typeof(Organizacion)) ||
                    (cliente.GetType() == typeof(Institucion)))
                {
                    double probabilidad = (new Random()).NextDouble();
                    if ((cliente.GetType() == typeof(Empresa)))
                    {
                        if (!(probabilidad <= 0.8)) { manejable = false; Console.WriteLine("SHIT!!"); }
                    }
                    if ((cliente.GetType() == typeof(Organizacion)))
                    {
                        if (!(probabilidad <= 0.35)) { manejable = false; }
                    }
                    if ((cliente.GetType() == typeof(Institucion)))
                    {
                        if (!(probabilidad <= 0.58)) { manejable = false; }
                    }
                    Console.WriteLine("Probabilidad " + probabilidad.ToString());
                }
            }




            int id = listaIdTransaccion.Count+1;

            if (manejable && stock)
            {
                Transaccion transaccion = new Transaccion(id, cliente,
                    vehiculo, sucursal, listaAccesorioArrendar,precio,tiempoArriendo);

                listaTransacciones.Add(transaccion);
                listaIdTransaccion.Add(id);
                Console.WriteLine("Transaccion Exitosa!...");
                ImprimirTransacciones();
                Console.ReadKey();
                //return transaccion;

            }
            else
            {
                Transaccion transaccion = new Transaccion(id, cliente,
                 vehiculo, sucursal, listaAccesorioArrendar, precio,tiempoArriendo);

                Console.WriteLine("Transaccion Fallida!...");
                Console.ReadKey();
                //return transaccion;
            }

        }


        public void CommandInterface()
        {
            List<int> opcionesValidas = new List<int>() { 1, 2, 3, 4, 5, 6 };
            //Console.Clear();
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
                inicioOP1:
                Console.Write("ID Cliente >: ");
                string id = Console.ReadLine();
                Cliente cliente = listaClientes.Find(x => x.id == id);

                if (!listaClientes.Contains(cliente))
                {
                    Console.WriteLine("No existe cliente con ese id\nGenerar un nuevo cliente\n");
                    CrearCliente();
                    goto inicioOP1;
                }

                RealizaTransaccion(cliente);



            }

            if (op == 2) { CrearCliente(); }

            if(op == 3) { CrearVehiculo(); }


            if (op == 4) { CrearAccesorio(); }
            if (op == 5) { CrearSucursal(); }





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
                "\t(2) Institucion\n" +
                "\t(3) Empresa\n" +
                "\t(4) Organizacion\n" +
                "\t>: ");

            List<int> opciones = new List<int>() { 1, 2, 3, 4 };
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

            else if (tipoCliente == 2)
            {
                Institucion cliente = new Institucion(id, listaPermisos);
                listaClientes.Add(cliente);
            }
            else if (tipoCliente == 3)
            {
                Empresa cliente = new Empresa(id, listaPermisos);
                listaClientes.Add(cliente);
            }
            else if (tipoCliente == 4)
            {
                Organizacion cliente = new Organizacion(id, listaPermisos);
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
        public void CrearAccesorio()
        {
            Console.WriteLine("--Crear nuevo Accesorio--\n");
            Console.Write("\nID Accesorio >: ");
            string id = Console.ReadLine();

            Console.Write("Precio >: ");
            int precio = Convert.ToInt32(Console.ReadLine());

            listaAccesorios.Add(new Accesorio(id, precio));
            Console.WriteLine("Accesorio Añadido Exitosamente");
            return;
        }


        public void CrearSucursal()
        {
            Console.WriteLine("--Crear nueva Sucursal--\n");
            Console.Write("\nID Sucursal >: ");
            string id = Console.ReadLine();


            ImprimirVehiculos();

            List<Vehiculo> listaVehiculosSucursal = new List<Vehiculo>();
            Console.WriteLine("Introduce ID Vehiculo: ");
            Dictionary<Vehiculo, int> dictVehiculoStock = new Dictionary<Vehiculo, int>();

            while (true)
            {
                errorVehiculo:
                Console.Write(">: ");
                string idVehiculo = Console.ReadLine();
                if (idVehiculo == "0") { break; }
                Vehiculo vehiculo = listaVehiculos.Find(x => x.id == idVehiculo);
                if (vehiculo == null) { Console.WriteLine("Invalido, Introduce nuevamente"); goto errorVehiculo; }
                listaVehiculosSucursal.Add(vehiculo);
                Console.Write("Introduce Stock >: ");
                int cant = Convert.ToInt32(Console.ReadLine());
                dictVehiculoStock.Add(vehiculo, cant);
            }


            listaSucursal.Add(new Sucursal(id, listaVehiculosSucursal, dictVehiculoStock));
            
            return;
        }




        public void Imprimir()
        {
            Console.Clear();
            Console.WriteLine("Seleccione una opcion pra ver:\n" +
                "\t(1) Clientes\n" +
                "\t(2) Vehiculos\n" +
                "\t(3) Transacciones\n" +
                "\t(4) Sucursales\n" +
                "");
            Console.Write("opcion >: ");
            string opcion = Console.ReadLine();

            if (opcion == "1") { ImprimirClientes(); }
            else if (opcion == "2") { ImprimirVehiculos(); }
            else if (opcion == "3") { ImprimirTransacciones(); }
            else if (opcion == "4") { ImprimirSucursales(); }


        }




        public void ImprimirSucursales()
        {
            Console.WriteLine("--Mostrando Sucursales--");
            foreach(Sucursal sucursal in listaSucursal)
            {
                Console.WriteLine($"ID: {sucursal.id}");
            }
        }
        public void ImprimirClientes()
        {
            //Console.Clear();
            Console.WriteLine("--Mostrando Clientes--");
            foreach (Cliente cliente in listaClientes)
            {
                string stringPermisos = "";
                foreach(string permiso in cliente.listaPermisos) { stringPermisos += " "+permiso; }
                Console.WriteLine($"ID: {cliente.id}, Permisos: {stringPermisos}");
            }
            //Console.Write("Enter para continar...");
            //Console.ReadKey();
        }
        public void ImprimirVehiculos()
        {
            //Console.Clear();
            Console.WriteLine("--Mostrando Vehiculos--");
            foreach(Vehiculo vehiculo in listaVehiculos)
            {
                Console.WriteLine($"ID: {vehiculo.id} Permiso: {vehiculo.tipoVehiculo}" +
                    $" Precio: {vehiculo.precio}");
            }
            //Console.Write("Enter para continar...");
            //Console.ReadKey();
        }
        public void ImprimirAccesorios()
        {
            Console.WriteLine("--Mostrando Accesorios--");

            foreach (Accesorio accesorio in listaAccesorios)
            {
                Console.WriteLine($"ID Accesorio: {accesorio.id} Precio: {accesorio.precio}");
            }
        }

        public void ImprimirTransacciones()
        {
            Console.WriteLine("--Mostrando Transacciones--");
            foreach(Transaccion transaccion in listaTransacciones)
            {
                Console.WriteLine($"ID: {transaccion.id}\tFecha Transaccion: {transaccion.fechaInicioTransaccion.ToString()}\tFecha Termino Arriendo: {transaccion.fechaInicioTransaccion.AddDays(transaccion.tiempoArriendo).ToString()}" +
                    $"\n\tCliente:" +
                    $" {transaccion.cliente.id} Sucursal: {transaccion.sucursal.id}\n" +
                    $"\tVehiculo: {transaccion.vehiculo.id}");

                int c = 0;
                    foreach(Accesorio accesorio in transaccion.listaAccesorio)
                {
                    c++;
                    Console.WriteLine($"\t\tID Accesorio ({c}): {accesorio.id}");

                }

                Console.WriteLine($"\tPrecio: { transaccion.precio}");


                Console.WriteLine();
            }
            Console.ReadKey();

        }


    }
}
