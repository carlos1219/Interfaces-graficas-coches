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
    /// Lógica de interacción para Opcional.xaml
    /// </summary>

    public class crearBarrasEventArgs : EventArgs
    {
        public crearBarrasEventArgs()
        {
            
        }
    }
    public partial class Opcional : Window
    {
        public ObservableCollection<Productos> productos = new ObservableCollection<Productos>();
        public ObservableCollection<Producto> producto = new ObservableCollection<Producto>();
        public ObservableCollection<Datos> datos = new ObservableCollection<Datos>();

        public event EventHandler<crearpolilineasEventArgs> crearpolilineas2;
        public event EventHandler<crearBarrasEventArgs> crearbarras;

        MainWindow main;

        public Opcional(ObservableCollection<Datos> datos2,MainWindow m)
        {
            InitializeComponent();
            this.datos = datos2;
            LlenarListView();
            listamat.ItemsSource = datos;
            ListaComprar.ItemsSource = producto;
            main = m;
        }
        void Oncreapolilineas2(crearpolilineasEventArgs e)
        {
            if (crearpolilineas2 != null)
            {
                crearpolilineas2(this, e);
            }
        }
        void OncreaBarras(crearBarrasEventArgs e)
        {
            if (crearbarras != null)
            {
                crearbarras(this, e);
            }
        }
        private void LlenarListView()
        {
            productos.Add(new Productos { Archivo = "Productos/anticongelante.jpeg", Precio = "4 €",Nombre="Anticongelante" });
            productos.Add(new Productos { Archivo = "Productos/Barra_Chocolate.jpg", Precio = "1,5 €", Nombre = "Chocolate" });
            productos.Add(new Productos { Archivo = "Productos/Chicles.jpg", Precio = "1,1 €", Nombre = "Chicles" });
            productos.Add(new Productos { Archivo = "Productos/Lava_parabrisas.jpg", Precio = "5 €", Nombre = "Lava parabrisas" });
            productos.Add(new Productos { Archivo = "Productos/Limpia_parabrisas.jpg", Precio = "12 €", Nombre = "Limpia parabrisas" });
            productos.Add(new Productos { Archivo = "Productos/Pan.jpg", Precio = "1 €", Nombre = "Pan" });
            productos.Add(new Productos { Archivo = "Productos/Pipas.jpg", Precio = "1,6 €", Nombre = "Pipas" });
            productos.Add(new Productos { Archivo = "Productos/botellas.jpeg", Precio = "1,8 €", Nombre = "Botellas" });
            productos.Add(new Productos { Archivo = "Productos/refrescos_lata.jpg", Precio = "1,3 €", Nombre = "Lata" });
            ListaTienda.ItemsSource = productos;
        }

        private void listamat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            añadir_tabla2();
        }
        private void añadir_tabla2()
        {
            if (listamat.SelectedItem == null)
            {
                listamat.ItemsSource = null;
            }
            //Si hay algún elemento seleccionado empieza a ejecutarse
            if (listamat.SelectedItem != null)
            {
                int i, j = 0;
                string[] palabra = new string[2];
                string ayuda = listamat.SelectedItem.ToString();
                palabra = ayuda.Split('\u0020');
                for (i = 0; i < datos.Count; i++)
                {
                    if (datos[i].Matricula.ToString() == palabra[0])
                    {
                        for (j = 0; j < datos[i].Repostajes.Count; j++)
                        {
                            //Comprueba que matricula corresponde con la matriucla del elemento seleccionado

                            listarepos.ItemsSource = datos[i].Repostajes;
                            
                        }
                    }
                }
            }
        }

        private void listarepos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listamat.SelectedItem != null)
            {
                if (listarepos.SelectedItem != null)
                {
                  
                }
            }
        }


        private void AñadirCarrito_Click(object sender, RoutedEventArgs e)
        {
            int c = 0,cont =0;
           
            if (ListaTienda.SelectedItem == null)
            {
                MessageBox.Show("Falta seleccionar el producto");
            }
            if (ListaTienda.SelectedItem != null)
            {
                for(int i= 0; i<ListaTienda.Items.Count; i++)
            {
                    if(i == ListaTienda.SelectedIndex)
                        {
                            if (producto.Count == 0)
                            {
                                Producto p = new Producto(productos[i].Precio, productos[i].Nombre, ++c);
                                producto.Add(p);
                            }
                            else
                            {
                                for (int j = 0; j < producto.Count; j++)
                                {
                                if (productos[i].Nombre == producto[j].Nombre)
                                {
                                    producto[j].Cantidad += 1;

                                   
                                    cont = 1000;
                                    ListaComprar.Items.Refresh();
                                    break;
                                }
                                
                                }
                                if(cont != 1000)
                            {
                                Producto p = new Producto(productos[i].Precio, productos[i].Nombre, ++c);
                                producto.Add(p);

                            }
                            }

                    }
                }
            }
            
        }

        private void BorrarCarrito_Click(object sender, RoutedEventArgs e)
        {
            if (ListaComprar.SelectedItem == null)
            {
                MessageBox.Show("Falta seleccionar el producto");
            }
            if(producto.Count == 0)
            {
                MessageBox.Show("Carrito vacio");
            }
            if (ListaComprar.SelectedItem != null)
            {
                for (int i = 0; i < ListaTienda.Items.Count; i++)
                    for (int j = 0; j < ListaComprar.Items.Count; j++)
                    {
                        try
                        {
                            if (productos[i].Nombre == producto[ListaComprar.SelectedIndex].Nombre)
                            {
                                if (producto[ListaComprar.SelectedIndex].Cantidad > 1)
                                {
                                    producto[ListaComprar.SelectedIndex].Cantidad -= 1;
                                    ListaComprar.Items.Refresh();
                                }
                                else
                                {
                                    producto.Remove(producto[j]);
                                }
                                break;
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            
                        }
                        
                    
                    }
            }
        }

        private void Comprar_Click(object sender, RoutedEventArgs e)
        {
            double temp = 0;
            int ayuda= 0;
            if(ListaComprar.Items.Count== 0)
            {
                MessageBox.Show("Carrito vacio");
            }
            else
            {
                if (listarepos.SelectedItem != null)
                {
                    for(int i = 0; i < datos.Count; i++)
                    {
                        if (datos[i] == datos[listamat.SelectedIndex])
                        {
                            for (int j= 0; j < datos[i].Repostajes.Count; j++)
                            {
                           
                                if (datos[i].Repostajes[j].Fecha == datos[i].Repostajes[listarepos.SelectedIndex].Fecha)
                                {
                                    Comprado c = new Comprado(producto, ayuda);
                                    datos[i].Repostajes[j].Preciot = c.Preciototal;
                                    //l1.refresh
                                    break;

                                }
                            }
                            for (int j = 0; j < datos[i].Repostajes.Count; j++)
                            {
                                temp = temp + datos[i].Repostajes[j].Preciot;
                            }
                            datos[i].MediaCompra =  temp / datos[i].Repostajes.Count;
                            producto.Clear();
                            if (listamat.SelectedItem != null)
                            {
                                crearpolilineasEventArgs parametro = new crearpolilineasEventArgs(datos[listamat.SelectedIndex].Repostajes);
                                Oncreapolilineas2(parametro);
                            }
                            
                            crearBarrasEventArgs parametro2 = new crearBarrasEventArgs();
                            OncreaBarras(parametro2);

                            ActualizartablasEventArgs act = new ActualizartablasEventArgs();
                            main.OnActualizartablas(act);

                        }
                    }
                }
            }
        }
    }

}
