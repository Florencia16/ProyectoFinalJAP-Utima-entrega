using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace TerceraEntrega.Personaje
{
    /// <summary>
    /// Lógica de interacción para ListaPersonaje.xaml
    /// </summary>
    public partial class ListaPersonaje : Page
    {

		List<PersonajeViewModel> dataSource = new List<PersonajeViewModel>();
		ICollectionView view;

		public ListaPersonaje()
        {
            InitializeComponent();
			foreach (TerceraEntrega.Domain.Personaje p in PersonajeBL.Listar()) dataSource.Add(new PersonajeViewModel(p));
			view = CollectionViewSource.GetDefaultView(dataSource);
			ListaPersonajes.ItemsSource = view;
		}

		private class PersonajeViewModel {

			public PersonajeViewModel(TerceraEntrega.Domain.Personaje p) {
				this.Id = p.Id;
				this.Nombre = p.Nombre;
				this.Nivel = p.Nivel;
				this.Fuerza = p.Fuerza;
				this.Destreza = p.Destreza;
				this.Constitucion = p.Constitucion;
				this.Inteligencia = p.Inteligencia;
				this.Sabiduria = p.Sabiduria;
				this.Carisma = p.Carisma;
				this.Imagen = p.Imagen;
				this.Raza = RazaBL.obtenerPorPersonaje(p.Id).nombre;
				this.Clase = ClaseBL.obtenerPorIdPersonaje(p.Id).Nombre;
			}

			public int Id { get; set; }
			public string Nombre { get; set; }
			public int Nivel { get; set; }
			public int Fuerza { get; set; }
			public int Destreza { get; set; }
			public int Constitucion { get; set; }
			public int Inteligencia { get; set; }
			public int Sabiduria { get; set; }
			public int Carisma { get; set; }
			public byte[] Imagen { get; set; }

			public string Raza { get; set; }
			public string Clase { get; set; }

		}

		private void verdetalle(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			PersonajeViewModel viewModel = button.DataContext as PersonajeViewModel;
			int id = viewModel.Id;
			this.NavigationService.Navigate(new AltaPersonaje(id, true));
		}

		private void editar(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			PersonajeViewModel viewModel = button.DataContext as PersonajeViewModel;
			int id = viewModel.Id;
			this.NavigationService.Navigate(new AltaPersonaje(id, false));
		}

		private void subirnivel(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			PersonajeViewModel viewModel = button.DataContext as PersonajeViewModel;
			int id = viewModel.Id;
			this.NavigationService.Navigate(new SubirNivel(id));
		}

		private void eliminar(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			PersonajeViewModel viewModel = button.DataContext as PersonajeViewModel;
			int id = viewModel.Id;
			PersonajeCaracteristicaBL.eliminarPersonajeCarcteristicasPorPersonaje(id);
			PersonajeBL.Eliminar(PersonajeBL.Obtener(id));
			dataSource.Remove(viewModel);
			view.Refresh();
		}
	}
}
