using erronka3_1T;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
namespace erronka3_iT
{
    internal class admin : langileBurua
    {

        public admin(int id, String izena, String abizena, String postua, String helbidea, String email, int telefonoa, String pasahitza) : base(id, izena, abizena, postua, helbidea, email, telefonoa, pasahitza)
        {

        }
        public static void langileak_ezabatu(string id)
        {
            string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";
            string query = "DELETE FROM langileak WHERE id = @id";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@id", id);
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Langilea behar bezala ezabatu da.");
                    }
                    else
                    {
                        MessageBox.Show("Ez da aurkitu ID hori duen erregistrorik.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea langilea ezabatzeko: " + ex.Message);
                }
            }
        }

    }
}
