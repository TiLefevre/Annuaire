using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Annuaire.Data;
using Annuaire.Pages;
using MySql.Data.MySqlClient;

namespace Annuaire
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        public void Display()
        {
            DBContact.DisplayAndSearch("SELECT Nom, Prenom, Fixe, Portable, Email, Service, Site FROM Annuaire", dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            DBContact.DisplayAndSearch("SELECT Nom, Prenom, Fixe, Portable, Email, Service, Site FROM Annuaire WHERE Nom LIKE '%" + search.Text + "%' or Prenom LIKE '%" + search.Text + "%' or Site LIKE '%" + search.Text + "%' or Service LIKE '%" + search.Text + "%'", dataGridView1);
        }

        private void search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                popup popup = new popup();
                popup.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Display();
        }
    }
}
