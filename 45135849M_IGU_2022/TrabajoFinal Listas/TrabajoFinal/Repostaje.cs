using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TrabajoFinal
{
    public class Repostaje : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DateTime? Fecha { get; set; }
        public float Kilometraje { get; set; }

        public float Litros { get; set; }

        public float Costes { get; set; }

        public float Kilometrajet { get; set; }
        public double Preciot { get; set; }


        public Repostaje(DateTime? fecha, float kilometros, float litros, float Coste)
        {
            Fecha = fecha;
            Kilometraje = kilometros;
            Litros = litros;
            Costes = Coste;
        }
        public Repostaje(DateTime? fecha, float kilometros, int litros, int Coste, double precio)
        {
            Fecha = fecha;
            Kilometraje = kilometros;
            Litros = litros;
            Costes = Coste;
            Preciot = precio;
        }
        public override string ToString()
        {
            return   Fecha + " " + Kilometraje + " " + Litros + " " + Costes;
        }

        public String ToStringComas()
        {
            return Fecha + "." + Kilometraje + "." + Litros + "." + Costes;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
               new PropertyChangedEventArgs(propertyName));
        }
    }
}
