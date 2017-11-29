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

    }
}
