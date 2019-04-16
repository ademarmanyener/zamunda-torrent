using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Text = "";
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from kullanicilar where kullanici_adi='" + Session["kullanici_adi"].ToString() + "'", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Label2.Text = "Hoşgeldiniz sayın " + Session["kullanici_adi"].ToString() + ".";
            if (reader["avatar"].ToString() == "none.jpg")
            {
                Image1.ImageUrl = "~/Image/site/logo.jpg";
            }
            else
            {
                Image1.ImageUrl = "~/Image/avatar/" + reader["avatar"].ToString();
            }
        }
        /* footer */
        OleDbCommand cmdLinks = new OleDbCommand("select * from links", cnn);
        OleDbDataReader readerLinks = cmdLinks.ExecuteReader();
        DataList2.DataSource = readerLinks;
        DataList2.DataBind();
        cnn.Close();
    }

    // çıkış yap
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    // profilim
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("profilimG.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {

    }

    // yetki ver
    protected void Button3_Click(object sender, EventArgs e)
    {
        char control = 'f';
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from kullanicilar", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            if (TextBox1.Text == reader["kullanici_adi"].ToString())
            {
                OleDbCommand cmd2 = new OleDbCommand("select * from kullanicilar where kullanici_adi='" + Session["kullanici_adi"].ToString() + "'", cnn);
                OleDbDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2["yetki"].ToString()=="admin")
                    {
                        control = 't';
                        if (TextBox3.Text==reader2["sifre"].ToString())
                        {
                            OleDbCommand cmdUpdate = new OleDbCommand("update kullanicilar set yetki=@p1 where kullanici_adi=@p2",cnn);
                            cmdUpdate.Parameters.AddWithValue("@p1", TextBox2.Text);
                            cmdUpdate.Parameters.AddWithValue("@p2", TextBox1.Text);
                            cmdUpdate.ExecuteNonQuery();
                            Label3.ForeColor = System.Drawing.Color.Lime;
                            Label3.Text = "Kullanıcının yetkisi başarıyla güncellenmiştir.";
                        }
                        else
                        {
                            Label3.ForeColor = System.Drawing.Color.Red;
                            Label3.Text = "Şifrenizin doğru olduğuna emin olun!";
                        }
                    }
                    else
                    {
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Label3.Text = "Bunu yapmak için yetkiniz yok!";
                    }
                }
            }
            if (control=='f')
            {
                Label3.ForeColor = System.Drawing.Color.Red;
                Label3.Text = "Böyle bir kullanıcı mevcut değil!";
            }
        }
        cnn.Close();
    }

    // torrent seç
    protected void Button4_Click1(object sender, EventArgs e)
    {
    }
}