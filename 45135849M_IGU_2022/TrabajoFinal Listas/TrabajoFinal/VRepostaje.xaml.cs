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
using System.Text.RegularExpressions;

namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para VRepostaje.xaml
    /// </summary>
    public partial class VRepostaje : Window
    {
        ObservableCollection<Datos> datos;
        MainWindow mw;
        public VRepostaje(ObservableCollection<Datos> dat,MainWindow m)

        {
            InitializeComponent();
            datos = dat;
   
            listamat.ItemsSource = datos;
            mw = m;
      

        }

        private void listamat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Añadir_Click(object sender, RoutedEventArgs e)
        {
            if(listamat.SelectedItem != null)
            {
                //Declaramos las variables necesarias 
                int i;
                int cont = 0;
                int NKM = 0;
                float Litros = 0;
                float Coste = 0;
                float NKMf = 0;
                string[] temp = new string[3];
                //Comprobamos que no haya ninguna textbox vacía
                if (NKMBox.Text.Length == 0 || LitrosBox.Text.Length == 0 || CosteBox.Text.Length == 0 || FechaBox.Text.Length == 0)
                {
                    MessageBox.Show("algún dato está vacío");
                }
                //Si no esta vacía convertimos los datos q nos han dado y comprobamos que sean correctos
                else
                {
                    string[] temporal = datos[listamat.SelectedIndex].Matricula.Split('\u002D');
                    int f = 0;
                    Matricula m = new Matricula("0000", "ZZZ");
                    try
                    {

                        m = new Matricula(temporal[0], temporal[1]);
                        try
                        {
                            Regex rx = new Regex(@"^\d{4}$");
                            Regex rx2 = new Regex(@"\b[*WRTYPSDFGHJKLZXCVBNM*]{3}\b");
                            if (rx2.IsMatch(temporal[1]))
                            {
                                if (rx.IsMatch(temporal[0]))
                                {

                                    m = new Matricula(temporal[0], temporal[1]);
                                    string hm = m.TostringGuion();
                                }
                                else
                                {
                                    MessageBox.Show("El número de la matricula debe tener 4 digitos");
                                    f = 1;
                                    
                                }
                            }
                            else
                            {
                                MessageBox.Show("Solo puede tener 3 dígitos las letras de la matricula y en mayúscula");
                                f = 1;
                            
                            }


                        }
                        catch (FormatException)
                        {
                            f = 1;
                            MessageBox.Show("Matricula mal formada ");
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        f = 1;
                        MessageBox.Show("Matricula formada sin guión");
                    }
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
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("dato mal introducido en num km");
                            NKMBox.Background = Brushes.Red;
                        }
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Los litros son demasiados");
                        NKMBox.Background = Brushes.Red;
                    }

                    try { 
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
                        catch (OverflowException)
                        {
                            MessageBox.Show("El coste es demasiado");
                            CosteBox.Background = Brushes.Red;
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("dato mal introducido en Coste");
                        CosteBox.Background = Brushes.Red;
                    }

                        if (NKM == 0 || Litros == 0 || Coste == 0)
                        {

                            MessageBox.Show("Alguno de sus datos ha sido mal introducido");
                        }
                        else
                        {
                            DateTime? Fecha = FechaBox.SelectedDate;

                            cont = 0;
                            int contar = 0;
                        //Si tenemos su nombre acabamos el bucle y añadimos en la colección de repostajes este nuevo repostaje
                        Datos datos2;
                        Repostaje report;
                        for (i = 0; i < datos.Count; i++)
                        {
                            
                            if (datos[listamat.SelectedIndex].Matricula == datos[i].Matricula)
                            {
                                if (datos[i].Kilometrajet < NKM && datos[i].Repostajes[datos[i].Repostajes.Count - 1].Fecha < Fecha)
                                {

                                    report = new Repostaje(Fecha, NKM, Litros, Coste);
                                    datos[i].Repostajes.Add(report);
                                    NKMf = NKM;
                                     datos2= new Datos(m, datos[i].Marca, NKMf, datos[i].MediaLitros, datos[i].MediaCoste, datos[i].Repostajes, cont);
                                    datos[i].MediaLitros = datos2.MediaLitros;
                                    datos[i].MediaCoste = datos2.MediaCoste;
                                    datos[i].Kilometrajet = datos2.Kilometrajet;
                                    ActualizartablasEventArgs act = new ActualizartablasEventArgs();
                                    mw.OnActualizartablas(act);                                   
                                    this.Close();

                                }else if(datos[i].Kilometrajet < NKM && datos[i].Repostajes[datos[i].Repostajes.Count - 1].Fecha == Fecha)
                                { 
                                        
                                    report = new Repostaje(Fecha, NKM, Litros, Coste);
                                    datos[i].Repostajes.Add(report);
                                    NKMf = NKM;
                                    datos2 = new Datos(m, datos[i].Marca, NKMf, datos[i].MediaLitros, datos[i].MediaCoste, datos[i].Repostajes, cont);
                                    datos[i].MediaLitros = datos2.MediaLitros;
                                    datos[i].MediaCoste = datos2.MediaCoste;
                                    datos[i].Kilometrajet = datos2.Kilometrajet;
                                    ActualizartablasEventArgs act = new ActualizartablasEventArgs();
                                    mw.OnActualizartablas(act);
                                    this.Close();

                                }
                                else
                                {
                                    MessageBox.Show("Fecha o kilometros erróneos");
                                }

                                i = 1000;
                                cont = 1000;
                            }
                        }
                    }

                }            

            }
            
        }
    }
}
