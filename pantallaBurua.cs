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
    }
}
