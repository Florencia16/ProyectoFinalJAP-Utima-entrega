using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerceraEntrega.Domain
{
    public class Raza
    {
        public int Id;
        public string nombre;
        public string Descripcion;
        public List<Personaje> Personajes { get; set; }
        public CaracteristicaVariable CaracteristicaVariable { get; set; }
        public int Bonus { get; set; }
        public override string ToString()
        {
            return this.nombre;
        }

    }
}