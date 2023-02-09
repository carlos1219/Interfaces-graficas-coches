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
    /// Lógica de interacción para login.xaml
    /// </summary>
    
    public partial class login : Window
    {
        int MAX = 100;
        public login()
        {
            InitializeComponent();
        }

        private void Iniciar_Sesión_Click(object sender, RoutedEventArgs e)
        {
            int flag = 0;
            string[] linea = new string[MAX];
            string[] palabra = new string[3];
            linea = File.ReadAllLines("Usuarios.txt");
            for (int k = 0; k < linea.Length; k++)
            {
                palabra = linea[k].Split('\u002C');
                if (NombreTBX.Text == palabra[0] && ContraseñaTBX.Text == palabra[1])
                {
                    MainWindow mw = new MainWindow(palabra[2], palabra[0], palabra[1]);
                    mw.Show();
                    this.Close();
                    flag= 1;
                }
            }
            if (flag == 0)
            {
                MessageBox.Show("El usuario y la contraseña no concuerdan");
            }
        }

        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            VRegistrar r = new VRegistrar();
            r.ShowDialog();

        }
    }
}
