using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

public partial class torrent_sayfasi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = "";
        Boolean control = false;
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler where torrent_id='" + Request.QueryString["torrent_id"].ToString() + "'", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        DataList1.DataSource = reader;
        DataList1.DataBind();
        OleDbCommand cmd2 = new OleDbCommand("select * from kullanicilar where kullanici_adi='" + Session["kullanici_adi"].ToString() + "'", cnn);
        OleDbDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            Label2.Text = "Hoşgeldiniz sayın " + Session["kullanici_adi"].ToString() + ".";
            if (reader2["avatar"].ToString() == "none.jpg")
            {
                Image1.ImageUrl = "~/Image/site/logo.jpg";
            }
            else
            {
                Image1.ImageUrl = "~/Image/avatar/" + reader2["avatar"].ToString();
            }
        }
        /* footer */
        OleDbCommand cmdLinks = new OleDbCommand("select * from links", cnn);
        OleDbDataReader readerLinks = cmdLinks.ExecuteReader();
        DataList2.DataSource = readerLinks;
        DataList2.DataBind();
        // admin button
        Boolean control3 = false;
        OleDbCommand cmd3 = new OleDbCommand("select * from torrentler where torrent_ekleyen_kisi='" + Session["kullanici_adi"] + "' and torrent_id='" + Request.QueryString["torrent_id"].ToString() + "'", cnn);
        OleDbDataReader reader3 = cmd3.ExecuteReader();
        if (reader3.Read())
        {
            control3 = true;
            Button4.Visible = true;
            Button5.Visible = true;

        }
        else
        {
            Button4.Visible = false;
            Button5.Visible = false;
        }
        cnn.Close();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler where torrent_id='" + Request.QueryString["torrent_id"].ToString() + "'", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + reader["torrent_dosyasi"].ToString());
            Response.TransmitFile(Server.MapPath("~/File/torrent/") + reader["torrent_dosyasi"].ToString());
            Response.End();
        }
        //Response.ContentType = "Application/pdf";
    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    // profilim
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("profilimG.aspx");
    }

    // çıkış yap
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    // anasayfa
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("indexG.aspx");
    }

    // torrent sil
    protected void Button5_Click(object sender, EventArgs e)
    {
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler where torrent_id='"+Request.QueryString["torrent_id"].ToString()+"'",cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            File.Delete(Server.MapPath("~/File/torrent/") + reader["torrent_dosyasi"].ToString());
            File.Delete(Server.MapPath("~/Image/torrent/") + reader["torrent_resmi"].ToString());
            OleDbCommand cmdDelete = new OleDbCommand("delete from torrentler where torrent_id='"+reader["torrent_id"].ToString()+"'",cnn);
            cmdDelete.ExecuteNonQuery();
        }
        //Response.Redirect("indexG.aspx");
        Label4.ForeColor = System.Drawing.Color.Lime;
        Label4.Text = "Torrent silindi!";
        cnn.Close();

        //OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        //cnn.Open();
        //OleDbCommand cmd = new OleDbCommand("delete from torrentler where torrent_id='" + Request.QueryString["torrent_id"].ToString() + "'", cnn);
        //cmd.ExecuteNonQuery();
        //Label4.ForeColor = System.Drawing.Color.Lime;
        //Label4.Text = "Torrent silindi!";
        //cnn.Close();
    }

    // güncelle
    protected void Button4_Click(object sender, EventArgs e)
    {
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler where torrent_id='"+Request.QueryString["torrent_id"].ToString()+"'",cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Response.Redirect("torrent_duzenleG.aspx?torrent_id="+reader["torrent_id"].ToString());
        }
        cnn.Close();
    }
}