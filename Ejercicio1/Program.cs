using Ejercicio1;
using System.Text.RegularExpressions;


    class Program
    {
        static void Main()
        {
            GestorDeContactos gestor = new GestorDeContactos();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("Menu de Contactos:");
                Console.WriteLine("1. Agregar contacto");
                Console.WriteLine("2. Buscar contacto");
                Console.WriteLine("3. Listar contactos");
                Console.WriteLine("4. Eliminar contacto");
                Console.WriteLine("5. Salir");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        AgregarContacto(gestor);
                        break;
                    case "2":
                        BuscarContacto(gestor);
                        break;
                    case "3":
                        ListarContactos(gestor);
                        break;
                    case "4":
                        EliminarContacto(gestor);
                        break;
                    case "5":
                        salir = true;
                        gestor.GuardarContactos();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
            }
        }

        static void AgregarContacto(GestorDeContactos gestor)
        {
            Contacto nuevoContacto = new Contacto();

            while (true)
            {
                Console.Write("Nombre: ");
                nuevoContacto.Nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nuevoContacto.Nombre) || nuevoContacto.Nombre.Length < 3)
                {
                    Console.WriteLine("El nombre debe tener al menos 3 caracteres.");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Telefono: ");
                nuevoContacto.Telefono = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nuevoContacto.Telefono) || !Regex.IsMatch(nuevoContacto.Telefono, @"^\d+$"))
                {
                    Console.WriteLine("El telefono debe ser solo numerico.");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Email: ");
                nuevoContacto.Email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nuevoContacto.Email) || nuevoContacto.Email.Length < 3)
                {
                    Console.WriteLine("El email debe tener al menos 3 caracteres.");
                }
                else
                {
                    break;
                }
            }

            gestor.AgregarContacto(nuevoContacto);
            Console.WriteLine("Contacto agregado.");
        }

        static void BuscarContacto(GestorDeContactos gestor)
        {
            Console.Write("Ingrese nombre o telefono para buscar: ");
            string criterio = Console.ReadLine();

            var resultados = gestor.BuscarContacto(criterio);

            if (resultados.Any())
            {
                foreach (var contacto in resultados)
                {
                    Console.WriteLine(contacto);
                }
            }
            else
            {
                Console.WriteLine("No se encontraron contactos.");
            }
        }

        static void ListarContactos(GestorDeContactos gestor)
        {
            var contactos = gestor.ListarContactos();

            if (contactos.Any())
            {
                foreach (var contacto in contactos)
                {
                    Console.WriteLine(contacto);
                }
            }
            else
            {
                Console.WriteLine("No hay contactos para mostrar.");
            }
        }

        static void EliminarContacto(GestorDeContactos gestor)
        {
            Console.Write("Ingrese el ID del contacto a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (gestor.EliminarContacto(id))
                {
                    Console.WriteLine("Contacto eliminado.");
                }
                else
                {
                    Console.WriteLine("Contacto no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID no valido.");
            }
        }
    }