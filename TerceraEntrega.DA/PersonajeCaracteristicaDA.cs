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
        public static void Crear(int IdePer, int IdeCar, int valor)
        {
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "INSERT INTO PersonajeCaracteristica (IdPer, IdCar, Valor) VALUES (@IDPER, @IDCAR, @VALOR)";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@IdPER", IdePer);
                Comando.Parameters.AddWithValue("@IDCAR", IdeCar);
                Comando.Parameters.AddWithValue("@VALOR", valor);
                Connection.Open();
            }
        }

        public static List<PersonajeCaracteristica> Listar()
        {

            List<PersonajeCaracteristica> retorno = new List<PersonajeCaracteristica>();
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT * FROM PersonajeCaracteristica ";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    PersonajeCaracteristica laPersonajeCaracteristica = new PersonajeCaracteristica();
                    laPersonajeCaracteristica.Valor = (int)reader["Valor"];
                    laPersonajeCaracteristica.Personaje = PersonajeDA.Obtener((int)reader["IdPER"]);
                    laPersonajeCaracteristica.CaracteristicaVariable = CaracteristicaVariableDA.Obtener((int)reader["IdCAR"]);
                    retorno.Add(laPersonajeCaracteristica);
                }

            }
            return retorno;
        }
        public static void Obtener(PersonajeCaracteristica elPersonajeCaracteristica)
        {
            //personajeCaracteristica.Id = contadorId++;
            //          Datos.personajesCaracteristicas.Add(personajeCaracteristica);
        }

        public static void Eliminar(PersonajeCaracteristica elPersonajeCaracteristica)
        {
            //personajeCaracteristica.Id = contadorId++;
            //          Datos.personajesCaracteristicas.Add(personajeCaracteristica);
        }

        public static void Modificar(PersonajeCaracteristica elPersonajeCaracteristica)
        {
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "UPDATE PersonajeCaracteristica SET IdPer= @IdPER, IdCar = @IdCAR, Valor = @Valor WHERE IdPER= @IdPER AND IdCAR = @IdCAR";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@IdPER", elPersonajeCaracteristica.Personaje.Id);
                Comando.Parameters.AddWithValue("@IdCAR", elPersonajeCaracteristica.CaracteristicaVariable.Id);
                Comando.Parameters.AddWithValue("@Valor", elPersonajeCaracteristica.Valor);
                Connection.Open();
                Comando.ExecuteNonQuery();
            }
        }

        public static List<PersonajeCaracteristica> obtenerCaracteristicaPersonajesPorPersonaje(int id)
        {
            List<PersonajeCaracteristica> retorno = new List<PersonajeCaracteristica>();
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT * FROM PersonajeCaracteristica WHERE IdPer=" + id;
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    PersonajeCaracteristica laPersonajeCaracteristica = new PersonajeCaracteristica();
                    laPersonajeCaracteristica.Valor = (int)reader["Valor"];
                    laPersonajeCaracteristica.Personaje = PersonajeDA.Obtener((int)reader["IdPER"]);
                    laPersonajeCaracteristica.CaracteristicaVariable = CaracteristicaVariableDA.Obtener((int)reader["IdCAR"]);
                    retorno.Add(laPersonajeCaracteristica);
                }

            }
            return retorno;
        }

		public static void EliminarPorPersonaje(int idPersonaje)
		{
			using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
			{
				string query = "DELETE FROM PersonajeCaracteristica WHERE IdPer= @IdPER";
				SqlCommand Comando = new SqlCommand(query, Connection);
				Comando.Parameters.AddWithValue("@IdPER", idPersonaje);
				Connection.Open();
				Comando.ExecuteNonQuery();
			}
		}
	}
}
