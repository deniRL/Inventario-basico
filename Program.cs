using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace examen
{
    internal class Program
    {
        static void OpMostrarMenu()
        {
            Console.WriteLine("--- MENÚ DE INVENTARIO ---");
            Console.Write("Escoge una opción: ");
            Console.WriteLine("\n1. Agregar producto");
            Console.WriteLine("2. Mostrar todos los productos");
            Console.WriteLine("3. Buscar producto por nombre");
            Console.WriteLine("4. Calcular valor total del inventario");
            Console.WriteLine("5. Salir");
        }
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                OpMostrarMenu();
                int opcion = LeerOpMenu();
                //llama a cada metodo desde la clase producto : Producto.metodo();
                switch (opcion)
                {
                    case 1:
                  
                        Producto.AgregarProducto();
                        break;
                    case 2:
                        Producto.MostrarProductos();
                        break;
                    case 3:
                        Producto.ProductoPorNombre();
                        break;
                    case 4:
                        Producto.ValorTotal();
                        break;
                    case 5:
                        Console.WriteLine("\nGracias por usar el sistema de inventario");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("\n Opcion no valida Intente nuevamente.");
                        break;
                }
                // si el usuario no escoge salir , presionar otra tecla para seguir conotras opciones
                if (!salir)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }

        // valida la opción del menú con .Tryparse()
        static int LeerOpMenu()
        {
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.Write("Opcion NO valida. Inserta un número del 1-5\n");
            }
            return opcion;
        }
        
    }
}