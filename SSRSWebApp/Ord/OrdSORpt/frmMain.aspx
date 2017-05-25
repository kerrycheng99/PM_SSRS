<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMain.aspx.cs" Inherits="SSRSWebApp.Ord.OrdSORpt.frmMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>OrdSORpt - 受注一覧表</title>
    <link href="../../Contents/CSS/import.css" rel="stylesheet" type="text/css" />
	<script src="../../Contents/JS/AppDefault.js" type="text/javascript"></script>
	<script src="../../Contents/JS/lib/jquery/1.12.3/jquery.min.js" type="text/javascript"></script>
	<script src="../../Contents/JS/lib/layer/layer.js" type="text/javascript"></script>
	<script src="../../Contents/JS/RptPopWinMulti.js" type="text/javascript"></script>
    <style type="text/css">
        .rptBox{display:none;}
    </style>
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
                    <td class="topbtn">
                        <ul class="btn">
                            <li><asp:imagebutton id="cmdRelease" style="Z-INDEX: 110; " tabIndex="-1" runat="server" 
                                ImageUrl="../../Contents/Image/BackGround/btn-issue1-1.jpg" 
                                onclick="cmdIssue_Click"  ></asp:imagebutton>
                            </li>                           
                        </ul>
                    </td>
                    <td class="toprighttop">
                        <ul class="btn">
                            <li><asp:imagebutton id="imgReturn" 
                                imageurl="../../Contents/Image/BackGround/btn-menu.jpg" ImageAlign="Middle" 
                                Runat="server" BorderWidth="0px" BorderStyle="None" tabIndex="-1" 
                                onclick="imgReturn_Click" ></asp:imagebutton>
                            </li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td valign="top" colspan="2" class="toppgtit">
                        <asp:label id="flblTitle" runat="server" style=" height: 23px;" 
                        CssClass="TitleLabel" Width="250px">受注一覧表</asp:label>
                    </td>
				    <td colspan="2"><div class="toprightbtm"></div></td>
				</tr>
			</table>
    </div>
    <div id="msg">
        <asp:textbox id="lblMsg" style="Z-INDEX: 108; padding: 5px 0px;" tabIndex="-1" runat="server" Width="704px" BorderStyle="None" BackColor="Transparent"  AUTOCOMPLETE="off" MaxLength="999" Font-Bold="True" ReadOnly="True" ForeColor="Red"></asp:textbox>
    </div>
    <div id="main">
        <div id="main-content">
            <div id="line01" class="divline">
                <asp:Label ID="flbCUST_CD" style="Z-INDEX: 101; " runat="server" 
                    Width="100px" CssClass="fi_mtitle">顧客コード</asp:Label>
                <asp:TextBox id="txtCUST_CD" style="Z-INDEX: 102; margin-right:5px;" runat="server" Width="100px" AUTOCOMPLETE="off" 
                    CssClass="text_input_left_key" MaxLength="10" TabIndex="1"></asp:TextBox>
                <asp:textbox ID="txtCUST_CD1" style="Z-INDEX: 101;" runat="server"  Width="20px" CssClass="text_input_left_key" Height="17px" 
                   MaxLength ="3" TabIndex="2"></asp:textbox>
                <img id="btnCUSTSearch" style="Z-INDEX: 107;" class="searchbtn" 
                    src="../../Contents/Image/BackGround/sbtn_srch.gif" runat="server" alt=""/>
                <asp:textbox ID="lblCUST_DESC" style="Z-INDEX: 101; " runat="server" 
                    Width="300px" CssClass="d_label" ReadOnly="True" TabIndex="-1" BackColor="#CCCCCC" ></asp:textbox>
            </div>
            <div id="line02" class="divline">
                <asp:Label ID="flblSCH_ID" style="Z-INDEX: 101; height: 17px;" runat="server" 
                Width="100px" CssClass="fi_mtitle">計画担当者</asp:Label>
                <asp:DropDownList ID="ddlSCH_ID" style=" width: 100px; height: 20px;" 
                        runat="server"></asp:DropDownList>
                <asp:TextBox ID="lblSCH_NAME" style="width: 100px; height: 17px;" 
                        runat="server" CssClass="d_label" BackColor="#CCCCCC"  
                        BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" TabIndex="-1"></asp:TextBox>
            </div>
            <div id="line03" class="divline">
                <asp:label id="flblORDER_DATE" style="Z-INDEX: 101; " runat="server" 
                    Width="100px" CssClass="fi_mtitle">受注日</asp:label>
                <asp:TextBox ID="txtDATE_BEG" runat="server" MaxLength="8" Style="z-index: 300;text-align:center;"
                    TabIndex="4" Width="100px" CssClass="text_input_left_key"></asp:TextBox>
                <cc1:MaskedEditExtender ID="mskDATE_BEG" runat="server" TargetControlID="txtDATE_BEG" Mask="9999/99/99" MaskType="Date">
                </cc1:MaskedEditExtender>
                <img id="btnimgDue" style="Z-INDEX: 107;" class="searchbtn"
                    src="../../Contents/Image/BackGround/sbtn-cal.jpg" runat="server"  alt=""/>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                      CssClass="MyCalendar" PopupButtonID="btnimgDue" 
                      TargetControlID="txtDATE_BEG" Enabled="True" Format="yyyy/MM/dd"></cc1:CalendarExtender>
                      
                <asp:Label ID="flblTo" runat="server" CssClass="fi_mtitle" Height="22px" Style="z-index: 101;" Width="20px" TabIndex="-1">～</asp:Label>
                
                <asp:TextBox ID="txtDATE_END" runat="server" MaxLength="8" Style="z-index: 300;text-align:center;"
                    TabIndex="4" Width="100px" CssClass="text_input_left_key"></asp:TextBox>
                <cc1:MaskedEditExtender ID="mskDATE_END" runat="server" TargetControlID="txtDATE_END" Mask="9999/99/99" MaskType="Date">
                </cc1:MaskedEditExtender>
                <img id="btnimgDueEnd" style="Z-INDEX: 107;" class="searchbtn"
                    src="../../Contents/Image/BackGround/sbtn-cal.jpg" runat="server"  alt=""/>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                      CssClass="MyCalendar" PopupButtonID="btnimgDueEnd" 
                      TargetControlID="txtDATE_END" Enabled="True" Format="yyyy/MM/dd"></cc1:CalendarExtender>
            </div>
            <div style="margin-bottom:10px;"></div>
            <div id="rptContent" style="display:none;">
            </div>
                <rsweb:ReportViewer ID="rptver" runat="server" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="100%" Width="100%" CssClass="rptBox">
                    <ServerReport ReportServerUrl="http://localhost/ReportServer" />
                </rsweb:ReportViewer>     
            <%--<asp:Panel ID="rptContent" runat="server" Height="100%" Width="100%" style="display:none;"></asp:Panel>--%>
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
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
