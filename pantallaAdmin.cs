using erronka3_iT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace erronka3_1T
{
    public partial class pantallaAdmin : Form
    {
        public pantallaAdmin()
        {
            InitializeComponent();
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

        private void button6_Click(object sender, EventArgs e)
        {
            string id = textBox10.Text; admin.langileak_ezabatu(id);

            textBox10.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox9.Text;
            langileBurua.bezeroak_ezabatu(id);
            textBox9.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable tabla = langileOrokorra.zitak_ikusi();
            dataGridView1.DataSource = tabla;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable tabla = langileBurua.hornitzaile_eta_langilearen_erlazioak_ikusi();
            dataGridView1.DataSource = tabla;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string izena = b_izena.Text;
            string abizena = b_abizena.Text;
            string email = b_email.Text;
            string NAN = b_nan.Text;
            string telefonoa = b_telefonoa.Text;
            string helbidea = b_helbidea.Text;
            string pasahitza = b_pasahitza.Text;
            string suskripzioa = b_suskripzioa.Text;

            langileBurua.bezeroak_gehitu(izena, abizena, pasahitza, email, NAN, telefonoa, helbidea, suskripzioa);
            b_izena.Clear();
            b_abizena.Clear();
            b_email.Clear();
            b_nan.Clear();
            b_telefonoa.Clear();
            b_helbidea.Clear();
            b_pasahitza.Clear();
            b_suskripzioa.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string izena = l_izena.Text;
            string abizena = l_abizena.Text;
            string pasahitza = l_pasahitza.Text;
            string email = l_email.Text;
            string postua = l_postua.Text;
            string telefonoa = l_telefonoa.Text;
            string helbidea = l_helbidea.Text;
            string erabiltzailea = l_erabiltzailea.Text;

            admin.langileak_gehitu(izena, abizena, pasahitza, email, postua, telefonoa, helbidea, erabiltzailea);
            l_izena.Clear();
            l_abizena.Clear();
            l_pasahitza.Clear();
            l_email.Clear();
            l_postua.Clear();
            l_telefonoa.Clear();
            l_helbidea.Clear();
            l_erabiltzailea.Clear();
        }
    }
}
