using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerceraEntrega.Domain
{
    public class PersonajeCaracteristica
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public CaracteristicaVariable CaracteristicaVariable { get; set; }
        public Personaje Personaje { get; set; }
    }
}
