using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.Domain;
using TerceraEntrega.DA; 

namespace TerceraEntrega.BL
{
    public class PersonajeBL
    {
        public static int Crear(Personaje p, Clase clase, Raza raza)
        {
            int retorno = -1;
            retorno = PersonajeDA.Crear(p, clase, raza);
            return retorno;
        }

        public static Personaje Obtener(int id)
        {
            Personaje aux = new Personaje();
            aux = PersonajeDA.Obtener(id);
            return aux;
        }

        public static int Modificar(Personaje p, Clase clase, Raza raza)
        {
            int retorno = -1;
            retorno = PersonajeDA.Modificar(p, clase, raza);
            return retorno;
        }

        public static List<Personaje> Listar()
        {
            List<Personaje> aux = new List<Personaje>();
            aux = PersonajeDA.Listar();
            return aux;
        }

        public static int Eliminar(Personaje p)
        {
            int retorno = -1;
            retorno = PersonajeDA.Eliminar(p);
            return retorno;
        }
        public static void asignarHabilidadEspecialAPersonaje(HabilidadEspecial habilidadEspecial, Personaje personaje)
        {
            PersonajeDA.asignarHabilidadEspecialAPersonaje(habilidadEspecial, personaje);
        }


		public static void SubirNivel(Personaje personaje, HabilidadEspecial habilidadEspecial, PersonajeCaracteristica item)
		{
			if (habilidadEspecial!=null) PersonajeBL.asignarHabilidadEspecialAPersonaje(habilidadEspecial, personaje);

			if (((personaje.Nivel + 1) % 2 != 0) && ((personaje.Nivel + 1) != 1))
			{
				if (item != null) {
					item.Valor++;
					PersonajeCaracteristicaBL.Modificar(item);
				}
			}
				
			personaje.Nivel++;

			PersonajeBL.Modificar(personaje, null, null);
		}


	}

}

