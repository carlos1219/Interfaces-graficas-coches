using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinal
{
    public class Productos
    {
        public string Precio { get; set; }
        public string Archivo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }


    }
    public class Producto
    {
        public string Precio { get; set; }
        public string Archivo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public Producto(string precio,  string nombre, int cantidad)
        {
            Precio = precio;
           
            Nombre = nombre;
            Cantidad = cantidad;
        }
    }
}
