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
using System.Collections.ObjectModel;

namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para VModificarR.xaml
    /// </summary>
    /// 
    public class NotificarVMEventArgs : EventArgs
    {
        public NotificarVMEventArgs()
        {

        }
    }

    public partial class VModificarR : Window
    {
        ObservableCollection<Repostaje> repostaje;
        public event EventHandler<NotificarVMEventArgs> NotificarVM;
        string matricula;
        string marca;
        Datos datos2;
        public VModificarR(ObservableCollection<Repostaje> repost,String mat,String mar)
        {
            InitializeComponent();
            repostaje = repost;
            listarepost.Items.Add(repostaje[repostaje.Count-1]);
            matricula = mat;
            marca = mar;
        }
        public Datos pasadatos
        {
            get { return datos2; }
        }

        void OnNotificarVm(NotificarVMEventArgs e)
        {
            if (NotificarVM != null)
            {
                NotificarVM(this, e);
            }
        }

        private void ModificarR_Click(object sender, RoutedEventArgs e)
        {
            if (listarepost != null)
            {
                for (int i = 0; i < repostaje.Count; i++)
                {
                    if (i == repostaje.Count-1)
                    {
                        float NKM = 0;
                        float Litros = 0;
                        float Coste = 0;
                        string[] temp = new string[3];
                        //Comprobamos que no haya ninguna textbox vacía
                        if ( NKMBox.Text.Length == 0 || LitrosBox.Text.Length == 0 || CosteBox.Text.Length == 0 || FechaBox.Text.Length == 0)
                        {
                            MessageBox.Show("algún dato está vacío");
                        }
                        //Si no esta vacía convertimos los datos q nos han dado y comprobamos que sean correctos
                        else
                        { 
                            try
                            {
                                try
                                {
                                    NKM = Convert.ToInt32(NKMBox.Text);
                                    NKMBox.Background = Brushes.Green;
                                    if (NKM > 1000000)
                                    {
                                        NKM = 0;
                                        MessageBox.Show("Su coche tiene demasiados kilometros");
                                        NKMBox.Background = Brushes.Red;
                                    }
                                }
                                catch (OverflowException)
                                {
                                    MessageBox.Show("Los litros son demasiados");
                                    NKMBox.Background = Brushes.Red;
                                }
                            }
                            catch (FormatException)
                            {
                                NKMBox.Background = Brushes.Red;
                                MessageBox.Show("dato mal introducido en num km");
                            }

                            try
                            {
                                try
                                {
                                    Litros = float.Parse(LitrosBox.Text);
                                    LitrosBox.Background = Brushes.Green;
                                    if (Litros > 1500)
                                    {
                                        Litros = 0;
                                        MessageBox.Show("Los litros son demasiados");
                                        LitrosBox.Background = Brushes.Red;
                                    }
                                }
                                catch (FormatException)
                                {
                                    MessageBox.Show("dato mal introducido en Litros");
                                    LitrosBox.Background = Brushes.Red;
                                }
                            }
                            catch (OverflowException)
                            {
                                MessageBox.Show("Los litros son demasiados");
                                LitrosBox.Background = Brushes.Red;
                            }
                            try
                            {
                                try
                                {
                                    float layuda = (Litros * 3);
                                    Coste = float.Parse(CosteBox.Text);
                                    CosteBox.Background = Brushes.Green;
                                    if (Coste > 3000 || layuda < Coste)
                                    {
                                        Coste = 0;
                                        MessageBox.Show("El coste es excesivo");
                                        CosteBox.Background = Brushes.Red;
                                    }
                                }
                                catch (FormatException)
                                {
                                    MessageBox.Show("dato mal introducido en Coste");
                                    CosteBox.Background = Brushes.Red;
                                }
                            }
                            catch (OverflowException)
                            {
                                MessageBox.Show("El coste es demasiado");
                                CosteBox.Background = Brushes.Red;
                            }
                            if (NKM == 0 || Litros == 0 || Coste == 0)
                            {

                                MessageBox.Show("Alguno de sus datos ha sido mal introducido");
                            }
                            else
                            {
                               

                                
                                string[] temporal = matricula.Split('\u002D');
                                Matricula m = new Matricula(temporal[0], temporal[1]);
                                DateTime? Fecha = FechaBox.SelectedDate;
                                if (repostaje[repostaje.Count-1].Kilometraje < NKM && repostaje[repostaje.Count - 1].Fecha < Fecha)
                                {                        
                                    repostaje[i].Fecha = Fecha;
                                    repostaje[i].Litros = Litros;
                                    repostaje[i].Costes = Coste;
                                    repostaje[i].Kilometraje = NKM;
                                    datos2 = new Datos(m, marca, NKM, 0, 0,repostaje, 0);
                                    NotificarVMEventArgs vm = new NotificarVMEventArgs();
                                    OnNotificarVm(vm);
                                    this.Close();
                                }
                                else if (repostaje[repostaje.Count - 1].Kilometraje < NKM && repostaje[repostaje.Count - 1].Fecha == Fecha)
                                {
                                    repostaje[i].Fecha = Fecha;
                                    repostaje[i].Litros = Litros;
                                    repostaje[i].Costes = Coste;
                                    repostaje[i].Kilometraje = NKM;
                                    datos2 = new Datos(m, marca, NKM, 0, 0, repostaje, 0);
                                    NotificarVMEventArgs vm = new NotificarVMEventArgs();
                                    OnNotificarVm(vm);
                                    this.Close();
                                }else if(repostaje[repostaje.Count - 1].Kilometraje <= NKM && repostaje[repostaje.Count - 1].Fecha <= Fecha)
                                {
                                    if(repostaje[repostaje.Count - 1].Litros <= Litros)
                                    {
                                        repostaje[i].Fecha = Fecha;
                                        repostaje[i].Litros = Litros;
                                        repostaje[i].Costes = Coste;
                                        repostaje[i].Kilometraje = NKM;
                                        datos2 = new Datos(m, marca, NKM, 0, 0, repostaje, 0);
                                        NotificarVMEventArgs vm = new NotificarVMEventArgs();
                                        OnNotificarVm(vm);
                                        this.Close();
                                    }else if (repostaje[repostaje.Count - 1].Costes <= Coste)
                                    {
                                        repostaje[i].Fecha = Fecha;
                                        repostaje[i].Litros = Litros;
                                        repostaje[i].Costes = Coste;
                                        repostaje[i].Kilometraje = NKM;
                                        datos2 = new Datos(m, marca, NKM, 0, 0, repostaje, 0);
                                        NotificarVMEventArgs vm = new NotificarVMEventArgs();
                                        OnNotificarVm(vm);
                                        this.Close();
                                    }
                                }

                    }   }   }
                }

            }
        }

        private void listarepost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
               
                    FechaBox.Text = repostaje[repostaje.Count-1].Fecha.ToString();
                    LitrosBox.Text = repostaje[repostaje.Count-1].Litros.ToString();
                    CosteBox.Text = repostaje[repostaje.Count-1].Costes.ToString();
                    NKMBox.Text = repostaje[repostaje.Count-1].Kilometraje.ToString();
                
        }
    }
}
