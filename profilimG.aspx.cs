using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label5.Text = "Hoşgeldiniz sayın " + Session["kullanici_adi"].ToString() + ".";
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from kullanicilar where kullanici_adi='" + Session["kullanici_adi"].ToString() + "'", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Label3.Text = "Kullanıcı Adınız: " + reader["kullanici_adi"].ToString();
            Label4.Text = "Üye Olma Tarihiniz: " + reader["uye_olma_tarihi"].ToString();
            if (reader["avatar"].ToString() == "none")
            {
                Image1.ImageUrl = "~/Image/site/logo.jpg";
            }
            else
            {
                Image1.ImageUrl = "~/Image/avatar/" + reader["avatar"].ToString();
            }
        }
        cnn.Close();
    }

    // çıkış yap
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    // anasayfa
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("indexG.aspx");
    }

    // torrent ekle
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("torrent_ekleG.aspx");
    }

    // torrent sil
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("torrent_silG.aspx");
    }
}