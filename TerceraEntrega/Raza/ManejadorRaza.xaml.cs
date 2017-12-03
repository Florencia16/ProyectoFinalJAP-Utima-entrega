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
    /// Lógica de interacción para ManejadorRaza.xaml
    /// </summary>
    public partial class ManejadorRaza : Page
    {
        public ManejadorRaza()
        {
            InitializeComponent();
            ListRaza.ItemsSource = RazaBL.Listar();
        }

        private void ListRaza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btoCargar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.NomTxt.Text))
                {
                    throw new Exception("Debe especificar un nombre para la Raza");
                }
                if (string.IsNullOrEmpty(this.DesTxt.Text))
                {
                    throw new Exception("Debe especificar una Descripción para la Raza");
                }
                if (string.IsNullOrEmpty(this.BonusTxt.Text))
                {
                    throw new Exception("Debe especificar un Valor de Bonus para la Raza");
                }
                Raza laRaza = new Raza();
                laRaza.nombre = NomTxt.Text;
                laRaza.Descripcion = DesTxt.Text;
                laRaza.Bonus = Convert.ToInt32(BonusTxt.Text);
                int newRaza = RazaBL.Crear(laRaza);
                if (newRaza > 0)
                {
                    MessageBox.Show("Raza Ingresada Correctamente", "Correcto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListRaza.ItemsSource = RazaBL.Listar();

        }

        private void btoModificar(object sender, RoutedEventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(this.NomTxt.Text))
                {
                    throw new Exception("Debe especificar un nombre para la Raza");
                }
                if (string.IsNullOrEmpty(this.DesTxt.Text))
                {
                    throw new Exception("Debe especificar una Descripción para la Raza");
                }
                if (string.IsNullOrEmpty(this.BonusTxt.Text))
                {
                    throw new Exception("Debe especificar un Valor de Bonus para la Raza");
                }
                Raza SelectItem = (Raza)ListRaza.SelectedItem;
                SelectItem.nombre = NomTxt.Text;
                SelectItem.Descripcion = DesTxt.Text;
                SelectItem.Bonus = Convert.ToInt32(BonusTxt.Text);
                int modRaza = RazaBL.Modificar(SelectItem);
                if (modRaza > 0)
                {
                    MessageBox.Show("Raza Modificada Correctamente", "Correcto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListRaza.ItemsSource = RazaBL.Listar();
        }

        private void btoEliminar(object sender, RoutedEventArgs e)
        {
            try
            {

                Raza SelectItem = (Raza)ListRaza.SelectedItem;

                int removeRaza = RazaBL.Eliminar(SelectItem);
                if (removeRaza > 0)
                {
                    MessageBox.Show("Raza Eliminada Correctamente", "Correcto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListRaza.ItemsSource = RazaBL.Listar();

        }

        private void btoVolver(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
