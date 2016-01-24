using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Text;
using System.Windows;

namespace _9fag
{
    public partial class user1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }
            string email = Convert.ToString(Session["username"]);

            label_user.Text = email;
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        protected void button_change_pass_Click(object sender, EventArgs e)
        {
            //Pridobi staro geslo
            string old_pass = CalculateMD5Hash(current_pass.Text);
            //pridobi novo geslo
            string new_pass = CalculateMD5Hash(new_password.Text);
            //Pridobi username
            string email = Convert.ToString(Session["username"]);

            button_change_pass.Text = old_pass;


            string constr = ConfigurationManager.ConnectionStrings["baza"].ConnectionString;

            string id;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("change_pass"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("pass", old_pass);
                        cmd.Parameters.AddWithValue("newpass", new_pass);
                        cmd.Connection = con;
                        con.Open();
                        id = Convert.ToString(cmd.ExecuteScalar());
                        con.Close();
                    }
                }

                string message = string.Empty;

                if (id == "lmao")
                {
                    message = "Insert correct password";
                }
                else
                {
                    message = "Password has been changed successfully";
                }

                button_change_pass.Text = message;
            }

        }

        protected void button_delete_Click(object sender, EventArgs e)
        {
            //Pridobi  geslo za izbris
            string pass = CalculateMD5Hash(delete_pass.Text);
            //Pridobi username
            string email = Convert.ToString(Session["username"]);

            string constr = ConfigurationManager.ConnectionStrings["baza"].ConnectionString;

            string id;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("delete_user"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("pass", pass);
                        cmd.Connection = con;
                        con.Open();
                        id = Convert.ToString(cmd.ExecuteScalar());
                        con.Close();
                    }
                }

                string message = string.Empty;

                if (id == "lmao")
                {
                    message = "Insert correct password";
                }
                else
                {
                    Response.Redirect("logout.aspx");
                }

            }
        }
    }
}