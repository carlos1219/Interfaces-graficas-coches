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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para VCoches.xaml
    /// </summary>

    public partial class VCoches : Window
    {
        ObservableCollection<Datos> datos;
        public List<String> marcas = new List<string>()
        {
            "Alfa Romeo","alfa romeo","Alfa romeo","Aston Martin","aston martin","Audi","audi","BMW","bmw","Citroen","citroen","Cupra","cupra","Dacia","dacia","ds","Ds","Ferrari","ferrari","Ford","ford","Honda","honda","Hyundai","hyundai","jaguar","Jaguar","Jeep","jeep","Kia","kia","Mazda","mazda","Mercedes","mercedes","Mini","mini","Mitsubishi","mitsubishi","Nissan","nissan","Opel","opel","Peugeot","peugeot","Renault","renault","Seat","seat","Tesla","tesla","Volkswagen","volkswagen","Volvo","volvo"
        };
   
        public VCoches( ObservableCollection<Datos> dat)
        {
            InitializeComponent();
            datos = dat;
        }

        private void Añadir_Click(object sender, RoutedEventArgs e)
        {
            //Declaramos las variables necesarias 
            int i, G = 0;
            int cont = 0;
            int NKM = 0;
            float Litros = 0;
            float Coste = 0;
            float NKMf = 0, MediaLitros = 0, MediaCoste = 0;
            string[] temp = new string[3];
            //Comprobamos que no haya ninguna textbox vacía
            if (MatrículaBox.Text.Length == 0 || MarcaBox.Text.Length == 0 || NKMBox.Text.Length == 0 || LitrosBox.Text.Length == 0 || CosteBox.Text.Length == 0 || FechaBox.Text.Length == 0)
            {
                MessageBox.Show("algún dato está vacío");
            }
            //Si no esta vacía convertimos los datos q nos han dado y comprobamos que sean correctos
            else
            {
                string[] temporal = MatrículaBox.Text.Split('\u002D');
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
                                MatrículaBox.Background = Brushes.Green;
                            }
                            else
                            {
                                MessageBox.Show("El número de la matricula debe tener 4 digitos");
                                f = 1;
                                MatrículaBox.Background = Brushes.Red;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Solo puede tener 3 dígitos las letras de la matricula y en mayúscula");
                            f = 1;
                            MatrículaBox.Background = Brushes.Red;
                        }


                    }
                    catch (FormatException)
                    {
                        f = 1;
                        MessageBox.Show("Matricula mal formada ");
                        MatrículaBox.Background = Brushes.Red;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    f = 1;
                    MessageBox.Show("Matricula formada sin guión");
                    MatrículaBox.Background = Brushes.Red;
                }

                for (i = 0; i < marcas.Count; i++)
                {
                    if (marcas[i] == MarcaBox.Text)
                    {
                        G = 1;
                        MarcaBox.Background = Brushes.Green;
                    }
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
                    MessageBox.Show("Los litros son demasiados");
                    CosteBox.Background = Brushes.Red;
                }
                if (NKM == 0 || Litros == 0 || Coste == 0 || f != 0)
                {

                    MessageBox.Show("Alguno de sus datos ha sido mal introducido");
                }
                else if (G == 0)
                {
                    MessageBox.Show("Marca desconocida introduza una más conocida");
                    MarcaBox.Background = Brushes.Red;
                }
                else
                {
                    DateTime? Fecha = FechaBox.SelectedDate;

                    cont = 0;
                    int contar = 0;
                    //Comprobamos si nuestra lista está vacia si es asi añadimos el primer parámetro, si no está vacia comprobamos si está su nombre 
                    if (datos.Count == 0)
                    {
                        Repostaje report = new Repostaje(Fecha, NKM, Litros, Coste);
                        ObservableCollection<Repostaje> repostaje = new ObservableCollection<Repostaje>();
                        repostaje.Add(report);

                        String texto = report.ToString();


                        contar = 0;
                        NKMf = NKM;
                        Datos tempdatos = new Datos(m, MarcaBox.Text, NKMf, MediaLitros, MediaCoste, repostaje);
                        datos.Add(tempdatos);
                        this.Close();


                    }
                    else
                    {
                        //Si tenemos su nombre acabamos el bucle y añadimos en la colección de repostajes este nuevo repostaje
                        for (i = 0; i < datos.Count; i++)
                        {
                            if (m.TostringGuion() == datos[i].Matricula && MarcaBox.Text == datos[i].Marca)
                            {

                                if (datos[i].Kilometrajet < NKM && datos[i].Repostajes[datos[i].Repostajes.Count - 1].Fecha < Fecha)
                                {
                                    Repostaje report = new Repostaje(Fecha, NKM, Litros, Coste);
                                    datos[i].Repostajes.Add(report);
                                    NKMf = NKM;

                                    Datos datos2 = new Datos(m, datos[i].Marca, NKMf, datos[i].MediaLitros, datos[i].MediaCoste, datos[i].Repostajes, cont);

                                    datos[i].MediaLitros = datos2.MediaLitros;

                                    datos[i].MediaCoste = datos2.MediaCoste;
                                    datos[i].Kilometrajet = datos2.Kilometrajet;
                                    this.Close();




                                }
                                else if (datos[i].Kilometrajet > NKM && datos[i].Repostajes[datos[i].Repostajes.Count - 1].Fecha > Fecha)
                                {
                                    Repostaje report = new Repostaje(Fecha, NKM, Litros, Coste);

                                    NKMf = NKM;
                                    string[] lp = datos[i].Matricula.Split('\u002D');
                                    Matricula mat = new Matricula(lp[0], lp[1]);

                                    Datos datos2 = new Datos(mat, datos[i].Marca, NKMf, datos[i].MediaLitros, datos[i].MediaCoste, datos[i].Repostajes, cont);

                                    datos[i].MediaLitros = datos2.MediaLitros;

                                    datos[i].MediaCoste = datos2.MediaCoste;
                                    datos[i].Kilometrajet = datos2.Kilometrajet;
                                    datos[i].Repostajes.Add(report);
                                    this.Close();

                                }
                                else
                                {
                                    MessageBox.Show("Fecha o kilometros erróneos");
                                }

                                i = 1000;
                                cont = 1000;
                            }
                            else if (m.TostringGuion() == datos[i].Matricula && MarcaBox.Text != datos[i].Marca)
                            {
                                MessageBox.Show("La marca no concuerda con la base de datos");
                                cont = 1000;
                            }
                        }
                        //Si no tenemos su nombre metemos el vehiculo nuevo en la colecció de datos
                        if (cont != 1000)
                        {

                            Repostaje report = new Repostaje(Fecha, NKM, Litros, Coste);
                            ObservableCollection<Repostaje> repostas = new ObservableCollection<Repostaje>();
                            repostas.Add(report);

                            NKMf = NKM;
                            Datos tempdatos = new Datos(m, MarcaBox.Text, NKMf, MediaLitros, MediaCoste, repostas, contar);

                            datos.Add(tempdatos);
                            
                            this.Close();

                        }

                    }

                }

            }
          
        }
    }
}
