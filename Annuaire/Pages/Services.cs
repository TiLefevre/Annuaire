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
    public partial class Services : Form
    {
        AddService form;
        public Services()
        {
            InitializeComponent();
            form = new AddService(this);
        }
        public void Display()
        {
            DBContact.DisplayAndSearch("SELECT id, Nom FROM Services", dataGridView1);
        }

        private void Services_Shown(object sender, EventArgs e)
        {
            Display();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //UPDATE
            if (e.ColumnIndex == 0)
            {
                form.Clear();
                form.Id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.Nom = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            //DELETE
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Supprimer ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBContact.DeleteServices(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddService addServiceSite = new AddService(this);
            addServiceSite.Clear();
            addServiceSite.ShowDialog();
        }
    }
}
