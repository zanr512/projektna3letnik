using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Text;

namespace _9fag
{
    public partial class register : System.Web.UI.Page
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_button_Click(object sender, EventArgs e)
        {
            //Pridobi email
            var email = register_mail.Text;
            //Kriptira geslo in ga shrani
            var password = CalculateMD5Hash(register_pass.Text);

            //Poveže se na podatkovno bazo
            string constr = ConfigurationManager.ConnectionStrings["baza"].ConnectionString;

            int id = 0;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using(MySqlCommand cmd = new MySqlCommand("insert_user"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("pass", password);
                        cmd.Connection = con;
                        con.Open();
                        id = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                    }
                }

                string message = string.Empty;

                if(id == -1)
                {
                    message = "User already exists";
                }
                else
                {
                    message = "Registration sucessful <a href=login.aspx>Log In now</a>";
                }

                register_status.Text = message;
            }

        }
    }
}