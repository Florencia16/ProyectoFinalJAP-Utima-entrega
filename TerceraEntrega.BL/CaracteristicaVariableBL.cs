using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.DA;
using TerceraEntrega.Domain;

namespace TerceraEntrega.BL
{
    public class CaracteristicaVariableBL
    {
        public static int Crear(CaracteristicaVariable caracteristica)
        {
            int result = -1;
            result = CaracteristicaVariableDA.Crear(caracteristica);
            return result; 
        }

        public static CaracteristicaVariable Obtener(int id)
        {
            CaracteristicaVariable aux = new CaracteristicaVariable();
            aux = CaracteristicaVariableDA.Obtener(id);
            return aux;
        }

        public static int Modificar(CaracteristicaVariable caracteristica)
        {
            int retorno = -1;
            retorno = CaracteristicaVariableDA.Modificar(caracteristica);
            return retorno;
        }

        public static List<CaracteristicaVariable> Listar()
        {
            List<CaracteristicaVariable> aux = new List<CaracteristicaVariable>();
            aux = CaracteristicaVariableDA.Listar();
            return aux;
        }

        public static int Eliminar(CaracteristicaVariable caracteristica)
        {
            int retorno = -1;
            retorno = CaracteristicaVariableDA.Eliminar(caracteristica);
            return retorno;
        }


    }
}

