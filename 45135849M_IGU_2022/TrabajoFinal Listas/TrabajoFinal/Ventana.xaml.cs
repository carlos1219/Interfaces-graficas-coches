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
using System.Runtime;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    
    public class crearpolilineasEventArgs : EventArgs
    {
        public ObservableCollection<Repostaje> repostajepolilinea { get; set; }

        public crearpolilineasEventArgs(ObservableCollection<Repostaje> Repostajepolilinea)
        {
            repostajepolilinea = Repostajepolilinea;
        }
    } 
    public partial class Ventana : Window
    {        
        //Creamos las variables necesarias para ejecutar el programa
        public delegate void llenarlista(ObservableCollection<Datos> datos);
        public event EventHandler<crearBarrasEventArgs> crearbarras;
        int cambio=0;
        int MAX = 100;
        int contador = 0;
        string BD;
        List<String> marcas = new List<string>()
        {
            "Alfa Romeo","alfa romeo","Alfa romeo","Aston Martin","aston martin","Audi","audi","BMW","bmw","Citroen","citroen","Cupra","cupra","Dacia","dacia","ds","Ds","Ferrari","ferrari","Ford","ford","Honda","honda","Hyundai","hyundai","jaguar","Jaguar","Jeep","jeep","Kia","kia","Mazda","mazda","Mercedes","mercedes","Mini","mini","Mitsubishi","mitsubishi","Nissan","nissan","Opel","opel","Peugeot","peugeot","Renault","renault","Seat","seat","Tesla","tesla","Volkswagen","volkswagen","Volvo","volvo"
        };
        public event  EventHandler <crearpolilineasEventArgs> crearpolilineas;
        ObservableCollection<Datos> datos = new ObservableCollection<Datos>();
        public Ventana(ObservableCollection<Datos> datos2,MainWindow m,string BaseD)
        {
            List<String> lista = new List<string>();
            InitializeComponent();
            BD= BaseD;
            llenarlista llenar = new llenarlista(Leertxt);
            datos = datos2;
            llenar(datos);
            Lista1.ItemsSource = datos;
            Borrar_datos.IsEnabled = false;
            Borrar_repostaje.IsEnabled = false;
            m.Actualizartablas += M_Actualizartablas;
        }
        private void M_Actualizartablas(object sender, ActualizartablasEventArgs e)
        {
            actualizartablas();
        }
        void OncreaPolilineas(crearpolilineasEventArgs e)
        {
            if (crearpolilineas != null)
            {
                crearpolilineas(this, e);
            }
        }

        void OncreaBarras(crearBarrasEventArgs e)
        {
            if (crearbarras != null)
            {
                crearbarras(this, e);
            }
        }
        private void actualizartablas()
        {
            Lista1.Items.Refresh();
            Lista2.Items.Refresh();
        }
        //Nos servirá para saber que elemento de la tabla está seleccionado en la mainwindows 
        public int indiceElementoSeleccionado
        {
            get { return Lista1.SelectedIndex; }
        }
        public object ElementoSeleccionado 
        {
            get { return Lista1.SelectedItem; }
        }
        public object lista
        {
            get { return Lista1; }
        }
        public object lista2
        {
            get { return Lista2; }
        }
        private void Lista1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (Lista1.SelectedItem != null)
            {
                crearpolilineasEventArgs cp = new crearpolilineasEventArgs(datos[Lista1.SelectedIndex].Repostajes);
                OncreaPolilineas(cp);
            }

            añadir_tabla2();



        }
        private void añadir_tabla2()
        {
            if(Lista1.SelectedItem == null)
            {
                Lista2.ItemsSource = null;
            }
            //Si hay algún elemento seleccionado empieza a ejecutarse
            if (Lista1.SelectedItem != null)
            {
                Borrar_datos.IsEnabled = true;
                cambio = 1;
               
                int i, j = 0;
                string[] palabra = new string[2];
                string ayuda = Lista1.SelectedItem.ToString();
                palabra = ayuda.Split('\u0020');
                for (i = 0; i < datos.Count; i++)
                {
                    if (datos[i].Matricula.ToString() == palabra[0])
                    {
                        for (j = 0; j < datos[i].Repostajes.Count; j++)
                        {
                            //Comprueba que matricula corresponde con la matriucla del elemento seleccionado

                            Lista2.ItemsSource = datos[i].Repostajes;
                            
                        }
                    }
                }
            }
        }
        public void Leertxt(ObservableCollection<Datos> datos)
        {
            int G = 0;
            int i, j, k;
            int cont;
            float Litros=0, Coste=0;
            float NKM=0, NKMf, MediaLitros = 0, MediaCoste = 0;
            int dia, mes, ano, horas, minutos, segundos;
            String[] linea = new string[100];
            String[] Fecha = new string[3];
            String[] Division = new string[2];
            String[] palabra = new string[6];
            String[] Hora = new string[3];
            List<String> lista = new List<string>();
            DateTime fecha=new DateTime();
            //leemos todas las lineas del codigo una a una
            try
            {
                linea = File.ReadAllLines(BD);
            }
            catch (FileNotFoundException)
            {
                TextWriter streamReader= new StreamWriter(BD);
                streamReader.Close();
            }
            if (linea.Length != 100)
            {
            
            //Las ponemos en el formato adecuado 
            for (k = 0; k < linea.Length; k++)
            {
                G = 0;
                palabra = linea[k].Split('\u002E');
                    if (palabra[0].Length == 0 || palabra[1].Length == 0 || palabra[3].Length == 0 || palabra[4].Length == 0 || palabra[5].Length == 0)
                    {

                    }
                    else
                    {
                        string[] temporal = palabra[0].Split('\u002D');
                        int f = 0;
                        Matricula m = new Matricula("0000", "ZZZ");
                        try
                        {
                            m = new Matricula(temporal[0], temporal[1]);
                            try
                            {
                                Regex rx = new Regex(@"^\d{4}");

                                if (rx.IsMatch(temporal[0]))
                                {

                                    m = new Matricula(temporal[0], temporal[1]);
                                    string hm = m.TostringGuion();
                                }
                                else
                                {
                                    f = 1;
                                    MessageBox.Show("El número de la matricula debe tener 4 digitos");
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
                        for (i = 0; i < marcas.Count; i++)
                        {
                            if (marcas[i] == palabra[1])
                            {
                                G = 1;
                            }
                        }
                        Division = palabra[2].Split('\u0020');
                        try
                        {
                            Fecha = Division[0].Split('\u002f');
                            dia = Convert.ToInt32(Fecha[0]);
                            mes = Convert.ToInt32(Fecha[1]);
                            ano = Convert.ToInt32(Fecha[2]);

                            Hora = Division[1].Split('\u003a');
                            horas = Convert.ToInt32(Hora[0]);
                            minutos = Convert.ToInt32(Hora[1]);
                            segundos = Convert.ToInt32(Hora[2]);
                            fecha = new DateTime(ano, mes, dia);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Fecha erronea en la base de datos");
                        }

                        try
                        {
                            NKM = Convert.ToInt32(palabra[3]);
                            if (NKM > 1000000)
                            {
                                NKM = 0;
                                MessageBox.Show("Su coche tiene demasiados kilometros");
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("dato de la base de datos en num km");
                        }
                        try
                        {
                            Litros = float.Parse(palabra[4]);
                            if (Litros > 1500)
                            {
                                Litros = 0;
                                MessageBox.Show("Los litros son demasiados");
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("dato de la base de datos en Litros");
                        }
                        try
                        {
                            float layuda = (Litros * 3);
                            Coste = float.Parse(palabra[5]);

                            if (Coste > 3000 || layuda < Coste)
                            {
                                Coste = 0;
                                MessageBox.Show("El coste es excesivo");
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("dato de la base de datos en Coste");
                        }

                        if (NKM == 0 || Litros == 0 || Coste == 0 || f != 0)
                        {

                            MessageBox.Show("Alguno de sus datos está mal en la base de datos");
                        }
                        else if (G == 0)
                        {
                            MessageBox.Show("Marca desconocida introduza una más conocida");
                        }
                        else
                        {

                            // las añadimos en unos nuevos Datos
                            cont = 0;
                            int contar = 0;
                            //Comprobamos si nuestra lista está vacia si es asi añadimos el primer parámetro, si no está vacia comprobamos si está su nombre 
                            if (datos.Count == 0)
                            {
                                Repostaje report = new Repostaje(fecha, NKM, Litros, Coste);
                                ObservableCollection<Repostaje> repostaje = new ObservableCollection<Repostaje>();
                                repostaje.Add(report);


                                NKMf = NKM;
                                Datos tempdatos = new Datos(m, palabra[1], NKMf, MediaLitros, MediaCoste, repostaje);
                                datos.Add(tempdatos);

                            }
                            else
                            {
                                //Si tenemos su nombre acabamos el bucle y añadimos en la colección de repostajes este nuevo repostaje
                                for (i = 0; i < datos.Count; i++)
                                {
                                    if (m.TostringGuion() == datos[i].Matricula && palabra[1] == datos[i].Marca)
                                    {
                                        if (m.TostringGuion() == datos[i].Matricula)
                                        {
                                            if (datos[i].Kilometrajet < NKM)
                                            {
                                                Repostaje report = new Repostaje(fecha, NKM, Litros, Coste);
                                                datos[i].Repostajes.Add(report);
                                                NKMf = NKM;
                                                string[] lp = datos[i].Matricula.Split('\u002D');
                                                Matricula mat = new Matricula(lp[0], lp[1]);
                                                Datos datos2 = new Datos(mat, datos[i].Marca, NKMf, datos[i].MediaLitros, datos[i].MediaCoste, datos[i].Repostajes, cont);

                                                datos.Remove(datos[i]);
                                                datos.Add(datos2);

                                            }
                                        }
                                        else if (datos[i].Kilometrajet > NKM && datos[i].Repostajes[datos[i].Repostajes.Count - 1].Fecha > fecha)
                                        {
                                            Repostaje report = new Repostaje(fecha, NKM, Litros, Coste);

                                            datos[i].Repostajes.Add(report);

                                            NKMf = NKM;
                                            string[] lp = datos[i].Matricula.Split('\u002D');
                                            Matricula mat = new Matricula(lp[0], lp[1]);

                                            Datos datos2 = new Datos(mat, datos[i].Marca, NKMf, datos[i].MediaLitros, datos[i].MediaCoste, datos[i].Repostajes, cont);

                                            datos[i].MediaLitros = datos2.MediaLitros;

                                            datos[i].MediaCoste = datos2.MediaCoste;
                                            datos[i].Kilometrajet = datos2.Kilometrajet;
                                            datos[i].Repostajes.Add(report);

                                        }
                                        else
                                        {
                                            MessageBox.Show("Fecha o kilometros erróneos");
                                        }

                                        i = 1000;
                                        cont = 1000;
                                    }
                                    else if (m.TostringGuion() == datos[i].Matricula && palabra[1] != datos[i].Marca)
                                    {
                                        MessageBox.Show("La marca no concuerda con la base de datos");
                                        cont = 1000;
                                    }
                                }
                                //Si no tenemos su nombre metemos el vehiculo nuevo en la colecció de datos
                                if (cont != 1000)
                                {
                                    Repostaje report = new Repostaje(fecha, NKM, Litros, Coste);
                                    ObservableCollection<Repostaje> repostas = new ObservableCollection<Repostaje>();
                                    repostas.Add(report);

                                    NKMf = NKM;
                                    Datos tempdatos = new Datos(m, palabra[1], NKMf, MediaLitros, MediaCoste, repostas, contar);
                                    datos.Add(tempdatos);


                                }
                            }
                        }
                    }

                    
                }
            }

        }

        private void Borrar_datos_Click(object sender, RoutedEventArgs e)
        {
            //Comprueba que haya un elemento  seleccionado en la tabla1
            if (Lista1.SelectedItem != null)
            {
                int i, j = 0;
                string[] palabra = new string[2];
                string ayuda = Lista1.SelectedItem.ToString();
                palabra = ayuda.Split('\u0020');
                for (i = 0; i < datos.Count; i++)
                {
                    if (datos[i].Matricula.ToString() == palabra[0])
                    {
                        //Si una matriucla cuadra con la matricula de la tabla 1 se elemina ese coche
                        datos.Remove(datos[i]);
                        Lista1.Items.Refresh();
                        Lista2.Items.Clear();
                        crearpolilineasEventArgs cp = new crearpolilineasEventArgs(null);
                        OncreaPolilineas(cp); ;
                    }
                }

            }
        }

        private void Borrar_repostaje_Click(object sender, RoutedEventArgs e)
        {
            //Comprueba que haya un elemento  seleccionado en la tabla2
            if (Lista2.SelectedItem != null)
            {
                int i, j = 0, cont = datos[Lista1.SelectedIndex].Repostajes.Count;
                string[] palabra = new string[2];
                string ayuda = Lista1.SelectedItem.ToString();
                string[] palabra2 = new string[6];
                string ayuda2 = Lista2.SelectedItem.ToString();

                palabra = ayuda.Split('\u0020');
                palabra2 = ayuda2.Split('\u0020');
                string[] temporal = datos[Lista1.SelectedIndex].Matricula.Split('\u002D');
                Matricula m = new Matricula(temporal[0], temporal[1]);
                for (i = 0; i < datos.Count; i++)
                {
                    if (datos[i].Matricula.ToString() == palabra[0])
                    {
                        for (j = 0; j < datos[i].Repostajes.Count; j++)
                        {
                            if (datos[i].Repostajes[j].Kilometraje == Convert.ToInt32(palabra2[2]))
                            //Si una matricula cuadra con la matricula de la tabla 2 se elemina ese repostaje
                            {

                                datos[i].Repostajes.Remove(datos[i].Repostajes[j]);
                                Datos datos2 = new Datos(m, datos[i].Marca, datos[i].Kilometrajet, datos[i].MediaLitros, datos[i].MediaCoste, datos[i].Repostajes, cont);

                                datos[i].MediaLitros = datos2.MediaLitros;

                                datos[i].MediaCoste = datos2.MediaCoste;
                                if(datos2.Repostajes.Count - 1>=0)
                                {
                                     datos[i].Kilometrajet = datos2.Repostajes[datos2.Repostajes.Count-1].Kilometraje;
                                }
                                else { 
                                    datos[i].Kilometrajet = 0; 
                                }
                                crearBarrasEventArgs cb = new crearBarrasEventArgs();
                                OncreaBarras(cb);
                               
                            }
                        }
                    }
                }
            }
        }

        private void Lista2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Borrar_repostaje.IsEnabled = true;
        }

        private void Añadirtxt_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(BD);
            String linea;
            for(int i=0; i < datos.Count; i++)
            {
                string linea2=datos[i].ToStringComas();
                for(int j=0; j < datos[i].Repostajes.Count; j++)
                {
                    string linea3=datos[i].Repostajes[j].ToStringComas();
                    linea = linea2 + linea3;
                    sw.WriteLine(linea);
               
                }
            }
            sw.Close();
        }

    }

}


