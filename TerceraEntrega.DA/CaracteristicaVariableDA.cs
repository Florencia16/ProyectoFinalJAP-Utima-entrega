using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.Domain;
using System.Data.SqlClient;

namespace TerceraEntrega.DA
{
    public class CaracteristicaVariableDA : Conectar
    {
        public static int Crear(CaracteristicaVariable caracteristica)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "INSERT INTO CaracteristicaVariable (Nombre) OUTPUT INSERTED.ID VALUES (@Nombre)";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Nombre", caracteristica.nombre);


                Connection.Open();
                result = (int)Comando.ExecuteScalar();
            }

            foreach (Personaje personaje in PersonajeDA.Listar())
            {

                using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
                {
                    string query = "INSERT INTO PersonajeCaracterisitica (IdPER, IdCAR, Valor) VALUES (@IdPER, @IdCAR, @Valor)";
                    SqlCommand Comando = new SqlCommand(query, Connection);
                    Comando.Parameters.AddWithValue("@IdPER", personaje.Id);
                    Comando.Parameters.AddWithValue("@IdCAR", result);
                    Comando.Parameters.AddWithValue("@Valor", 1);
                    Connection.Open();
                    result = Comando.ExecuteNonQuery();
                }

            }



            return result;
        }

        public static int Modificar(CaracteristicaVariable caracteristica)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "UPDATE CaracteristicaVariable SET Nombre= @Nombre WHERE Id= @Id";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Nombre", caracteristica.nombre);
                Comando.Parameters.AddWithValue("@Id", caracteristica.Id);
                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;
        }

        public static CaracteristicaVariable Obtener(int id)
        {
            CaracteristicaVariable retorno = null;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT Id,Nombre FROM CaracteristicaVariable WHERE Id = @Id";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Id", id);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    retorno = new CaracteristicaVariable();
                    retorno.Id = (int)reader["Id"];
                    retorno.nombre = reader["Nombre"].ToString();

                }

            }
            return retorno;
        }

        public static List<CaracteristicaVariable> Listar()
        {
            List<CaracteristicaVariable> retorno = null;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT Id,Nombre FROM CaracteristicaVariable";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    if (retorno == null)
                    {
                        retorno = new List<CaracteristicaVariable>();
                    }
                    CaracteristicaVariable caracteristica = new CaracteristicaVariable();
                    caracteristica.Id = (int)reader["Id"];
                    caracteristica.nombre = reader["Nombre"].ToString();

                    retorno.Add(caracteristica);
                }

            }
            return retorno;
        }

        public static int Eliminar(CaracteristicaVariable caracteristica)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "DELETE FROM CaracteristicaVariable WHERE Id = @id ";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@id", caracteristica.Id);
                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;
        }

        public static CaracteristicaVariable ObtenerPorRaza(int idRaza)
        {
            CaracteristicaVariable retorno = null;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT cv.Id,cv.Nombre FROM CaracteristicaVariable cv, Raza r WHERE r.CaraVaId = cv.Id AND r.Id=@Id";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Id", idRaza);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    retorno = new CaracteristicaVariable();
                    retorno.Id = (int)reader["Id"];
                    retorno.nombre = reader["Nombre"].ToString();

                }

            }
            return retorno;
        }
    }
}
