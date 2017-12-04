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
using TerceraEntrega.Personaje;

namespace TerceraEntrega
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Page
    {
        public Principal()
        {
            InitializeComponent();
        }
               

        private void btoAltaPersonaje(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AltaPersonaje());

        }

        private void btoManejadorCarVariable(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CVariable());
        }

        private void btoManejadorClase(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ManejadorClase());
        }

        private void btoManejadorRaza(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ManejadorRaza());
        }

        private void btoManejadorHE(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ManejadorHE());
        }

        private void btoListarPersonaje(object sender, RoutedEventArgs e)
        {
			this.NavigationService.Navigate(new ListaPersonaje());
		}
    }
}
