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
        public static void langileak_gehitu(string izena, string abizena, string pasahitza, string email, string postua, string telefonoa, string helbidea, string erabiltzailea)
        {


            string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";
            string query = "INSERT INTO langileak (izena, abizena, postua, helbidea, email, telefonoa, pasahitza, erabiltzailea) VALUES (@izena, @abizena, @postua, @helbidea, @email, @telefonoa, @pasahitza,@erabiltzailea)";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@izena", izena);
                    comando.Parameters.AddWithValue("@abizena", abizena);
                    comando.Parameters.AddWithValue("@postua", postua);
                    comando.Parameters.AddWithValue("@helbidea", helbidea);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@telefonoa", telefonoa);
                    comando.Parameters.AddWithValue("@pasahitza", pasahitza);
                    comando.Parameters.AddWithValue("@erabiltzailea", erabiltzailea);
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Langilea behar bezala gehitu da.");
                    }
                    else
                    {
                        MessageBox.Show("Errorea langilea gehitzean.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea langilea gehitzean: " + ex.Message);
                }
            }
        }
        public static void langile_datua_aldatu(string id, string eremua, string datuBerria)
        {
            string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";
            string query = $"UPDATE langileak SET {eremua} = @datuBerria WHERE id = @id";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@datuBerria", datuBerria);
                    comando.Parameters.AddWithValue("@id", id);
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Langilearen datua behar bezala aldatu da.");
                    }
                    else
                    {
                        MessageBox.Show("Ez da aurkitu ID hori duen erregistrorik.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea langilearen datua aldatzean: " + ex.Message);
                }
            }
        }
    }
}
