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
    public partial class AddService : Form
    {
        private readonly Services _parent;
        public string Id, Nom;
        public AddService(Services parent)
        {
            InitializeComponent();
            _parent = parent;

        }
        public void UpdateInfo()
        {
            btnSave.Text = "Enregistrer";
            txtNom.Text = Nom;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nom vide");
                return;
            }
            if (btnSave.Text == "Envoyer")
            {
                ServiceData contact = new ServiceData(txtNom.Text.Trim());
                DBContact.AddServices(contact);
                Clear();
            }
            if (btnSave.Text == "Enregistrer")
            {
                ServiceData contact = new ServiceData(txtNom.Text.Trim());
                DBContact.UpdateServices(contact, Id);
            }
            _parent.Display();
        }

        public void Clear()
        {
            txtNom.Text = string.Empty;
        }
    }
}
