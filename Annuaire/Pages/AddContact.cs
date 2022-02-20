using Annuaire.Data;
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
    public partial class AddContact : Form
    {
        private readonly Form1 _parent;

        public AddContact(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void Clear()
        {
            txtNom.Text = txtPrenom.Text = txtFixe.Text = txtPortable.Text = txtEmail.Text = comboBox1.Text = comboBox2.Text = string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtNom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nom vide");
                return;
            }
            if (txtPrenom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Prenom vide");
                return;
            }
            if (txtFixe.Text.Trim().Length == 0)
            {
                MessageBox.Show("Téléphone fixe vide");
                return;
            }
            if (txtPortable.Text.Trim().Length == 0)
            {
                MessageBox.Show("Téléphone portable est vide");
                return;
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Email vide");
                return;
            }
            if (txtNom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Service vide");
                return;
            }
            if (txtNom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Site vide");
                return;
            }
            if (btnSave.Text == "Envoyer")
            {
                ContactData contact = new ContactData(txtNom.Text.Trim(), txtPrenom.Text.Trim(), txtFixe.Text.Trim(), txtPortable.Text.Trim(), txtEmail.Text.Trim(), comboBox1.Text.Trim(), comboBox2.Text.Trim(), checkBox1.Checked);
                DBContact.AddContact(contact);
                Clear();
            }
            _parent.Display();
        }
    }
}
