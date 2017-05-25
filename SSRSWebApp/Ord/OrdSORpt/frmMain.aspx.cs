using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Drawing;
using System.Data;

using System.Web.Configuration;
using Microsoft.Reporting.WebForms;
using PMClass;
using SSRSWebApp.Common.Ssrs;

namespace SSRSWebApp.Ord.OrdSORpt
{
    public struct ReportPrameter
    {
        public string CustCd;
        public string CustSubCd;
        public string SchId;
        public string DateBeg;
        public string DateEnd;
    }

    public partial class frmMain : System.Web.UI.Page
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
            //TEST
            ComLibrary com = new ComLibrary();
            string _Lang = WebConfigurationManager.ConnectionStrings["LANG"].ConnectionString;
            g_lang = com.StringToInt(_Lang);

            

            if (!IsPostBack)
            {
                // SSRS base setting
                this.rptver.Load += new System.EventHandler(this.SsrsBaseSetting); 

                // 画面編集
                this.txtDATE_BEG.Text = DateTime.Now.Date.AddDays(1 - DateTime.Now.Day).ToString("yyyy/MM/dd");
                this.txtDATE_END.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");
                txtCUST_CD.Focus();
                ddl_edit();
                Init_Label();
            }

            lblMsg.Text = "";
            Add_Search();

        }

        protected void ddl_edit()
        {
            DataSet dt = new DataSet();
            ComLibrary com = new ComLibrary();

            SystemParameter parameter = new SystemParameter(g_user_id, g_lang);
            parameter.key01 = "SCH_ID";
            dt = parameter.GetDetailList();

            ddlSCH_ID.DataValueField = "DATA_CHAR";
            ddlSCH_ID.DataTextField = "KEY02";
            ddlSCH_ID.DataSource = dt;
            ddlSCH_ID.DataBind();
            ddlSCH_ID.Items.Insert(0, "");
        }

        protected void Init_Label()
        {
            Dictionary dic = new Dictionary(g_user_id, g_lang);
            dic.screen_id = "OrdSORpt_frmMain";
            DataSet ds = dic.GetLabelOfScreenList();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    switch (row["CONTROL_ID"].ToString())
                    {
                        // ラベル
                        case "flblTitle": flblTitle.Text = row["ITEM_DESC"].ToString(); break;
                        case "flbCUST_CD": flbCUST_CD.Text = row["ITEM_DESC"].ToString(); break;
                        case "flblSCH_ID": flblSCH_ID.Text = row["ITEM_DESC"].ToString(); break;
                        case "flblORDER_DATE": flblORDER_DATE.Text = row["ITEM_DESC"].ToString(); break;
                        //
                    }
                }
            }

            cmdRelease.Attributes["onmocuseover"] = "MM_swapImage('" + cmdRelease.ClientID + "','','../../Contents/Image/BackGround/btn-Issue2-1.jpg',1);";
            cmdRelease.Attributes["onmouseout"] = "MM_swapImgRestore();";

            imgReturn.Attributes["onmouseover"] = "MM_swapImage('" + imgReturn.ClientID + "','','../../Contents/Image/BackGround/btn-menu_on.jpg',1);";
            imgReturn.Attributes["onmouseout"] = "MM_swapImgRestore();";

            btnCUSTSearch.Attributes["onmouseover"] = "MM_swapImage('" + btnCUSTSearch.ClientID + "','','../../../Contents/Image/BackGround/sbtn_srch_on.gif',1);";
            btnCUSTSearch.Attributes["onmouseout"] = "MM_swapImgRestore();";

            btnimgDue.Attributes["onmouseover"] = "MM_swapImage('" + btnimgDue.ClientID + "','','../../Contents/Image/BackGround/sbtn-cal_on.jpg',1);";
            btnimgDue.Attributes["onmouseout"] = "MM_swapImgRestore();";

            btnimgDueEnd.Attributes["onmouseover"] = "MM_swapImage('" + btnimgDueEnd.ClientID + "','','../../Contents/Image/BackGround/sbtn-cal_on.jpg',1);";
            btnimgDueEnd.Attributes["onmouseout"] = "MM_swapImgRestore();";

        }

        /// <summary>
        /// POPUP検索画面を作成する
        /// </summary>
        protected void Add_Search()
        {
            Search srch = new Search();
            ArrayList arrObj = new ArrayList();

            // 顧客検索画面
            srch.search_type = Search.SearchType.CUSTOMER;
            srch.opener = this;
            srch.opener_button = btnCUSTSearch;
            arrObj.Add(txtCUST_CD);
            arrObj.Add(txtCUST_CD1);
            arrObj.Add(lblCUST_DESC);
            srch.return_controls = arrObj;
            int rtn = srch.CreateSearchWindow();

        }

        #region DefineInitDate() : 初期化日付の設定
        /// <summary>
        /// 初期化日付の設定
        /// </summary>
        /// <returns></returns>
        protected string DefineInitDate()
        {
            string strDate = DateTime.Now.Date.ToString("yyyy/MM/dd");

            return strDate;
        }
        #endregion

        protected bool Get_Cust_Data()
        {
            Customer cust = new Customer(g_user_id, g_lang);
            Message msg = new Message(g_user_id, g_lang);

            cust.cust_cd = txtCUST_CD.Text.Trim().ToUpper();
            cust.cust_sub_cd = txtCUST_CD1.Text.Trim().ToUpper();
            txtCUST_CD.Text = cust.cust_cd;
            txtCUST_CD1.Text = cust.cust_sub_cd;
            if (cust.GetCustomerDetail() == ComConst.SUCCEED)
            {
                lblCUST_DESC.Text = cust.cust_name;
                lblCUST_DESC.ToolTip = lblCUST_DESC.Text;
            }
            else
            {
                lblMsg.Text = msg.GetMessage("CUSTOMER_NOT_EXIST_ERR");
                lblMsg.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 発行ボタン
        /// </summary>
        protected void cmdIssue_Click(object sender, ImageClickEventArgs e)
        {
            Message msg = new Message(g_user_id, g_lang);
            ComLibrary com = new ComLibrary();
            Sales osp = new Sales(g_user_id, g_lang);
            DataSet ds = new DataSet();
            Customer cust = new Customer(g_user_id, g_lang);
            if (txtCUST_CD.Text != "")
            {
                if (txtCUST_CD1.Text == "")
                {
                    cust.cust_cd = txtCUST_CD.Text.ToUpper().Trim();
                    txtCUST_CD.Text = cust.cust_cd;
                    ds = cust.GetCustomerExistList();
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        lblMsg.Text = msg.GetMessage("CUSTOMER_NOT_EXIST_ERR");
                        lblMsg.ForeColor = Color.Red;
                        return;
                    }
                }
                else
                {
                    if (!Get_Cust_Data())
                    {
                        return;
                    }
                }
            }
            else
            {
                if (txtCUST_CD1.Text != "")
                {
                    lblCUST_DESC.Text = "";
                    lblMsg.Text = msg.GetMessage("INPUT_MANDATORY_ERR") + "(" + flbCUST_CD.Text + ")";
                    lblMsg.ForeColor = Color.Red;
                    return;
                }
            }
            lblSCH_NAME.Text = ddlSCH_ID.SelectedValue;
            lblSCH_NAME.ToolTip = lblSCH_NAME.Text;

            osp.cust_cd = txtCUST_CD.Text.ToUpper();
            osp.cust_sub_cd = txtCUST_CD1.Text.ToUpper();
            osp.sch_id = ddlSCH_ID.SelectedItem.Text.ToUpper();
            osp.beg_date = com.DateFormatToInt(txtDATE_BEG.Text, "yyyy/MM/dd");
            osp.end_date = com.DateFormatToInt(txtDATE_END.Text, "yyyy/MM/dd");
            ds = osp.GetOrdSORptList();
            if (ds == null)
            {
                lblMsg.Text = osp.strErr;
                lblMsg.ForeColor = Color.Red;
                return;
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblMsg.Text = msg.GetMessage("PRINT_DATA_NOT_EXIST_ERR");
                lblMsg.ForeColor = Color.Red;
                return;
            }
           

            try
            {
                GetSsrsReport();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.ToString();
                lblMsg.ForeColor = Color.Red;
                return;
            }

        }
        /// <summary>
        /// ReportViewer SSRS base setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SsrsBaseSetting(object sender, EventArgs e)
        {
            string _ReportServerUrl = WebConfigurationManager.ConnectionStrings["ReportServerUrl"].ConnectionString;
            string _ReportPath = WebConfigurationManager.ConnectionStrings["ReportRoot"].ConnectionString;
            string _ReportName = "OrdSORpt";

            ((ReportViewer)sender).ProcessingMode = ProcessingMode.Remote;
            ((ReportViewer)sender).Font.Name = "Verdana";
            ((ReportViewer)sender).Font.Size = 8;
            ((ReportViewer)sender).WaitMessageFont.Name = "Verdana";
            ((ReportViewer)sender).WaitMessageFont.Size = 14;
            ((ReportViewer)sender).Style["height"] = "100%;";
            ((ReportViewer)sender).Style["width"] = "100%;";
            IReportServerCredentials irsc = new SSRSReportCredentials();
            ((ReportViewer)sender).ServerReport.ReportServerCredentials = irsc;
            ((ReportViewer)sender).ServerReport.ReportServerUrl = new Uri(_ReportServerUrl);
            ((ReportViewer)sender).ServerReport.ReportPath = _ReportPath + "/" + _ReportName;
        }

        /// <summary>
        /// SSRS report create
        /// </summary>
        /// <param name="oRpt"></param>
        /// <param name="oDs"></param>
        private void GetSsrsReport()
        {
            ComLibrary com = new ComLibrary();

            try
            {
                // SSRS report POP window open
                //string rptsJsArr = "'" + rptver.ClientID + "'";
                //ClientScript.RegisterStartupScript(ClientScript.GetType(), "popscript", "<script>showRptPopWin(" + rptsJsArr + ");</script>");
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "popscript", "<script>jRptPopWin('" + rptver.ClientID + "','" + flblTitle.Text + "');</script>");

                List<ReportParameter> paras = new List<ReportParameter>();
                paras.Add(new ReportParameter("LANG", g_lang.ToString()));
                paras.Add(new ReportParameter("CUST_CD", txtCUST_CD.Text));
                paras.Add(new ReportParameter("CUST_SUB_CD", txtCUST_CD1.Text));
                paras.Add(new ReportParameter("SCH_ID", ddlSCH_ID.SelectedItem.Text));
                paras.Add(new ReportParameter("BEG_ORDER_RECV_DATE", com.DateFormatToInt(txtDATE_BEG.Text, "yyyy/MM/dd").ToString()));
                paras.Add(new ReportParameter("END_ORDER_RECV_DATE", com.DateFormatToInt(txtDATE_END.Text, "yyyy/MM/dd").ToString()));
                rptver.ServerReport.SetParameters(paras);
                rptver.ShowParameterPrompts = false; 

                //// test
                //SsrsOrdSORpt rpt = new SsrsOrdSORpt();
                //rpt.opener = this;
                //rpt.RPT_LANG = g_lang;
                //rpt.CUST_CD = txtCUST_CD.Text;
                //rpt.CUST_SUB_CD = txtCUST_CD1.Text;
                //rpt.SCH_ID = ddlSCH_ID.SelectedItem.Text;
                //rpt.BEG_ORDER_RECV_DATE = com.DateFormatToInt(txtDATE_BEG.Text, "yyyy/MM/dd");
                //rpt.END_ORDER_RECV_DATE = com.DateFormatToInt(txtDATE_END.Text, "yyyy/MM/dd");
                //rpt.CreatSsrsReport();
                
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.ToString();
                lblMsg.ForeColor = Color.Red;
                return;
            }

        }

        /// <summary>
        /// Back to Menu ボタン
        /// </summary>
        protected void imgReturn_Click(object sender, ImageClickEventArgs e)
        {
            //return Menu 
            string strUrl = "~/Default.aspx";
            Response.Redirect(strUrl);
        }


    }
}
