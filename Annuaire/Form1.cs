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
        AddContact form;
        public Form1()
        {
            InitializeComponent();
            form = new AddContact(this);
        }


       public void Display()
        {
            DBContact.DisplayAndSearch("SELECT id, Nom, Prenom, Fixe, Portable, Email, Service, Site FROM Annuaire", dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            
            AddContact addcontact = new AddContact(this);
            addcontact.Clear();
            addcontact.ShowDialog();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            DBContact.DisplayAndSearch("SELECT id, Nom, Prenom, Fixe, Portable, Email, Service, Site FROM Annuaire WHERE Nom LIKE '%"+ search.Text +"%' or Prenom LIKE '%"+ search.Text + "%' or Site LIKE '%" + search.Text + "%' or Service LIKE '%" + search.Text + "%'", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //UPDATE
            if (e.ColumnIndex == 0)
            {
                form.Clear();
                form.Id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.Nom = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.Prenom = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.Fixe = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.Portable = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.Email = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.Service = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.Site = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            //DELETE
            if(e.ColumnIndex == 1)
            {
                if(MessageBox.Show("Supprimer ?","Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBContact.DeleteContact(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sites sites = new Sites();
            sites.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            services.Show();
        }
    }
}
