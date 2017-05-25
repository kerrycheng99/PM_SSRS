using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.Reporting.WebForms;
using PMClass;

namespace SSRSWebApp.Common.Ssrs
{
    public class SsrsOrdSORpt
    {
        
        public SsrsOrdSORpt() 
        {
            
        }

        #region : フィールド
        /// <summary>
        /// フィールド
        /// </summary>
        //protected global::Microsoft.Reporting.WebForms.ReportViewer rptver;
        protected Page _opener;
        protected int _RPT_LANG = 1;
        protected string _CUST_CD;
        protected string _CUST_SUB_CD;
        protected string _SCH_ID;
        protected int _BEG_ORDER_RECV_DATE;
        protected int _END_ORDER_RECV_DATE;
        #endregion
        #region : プロパティ
        ///<summary>
        /// プロパティ
        ///</summary>
        public Page opener
        {
            get { return _opener; }
            set { _opener = value; }
        }
        public int RPT_LANG { get { return _RPT_LANG; } set { _RPT_LANG = value; } }
        public string CUST_CD { get { return _CUST_CD; } set { _CUST_CD = value; } }
        public string CUST_SUB_CD { get { return _CUST_SUB_CD; } set { _CUST_SUB_CD = value; } }
        public string SCH_ID { get { return _SCH_ID; } set { _SCH_ID = value; } }
        public int BEG_ORDER_RECV_DATE { get { return _BEG_ORDER_RECV_DATE; } set { _BEG_ORDER_RECV_DATE = value; } }
        public int END_ORDER_RECV_DATE { get { return _END_ORDER_RECV_DATE; } set { _END_ORDER_RECV_DATE = value; } }
        #endregion

        /// <summary>
        /// Generate the SSRS report
        /// </summary>
        /// <returns></returns>
        public void CreatSsrsReport()
        {
            //int rtn = 0;

            //// Html setting
            //Panel pn = new Panel();
            //pn.ID = "rptContent";
            //pn.Visible = false;
            //_opener.FindControl("form1").Controls.Add(pn);
            

            // Report POP window
            _opener.ClientScript.RegisterStartupScript(_opener.ClientScript.GetType(), "popscript", "<script>showRptPopWin();</script>");
            Panel pn = (Panel)_opener.FindControl("rptContent");

            // ReportViewer and SSRS setting
            string _ReportServerUrl = WebConfigurationManager.ConnectionStrings["ReportServerUrl"].ConnectionString;
            string _ReportPath = WebConfigurationManager.ConnectionStrings["ReportRoot"].ConnectionString;
            string _ReportName = "OrdSORpt";
            ReportViewer rptver = new ReportViewer();
            pn.Controls.Add(rptver);
            //rptver.Load += new System.EventHandler(this.SsrsBaseSetting); 
            //ReportViewer rptver = (ReportViewer)_opener.FindControl("rptver");
            rptver.ProcessingMode = ProcessingMode.Remote;
            rptver.Font.Name = "Verdana";
            rptver.Font.Size = 8;
            rptver.WaitMessageFont.Name = "Verdana";
            rptver.WaitMessageFont.Size = 14;
            rptver.Style["style"] = "height:100%;width:100%;";
            IReportServerCredentials irsc = new SSRSReportCredentials();
            rptver.ServerReport.ReportServerCredentials = irsc;
            rptver.ServerReport.ReportServerUrl = new Uri(_ReportServerUrl);
            rptver.ServerReport.ReportPath = _ReportPath + "/" + _ReportName;

            List<ReportParameter> paras = new List<ReportParameter>();
            paras.Add(new ReportParameter("LANG", _RPT_LANG.ToString()));
            paras.Add(new ReportParameter("CUST_CD", _CUST_CD));
            paras.Add(new ReportParameter("CUST_SUB_CD", _CUST_SUB_CD));
            paras.Add(new ReportParameter("SCH_ID", _SCH_ID));
            paras.Add(new ReportParameter("BEG_ORDER_RECV_DATE", _BEG_ORDER_RECV_DATE.ToString()));
            paras.Add(new ReportParameter("END_ORDER_RECV_DATE", _END_ORDER_RECV_DATE.ToString()));
            rptver.ServerReport.SetParameters(paras);
            rptver.ShowParameterPrompts = false;

        }

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
    }
}