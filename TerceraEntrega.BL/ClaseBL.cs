using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.Domain;
using TerceraEntrega.DA;

namespace TerceraEntrega.BL
{
    public class ClaseBL
    {
        public static int Crear(Clase clase)
        {
            int retorno = -1;
            retorno = ClaseDA.Crear(clase);
            return retorno;
        }

        public static Clase Obtener(int id)
        {
            Clase aux = new Clase();
            aux = ClaseDA.Obtener(id);
            return aux;
        }

        public static int Modificar(Clase clase)
        {
            int retorno = -1;
            retorno = ClaseDA.Modificar(clase);
            return retorno;
        }

        public static List<Clase> Listar()
        {
            List<Clase> aux = new List<Clase>();
            aux = ClaseDA.Listar();
            return aux;
        }

        public static int Eliminar(Clase clase)
        {
            int retorno = -1;
            retorno = ClaseDA.Eliminar(clase);
            return retorno;
        }

        public static Clase obtenerPorIdPersonaje(int id)
        {
            Clase aux = new Clase();
            aux = ClaseDA.obtenerPorIdPersonaje(id);
            return aux;
        }

        public static void agregarHabilidadEspecialAClase(HabilidadEspecial habilidadEspecial, Clase clase)
        {
            new ClaseDA().agregarHabilidadEspecialAClase(habilidadEspecial, clase);
        }

        public static void quitarHabilidadEspecialAClase(HabilidadEspecial habilidadEspecial, Clase clase)
        {
            new ClaseDA().QuitarHabilidadEspecialAClase(habilidadEspecial, clase);
        }
    }
}

