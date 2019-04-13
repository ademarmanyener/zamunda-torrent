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

    // ekle
    protected void Button3_Click(object sender, EventArgs e)
    {
        /* = */
        if (FileUpload1.HasFile && FileUpload2.HasFile)
        {
            char control = 't';
            OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
            string uzantiResim = Path.GetExtension(FileUpload1.FileName);
            string uzantiTorrent = Path.GetExtension(FileUpload2.FileName);
            if (uzantiResim == ".jpg" && uzantiTorrent == ".torrent")
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from torrentler", cnn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (TextBox1.Text == reader["torrent_id"].ToString())
                    {
                        control = 'f';
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Label3.Text = "Bu ID ile bir torrent zaten kayıtlı";
                    }
                }
                if (control == 't')
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Image/torrent/") + TextBox1.Text.ToString()+".jpg");
                    FileUpload2.SaveAs(Server.MapPath("~/File/torrent/") + TextBox1.Text.ToString()+".torrent");
                    OleDbCommand cmdInsert = new OleDbCommand("insert into torrentler values(@p1,@p2,@p3,@p4,@p5,@p6,now,@p7)", cnn);
                    cmdInsert.Parameters.AddWithValue("@p1", TextBox1.Text);
                    cmdInsert.Parameters.AddWithValue("@p2", TextBox2.Text);
                    cmdInsert.Parameters.AddWithValue("@p3", TextBox3.Text);
                    cmdInsert.Parameters.AddWithValue("@p4", DropDownList1.SelectedValue);
                    cmdInsert.Parameters.AddWithValue("@p5", TextBox1.Text + ".jpg");
                    cmdInsert.Parameters.AddWithValue("@p6", TextBox1.Text + ".torrent");
                    cmdInsert.Parameters.AddWithValue("@p7", Session["kullanici_adi"].ToString());
                    cmdInsert.ExecuteNonQuery();
                    Label3.ForeColor = System.Drawing.Color.Lime;
                    Label3.Text = "Torrent başarıyla eklendi.";
                }
                cnn.Close();

            }
            else
            {
                Label3.ForeColor = System.Drawing.Color.Red;
                Label3.Text = "Sadece .jpg türü resimler ve .torrent uzantılı dosyalar destekleniyor!";
            }
        }
        else
        {
            Label3.ForeColor = System.Drawing.Color.Red;
            Label3.Text = "Önce dosya seçmelisiniz!";
        }
        /* = */
    }
}