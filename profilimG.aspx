<%@ Page Language="C#" AutoEventWireup="true" CodeFile="profilimG.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>Zamunda Torrent - Oyun, dizi, film...</title>
	<link rel="shortcut icon" href="Image/site/logo.jpg">
	<link rel="stylesheet" type="text/css" href="Css/style.css">
    <style type="text/css">
        .auto-style2 {
            width: 331px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<div id="header">
		<div id="header1">
			<div id="logo"><a href="indexG.aspx"><img src="Image/site/logo.jpg"></a></div>
			<div id="title"><h3><a href="indexG.aspx">Zamunda Torrent</a></h3></div>
            <div id="category">
                <table>
                    <tr>
                        <td>
                            <asp:Button CssClass="button1" ID="Button7" runat="server" OnClick="Button7_Click" Text="Anasayfa" />
                        </td>
                    </tr>
                </table>
            </div>
			<div id="menu">
				<table>
					<tr>
						<td>
                            <asp:Image ID="Image2" runat="server" Height="42px" Width="44px" />
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Label"></asp:Label>
                        </td>
					</tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Anasayfa" CssClass="button2" OnClick="Button1_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" Text="Çıkış Yap" CssClass="button2" OnClick="Button2_Click" />
                        </td>
                    </tr>
				</table>
			</div>
		</div>
	</div>
	<div id="container" style="background-color: white; height: 600px; border: 2px solid black;">
        <table style="width: 100%; height: 25px;">
            <tr>
                <td>
                    <asp:Button ID="Button3" CssClass="button2" runat="server" Text="Torrent Ekle" OnClick="Button3_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button4" CssClass="button2" runat="server" Text="Torrent Sil" OnClick="Button4_Click" />
                </td>
            </tr>
        </table>
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style2" rowspan="2">
                            <asp:Image BorderStyle="Ridge" BorderColor="Orange" ID="Image1" runat="server" Height="314px" Width="313px" />
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label6" runat="server" Text="Avatar Yükle: "></asp:Label>
                            <asp:FileUpload ID="FileUpload1" runat="server" style="width: 203px" />
                            <asp:Button CssClass="button2" ID="Button6" runat="server" Text="Sil" OnClick="Button6_Click" style="height: 25px" />
                            <asp:Button CssClass="button2" ID="Button5" runat="server" Text="Yükle" OnClick="Button5_Click" />
                            <asp:Label ID="Label7" runat="server"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
	</div>
    </form>
</body>
</html>
