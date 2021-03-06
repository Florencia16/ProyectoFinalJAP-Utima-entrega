﻿using System;
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
using Microsoft.Win32;
using System.IO;
using TerceraEntrega.Personaje;

namespace TerceraEntrega
{
    /// <summary>
    /// Lógica de interacción para AltaPersonaje.xaml
    /// </summary>
    /// 
    public partial class AltaPersonaje : Page
    {
		TerceraEntrega.Domain.Personaje p = new TerceraEntrega.Domain.Personaje();
        Clase c = new Clase();
        Raza r = new Raza(); 
        byte[] imagen;
        BitmapDecoder bitCoder;

        private enum TipoMensaje
        {
            Default = 0,
            Correcto = 1,
            Error = 2
        }


        public AltaPersonaje()
        {
            InitializeComponent();

            CboRaza.ItemsSource = RazaBL.Listar();
            CboRaza.SelectedValuePath = "Id";

            CboClase.ItemsSource = ClaseBL.Listar();
            CboClase.SelectedValuePath = "Id";
            
            
        }

		public AltaPersonaje(int id, Boolean readOnly)
        {
            InitializeComponent();

            CboRaza.ItemsSource = RazaBL.Listar();
            CboRaza.SelectedValuePath = "Id";

            CboClase.ItemsSource = ClaseBL.Listar();
            CboClase.SelectedValuePath = "Id";

			p = PersonajeBL.Obtener(id);
			c = ClaseBL.obtenerPorIdPersonaje(id);
			r = RazaBL.obtenerPorPersonaje(id);

			this.NombreTxt.Text = p.Nombre;
			this.NivelTxt.Text = p.Nivel.ToString();
			this.FueTxt.Text = p.Fuerza.ToString();
			this.DesTXT.Text = p.Destreza.ToString();
			this.ConstTxt.Text = p.Constitucion.ToString();
			this.InteTxt.Text = p.Inteligencia.ToString();
			this.SabTxt.Text = p.Sabiduria.ToString();
			this.CarTxt.Text = p.Carisma.ToString();
			this.Foto.Source = LoadImage(p.Imagen);

			this.CboClase.SelectedItem = 1;
			this.CboRaza.SelectedItem = 1;

			this.Titulo.Content = "Modificar Personaje";
			this.Cargar.Content = "Modificar";

			if (readOnly) {
				this.Cargar.Visibility = Visibility.Hidden;
				this.NombreTxt.IsEnabled = false;
				this.NivelTxt.IsEnabled = false;
				this.FueTxt.IsEnabled = false;
				this.DesTXT.IsEnabled = false;
				this.ConstTxt.IsEnabled = false;
				this.InteTxt.IsEnabled = false;
				this.SabTxt.IsEnabled = false;
				this.CarTxt.IsEnabled = false;
				this.CboClase.IsEnabled = false;
				this.CboRaza.IsEnabled = false;
				this.ArchivoSelect.Visibility = Visibility.Hidden;
				this.BotonCargarImagen.Visibility = Visibility.Hidden;
				this.Titulo.Content = "Detalles Personaje";
			}

		}

