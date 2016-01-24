using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Configuration;

namespace _9fag
{
    public partial class upload : System.Web.UI.Page
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            //Prebere id od zadje slike iz .xml datoteke
            string file_name = string.Empty;
            using (XmlTextReader reader = new XmlTextReader(Server.MapPath("file.xml")))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        file_name = reader.Value;
                    }
                }
            }

            string name = "upload/" + file_name + ".png";
            string comment = comment1.Text;

            //Naloži sliko v mapo upload na serverju
            file_upload.SaveAs(Server.MapPath("upload") + "//" + file_name + ".png");
            if (System.IO.File.Exists(Server.MapPath("upload" + "//" + file_name + ".png")))
            {
                string constr = ConfigurationManager.ConnectionStrings["baza"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("insert_pic"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("path", name);
                            cmd.Parameters.AddWithValue("id", Session["user_id"]);
                            cmd.Parameters.AddWithValue("pic_id", file_name);
                            cmd.Parameters.AddWithValue("name1", comment);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                    }
                }

                    lblMessage.Text = "File Successfully Uploaded";

                //Pretvori iz stringa v int in obratno
                int file_name1 = Convert.ToInt16(file_name);
                file_name1++;
                file_name = Convert.ToString(file_name1);

                //Zapiše nove podatke slik v xml datoteko
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.Encoding = Encoding.UTF8;

                string xmlDoc = Server.MapPath("file.xml");

                using (XmlWriter writer = XmlWriter.Create(xmlDoc, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("file_upload_id");
                    writer.WriteElementString("id", file_name);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            else
            {
                lblMessage.Text = "File Was Not Uploaded";
            }
        }
    }
}