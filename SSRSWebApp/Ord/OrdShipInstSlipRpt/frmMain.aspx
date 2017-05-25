<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMain.aspx.cs" Inherits="SSRSWebApp.Ord.OrdShipInstSlipRpt.frmMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>OrdShipInstSlipRpt - 出荷伝票発行</title>
    <link href="../../Contents/CSS/import.css" rel="stylesheet" type="text/css" />
	<script src="../../Contents/JS/AppDefault.js" type="text/javascript"></script>
	<script src="../../Contents/JS/lib/jquery/1.12.3/jquery.min.js" type="text/javascript"></script>
	<script src="../../Contents/JS/lib/layer/layer.js" type="text/javascript"></script>
	<script src="../../Contents/JS/RptPopWinMulti.js" type="text/javascript"></script>
    <style type="text/css">
        .fakeContainer 
        {      
        	
    	    /*LEFT: 4px; 
            TOP: 10px;    	   
    	    POSITION: relative;*/
            float: left;          
            border: none;           
            background-color:Transparent;
            overflow: hidden;       
        }
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
                            <li><asp:imagebutton id="cmdSearch" style="Z-INDEX: 110; " tabIndex="-1" runat="server" 
							ImageUrl="../../Contents/Image/BackGround/btn-search1-1.jpg" onclick="cmdSearch_Click" ></asp:imagebutton>
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
                        CssClass="TitleLabel" Width="250px">出荷伝票発行</asp:label>
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
                <asp:Label ID="flblCUST_CD" style="Z-INDEX: 101; " runat="server" 
                    Width="100px" CssClass="fi_mtitle">顧客コード</asp:Label>
                <asp:TextBox id="txtCUST_CD" style="Z-INDEX: 102; margin-right:5px;" runat="server" Width="100px" AUTOCOMPLETE="off" 
                    CssClass="text_input_left_key" MaxLength="10" TabIndex="1"></asp:TextBox>
                <asp:textbox ID="txtCUST_SUB_CD" style="Z-INDEX: 101;" runat="server"  Width="20px" CssClass="text_input_left_key" Height="17px" 
                   MaxLength ="3" TabIndex="2"></asp:textbox>
                <img id="btnCUSTSearch" style="Z-INDEX: 107;" class="searchbtn" 
                    src="../../Contents/Image/BackGround/sbtn_srch.gif" runat="server" alt=""/>
                <asp:textbox ID="lblCUST_DESC" style="Z-INDEX: 101; " runat="server" 
                    Width="300px" CssClass="d_label" ReadOnly="True" TabIndex="-1" BackColor="#CCCCCC" ></asp:textbox>
            </div>
            <div id="line02" class="divline">
                <asp:label id="flblSCH_SHIP_DATE" style="Z-INDEX: 101; " runat="server" 
                    Width="100px" CssClass="fi_mtitle">出荷予定日</asp:label>
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
                <asp:CheckBox ID="chkReprint" runat="server" CssClass="fi_mtitle"　                        
                    style="LEFT: 436px; POSITION: absolute; TOP: 35px; " 
                    Text="再発行" AutoPostBack="true" oncheckedchanged="chkReprint_CheckedChanged" />
            </div>
            <div id="line03" class="divline">
                <asp:CheckBox ID="chkAll" runat="server" Text="全選択" CssClass="fi_mtitle" 
                            style=" LEFT: 8px; POSITION:relative; TOP: 2px;" AutoPostBack="true" 
                            OnCheckedChanged="chkALL_SEL_CheckedChanged"/>
            </div>
            <div id="line04" class="divline" style="padding-top:10px;">
                <asp:GridView ID="dgvDetail" runat="server" Width ="700px"
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                        CellPadding="2" AutoGenerateColumns="False" PageSize="100" 
                        GridLines="Vertical" ForeColor="Black"
                        AllowPaging="True" onpageindexchanging="dgvDetail_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSel" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="24px" />
                                <HeaderStyle Width="24px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NO">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex  + 1%>
                                </ItemTemplate>
                                <ItemStyle Width="24px" />
                                <HeaderStyle Width="24px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="顧客コード">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblCUST_CD" runat="server" CssClass="GVCellText_Cust" Text='<%# Bind("CUST_CD") %>' ToolTip='<%# Bind("CUST_CD") %>' ReadOnly="true" TabIndex="-1"></asp:TextBox>                                    
                                </ItemTemplate>
                                <ItemStyle CssClass="GVCellLbl_Cust" />
                                <HeaderStyle CssClass="GVCellLbl_Cust" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="顧客名">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblCUST_NAME" runat="server" CssClass="GVCellText_CustName" Text='<%# Bind("CUST_NAME") %>' ToolTip='<%# Bind("CUST_NAME") %>' ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="GVCellLbl_CustName" />
                                <HeaderStyle CssClass="GVCellLbl_CustName" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="出荷予定日" DataField="SCH_SHIP_DATE" DataFormatString="{0:0###/##/##}" >
                            <ItemStyle HorizontalAlign="Center" CssClass="GVCellLbl_Date" />
                            <HeaderStyle CssClass="GVCellLbl_Date" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="出荷伝票№" DataField="SHIP_NO" >
                            <ItemStyle CssClass="GVCellLbl_IssueNo" />
                            <HeaderStyle CssClass="GVCellLbl_IssueNo" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="明細数" DataField="DET_QTY" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" CssClass="GVCellLbl_Qty" />
                            <HeaderStyle CssClass="GVCellLbl_Qty" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle CssClass="GVFooter" />
                        <PagerStyle CssClass ="GVPager" />
                        <SelectedRowStyle CssClass ="GVSelectedRow" />
                        <HeaderStyle CssClass ="GVHeader" />
                        <AlternatingRowStyle CssClass ="GVAlternatingRow" />
                        <RowStyle CssClass="GVRow" />
                    </asp:GridView>
                <script type="text/javascript">
                    var obj = window.document.getElementById("<%= dgvDetail.ClientID%>");
                    if (obj != null) {
                        obj.parentNode.className = "fakeContainer";

                        (function () {
                            var start = new Date();
                            superTable("<%= dgvDetail.ClientID%>", {
                                     fixHeight: 340,
                                     fixWidth: 718,
                                     onFinish: function () {
                                         return;
                                     }
                                 });
                             })();
                         }
                     </script>	
            </div>
            <div style="margin-bottom:10px;"></div>

                <rsweb:ReportViewer ID="rptver1" runat="server" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="100%" Width="100%" CssClass="rptBox">
                    <ServerReport ReportServerUrl="http://localhost/ReportServer" />
                </rsweb:ReportViewer>   

                <rsweb:ReportViewer ID="rptver2" runat="server" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="100%" Width="100%" CssClass="rptBox">
                    <ServerReport ReportServerUrl="http://localhost/ReportServer" />
                </rsweb:ReportViewer>

                <rsweb:ReportViewer ID="rptver3" runat="server" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="100%" Width="100%" CssClass="rptBox">
                    <ServerReport ReportServerUrl="http://localhost/ReportServer" />
                </rsweb:ReportViewer>

                <rsweb:ReportViewer ID="rptver4" runat="server" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="100%" Width="100%" CssClass="rptBox">
                    <ServerReport ReportServerUrl="http://localhost/ReportServer" />
                </rsweb:ReportViewer>   
            
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
