using System;
using System.Data.OleDb;
using System.IO;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Image1.BackColor = System.Drawing.Color.Black;
        Label2.Text = "Hoşgeldiniz sayın " + Session["kullanici_adi"].ToString() + ".";
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from kullanicilar where kullanici_adi='" + Session["kullanici_adi"].ToString() + "'", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Label3.Text = "Kullanıcı Adınız: " + reader["kullanici_adi"].ToString() + ".";
            Label4.Text = "Üye Olma Tarihiniz: " + reader["uye_olma_tarihi"].ToString() + ".";
            Label8.Text = "Yetkiniz: " + reader["yetki"].ToString() + ".";
            if (reader["avatar"].ToString() == "none.jpg")
            {
                //Image1.ImageUrl = "~/Image/site/logo.jpg";
                //Image2.ImageUrl = "~/Image/site/logo.jpg";
            }
            else
            {
                Image1.ImageUrl = "~/Image/avatar/" + reader["avatar"].ToString();
                Image2.ImageUrl = "~/Image/avatar/" + reader["avatar"].ToString();
            }

            if (reader["yetki"].ToString() == "admin")
            {
                Button3.Visible = true;
                Button8.Visible = true;
                Button4.Visible = true;
                Button10.Visible = true;
            }
            else
            {
                Button3.Visible = false;
                Button8.Visible = false;
                Button4.Visible = false;
                Button10.Visible = false;
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

    // avatar sil
    protected void Button6_Click(object sender, EventArgs e)
    {
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from kullanicilar where kullanici_adi='" + Session["kullanici_adi"].ToString() + "'", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            if (reader["avatar"].ToString() != "none.jpg")
            {
                File.Delete(Server.MapPath("~/Image/avatar/") + reader["avatar"].ToString());
                OleDbCommand cmdUpdate = new OleDbCommand("update kullanicilar set avatar=@p1 where kullanici_adi='" + Session["kullanici_adi"].ToString() + "'", cnn);
                cmdUpdate.Parameters.AddWithValue("@p1", "none.jpg");
                cmdUpdate.ExecuteNonQuery();
            }
            else
            {
                OleDbCommand cmdUpdate = new OleDbCommand("update kullanicilar set avatar=@p1 where kullanici_adi='" + Session["kullanici_adi"].ToString() + "'", cnn);
                cmdUpdate.Parameters.AddWithValue("@p1", "none.jpg");
                cmdUpdate.ExecuteNonQuery();
            }
        }
        Label7.ForeColor = System.Drawing.Color.Lime;
        Label7.Text = "Avatar silindi.";
        cnn.Close();
    }

    // avatar yükle
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string avatarUzantisi = Path.GetExtension(FileUpload1.FileName);
            if (avatarUzantisi == ".jpg")
            {
                FileUpload1.SaveAs(Server.MapPath("~/Image/avatar/") + Session["kullanici_adi"].ToString() + ".jpg");
                Label7.ForeColor = System.Drawing.Color.Lime;
                Label7.Text = "Avatar yüklendi! (Görüntülemek için sayfayı yenileyin.)";
                OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
                cnn.Open();
                OleDbCommand cmdUpdate = new OleDbCommand("update kullanicilar set avatar=@p1 where kullanici_adi='" + Session["kullanici_adi"].ToString() + "'", cnn);
                cmdUpdate.Parameters.AddWithValue("@p1", Session["kullanici_adi"].ToString() + ".jpg");
                cmdUpdate.ExecuteNonQuery();
                cnn.Close();
            }
            else
            {
                Label7.ForeColor = System.Drawing.Color.Red;
                Label7.Text = "Sadece .jpg uzantılı avatar yükleyebilirsiniz!";
            }
        }
        else
        {
            Label7.ForeColor = System.Drawing.Color.Red;
            Label7.Text = "Önce bir resim seçmelisiniz!";
        }
    }

    // anasayfa
    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("indexG.aspx");
    }

    // torrent düzenle
    protected void Button8_Click(object sender, EventArgs e)
    {
        Response.Redirect("torrent_duzenleG.aspx");
    }

    // şifre değiştir
    protected void Button9_Click(object sender, EventArgs e)
    {
        Response.Redirect("sifre_degistirG.aspx");
    }

    // yetki ver
    protected void Button10_Click(object sender, EventArgs e)
    {
        Response.Redirect("yetki_verG.aspx");
    }

    // site ayarları
    protected void Button11_Click(object sender, EventArgs e)
    {
        Response.Redirect("site_ayarlariG.aspx");
    }
}