using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerceraEntrega.DA
{
    public class Conectar
    {
        private static readonly Conectar _instancia = new Conectar();
        public static Conectar Instancia
        {
            get
            {
                return _instancia;
            }
        }
        public Conectar()
        {
        }
        
        public string CadenaConexion()
        {
            string _Connection = "Integrated Security = SSPI; Persist Security Info= False; Initial Catalog = DBFinal; Data Source =DESKTOP-O8S2K8B\\SQLEXPRESS";
            return _Connection; 
        }
       

    }
    
}
