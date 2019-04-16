<%@ Page Language="C#" AutoEventWireup="true" CodeFile="torrent_sayfasiG.aspx.cs" Inherits="torrent_sayfasi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>Zamunda Torrent - Oyun, dizi, film...</title>
	<link rel="shortcut icon" href="Image/site/logo.jpg">
	<link rel="stylesheet" type="text/css" href="Css/style.css">
    <style type="text/css">
        #Button4 {
            width: 250px;
            height: 150px;
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
                            <asp:Button CssClass="button1" ID="Button3" runat="server" Text="Anasayfa" OnClick="Button3_Click" />
                        </td>
                    </tr>
                </table>
            </div>
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
                            <asp:Button ID="Button1" runat="server" CssClass="button2" Text="Profilim" OnClick="Button1_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" CssClass="button2" Text="Çıkış Yap" OnClick="Button2_Click" />
                        </td>
                    </tr>
				</table>
			</div>
		</div>
	</div>
    <!-- <div id="container" style="background-color: white; border: 1px solid black; font-size: 25px;"> -->
        <div id="container" style="color: white;">
        <asp:DataList ID="DataList1" style="margin: 0px;" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
            <ItemTemplate>
                <table style="width:100%;">
                    <tr>
                        <td>
                            <asp:Image ID="Image1" style="margin-left: 200px;" runat="server" ImageUrl='<%# "~/Image/torrent/"+Eval("torrent_resmi").ToString() %>' Height="416px" Width="361px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image2" style="margin-left: 250px;" runat="server" ImageUrl="~/Image/site/dosya_adi.png" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" style="margin-left: 225px;" runat="server" Text='<%# Eval("torrent_adi").ToString() %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image3" style="margin-left: 250px;" runat="server" ImageUrl="~/Image/site/not.png" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" style="margin-left: 25px;" runat="server" Text='<%# Eval("torrent_bilgisi").ToString() %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image4" style="margin-left: 250px;" runat="server" ImageUrl="~/Image/site/indirme_linki.png" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton CssClass="linkButton1" ID="LinkButton1" style="margin-left: 225px;" runat="server" OnClick="LinkButton1_Click">İndirmek için tıklayın.</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Image BorderStyle="Dotted" BorderColor="Orange" ID="Image5" runat="server" ImageUrl='<%# "~/Image/avatar/"+Eval("torrent_ekleyen_kisi").ToString()+".jpg" %>' Height="175px" Width="188px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%# "Ekleyen kişi: "+ Eval("torrent_ekleyen_kisi").ToString() %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>          
            <asp:Button CssClass="button2" ID="Button4" runat="server" Text="Güncelle" Height="65px" Width="133px" OnClick="Button4_Click" />
            <asp:Button CssClass="button2" ID="Button5" runat="server" Text="Sil" Height="65px" Width="133px" OnClick="Button5_Click" />
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
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
</body>
</html>
