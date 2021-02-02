using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public partial class Admin_fire : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand com;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand(" select DISTINCT t.email from register_hck t where t.address=@address union select DISTINCT t1.email from emergency t1 where t1.address = @address ", con);
        cmd.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = DropDownList1.SelectedValue.ToString();
        ArrayList emailArray = new ArrayList();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            emailArray.Add(dr["email"]);
        }
        foreach (string email in emailArray)
        {
            const string username = "dtilak1999@gmail.com";
            const string password = "Sanyam99+";
            // SmtpClient smtpclient = new SmtpClient();
            SmtpClient smtpclient = new SmtpClient();
            MailMessage mail = new MailMessage();
            MailAddress fromaddress = new MailAddress("dtilak1999@gmail.com");
            smtpclient.Host = "smtp.gmail.com";
            smtpclient.Port = 587;
            mail.From = fromaddress;
            mail.To.Add(email);
            mail.Subject = "Forest Fire in Your Area";
            mail.Body = "<html><head><title></title></head><body><p>There is a fire in your city look at in our website and aware others also.</p></body></html> ";
            mail.IsBodyHtml = true;
            smtpclient.EnableSsl = true;
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.Credentials = new System.Net.NetworkCredential(username, password);
            smtpclient.Send(mail);
            Label1.Text = "Your email was sent sucessfully ";
            dr.Close();
            con.Close();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

