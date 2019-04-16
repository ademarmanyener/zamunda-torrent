<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Zamunda Torrent - Oyun, dizi, film...</title>
    <link rel="shortcut icon" href="Image/site/logo.jpg">
    <link rel="stylesheet" type="text/css" href="Css/style.css">
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <div id="header1">
                <div id="logo"><a href="index.aspx">
                    <img src="Image/site/logo.jpg"></a></div>
                <div id="title">
                    <h3><a href="index.aspx">Zamunda Torrent</a></h3>
                </div>
                <div id="category">
                    <table>
                        <tr>
                            <td>
                                <asp:Button CssClass="button1" ID="Button1" runat="server" Text="Oyun" OnClick="Button1_Click" />
                            </td>
                            <td>
                                <asp:Button CssClass="button1" ID="Button2" runat="server" Text="Dizi" OnClick="Button2_Click" />
                            </td>
                            <td>
                                <asp:Button CssClass="button1" ID="Button3" runat="server" Text="Film" OnClick="Button3_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="menu">
                    <table>
                        <tr>
                            <td><a href="giris_yap.aspx">
                                <img src="Image/site/giris_yap.png"></a></td>
                            <td><a href="uye_ol.aspx">
                                <img src="Image/site/uye_ol.png"></a></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="container">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageButton1" ImageUrl='<%# "Image/torrent/"+Eval("torrent_resmi").ToString() %>' PostBackUrl='<%# "~/torrent_sayfasi.aspx?torrent_id="+Eval("torrent_id").ToString() %>' runat="server" Height="290px" Width="249px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" Style="font-size: 20px;" runat="server" Text='<%# Eval("torrent_adi").ToString() %>'></asp:Label>
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
