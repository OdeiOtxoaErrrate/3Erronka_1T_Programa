using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace erronka3_1T
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string erabiltzailea = textBox1.Text; string pasahitza = textBox2.Text; string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;"; using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    string query = "SELECT postua FROM langileak WHERE erabiltzailea = @user AND pasahitza = @pass";

                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@user", erabiltzailea);
                    comando.Parameters.AddWithValue("@pass", pasahitza);

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        string puesto = resultado.ToString();
                        MessageBox.Show("¡Ongi etorri! Zure postua: " + puesto);

                        this.Hide();

                        switch (puesto.ToLower())
                        {
                            case "admin":
                                Form pantallaAdmin = new pantallaAdmin();
                                pantallaAdmin.ShowDialog();
                                break;

                            case "langile burua":
                                Form pantallaBurua = new pantallaBurua();
                                pantallaBurua.ShowDialog();
                                break;

                            case "langile orokorra":
                                Form pantallaOrokorra = new pantallaOrokorra();
                                pantallaOrokorra.ShowDialog();
                                break;

                            default:
                                MessageBox.Show("Postua ez da errekonozitu.");
                                break;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erabiltzailea edo pasahitza okerra.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea konexioan: " + ex.Message);
                }
            }

        }
    }
}
