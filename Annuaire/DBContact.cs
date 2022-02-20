using Annuaire.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Annuaire
{
    class DBContact
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "database=bddtimothe_bdd; server=mysql-bddtimothe.alwaysdata.net; user id=258372; password=6v9hjZAZ5";
            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Mysql connection: \n" + ex.Message, "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

        public static void AddContact(ContactData contact)
        {
            string sql = "INSERT INTO `Annuaire`(`Nom`, `Prenom`, `Fixe`, `Portable`, `Email`, `Service`, `Site`, `role`) VALUES (@Nom, @Prenom, @Fixe, @Portable, @Email, @Service, @Site, @Role)";
            MySqlConnection con = GetConnection(); 
            MySqlCommand cmd = new MySqlCommand(sql, con);            
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Nom", MySqlDbType.VarChar).Value = contact.Nom;
            cmd.Parameters.Add("@Prenom", MySqlDbType.VarChar).Value = contact.Prenom;
            cmd.Parameters.Add("@Fixe", MySqlDbType.VarChar).Value = contact.Fixe;
            cmd.Parameters.Add("@Portable", MySqlDbType.VarChar).Value = contact.Portable;
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = contact.Email;
            cmd.Parameters.Add("@Service", MySqlDbType.VarChar).Value = contact.Service;
            cmd.Parameters.Add("@Site", MySqlDbType.VarChar).Value = contact.Site;
            cmd.Parameters.Add("@Role", MySqlDbType.VarChar).Value = contact.Role;
           
            try
            {
                //con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Contact not insert: \n" + ex.Message, "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void UpdateContact(ContactData contact)
        {
            string sql = "Update Annuaire SET Nom = @Nom, Prenom = @Prenom, Fixe = @Fixe, Portable = @Portable, Email = @Email, Service = @Service, Site = @Site";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Nom", MySqlDbType.VarChar).Value = contact.Nom;
            cmd.Parameters.Add("@Prenom", MySqlDbType.VarChar).Value = contact.Prenom;
            cmd.Parameters.Add("@Fixe", MySqlDbType.VarChar).Value = contact.Fixe;
            cmd.Parameters.Add("@Portable", MySqlDbType.VarChar).Value = contact.Portable;
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = contact.Email;
            cmd.Parameters.Add("@Service", MySqlDbType.VarChar).Value = contact.Service;
            cmd.Parameters.Add("@Site", MySqlDbType.VarChar).Value = contact.Site;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Contact not update: \n" + ex.Message, "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DeleteContact(string id)
        {
            string sql = "DELETE FROM Annuaire WHERE Id = @Id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Contact not delete: \n" + ex.Message, "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DisplayAndSearch(string query, DataGridView dvg)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dvg.DataSource = tbl;
            con.Close();
        }
    }
}
