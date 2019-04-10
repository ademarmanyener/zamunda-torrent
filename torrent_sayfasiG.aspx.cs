using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class torrent_sayfasi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler where torrent_id='" + Request.QueryString["torrent_id"].ToString() + "'", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        DataList1.DataSource = reader;
        DataList1.DataBind();
        OleDbCommand cmd2 = new OleDbCommand("select * from kullanicilar where kullanici_adi='"+Session["kullanici_adi"].ToString()+"'",cnn);
        OleDbDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            Label2.Text = "Hoşgeldiniz sayın "+Session["kullanici_adi"].ToString()+".";
            if (reader2["avatar"].ToString() == "none.jpg")
            {
                Image1.ImageUrl = "~/Image/site/logo.jpg";
            }
            else
            {
                Image1.ImageUrl = "~/Image/avatar/" + reader2["avatar"].ToString();
            }
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
            Response.AppendHeader("Content-Disposition", "attachment; filename="+reader["torrent_dosyasi"].ToString());
            Response.TransmitFile(Server.MapPath("~/File/torrent/") + reader["torrent_dosyasi"].ToString());
            Response.End();
        }
        //Response.ContentType = "Application/pdf";
    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("profilimG.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
}