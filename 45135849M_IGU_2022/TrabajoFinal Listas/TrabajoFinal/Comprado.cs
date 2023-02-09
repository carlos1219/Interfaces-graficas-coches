using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TrabajoFinal
{
    public class Comprado
    {
        public double Preciototal { get; set; }
        public  ObservableCollection<Producto> Producto { get; set; }

        public Comprado(ObservableCollection<Producto> producto, double preciot)
        {
            string[] n = new string[2];
            double f;
           
            for (int i = 0; i<producto.Count; i++)
            {
                n = producto[i].Precio.Split('\u0020');
                f = double.Parse(n[0]);
                preciot =  (f* producto[i].Cantidad)+preciot;
            }
            Producto= producto;
            Preciototal= preciot;
        }
    }
}
