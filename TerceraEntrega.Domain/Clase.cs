using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerceraEntrega.Domain
{
    public class Clase
    {
        public int Id;
        public string Nombre;
        public String Descripcion;
        public List<Personaje> Personajes { get; set; }
        public List<HabilidadEspecial> HabilidadesEspeciales { get; set; }
    }
}
