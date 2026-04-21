using erronka3_1T;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace erronka3_1T
{
    public partial class pantallaBurua : Form
    {
        public pantallaBurua()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable tabla = langileOrokorra.zitak_ikusi();

            dataGridView1.DataSource = tabla;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable tabla = langileBurua.bezeroak_ikusi();

            dataGridView1.DataSource = tabla;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable tabla = langileBurua.langileak_ikusi();

            dataGridView1.DataSource = tabla;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable tabla = langileBurua.hornitzaile_eta_langilearen_erlazioak_ikusi();

            dataGridView1.DataSource = tabla;
        }

        private void b_ezab_btn_Click(object sender, EventArgs e)
        {
            string id = bezero_id.Text; langileBurua.bezeroak_ezabatu(id);

            bezero_id.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string id = textBox9.Text;

            string eremua = izena.Text;

            string datuBerria = textBox18.Text;


            langileBurua.bezero_datua_aldatu(id, eremua, datuBerria);

            textBox9.Clear();

            textBox18.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string izena = textBox1.Text; 
            string abizena = textBox2.Text; 
            string email = textBox4.Text; 
            string NAN = textBox5.Text; 
            string telefonoa = textBox6.Text; 
            string helbidea = textBox7.Text; 
            string pasahitza = textBox3.Text; 
            string suskripzioa = textBox8.Text;

            langileBurua.bezeroak_gehitu(izena, abizena, pasahitza, email, NAN, telefonoa, helbidea, suskripzioa);

            textBox1.Clear();

            textBox2.Clear();

            textBox3.Clear();

            textBox4.Clear();

            textBox5.Clear();

            textBox6.Clear();

            textBox7.Clear();

            textBox8.Clear();
        }
    }
}
