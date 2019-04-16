<%@ Page Language="C#" AutoEventWireup="true" CodeFile="giris_yap.aspx.cs" Inherits="kayit_ol" %>

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
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="button1" Text="Giriş Yap" />
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
        <div id="footer0">        
     <asp:DataList ID="DataList2" runat="server">
       <ItemTemplate>
        <div id="footer">
            <div id="table1">
            <table>
                <tr>
                    <td rowspan="2"><a href='<%# Eval("anasayfa").ToString() %>'><img src="Image/site/logo.jpg"></a></td>
                </tr>
            </table>
            </div>
            <div id="baslik">
                <h3><a href='<%# Eval("anasayfa").ToString() %>'>Zamunda Torrent</a></h3>
            </div>
            <div id="table2">
            <table>
                <tr>
                    <td rowspan="2"><a target="_blank" href='<%# Eval("facebook").ToString() %>'><img src="Image/site/social/facebook.png"></a></td>
                    <td rowspan="2"><a target="_blank" href='<%# Eval("twitter").ToString() %>'><img src="Image/site/social/twitter.png"></a></td>
                    <td rowspan="2"><a target="_blank" href='<%# Eval("instagram").ToString() %>'><img src="Image/site/social/instagram.png"></a></td>
                    <td rowspan="2"><a target="_blank" href='<%# Eval("google_plus").ToString() %>'><img src="Image/site/social/google-plus.png"></a></td>
                </tr>
            </table>
            </div>                
        </div>  
       </ItemTemplate>
      </asp:DataList> 
            </div>
    </form>
</body>
</html>
