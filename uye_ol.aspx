﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uye_ol.aspx.cs" Inherits="kayit_ol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>Zamunda Torrent - Oyun, dizi, film...</title>
	<link rel="shortcut icon" href="Image/site/logo.jpg">
	<link rel="stylesheet" type="text/css" href="Css/style.css">
    <style type="text/css">
        .auto-style1 {
            width: 38px;
        }
        .auto-style2 {
            width: 149px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<div id="header">
		<div id="header1">
			<div id="logo"><a href="index.aspx"><img src="Image/site/logo.jpg"></a></div>
			<div id="title"><h3><a href="index.aspx">Zamunda Torrent</a></h3></div>
			<div id="menu">
				<table>
					<tr>
						<td><a href="giris_yap.aspx"><img src="Image/site/giris_yap.png"></a></td>
						<td><a href="uye_ol.aspx"><img src="Image/site/uye_ol.png"></a></td>
					</tr>
				</table>
			</div>
		</div>
	</div>
    <div id="container">
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">Kullanıcı Adı:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">Şifre</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Kayıt Ol" />
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>