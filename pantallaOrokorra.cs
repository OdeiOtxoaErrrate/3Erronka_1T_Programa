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
    public partial class pantallaOrokorra : Form
    {
        public pantallaOrokorra()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = zita_id.Text; langileOrokorra.zita_eguneratu(id);

            zita_id.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tabla = langileOrokorra.zitak_ikusi();

            dataGridView1.DataSource = tabla;
        }
    }
}
