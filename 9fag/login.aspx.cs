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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("index.aspx");
            }
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

        protected void login_button_Click(object sender, EventArgs e)
        {
            //Pridobi email iz textboxa
            var email = login_email.Text;
            //enkriptira geslo
           

            string password = CalculateMD5Hash(login_password.Text);

            string constr = ConfigurationManager.ConnectionStrings["baza"].ConnectionString;

            string id;
            string user_id;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("user_login"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("pass", password);
                        cmd.Connection = con;
                        con.Open();
                        id = Convert.ToString(cmd.ExecuteScalar());
                        con.Close();

                    }
                }


                using (MySqlCommand cmd = new MySqlCommand("get_id"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("user1", id);
                        cmd.Connection = con;
                        con.Open();
                        user_id = Convert.ToString(cmd.ExecuteScalar());
                        con.Close();

                        Session["user_id"] = user_id;
                    }
                }


                string message = string.Empty;

                if(id == "lmao")
                {
                    message = "Incorrect username or password";
                }
                else
                {
                    Session["username"] = id;
                    Response.Redirect("index.aspx");
                }


                login_status.Text = message;
            }




        }



        }
    }
