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

namespace TerceraEntrega.Personaje
{
	/// <summary>
	/// Lógica de interacción para SubirNivel.xaml
	/// </summary>
	public partial class SubirNivel : Page
	{
		public SubirNivel(int id)
		{
			InitializeComponent();


			TerceraEntrega.Domain.Personaje personaje = PersonajeBL.Obtener(id);

			List<PersonajeCaracteristica> caracteristicasPersonaje = PersonajeCaracteristicaBL.obtenerCaracteristicaPersonajesPorPersonaje(id);

			List<CaracteristicaVariable> carcateristicas = new List<CaracteristicaVariable>();

			foreach (PersonajeCaracteristica i in caracteristicasPersonaje) {
				carcateristicas.Add(i.CaracteristicaVariable);
			}

			Lista.ItemsSource = carcateristicas;

			//agregar habilidad especial

			List<HabilidadEspecial> habilidadesEspeciales = new List<HabilidadEspecial>();

			List<HabilidadEspecial> habilidadesEspecialesAMostrar = new List<HabilidadEspecial>();
			//recorro habilidades especiales de la clase del personaje
			foreach (HabilidadEspecial habilidadClase in ClaseBL.obtenerPorIdPersonaje(personaje.Id).HabilidadesEspeciales)
			{
				//si no esta en el personaje la imprimo
				bool estaEnPersonaje = false;
				foreach (HabilidadEspecial habilidadPersonaje in personaje.HabilidadesEspeciales)
				{
					if (habilidadClase.Id == habilidadPersonaje.Id) estaEnPersonaje = true;
				}
				if (!estaEnPersonaje) habilidadesEspecialesAMostrar.Add(habilidadClase);
			}

			Lista2.ItemsSource = habilidadesEspecialesAMostrar;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new Principal());
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new ListaPersonaje());
		}
	}
}
