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

    // düzenle
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile && FileUpload2.HasFile)
        {
            char control = 'f';
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
                        if (Session["kullanici_adi"].ToString() == reader["torrent_ekleyen_kisi"].ToString())
                        {
                            if (FileUpload1.HasFile && FileUpload2.HasFile)
                            {
                                control = 't';
                                File.Delete(Server.MapPath("~/Image/torrent/") + reader["torrent_resmi"].ToString());
                                File.Delete(Server.MapPath("~/File/torrent/") + reader["torrent_dosyasi"].ToString());
                                FileUpload1.SaveAs(Server.MapPath("~/Image/torrent/") + TextBox1.Text.ToString() + ".jpg");
                                FileUpload2.SaveAs(Server.MapPath("~/File/torrent/") + TextBox1.Text.ToString() + ".torrent");
                                string torrentResim = TextBox1.Text + ".jpg";
                                string torrentDosya = TextBox1.Text + ".torrent";
                                OleDbCommand cmdUpdate = new OleDbCommand("update torrentler set torrent_adi=@p1, torrent_bilgisi=@p2, torrent_turu=@p3, torrent_resmi=@p4, torrent_dosyasi=@p5, torrent_eklenme_tarihi=now where torrent_id=@p6", cnn);
                                cmdUpdate.Parameters.AddWithValue("@p1", TextBox2.Text);
                                cmdUpdate.Parameters.AddWithValue("@p2", TextBox3.Text);
                                cmdUpdate.Parameters.AddWithValue("@p3", DropDownList1.SelectedValue);
                                cmdUpdate.Parameters.AddWithValue("@p4", torrentResim);
                                cmdUpdate.Parameters.AddWithValue("@p5", torrentDosya);
                                cmdUpdate.Parameters.AddWithValue("@p6", TextBox1.Text);
                                cmdUpdate.ExecuteNonQuery();
                                Label3.ForeColor = System.Drawing.Color.Lime;
                                Label3.Text = "Torrent başarıyla güncellendi.";
                            }
                            else
                            {
                                control = 't';
                                File.Delete(Server.MapPath("~/Image/torrent/") + reader["torrent_resmi"].ToString());
                                File.Delete(Server.MapPath("~/File/torrent/") + reader["torrent_dosyasi"].ToString());
                                FileUpload1.SaveAs(Server.MapPath("~/Image/torrent/") + TextBox1.Text.ToString() + ".jpg");
                                FileUpload2.SaveAs(Server.MapPath("~/File/torrent/") + TextBox1.Text.ToString() + ".torrent");
                                string torrentResim = TextBox1.Text + ".jpg";
                                string torrentDosya = TextBox1.Text + ".torrent";
                                OleDbCommand cmdUpdate = new OleDbCommand("update torrentler set torrent_adi=@p1, torrent_bilgisi=@p2, torrent_turu=@p3, torrent_eklenme_tarihi=now where torrent_id=@p4", cnn);
                                cmdUpdate.Parameters.AddWithValue("@p1", TextBox2.Text);
                                cmdUpdate.Parameters.AddWithValue("@p2", TextBox3.Text);
                                cmdUpdate.Parameters.AddWithValue("@p3", DropDownList1.SelectedValue);
                                cmdUpdate.Parameters.AddWithValue("@p4", TextBox1.Text);
                                cmdUpdate.ExecuteNonQuery();
                                Label3.ForeColor = System.Drawing.Color.Lime;
                                Label3.Text = "Torrent başarıyla güncellendi.";
                            }
                        }
                        else
                        {
                            Label3.ForeColor = System.Drawing.Color.Red;
                            Label3.Text = "Bu kayıt size ait değil!";
                        }
                    }
                }
                if (control == 'f')
                {
                    Label3.ForeColor = System.Drawing.Color.Red;
                    Label3.Text = "Böyle bir kayıdınız bulunmamaktadır.";
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

    // torrent seç
    protected void Button4_Click1(object sender, EventArgs e)
    {
        char control = 'f';
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from torrentler",cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            if (TextBox1.Text==reader["torrent_id"].ToString())
            {
                if (Session["kullanici_adi"].ToString()==reader["torrent_ekleyen_kisi"].ToString())
                {
                    control = 't';
                    TextBox2.Text = reader["torrent_adi"].ToString();
                    TextBox3.Text = reader["torrent_bilgisi"].ToString();
                }
                else
                {
                    Label3.ForeColor = System.Drawing.Color.Red;
                    Label3.Text = "Bu kayıt size ait değil.";
                }
            }
            else
            {
                Label3.ForeColor = System.Drawing.Color.Red;
                Label3.Text = "Böyle bir kayıt mevcut değil.";
            }
        }
        cnn.Close();
    }
}