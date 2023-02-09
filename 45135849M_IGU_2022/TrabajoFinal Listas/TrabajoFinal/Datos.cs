using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;

namespace TrabajoFinal
{
    public class Datos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public float Kilometrajet { get; set; }
        public float MediaLitros { get; set; }
        public float MediaCoste { get; set; }
        public double MediaCompra { get; set; }
        public ObservableCollection<Repostaje> Repostajes { get; set; }
        public int contador { get; set; }
           
        
        public Datos(Matricula m, string ma,float nkm, float Medialitros, float Mediacoste, ObservableCollection<Repostaje> repost,int cont)
        {
            Matricula = m.TostringGuion();
            Marca = ma;
            Kilometrajet = nkm;
           
            MediaCoste = calcularMediaCoste(repost);
            MediaLitros = calcularMedialitros(repost);
            contador = cont;
            Repostajes = repost;

        }
        public Datos(Matricula m, string ma, float nkm, float Medialitros, float Mediacoste, ObservableCollection<Repostaje> repost)
        {
            Matricula = m.TostringGuion();
            Marca = ma;
            Kilometrajet = nkm;
            MediaCoste = Mediacoste;
            Repostajes = repost;
            MediaLitros = Medialitros;
           

        }
        public override string ToString()
            {
                return Matricula + ' ' + Marca ;
            }

         public String ToStringComas()
        {
            return Matricula + '.' + Marca + "." ;
        }

        private float calcularMedialitros(ObservableCollection<Repostaje> repost)
        {
            int i;
            int cont = repost.Count ;
            float ml=0,total=0;
            float temp=0;
            for (i = 0; i < cont-1; i++)
            {
                temp = repost[i].Litros+temp;
            }
            if (cont-1 >= 0)
            {
                total = repost[cont - 1].Kilometraje - repost[0].Kilometraje;
                ml = (temp * 100) / total;
            }

            
            return ml;
        }
        
    private float calcularMediaCoste(ObservableCollection<Repostaje> repost)
    {
        int i;
        int cont = repost.Count;
        float mc = 0, total = 0;
        float temp = 0;
        string prueba, prueba2;
        prueba = Convert.ToString(cont);


        for (i = 0; i < cont - 1; i++)
        {
            temp = repost[i].Costes + temp;
        }
        prueba2 = Convert.ToString(temp);

        if(cont-1 >= 0)
            {
                total = repost[cont - 1].Kilometraje - repost[0].Kilometraje;
                prueba = Convert.ToString(total);

                mc = (temp * 100) / total;
            }


        return mc;
    }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
               new PropertyChangedEventArgs(propertyName));
        }
    }
  

}

