using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Annuaire.Pages
{
    public partial class popup : Form
    {
        public popup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "admin")
            {
                this.Hide();
                Form2 form2 = new Form2();
                form2.Close();
                Form1 form1 = new Form1();
                form1.Show();
            }
        }
    }
}
