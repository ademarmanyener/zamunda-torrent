<%@ Page Language="C#" AutoEventWireup="true" CodeFile="indexG.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>Zamunda Torrent - Oyun, dizi, film...</title>
	<link rel="shortcut icon" href="Image/site/logo.jpg">
	<link rel="stylesheet" type="text/css" href="Css/style.css">
    <style type="text/css">
        .auto-style2 {
            width: 200px;
        }
        .auto-style3 {
            width: 200px;
            height: 29px;
        }
        .auto-style4 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<div id="header">
		<div id="header1">
			<div id="logo"><a href="indexG.aspx"><img src="Image/site/logo.jpg"></a></div>
			<div id="title"><h3><a href="indexG.aspx">Zamunda Torrent</a></h3></div>
			<div id="menu">
				<table>
					<tr>
						<td>
                            <asp:Image ID="Image1" runat="server" Height="42px" Width="44px" />
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Label"></asp:Label>
                        </td>
					</tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Profilim" CssClass="button2" OnClick="Button1_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" Text="Çıkış Yap" CssClass="button2" OnClick="Button2_Click" />
                        </td>
                    </tr>
				</table>
			</div>
		    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
		</div>
	</div>
	<div id="container" >      
	    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
            <ItemTemplate>
                <table style="width:100%;">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButton1" ImageUrl='<%# "Image/torrent/"+Eval("torrent_resmi").ToString() %>' PostBackUrl='<%# "~/torrent_sayfasiG.aspx?torrent_id="+Eval("torrent_id").ToString() %>' runat="server" Height="290px" Width="249px" />
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
