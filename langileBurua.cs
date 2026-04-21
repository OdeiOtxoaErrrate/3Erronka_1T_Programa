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
    }

}