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
    }
}
