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
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

           
        }

       public void Display()
        {
            DBContact.DisplayAndSearch("SELECT id, Nom, Prenom, Fixe, Portable, Email, Service, Site, Role FROM Annuaire", dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            AddContact addcontact = new AddContact(this);
            addcontact.ShowDialog();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            DBContact.DisplayAndSearch("SELECT id, Nom, Prenom, Fixe, Portable, Email, Service, Site, Role FROM Annuaire WHERE Nom LIKE '%"+ search.Text +"%' or Prenom LIKE '%"+ search.Text +"%'", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                return;
            }
            if(e.ColumnIndex == 1)
            {
                MessageBox.Show("Supprimer ?","Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
