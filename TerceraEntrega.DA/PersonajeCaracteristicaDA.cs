using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.Domain;
using System.Data.SqlClient;

namespace TerceraEntrega.DA
{
    public class PersonajeCaracteristicaDA : Conectar
    {
        public static void Modificar(PersonajeCaracteristica elPersonajeCaracteristica)
        {
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "UPDATE PersonajeCaracterisitica SET IdPER= @IdPER, IdCAR = @IdCAR, Valor = @Valor WHERE IdPER= @IdPER AND IdCAR = @IdCAR";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@IdPER", elPersonajeCaracteristica.Personaje.Id);
                Comando.Parameters.AddWithValue("@IdCAR", elPersonajeCaracteristica.CaracteristicaVariable.Id);
                Comando.Parameters.AddWithValue("@Valor", elPersonajeCaracteristica.Valor);
                Comando.Parameters.AddWithValue("@Id", elPersonajeCaracteristica.Id);
                Connection.Open();
                Comando.ExecuteNonQuery();
            }
        }

        public static List<PersonajeCaracteristica> obtenerCaracteristicaPersonajesPorPersonaje(int id)
        {
            List<PersonajeCaracteristica> retorno = new List<PersonajeCaracteristica>();
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT * FROM PersonajeCaracterisitica WHERE IdPER=" + id;
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    PersonajeCaracteristica laPersonajeCaracteristica = new PersonajeCaracteristica();
                    laPersonajeCaracteristica.Id = CaracteristicaVariableDA.Obtener((int)reader["IdCAR"]).Id;
                    laPersonajeCaracteristica.Valor = (int)reader["Valor"];
                    laPersonajeCaracteristica.Personaje = PersonajeDA.Obtener((int)reader["IdPER"]);
                    laPersonajeCaracteristica.CaracteristicaVariable = CaracteristicaVariableDA.Obtener((int)reader["IdCAR"]);
                    retorno.Add(laPersonajeCaracteristica);
                }

            }
            return retorno;
        }
    }
}
