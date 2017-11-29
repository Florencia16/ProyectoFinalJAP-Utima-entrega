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
    /// Lógica de interacción para AltaPersonaje.xaml
    /// </summary>
    /// 
    public partial class AltaPersonaje : Page
    {
        public AltaPersonaje()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int auxborrar = 0; 
            Personaje p = new Personaje();
            Clase c = new Clase();
            Raza r = new Raza(); 
            this.NombreTxt.Text = p.Nombre;
            p.Nivel =int.Parse(this.NivelTxt.Text);
            p.Sabiduria = int.Parse(this.SabTxt.Text);
            p.Destreza = int.Parse(this.DesTXT.Text);
            p.Carisma = int.Parse(this.CarTxt.Text);
            p.Constitucion = int.Parse(this.ConstTxt.Text);
            p.Fuerza = int.Parse(this.FueTxt.Text);
            p.Inteligencia = int.Parse(this.InteTxt.Text);
            

            auxborrar = PersonajeBL.Crear(p, c,  r);           
           


        }


    }
}
