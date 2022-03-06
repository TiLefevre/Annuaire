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
        public string Id, Nom, Prenom, Fixe, Portable, Email, Service, Site;

        private void AddContact_Load(object sender, EventArgs e)
        {
            DBContact.search("SELECT Nom From Services", comboBox1);
            DBContact.search("SELECT Nom From Sites", comboBox2);
        }

        public AddContact(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            label1.Text = "Modifier";
            btnSave.Text = "Enregistrer";
            txtNom.Text = Nom;
            txtPrenom.Text = Prenom;
            txtFixe.Text = Fixe;
            txtPortable.Text = Portable;
            txtEmail.Text = Email;
            comboBox1.Text = Service;
            comboBox2.Text = Site;
        }

        public void Clear()
        {
            txtNom.Text = txtPrenom.Text = txtFixe.Text = txtPortable.Text = txtEmail.Text = comboBox1.Text = comboBox2.Text = string.Empty;
        }
        public void listSite()
        {

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
            if(btnSave.Text == "Enregistrer")
            {
                ContactData contact = new ContactData(txtNom.Text.Trim(), txtPrenom.Text.Trim(), txtFixe.Text.Trim(), txtPortable.Text.Trim(), txtEmail.Text.Trim(), comboBox1.Text.Trim(), comboBox2.Text.Trim(), checkBox1.Checked);
                DBContact.UpdateContact(contact, Id);
            }
            _parent.Display();
        }
    }
}
