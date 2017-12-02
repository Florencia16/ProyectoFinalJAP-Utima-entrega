using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerceraEntrega.Domain
{
    public class CaracteristicaVariable
    {
        public int Id;
        public String Nombre;
        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