        private void btoCargar(object sender, RoutedEventArgs e)
        {
            try
            {                              
                int Nivel = -1;
                int Fuerza = -1;
                int Destreza = -1;
                int Constitucion = -1;
                int Inteligencia = -1;
                int Sabiduria = -1;
                int Carisma = -1; 

                //Validacion de los valores ingresados 
                if (string.IsNullOrEmpty(this.NombreTxt.Text))
                {
                    throw new Exception("Debe especificar un nombre para el personaje");
                }
                if (!int.TryParse(this.NivelTxt.Text, out Nivel) && Nivel > 0 && Nivel <10)
                {
                    throw new Exception("El nivel especificado no es válido.");
                }
                if (!int.TryParse(this.FueTxt.Text, out Fuerza) && Fuerza > 0 && Fuerza <10)
                {
                    throw new Exception("El valor de Fuerza especificado no es válido.");
                }
                if (!int.TryParse(this.DesTXT.Text, out Destreza) && Destreza > 0 && Destreza < 10)
                {
                    throw new Exception("El valor de Destreza especificado no es válido.");
                }
                if (!int.TryParse(this.ConstTxt.Text, out Constitucion) && Constitucion > 0 && Constitucion < 10)
                {
                    throw new Exception("El valor de Constitución especificado no es válido.");
                }
                if (!int.TryParse(this.InteTxt.Text, out Inteligencia) && Inteligencia > 0 && Inteligencia < 10)
                {
                    throw new Exception("El valor de Inteligencia especificado no es válido.");
                }
                if (!int.TryParse(this.SabTxt.Text, out Sabiduria) && Sabiduria > 0 && Sabiduria < 10)
                {
                    throw new Exception("El valor de Sabiduria especificado no es válido.");
                }
                if (!int.TryParse(this.CarTxt.Text, out Carisma) && Carisma > 0 && Carisma < 10)
                {
                    throw new Exception("El valor de Carisma especificado no es válido.");
                }
                if (r == null)
                {
                    throw new Exception("Debe Seleccionar una Raza al Personaje");
                }
                if (c == null)
                {
                    throw new Exception("Debe Seleccionar una Clase al Personaje");
                }



                // Asignación de datos al personaje 
                p.Nombre = NombreTxt.Text;
                p.Nivel = Nivel;
                p.Fuerza = Fuerza;
                p.Destreza = Destreza;
                p.Constitucion = Constitucion;
                p.Inteligencia = Inteligencia;
                p.Sabiduria = Sabiduria;
                p.Carisma = Carisma;
                p.Imagen = imagen;


				//Alta del Personaje
				if (p.Id == 0)
				{
					int newPersonaje = PersonajeBL.Crear(p, c, r);
					if (newPersonaje > 0)
					{
						SetClientMessage("Personaje agregado correctamente!", TipoMensaje.Correcto);
						this.NavigationService.Navigate(new PerCaracteristica());

					}
				}
				else {
					PersonajeBL.Modificar(p, c, r);
					this.NavigationService.Navigate(new ListaPersonaje());
				}
				

            }
            catch (Exception ex)
            {
                SetClientMessage(ex.Message, TipoMensaje.Error);
            }

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

        private void btoExaminar(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog OD = new OpenFileDialog();
            OD.Filter = "Imagenes jpg(*.jpg)| *.jpg | All Files(*.*) | *.*";
            if (OD.ShowDialog() == true)
            {
                using (Stream stream = OD.OpenFile())
                {
                    bitCoder = BitmapDecoder.Create(stream, BitmapCreateOptions.PreservePixelFormat,
                    BitmapCacheOption.OnLoad);
                    Foto.Source = bitCoder.Frames[0];
                    this.ArchivoSelect.Text = OD.FileName;
                }
            }
            else
            {
                Foto.Source = null;
            }
            System.IO.FileStream fs;
            fs = new System.IO.FileStream(this.ArchivoSelect.Text, System.IO.FileMode.Open);
            imagen = new byte[Convert.ToInt32(fs.Length.ToString())];
            fs.Read(imagen, 0, imagen.Length);
        }

        private void btoVolver(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void ComboRaza(object sender, SelectionChangedEventArgs e)
        {
            int PosCombo = CboRaza.SelectedIndex; 
            r = (Raza)CboRaza.SelectedItem;           
        }

        
        private void ComboClase(object sender, SelectionChangedEventArgs e)
        {
            int selectIndex = CboClase.SelectedIndex;
            c = (Clase)CboClase.SelectedItem;
        }


		private static BitmapImage LoadImage(byte[] imageData)
		{
			if (imageData == null || imageData.Length == 0) return null;
			var image = new BitmapImage();
			using (var mem = new MemoryStream(imageData))
			{
				mem.Position = 0;
				image.BeginInit();
				image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
				image.CacheOption = BitmapCacheOption.OnLoad;
				image.UriSource = null;
				image.StreamSource = mem;
				image.EndInit();
			}
			image.Freeze();
			return image;
		}


	}
    
}
