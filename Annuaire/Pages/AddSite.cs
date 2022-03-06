using Annuaire.Data;
using Annuaire;
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
    public partial class AddSite : Form
    {
        private readonly Sites _parent;
        public string Id, Nom;
        public AddSite(Sites parent)
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
                SitesData contact = new SitesData(txtNom.Text.Trim());
                DBContact.AddSites(contact);
                Clear();
            }
            if (btnSave.Text == "Enregistrer")
            {
                SitesData contact = new SitesData(txtNom.Text.Trim());
                DBContact.UpdateSites(contact, Id);
            }
            _parent.Display();
        }

        public void Clear()
        {
            txtNom.Text = string.Empty;
        }
    }
}
