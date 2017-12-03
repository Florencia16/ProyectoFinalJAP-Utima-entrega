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
    /// Lógica de interacción para ManejadorHE.xaml
    /// </summary>
    public partial class ManejadorHE : Page
    {
        public ManejadorHE()
        {
            InitializeComponent();
            ListHE.ItemsSource = HabilidadEspecialBL.Listar(); 
        }

        private void ListHE_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                if (string.IsNullOrEmpty(this.DescripciónTxt.Text))
                {
                    throw new Exception("Debe especificar una Descripción para la Habilidad Especial");
                }
                HabilidadEspecial HE = new HabilidadEspecial();
                HE.Nombre = NombreTxt.Text;
                HE.Descripcion = DescripciónTxt.Text;
                int newHE = HabilidadEspecialBL.Crear(HE);
                if (newHE > 0)
                {
                    MessageBox.Show("Habilidad Especial Ingresada Correctamente", "Correcto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListHE.ItemsSource = HabilidadEspecialBL.Listar();
        }

        private void btoModificar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.NombreTxt.Text))
                {
                    throw new Exception("Debe especificar un nombre para la Habilidad Especial");
                }
                if (string.IsNullOrEmpty(this.DescripciónTxt.Text))
                {
                    throw new Exception("Debe especificar una Descripción para la Habilidad Especial");
                }
                HabilidadEspecial SelectItem = (HabilidadEspecial)ListHE.SelectedItem;
                SelectItem.Nombre = NombreTxt.Text;
                SelectItem.Descripcion = DescripciónTxt.Text;
                int modHE = HabilidadEspecialBL.Modificar(SelectItem);
                if (modHE > 0)
                {
                    MessageBox.Show("Habilidad Especial Modificada Correctamente", "Correcto");
                }
            }           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListHE.ItemsSource = HabilidadEspecialBL.Listar();
        }

        private void btoEliminar(object sender, RoutedEventArgs e)
        {
            try
            {

                HabilidadEspecial SelectItem = (HabilidadEspecial)ListHE.SelectedItem;

                int removeHE = HabilidadEspecialBL.Eliminar(SelectItem);
                if (removeHE > 0)
                {
                    MessageBox.Show("Habilidad Especial Eliminada Correctamente", "Correcto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr");
            }
            ListHE.ItemsSource = HabilidadEspecialBL.Listar();
        }

        private void btoVolver(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
