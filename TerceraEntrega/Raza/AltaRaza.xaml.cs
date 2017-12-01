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
using TerceraEntrega.Domain;
using TerceraEntrega.BL;

namespace TerceraEntrega
{
    /// <summary>
    /// Lógica de interacción para AltaRaza.xaml
    /// </summary>
    public partial class AltaRaza : Page
    {
        public AltaRaza()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Raza laraza = new Raza();
            this.NombreTxt.Text = laraza.nombre;
            this.DescripcionTxt.Text = laraza.Descripcion;
            laraza.Bonus = int.Parse(this.BonusTxt.Text);
            RazaBL.Crear(laraza); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
