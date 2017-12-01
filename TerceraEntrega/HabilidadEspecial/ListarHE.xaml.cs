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
    /// Lógica de interacción para ListarHE.xaml
    /// </summary>
    public partial class ListarHE : Page
    {
        public ListarHE()
        {
            InitializeComponent();
            
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<HabilidadEspecial> HE = new List<HabilidadEspecial>();
            HE = HabilidadEspecialBL.Listar();
            foreach(HabilidadEspecial h in HE)
            {
                this.ListHE.Items.Add(h); 
            }

        }
    }

}
