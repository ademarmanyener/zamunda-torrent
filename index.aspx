<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>Zamunda Torrent - Oyun, dizi, film...</title>
	<link rel="shortcut icon" href="Image/site/logo.jpg">
	<link rel="stylesheet" type="text/css" href="Css/style.css">
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
	    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
            <ItemTemplate>
                <table style="width:100%;">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButton1" ImageUrl='<%# "Image/torrent/"+Eval("torrent_resmi").ToString() %>' PostBackUrl='<%# "~/torrent_sayfasi.aspx?torrent_id="+Eval("torrent_id").ToString() %>' runat="server" Height="290px" Width="249px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" style="font-size: 20px;" runat="server" Text='<%# Eval("torrent_adi").ToString() %>'></asp:Label>
                        <br />
                        <br />
                        <br />
                        <br />
                        <hr />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
	</div>
    </form>
</body>
</html>
