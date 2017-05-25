<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SrchCustomer.aspx.cs" Inherits="SSRSWebApp.Common.Search.SrchStore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Store Search - 顧客検索</title>
    <link href="../../Contents/CSS/import.css" rel="stylesheet" type="text/css" />
	<script src="../../Contents/JS/AppDefault.js" type="text/javascript"></script>
    <script src="../../Contents/JS/superTables.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" style="height: 100%;">
    <!-- Header -->
    <div id="popschhead">
        <table>
            <tr>
                <td class="schpopheadleft"></td>
                <td class="schpopheadtitle" valign="middle">
                    <asp:Label ID="flblTitle" runat="server" CssClass="SrchLabel" Width="200px">顧客検索</asp:Label>
                </td>
                <td class="schpopheadcnt">
                    <asp:Label ID="flblCount" runat="server" CssClass="CountLabel">[件数 = 0]</asp:Label>
                </td>
                <td class="schpopheadbtn">
                    <ul class="btn">
                            <li><asp:ImageButton ID="imgBack" ImageUrl="../../Contents/Image/BackGround/btn-back1-1.jpg"
                                 ImageAlign="Middle" runat="server" BorderWidth="0px" BorderStyle="None" TabIndex="-1">
                                 </asp:ImageButton>                                        
                            </li>
                            <li><asp:imagebutton id="imgDisp" style="Z-INDEX: 110; " tabIndex="-1" runat="server" 
                                ImageUrl="../../Contents/Image/BackGround/btn-ind1-1.jpg" 
                                onclick="imgDisp_Click"  ></asp:imagebutton>
                            </li>
                                                       
                    </ul>
                </td>
            </tr>
        </table>
    </div>
    <div id="popschheadline"></div>
    <div id="popschmsg">
        <asp:textbox id="lblMsg" style="Z-INDEX: 108;" tabIndex="-1" runat="server" 
            Width="500px" BorderStyle="None" BackColor="Transparent"  AUTOCOMPLETE="off" MaxLength="999" Font-Bold="True" 
            ReadOnly="True" ForeColor="Red"></asp:textbox>
    </div>
    <div id="popschcondtions">
        <div class="divline">
            <asp:Label ID="flblSRCH_CUSTOMER_CD" runat="server" Style="z-index: 108;" Text="顧客コード" Width="100px" CssClass="fi_mtitle"></asp:Label>
            <asp:TextBox ID="txtSRCH_CUSTOMER_CD" runat="server" Style="z-index: 125;" Width="150px" MaxLength="20" CssClass="text_input_left_key" AUTOCOMPLETE="off"></asp:TextBox>
        </div>
        <div class="divline">
            <asp:Label ID="flblSRCH_CUSTOMER_NAME" Style="z-index: 108;" runat="server" CssClass="fi_mtitle" Width="100px">顧客略称の一部</asp:Label>
            <asp:textbox id="txtSRCH_CUSTOMER_NAME" style="Z-INDEX: 102; height: 18px; width: 300px;" 
                        runat="server"  MaxLength="30"  CssClass="text_input_left"
                        AUTOCOMPLETE="off"></asp:textbox>
        </div>
    </div>
    <!-- Detail -->
    <div id="popschlist">
        <asp:GridView ID="dgvSearch" runat="server" BackColor="White" CssClass="GridTable"
                            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False"
                            PageSize="45" OnSorting="dgvSearch_Sorting" OnSelectedIndexChanged="dgvSearch_SelectedIndexChanged"
                            AllowSorting="True" OnPageIndexChanging="dgvSearch_PageIndexChanging"
                            AllowPaging="True" OnRowDataBound="dgvSearch_RowDataBound">
                            <FooterStyle CssClass="GVFooter" />
                            <HeaderStyle CssClass="GVHeader" ForeColor="White" />
                            <PagerStyle CssClass="GVPager" />
                            <SelectedRowStyle CssClass="GVSelectedRow" />
                            <AlternatingRowStyle CssClass="GVAlternatingRow" />
                            <RowStyle CssClass="GVRow" />
                            <Columns>
                                <asp:TemplateField HeaderText="№">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex  + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="24px" />
                                    <ItemStyle Width="24px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="CUST_CD" HeaderText="顧客コード" ReadOnly="True" 
                                SortExpression="CUST_CD">
                                    <ItemStyle CssClass="GVCellLbl_ItemName"/>
                                    <HeaderStyle CssClass="GVCellLbl_ItemName" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CUST_SUB_CD" HeaderText="顧客サブコード" ReadOnly="True" 
                                SortExpression="CUST_SUB_CD">
                                    <ItemStyle CssClass="GVCellLbl_ItemName"/>
                                    <HeaderStyle CssClass="GVCellLbl_ItemName" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="顧客略称" SortExpression="CUST_NAME">
                                <ItemTemplate>
                                    <asp:textbox ID="lblDesc" runat="server" CssClass="GVCellText_SrcName" Text='<%# Bind("CUST_NAME") %>' ToolTip='<%# Bind("CUST_NAME") %>' ReadOnly="true"></asp:textbox>
                                </ItemTemplate>
                                <ItemStyle  CssClass="GVCellLbl_ItemDesc" />
                                <HeaderStyle CssClass="GVCellLbl_ItemDesc" />
                            </asp:TemplateField>
                            </Columns>
        </asp:GridView>
    </div>
        <script type="text/javascript">
                    var   obj=window.document.getElementById("<%= dgvSearch.ClientID%>");   
                    if   (obj   !=   null)   
                    {   
                     obj.parentNode.className = "fakeContainer";

                        (function() {
                            var start = new Date();
                            superTable("<%= dgvSearch.ClientID%>", {  
                               fixHeight : 345 ,
                               fixWidth : 555 ,
                               onFinish : function () 
                               {                                      
                                    return;         
                               }
                            });
                        })(); 
                    }
        </script>

    <!-- Footer -->
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
