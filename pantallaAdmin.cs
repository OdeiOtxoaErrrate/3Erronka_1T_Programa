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
    }
}
