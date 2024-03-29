﻿using System;
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

    // sil
    protected void Button3_Click(object sender, EventArgs e)
    {
        char control = 'f';
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            if (TextBox1.Text == reader["torrent_id"].ToString())
            {
                if (reader["torrent_ekleyen_kisi"].ToString() == Session["kullanici_adi"].ToString())
                {
                    control = 't';
                    File.Delete(Server.MapPath("~/Image/torrent/") + reader["torrent_resmi"].ToString());
                    File.Delete(Server.MapPath("~/File/torrent/") + reader["torrent_dosyasi"].ToString());
                    OleDbCommand cmdDelete = new OleDbCommand("delete from torrentler where torrent_id=@p1",cnn);
                    cmdDelete.Parameters.AddWithValue("@p1",TextBox1.Text);
                    cmdDelete.ExecuteNonQuery();
                    Label3.ForeColor = System.Drawing.Color.Lime;
                    Label3.Text = "Torrent kaydınız başarıyla silindi.";
                }
            }
        }
        if (control == 'f')
        {
            Label3.ForeColor = System.Drawing.Color.Red;
            Label3.Text = "Böyle bir torrent kaydınız bulunmamaktadır.";
        }
        cnn.Close();

    }
}