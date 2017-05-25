using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Drawing;
using System.Data;

using System.Text;
using System.Web.Configuration;
using Microsoft.Reporting.WebForms;
using PMClass;
using SSRSWebApp.Common.Ssrs;

namespace SSRSWebApp.Ord.OrdShipInstSlipRpt
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

            SaveGridData();
            Add_Search();
            if (!IsPostBack)
            {
                // SSRS base setting
                this.rptver1.Load += new System.EventHandler(this.SsrsBaseSetting);
                this.rptver2.Load += new System.EventHandler(this.SsrsBaseSetting);
                this.rptver3.Load += new System.EventHandler(this.SsrsBaseSetting);
                this.rptver4.Load += new System.EventHandler(this.SsrsBaseSetting); 

                // 画面編集
                this.txtDATE_BEG.Text = DateTime.Now.Date.AddDays(1 - DateTime.Now.Day).ToString("yyyy/MM/dd");
                this.txtDATE_END.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");
                txtCUST_CD.Focus();
                Init_Label();
            }
            else
            {
                if (ViewState["GridData"] != null)
                {
                    EditGridView((DataTable)ViewState["GridData"]);
                }
            }

            lblMsg.Text = "";
        }

        protected void Init_Label()
        {
            Dictionary dic = new Dictionary(g_user_id, g_lang);
            dic.screen_id = "OrdShipInstSlipRpt_frmMain";
            DataSet ds = dic.GetLabelOfScreenList();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    switch (row["CONTROL_ID"].ToString())
                    {
                        // ラベル
                        case "flblTitle": flblTitle.Text = row["ITEM_DESC"].ToString(); break;
                        case "flblCUST_CD": flblCUST_CD.Text = row["ITEM_DESC"].ToString(); break;
                        case "flblSCH_SHIP_DATE": flblSCH_SHIP_DATE.Text = row["ITEM_DESC"].ToString(); break;
                        case "chkReprint": chkReprint.Text = row["ITEM_DESC"].ToString(); break;
                        case "chkAll": chkAll.Text = row["ITEM_DESC"].ToString(); break;
                        //Grid Head
                        case "dgv_ITEM1": dgvDetail.Columns[2].HeaderText = row["ITEM_DESC"].ToString(); break;
                        case "dgv_ITEM2": dgvDetail.Columns[3].HeaderText = row["ITEM_DESC"].ToString(); break;
                        case "dgv_ITEM3": dgvDetail.Columns[4].HeaderText = row["ITEM_DESC"].ToString(); break;
                        case "dgv_ITEM4": dgvDetail.Columns[5].HeaderText = row["ITEM_DESC"].ToString(); break;
                        case "dgv_ITEM5": dgvDetail.Columns[6].HeaderText = row["ITEM_DESC"].ToString(); break;
                    }
                }
            }
            //
            // img系ボタンイメージの編集     －      言語対応とSwapImage
            //
            switch (g_lang)
            {
                case 1:
                    cmdSearch.ImageUrl = "../../Contents/Image/BackGround/btn-search1-1.jpg";
                    cmdSearch.Attributes["onmouseover"] = "MM_swapImage('" + cmdSearch.ClientID + "','','../../Contents/Image/BackGround/btn-search2-1.jpg',1);";
                    cmdSearch.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    cmdRelease.ImageUrl = "../../Contents/Image/BackGround/btn-Issue1-1.jpg";
                    cmdRelease.Attributes["onmouseover"] = "MM_swapImage('" + cmdRelease.ClientID + "','','../../Contents/Image/BackGround/btn-Issue2-1.jpg',1);";
                    cmdRelease.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    break;
                case 2:
                    cmdSearch.ImageUrl = "../../Contents/Image/BackGround/btn-search1-2.jpg";
                    cmdSearch.Attributes["onmouseover"] = "MM_swapImage('" + cmdSearch.ClientID + "','','../../Contents/Image/BackGround/btn-search2-2.jpg',1);";
                    cmdSearch.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    cmdRelease.ImageUrl = "../../Contents/Image/BackGround/btn-Issue1-2.jpg";
                    cmdRelease.Attributes["onmouseover"] = "MM_swapImage('" + cmdRelease.ClientID + "','','../../Contents/Image/BackGround/btn-Issue2-2.jpg',1);";
                    cmdRelease.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    break;
                case 3:
                    cmdSearch.ImageUrl = "../../Contents/Image/BackGround/btn-search1-3.jpg";
                    cmdSearch.Attributes["onmouseover"] = "MM_swapImage('" + cmdSearch.ClientID + "','','../../Contents/Image/BackGround/btn-search2-3.jpg',1);";
                    cmdSearch.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    cmdRelease.ImageUrl = "../../Contents/Image/BackGround/btn-Issue1-3.jpg";
                    cmdRelease.Attributes["onmouseover"] = "MM_swapImage('" + cmdRelease.ClientID + "','','../../Contents/Image/BackGround/btn-Issue2-3.jpg',1);";
                    cmdRelease.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    break;
                case 4:
                    cmdSearch.ImageUrl = "../../Contents/Image/BackGround/btn-search1-4.jpg";
                    cmdSearch.Attributes["onmouseover"] = "MM_swapImage('" + cmdSearch.ClientID + "','','../../Contents/Image/BackGround/btn-search2-4.jpg',1);";
                    cmdSearch.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    cmdRelease.ImageUrl = "../../Contents/Image/BackGround/btn-Issue1-4.jpg";
                    cmdRelease.Attributes["onmouseover"] = "MM_swapImage('" + cmdRelease.ClientID + "','','../../Contents/Image/BackGround/btn-Issue2-4.jpg',1);";
                    cmdRelease.Attributes["onmouseout"] = "MM_swapImgRestore();";
                    break;
            }
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
            arrObj.Add(txtCUST_SUB_CD);
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

        protected void EditGridView(DataTable dt)
        {
            ComLibrary com = new ComLibrary();
            dgvDetail.DataSource = dt;
            dgvDetail.DataBind();
            int j;
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                j = dgvDetail.Rows[i].DataItemIndex;
                ((CheckBox)dgvDetail.Rows[i].Cells[0].FindControl("chkSel")).Checked = com.IntToBool(com.StringToInt(dt.Rows[j]["CHK"].ToString()));
            }
        }

        protected void SaveGridData()
        {
            if (dgvDetail.Rows.Count != 0)
            {
                int j;
                ComLibrary com = new ComLibrary();
                DataTable dt = (DataTable)ViewState["GridData"];
                if (dt.Columns["CHK"] == null)
                {
                    dt.Columns.Add("CHK");
                }
                for (int i = 0; i < dgvDetail.Rows.Count; i++)
                {
                    j = dgvDetail.Rows[i].DataItemIndex;
                    dt.Rows[j]["CHK"] = com.BoolToInt(((CheckBox)dgvDetail.Rows[i].Cells[0].FindControl("chkSel")).Checked);
                }
                ViewState["GridData"] = dt;
            }
        }

        protected bool Get_Cust_Data()
        {
            Customer cust = new Customer(g_user_id, g_lang);
            Message msg = new Message(g_user_id, g_lang);

            cust.cust_cd = txtCUST_CD.Text.Trim().ToUpper();
            cust.cust_sub_cd = txtCUST_SUB_CD.Text.Trim().ToUpper();
            txtCUST_CD.Text = cust.cust_cd;
            txtCUST_SUB_CD.Text = cust.cust_sub_cd;
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

        protected void chkReprint_CheckedChanged(object sender, EventArgs e)
        {
            dgvDetail.DataSource = null;
            dgvDetail.DataBind();
            chkAll.Checked = false;
            ViewState["GridEditData"] = null;
            ViewState["GridData"] = null;
        }

        protected void dgvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            chkAll.Checked = false;
            ViewState["GridEditData"] = null;
            dgvDetail.PageIndex = e.NewPageIndex;
            EditGridView((DataTable)ViewState["GridData"]);
        }

        protected void chkALL_SEL_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewState["GridData"] != null)
            {
                DataTable dt = (DataTable)ViewState["GridData"];
                string chk;
                if (chkAll.Checked)
                {
                    chk = "1";
                }
                else
                {
                    chk = "0";
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["CHK"] = chk;
                }
                for (int i = 0; i < dgvDetail.Rows.Count; i++)
                {
                    ((CheckBox)dgvDetail.Rows[i].Cells[0].FindControl("chkSEL")).Checked = chkAll.Checked;
                }
            }
        }
        protected void cmdSearch_Click(object sender, ImageClickEventArgs e)
        {
            Message msg = new Message(g_user_id, g_lang);
            ComLibrary com = new ComLibrary();
            Ship shp = new Ship(g_user_id, g_lang);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            Customer cust = new Customer(g_user_id, g_lang);

            dgvDetail.DataSource = null;
            dgvDetail.DataBind();
            chkAll.Checked = false;
            dgvDetail.PageIndex = 0;
            ViewState["GridData"] = null;

            if (txtCUST_CD.Text != "")
            {
                if (txtCUST_SUB_CD.Text == "")
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
                if (txtCUST_SUB_CD.Text != "")
                {
                    lblCUST_DESC.Text = "";
                    lblMsg.Text = msg.GetMessage("INPUT_MANDATORY_ERR") + "(" + flblCUST_CD.Text + ")";
                    lblMsg.ForeColor = Color.Red;
                    return;
                }
            }

            //if (!ChkCust(txtCUST_CD, txtCUST_SUB_CD, lblCUST_NAME, flblCUST_CD))
            //{
            //    return;
            //}
            shp.cust_cd = txtCUST_CD.Text;
            shp.cust_sub_cd = txtCUST_SUB_CD.Text;
            shp.sch_ship_date_beg = com.DateFormatToInt(txtDATE_BEG.Text, "yyyy/MM/dd");
            shp.sch_ship_date_end = com.DateFormatToInt(txtDATE_END.Text, "yyyy/MM/dd");
            shp.print_flag = com.BoolToInt(chkReprint.Checked);
            ds = shp.Get_ShipInstSlipList();
            if (ds == null)
            {
                lblMsg.Text = shp.strErr;
                lblMsg.ForeColor = Color.Red;
                return;
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblMsg.Text = msg.GetMessage("DATA_NOT_EXIST_ERR");
                lblMsg.ForeColor = Color.Red;
                return;
            }
            dt = ds.Tables[0];
            if (dt.Columns["CHK"] == null)
            {
                dt.Columns.Add("CHK");
            }
            ViewState["GridData"] = dt;
            EditGridView(ds.Tables[0]);
        }

        /// <summary>
        /// 発行ボタン
        /// </summary>
        protected void cmdIssue_Click(object sender, ImageClickEventArgs e)
        {
            ComLibrary com = new ComLibrary();
            Message msg = new Message(g_user_id, g_lang);
            Ship ship = new Ship(g_user_id, g_lang);
            DataTable dt = (DataTable)ViewState["GridData"];
            bool flag = false;

            if (dt == null)
            {
                lblMsg.Text = msg.GetMessage("PRINT_DATA_NOT_EXIST_ERR");
                lblMsg.ForeColor = Color.Red;
                return;
            }

            // Get SSRS report conditions
            int print_flag = com.BoolToInt(chkReprint.Checked);
            ArrayList ship_no_lang1 = new ArrayList();
            ArrayList ship_no_lang2 = new ArrayList();
            ArrayList ship_no_lang3 = new ArrayList();
            ArrayList ship_no_lang4 = new ArrayList();
            DataSet ds = new DataSet();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["CHK"].ToString() == "1")
                {
                    flag = true;
                    ship.ship_no = dt.Rows[i]["SHIP_NO"].ToString();
                    ship.print_flag = com.BoolToInt(chkReprint.Checked);
                    ds = ship.Get_ShipInstSlipRptList();
                    if (ds == null)
                    {
                        lblMsg.Text = ship.strErr;
                        lblMsg.ForeColor = Color.Red;
                        return;
                    }
                    switch (ds.Tables[0].Rows[0]["LANG"].ToString())
                    {
                        case "1": ship_no_lang1.Add(dt.Rows[i]["SHIP_NO"].ToString()); break;
                        case "2": ship_no_lang2.Add(dt.Rows[i]["SHIP_NO"].ToString()); break;
                        case "3": ship_no_lang3.Add(dt.Rows[i]["SHIP_NO"].ToString()); break;
                        case "4": ship_no_lang4.Add(dt.Rows[i]["SHIP_NO"].ToString()); break;
                    }
                }
            }

            ship_no_lang1.TrimToSize();
            ship_no_lang2.TrimToSize();
            ship_no_lang3.TrimToSize();
            ship_no_lang4.TrimToSize();

            if (!flag)
            {
                lblMsg.Text = msg.GetMessage("NO_CHECK_ERR");
                lblMsg.ForeColor = Color.Red;
                return;
            }
            if (ship_no_lang1.Count == 0 && ship_no_lang2.Count == 0 && ship_no_lang3.Count == 0 && ship_no_lang4.Count == 0)
            {
                lblMsg.Text = msg.GetMessage("PRINT_DATA_NOT_EXIST_ERR");
                lblMsg.ForeColor = Color.Red;
                return;
            }

            try
            {
                GetSsrsReport(print_flag, ship_no_lang1, ship_no_lang2, ship_no_lang3, ship_no_lang4);
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
            string _ReportName = "OrdShipInstSlipRpt";

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
        private void GetSsrsReport(int p_print_flag, ArrayList p_ship_no1, ArrayList p_ship_no2, ArrayList p_ship_no3, ArrayList p_ship_no4)
        {
            ComLibrary com = new ComLibrary();

            try
            {
                                
                List<ReportParameter> paras = new List<ReportParameter>();
                if (p_ship_no1.Count > 0)
                {
                    paras.Add(new ReportParameter("LANG", 1.ToString()));
                    paras.Add(new ReportParameter("SLIP_PRINT_FLAG", p_print_flag.ToString()));
                    paras.Add(new ReportParameter("SHIP_NO", (string[])p_ship_no1.ToArray(typeof(string))));
                    rptver1.ServerReport.SetParameters(paras);
                    rptver1.ShowParameterPrompts = false;
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "popscript1", "<script>jRptPopWin('" + rptver1.ClientID + "','" + flblTitle.Text + "_1');</script>");
                }
                if (p_ship_no2.Count > 0)
                {
                    paras = new List<ReportParameter>();
                    paras.Add(new ReportParameter("LANG", 2.ToString()));
                    paras.Add(new ReportParameter("SLIP_PRINT_FLAG", p_print_flag.ToString()));
                    paras.Add(new ReportParameter("SHIP_NO", (string[])p_ship_no2.ToArray(typeof(string))));
                    rptver2.ServerReport.SetParameters(paras);
                    rptver2.ShowParameterPrompts = false;
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "popscript2", "<script>jRptPopWin('" + rptver2.ClientID + "','" + flblTitle.Text + "_2');</script>");
                }
                if (p_ship_no3.Count > 0)
                {
                    paras = new List<ReportParameter>();
                    paras.Add(new ReportParameter("LANG", 3.ToString()));
                    paras.Add(new ReportParameter("SLIP_PRINT_FLAG", p_print_flag.ToString()));
                    paras.Add(new ReportParameter("SHIP_NO", (string[])p_ship_no3.ToArray(typeof(string))));
                    rptver3.ServerReport.SetParameters(paras);
                    rptver3.ShowParameterPrompts = false;
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "popscript3", "<script>jRptPopWin('" + rptver3.ClientID + "','" + flblTitle.Text + "_3');</script>");
                }
                //if (p_ship_no4.Count > 0)
                if (p_ship_no1.Count > 0)//test multi report
                {
                    paras = new List<ReportParameter>();
                    paras.Add(new ReportParameter("LANG", 4.ToString()));
                    paras.Add(new ReportParameter("SLIP_PRINT_FLAG", p_print_flag.ToString()));
                    paras.Add(new ReportParameter("SHIP_NO", (string[])p_ship_no1.ToArray(typeof(string))));
                    rptver4.ServerReport.SetParameters(paras);
                    rptver4.ShowParameterPrompts = false;
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "popscript4", "<script>jRptPopWin('" + rptver4.ClientID + "','" + flblTitle.Text + "_4');</script>");
                }
                
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
