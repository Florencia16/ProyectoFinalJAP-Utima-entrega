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
    /// Lógica de interacción para CVariable.xaml
    /// </summary>
    public partial class CVariable : Page
    {
        public CVariable()
        {
            InitializeComponent();
            ListCVariable.ItemsSource = CaracteristicaVariableBL.Listar();
        }

        private void ListCVariable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btoCrear(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.NombreTxt.Text))
                {
                    throw new Exception("Debe especificar un nombre para la Habilidad Especial");
                }
                CaracteristicaVariable CarVariable = new CaracteristicaVariable();
                CarVariable.Nombre = NombreTxt.Text;
                int newCV = CaracteristicaVariableBL.Crear(CarVariable);
                if (newCV > 0)
                {
                    MessageBox.Show("CV Ingresada Correctamente", "Correcto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListCVariable.ItemsSource = CaracteristicaVariableBL.Listar();

        }

        private void btoModificar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.NombreTxt.Text))
                {
                    throw new Exception("Debe especificar un nombre para la Habilidad Especial");
                }
                CaracteristicaVariable SelectItem = (CaracteristicaVariable)ListCVariable.SelectedItem;
                SelectItem.Nombre = NombreTxt.Text;
                int modCV = CaracteristicaVariableBL.Modificar(SelectItem);
                if (modCV > 0)
                {
                    MessageBox.Show("CV Modificada Correctamente", "Correcto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListCVariable.ItemsSource = CaracteristicaVariableBL.Listar();
        }

        private void btoEliminar(object sender, RoutedEventArgs e)
        {
            try
            {

                CaracteristicaVariable SelectItem = (CaracteristicaVariable)ListCVariable.SelectedItem;

                int modCV = CaracteristicaVariableBL.Eliminar(SelectItem);
                if (modCV > 0)
                {
                    MessageBox.Show("CV Eliminada Correctamente", "Correcto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListCVariable.ItemsSource = CaracteristicaVariableBL.Listar();

        }

        private void Volver(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}

