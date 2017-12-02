using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.Domain;
using System.Data.SqlClient;

namespace TerceraEntrega.DA
{
    public class PersonajeDA : Conectar
    {

        public static int Crear(Personaje p, Clase clase, Raza raza)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "INSERT INTO Personaje (Nombre, Nivel, Fuerza, Destreza, Constitucion, Inteligencia, Sabiduria, Carisma, ClaseId, RazaId, ImagenPers) VALUES (@Nombre, @Nivel, @Fuerza, @Destreza, @Constitucion, @Inteligencia, @Sabiduria, @Carisma, @ClaseId, @RazaId, @ImagenPers)";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Nombre", p.Nombre);
                Comando.Parameters.AddWithValue("@Nivel", p.Nivel);
                Comando.Parameters.AddWithValue("@Fuerza", p.Fuerza);
                Comando.Parameters.AddWithValue("@Destreza", p.Destreza);
                Comando.Parameters.AddWithValue("@Constitucion", p.Constitucion);
                Comando.Parameters.AddWithValue("@Inteligencia", p.Inteligencia);
                Comando.Parameters.AddWithValue("@Sabiduria", p.Sabiduria);
                Comando.Parameters.AddWithValue("@Carisma", p.Carisma);
                Comando.Parameters.AddWithValue("@ClaseId", clase.Id);
                Comando.Parameters.AddWithValue("@RazaId", raza.Id);
                Comando.Parameters.AddWithValue("@ImagenPers", p.Imagen);
                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;
        }


