using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen
{
    internal class Producto
    {
        //Declaracion de la lista que ultizaremos para almacenamiento y procesos
        static List<Producto> inventario = new List<Producto>();
        static int contadorId = 1; // Id autoincrementable

        //atributos que definimos en esta clase de producto
        // { get; set;} es la forma corta de asignar las porpiedades de get y set
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        // Método para devolver el detalle del producto
        public string ObtenerDetalle()
        {
            return $"[{Id}] {Nombre} - ${Precio} (Stock: {Stock})";
        }

        //Metodo de añadr un producto nuevo
        public static void AgregarProducto()
        {
            Console.WriteLine("\n--- AGREGAR PRODUCTO ---");

            // Nombre y validacion de entrada
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }

            // Precio (validación con decimal.TryParse y mayor a cero)
            decimal precio;
            Console.Write("Precio: ");
            while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
            {
                Console.Write("Precio NO valido. Debe ser un número mayor a cero: ");
            }

            // Stock (validación con int.TryParse y mayor a cero)
            int stock;
            Console.Write("Stock: ");
            while (!int.TryParse(Console.ReadLine(), out stock) || stock <= 0)
            {
                Console.Write(" Debe ser un número entero mayor a cero");
            }

            // Crear y añadir el producto nuevo
            Producto nuevo = new Producto
            {
                Id = contadorId++,
                Nombre = nombre,
                Precio = precio,
                Stock = stock
            };

            inventario.Add(nuevo);
            Console.WriteLine($"Producto agregado correctamente, Id: {nuevo.Id}.");
        }

        public static void MostrarProductos()
        {
            Console.WriteLine("\n--- LISTA DE PRODUCTOS ---");

            if (inventario.Count == 0)
            {
                Console.WriteLine("La lista está vacía. No hay productos registrados.");
                return;
            }

            foreach (Producto p in inventario)
            {
                Console.WriteLine(p.ObtenerDetalle());
            }
        }

        public static void ProductoPorNombre()
        {
            Console.WriteLine("\n--- BUSCAR PRODUCTO ---");
            Console.Write("Ingrese el nombre o parte del nombre a buscar: ");
            string busqueda = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(busqueda))
            {
                Console.WriteLine("Debe ingresar un texto para buscar.");
                return;
            }

            // Búsqueda ignorando mayúsculas/minúsculas y coincidencias parciales
            var resultados = inventario
                .Where(p => p.Nombre.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine($"No se encontraron productos que contengan \"{busqueda}\".");
            }
            else
            {
                Console.WriteLine($"\nSe encontraron {resultados.Count} coincidencia(s):");
                foreach (Producto p in resultados)
                {
                    Console.WriteLine(p.ObtenerDetalle());
                }
            }
        }

        public static void ValorTotal()
        {
            Console.WriteLine("\n--- VALOR TOTAL DEL INVENTARIO ---");

            if (inventario.Count == 0)
            {
                Console.WriteLine("La lista está vacía. El valor total es $0.");
                return;
            }

            decimal total = 0;
            foreach (Producto p in inventario)
            {
                total += p.Precio * p.Stock;
            }

            Console.WriteLine($"El valor total del inventario es: ${total}");
        }
    }
}
