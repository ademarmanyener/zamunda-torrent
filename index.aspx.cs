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
        /*
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        DataList1.DataSource = reader;
        DataList1.DataBind();
        cnn.Close();        
        */
        
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler order by torrent_eklenme_tarihi desc", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        DataList1.DataSource = reader;
        DataList1.DataBind();
        /* footer */
        OleDbCommand cmdLinks = new OleDbCommand("select * from links",cnn);
        OleDbDataReader readerLinks = cmdLinks.ExecuteReader();
        DataList2.DataSource = readerLinks;
        DataList2.DataBind();
        cnn.Close();
    }

    // oyun
    protected void Button1_Click(object sender, EventArgs e)
    {
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler where torrent_turu='oyun' order by torrent_eklenme_tarihi desc", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        DataList1.DataSource = reader;
        DataList1.DataBind();
        cnn.Close();
    }

    // dizi
    protected void Button2_Click(object sender, EventArgs e)
    {
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler where torrent_turu='dizi' order by torrent_eklenme_tarihi desc", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        DataList1.DataSource = reader;
        DataList1.DataBind();
        cnn.Close();
    }

    // film
    protected void Button3_Click(object sender, EventArgs e)
    {
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler where torrent_turu='film' order by torrent_eklenme_tarihi desc", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        DataList1.DataSource = reader;
        DataList1.DataBind();
        cnn.Close();
    }
}