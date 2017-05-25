<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SSRSWebApp._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SSRSWebApp Menu</title>
    <link href="Contents/CSS/import.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="Contents/JS/AppDefault.js"></script>
    <script type="text/javascript">
            window.onload = function () {
                autoFit();               
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="head">
		<table>
                <tr>
                    <td class="topleft"></td>
                    <td class="toplog" valign="bottom"></td>
                    <td class="topusr">
                        <ul class="usr"><li><asp:label id="lblUserName" runat="server" Width="150px" CssClass="fi_mtitle" Height="18px">User Name</asp:label></li>
                        </ul>
                    </td>
                    <td class="topbtn"></td>
                    <td class="toprighttop"></td>
                </tr>
                <tr>
                    <td></td>
                    <td valign="top" colspan="2" class="toppgtit">
                        <asp:label id="flblTitle" runat="server" style=" height: 23px;" 
                        CssClass="TitleLabel" Width="250px">メインメニュー</asp:label>
                    </td>
				    <td colspan="2"><div class="toprightbtm"></div></td>
				</tr>
			</table>
    </div>
    <div id="msg">
        <asp:textbox id="lblMsg" style="Z-INDEX: 108; padding: 5px" tabIndex="-1" runat="server" Width="704px" BorderStyle="None" BackColor="Transparent"  AUTOCOMPLETE="off" MaxLength="999" Font-Bold="True" ReadOnly="True" ForeColor="Red"></asp:textbox>
    </div>
    <div id="main">
        <div id="main-content">
            <ul class="menutitle">
                <li onclick="javascript:document.getElementById('01').click();" style="cursor:pointer;"><a id="01" href="Ord/OrdSORpt/frmMain.aspx">受注一覧表発行</a></li>
                <li onclick="javascript:document.getElementById('02').click();" style="cursor:pointer;"><a id="02" href="Ord/OrdShipInstSlipRpt/frmMain.aspx">出荷伝票発行</a></li>
                
                <li><span>XXX発行</span></li>
                <li><span>XXX発行</span></li>
                
                <li><span>XXX発行</span></li>
                <li><span>XXX発行</span></li>
                
                <li><span>XXX発行</span></li>
                <li><span>XXX発行</span></li>
                
            </ul>
        </div>
    </div>
    <div id="foot">
		    <table>
                <tr>
                    <td class="footlef"></td>
                    <td class="footmid"></td>
                    <td class="footcp"></td>
                </tr>
                <tr>
                    <td colspan="3" class="footbg"></td>
                </tr>
            </table>
            <!--[if IE 6]>
            <script type="text/javascript">
            (function(){
            var overlay = document.getElementById('overlay'), t;
            window.onscroll = function() {
            t && clearTimeout(t);
            t = setTimeout(function() {
            // reflow
            overlay.className = overlay.className;
            }, 13);
            };
            })();
            </script>
            <![endif]-->
        </div>
        
    </form>
</body>
</html>
