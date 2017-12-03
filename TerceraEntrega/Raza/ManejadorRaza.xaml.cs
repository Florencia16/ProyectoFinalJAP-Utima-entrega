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

            cboCV.ItemsSource = CaracteristicaVariableBL.Listar();
            cboCV.SelectedValuePath = "Id";
        }

        Raza laRaza = new Raza();
        CaracteristicaVariable Car = new CaracteristicaVariable();

        private void ListRaza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btoCargar(object sender, RoutedEventArgs e)
        {
            int bonus = -1;
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
                if (!int.TryParse(this.BonusTxt.Text, out bonus) && bonus > 0 && bonus < 5)
                {
                    throw new Exception("El valor de Bonus especificado no es válido.");
                }
                if (Car == null)
                {
                    throw new Exception("Debe ingresar una Caracteristica Variable");
                }

                laRaza.nombre = NomTxt.Text;
                laRaza.Descripcion = DesTxt.Text;
                laRaza.Bonus = bonus;
                laRaza.CaracteristicaVariable = Car;

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
            int bonus = -1;

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
                if (!int.TryParse(this.BonusTxt.Text, out bonus) && bonus > 0 && bonus < 5)
                    {
                    throw new Exception("Debe especificar un Valor de Bonus para la Raza entre 1 y 5");
                }
                Raza SelectItem = (Raza)ListRaza.SelectedItem;
                SelectItem.nombre = NomTxt.Text;
                SelectItem.Descripcion = DesTxt.Text;
                SelectItem.Bonus = bonus;
                SelectItem.CaracteristicaVariable = Car; 
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

        private void ComboCV(object sender, SelectionChangedEventArgs e)
        {
            int PosCombo = cboCV.SelectedIndex;
            Car = (CaracteristicaVariable)cboCV.SelectedItem;
          

        }
    }
}
