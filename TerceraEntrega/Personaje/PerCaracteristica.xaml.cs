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
    /// Lógica de interacción para PerCaracteristica.xaml
    /// </summary>
    public partial class PerCaracteristica : Page
    {
        public PerCaracteristica()
        {
            InitializeComponent();
            ListCaracteristica.ItemsSource = CaracteristicaVariableBL.Listar();
        }

        private void ListCaracteristica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btoCargar_Click(object sender, RoutedEventArgs e)
        {
            bool Completo = false;
            CaracteristicaVariable SelectItem = (CaracteristicaVariable)ListCaracteristica.SelectedItem;
            int IdPersonaje = PersonajeBL.Listar().Max(x => x.Id);
            int valor = Convert.ToInt32(ValorTxt.Text);
            string result = ValorTxt.Text;
            while (result == null || result == "" || !int.TryParse(result, out valor) || valor <= 0 || valor > 10)
            {
                MessageBox.Show("El valor Ingresado no es el correcto, intente nuevamente", "Error");
                valor = Convert.ToInt32(ValorTxt.Text);
            }
            PersonajeCaracteristicaBL.Crear(IdPersonaje, SelectItem.Id, valor);
            MessageBox.Show("Se cargo el valor exitosamente para el Personaje: " + PersonajeBL.Obtener(IdPersonaje).Nombre, "Felicidades");
            foreach(PersonajeCaracteristica PerCar in PersonajeCaracteristicaBL.Listar())
            {
                if((PerCar.Personaje.Id == IdPersonaje) && (PerCar.CaracteristicaVariable.Id==SelectItem.Id)&& (valor != 0))
                {
                    Completo = true; 
                }
            }
            if (Completo == true)
            {
                MessageBox.Show("Has completado todas las caracteristicas variables existentes en el sistema para este Personaje", "Genial!!"); 
            }

        }

    }

}
