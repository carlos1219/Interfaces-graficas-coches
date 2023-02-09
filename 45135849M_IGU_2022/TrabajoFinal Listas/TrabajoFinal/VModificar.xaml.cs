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
using System.ComponentModel;

namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para VModificar.xaml
    /// </summary>
    /// 
    public partial class VModificar : Window
    {
        ObservableCollection<Datos> datos;
        public event EventHandler<crearpolilineasEventArgs> crearpolilineas3;

        public List<String> marcas = new List<string>()
      
        {
            "Alfa Romeo","alfa romeo","Alfa romeo","Aston Martin","aston martin","Audi","audi","BMW","bmw","Citroen","citroen","Cupra","cupra","Dacia","dacia","ds","Ds","Ferrari","ferrari","Ford","ford","Honda","honda","Hyundai","hyundai","jaguar","Jaguar","Jeep","jeep","Kia","kia","Mazda","mazda","Mercedes","mercedes","Mini","mini","Mitsubishi","mitsubishi","Nissan","nissan","Opel","opel","Peugeot","peugeot","Renault","renault","Seat","seat","Tesla","tesla","Volkswagen","volkswagen","Volvo","volvo"
        };
        public Boolean cancel = true;
        public event EventHandler<crearBarrasEventArgs> crearbarras2;
        VModificarR mr;
        MainWindow mw;
        Matricula m2 = new Matricula("zzz", "0000");
        Datos datos3;
        public VModificar(ObservableCollection<Datos> dat,MainWindow m)
        {
            InitializeComponent();
            datos = dat;
            listamat.ItemsSource = datos;
            mw = m;
            datos3 = datos[0];
            
        }

        void Oncreapolilineas3(crearpolilineasEventArgs e)
        {
            if (crearpolilineas3 != null)
            {
                crearpolilineas3(this, e);
            }
        }
        public void Form1_Closing(Object sender, CancelEventArgs e)
        {
            if (e.Cancel == false)
            {
                cancel = true;

                
            }
        }
        void OncreaBarras2(crearBarrasEventArgs e)
        {
            if (crearbarras2 != null)
            {
                crearbarras2(this, e);
            }
        }

        private void listamat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listamat.SelectedItem != null)
            {
                MatrículaBox.Text = datos[listamat.SelectedIndex].Matricula;
                MarcaBox.Text=datos[listamat.SelectedIndex].Marca;
            }
        }

        private void Modificar_Click(object sender, RoutedEventArgs e)
        {
            if (listamat.SelectedItem != null)
            {
                int G = 0;
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

                for (int i = 0; i < marcas.Count; i++)
                {
                    if (marcas[i] == MarcaBox.Text)
                    {
                        G = 1;
                        MarcaBox.Background = Brushes.Green;
                    }
                }
                if (G == 0)
                {
                    MessageBox.Show("Marca desconocida introduza una más conocida");
                    MarcaBox.Background = Brushes.Red;
                }
                if (G == 1 && f == 0)
                {
                    datos[listamat.SelectedIndex].Matricula = MatrículaBox.Text;
                    datos[listamat.SelectedIndex].Marca = MarcaBox.Text;
                    ActualizartablasEventArgs act = new ActualizartablasEventArgs();
                    mw.OnActualizartablas(act);
                    crearBarrasEventArgs cb = new crearBarrasEventArgs();
                    OncreaBarras2(cb);
                    crearpolilineasEventArgs cp = new crearpolilineasEventArgs(datos[listamat.SelectedIndex].Repostajes);
                    Oncreapolilineas3(cp);

                    this.Close();
                }
            }
        }

        private void ModificarR_Click(object sender, RoutedEventArgs e)
        {
            if(listamat.SelectedItem != null)
            {
                if (cancel == false)
                {
                    mr.Activate();
                }
                if (cancel == true)
                {
                    mr = new VModificarR(datos[listamat.SelectedIndex].Repostajes, datos[listamat.SelectedIndex].Matricula, datos[listamat.SelectedIndex].Marca);
                    mr.Show();
                    cancel = false;
                    mr.Closing += new CancelEventHandler(this.Form1_Closing);
                    mr.NotificarVM += Mr_NotificarVM;


                }

            }
     
        }

        private void Mr_NotificarVM(object sender, NotificarVMEventArgs e)
        {
           
            datos3 = mr.pasadatos;
            for(int i = 0; i < datos.Count; i++)
            {
                if (datos3.Matricula == datos[i].Matricula)
                {
                    datos[i].MediaLitros = datos3.MediaLitros;
                    datos[i].MediaCoste = datos3.MediaCoste;
                    datos[i].Kilometrajet = datos3.Kilometrajet;
                }
            }
            ActualizartablasEventArgs act = new ActualizartablasEventArgs();
            mw.OnActualizartablas(act);
            crearBarrasEventArgs cb = new crearBarrasEventArgs();
            OncreaBarras2(cb);
            crearpolilineasEventArgs cp = new crearpolilineasEventArgs(datos[listamat.SelectedIndex].Repostajes);
            Oncreapolilineas3(cp);


        }
    }
}
