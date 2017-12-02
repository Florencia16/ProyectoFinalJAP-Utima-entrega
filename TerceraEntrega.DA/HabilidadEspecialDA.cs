using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.Domain; 

namespace TerceraEntrega.DA
{
    public class HabilidadEspecialDA : Conectar
    {
        public static int Crear(HabilidadEspecial HE)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "INSERT INTO HabilidadEspecial (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Nombre", HE.Nombre);
                Comando.Parameters.AddWithValue("@Descripcion", HE.Descripcion);

                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;
        }

        public static int Modificar(HabilidadEspecial HE)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "UPDATE HabilidadEspecial SET Nombre= @Nombre, Descripcion = @Descripcion WHERE Id= @Id";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Nombre", HE.Nombre);
                Comando.Parameters.AddWithValue("@Descripcion", HE.Descripcion);
                Comando.Parameters.AddWithValue("@Id", HE.Id);
                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;
        }

        public static HabilidadEspecial Obtener(int id)
        {
            HabilidadEspecial retorno = null;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT Id,Nombre, Descripcion FROM HabilidadEspecial WHERE Id = @Id";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@Id", id);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    retorno = new HabilidadEspecial();
                    retorno.Id = (int)reader["Id"];
                    retorno.Nombre = reader["Nombre"].ToString();
                    retorno.Descripcion = reader["Descripcion"].ToString();
                }

            }
            return retorno;
        }

        public static List<HabilidadEspecial> Listar()
        {
            List<HabilidadEspecial> retorno = new List<HabilidadEspecial>();
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT Id,Nombre, Descripcion FROM HabilidadEspecial";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    if (retorno == null)
                    {
                        retorno = new List<HabilidadEspecial>();
                    }
                    HabilidadEspecial h = new HabilidadEspecial();
                    h.Id = (int)reader["Id"];
                    h.Nombre = reader["Nombre"].ToString();
                    h.Descripcion = reader["Descripcion"].ToString();
                    retorno.Add(h);
                }

            }
            return retorno;
        }

        public static int Eliminar(HabilidadEspecial HE)
        {
            int result = 0;
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "DELETE FROM HabilidadEspecial WHERE Id = @id ";
                SqlCommand Comando = new SqlCommand(query, Connection);
                Comando.Parameters.AddWithValue("@id", HE.Id);
                Connection.Open();
                result = Comando.ExecuteNonQuery();
            }
            return result;
        }

        public static List<HabilidadEspecial> obtenerHabilidadesEspecialesDeClase(int IdClas)
        {
            List<HabilidadEspecial> retorno = new List<HabilidadEspecial>();
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT he.* FROM HabilidadEspecial he, ClaseHabilidadEspecial che WHERE he.Id = che.IdHe AND che.IdClas = " + IdClas;
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    if (retorno == null)
                    {
                        retorno = new List<HabilidadEspecial>();
                    }
                    HabilidadEspecial h = new HabilidadEspecial();
                    h.Id = (int)reader["Id"];
                    h.Nombre = reader["Nombre"].ToString();
                    h.Descripcion = reader["Descripcion"].ToString();
                    retorno.Add(h);
                }

            }
            return retorno;
        }

        public static List<HabilidadEspecial> obtenerHabilidadesEspecialesDePersonaje(int idPersonaje)
        {
            List<HabilidadEspecial> retorno = new List<HabilidadEspecial>();
            using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
            {
                string query = "SELECT he.* FROM HabilidadEspecial he, PersonajeHabilidadEspecial phe WHERE he.Id = phe.IdHe AND phe.IdPER = " + idPersonaje;
                SqlCommand Comando = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    if (retorno == null)
                    {
                        retorno = new List<HabilidadEspecial>();
                    }
                    HabilidadEspecial h = new HabilidadEspecial();
                    h.Id = (int)reader["Id"];
                    h.Nombre = reader["Nombre"].ToString();
                    h.Descripcion = reader["Descripcion"].ToString();
                    retorno.Add(h);
                }

            }
            return retorno;
        }




    }
}
