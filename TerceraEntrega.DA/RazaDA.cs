using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerceraEntrega.Domain;

namespace TerceraEntrega.DA 
{
    public class RazaDA : Conectar
    {

            public static int Crear(Raza raza)
            {
                int result = -1;
                using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
                {
                    string query = "INSERT INTO Raza (Nombre, Descripcion, Bonus, CaraVaId) VALUES (@Nombre, @Descripcion, @Bonus, @CaraVaId)";
                    SqlCommand Comando = new SqlCommand(query, Connection);
                    Comando.Parameters.AddWithValue("@Nombre", raza.nombre);
                    Comando.Parameters.AddWithValue("@Descripcion", raza.Descripcion);
                    Comando.Parameters.AddWithValue("@Bonus", raza.Bonus);
                    Comando.Parameters.AddWithValue("@CaraVaId", raza.CaracteristicaVariable.Id);
                    Connection.Open();
                    result = Comando.ExecuteNonQuery();
                }
                return result;
            }


            public static int Modificar(Raza laRaza)
            {
                int result = 0;
                using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
                {
                    string query = "UPDATE Raza SET Nombre= @Nombre, Descripcion = @Descripcion WHERE Id= @Id";
                    SqlCommand Comando = new SqlCommand(query, Connection);
                    Comando.Parameters.AddWithValue("@Nombre", laRaza.nombre);
                    Comando.Parameters.AddWithValue("@Descripcion", laRaza.Descripcion);
                    Comando.Parameters.AddWithValue("@Id", laRaza.Id);
                    Connection.Open();
                    result = Comando.ExecuteNonQuery();
                }
                return result;
            }

            public static Raza Obtener(int id)
            {
                Raza retorno = null;
                using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
                {
                    string query = "SELECT Id,Nombre, Descripcion FROM Raza WHERE Id = @Id";
                    SqlCommand Comando = new SqlCommand(query, Connection);
                    Comando.Parameters.AddWithValue("@Id", id);
                    Connection.Open();
                    SqlDataReader reader = Comando.ExecuteReader();

                    if (reader.Read())
                    {
                        retorno = new Raza();
                        retorno.Id = (int)reader["Id"];
                        retorno.nombre = reader["Nombre"].ToString();
                        retorno.Descripcion = reader["Descripcion"].ToString();
                        retorno.Personajes = PersonajeDA.ObtenerPorRaza(retorno.Id);

                    }

                }
                return retorno;
            }

            public static List<Raza> Listar()
            {
                List<Raza> retorno = new List<Raza>();
                using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
                {
                    string query = "SELECT Id,Nombre, Descripcion FROM Raza";
                    SqlCommand Comando = new SqlCommand(query, Connection);
                    Connection.Open();
                    SqlDataReader reader = Comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Raza laRaza = new Raza();
                        laRaza.Id = (int)reader["Id"];
                        laRaza.nombre = reader["Nombre"].ToString();
                        laRaza.Descripcion = reader["Descripcion"].ToString();
                        laRaza.Personajes = PersonajeDA.ObtenerPorRaza(laRaza.Id);
                        laRaza.CaracteristicaVariable = CaracteristicaVariableDA.ObtenerPorRaza(laRaza.Id);
                        retorno.Add(laRaza);
                    }

                }
                return retorno;
            }

            public static int Eliminar(Raza laRaza)
            {
                int result = 0;
                using (SqlConnection Connection = new SqlConnection(Conectar.Instancia.CadenaConexion()))
                {
                    string query = "DELETE FROM Raza WHERE Id = @id ";
                    SqlCommand Comando = new SqlCommand(query, Connection);
                    Comando.Parameters.AddWithValue("@id", laRaza.Id);
                    Connection.Open();
                    result = Comando.ExecuteNonQuery();
                }
                return result;
            }

        }
    }

