﻿using System;
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
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        /* footer */
        OleDbCommand cmdLinks = new OleDbCommand("select * from links", cnn);
        OleDbDataReader readerLinks = cmdLinks.ExecuteReader();
        DataList2.DataSource = readerLinks;
        DataList2.DataBind();
        cnn.Close();
    }

    // kayıt ol
    protected void Button1_Click(object sender, EventArgs e)
    {
        char control = 't';
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/db.accdb"));
        cnn.Open();
        OleDbCommand cmd = new OleDbCommand("select * from kullanicilar", cnn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            if (TextBox1.Text==reader["kullanici_adi"].ToString())
            {
                control = 'f';
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Böyle bir hesap zaten kayıtlı!.";
            }
        }
        if (control == 't')
        {
            OleDbCommand cmdRegister = new OleDbCommand("insert into kullanicilar values(@p1,@p2,'none.jpg',now,'normal')", cnn);
            cmdRegister.Parameters.AddWithValue("@p1", TextBox1.Text);
            cmdRegister.Parameters.AddWithValue("@p2", TextBox2.Text);
            cmdRegister.ExecuteNonQuery();
            Label1.ForeColor = System.Drawing.Color.Lime;
            Label1.Text = "Başarıyla kayıt oldunuz!";
        }
        cnn.Close();
    }
}