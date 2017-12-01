using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.Domain;
using TerceraEntrega.DA; 

namespace TerceraEntrega.BL
{
    public class HabilidadEspecialBL
    {
        public static int Crear(HabilidadEspecial HE)
        {
            int retorno = -1;
            retorno = HabilidadEspecialDA.Crear(HE);
            return retorno;
        }

        public static HabilidadEspecial Obtener(int id)
        {
            HabilidadEspecial aux = new HabilidadEspecial();
            aux = HabilidadEspecialDA.Obtener(id);
            return aux;
        }

        public static int Modificar(HabilidadEspecial HE)
        {
            int retorno = -1;
            retorno = HabilidadEspecialDA.Modificar(HE);
            return retorno;
        }

        public static List<HabilidadEspecial> Listar()
        {
            List<HabilidadEspecial> aux = new List<HabilidadEspecial>();
            aux = HabilidadEspecialDA.Listar();
            return aux;
        }

        public static int Eliminar(HabilidadEspecial HE)
        {
            int retorno = -1;
            retorno = HabilidadEspecialDA.Eliminar(HE);
            return retorno;
        }

    }
}

