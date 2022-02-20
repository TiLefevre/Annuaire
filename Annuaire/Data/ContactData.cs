using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire.Data
{
    class ContactData
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Fixe { get; set; }
        public string Portable { get; set; }
        public string Email { get; set; }
        public string Service { get; set; }
        public string Site { get; set; }

        public int Role { get; set; }

        public ContactData(string nom, string prenom, string fixe, string portable, string email,string service,string site, bool role)
        {
            Nom = nom;
            Prenom = prenom;
            Fixe = fixe;
            Portable = portable;
            Email = email;
            Service = service;
            Site = site;
            Role = role ? 1 : 0;
        }

    }
}
