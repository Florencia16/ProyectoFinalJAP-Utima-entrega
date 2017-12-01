using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.Domain;
using System.Data.SqlClient; 

namespace TerceraEntrega.DA
{
    public class ClaseDA : Conectar
    {

        public static int Crear(Clase Clase)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "INSERT INTO Clase (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Nombre", Clase.Nombre);
                Comando.Parameters.AddWithValue("@Descripcion", Clase.Descripcion);

                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;
        }

        public static int Modificar(Clase clase)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "UPDATE Clase SET Nombre= @Nombre, Descripcion = @Descripcion WHERE Id= @Id";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Nombre", clase.Nombre);
                Comando.Parameters.AddWithValue("@Descripcion", clase.Descripcion);
                Comando.Parameters.AddWithValue("@Id", clase.Id);
                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;
        }

        public static Clase Obtener(int id)
        {
            Clase retorno = null;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT Id,Nombre, Descripcion FROM Clase WHERE Id = @Id";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Id", id);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    retorno = new Clase();
                    retorno.Id = (int)reader["Id"];
                    retorno.Nombre = reader["Nombre"].ToString();
                    retorno.Descripcion = reader["Descripcion"].ToString();
                    retorno.Personajes = PersonajeDA.ObtenerPorClase(retorno.Id);
                }

            }
            return retorno;
        }

        public static List<Clase> Listar()
        {
            List<Clase> retorno = null;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT Id,Nombre, Descripcion FROM Clase";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    if (retorno == null)
                    {
                        retorno = new List<Clase>();
                    }
                    Clase c = new Clase();
                    c.Id = (int)reader["Id"];
                    c.Nombre = reader["Nombre"].ToString();
                    c.Descripcion = reader["Descripcion"].ToString();
                    retorno.Add(c);
                }

            }
            return retorno;
        }

        public static int Eliminar(Clase clase)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "DELETE FROM Clase WHERE Id = @id ";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@id", clase.Id);
                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;
        }

        public static Clase obtenerPorIdPersonaje(int id)
        {
            Clase retorno = null;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT c.* FROM Clase c, Personaje p WHERE p.ClaseId = c.Id AND p.Id = @Id";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Id", id);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    retorno = new Clase();
                    retorno.Id = (int)reader["Id"];
                    retorno.Nombre = reader["Nombre"].ToString();
                    retorno.Descripcion = reader["Descripcion"].ToString();
                    retorno.HabilidadesEspeciales = HabilidadEspecialDA.obtenerHabilidadesEspecialesDeClase(retorno.Id);
                }

            }
            return retorno;
        }

        public int agregarHabilidadEspecialAClase(HabilidadEspecial habilidadEspecial, Clase clase)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "INSERT INTO ClaseHabilidadEspecial (IdClas, IdHe) VALUES (@IdClas, @IdHe)";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@IdClas", clase.Id);
                Comando.Parameters.AddWithValue("@IdHe", habilidadEspecial.Id);
                Connection.Open();
                Comando.ExecuteNonQuery();
            }
            return result;
        }

        public int QuitarHabilidadEspecialAClase(HabilidadEspecial habilidadEspecial, Clase clase)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "DELETE FROM ClaseHabilidadEspecial WHERE IdHe = @idHe AND IdClas = @idClas ";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@idClas", clase.Id);
                Comando.Parameters.AddWithValue("@idHe", habilidadEspecial.Id);
                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;
        }
    }
}
