using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.Domain;
using TerceraEntrega.DA; 

namespace TerceraEntrega.BL
{
    public class PersonajeCaracteristicaBL
    {
        public static void Crear(int IdP, int IdC, int valor)
        {
            PersonajeCaracteristicaDA.Crear( IdP,  IdC,  valor);

        }
        public static void Modificar(PersonajeCaracteristica personajeCaracteristica)
        {
            PersonajeCaracteristicaDA.Modificar(personajeCaracteristica);

        }
        public static List<PersonajeCaracteristica> Listar()
        {
            List<PersonajeCaracteristica> aux = new List<PersonajeCaracteristica>();
            aux = PersonajeCaracteristicaDA.Listar();
            return aux;
        }
        public static List<PersonajeCaracteristica> obtenerCaracteristicaPersonajesPorPersonaje(int id)
        {
            List<PersonajeCaracteristica> aux = new List<PersonajeCaracteristica>();
            aux = PersonajeCaracteristicaDA.obtenerCaracteristicaPersonajesPorPersonaje(id);
            return aux;
        }

		public static void eliminarPersonajeCarcteristicasPorPersonaje(int idPersonaje)
		{
			PersonajeCaracteristicaDA.EliminarPorPersonaje(idPersonaje);
		}

	}
}
