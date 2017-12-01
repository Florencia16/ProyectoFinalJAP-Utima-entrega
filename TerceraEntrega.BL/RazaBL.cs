using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.Domain;
using TerceraEntrega.DA; 

namespace TerceraEntrega.BL
{
    public class RazaBL
    {
        public static int Crear(Raza raza)
        {
            int retorno = -1;
            retorno = RazaDA.Crear(raza);
            return retorno;
        }

        public static Raza Obtener(int id)
        {
            Raza aux = new Raza();
            aux = RazaDA.Obtener(id);
            return aux;
        }

        public static int Modificar(Raza raza)
        {
            int retorno = -1;
            retorno = RazaDA.Modificar(raza);
            return retorno;
        }

        public static List<Raza> Listar()
        {
            List<Raza> aux = new List<Raza>();
            aux = RazaDA.Listar();
            return aux;
        }

        public static int Eliminar(Raza raza)
        {
            int retorno = -1;
            retorno = RazaDA.Eliminar(raza);
            return retorno;
        }

        public static Raza obtenerPorPersonaje(int idPersonaje)
        {
            List<Raza> aux = new List<Raza>();
            aux = Listar();
            foreach (Raza item in aux)
            {
                foreach (Personaje personaje in item.Personajes)
                {
                    if (personaje.Id == idPersonaje)
                        return item;
                }
            }
            return null;
        }


    }
}
