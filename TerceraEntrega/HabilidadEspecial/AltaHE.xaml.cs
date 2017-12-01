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
    /// Lógica de interacción para AltaHE.xaml
    /// </summary>
    public partial class AltaHE : Page
    {
        public AltaHE()
        {
            InitializeComponent();

        }

        private void SetClientMessage(string message, TipoMensaje tipoMsj = TipoMensaje.Default)
        {
            switch (tipoMsj)
            {
                case TipoMensaje.Default:
                    break;
                case TipoMensaje.Correcto:
                    this.Message.Foreground = Brushes.DarkSeaGreen;
                    break;
                case TipoMensaje.Error:
                    this.Message.Foreground = Brushes.Red;
                    break;
            }


            this.Message.Text = message;
        }

        private enum TipoMensaje
        {
            Default = 0,
            Correcto = 1,
            Error = 2
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HabilidadEspecial h = new HabilidadEspecial();
                

                //Validacion de los valores ingresados 
                if (string.IsNullOrEmpty(this.Nombretxt.Text))
                {
                    throw new Exception("Debe especificar un nombre para la Habilidad Especial");
                }
                if (string.IsNullOrEmpty(this.Descripciontxt.Text))
                {
                    throw new Exception("Debe especificar una descripción para la Habilidad Especial");
                }
        
                // Asignación de datos a la HE  
                h.Nombre = Nombretxt.Text;
                h.Descripcion = Descripciontxt.Text;

                //Se obtiene la clase seleccionada del personaje a crear 



                //Alta de la HE
                int newHE = HabilidadEspecialBL.Crear(h);
                if (newHE > 0)
                {
                    SetClientMessage("Habilidad Especial agregada correctamente!", TipoMensaje.Correcto);

                }

            }
            catch (Exception ex)
            {
                SetClientMessage(ex.Message, TipoMensaje.Error);
            }


        }
    }


}
