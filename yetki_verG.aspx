<%@ Page Language="C#" AutoEventWireup="true" CodeFile="yetki_verG.aspx.cs" Inherits="index" %>

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
		</div>
	</div>
	<div id="container" >
        <table style="width: 100%; height: 100%; background-color: black; color: white; padding-bottom: 5px; padding-left: 5px; margin-bottom: 25px;">
            <tr>
                <td style="text-align: center;" colspan="2">= Yetki Ver =</td>
            </tr>
            <tr>
                <td class="auto-style2">Yetki Verilecek Kişi:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Verilecek Yetki:</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Şifreniz:</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Button ID="Button3" CssClass="button2" runat="server" Text="Yetki Ver" OnClick="Button3_Click" />                    
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
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
                    <td rowspan="2"><a href='<%# Eval("anasayfaG").ToString() %>'><img src="Image/site/logo.jpg"></a></td>
                </tr>
            </table>
            </div>
            <div id="baslik">
                <h3><a href='<%# Eval("anasayfaG").ToString() %>'>Zamunda Torrent</a></h3>
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
