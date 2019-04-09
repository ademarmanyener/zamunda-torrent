using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class kayit_ol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // kayıt ol
    protected void Button1_Click(object sender, EventArgs e)
    {
        char control = 'f';
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from kullanicilar", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            if (TextBox1.Text==reader["kullanici_adi"].ToString() && TextBox2.Text==reader["sifre"].ToString())
            {
                control = 't';
                Response.Redirect("indexG.aspx?kullanici_adi="+reader["kullanici_adi"].ToString());
                //Label1.ForeColor = System.Drawing.Color.Lime;
                //Label1.Text = "Giriş başarılı.";
            }
        }
        if (control == 'f')
        {
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "Hatalı kullanıcı adı/şifre!";
        }
        cnn.Close();
    }
}