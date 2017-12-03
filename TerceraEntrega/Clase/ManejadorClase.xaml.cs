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
using TerceraEntrega.BL;
using TerceraEntrega.Domain; 

namespace TerceraEntrega
{
    /// <summary>
    /// Lógica de interacción para ManejadorClase.xaml
    /// </summary>
    public partial class ManejadorClase : Page
    {
        public ManejadorClase()
        {
            InitializeComponent();
            ListClase.ItemsSource = ClaseBL.Listar();

        }
            
       
        private void ListClase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btoCargar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.NomTxt.Text))
                {
                    throw new Exception("Debe especificar un nombre para la Clase");
                }
                if (string.IsNullOrEmpty(this.DesTxt.Text))
                {
                    throw new Exception("Debe especificar una Descripción para la Clase");
                }
                Clase laclase = new Clase();
                laclase.Nombre = NomTxt.Text;
                laclase.Descripcion = DesTxt.Text;
                int newClase = ClaseBL.Crear(laclase);
                if (newClase > 0)
                {
                    MessageBox.Show("Clase Ingresada Correctamente", "Correcto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListClase.ItemsSource = ClaseBL.Listar();
        }

        private void btoModificar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.NomTxt.Text))
                {
                    throw new Exception("Debe especificar un nombre para la Clase");
                }
                if (string.IsNullOrEmpty(this.DesTxt.Text))
                {
                    throw new Exception("Debe especificar una Descripción para la Clase");
                }
                Clase SelectItem = (Clase)ListClase.SelectedItem;
                SelectItem.Nombre = NomTxt.Text;
                SelectItem.Descripcion = DesTxt.Text;
                int modClase = ClaseBL.Modificar(SelectItem);
                if (modClase > 0)
                {
                    MessageBox.Show("Clase Modificada Correctamente", "Correcto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListClase.ItemsSource = ClaseBL.Listar();
        }

        private void btoEliminar(object sender, RoutedEventArgs e)
        {
            try
            {

                Clase SelectItem = (Clase)ListClase.SelectedItem;

                int removeClase = ClaseBL.Eliminar(SelectItem);
                if (removeClase > 0)
                {
                    MessageBox.Show("Clase Eliminada Correctamente", "Correcto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListClase.ItemsSource = ClaseBL.Listar();
        }

        private void btoVolver(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

       
    }
}
