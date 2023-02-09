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
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace TrabajoFinal
{

    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>

    public class ActualizartablasEventArgs : EventArgs
    {
        

        public ActualizartablasEventArgs()
        {

        }

    }
    public partial class MainWindow : Window
    {

        //Creamos las variables necesarias para ejecutar el programa
        public Boolean cancel = false;
        public Boolean cancel2 = true;
        public Boolean cancel3 = true;
        public Boolean cancel4 = true;
        public Boolean cancel5 = true;
        public int MAX = 100;
        public int contador = 0;
        public event EventHandler<ActualizartablasEventArgs> Actualizartablas;
        public ListView list;
        public ListView list2;
        public ObservableCollection<Repostaje> repostaje = new ObservableCollection<Repostaje>();
        public ObservableCollection<Datos> datos = new ObservableCollection<Datos>();
        public ObservableCollection<Datos> datosmedia = new ObservableCollection<Datos>();
        public List<String> marcas = new List<string>()
        {
            "Alfa Romeo","alfa romeo","Alfa romeo","Aston Martin","aston martin","Audi","audi","BMW","bmw","Citroen","citroen","Cupra","cupra","Dacia","dacia","ds","Ds","Ferrari","ferrari","Ford","ford","Honda","honda","Hyundai","hyundai","jaguar","Jaguar","Jeep","jeep","Kia","kia","Mazda","mazda","Mercedes","mercedes","Mini","mini","Mitsubishi","mitsubishi","Nissan","nissan","Opel","opel","Peugeot","peugeot","Renault","renault","Seat","seat","Tesla","tesla","Volkswagen","volkswagen","Volvo","volvo"
        };
        public List<String> p = new List<string>();
        Ventana ventana;
        Opcional op;
        VCoches v;
        VModificar vm;
        VRepostaje vr;
        string BaseD, Usuario, Contraseña;


        public MainWindow(string BD, string usu, string cont)
        {
            InitializeComponent();
            BaseD = BD;
            Usuario = usu;
            Contraseña = cont;
            //Iniciamos el programa y abrimos la segunda ventana
            Aniadir();
            //Damos valores a nuestros eventos
            datos.CollectionChanged += Vehiculos_CollectionChanged;
            for (int i = 0; i < datos.Count; i++)
            {
                datos[i].Repostajes.CollectionChanged += Repostajes_CollectionChanged;
            }
            this.Closing += new CancelEventHandler(this.Form2_Closing);
            ventana.crearpolilineas += Ventana_crearpolilineas;
            ventana.crearbarras += Ventana_crearbarras;
            //Y creamos por primera vez la gráfica de barras
            crearBarras();
        }
        public void OnActualizartablas(ActualizartablasEventArgs e)
        {
            if (Actualizartablas != null)
            {
                Actualizartablas(this, e);
            }
        }

        private void Ventana_crearpolilineas(object sender, crearpolilineasEventArgs e)
        {
            
            crearPolilineas(e.repostajepolilinea);
        }
        private void Op_crearbarras(object sender, crearBarrasEventArgs e)
        {
            crearBarras();
        }

        //Eventos para coordinar el cierre de las ventanas
        public void Form1_Closing(Object sender, CancelEventArgs e)
        {
            if (e.Cancel == false)
            {
                cancel = false;
            }
        }
        public void Form3_Closing(Object sender, CancelEventArgs e)
        {
            if (e.Cancel == false)
            {
                cancel2 = true;
            }

        }
        public void Form4_Closing(Object sender, CancelEventArgs e)
        {
            if (e.Cancel == false)
            {
                cancel3 = true;
            }

        }
        public void Form5_Closing(Object sender, CancelEventArgs e)
        {
            if (e.Cancel == false)
            {
                cancel4 = true;
            }

        }
        public void Form6_Closing(Object sender, CancelEventArgs e)
        {
            if (e.Cancel == false)
            {
                cancel5 = true;
            }

        }

        public void Aniadir()
        {
            if (cancel == false)
            {
                ventana = new Ventana(datos, this, BaseD);
                ventana.Show();
                cancel = true;
                ventana.Closing += new CancelEventHandler(this.Form1_Closing);
                ventana.crearpolilineas += Ventana_crearpolilineas;
                ventana.crearbarras += Ventana_crearbarras;
            }

        }

        private void Ventana_crearbarras(object sender, crearBarrasEventArgs e)
        {
            crearBarras();
        }

        public void Form2_Closing(Object sender, CancelEventArgs e)
        {
            if (e.Cancel == false)
            {
                Application.Current.Shutdown();
            }

        }
        private void Boton_sec_Click(object sender, RoutedEventArgs e)
        {
            Aniadir();
        }
        //creamos los eventos necesarios para saber si se modifica nuestra observable collection 
        private void Vehiculos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //Si algún elemento de la observable collection datos es borrado o añadido se vuelven a crear las graficas
            if (e.OldItems != null)
                foreach (Datos f in e.OldItems)
                {
                    ActualizartablasEventArgs act = new ActualizartablasEventArgs();
                    OnActualizartablas(act);
                    crearBarras();

                }
            if (e.NewItems != null)
            {
                foreach (Datos f in e.NewItems)
                {
                    ActualizartablasEventArgs act = new ActualizartablasEventArgs();
                    OnActualizartablas(act);
                    crearBarras();

                }
            }
        }
        private void Repostajes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //Si algún elemento de la observable collection Repostaje es borrado o añadido se vuelven a crear las graficas
            if (e.OldItems != null)
            {
                foreach (Repostaje p in e.OldItems)
                {
                    ActualizartablasEventArgs act = new ActualizartablasEventArgs();
                    if (ventana.ElementoSeleccionado != null)
                    {
                        crearPolilineas(datos[ventana.indiceElementoSeleccionado].Repostajes);

                    }
                    crearBarras();
                }
            }
            if (e.NewItems != null)
            {
                foreach (Repostaje p in e.NewItems)
                {
                    ActualizartablasEventArgs act = new ActualizartablasEventArgs();
                    OnActualizartablas(act);
                    if (ventana.ElementoSeleccionado != null)
                    {
                        crearPolilineas(datos[ventana.indiceElementoSeleccionado].Repostajes);
                    }
                    crearBarras();
                }
            }
        }
        private void Lienzo1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            crearBarras();
        }
        //si el tamaño de la ventana cambia volvemos a crear las gráficas
        private void Lienzo2_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ventana.ElementoSeleccionado != null)
            {
                crearPolilineas(datos[ventana.indiceElementoSeleccionado].Repostajes);
            }


        }

        private void Opcional_Click(object sender, RoutedEventArgs e)
        {
            if (cancel2 == false)
            {
                op.Activate();
            }
            if (cancel2 == true)
            {
                op = new Opcional(datos, this);
                op.Show();
                cancel2 = false;
                op.Closing += new CancelEventHandler(this.Form3_Closing);
                op.crearpolilineas2 += Op_crearpolilineas2;
                op.crearbarras += Op_crearbarras;
            }
        }
        private void Op_crearpolilineas2(object sender, crearpolilineasEventArgs e)
        {
            if (ventana.ElementoSeleccionado != null)
            {
                crearPolilineas(datos[ventana.indiceElementoSeleccionado].Repostajes);
            }
        }

        private void BVCoche_Click(object sender, RoutedEventArgs e)
        {
            if (cancel3 == false)
            {
                v.Activate();
            }
            if (cancel3 == true)
            {
                v = new VCoches(datos);
                v.Show();
                cancel3 = false;
                v.Closing += new CancelEventHandler(this.Form4_Closing);


            }
        }

        private void BVRepostaje_Click(object sender, RoutedEventArgs e)
        {
            if (cancel4 == false)
            {
                vr.Activate();
            }
            if (cancel4 == true)
            {
                vr = new VRepostaje(datos, this);
                vr.Show();
                cancel4 = false;
                vr.Closing += new CancelEventHandler(this.Form5_Closing);
            }

        }

        private void Modificar_Click(object sender, RoutedEventArgs e)
        {
            if (cancel5 == false)
            {
                vm.Activate();
            }
            if (cancel5 == true)
            {
                vm = new VModificar(datos, this);
                vm.Show();
                vm.crearbarras2 += Vm_crearbarras2;
                vm.crearpolilineas3 += Vm_crearpolilineas3;
                cancel5 = false;
                vm.Closing += new CancelEventHandler(this.Form6_Closing);
            }

        }

        private void Vm_crearpolilineas3(object sender, crearpolilineasEventArgs e)
        {
            if (ventana.ElementoSeleccionado != null)
            {
                crearPolilineas(datos[ventana.indiceElementoSeleccionado].Repostajes);
            }

        }

        private void Vm_crearbarras2(object sender, crearBarrasEventArgs e)
        {
            crearBarras();
        }

        public void crearPolilineas(ObservableCollection<Repostaje> r)
        {
            Lienzo2.Children.Clear();
            if (r != null)
            {
                repostaje = r;
                int ind = 0;
                int j;
                float valormaxkm = 0;
                float ayudal = 0, ayudac = 0;
                double ayudacompra = 0;
                try
                {

                    for (j = 0; j < repostaje.Count; j++)
                    {
                        float resta = 0;
                        if (j > 0)
                        {
                            float t = repostaje[j].Kilometraje;
                            float ayuda = repostaje[j - 1].Kilometraje;
                            resta = (t - ayuda) / 8;
                        }

                        if (ayudacompra == 0)
                        {
                            ayudacompra = repostaje[j].Preciot;


                        }
                        else if (ayudacompra < repostaje[j].Preciot)
                        {
                            ayudacompra = repostaje[j].Preciot;

                        }
                        if (ayudal == 0)
                        {
                            ayudal = repostaje[j].Litros;

                        }
                        else if (ayudal < repostaje[j].Litros)
                        {
                            ayudal = repostaje[j].Litros;
                        }

                        if (ayudac == 0)
                        {
                            ayudac = repostaje[j].Costes;

                        }
                        else if (ayudac < repostaje[j].Costes)
                        {
                            ayudac = repostaje[j].Costes;
                        }

                        if (valormaxkm == 0)
                        {
                            valormaxkm = resta * 8;
                        }
                        else if (valormaxkm < resta * 8)
                        {
                            valormaxkm = resta * 8;
                        }
                        if (ayudacompra == 0)
                        {
                            ayudacompra = 1;
                            ind = 1;
                        }
                    }
                    //creamos las polilineas sin puntos                     
                    Polyline coste = new Polyline();
                    coste.Stroke = System.Windows.Media.Brushes.Red;
                    Polyline compra = new Polyline();
                    compra.Stroke = System.Windows.Media.Brushes.DarkGoldenrod;
                    Polyline litros = new Polyline();
                    litros.Stroke = System.Windows.Media.Brushes.Green;
                    Polyline km = new Polyline();
                    km.Stroke = System.Windows.Media.Brushes.Blue;
                    PointCollection costecollec = new PointCollection();
                    PointCollection litroscollec = new PointCollection();
                    PointCollection kmcollec = new PointCollection();
                    PointCollection compracollec = new PointCollection();
                    for (j = 0; j < repostaje.Count; j++)
                    {
                        //Vamos creando los puntos y los metemos en una collección de puntos
                        double calculosc = 0, calculosl = 0, calculoskm = 0, calculoscom = 0;
                        double div = Lienzo2.ActualWidth / repostaje.Count;
                        if (j == 0)
                        {
                            double cambiar = Lienzo2.ActualHeight - (Lienzo2.ActualHeight / 4);
                            double cambiar2 = Lienzo2.ActualWidth / 10;
                            calculosl = ((-repostaje[j].Litros * cambiar) / ayudal) + Lienzo2.ActualHeight;
                            calculosc = ((-repostaje[j].Costes * cambiar) / ayudac) + Lienzo2.ActualHeight;
                            if (ayudacompra != 0)
                            {
                                calculoscom = ((-repostaje[j].Preciot * cambiar) / ayudacompra) + Lienzo2.ActualHeight;
                            }
                            else
                            {
                                calculoscom = 0;
                            }
                            System.Windows.Point Pointcompra = new System.Windows.Point(cambiar2 + (j * div), (calculoscom));
                            System.Windows.Point Pointcoste = new System.Windows.Point(cambiar2 + (j * div), (calculosc));
                            System.Windows.Point Pointlitros = new System.Windows.Point(cambiar2 + (j * div), (calculosl));
                            TextBlock fecha = new TextBlock();
                            string h = repostaje[j].Fecha.ToString();
                            string[] h2 = h.Split('\u0020');
                            fecha.Text = h2[0];
                            fecha.FontSize = 9;
                            fecha.SetValue(Canvas.BottomProperty, -15.0);
                            fecha.SetValue(Canvas.LeftProperty, 40.0);
                            Lienzo2.Children.Add(fecha);

                            compracollec.Add(Pointcompra);
                            costecollec.Add(Pointcoste);
                            litroscollec.Add(Pointlitros);
                        }
                        else
                        {
                            double cambiar = Lienzo2.ActualHeight - (Lienzo2.ActualHeight / 4);
                            float t = repostaje[j].Kilometraje;
                            float ayuda = repostaje[j - 1].Kilometraje;
                            float resta2 = (t - ayuda);

                            double cambiar2 = Lienzo2.ActualWidth / 10;
                            calculoskm = (-resta2 * cambiar / valormaxkm) + Lienzo2.ActualHeight;
                            calculosc = ((-repostaje[j].Costes * cambiar) / ayudac) + Lienzo2.ActualHeight;
                            calculosl = ((-repostaje[j].Litros * cambiar) / ayudal) + Lienzo2.ActualHeight;

                            if (ayudacompra != 0)
                            {
                                calculoscom = ((-repostaje[j].Preciot * cambiar) / ayudacompra) + Lienzo2.ActualHeight;
                            }
                            else
                            {
                                calculoscom = 0;
                            }
                            System.Windows.Point Pointcompra = new System.Windows.Point(cambiar2 + (j * div), (calculoscom));
                            System.Windows.Point Pointcoste = new System.Windows.Point(cambiar2 + (j * div), (calculosc));
                            System.Windows.Point Pointlitros = new System.Windows.Point(cambiar2 + (j * div), (calculosl));
                            System.Windows.Point Pointkm = new System.Windows.Point(cambiar2 + (j * div), calculoskm);
                            TextBlock fecha = new TextBlock();
                            string h = repostaje[j].Fecha.ToString();
                            string[] h2 = h.Split('\u0020');
                            fecha.Text = h2[0];
                            fecha.FontSize = 9;
                            fecha.SetValue(Canvas.BottomProperty, -15.0);
                            fecha.SetValue(Canvas.LeftProperty, 5.0 + ((div * j)));
                            Lienzo2.Children.Add(fecha);
                            compracollec.Add(Pointcompra);
                            costecollec.Add(Pointcoste);
                            litroscollec.Add(Pointlitros);
                            kmcollec.Add(Pointkm);
                        }

                    }
                    //Al acabar esa coleción de puntos se la pasamos a la polilinea y la metemos en el canvas
                    coste.Points = costecollec;
                    litros.Points = litroscollec;
                    km.Points = kmcollec;
                    compra.Points = compracollec;

                    Lienzo2.Children.Add(compra);
                    Lienzo2.Children.Add(coste);
                    Lienzo2.Children.Add(litros);
                    Lienzo2.Children.Add(km);

                    //Por último metemos los valores de los ejes
                    TextBlock tbkm1 = new TextBlock();
                    TextBlock tbkm2 = new TextBlock();
                    TextBlock tbkm3 = new TextBlock();
                    TextBlock tbkm4 = new TextBlock();

                    tbkm1.Foreground = Brushes.Blue;
                    tbkm1.Margin = new Thickness(0, 0, 0, 3);
                    tbkm1.Text = "0";
                    tbkm1.SetValue(Canvas.BottomProperty, 00.0);
                    tbkm1.SetValue(Canvas.RightProperty, 00.0);

                    Lienzo2.Children.Add(tbkm1);

                    tbkm2.Foreground = Brushes.Blue;
                    tbkm2.Margin = new Thickness(0, 0, 0, 3);
                    int a = Convert.ToInt32(valormaxkm / 3);
                    String t4 = a.ToString();
                    tbkm2.Text = t4;
                    tbkm2.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight / 4));
                    tbkm2.SetValue(Canvas.RightProperty, 00.0);

                    Lienzo2.Children.Add(tbkm2);

                    tbkm3.Foreground = Brushes.Blue;
                    tbkm3.Margin = new Thickness(0, 0, 0, 3);
                    a = Convert.ToInt32(valormaxkm / 1.5);
                    String t2 = a.ToString();
                    tbkm3.Text = t2;
                    tbkm3.SetValue(Canvas.BottomProperty, 0.00 + (Lienzo2.ActualHeight / 2));
                    tbkm3.SetValue(Canvas.RightProperty, 00.0);

                    Lienzo2.Children.Add(tbkm3);

                    tbkm4.Foreground = Brushes.Blue;
                    tbkm4.Margin = new Thickness(0, 0, 0, 3);
                    String t3 = (valormaxkm).ToString();
                    tbkm4.Text = t3;
                    tbkm4.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 1.32);
                    tbkm4.SetValue(Canvas.RightProperty, 00.0);

                    Lienzo2.Children.Add(tbkm4);

                    TextBlock tblitros1 = new TextBlock();
                    TextBlock tblitros2 = new TextBlock();
                    TextBlock tblitros3 = new TextBlock();
                    TextBlock tblitros4 = new TextBlock();

                    tblitros1.Foreground = Brushes.Green;
                    tblitros1.Margin = new Thickness(0, 0, 0, 3);
                    tblitros1.Text = "0";
                    tblitros1.SetValue(Canvas.BottomProperty, 00.0);
                    tblitros1.SetValue(Canvas.LeftProperty, 00.0);

                    Lienzo2.Children.Add(tblitros1);

                    tblitros2.Foreground = Brushes.Green;
                    tblitros2.Margin = new Thickness(0, 0, 0, 3);
                    a = Convert.ToInt32(ayudal / 3);
                    tblitros2.Text = a.ToString();
                    tblitros2.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 4);
                    tblitros2.SetValue(Canvas.LeftProperty, 00.0);

                    Lienzo2.Children.Add(tblitros2);

                    tblitros3.Foreground = Brushes.Green;
                    tblitros3.Margin = new Thickness(0, 0, 0, 3);
                    a = Convert.ToInt32(ayudal / 1.5);
                    tblitros3.Text = a.ToString();
                    tblitros3.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 2);
                    tblitros3.SetValue(Canvas.LeftProperty, 00.0);

                    Lienzo2.Children.Add(tblitros3);

                    tblitros4.Foreground = Brushes.Green;
                    tblitros4.Margin = new Thickness(0, 0, 0, 3);
                    a = Convert.ToInt32(ayudal);
                    tblitros4.Text = a.ToString();
                    tblitros4.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 1.32);
                    tblitros4.SetValue(Canvas.LeftProperty, 00.0);

                    Lienzo2.Children.Add(tblitros4);

                    TextBlock tbcoste1 = new TextBlock();
                    TextBlock tbcoste2 = new TextBlock();
                    TextBlock tbcoste3 = new TextBlock();
                    TextBlock tbcoste4 = new TextBlock();


                    tbcoste1.Foreground = Brushes.Red;
                    tbcoste1.Margin = new Thickness(0, 0, 0, 3);
                    tbcoste1.Text = "0";
                    tbcoste1.SetValue(Canvas.BottomProperty, 00.0);
                    tbcoste1.SetValue(Canvas.LeftProperty, -20.0);

                    Lienzo2.Children.Add(tbcoste1);

                    tbcoste2.Foreground = Brushes.Red;
                    tbcoste2.Margin = new Thickness(0, 0, 0, 3);
                    a = Convert.ToInt32(ayudac / 3);
                    tbcoste2.Text = a.ToString();
                    tbcoste2.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 4);
                    tbcoste2.SetValue(Canvas.LeftProperty, -20.0);

                    Lienzo2.Children.Add(tbcoste2);

                    tbcoste3.Foreground = Brushes.Red;
                    tbcoste3.Margin = new Thickness(0, 0, 0, 3);
                    a = Convert.ToInt32(ayudac / 1.5);
                    tbcoste3.Text = a.ToString();
                    tbcoste3.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 2);
                    tbcoste3.SetValue(Canvas.LeftProperty, -20.0);

                    Lienzo2.Children.Add(tbcoste3);

                    tbcoste4.Foreground = Brushes.Red;
                    tbcoste4.Margin = new Thickness(0, 0, 0, 3);
                    a = Convert.ToInt32(ayudac);
                    tbcoste4.Text = a.ToString();
                    tbcoste4.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 1.32);
                    tbcoste4.SetValue(Canvas.LeftProperty, -20.0);

                    Lienzo2.Children.Add(tbcoste4);

                    if (ind == 1)
                    {
                        ayudacompra = 0;
                    }
                    Rectangle rectcompra1 = new Rectangle();
                    rectcompra1.Width = 10;
                    rectcompra1.Height = 5;
                    rectcompra1.Fill = Brushes.DarkGoldenrod;
                    rectcompra1.SetValue(Canvas.BottomProperty, 00.0);
                    rectcompra1.SetValue(Canvas.LeftProperty, -35.0);
                    Rectangle rectcompra2 = new Rectangle();
                    rectcompra2.Width = 10;
                    rectcompra2.Height = 5;
                    rectcompra2.Fill = Brushes.DarkGoldenrod;
                    rectcompra2.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 4);
                    rectcompra2.SetValue(Canvas.LeftProperty, -35.0);
                    Rectangle rectcompra3 = new Rectangle();
                    rectcompra3.Width = 10;
                    rectcompra3.Height = 5;
                    rectcompra3.Fill = Brushes.DarkGoldenrod;
                    rectcompra3.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 2);
                    rectcompra3.SetValue(Canvas.LeftProperty, -35.0);
                    Rectangle rectcompra4 = new Rectangle();
                    rectcompra4.Width = 10;
                    rectcompra4.Height = 5;
                    rectcompra4.Fill = Brushes.DarkGoldenrod;
                    rectcompra4.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 1.32);
                    rectcompra4.SetValue(Canvas.LeftProperty, -35.0);
                    Lienzo2.Children.Add(rectcompra1);
                    Lienzo2.Children.Add(rectcompra2);
                    Lienzo2.Children.Add(rectcompra3);
                    Lienzo2.Children.Add(rectcompra4);

                    TextBlock tbcompra1 = new TextBlock();
                    TextBlock tbcompra2 = new TextBlock();
                    TextBlock tbcompra3 = new TextBlock();
                    TextBlock tbcompra4 = new TextBlock();


                    tbcompra1.Foreground = Brushes.DarkGoldenrod;
                    tbcompra1.Margin = new Thickness(0, 0, 0, 3);
                    tbcompra1.Text = "0";
                    tbcompra1.SetValue(Canvas.BottomProperty, 00.0);
                    tbcompra1.SetValue(Canvas.LeftProperty, -35.0);

                    Lienzo2.Children.Add(tbcompra1);

                    tbcompra2.Foreground = Brushes.DarkGoldenrod;
                    tbcompra2.Margin = new Thickness(0, 0, 0, 3);
                    a = Convert.ToInt32(ayudacompra / 3);
                    tbcompra2.Text = a.ToString();
                    tbcompra2.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 4);
                    tbcompra2.SetValue(Canvas.LeftProperty, -35.0);

                    Lienzo2.Children.Add(tbcompra2);

                    tbcompra3.Foreground = Brushes.DarkGoldenrod;
                    tbcompra3.Margin = new Thickness(0, 0, 0, 3);
                    a = Convert.ToInt32(ayudacompra / 1.5);
                    tbcompra3.Text = a.ToString();
                    tbcompra3.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 2);
                    tbcompra3.SetValue(Canvas.LeftProperty, -35.0);

                    Lienzo2.Children.Add(tbcompra3);

                    tbcompra4.Foreground = Brushes.DarkGoldenrod;
                    tbcompra4.Margin = new Thickness(0, 0, 0, 3);
                    a = Convert.ToInt32(ayudacompra);
                    tbcompra4.Text = a.ToString();
                    tbcompra4.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo2.ActualHeight) / 1.32);
                    tbcompra4.SetValue(Canvas.LeftProperty, -35.0);

                    Lienzo2.Children.Add(tbcompra4);


                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Primero selecciona en la tabla 1");
                }

            }
        }   

        public void crearBarras()
        {
            //eliminamos todos los elementos del canvas
            Lienzo1.Children.Clear();
            double calculo1 = 0, calculo2 = 0, calculo3 = 0, calculo4 = 0;
            //calculamos el espacio que vana tener las tres barras
            double anchotres = Lienzo1.ActualWidth / datos.Count;
            float km = 0, coste = 0, litros = 0;
            double compra = 0;
            //seleccionamos los valores mayores de medialitros,mediacoste y km
            for (int i = 0; i < datos.Count; i++)
            {

                if (datos[i].Kilometrajet > km)
                {
                    km = datos[i].Kilometrajet;
                }
                if (datos[i].MediaCoste > coste)
                {
                    coste = datos[i].MediaCoste;
                }
                if (datos[i].MediaLitros > litros)
                {
                    litros = datos[i].MediaLitros;
                }
                if (datos[i].MediaCompra > compra)
                {
                    compra = datos[i].MediaCompra;
                }
            }
            //buscamos la posición de las barras y las añadimos
            for (int i = 0; i < datos.Count; i++)
            {
                double h1 = anchotres / 4.4;
                double h2 = anchotres / 3;
                double h3 = anchotres / 2.3;
                double h4 = anchotres / 1.85;
                double h11 = h1 + anchotres * i;
                double h22 = h2 + anchotres * i;
                double h33 = h3 + anchotres * i;
                double h44 = h4 + anchotres * i;
                //Si él valor de MediaCoste es el máximo lo indicamos,sino hacemos una regla de tres
                if (datos[i].MediaCoste == coste)
                {
                    calculo1 = Lienzo1.ActualHeight / 1.13;

                }
                else
                {
                    calculo1 = ((Lienzo1.ActualHeight / 1.13) * datos[i].MediaCoste) / coste;


                }

                Rectangle rect = new Rectangle();
                rect.Width = anchotres / 12;
                rect.Height = calculo1;
                rect.Fill = Brushes.Red;
                rect.SetValue(Canvas.LeftProperty, 00.0 + (h11));
                rect.SetValue(Canvas.BottomProperty, 00.0);

                Lienzo1.Children.Add(rect);
                //Si él valor de MediaLitros es el máximo lo indicamos,sino hacemos una regla de tres
                if (datos[i].MediaLitros == litros)
                {
                    calculo2 = Lienzo1.ActualHeight / 1.13;

                }
                else
                {
                    calculo2 = ((Lienzo1.ActualHeight / 1.13) * datos[i].MediaLitros) / litros;


                }
                Rectangle rect2 = new Rectangle();
                rect2.Width = anchotres / 12;
                rect2.Height = calculo2;
                rect2.Fill = Brushes.Green;
                rect2.SetValue(Canvas.LeftProperty, 00.0 + (h22));
                rect2.SetValue(Canvas.BottomProperty, 00.0);
                Lienzo1.Children.Add(rect2);
                //Si él valor de Kilometraje es el máximo lo indicamos,sino hacemos una regla de tres
                if (datos[i].Kilometrajet == km)
                {
                    calculo3 = Lienzo1.ActualHeight / 1.13;

                }
                else
                {
                    calculo3 = ((Lienzo1.ActualHeight / 1.13) * datos[i].Kilometrajet) / km;


                }

                Rectangle rect3 = new Rectangle();
                rect3.Width = anchotres / 12;
                rect3.Height = calculo3;
                rect3.Fill = Brushes.Blue;
                rect3.SetValue(Canvas.LeftProperty, 00.0 + (h33));
                rect3.SetValue(Canvas.BottomProperty, 00.0);
                Lienzo1.Children.Add(rect3);
                if (compra != 0)
                {
                    if (datos[i].MediaCompra == compra)
                    {
                        calculo4 = Lienzo1.ActualHeight / 1.13;

                    }
                    else
                    {
                        calculo4 = ((Lienzo1.ActualHeight / 1.13) * datos[i].MediaCompra) / compra;


                    }
                    Rectangle rect4 = new Rectangle();
                    rect4.Width = anchotres / 12;
                    rect4.Height = calculo4;
                    rect4.Fill = Brushes.DarkGoldenrod;
                    rect4.SetValue(Canvas.LeftProperty, 00.0 + (h44));
                    rect4.SetValue(Canvas.BottomProperty, 00.0);
                    Lienzo1.Children.Add(rect4);

                    TextBlock tbcompra1 = new TextBlock();
                    TextBlock tbcompra2 = new TextBlock();
                    TextBlock tbcompra3 = new TextBlock();

                    tbcompra1.Foreground = Brushes.DarkGoldenrod;
                    tbcompra1.Margin = new Thickness(0, 0, 0, 3);
                    tbcompra1.Text = "0";
                    tbcompra1.FontSize = 9;
                    tbcompra1.SetValue(Canvas.BottomProperty, 01.5);
                    tbcompra1.SetValue(Canvas.RightProperty, -35.0);


                    Lienzo1.Children.Add(tbcompra1);

                    tbcompra2.Foreground = Brushes.DarkGoldenrod;
                    tbcompra2.Margin = new Thickness(0, 0, 0, 3);
                    int b = Convert.ToInt32(compra / 2);
                    string tb = b.ToString();
                    tbcompra2.Text = tb;
                    tbcompra2.FontSize = 9;
                    tbcompra2.SetValue(Canvas.BottomProperty, 01.5 + (Lienzo1.ActualHeight / 1.95));
                    tbcompra2.SetValue(Canvas.RightProperty, -35.0);


                    Lienzo1.Children.Add(tbcompra2);

                    tbcompra3.Foreground = Brushes.DarkGoldenrod;
                    tbcompra3.Margin = new Thickness(0, 0, 0, 3);
                    b = Convert.ToInt32(compra);
                    tb = b.ToString();
                    tbcompra3.Text = tb;
                    tbcompra3.FontSize = 9;
                    tbcompra3.SetValue(Canvas.BottomProperty, 01.5 + (Lienzo1.ActualHeight / 1.15));
                    tbcompra3.SetValue(Canvas.RightProperty, -35.0);


                    Lienzo1.Children.Add(tbcompra3);

                    Rectangle rectcompra1 = new Rectangle();
                    rectcompra1.Width = 10;
                    rectcompra1.Height = 5;
                    rectcompra1.Fill = Brushes.DarkGoldenrod;
                    rectcompra1.SetValue(Canvas.BottomProperty, 00.0);
                    rectcompra1.SetValue(Canvas.RightProperty, -35.0);
                    Rectangle rectcompra2 = new Rectangle();
                    rectcompra2.Width = 10;
                    rectcompra2.Height = 5;
                    rectcompra2.Fill = Brushes.DarkGoldenrod;
                    rectcompra2.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 1.95));
                    rectcompra2.SetValue(Canvas.RightProperty, -35.0);
                    Rectangle rectcompra3 = new Rectangle();
                    rectcompra3.Width = 10;
                    rectcompra3.Height = 5;
                    rectcompra3.Fill = Brushes.DarkGoldenrod;
                    rectcompra3.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 1.15));
                    rectcompra3.SetValue(Canvas.RightProperty, -35.0);

                    Lienzo1.Children.Add(rectcompra3);
                    Lienzo1.Children.Add(rectcompra2);
                    Lienzo1.Children.Add(rectcompra1);
                }


                TextBlock tbfecha = new TextBlock();

                tbfecha.Foreground = Brushes.Black;
                tbfecha.Margin = new Thickness(0, 0, 0, 3);
                tbfecha.Text = datos[i].Matricula;
                tbfecha.FontSize = 9;
                tbfecha.SetValue(Canvas.BottomProperty, -20.0);
                tbfecha.SetValue(Canvas.LeftProperty, 00.0 + (h11));


                Lienzo1.Children.Add(tbfecha);

                //Añadimos los valores de los ejes

                TextBlock tbkm1 = new TextBlock();
                TextBlock tbkm2 = new TextBlock();
                TextBlock tbkm3 = new TextBlock();
                TextBlock tbkm4 = new TextBlock();
                TextBlock tbkm5 = new TextBlock();
                TextBlock tbkm6 = new TextBlock();
                TextBlock tbkm7 = new TextBlock();
                TextBlock tbkm8 = new TextBlock();
                TextBlock tbkm9 = new TextBlock();

                tbkm1.Foreground = Brushes.Blue;
                tbkm1.Margin = new Thickness(0, 0, 0, 3);
                tbkm1.Text = "0";
                tbkm1.FontSize = 9;
                tbkm1.SetValue(Canvas.BottomProperty, 00.0);
                tbkm1.SetValue(Canvas.RightProperty, 00.0);


                Lienzo1.Children.Add(tbkm1);

                tbkm2.Foreground = Brushes.Blue;
                tbkm2.FontSize = 9;
                tbkm2.Margin = new Thickness(0, 0, 0, 3);
                int a = Convert.ToInt32(km / 8);
                String t1 = a.ToString();
                tbkm2.Text = t1;
                tbkm2.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 8));
                tbkm2.SetValue(Canvas.RightProperty, 00.0);
                Lienzo1.Children.Add(tbkm2);

                tbkm3.Foreground = Brushes.Blue;
                tbkm3.FontSize = 9;
                tbkm3.Margin = new Thickness(0, 0, 0, 3);
                a = Convert.ToInt32(km / 4);
                String t2 = a.ToString();
                tbkm3.Text = t2;
                tbkm3.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 4));
                tbkm3.SetValue(Canvas.RightProperty, 00.0);
                Lienzo1.Children.Add(tbkm3);

                tbkm4.Foreground = Brushes.Blue;
                tbkm4.FontSize = 9;
                tbkm4.Margin = new Thickness(0, 0, 0, 3);
                a = Convert.ToInt32(km / 2);
                String t3 = a.ToString();
                tbkm4.Text = t3;
                tbkm4.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 2.70));
                tbkm4.SetValue(Canvas.RightProperty, 00.0);
                Lienzo1.Children.Add(tbkm4);

                tbkm5.Foreground = Brushes.Blue;
                tbkm5.FontSize = 9;
                tbkm5.Margin = new Thickness(0, 0, 0, 3);
                a = Convert.ToInt32(km / 1.75);
                String t4 = a.ToString();
                tbkm5.Text = t4;
                tbkm5.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 1.95));
                tbkm5.SetValue(Canvas.RightProperty, 00.0);
                Lienzo1.Children.Add(tbkm5);

                tbkm6.Foreground = Brushes.Blue;
                tbkm6.FontSize = 9;
                tbkm6.Margin = new Thickness(0, 0, 0, 3);
                a = Convert.ToInt32(km / 1.5);
                String t5 = a.ToString();
                tbkm6.Text = t5;
                tbkm6.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 1.60));
                tbkm6.SetValue(Canvas.RightProperty, 00.0);
                Lienzo1.Children.Add(tbkm6);

                tbkm7.Foreground = Brushes.Blue;
                tbkm7.FontSize = 9;
                tbkm7.Margin = new Thickness(0, 0, 0, 3);
                a = Convert.ToInt32(km / 1.25);
                String t6 = a.ToString();
                tbkm7.Text = t6;
                tbkm7.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 1.32));
                tbkm7.SetValue(Canvas.RightProperty, 00.0);
                Lienzo1.Children.Add(tbkm7);

                tbkm8.Foreground = Brushes.Blue;
                tbkm8.FontSize = 9;
                tbkm8.Margin = new Thickness(0, 0, 0, 3);
                a = Convert.ToInt32(km);
                String t7 = a.ToString();
                tbkm8.Text = t7;
                tbkm8.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 1.15));
                tbkm8.SetValue(Canvas.RightProperty, 00.0);
                Lienzo1.Children.Add(tbkm8);

                TextBlock tbcoste1 = new TextBlock();
                TextBlock tbcoste2 = new TextBlock();
                TextBlock tbcoste3 = new TextBlock();

                tbcoste1.Foreground = Brushes.Red;
                tbcoste1.Margin = new Thickness(0, 0, 0, 3);
                tbcoste1.Text = "0";
                tbcoste1.FontSize = 9;
                tbcoste1.SetValue(Canvas.BottomProperty, 00.0);
                tbcoste1.SetValue(Canvas.RightProperty, -15.0);


                Lienzo1.Children.Add(tbcoste1);

                tbcoste2.Foreground = Brushes.Red;
                tbcoste2.Margin = new Thickness(0, 0, 0, 3);
                a = Convert.ToInt32(coste / 2);
                t1 = a.ToString();
                tbcoste2.Text = t1;
                tbcoste2.FontSize = 9;
                tbcoste2.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 1.95));
                tbcoste2.SetValue(Canvas.RightProperty, -15.0);


                Lienzo1.Children.Add(tbcoste2);

                tbcoste3.Foreground = Brushes.Red;
                tbcoste3.Margin = new Thickness(0, 0, 0, 3);
                a = Convert.ToInt32(coste);
                t1 = a.ToString();
                tbcoste3.Text = t1;
                tbcoste3.FontSize = 9;
                tbcoste3.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 1.15));
                tbcoste3.SetValue(Canvas.RightProperty, -15.0);


                Lienzo1.Children.Add(tbcoste3);


                TextBlock tblitros1 = new TextBlock();
                TextBlock tblitros2 = new TextBlock();
                TextBlock tblitros3 = new TextBlock();

                tblitros1.Foreground = Brushes.Green;
                tblitros1.Margin = new Thickness(0, 0, 0, 3);
                tblitros1.Text = "0";
                tblitros1.FontSize = 9;
                tblitros1.SetValue(Canvas.BottomProperty, 00.0);
                tblitros1.SetValue(Canvas.LeftProperty, 0.0);
                Lienzo1.Children.Add(tblitros1);


                tblitros2.Foreground = Brushes.Green;
                tblitros2.Margin = new Thickness(0, 0, 0, 3);
                a = Convert.ToInt32(litros / 2);
                t1 = a.ToString();
                tblitros2.Text = t1;
                tblitros2.FontSize = 9;
                tblitros2.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 1.95));
                tblitros2.SetValue(Canvas.LeftProperty, 0.0);


                Lienzo1.Children.Add(tblitros2);

                tblitros3.Foreground = Brushes.Green;
                tblitros3.Margin = new Thickness(0, 0, 0, 3);
                a = Convert.ToInt32(litros);
                t1 = a.ToString();
                tblitros3.Text = t1;
                tblitros3.FontSize = 9;
                tblitros3.SetValue(Canvas.BottomProperty, 00.0 + (Lienzo1.ActualHeight / 1.15));
                tblitros3.SetValue(Canvas.LeftProperty, 0.0);


                Lienzo1.Children.Add(tblitros3);
            }


        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {

            string[] linea = new string[MAX];
            string[] palabra = new string[3];
            linea = File.ReadAllLines("Usuarios.txt");
            StreamWriter sw = new StreamWriter("Usuarios.txt");
            for (int k = 0; k < linea.Length; k++)
            {
                palabra = linea[k].Split('\u002C');
                if (Usuario != palabra[0])
                {
                    sw.WriteLine(linea[k]);                
                }
            }
            sw.Close();
            File.Delete(BaseD);
            Application.Current.Shutdown();
             
        }
    }
}