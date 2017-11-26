using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerceraEntrega.Domain
{
    
    public class Personaje
    {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public int Nivel { get; set; }
            public int Fuerza { get; set; }
            public int Destreza { get; set; }
            public int Constitucion { get; set; }
            public int Inteligencia { get; set; }
            public int Sabiduria { get; set; }
            public int Carisma { get; set; }
            public List<HabilidadEspecial> HabilidadesEspeciales { get; set; }
    }
    

}

