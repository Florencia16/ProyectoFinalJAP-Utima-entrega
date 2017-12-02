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
            CaracteristicaVariable SelectItem = (CaracteristicaVariable)ListCaracteristica.SelectedItem;
            int IdPersonaje = PersonajeBL.Listar().Max(x => x.Id);
            int valor = Convert.ToInt32(ValorTxt.Text);
            PersonajeCaracteristicaBL.Crear(IdPersonaje, SelectItem.Id, valor); 
        }
    }

}
