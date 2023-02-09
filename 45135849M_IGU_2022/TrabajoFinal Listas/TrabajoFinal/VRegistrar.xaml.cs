using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para VRegistrar.xaml
    /// </summary>
    public partial class VRegistrar : Window
    {
        int MAX = 100;
        public VRegistrar()
        {
            InitializeComponent();
        }

        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            string[] linea2 = new string[MAX];
            string[] palabra = new string[3];
            string ayuda;
            int flag1=0,flag2=0;
            linea2 = File.ReadAllLines("Usuarios.txt");
            for(int i=0;i<linea2.Length;i++)
            {
                
                palabra = linea2[i].Split('\u002C');
           
                if (palabra[0] == NombreTBX.Text)
                {
                    flag1 = 1;
                }
                ayuda = palabra[2] ;
              
                if (ayuda == BDTBX.Text + ".txt")
                {
                    flag2 = 1;
                }
            }
            if (flag1 == 0)
            {
                NombreTBX.Background = Brushes.Green;
            }
            if (flag2 == 0)
            {
                BDTBX.Background = Brushes.Green;
            }
            if (flag1 == 0 && flag2==0) {
                string linea = NombreTBX.Text + "," + ContraseñaTBX.Text + "," + BDTBX.Text + ".txt"+",";
                StreamWriter agregar = File.AppendText("Usuarios.txt");
                agregar.WriteLine(linea);
                agregar.Close();
                this.Close();
            }
            if (flag1 == 1)
            {
                NombreTBX.Background = Brushes.Red;
            }
            if (flag2 == 1)
            {
                BDTBX.Background = Brushes.Red;
            }


        }
    }
}
