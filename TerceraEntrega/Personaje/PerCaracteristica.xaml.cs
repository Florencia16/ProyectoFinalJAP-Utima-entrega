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
            try
            {
                int valor = 0;
                bool completo = false; 
                CaracteristicaVariable SelectItem = (CaracteristicaVariable)ListCaracteristica.SelectedItem;
                int IdPersonaje = PersonajeBL.Listar().Max(x => x.Id);
                foreach (CaracteristicaVariable Car in CaracteristicaVariableBL.Listar())
                {
                    PersonajeCaracteristicaBL.Crear(IdPersonaje, Car.Id, valor);
                }
                valor = Convert.ToInt32(ValorTxt.Text);
                string result = ValorTxt.Text;
                if (result == null || result == "" || !int.TryParse(result, out valor) || valor <= 0 || valor > 10)
                {
                    MessageBox.Show("El valor Ingresado no es el correcto, intente nuevamente", "Error");
                }
                else
                {
                        PersonajeCaracteristica Aux = new PersonajeCaracteristica();
                        Aux.CaracteristicaVariable = SelectItem;
                        Aux.Personaje = PersonajeBL.Obtener(IdPersonaje);
                        Aux.Valor = valor;
                        PersonajeCaracteristicaBL.Modificar(Aux);
                        MessageBox.Show("Se cargo el valor exitosamente para el Personaje: " + PersonajeBL.Obtener(IdPersonaje).Nombre, "Felicidades");

                }
                foreach (PersonajeCaracteristica PerCar in PersonajeCaracteristicaBL.Listar())
                {
                    foreach (CaracteristicaVariable C in CaracteristicaVariableBL.Listar())
                    {

                        if ((PerCar.Personaje.Id == IdPersonaje) && (PerCar.CaracteristicaVariable.Id == C.Id) && (PerCar.Valor != 0))
                        {
                            completo= true;
                        }
                    }                  
                    
                }
                if (completo)
                {
                    MessageBox.Show("Has completado todas las caracteristicas variables existentes en el sistema para este Personaje", "Genial!!");

                }
            }
            

            catch (Exception ex)
            {
                MessageBox.Show("Existe un error"+ex, "Cuidado!!!!");
            }

        }

        private void btoVolver(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }

}
