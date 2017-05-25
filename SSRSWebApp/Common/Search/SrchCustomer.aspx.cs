/*|------------------------------------------------------------------------------------------|*/
/*|  プロジェクト名　：　ProductionMaster                                                    |*/
/*|  機能名　　　　　：　顧客検索画面　　                                                    |*/
/*|  プログラムID  　：　SrchCustomer                                                       |*/
/*|------------------------------------------------------------------------------------------|*/
/*| [ 検索結果戻り値 ]                                                                       |*/
/*|     Array[0] : 顧客コード                                                                |*/
/*|     Array[1] : 顧客サブコード                                                            |*/
/*|     Array[2] : 顧客略称                                                                  |*/
/*|------------------------------------------------------------------------------------------|*/
/*|  [履歴]  　                                                                              |*/
/*|  2017/03/13     UBIQ_SH        　新規作成                                                |*/
/*|------------------------------------------------------------------------------------------|*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Drawing;
using PMClass;

namespace SSRSWebApp.Common.Search
{
    public partial class SrchStore : System.Web.UI.Page
    {
        protected string g_user_id;
        protected int g_lang;
        protected string g_company_cd;
        protected string g_name;

        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie MyCookie;
            //try
            //{
            //    MyCookie = new HttpCookie("PMLastVisit");
            //    HttpCookieCollection MyCookieColl = Request.Cookies;
            //    MyCookie = MyCookieColl.Get("PMLastVisit");
            //    g_user_id = MyCookie.Values["USER_ID"];
            //    g_lang = int.Parse(MyCookie.Values["LANG"]);
            //    g_company_cd = MyCookie.Values["COMPANY_CD"];
            //    g_name = HttpUtility.UrlDecode(MyCookie.Values["NAME"]);
            //}
            //catch
            //{
            //    Response.Redirect("~/NotLoginErr.htm");
            //}

            lblMsg.Text = ""; 
            if (!IsPostBack)
            {
                // 画面編集
                Init_Label();
                Init_Proc();
                Script_Proc();
                this.imgBack.Attributes["onclick"] = "JavaScript:window.close()";
            }

            //Script_Proc();

        }

        #region : 初期画面ラベル編集
        //
        // 初期画面ラベル編集
        //
        protected void Init_Label()
        {
            imgDisp.Attributes["onmouseover"] = "MM_swapImage('" + imgDisp.ClientID + "','','../../Contents/Image/BackGround/btn-ind2-1.jpg',1);";
            imgDisp.Attributes["onmouseout"] = "MM_swapImgRestore();";
            imgBack.Attributes["onmouseover"] = "MM_swapImage('" + imgBack.ClientID + "','','../../Contents/Image/BackGround/btn-Back2-1.jpg',1);";
            imgBack.Attributes["onmouseout"] = "MM_swapImgRestore();";

            ////DropDownList Data Bind
            //DataSet dt = new DataSet();
            //ComLibrary com = new ComLibrary();
            //SystemParameter sp = new SystemParameter();
            ////店舗業態コード
            //sp.business_catg = "HY";
            //sp.spkey1 = "STORE_CATG";
            //dt = sp.GetSPListByBuisinessCatgAndSPKey1();
            //ddlSTORE_TYPE.DataValueField = "SPKEY2";
            //ddlSTORE_TYPE.DataTextField = "SPCHR1";
            //ddlSTORE_TYPE.DataSource = dt;
            //ddlSTORE_TYPE.DataBind();
            //ddlSTORE_TYPE.Items.Insert(0, "");
            
        }
        #endregion

        #region : 初期画面編集
        //
        // 初期画面編集
        //
        protected void Init_Proc()
        {
            // Grid_View編集
            Edit_Grid();
        }

        #endregion

        /// <summary>
        /// 再表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgDisp_Click(object sender, ImageClickEventArgs e)
        {
            // Grid_View編集
            Edit_Grid();
            Script_Proc();
        }

        protected void Edit_Grid()
        {
            // 仕入先マスタより一覧を得る
            Customer customer = new Customer(g_user_id, g_lang);
            Message msg = new Message(g_user_id, g_lang);

            customer.cust_cd = txtSRCH_CUSTOMER_CD.Text.ToUpper();
            customer.cust_name = txtSRCH_CUSTOMER_NAME.Text;
            DataSet ds = customer.GetCustomerList();

            //-->ADD BY UBIQ-SUO 2010/09/25
            if (customer.range)
            {
                lblMsg.Text = msg.GetMessage("OUT_2000_RANGE");
                lblMsg.ForeColor = Color.Red;
            }
            //<--ADD BY UBIQ-SUO 2010/09/25

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgvSearch.DataSource = ds.Tables[0];
                dgvSearch.DataBind();
                ViewState["dgvSearch"] = ds.Tables[0];
            }
            string[] strcou;
            strcou = flblCount.Text.Split('=');
            flblCount.Text = strcou[0] + " = " + ds.Tables[0].Rows.Count.ToString() + "]";
        }

        /// <summary>
        /// [ 共通：クライアントスクリプトの生成 ]
        ///		検索・検索結果を起動元(親)画面に返すJavaScriptを記述
        /// </summary>
        protected void Script_Proc()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(@"function SelectedRow(item1, item2) {");
            sb.Append(@"    var arr0 = item1;");   //コード
            sb.Append(@"    var arr1 = item2;");   //名   
            sb.Append(@"    var ret= new Array(arr0,arr1);    ");
            sb.Append(@"    window.opener.").Append(Request["ScriptName"].ToString()).Append("(ret); ");
            sb.Append(@"    __doPostBack();   ");
            sb.Append(@"    window.close();   ");
            sb.Append(@"} ");

            // onMouseover Event
            sb.Append(@"function MouseoverRow(ID) {");
            sb.Append(@"    document.getElementById(ID).style.backgroundColor = 'orange' ");
            sb.Append(@"} ");

            // onMouseout Event
            sb.Append(@"function MouseoutRow(ID) {");
            sb.Append(@"    document.getElementById(ID).style.backgroundColor = '' ");
            sb.Append(@"} ");

            sb.Append(@"</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "SelectedRow", sb.ToString());
        }

        // Sort
        //
        // Fixed logic. Do not change.
        //
        protected void dgvSearch_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, " DESC");
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, " ASC");
            }
            Script_Proc();
        }
        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;
                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }
        private void SortGridView(string sortExpression, string direction)
        {
            DataTable dt = (DataTable)ViewState["dgvSearch"];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
            dgvSearch.DataSource = dv;
            dgvSearch.DataBind();
        }


        protected void dgvSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Script_Proc();
        }

        //
        // Fixed logic. Do not change.
        //
        protected void dgvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSearch.SelectedIndex = -1;
            dgvSearch.PageIndex = e.NewPageIndex;
            // Grid_View編集
            Edit_Grid();
            Script_Proc();
        }

        /// <summary>
        ///		
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dgvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string strEvent = "";
            ComLibrary com = new ComLibrary();

            if (e.Row.DataItemIndex >= 0)
            {
                strEvent = String.Format("SelectedRow('{0}', '{1}', '{2}')", com.SetJsStr(e.Row.Cells[1].Text),
                    com.SetJsStr(e.Row.Cells[2].Text),
                    com.SetJsStr(((TextBox)e.Row.Cells[3].FindControl("lblDesc")).Text));
                e.Row.Attributes.Add("onClick", strEvent);

                strEvent = String.Format("MouseoverRow('{0}')", e.Row.ClientID);
                e.Row.Attributes.Add("onmouseover", strEvent);

                strEvent = String.Format("MouseoutRow('{0}')", e.Row.ClientID);
                e.Row.Attributes.Add("onmouseout", strEvent);
            }
        }
    }
}
