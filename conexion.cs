using erronka3_1T;
using MySql.Data.MySqlClient;
using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";

try
{
    MySqlConnection conexion = new MySqlConnection(connectionString);
    conexion.Open();
    Form login = new login();
    login.ShowDialog();


    conexion.Close();
}
catch (Exception ex)
{
    MessageBox.Show("Error: " + ex.Message);
}
