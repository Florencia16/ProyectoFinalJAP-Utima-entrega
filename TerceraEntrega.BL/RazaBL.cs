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

    }
}
