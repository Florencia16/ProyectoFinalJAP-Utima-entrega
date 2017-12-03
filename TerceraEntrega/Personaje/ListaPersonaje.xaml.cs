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

namespace TerceraEntrega.Personaje
{
	/// <summary>
	/// Lógica de interacción para ListaPersonaje.xaml
	/// </summary>
	public partial class ListaPersonaje : Page
	{
		public ListaPersonaje()
		{
			InitializeComponent();
			ListaPersonajes.ItemsSource = PersonajeBL.Listar();
		}
	}
}