        public static int Modificar(Personaje p, Clase clase, Raza raza)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "UPDATE Personaje SET Nombre = @Nombre, Nivel = @Nivel, Fuerza = @Fuerza, Destreza = @Destreza, Constitucion = @Constitucion, Inteligencia = @Inteligencia, Sabiduria = @Sabiduria, Carisma = @Carisma";
                string where = " WHERE Id= @Id";
                if (clase != null)
                {
                    query += ", ClaseId = @ClaseId";
                }
                else if (raza != null)
                {
                    query += ", RazaId = @RazaId";
                }
                query += where;
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Id", p.Id);
                Comando.Parameters.AddWithValue("@Nombre", p.Nombre);
                Comando.Parameters.AddWithValue("@Nivel", p.Nivel);
                Comando.Parameters.AddWithValue("@Fuerza", p.Fuerza);
                Comando.Parameters.AddWithValue("@Destreza", p.Destreza);
                Comando.Parameters.AddWithValue("@Constitucion", p.Constitucion);
                Comando.Parameters.AddWithValue("@Inteligencia", p.Inteligencia);
                Comando.Parameters.AddWithValue("@Sabiduria", p.Sabiduria);
                Comando.Parameters.AddWithValue("@Carisma", p.Carisma);
                if (clase != null) Comando.Parameters.AddWithValue("@ClaseId", clase.Id);
                if (raza != null) Comando.Parameters.AddWithValue("@RazaId", raza.Id);
                //ver el resto de los atributos falta realaciones con raza clase y habilidad especial 
                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;
        }
        public static Personaje Obtener(int id)
        {

            List<Personaje> retorno = new List<Personaje>();
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT Id, Nombre, Nivel, Fuerza, Destreza, Constitucion, Inteligencia, Sabiduria, Carisma, Imagen FROM Personaje WHERE Id=" + id;
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    if (retorno == null)
                    {
                        retorno = new List<Personaje>();
                    }
                    Personaje p = new Personaje();
                    p.Id = (int)reader["Id"];
                    p.Nombre = reader["Nombre"].ToString();
                    p.Nivel = (int)reader["Nivel"];
                    p.Fuerza = (int)reader["Fuerza"];
                    p.Destreza = (int)reader["Destreza"];
                    p.Constitucion = (int)reader["Constitucion"];
                    p.Inteligencia = (int)reader["Inteligencia"];
                    p.Sabiduria = (int)reader["Sabiduria"];
                    p.Carisma = (int)reader["Carisma"];
                    p.Imagen=(byte[])reader["Imagen"]; 
                    p.HabilidadesEspeciales = HabilidadEspecialDA.obtenerHabilidadesEspecialesDePersonaje(p.Id);
                    retorno.Add(p);
                }

            }
            return (retorno.Count > 0) ? retorno[0] : null;

        }
        public static List<Personaje> Listar()
        {
            List<Personaje> retorno = new List<Personaje>();
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT Id, Nombre, Nivel, Fuerza, Destreza, Constitucion, Inteligencia, Sabiduria, Carisma FROM Personaje";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    if (retorno == null)
                    {
                        retorno = new List<Personaje>();
                    }
                    Personaje p = new Personaje();
                    p.Id = (int)reader["Id"];
                    p.Nombre = reader["Nombre"].ToString();
                    p.Nivel = (int)reader["Nivel"];
                    p.Fuerza = (int)reader["Fuerza"];
                    p.Destreza = (int)reader["Destreza"];
                    p.Constitucion = (int)reader["Constitucion"];
                    p.Inteligencia = (int)reader["Inteligencia"];
                    p.Sabiduria = (int)reader["Sabiduria"];
                    p.Carisma = (int)reader["Carisma"];
                    retorno.Add(p);
                }

            }
            return retorno;

        }


        public static int Eliminar(Personaje p)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "DELETE FROM Personaje WHERE Id = @id ";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@id", p.Id);
                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;

        }

        public static List<Personaje> ObtenerPorRaza(int idRaza)
        {
            List<Personaje> retorno = new List<Personaje>();
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT Id, Nombre, Nivel, Fuerza, Destreza, Constitucion, Inteligencia, Sabiduria, Carisma FROM Personaje WHERE RazaId=" + idRaza;
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    if (retorno == null)
                    {
                        retorno = new List<Personaje>();
                    }
                    Personaje p = new Personaje();
                    p.Id = (int)reader["Id"];
                    p.Nombre = reader["Nombre"].ToString();
                    p.Nivel = (int)reader["Nivel"];
                    p.Fuerza = (int)reader["Fuerza"];
                    p.Destreza = (int)reader["Destreza"];
                    p.Constitucion = (int)reader["Constitucion"];
                    p.Inteligencia = (int)reader["Inteligencia"];
                    p.Sabiduria = (int)reader["Sabiduria"];
                    p.Carisma = (int)reader["Carisma"];
                    retorno.Add(p);
                }

            }
            return retorno;
        }

        public static List<Personaje> ObtenerPorClase(int idClase)
        {
            List<Personaje> retorno = new List<Personaje>();
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT Id, Nombre, Nivel, Fuerza, Destreza, Constitucion, Inteligencia, Sabiduria, Carisma FROM Personaje WHERE ClaseId=" + idClase;
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    if (retorno == null)
                    {
                        retorno = new List<Personaje>();
                    }
                    Personaje p = new Personaje();
                    p.Id = (int)reader["Id"];
                    p.Nombre = reader["Nombre"].ToString();
                    p.Nivel = (int)reader["Nivel"];
                    p.Fuerza = (int)reader["Fuerza"];
                    p.Destreza = (int)reader["Destreza"];
                    p.Constitucion = (int)reader["Constitucion"];
                    p.Inteligencia = (int)reader["Inteligencia"];
                    p.Sabiduria = (int)reader["Sabiduria"];
                    p.Carisma = (int)reader["Carisma"];
                    retorno.Add(p);
                }

            }
            return retorno;
        }

        public static void asignarHabilidadEspecialAPersonaje(HabilidadEspecial habilidadEspecial, Personaje personaje)
        {
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "INSERT INTO PersonajeHabilidadEspecial (IdPER, IdHe) VALUES (@IdPER, @IdHe)";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@IdPER", personaje.Id);
                Comando.Parameters.AddWithValue("@IdHe", habilidadEspecial.Id);
                Connection.Open();
                Comando.ExecuteNonQuery();
            }
        }
    }
}
