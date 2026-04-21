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
    }
}
