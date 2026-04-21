using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace erronka3_1T

{

    internal class langileBurua : langileOrokorra
    {



        public langileBurua(int id, String izena, String abizena, String postua, String helbidea, String email, int telefonoa, String pasahitza) : base(id, izena, abizena, postua, helbidea, email, telefonoa, pasahitza)

        {


        }

        public static DataTable bezeroak_ikusi()

        {

            string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";


            string query = "SELECT * FROM bezeroak";


            using (MySqlConnection conexion = new MySqlConnection(connectionString))

            {

                try
                {

                    conexion.Open();


                    MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);


                    DataTable tabla = new DataTable();


                    adaptador.Fill(tabla);


                    return tabla;


                }

                catch (Exception ex)

                {

                    MessageBox.Show("Error al cargar las citas: " + ex.Message);

                    return null;

                }

            }

        }

        public static DataTable langileak_ikusi()

        {

            string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";


            string query = "SELECT * FROM langileak";


            using (MySqlConnection conexion = new MySqlConnection(connectionString))

            {

                try
                {

                    conexion.Open();


                    MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);


                    DataTable tabla = new DataTable();


                    adaptador.Fill(tabla);


                    return tabla;


                }

                catch (Exception ex)

                {

                    MessageBox.Show("Error al cargar las citas: " + ex.Message);

                    return null;

                }

            }

        }
        public static DataTable hornitzaile_eta_langilearen_erlazioak_ikusi()

        {

            string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";


            string query = "SELECT * FROM erlazioa_langileak_hornitzaileak";


            using (MySqlConnection conexion = new MySqlConnection(connectionString))

            {

                try
                {

                    conexion.Open();


                    MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);


                    DataTable tabla = new DataTable();


                    adaptador.Fill(tabla);


                    return tabla;


                }

                catch (Exception ex)

                {

                    MessageBox.Show("Error al cargar las citas: " + ex.Message);

                    return null;

                }

            }

        }
        public static void bezeroak_ezabatu(string id)

        {

            string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";

            string query = "DELETE FROM bezeroak WHERE id = @id";

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

                        MessageBox.Show("Bezeroa behar bezala ezabatu da.");

                    }

                    else
                    {

                        MessageBox.Show("Ez da aurkitu ID hori duen erregistrorik.");

                    }

                }

                catch (Exception ex)

                {

                    MessageBox.Show("Errorea bezeroa ezabatzeko: " + ex.Message);

                }

            }

        }
        public static void bezeroak_gehitu(string izena, string abizena, string pasahitza, string email, string NAN, string telefonoa, string helbidea, string suskripzioa)

        {

            string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";

            string query = "INSERT INTO bezeroak (izena, abizena, pasahitza, email, NAN, telefonoa, helbidea, suskripzioa) VALUES (@izena, @abizena, @pasahitza, @email, @NAN, @telefonoa, @helbidea, @suskripzioa)";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))

            {

                try
                {

                    conexion.Open();

                    MySqlCommand comando = new MySqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@izena", izena);

                    comando.Parameters.AddWithValue("@abizena", abizena);

                    comando.Parameters.AddWithValue("@pasahitza", pasahitza);

                    comando.Parameters.AddWithValue("@email", email);

                    comando.Parameters.AddWithValue("@NAN", NAN);

                    comando.Parameters.AddWithValue("@telefonoa", telefonoa);

                    comando.Parameters.AddWithValue("@helbidea", helbidea);

                    comando.Parameters.AddWithValue("@suskripzioa", suskripzioa);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)

                    {

                        MessageBox.Show("Bezeroa behar bezala gehitu da.");

                    }

                    else
                    {

                        MessageBox.Show("Errorea bezeroa gehitzean.");

                    }

                }

                catch (Exception ex)

                {

                    MessageBox.Show("Errorea bezeroa gehitzean: " + ex.Message);

                }

            }

        }
        public static void bezero_datua_aldatu(string id, string eremua, string datuBerria)
        {
            string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";
            string query = $"UPDATE bezeroak SET {eremua} = @datuBerria WHERE id = @id";
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
                        MessageBox.Show("Bezeroaren datua behar bezala aldatu da.");
                    }
                    else
                    {
                        MessageBox.Show("Ez da aurkitu ID hori duen erregistrorik.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea bezeroaren datua aldatzean: " + ex.Message);
                }
            }
        }

    }

}