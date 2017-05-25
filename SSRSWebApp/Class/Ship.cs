using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Data;

namespace PMClass
{
    public class Ship
    {
        #region : コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Ship()
        {
            try
            {
                _db_type = WebConfigurationManager.AppSettings["db_type"];
            }
            catch { }
        }
        public Ship(string p_user_id, int p_lang)
        {
            _chg_user_id = p_user_id;
            _lang = p_lang;
            try
            {
                _db_type = WebConfigurationManager.AppSettings["db_type"];
            }
            catch { }
        }
        #endregion

        #region : フィールド
        /// <summary>
        /// フィールド
        /// </summary>
        protected string _db_type = "";
        protected int _lang = 1;
        protected string _cust_cd = "";
        protected string _cust_sub_cd = "";
        protected string _cust_name = "";
        protected string _ship_to_cd = "";
        protected string _ship_to_sub_cd = "";
        protected string _ship_to_name = "";
        protected string _order_no = "";
        protected string _cust_order_no = "";
        protected string _item_no = "";
        protected string _item_desc = "";
        protected int _order_qty = 0;
        protected int _ship_qty = 0;
        protected int _actual_ship_qty = 0;
        protected double _alloc_qty = 0;
        protected int _ship_req_date = 0;
        protected string _joc_cd = "";
        protected string _sch_id = "";
        protected string _ship_whs = "";
        protected int _order_line_no = 0;
        protected int _ship_cnt = 0;
        protected int _sch_ship_date_beg = 0;
        protected int _sch_ship_date_end = 0;
        protected int _alloc_status = 0;
        protected int _partial_alloc_flag = 0;
        protected string _ship_no = "";
        protected int _actual_ship_date = 0;
        protected int _actual_ship_date_beg = 0;
        protected int _actual_ship_date_end = 0;
        //OrdReturn
        protected int _order_flag = 0;
        protected int _return_date = 0;
        protected int _return_qty = 0;
        protected string _return_whs = "";
        protected string _return_reason = "";
        protected int _reopen_flag = 0;
        protected int _ship_seq = 0;
        protected string _lot_no = "";
        protected string _location = "";
        protected double _inv_bal = 0;
        protected string _return_no = "";

        protected int _print_flag = 0;

        protected DateTime _entry_date;
        protected DateTime _chg_date;
        protected string _chg_pgm = "";
        protected string _chg_user_id = "";
        protected int _update_cntr = 0;
        protected string _dbmsg = "";
        protected string _errmsg = "";
        protected string _strErr = "";
        protected int _errcode = 0;
        protected int _sqlcode = 0;
        protected string _proc_name = "";
        //ADD UBIQ-LIU 2010/06/18
        protected int _flag;
        protected string _slip_no = "";
        protected double _act_price;

        public int WILL_SHIP_QTY = 0;
		//ADD BY UBIQ-LIU 2015/05/07
		protected double _return_prc = 0;
		protected string _return_cur = string.Empty;
        #endregion

        #region : プロパティ
        ///<summary>
        /// プロパティ
        ///</summary>
        public int lang { get { return _lang; } set { _lang = value; } }
        public string cust_cd { get { return _cust_cd; } set { _cust_cd = value; } }
        public string cust_sub_cd { get { return _cust_sub_cd; } set { _cust_sub_cd = value; } }
        public string cust_name { get { return _cust_name; } set { _cust_name = value; } }
        public string ship_to_cd { get { return _ship_to_cd; } set { _ship_to_cd = value; } }
        public string ship_to_sub_cd { get { return _ship_to_sub_cd; } set { _ship_to_sub_cd = value; } }
        public string ship_to_name { get { return _ship_to_name; } set { _ship_to_name = value; } }
        public string order_no { get { return _order_no; } set { _order_no = value; } }
        public string cust_order_no { get { return _cust_order_no; } set { _cust_order_no = value; } }
        public string item_no { get { return _item_no; } set { _item_no = value; } }
        public string item_desc { get { return _item_desc; } set { _item_desc = value; } }
        public int order_qty { get { return _order_qty; } set { _order_qty = value; } }
        public int ship_qty { get { return _ship_qty; } set { _ship_qty = value; } }
        public int actual_ship_qty { get { return _actual_ship_qty; } set { _actual_ship_qty = value; } }
        public double alloc_qty { get { return _alloc_qty; } set { _alloc_qty = value; } }
        public int ship_req_date { get { return _ship_req_date; } set { _ship_req_date = value; } }
        public string joc_cd { get { return _joc_cd; } set { _joc_cd = value; } }
        public string sch_id { get { return _sch_id; } set { _sch_id = value; } }
        public string ship_whs { get { return _ship_whs; } set { _ship_whs = value; } }
        public int order_line_no { get { return _order_line_no; } set { _order_line_no = value; } }
        public int ship_cnt { get { return _ship_cnt; } set { _ship_cnt = value; } }
        public int sch_ship_date_beg { get { return _sch_ship_date_beg; } set { _sch_ship_date_beg = value; } }
        public int sch_ship_date_end { get { return _sch_ship_date_end; } set { _sch_ship_date_end = value; } }
        public int alloc_status { get { return _alloc_status; } set { _alloc_status = value; } }
        public int partial_alloc_flag { get { return _partial_alloc_flag; } set { _partial_alloc_flag = value; } }
        public int order_flag { get { return _order_flag; } set { _order_flag = value; } }
        public int return_date { get { return _return_date; } set { _return_date = value; } }
        public int return_qty { get { return _return_qty; } set { _return_qty = value; } }
        public string return_whs { get { return _return_whs; } set { _return_whs = value; } }
        public string return_reason { get { return _return_reason; } set { _return_reason = value; } }
        public int reopen_flag { get { return _reopen_flag; } set { _reopen_flag = value; } }
        public string ship_no { get { return _ship_no; } set { _ship_no = value; } }
        public int actual_ship_date { get { return _actual_ship_date; } set { _actual_ship_date = value; } }
        public string return_no { get { return _return_no; } set { _return_no = value; } }
        public int actual_ship_date_beg { get { return _actual_ship_date_beg; } set { _actual_ship_date_beg = value; } }
        public int actual_ship_date_end { get { return _actual_ship_date_end; } set { _actual_ship_date_end = value; } }

        public int ship_seq { get { return _ship_seq; } set { _ship_seq = value; } }
        public string lot_no { get { return _lot_no; } set { _lot_no = value; } }
        public string location { get { return _location; } set { _location = value; } }
        public double inv_bal { get { return _inv_bal; } set { _inv_bal = value; } }
        public int print_flag { get { return _print_flag; } set { _print_flag = value; } }

        public int flag { get { return _flag; } set { _flag = value; } }
        public double act_price { get { return _act_price; } set { _act_price = value; } }
        public string slip_no { get { return _slip_no; } set { _slip_no = value; } }
		//ADD BY UBIQ-LIU 2015/05/07
		public double return_prc { get { return _return_prc; } set { _return_prc = value; } }
		public string return_cur { get { return _return_cur; } set { _return_cur = value; } }

        public DateTime entry_date { get { return _entry_date; } set { _entry_date = value; } }
        public DateTime chg_date { get { return _chg_date; } set { _chg_date = value; } }
        public string chg_user_id { get { return _chg_user_id; } set { _chg_user_id = value; } }
        public string chg_pgm { get { return _chg_pgm; } set { _chg_pgm = value; } }
        public int update_cntr { get { return _update_cntr; } set { _update_cntr = value; } }
        public string dbmsg { get { return _dbmsg; } set { _dbmsg = value; } }
        public string strErr { get { return _strErr; } set { _strErr = value; } }
        #endregion

        /// <summary>
        /// 出荷引当Main Dataの取得
        /// 
        /// 使用画面：OrdShipInst
        /// </summary>
        public DataSet GetShipInstList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT                                                                                  ");
            strSQL.Append(" SO.CUST_CD+'-'+SO.CUST_SUB_CD CUST_CD,	SO.SHIP_TO_CD+'-'+SO.SHIP_TO_SUB_CD SHIP_TO_CD,	");
            strSQL.Append(" SO.ORDER_NO,        SO.CUST_ORDER_NO,   SOD.ITEM_NO,        SOD.ORDER_QTY,              ");
            strSQL.Append(" SOD.ACTUAL_SHIP_QTY,SS.ALLOC_QTY,       SOD.ACTUAL_SHIP_QTY,SOD.SHIP_REQ_DATE,          ");
            strSQL.Append(" SOD.SHIP_REQ_DATE,	SOD.JOC_CD,		    SOD.SHIP_WHS,	    SOD.ORDER_LINE_NO,		    ");
            //strSQL.Append(" SOD.SHIP_CNT,	    C1.CUST_NAME as CUST_NAME,		C2.CUST_NAME AS SHIP_TO_NAME,	    "); //Del Ubiq-Sai 10.09.30
            strSQL.Append(" SS.SHIP_SEQ SHIP_CNT,C1.CUST_NAME as CUST_NAME,		C2.CUST_NAME AS SHIP_TO_NAME,	    "); //Add Ubiq-Sai 10.09.30
            //strSQL.Append(" I.ITEM_DESC,		I.SCH_ID, SP.DATA_CHAR SCH_DESC,	SUM(INV.INV_BAL) - SUM(INV.ALLOC_QTY) WILL_SHIP_QTY,    "); //Del 2012.05.21 Ubiq-Sai
            strSQL.Append(" I.ITEM_DESC,		I.SCH_ID, SP.DATA_CHAR SCH_DESC,	INV.WILL_SHIP_QTY,              "); //Add 2012.05.21 Ubiq-Sai
            //strSQL.Append(" SUM(INV.INV_BAL) INV_BAL,(SOD.ORDER_QTY-SOD.ACTUAL_SHIP_QTY) UNSHIP_QTY               "); //Del 2012.05.21 Ubiq-Sai
            strSQL.Append(" INV.INV_BAL,        (SOD.ORDER_QTY-SOD.ACTUAL_SHIP_QTY) UNSHIP_QTY                      "); //Add 2012.05.21 Ubiq-Sai
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM SALES_ORDER SO, SALES_ORDER_DETAIL SOD,SHIPPING_SCHEDULE SS,                   ");
                strSQL.Append(" ITEM_MASTER I ,CUSTOMER_MASTER C1 ,CUSTOMER_MASTER C2,INVENTORY_DETAIL INV          ");
                strSQL.Append(" WHERE SO.ORDER_NO     = SOD.ORDER_NO            ");
                strSQL.Append(" AND SOD.ORDER_NO      = SS.ORDER_NO             ");
                strSQL.Append(" AND SOD.ORDER_NO      = SS.ORDER_NO             ");
                //strSQL.Append(" AND SOD.SHIP_CNT          = SS.SHIP_SEQ         ");   //Del Ubiq-Sai 10.09.30
                strSQL.Append(" AND SS.ORDER_STATUS       < 90                ");
                strSQL.Append(" AND SO.CUST_CD            = C1.CUST_CD(+)       ");
                strSQL.Append(" AND SO.CUST_SUB_CD        = C1.CUST_SUB_CD(+)   ");
                strSQL.Append(" AND SO.SHIP_TO_CD         = C2.CUST_CD(+)       ");
                strSQL.Append(" AND SO.SHIP_TO_SUB_CD     = C2.SHIP_TO_SUB_CD(+)");
                strSQL.Append(" AND SOD.ITEM_NO           = I.ITEM_NO(+)        ");
                strSQL.Append(" AND SOD.ITEM_NO           = INV.ITEM_NO(+)      ");
                strSQL.Append(" AND SOD.SHIP_WHS          = INV.WHS_CD(+)       ");
                strSQL.Append(" AND INV.INV_YM             = 0                  ");
                strSQL.Append(" AND INV.INV_WIP_TYPE       = 0                  ");
                strSQL.Append(" AND INV.INV_TYPE           = 0                  ");

                strSQL.Append(" AND SO.PO_TYPE = 0                      ");     //Add 10.08.19 Ubiq-Sai
                strSQL.Append(" AND SO.ORDER_STATUS       < 90          ");
                strSQL.Append(" AND SOD.ORDER_STATUS      < 90          ");

                db.DbParametersClear();
                if (alloc_status == 0)
                {
                    strSQL.Append(" AND SOD.ALLOC_STATUS <> 1 ");
                }
                if (order_no != "")
                {
                    strSQL.Append(" AND SO.ORDER_NO = :ORDER_NO ");
                    db.DbPsetString("ORDER_NO", _order_no);
                }
                if (cust_order_no != "")
                {
                    strSQL.Append(" AND SO.CUST_ORDER_NO = :CUST_ORDER_NO ");
                    db.DbPsetString("CUST_ORDER_NO", _cust_order_no);
                }
                if (cust_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_CD              = @CUST_CD                                  ");
                    db.DbPsetString("@CUST_CD", _cust_cd);
                }
                if (cust_sub_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_SUB_CD          = @CUST_SUB_CD                              ");
                    db.DbPsetString("@CUST_SUB_CD", _cust_sub_cd);
                }
                if (ship_to_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_CD           = @SHIP_TO_CD                               ");
                    db.DbPsetString("@SHIP_TO_CD", _ship_to_cd);
                }
                if (ship_to_sub_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_SUB_CD       = @SHIP_TO_SUB_CD                           ");
                    db.DbPsetString("@SHIP_TO_SUB_CD", _ship_to_sub_cd);
                }
                //if (cust_cd != "")
                //{
                //    strSQL.Append(" AND SO.CUST_CD = :CUST_CD           ");
                //    strSQL.Append(" AND SO.CUST_SUB_CD = :CUST_SUB_CD   ");
                //    db.DbPsetString("CUST_CD", _cust_cd);
                //    db.DbPsetString("CUST_SUB_CD", _cust_sub_cd);
                //}
                //if (ship_to_cd != "")
                //{
                //    strSQL.Append(" AND SO.SHIP_TO_CD = :SHIP_TO_CD         ");
                //    strSQL.Append(" AND SO.SHIP_TO_SUB_CD = :SHIP_TO_SUB_CD ");
                //    db.DbPsetString("SHIP_TO_CD", _ship_to_cd);
                //    db.DbPsetString("SHIP_TO_SUB_CD", _ship_to_sub_cd);
                //}
                if (item_no != "")
                {
                    strSQL.Append(" AND SOD.ITEM_NO = :ITEM_NO ");
                    db.DbPsetString("ITEM_NO", _item_no);
                }
                if (sch_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SOD.SHIP_REQ_DATE >= :SCH_SHIP_DATE_BEG ");
                    db.DbPsetInt("SCH_SHIP_DATE_BEG", _sch_ship_date_beg);
                }
                if (sch_ship_date_end != 0)
                {
                    strSQL.Append(" AND SOD.SHIP_REQ_DATE <= :SCH_SHIP_DATE_END ");
                    db.DbPsetInt("SCH_SHIP_DATE_END", _sch_ship_date_end);
                }
            }
            else
            {
                db.DbParametersClear();

                strSQL.Append(" FROM SALES_ORDER SO                                                                 ");
                //strSQL.Append(" LEFT OUTER JOIN SALES_ORDER_DETAIL SOD ON SO.ORDER_NO = SOD.ORDER_NO              ");
                strSQL.Append(" INNER JOIN SALES_ORDER_DETAIL SOD ON SO.ORDER_NO = SOD.ORDER_NO                     ");
                strSQL.Append(" AND SOD.ORDER_STATUS      < 90                                                      ");
                strSQL.Append(" LEFT OUTER JOIN SHIPPING_SCHEDULE SS ON SOD.ORDER_NO = SS.ORDER_NO                  ");
                strSQL.Append(" AND SOD.ORDER_LINE_NO = SS.ORDER_LINE_NO                                            ");
                //strSQL.Append(" AND SOD.SHIP_CNT      = SS.SHIP_SEQ                                               ");   //Del Ubiq-Sai 10.09.30
                strSQL.Append(" AND SS.ORDER_STATUS   < 90                                                          ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER C1 ON SO.CUST_CD = C1.CUST_CD                       ");
                strSQL.Append(" AND SO.CUST_SUB_CD    = C1.CUST_SUB_CD                                              ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER C2 ON SO.SHIP_TO_CD = C2.CUST_CD                    ");
                strSQL.Append(" AND SO.SHIP_TO_SUB_CD    = C2.CUST_SUB_CD                                           ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON SOD.ITEM_NO = I.ITEM_NO                            ");

                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER SP ON SP.KEY01       = 'SCH_ID'                    ");
                strSQL.Append(" AND SP.KEY02                = I.SCH_ID                                              ");

                //strSQL.Append(" LEFT OUTER JOIN INVENTORY_DETAIL INV ON SOD.ITEM_NO = INV.ITEM_NO                 ");     //Del 2012.05.21 Ubiq-Sai
                //Add 2012.05.21 Ubiq-Sai Start
                strSQL.Append(" LEFT OUTER JOIN                                                                     ");
                strSQL.Append(" ( SELECT INV.WHS_CD, INV.ITEM_NO, INV.JOC_CD,                                       ");
                strSQL.Append("          SUM(INV.INV_BAL) INV_BAL, SUM(INV.INV_BAL - INV.ALLOC_QTY) WILL_SHIP_QTY   ");
                strSQL.Append("     FROM INVENTORY_DETAIL INV                                                       ");
                strSQL.Append("    WHERE INV.INV_YM       = 0                                                       ");
                strSQL.Append("      AND INV.INV_WIP_TYPE = 0                                                       ");
                strSQL.Append("      AND INV.INV_TYPE     = 0                                                       ");
                strSQL.Append("   GROUP BY INV.WHS_CD, INV.ITEM_NO, INV.JOC_CD                                      ");
                strSQL.Append(" ) INV                                                                               ");
                //Add 2012.05.21 Ubiq-Sai End

                strSQL.Append(" ON  SOD.ITEM_NO     = INV.ITEM_NO                                                   ");
                strSQL.Append(" AND SOD.SHIP_WHS    = INV.WHS_CD                                                    ");
                //strSQL.Append(" AND INV.INV_YM       = 0                                                          ");   //Del 2012.05.21 Ubiq-Sai
                //strSQL.Append(" AND INV.INV_WIP_TYPE = 0                                                          ");   //Del 2012.05.21 Ubiq-Sai
                //strSQL.Append(" AND INV.INV_TYPE     = 0                                                          ");   //Del 2012.05.21 Ubiq-Sai
                strSQL.Append(" AND CASE WHEN I.PO_TYPE = '4' THEN INV.JOC_CD ELSE '1' END                          ");
                strSQL.Append(" = CASE WHEN I.PO_TYPE = '4' THEN SOD.JOC_CD ELSE '1' END                            ");
                strSQL.Append(" WHERE SO.ORDER_STATUS < 90                                                          ");
                strSQL.Append(" AND SO.PO_TYPE = 0                                                                  ");   //Add 10.08.19 Ubiq-Sai
                if (order_no != "")
                {
                    strSQL.Append(" AND SO.ORDER_NO = @ORDER_NO ");
                    db.DbPsetString("@ORDER_NO", _order_no);
                }
                if (cust_order_no != "")
                {
                    strSQL.Append(" AND SO.CUST_ORDER_NO = @CUST_ORDER_NO ");
                    db.DbPsetString("@CUST_ORDER_NO", _cust_order_no);
                }
                if (cust_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_CD              = @CUST_CD                                  ");
                    db.DbPsetString("@CUST_CD", _cust_cd);
                }
                if (cust_sub_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_SUB_CD          = @CUST_SUB_CD                              ");
                    db.DbPsetString("@CUST_SUB_CD", _cust_sub_cd);
                }
                if (ship_to_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_CD           = @SHIP_TO_CD                               ");
                    db.DbPsetString("@SHIP_TO_CD", _ship_to_cd);
                }
                if (ship_to_sub_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_SUB_CD       = @SHIP_TO_SUB_CD                           ");
                    db.DbPsetString("@SHIP_TO_SUB_CD", _ship_to_sub_cd);
                }
                //if (cust_cd != "")
                //{
                //    strSQL.Append(" AND SO.CUST_CD = @CUST_CD ");
                //    strSQL.Append(" AND SO.CUST_SUB_CD = @CUST_SUB_CD ");
                //    db.DbPsetString("@CUST_CD", _cust_cd);
                //    db.DbPsetString("@CUST_SUB_CD", _cust_sub_cd);
                //}
                //if (ship_to_cd != "")
                //{
                //    strSQL.Append(" AND SO.SHIP_TO_CD = @SHIP_TO_CD ");
                //    strSQL.Append(" AND SO.SHIP_TO_SUB_CD = @SHIP_TO_SUB_CD ");
                //    db.DbPsetString("@SHIP_TO_CD", _ship_to_cd);
                //    db.DbPsetString("@SHIP_TO_SUB_CD", _ship_to_sub_cd);
                //}
                if (alloc_status == 0)
                {
                    strSQL.Append(" AND SOD.ALLOC_STATUS <> 1 ");
                }
                if (item_no != "")
                {
                    //strSQL.Append(" AND SOD.ITEM_NO = @ITEM_NO ");    //Del 2017.03.01 Ubiq-Sai
                    strSQL.Append(" AND SOD.ITEM_NO LIKE @ITEM_NO ");   //Add 2017.03.01 Ubiq-Sai
                    db.DbPsetString("@ITEM_NO", _item_no);
                }
                if (sch_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SOD.SHIP_REQ_DATE >= @SCH_SHIP_DATE_BEG ");
                    db.DbPsetInt("@SCH_SHIP_DATE_BEG", _sch_ship_date_beg);
                }
                if (sch_ship_date_end != 0)
                {
                    strSQL.Append(" AND SOD.SHIP_REQ_DATE <= @SCH_SHIP_DATE_END ");
                    db.DbPsetInt("@SCH_SHIP_DATE_END", _sch_ship_date_end);
                }
                if (ship_whs != "")
                {
                    strSQL.Append(" AND SOD.SHIP_WHS = @SHIP_WHS ");
                    db.DbPsetString("@SHIP_WHS", _ship_whs);
                }
            }
            //Del 2012.05.21 Ubiq-Sai Start
            //strSQL.Append(" GROUP BY  SO.CUST_CD,			SO.CUST_SUB_CD,		SO.SHIP_TO_CD,		SO.SHIP_TO_SUB_CD,	        ");
            //strSQL.Append("           SO.ORDER_NO,          SO.CUST_ORDER_NO,   SOD.ITEM_NO,        SOD.ORDER_QTY,              ");
            //strSQL.Append("           SOD.ACTUAL_SHIP_QTY,  SS.ALLOC_QTY,       SOD.ACTUAL_SHIP_QTY,SOD.SHIP_REQ_DATE,          ");
            //strSQL.Append("           SOD.SHIP_REQ_DATE,	SOD.JOC_CD,		    SOD.SHIP_WHS,	    SOD.ORDER_LINE_NO,		    ");
            ////strSQL.Append("           SOD.SHIP_CNT,	        C1.CUST_NAME ,		C2.CUST_NAME,	                                "); //Del Ubiq-Sai 10.09.30
            //strSQL.Append("           SS.SHIP_SEQ,	        C1.CUST_NAME ,		C2.CUST_NAME,	                                ");     //Add Ubiq-Sai 10.09.30
            //strSQL.Append("           I.ITEM_DESC,		    I.SCH_ID,           SP.DATA_CHAR");
            //Del 2012.05.21 Ubiq-Sai End
            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "TABLE");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                }
                if (db.State() == ConnectionState.Open)
                    db.DbClose();

                return ds;
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
        }
        /// <summary>
        /// 出荷引当Detail Dataの取得
        /// 
        /// 使用画面：OrdShipInst
        /// </summary>
        public DataSet GetShipDetailList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT                                                                                  ");
            strSQL.Append(" S1.DATA_CHAR UMSR_NAME,                                                                 ");
            strSQL.Append(" INV.LOT_NO,			INV.LOCATION,		INV.INV_BAL,		INV.ALLOC_QTY,              ");
            //strSQL.Append(" SA.ALLOC_QTY ALLOC_QTY_SA,              I.ITEM_UMSR,        INV.JOC_CD,    SA.SHIP_SEQ  "); //Upd Ubiq-Sai 10.02.24    //Del 2012.05.21 Ubiq-Sai
            strSQL.Append(" ISNULL(SA.ALLOC_QTY,0) ALLOC_QTY_SA,    I.ITEM_UMSR,        INV.JOC_CD,                 ");   //Add 2012.05.21 Ubiq-Sai
            strSQL.Append(" ISNULL(SA.SHIP_SEQ,@SHIP_SEQ) SHIP_SEQ, ISNULL(SA.SCH_SHIP_QTY,0) SCH_SHIP_QTY          ");   //Add 2012.05.21 Ubiq-Sai
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM INVENTORY_DETAIL INV, SHIPPING_ALLOCATION SA, ITEM_MASTER I ");
                strSQL.Append(" WHERE INV.ITEM_NO     = SA.ITEM_NO(+)           ");
                strSQL.Append(" AND SA.ORDER_NO       = :ORDER_NO               ");
                strSQL.Append(" AND SA.ORDER_LINE_NO  = :ORDER_LINE_NO          ");
                strSQL.Append(" AND SA.SHIP_SEQ       = :SHIP_SEQ               ");
                strSQL.Append(" AND INV.ITEM_NO       = I.ITEM_NO(+)            ");
                strSQL.Append(" AND INV.INV_YM        = 0                       ");
                strSQL.Append(" AND INV.INV_WIP_TYPE  = 0                       ");
                strSQL.Append(" AND INV.INV_TYPE      = 0                       ");
                strSQL.Append(" AND INV.ITEM_NO       = :ITEM_NO                ");

                db.DbParametersClear();
                db.DbPsetString("ORDER_NO", _order_no);
                db.DbPsetInt("ORDER_LINE_NO", _order_line_no);
                db.DbPsetInt("SHIP_SEQ", _ship_seq);
                db.DbPsetString("ITEM_NO", _item_no);
            }
            else
            {
                db.DbParametersClear();
 
                //Del 2012.05.21 Ubiq-Sai Start
                //strSQL.Append(" FROM INVENTORY_DETAIL INV                                           ");
                //strSQL.Append(" LEFT OUTER JOIN SHIPPING_ALLOCATION SA ON INV.ITEM_NO = SA.ITEM_NO  ");
                //strSQL.Append(" AND SA.ORDER_NO       = @ORDER_NO                                   ");
                //strSQL.Append(" AND SA.ORDER_LINE_NO  = @ORDER_LINE_NO                              ");
                //strSQL.Append(" AND SA.SHIP_SEQ       = @SHIP_SEQ                                   ");
                //strSQL.Append(" AND INV.WHS_CD        = SA.WHS_CD                                   ");
                //strSQL.Append(" AND INV.LOCATION      = SA.LOCATION                                 ");
                //strSQL.Append(" AND INV.LOT_NO        = SA.LOT_NO                                   ");
                //strSQL.Append(" AND INV.JOC_CD        = SA.JOC_CD                                   ");

                ////add by wanghui 2010/3/18 strat 
                //strSQL.Append(" INNER JOIN SHIPPING_SCHEDULE SH                                     ");
                //strSQL.Append("	  ON SA.ORDER_NO = SH.ORDER_NO                                      ");
                //strSQL.Append("	  AND SA.ORDER_LINE_NO = SH.ORDER_LINE_NO                           ");
                //strSQL.Append("	  AND SA.SHIP_SEQ = SH.SHIP_SEQ                                     ");               
                ////add by wanghui 2010/3/18 end

                //strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON INV.ITEM_NO       = I.ITEM_NO      ");
                //strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY02    = I.ITEM_UMSR    ");
                //strSQL.Append(" AND S1.KEY01    =   'ITEM_UMSR'                                     ");
                //strSQL.Append(" WHERE INV.INV_YM       = 0                                          ");
                //strSQL.Append(" AND INV.INV_WIP_TYPE = 0                                            ");
                //strSQL.Append(" AND INV.INV_TYPE     = 0                                            ");
                //strSQL.Append(" AND INV.ITEM_NO = @ITEM_NO                                          ");
                //strSQL.Append(" AND INV.WHS_CD = @WHS_CD                                            ");
                //strSQL.Append(" AND SH.ORDER_STATUS < 90                                            ");     //Add Ubiq-Sai 10.04.02
                //Del 2012.05.21 Ubiq-Sai End

                //Add 2012.05.21 Ubiq-Sai Start
                strSQL.Append(" FROM																						");
                strSQL.Append(" 	(	SELECT *																			");
                strSQL.Append(" 		FROM INVENTORY_DETAIL																");
                strSQL.Append(" 		WHERE INV_YM     = (CASE WHEN @SHIP_SEQ = 0 THEN 9999 ELSE 0 END)					");
                strSQL.Append(" 		AND INV_WIP_TYPE = 0																");
                strSQL.Append(" 		AND INV_TYPE     = 0																");
                strSQL.Append(" 		AND WHS_CD       = @WHS_CD															");
                strSQL.Append(" 		AND ITEM_NO      = @ITEM_NO															");
                strSQL.Append(" 		AND INV_BAL      > 0																");
                strSQL.Append(" 	) INV																					");
                strSQL.Append(" LEFT OUTER JOIN																			    ");
                strSQL.Append(" 	(	SELECT 	SA.ITEM_NO, SA.WHS_CD, SA.LOCATION, SA.LOT_NO, SA.JOC_CD, SA.ALLOC_QTY,		");
                strSQL.Append(" 				SA.ORDER_NO, SA.ORDER_LINE_NO, SH.SHIP_SEQ, SH.SCH_SHIP_QTY					");
                strSQL.Append(" 		FROM SHIPPING_ALLOCATION SA															");
                strSQL.Append(" 		INNER JOIN SHIPPING_SCHEDULE SH														");
                strSQL.Append(" 		ON SA.ORDER_NO = SH.ORDER_NO														");
                strSQL.Append(" 		AND SA.ORDER_LINE_NO = SH.ORDER_LINE_NO												");
                strSQL.Append(" 		AND SA.SHIP_SEQ = SH.SHIP_SEQ														");
                strSQL.Append(" 		WHERE SH.ORDER_STATUS  < 90															");
                strSQL.Append("         AND SA.ORDER_NO      = @ORDER_NO													");
                strSQL.Append("         AND SA.ORDER_LINE_NO = @ORDER_LINE_NO												");
                strSQL.Append("         AND SA.SHIP_SEQ      = @SHIP_SEQ													");
                strSQL.Append(" 	) SA																					");
                strSQL.Append(" ON INV.ITEM_NO   = SA.ITEM_NO																");
                strSQL.Append(" AND INV.WHS_CD   = SA.WHS_CD																");
                strSQL.Append(" AND INV.LOCATION = SA.LOCATION																");
                strSQL.Append(" AND INV.LOT_NO   = SA.LOT_NO																");
                strSQL.Append(" AND INV.JOC_CD   = SA.JOC_CD																");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON INV.ITEM_NO = I.ITEM_NO									");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY02 = I.ITEM_UMSR AND S1.KEY01 = 'ITEM_UMSR'	");
                //Add 2012.05.21 Ubiq-Sai End

                db.DbPsetString("@ORDER_NO", _order_no);
                db.DbPsetInt("@ORDER_LINE_NO", _order_line_no);
                db.DbPsetInt("@SHIP_SEQ", _ship_seq);
                db.DbPsetString("@ITEM_NO", _item_no);
                db.DbPsetString("@WHS_CD", _ship_whs);
            }
            //strSQL.Append(" ORDER BY ");
            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "TABLE");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                }
                if (db.State() == ConnectionState.Open)
                    db.DbClose();

                return ds;
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
        }
        /// <summary>
        /// 出荷引当
        /// 
        /// 使用画面：OrdShipInst
        /// </summary>
        public int ShipAlloc()
        {
            ComDB db = new ComDB(_db_type);
            int rtn = 0;
            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
            db.DbPsetInt("@I_ORDER_LINE_NO", _order_line_no, ComConst.DB_IN);
            db.DbPsetInt("@I_PARTIAL_ALLOC_FLAG", _partial_alloc_flag, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_PGM", _chg_pgm, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_USERID", _chg_user_id, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@I_UPDATE_CNTR", _update_cntr, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);

            db.DbBeginTrans();
            rtn = db.DbStored("SP_SHIP_ALLOC");
            rtn = db.DbPgetInt("RET");
            if (rtn == ComConst.SUCCEED)
            {
                db.DbCommit();
            }
            else
            {
                _errcode = db.DbPgetInt("@O_ERRCODE");
                _errmsg = db.DbPgetString("@O_MSG");
                _sqlcode = db.DbPgetInt("@O_SQLCODE");
                _dbmsg = db.DbPgetString("@O_SQLMSG");
                _proc_name = db.DbPgetString("@O_PROC_NAME");
                _strErr = _errcode + ":" + _errmsg + "[" + _sqlcode + ":" + _dbmsg + "(" + _proc_name + ")]";
                db.DbRollback();
                rtn = ComConst.FAILED;
            }

            return rtn;
        }
        /// <summary>
        /// 出荷引当解除
        /// 
        /// 使用画面：OrdShipInst
        /// </summary>
        public int ShipUnAlloc()
        {
            ComDB db = new ComDB(_db_type);
            int rtn = 0;
            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
            db.DbPsetInt("@I_ORDER_LINE_NO", _order_line_no, ComConst.DB_IN);
            db.DbPsetInt("@I_SHIP_SEQ", _ship_seq, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_PGM", _chg_pgm, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_USERID", _chg_user_id, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@I_UPDATE_CNTR", _update_cntr, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);

            db.DbBeginTrans();
            rtn = db.DbStored("SP_SHIP_UNALLOC");
            rtn = db.DbPgetInt("RET");
            if (rtn == ComConst.SUCCEED)
            {
                db.DbCommit();
            }
            else
            {
                _errcode = db.DbPgetInt("@O_ERRCODE");
                _errmsg = db.DbPgetString("@O_MSG");
                _sqlcode = db.DbPgetInt("@O_SQLCODE");
                _dbmsg = db.DbPgetString("@O_SQLMSG");
                _proc_name = db.DbPgetString("@O_PROC_NAME");
                _strErr = _errcode + ":" + _errmsg + "[" + _sqlcode + ":" + _dbmsg + "(" + _proc_name + ")]";
                db.DbRollback();
                rtn = ComConst.FAILED;
            }

            return rtn;
        }
        /// <summary>
        /// 出荷引当変更
        /// 
        /// 使用画面：OrdShipInst
        /// </summary>
        public int ShipAllocChange()
        {
            ComDB db = new ComDB(_db_type);
            int rtn = 0;
            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
            db.DbPsetInt("@I_ORDER_LINE_NO", _order_line_no, ComConst.DB_IN);
            db.DbPsetInt("@I_SHIP_SEQ", _ship_seq, ComConst.DB_IN);
            db.DbPsetString("@I_ITEM_NO", _item_no, ComConst.DB_IN);
            db.DbPsetString("@I_WHS_CD", _ship_whs, ComConst.DB_IN);
            db.DbPsetString("@I_LOCATION", _location, ComConst.DB_IN);
            db.DbPsetString("@I_LOT_NO", _lot_no, ComConst.DB_IN);
            db.DbPsetString("@I_JOC_CD", _joc_cd, ComConst.DB_IN);
            db.DbPsetDouble("@I_ALLOC_QTY", _alloc_qty, ComConst.DB_IN);
            //db.DbPsetInt("@I_ACTUAL_SHIP_DATE", _actual_ship_date, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_PGM", _chg_pgm, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_USERID", _chg_user_id, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@I_UPDATE_CNTR", _update_cntr, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);

            db.DbBeginTrans();
            rtn = db.DbStored("SP_SHIP_ALLOC_CHANGE");
            rtn = db.DbPgetInt("RET");
            if (rtn == ComConst.SUCCEED)
            {
                db.DbCommit();
            }
            else
            {
                _errcode = db.DbPgetInt("@O_ERRCODE");
                _errmsg = db.DbPgetString("@O_MSG");
                _sqlcode = db.DbPgetInt("@O_SQLCODE");
                _dbmsg = db.DbPgetString("@O_SQLMSG");
                _proc_name = db.DbPgetString("@O_PROC_NAME");
                _strErr = _errcode + ":" + _errmsg + "[" + _sqlcode + ":" + _dbmsg + "(" + _proc_name + ")]";
                db.DbRollback();
                rtn = ComConst.FAILED;
            }

            return rtn;
        }
        /// <summary>
        /// 出荷予定一覧表 Dataの取得
        /// 
        /// 使用画面：OrdShipSchRpt
        /// </summary>
        public DataSet GetShipSchList()//2008.12.03 ADD BY LIU
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT                                                                                  ");
            strSQL.Append(" SOD.SHIP_REQ_DATE,	SOD.ITEM_NO,		I.ITEM_DESC,		SOD.ORDER_QTY,	            ");
            strSQL.Append(" SOD.ACTUAL_SHIP_QTY,I.ITEM_UMSR,        SOD.DELIV_DATE,     SO.ORDER_NO,                ");
            strSQL.Append(" SO.CUST_ORDER_NO,   SO.CUST_CD+'-'+SO.CUST_SUB_CD CUST_NO,  CM.CUST_NAME,               ");
            strSQL.Append(" SO.SHIP_TO_CD+'-'+SO.SHIP_TO_SUB_CD SHIP_NO,	SO.ADDRESS1,I.SCH_ID,  SP.DATA_CHAR SCH_NAME,   ");
            strSQL.Append(" CM1.CUST_NAME SHIP_NAME,                                                                ");
            strSQL.Append(" SOD.JOC_CD,	    S1.DATA_CHAR UMSR_NAME, SOD.SHIP_WHS                                    ");
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM SALES_ORDER SO, SALES_ORDER_DETAIL SOD,                                    ");
                strSQL.Append(" ITEM_MASTER I ,CUSTOMER_MASTER CM                                               ");
                strSQL.Append(" WHERE SO.ORDER_NO         = SOD.ORDER_NO                                        ");
                strSQL.Append(" AND SO.CUST_CD            = CM.CUST_CD(+)                                       ");
                strSQL.Append(" AND SO.CUST_SUB_CD        = CM.CUST_SUB_CD(+)                                   ");
                strSQL.Append(" AND SOD.ITEM_NO           = I.ITEM_NO(+)                                        ");

                db.DbParametersClear();
                if (sch_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SOD.SHIP_REQ_DATE >= :SCH_SHIP_DATE_BEG ");
                    db.DbPsetInt("SCH_SHIP_DATE_BEG", _sch_ship_date_beg);
                }
                if (sch_ship_date_end != 0)
                {
                    strSQL.Append(" AND SOD.SHIP_REQ_DATE <= :SCH_SHIP_DATE_END ");
                    db.DbPsetInt("SCH_SHIP_DATE_END", _sch_ship_date_end);
                }
            }
            else
            {
                db.DbParametersClear();

                strSQL.Append(" FROM SALES_ORDER SO                                                 ");
                //strSQL.Append(" LEFT OUTER JOIN SALES_ORDER_DETAIL SOD ON SO.ORDER_NO = SOD.ORDER_NO");//upd 20090202liu
                strSQL.Append(" INNER JOIN SALES_ORDER_DETAIL SOD ON SO.ORDER_NO = SOD.ORDER_NO ");
                strSQL.Append(" AND SOD.ORDER_STATUS      < 90                                  ");

                if (sch_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SOD.SHIP_REQ_DATE >= @SCH_SHIP_DATE_BEG ");
                    db.DbPsetInt("@SCH_SHIP_DATE_BEG", _sch_ship_date_beg);
                }
                if (sch_ship_date_end != 0)
                {
                    strSQL.Append(" AND SOD.SHIP_REQ_DATE <= @SCH_SHIP_DATE_END ");
                    db.DbPsetInt("@SCH_SHIP_DATE_END", _sch_ship_date_end);
                }
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER CM ON SO.CUST_CD = CM.CUST_CD       ");
                strSQL.Append(" AND SO.CUST_SUB_CD    = CM.CUST_SUB_CD                              ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER CM1 ON SO.SHIP_TO_CD = CM1.CUST_CD  ");
                strSQL.Append(" AND SO.SHIP_TO_SUB_CD    = CM1.CUST_SUB_CD                          ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON SOD.ITEM_NO = I.ITEM_NO            ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY01       = 'ITEM_UMSR' ");
                strSQL.Append(" AND S1.KEY02                = I.ITEM_UMSR                           ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER SP ON SP.KEY01       = 'SCH_ID'    ");
                strSQL.Append(" AND SP.KEY02                = I.SCH_ID                              ");
                strSQL.Append(" WHERE SO.ORDER_STATUS < 90                                          ");//ADD 20090202 LIU
                strSQL.Append(" AND SO.PO_TYPE = 0                                                  ");//Add 2015.07.02 Ubiq.Kawai
            }
            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "TABLE");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                }
                if (db.State() == ConnectionState.Open)
                    db.DbClose();

                return ds;
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
        }
        /// <summary>
        /// 出荷指示一覧表 Dataの取得
        /// 
        /// 使用画面：OrdShipInstRpt
        /// </summary>
        public DataSet GetShipInstPrtList()//2008.12.03 ADD BY LIU
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT                                                                                  ");
            strSQL.Append(" SS.SCH_SHIP_DATE,	    SOD.SHIP_WHS,           WHS.WHS_DESC,       SS.SHIP_NO,         ");
            strSQL.Append(" SO.SHIP_TO_CD+'-'+SO.SHIP_TO_SUB_CD SHIP_TO_NO, CM.CUST_NAME,       SO.ADDRESS1,   	    ");
            strSQL.Append(" SOD.ITEM_NO,	        I.ITEM_DESC,            SS.SCH_SHIP_QTY,    I.ITEM_UMSR,        ");
            strSQL.Append(" SS.ORDER_NO+'-'+CONVERT(char,SS.ORDER_LINE_NO) ORDER_NO,    SA.LOCATION,	SA.LOT_NO,	");
            strSQL.Append(" SA.JOC_CD,	            SA.ALLOC_QTY,           S1.DATA_CHAR UMSR_NAME                  ");
            strSQL.Append(" ,SUMA.SUM_ALLOC_QTY                                                                     "); //Add by ubiq -zyb 20110214
            if (_db_type == "ORACLE")
            {
                db.DbParametersClear();
                strSQL.Append(" FROM SALES_ORDER SO,    SALES_ORDER_DETAIL SOD,     SHIPPING_SCHEDULE SS,       ");
                strSQL.Append(" ITEM_MASTER I ,         CUSTOMER_MASTER CM,         WAREHOUSE_MASTER WHS,       ");
                strSQL.Append(" SHIPPING_ALLOCATION SA                                                          ");

                strSQL.Append(" WHERE SS.ORDER_NO         = SO.ORDER_NO                                         ");
                strSQL.Append(" AND SS.ORDER_NO           = SOD.ORDER_NO                                        ");
                strSQL.Append(" AND SS.ORDER_NO           = SOD.ORDER_LINE_NO                                   ");
                strSQL.Append(" AND SS.ORDER_NO           = SA.ORDER_NO                                         ");
                strSQL.Append(" AND SS.ORDER_NO           = SA.ORDER_LINE_NO                                    ");
                strSQL.Append(" AND SS.SHIP_SEQ           = SA.SHIP_SEQ                                         ");
                strSQL.Append(" AND SOD.ITEM_NO           = I.ITEM_NO(+)                                        ");
                strSQL.Append(" AND SOD.SHIP_WHS          = WHS.WHS_CD(+)                                       ");
                strSQL.Append(" AND SO.SHIP_TO_CD         = CM.CUST_CD(+)                                       ");
                strSQL.Append(" AND SO.SHIP_TO_SUB_CD     = CM.CUST_SUB_CD(+)                                   ");
                strSQL.Append(" AND SO.ORDER_STATUS       < 90                                                  ");
                strSQL.Append(" AND SOD.ORDER_STATUS      < 90                                                  ");
                strSQL.Append(" AND SS.ORDER_STATUS       < 90                                                  ");
                strSQL.Append(" AND   SA.ALLOC_QTY          <> 0                                                ");
                if (ship_whs != "")
                {
                    strSQL.Append(" AND SOD.SHIP_WHS           = :SHIP_WHS                                   ");
                    db.DbPsetString("SHIP_WHS", _ship_whs);
                }
                if (sch_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SS.SCH_SHIP_DATE >= :SCH_SHIP_DATE_BEG ");
                    db.DbPsetInt("SCH_SHIP_DATE_BEG", _sch_ship_date_beg);
                }
                if (sch_ship_date_end != 0)
                {
                    strSQL.Append(" AND SS.SCH_SHIP_DATE <= :SCH_SHIP_DATE_END ");
                    db.DbPsetInt("SCH_SHIP_DATE_END", _sch_ship_date_end);
                }
            }
            else
            {
                db.DbParametersClear();

                strSQL.Append(" FROM SHIPPING_SCHEDULE SS                                               ");
                //strSQL.Append(" LEFT OUTER JOIN SALES_ORDER SO ON SS.ORDER_NO = SO.ORDER_NO             ");//upd 20090203 liu
                strSQL.Append(" INNER JOIN SALES_ORDER SO ON SS.ORDER_NO = SO.ORDER_NO                  ");
                strSQL.Append(" AND SO.ORDER_STATUS         < 90                                        ");
                //strSQL.Append(" LEFT OUTER JOIN SALES_ORDER_DETAIL SOD ON SS.ORDER_NO = SOD.ORDER_NO    ");
                strSQL.Append(" INNER JOIN SALES_ORDER_DETAIL SOD ON SS.ORDER_NO = SOD.ORDER_NO         ");
                strSQL.Append(" AND SS.ORDER_LINE_NO        = SOD.ORDER_LINE_NO                         ");
                strSQL.Append(" AND SOD.ORDER_STATUS        < 90                                        ");
                if (ship_whs != "")
                {
                    strSQL.Append(" AND SOD.SHIP_WHS           = @SHIP_WHS                              ");
                    db.DbPsetString("@SHIP_WHS", _ship_whs);
                }
                strSQL.Append(" LEFT OUTER JOIN SHIPPING_ALLOCATION SA ON SS.ORDER_NO = SA.ORDER_NO     ");
                strSQL.Append(" AND SS.ORDER_LINE_NO        = SA.ORDER_LINE_NO                          ");
                strSQL.Append(" AND SS.SHIP_SEQ             = SA.SHIP_SEQ                               ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON SOD.ITEM_NO          = I.ITEM_NO       ");
                strSQL.Append(" LEFT OUTER JOIN WAREHOUSE_MASTER WHS ON SOD.SHIP_WHS  = WHS.WHS_CD      ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER CM ON SO.SHIP_TO_CD   = CM.CUST_CD      ");
                strSQL.Append(" AND SO.SHIP_TO_SUB_CD       = CM.CUST_SUB_CD                            ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY01       = 'ITEM_UMSR'     ");
                strSQL.Append(" AND S1.KEY02                = I.ITEM_UMSR                               ");
                //Add by ubiq-zyb 20110214
                strSQL.Append(" LEFT JOIN (SELECT SUM( ALLOC_QTY) SUM_ALLOC_QTY,ORDER_NO                ");
                //strSQL.Append(" ,ORDER_LINE_NO ,SHIP_SEQ                                                ");
                strSQL.Append(" ,ORDER_LINE_NO                                                          ");     //Upd 2011.02.14 Ubiq-Sai
                strSQL.Append(" FROM  SHIPPING_ALLOCATION                                               ");
                //strSQL.Append(" GROUP BY ORDER_NO , ORDER_LINE_NO ,SHIP_SEQ  )   AS SUMA ON             ");
                strSQL.Append(" GROUP BY ORDER_NO , ORDER_LINE_NO  )   AS SUMA ON                       ");     //Upd 2011.02.14 Ubiq-Sai
                strSQL.Append(" SS.ORDER_NO = SUMA.ORDER_NO                                             ");
                strSQL.Append(" AND SS.ORDER_LINE_NO        = SUMA.ORDER_LINE_NO                        ");
                //strSQL.Append(" AND SS.SHIP_SEQ             = SUMA.SHIP_SEQ                             ");   //Del 2011.02.14 Ubiq-Sai
                //end add
                strSQL.Append(" WHERE SS.ORDER_STATUS        < 90                                       ");
                strSQL.Append(" AND   SA.ALLOC_QTY          <> 0                                        ");

                if (sch_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SS.SCH_SHIP_DATE >= @SCH_SHIP_DATE_BEG ");
                    db.DbPsetInt("@SCH_SHIP_DATE_BEG", _sch_ship_date_beg);
                }
                if (sch_ship_date_end != 0)
                {
                    strSQL.Append(" AND SS.SCH_SHIP_DATE <= @SCH_SHIP_DATE_END ");
                    db.DbPsetInt("@SCH_SHIP_DATE_END", _sch_ship_date_end);
                }
            }
            strSQL.Append(" ORDER BY SOD.SHIP_WHS,SOD.ITEM_NO ,SS.SHIP_NO            ");
            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "TABLE");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                }
                if (db.State() == ConnectionState.Open)
                    db.DbClose();

                return ds;
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
        }

        /// <summary>
        ///  返品処理の追加
        /// 
        /// 使用画面：OrdReturn
        /// </summary>
        public int SalesReturn()//2008.12.04 ADD BY ZHAO
        {
            ComDB db = new ComDB(_db_type);
            int rtn = 0;

            db.DbParametersClear();
            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetInt("@I_ORDER_FLAG", _order_flag, ComConst.DB_IN);
            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
            db.DbPsetInt("@I_ORDER_LINE_NO", _order_line_no, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_CD", _cust_cd, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_SUB_CD ", _cust_sub_cd, ComConst.DB_IN);
            db.DbPsetString("@I_ITEM_NO", _item_no, ComConst.DB_IN);
            db.DbPsetInt("@I_RETURN_DATE", _return_date, ComConst.DB_IN);
			db.DbPsetInt("@I_RETURN_QTY", _return_qty, ComConst.DB_IN);
			db.DbPsetDouble("@I_RETURN_PRC", _return_prc, ComConst.DB_IN);//ADD BY UBIQ-LIU 2015/04/27
			db.DbPsetString("@I_RETURN_CUR", _return_cur, ComConst.DB_IN);//ADD BY UBIQ-LIU 2015/04/27
            db.DbPsetString("@I_RETURN_WHS", _return_whs, ComConst.DB_IN);
            db.DbPsetString("@I_RETURN_REASON", _return_reason, ComConst.DB_IN);
            db.DbPsetInt("@I_REOPEN_FLAG", _reopen_flag, ComConst.DB_IN);

            db.DbPsetString("@I_CHG_PGM", _chg_pgm, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_USERID", _chg_user_id, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@I_UPDATE_CNTR", _update_cntr, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);

            db.DbBeginTrans();
            rtn = db.DbStored("SP_SALES_RETURN");
            if (rtn == ComConst.SUCCEED)
            {
                db.DbCommit();
            }
            else
            {
                _errcode = db.DbPgetInt("@O_ERRCODE");
                _errmsg = db.DbPgetString("@O_MSG");
                _sqlcode = db.DbPgetInt("@O_SQLCODE");
                _dbmsg = db.DbPgetString("@O_SQLMSG");
                _proc_name = db.DbPgetString("@O_PROC_NAME");
                _strErr = _errcode + ":" + _errmsg + "[" + _sqlcode + ":" + _dbmsg + "(" + _proc_name + ")]";
                db.DbRollback();
                rtn = ComConst.FAILED;
            }

            return rtn;

        }

        /// <summary>
        /// 出荷実績入力 Dataの取得
        /// 
        /// 使用画面：OrdShipAct
        /// </summary>
        public DataSet GetShipActList()//2008.12.04 ADD BY LIU
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT                                                                                            ");
            strSQL.Append(" SS.SHIP_NO,	SO.CUST_CD+'-'+SO.CUST_SUB_CD CUST_NO,CUST1.CUST_NAME,  CUST2.CUST_NAME SHIP_NAME,    ");
            strSQL.Append(" SO.SHIP_TO_CD+'-'+SO.SHIP_TO_SUB_CD SHIP_TO_NO,  SS.ORDER_NO,	    SO.CUST_ORDER_NO,             ");
            strSQL.Append(" SOD.ITEM_NO,            I.ITEM_DESC,             SS.ALLOC_QTY,      SS.SCH_SHIP_DATE,             ");
            strSQL.Append(" SOD.SHIP_WHS,           WHS.WHS_DESC,            SOD.ORDER_LINE_NO, SS.SHIP_SEQ                   ");
            strSQL.Append(" , S.DATA_CHAR UMSR_NAME ,SS.SCH_SHIP_QTY         ");   // 2017.01.20
            if (_db_type == "ORACLE")
            {
                db.DbParametersClear();
                strSQL.Append(" FROM SALES_ORDER SO,    SALES_ORDER_DETAIL SOD,     SHIPPING_SCHEDULE SS,       ");
                strSQL.Append(" ITEM_MASTER I ,         CUSTOMER_MASTER CUST1,      WAREHOUSE_MASTER WHS,       ");
                strSQL.Append(" CUSTOMER_MASTER CUST2,  SHIPPING_ALLOCATION SA                                  ");
                strSQL.Append(" WHERE SS.ORDER_NO         = SO.ORDER_NO                                         ");
                strSQL.Append(" AND SS.ORDER_NO           = SOD.ORDER_NO                                        ");
                strSQL.Append(" AND SS.ORDER_NO           = SOD.ORDER_LINE_NO                                   ");
                strSQL.Append(" AND SS.ORDER_NO           = SA.ORDER_NO                                         ");
                strSQL.Append(" AND SS.ORDER_NO           = SA.ORDER_LINE_NO                                    ");
                strSQL.Append(" AND SS.SHIP_SEQ           = SA.SHIP_SEQ                                         ");
                strSQL.Append(" AND SOD.ITEM_NO           = I.ITEM_NO(+)                                        ");
                strSQL.Append(" AND SOD.SHIP_WHS          = WHS.WHS_CD(+)                                       ");
                strSQL.Append(" AND SO.CUST_CD            = CUST1.CUST_CD(+)                                    ");
                strSQL.Append(" AND SO.CUST_SUB_CD        = CUST1.CUST_SUB_CD(+)                                ");
                strSQL.Append(" AND SO.SHIP_TO_CD         = CUST2.CUST_CD(+)                                    ");
                strSQL.Append(" AND SO.SHIP_TO_SUB_CD     = CUST2.CUST_SUB_CD(+)                                ");
                strSQL.Append(" AND SO.ORDER_STATUS       < 90                                                 ");
                strSQL.Append(" AND SOD.ORDER_STATUS      < 90                                                 ");
                strSQL.Append(" AND SS.ORDER_STATUS       < 90                                                  ");
                if (ship_no != "")
                {
                    strSQL.Append(" AND SS.SHIP_NO           = :SHIP_NO                                    ");
                    db.DbPsetString("SHIP_NO", _ship_no);
                }
                if (order_no != "")
                {
                    strSQL.Append(" AND SS.ORDER_NO           = :ORDER_NO                                   ");
                    db.DbPsetString("ORDER_NO", _order_no);
                }
                if (cust_order_no != "")
                {
                    strSQL.Append(" AND SO.CUST_ORDER_NO           = :CUST_ORDER_NO                         ");
                    db.DbPsetString("CUST_ORDER_NO", _cust_order_no);
                }
                if (cust_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_CD              = :CUST_CD                                  ");
                    strSQL.Append(" AND SO.CUST_SUB_CD          = :CUST_SUB_CD                              ");
                    db.DbPsetString("CUST_CD", _cust_cd);
                    db.DbPsetString("CUST_SUB_CD", _cust_sub_cd);
                }
                if (ship_to_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_CD           = :SHIP_TO_CD                               ");
                    strSQL.Append(" AND SO.SHIP_TO_SUB_CD       = :SHIP_TO_SUB_CD                           ");
                    db.DbPsetString("SHIP_TO_CD", _ship_to_cd);
                    db.DbPsetString("SHIP_TO_SUB_CD", _ship_to_sub_cd);
                }
                if (item_no != "")
                {
                    strSQL.Append(" AND SOD.ITEM_NO           = :ITEM_NO                                   ");
                    db.DbPsetString("ITEM_NO", _item_no);
                }
                if (sch_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SS.SCH_SHIP_DATE >= :SCH_SHIP_DATE_BEG ");
                    db.DbPsetInt("SCH_SHIP_DATE_BEG", _sch_ship_date_beg);
                }
                if (sch_ship_date_end != 0)
                {
                    strSQL.Append(" AND SS.SCH_SHIP_DATE <= :SCH_SHIP_DATE_END ");
                    db.DbPsetInt("SCH_SHIP_DATE_END", _sch_ship_date_end);
                }
                if (ship_whs != "")
                {
                    strSQL.Append(" AND SOD.SHIP_WHS           = :SHIP_WHS                                   ");
                    db.DbPsetString("SHIP_WHS", _ship_whs);
                }
            }
            else
            {
                db.DbParametersClear();

                strSQL.Append(" FROM SHIPPING_SCHEDULE SS                                                   ");
                //strSQL.Append(" LEFT OUTER JOIN SALES_ORDER SO ON SS.ORDER_NO = SO.ORDER_NO             ");
                strSQL.Append(" INNER JOIN SALES_ORDER SO ON SS.ORDER_NO = SO.ORDER_NO                      ");
                strSQL.Append(" AND SO.ORDER_STATUS         < 90                                            ");
                //strSQL.Append(" LEFT OUTER JOIN SALES_ORDER_DETAIL SOD ON SS.ORDER_NO = SOD.ORDER_NO    ");
                strSQL.Append(" INNER JOIN SALES_ORDER_DETAIL SOD ON SS.ORDER_NO = SOD.ORDER_NO             ");
                strSQL.Append(" AND SS.ORDER_LINE_NO        = SOD.ORDER_LINE_NO                             ");
                strSQL.Append(" AND SOD.ORDER_STATUS        < 90                                            ");
                //strSQL.Append(" LEFT OUTER JOIN SHIPPING_ALLOCATION SA ON SS.ORDER_NO = SA.ORDER_NO     ");
                //strSQL.Append(" AND SS.ORDER_LINE_NO        = SA.ORDER_LINE_NO                          ");
                //strSQL.Append(" AND SS.SHIP_SEQ             = SA.SHIP_SEQ                               ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON SOD.ITEM_NO          = I.ITEM_NO       ");
                strSQL.Append(" LEFT OUTER JOIN WAREHOUSE_MASTER WHS ON SOD.SHIP_WHS  = WHS.WHS_CD      ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER CUST1 ON SO.CUST_CD   = CUST1.CUST_CD   ");
                strSQL.Append(" AND SO.CUST_SUB_CD       = CUST1.CUST_SUB_CD                            ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER CUST2 ON SO.SHIP_TO_CD= CUST2.CUST_CD   ");
                strSQL.Append(" AND SO.SHIP_TO_SUB_CD       = CUST2.CUST_SUB_CD                         ");
                strSQL.Append(" LEFT JOIN SYSTEM_PARAMETER S ON  S.KEY01  = 'ITEM_UMSR'                 "); // 2017.01.20
                strSQL.Append("  AND    S.KEY02 = I.ITEM_UMSR                                          ");
                strSQL.Append(" WHERE SS.ORDER_STATUS        < 90                                        ");
                if (ship_no != "")
                {
                    strSQL.Append(" AND SS.SHIP_NO           = @SHIP_NO                                    ");
                    db.DbPsetString("SHIP_NO", _ship_no);
                }
                if (order_no != "")
                {
                    strSQL.Append(" AND SS.ORDER_NO           = @ORDER_NO                                   ");
                    db.DbPsetString("ORDER_NO", _order_no);
                }
                if (sch_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SS.SCH_SHIP_DATE >= @SCH_SHIP_DATE_BEG ");
                    db.DbPsetInt("@SCH_SHIP_DATE_BEG", _sch_ship_date_beg);
                }
                if (sch_ship_date_end != 0)
                {
                    strSQL.Append(" AND SS.SCH_SHIP_DATE <= @SCH_SHIP_DATE_END ");
                    db.DbPsetInt("@SCH_SHIP_DATE_END", _sch_ship_date_end);
                }
                if (cust_order_no != "")
                {
                    strSQL.Append(" AND SO.CUST_ORDER_NO           = @CUST_ORDER_NO                         ");
                    db.DbPsetString("@CUST_ORDER_NO", _cust_order_no);
                }
                if (cust_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_CD              = @CUST_CD                                  ");                    
                    db.DbPsetString("@CUST_CD", _cust_cd);                    
                }
                if (cust_sub_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_SUB_CD          = @CUST_SUB_CD                              ");
                    db.DbPsetString("@CUST_SUB_CD", _cust_sub_cd);
                }
                if (ship_to_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_CD           = @SHIP_TO_CD                               ");                    
                    db.DbPsetString("@SHIP_TO_CD", _ship_to_cd);                    
                }
                if (ship_to_sub_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_SUB_CD       = @SHIP_TO_SUB_CD                           ");
                    db.DbPsetString("@SHIP_TO_SUB_CD", _ship_to_sub_cd);
                }
                if (ship_whs != "")
                {
                    strSQL.Append(" AND SOD.SHIP_WHS           = @SHIP_WHS                              ");
                    db.DbPsetString("@SHIP_WHS", _ship_whs);
                }
                if (item_no != "")
                {
                    //strSQL.Append(" AND SOD.ITEM_NO           = @ITEM_NO                                   ");    //Del 2017.03.01 Ubiq-Sai
                    strSQL.Append(" AND SOD.ITEM_NO        LIKE @ITEM_NO                                   ");      //Add 2017.03.01 Ubiq-Sai
                    db.DbPsetString("@ITEM_NO", _item_no);
                }
            }
            strSQL.Append(" ORDER BY SOD.SHIP_WHS,SOD.ITEM_NO ,SS.SHIP_NO            ");
            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "TABLE");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                }
                if (db.State() == ConnectionState.Open)
                    db.DbClose();

                return ds;
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
        }
        /// <summary>
        /// 出荷実績プロシジャ
        /// SP_SHIP_ACP
        /// 使用画面：OrdShipAct
        /// </summary>
        public int ShipAct()//2008.12.04 ADD BY LIU
        {
            ComDB db = new ComDB(_db_type);
            int rtn = 0;
            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
            db.DbPsetInt("@I_ORDER_LINE_NO", _order_line_no, ComConst.DB_IN);
            db.DbPsetInt("@I_SHIP_SEQ", _ship_seq, ComConst.DB_IN);
            db.DbPsetInt("@I_ACTUAL_SHIP_DATE", _actual_ship_date, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_PGM", _chg_pgm, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_USERID", _chg_user_id, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@I_UPDATE_CNTR", _update_cntr, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);

            db.DbBeginTrans();
            rtn = db.DbStored("SP_SHIP_ACT");
            rtn = db.DbPgetInt("RET");
            if (rtn == ComConst.SUCCEED)
            {
                db.DbCommit();
            }
            else
            {
                _errcode = db.DbPgetInt("@O_ERRCODE");
                _errmsg = db.DbPgetString("@O_MSG");
                _sqlcode = db.DbPgetInt("@O_SQLCODE");
                _dbmsg = db.DbPgetString("@O_SQLMSG");
                _proc_name = db.DbPgetString("@O_PROC_NAME");
                _strErr = _errcode + ":" + _errmsg + "[" + _sqlcode + ":" + _dbmsg + "(" + _proc_name + ")]";
                db.DbRollback();
                rtn = ComConst.FAILED;
            }

            return rtn;
        }

        /// <summary>
        ///  返品取消の追加
        /// 
        /// 使用画面：OrdReturnCancel
        /// </summary>
        public int SalesReturnCancel()//2008.12.05 ADD BY ZHAO
        {
            int rtn = 0;
            ComDB db = new ComDB(_db_type);
            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_RETURN_NO", _return_no, ComConst.DB_IN);

            db.DbPsetString("@I_CHG_PGM", _chg_pgm, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_USERID", _chg_user_id, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@I_UPDATE_CNTR", _update_cntr, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);

            db.DbBeginTrans();
            rtn = db.DbStored("SP_SALES_RETURN_CANCEL");
            rtn = db.DbPgetInt("RET");
            if (rtn == ComConst.SUCCEED)
            {
                db.DbCommit();
            }
            if (rtn != ComConst.SUCCEED)
            {
                _errcode = db.DbPgetInt("@O_ERRCODE");
                _errmsg = db.DbPgetString("@O_MSG");
                _sqlcode = db.DbPgetInt("@O_SQLCODE");
                _dbmsg = db.DbPgetString("@O_SQLMSG");
                _proc_name = db.DbPgetString("@O_PROC_NAME");
                _strErr = _errcode + ":" + _errmsg + "[" + _sqlcode + ":" + _dbmsg + "(" + _proc_name + ")]";
                db.DbRollback();
                rtn = ComConst.FAILED;
            }

            return rtn;

        }

        /// <summary>
        /// 出荷実績入力 Dataの取得
        /// 
        /// 使用画面：OrdShipAct
        /// </summary>
        public DataSet GetShipActCancelList()//2008.12.05 ADD BY LIU
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT                                                                                            ");
            strSQL.Append(" SS.SHIP_NO,	SO.CUST_CD+'-'+SO.CUST_SUB_CD CUST_NO,CUST1.CUST_NAME,  CUST2.CUST_NAME SHIP_NAME,    ");
            strSQL.Append(" SO.SHIP_TO_CD+'-'+SO.SHIP_TO_SUB_CD SHIP_TO_NO,  SS.ORDER_NO,	    SO.CUST_ORDER_NO,             ");
            strSQL.Append(" SOD.ITEM_NO,            I.ITEM_DESC,             SS.ALLOC_QTY,      SS.ACTUAL_SHIP_QTY,           ");
            strSQL.Append(" SS.ACTUAL_SHIP_DATE,    SOD.SHIP_WHS,            WHS.WHS_DESC,      SOD.ORDER_LINE_NO,            ");
            strSQL.Append(" SS.SHIP_SEQ                                                                                       ");
            if (_db_type == "ORACLE")
            {
                db.DbParametersClear();
                strSQL.Append(" FROM SALES_ORDER SO,    SALES_ORDER_DETAIL SOD,     SHIPPING_SCHEDULE SS,       ");
                strSQL.Append(" ITEM_MASTER I ,         CUSTOMER_MASTER CUST1,      WAREHOUSE_MASTER WHS,       ");
                strSQL.Append(" CUSTOMER_MASTER CUST2,  SHIPPING_ALLOCATION SA                                  ");
                strSQL.Append(" WHERE SS.ORDER_NO         = SO.ORDER_NO                                         ");
                strSQL.Append(" AND SS.ORDER_NO           = SOD.ORDER_NO                                        ");
                strSQL.Append(" AND SS.ORDER_NO           = SOD.ORDER_LINE_NO                                   ");
                strSQL.Append(" AND SS.ORDER_NO           = SA.ORDER_NO                                         ");
                strSQL.Append(" AND SS.ORDER_NO           = SA.ORDER_LINE_NO                                    ");
                strSQL.Append(" AND SS.SHIP_SEQ           = SA.SHIP_SEQ                                         ");
                strSQL.Append(" AND SOD.ITEM_NO           = I.ITEM_NO(+)                                        ");
                strSQL.Append(" AND SOD.SHIP_WHS          = WHS.WHS_CD(+)                                       ");
                strSQL.Append(" AND SO.CUST_CD            = CUST1.CUST_CD(+)                                    ");
                strSQL.Append(" AND SO.CUST_SUB_CD        = CUST1.CUST_SUB_CD(+)                                ");
                strSQL.Append(" AND SO.SHIP_TO_CD         = CUST2.CUST_CD(+)                                    ");
                strSQL.Append(" AND SO.SHIP_TO_SUB_CD     = CUST2.CUST_SUB_CD(+)                                ");
                strSQL.Append(" AND SS.ORDER_STATUS       = 90                                                  ");
                if (ship_no != "")
                {
                    strSQL.Append(" AND SS.SHIP_NO           = :SHIP_NO                                    ");
                    db.DbPsetString("SHIP_NO", _ship_no);
                }
                if (order_no != "")
                {
                    strSQL.Append(" AND SS.ORDER_NO           = :ORDER_NO                                   ");
                    db.DbPsetString("ORDER_NO", _order_no);
                }
                if (cust_order_no != "")
                {
                    strSQL.Append(" AND SO.CUST_ORDER_NO           = :CUST_ORDER_NO                         ");
                    db.DbPsetString("CUST_ORDER_NO", _cust_order_no);
                }
                if (cust_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_CD              = :CUST_CD                                  ");
                    strSQL.Append(" AND SO.CUST_SUB_CD          = :CUST_SUB_CD                              ");
                    db.DbPsetString("CUST_CD", _cust_cd);
                    db.DbPsetString("CUST_SUB_CD", _cust_sub_cd);
                }
                if (ship_to_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_CD           = :SHIP_TO_CD                               ");
                    strSQL.Append(" AND SO.SHIP_TO_SUB_CD       = :SHIP_TO_SUB_CD                           ");
                    db.DbPsetString("SHIP_TO_CD", _ship_to_cd);
                    db.DbPsetString("SHIP_TO_SUB_CD", _ship_to_sub_cd);
                }
                if (item_no != "")
                {
                    strSQL.Append(" AND SOD.ITEM_NO           = :ITEM_NO                                   ");
                    db.DbPsetString("ITEM_NO", _item_no);
                }
                if (actual_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SS.ACTUAL_SHIP_DATE >= :ACTUAL_SHIP_DATE_BEG ");
                    db.DbPsetInt("ACTUAL_SHIP_DATE_BEG", _actual_ship_date_beg);
                }
                if (actual_ship_date_end != 0)
                {
                    strSQL.Append(" AND SS.ACTUAL_SHIP_DATE <= :ACTUAL_SHIP_DATE_END ");
                    db.DbPsetInt("ACTUAL_SHIP_DATE_END", _actual_ship_date_end);
                }
                if (ship_whs != "")
                {
                    strSQL.Append(" AND SOD.SHIP_WHS           = :SHIP_WHS                                   ");
                    db.DbPsetString("SHIP_WHS", _ship_whs);
                }
            }
            else
            {
                db.DbParametersClear();

                strSQL.Append(" FROM SHIPPING_SCHEDULE SS                                               ");
                strSQL.Append(" LEFT OUTER JOIN SALES_ORDER SO ON SS.ORDER_NO = SO.ORDER_NO             ");
                strSQL.Append(" LEFT OUTER JOIN SALES_ORDER_DETAIL SOD ON SS.ORDER_NO = SOD.ORDER_NO    ");
                strSQL.Append(" AND SS.ORDER_LINE_NO        = SOD.ORDER_LINE_NO                         ");
                //strSQL.Append(" LEFT OUTER JOIN SHIPPING_ALLOCATION SA ON SS.ORDER_NO = SA.ORDER_NO     ");
                //strSQL.Append(" AND SS.ORDER_LINE_NO        = SA.ORDER_LINE_NO                          ");
                //strSQL.Append(" AND SS.SHIP_SEQ             = SA.SHIP_SEQ                               ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON SOD.ITEM_NO          = I.ITEM_NO       ");
                strSQL.Append(" LEFT OUTER JOIN WAREHOUSE_MASTER WHS ON SOD.SHIP_WHS  = WHS.WHS_CD      ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER CUST1 ON SO.CUST_CD   = CUST1.CUST_CD   ");
                strSQL.Append(" AND SO.CUST_SUB_CD       = CUST1.CUST_SUB_CD                            ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER CUST2 ON SO.SHIP_TO_CD= CUST2.CUST_CD   ");
                strSQL.Append(" AND SO.SHIP_TO_SUB_CD       = CUST2.CUST_SUB_CD                         ");
                strSQL.Append(" WHERE SS.ORDER_STATUS        = 90                                       ");
                if (ship_no != "")
                {
                    strSQL.Append(" AND SS.SHIP_NO           = @SHIP_NO                                    ");
                    db.DbPsetString("SHIP_NO", _ship_no);
                }
                if (order_no != "")
                {
                    strSQL.Append(" AND SS.ORDER_NO           = @ORDER_NO                                   ");
                    db.DbPsetString("ORDER_NO", _order_no);
                }
                if (actual_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SS.ACTUAL_SHIP_DATE >= @ACTUAL_SHIP_DATE_BEG ");
                    db.DbPsetInt("@ACTUAL_SHIP_DATE_BEG", _actual_ship_date_beg);
                }
                if (actual_ship_date_end != 0)
                {
                    strSQL.Append(" AND SS.ACTUAL_SHIP_DATE <= @ACTUAL_SHIP_DATE_END ");
                    db.DbPsetInt("@ACTUAL_SHIP_DATE_END", _actual_ship_date_end);
                }
                if (cust_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_CD              = @CUST_CD                                  ");                    
                    db.DbPsetString("@CUST_CD", _cust_cd);                    
                }
                if (cust_sub_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_SUB_CD          = @CUST_SUB_CD                              ");
                    db.DbPsetString("@CUST_SUB_CD", _cust_sub_cd);
                }
                if (ship_to_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_CD           = @SHIP_TO_CD                               ");                    
                    db.DbPsetString("@SHIP_TO_CD", _ship_to_cd);                    
                }
                if (ship_to_sub_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_SUB_CD       = @SHIP_TO_SUB_CD                           ");
                    db.DbPsetString("@SHIP_TO_SUB_CD", _ship_to_sub_cd);
                }
                if (cust_order_no != "")
                {
                    strSQL.Append(" AND SO.CUST_ORDER_NO           = @CUST_ORDER_NO                         ");
                    db.DbPsetString("@CUST_ORDER_NO", _cust_order_no);
                }
                if (ship_whs != "")
                {
                    strSQL.Append(" AND SOD.SHIP_WHS           = @SHIP_WHS                              ");
                    db.DbPsetString("@SHIP_WHS", _ship_whs);
                }
                if (item_no != "")
                {
                    //strSQL.Append(" AND SOD.ITEM_NO           = @ITEM_NO                                   ");    //Del 2017.03.01 Ubiq-Sai
                    strSQL.Append(" AND SOD.ITEM_NO        LIKE @ITEM_NO                                   ");      //Add 2017.03.01 Ubiq-Sai
                    db.DbPsetString("@ITEM_NO", _item_no);
                }
            }
            strSQL.Append(" ORDER BY SOD.SHIP_WHS,SOD.ITEM_NO ,SS.SHIP_NO            ");
            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "TABLE");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                }
                if (db.State() == ConnectionState.Open)
                    db.DbClose();

                return ds;
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
        }

        /// <summary>
        /// 出荷実績プロシジャ
        /// SP_SHIP_ACT_DETAIL_CHANGE
        /// 使用画面：OrdShipAct
        /// </summary>
        public int ShipActCancel()//2008.12.05 ADD BY LIU
        {
            ComDB db = new ComDB(_db_type);
            int rtn = 0;
            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
            db.DbPsetInt("@I_ORDER_LINE_NO", _order_line_no, ComConst.DB_IN);
            db.DbPsetInt("@I_SHIP_SEQ", _ship_seq, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_PGM", _chg_pgm, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_USERID", _chg_user_id, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@I_UPDATE_CNTR", _update_cntr, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);

            db.DbBeginTrans();
            rtn = db.DbStored("SP_SHIP_ACT_CANCEL");
            rtn = db.DbPgetInt("RET");
            if (rtn == ComConst.SUCCEED)
            {
                db.DbCommit();
            }
            else
            {
                _errcode = db.DbPgetInt("@O_ERRCODE");
                _errmsg = db.DbPgetString("@O_MSG");
                _sqlcode = db.DbPgetInt("@O_SQLCODE");
                _dbmsg = db.DbPgetString("@O_SQLMSG");
                _proc_name = db.DbPgetString("@O_PROC_NAME");
                _strErr = _errcode + ":" + _errmsg + "[" + _sqlcode + ":" + _dbmsg + "(" + _proc_name + ")]";
                db.DbRollback();
                rtn = ComConst.FAILED;
            }

            return rtn;
        }

        /// <summary>
        /// 出荷実績一覧表 Dataの取得
        /// 
        /// 使用画面：OrdShipActRpt
        /// </summary>
        public DataSet GetShipActRptList()//2008.12.05 ADD BY LIU
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();
            //--- sql
            strSQL.Append(" SELECT      	                                                                      ");
            strSQL.Append(" SO.CUST_CD+'-'+SO.CUST_SUB_CD CUST_NO,CUST1.CUST_NAME,  CUST2.CUST_NAME SHIP_NAME,    ");
            strSQL.Append(" SO.SHIP_TO_CD+'-'+SO.SHIP_TO_SUB_CD SHIP_TO_NO,  SOD.ORDER_NO+'-'+CONVERT(char,SOD.ORDER_LINE_NO) ORDER_NO,  ");
            strSQL.Append(" SO.CUST_ORDER_NO,    SOD.ITEM_NO,           I.ITEM_DESC,            SS.SHIP_NO,       ");
            strSQL.Append(" SS.ACTUAL_SHIP_QTY,  SOD.UNIT_PRICE,        SOD.CURRENCY,           WHS.WHS_DESC,     ");
            strSQL.Append(" SOD.DELIV_DATE,      S1.DATA_CHAR CUR_NAME, S2.DATA_CHAR SCH_NAME,  SOD.JOC_CD,       ");
            strSQL.Append(" SOD.SHIP_WHS WHS_CD,                                                                  ");
            strSQL.Append(" SS.ACTUAL_SHIP_DATE, S3.DATA_CHAR UMSR                                                ");
            strSQL.Append(",ISNULL(S1.DATA_DEC,0) PRC_DEC,		ISNULL(S1.DATA_DEC2,0) AMT_DEC 						");//ADD BY UBIQ-LIU 2016-7-20
            if (_db_type == "ORACLE")
            {
                db.DbParametersClear();
                strSQL.Append(" FROM SALES_ORDER SO,    SALES_ORDER_DETAIL SOD,     SHIPPING_SCHEDULE SS,       ");
                strSQL.Append(" ITEM_MASTER I ,         CUSTOMER_MASTER CUST1,      WAREHOUSE_MASTER WHS,       ");
                //strSQL.Append(" CUSTOMER_MASTER CUST2,  SHIPPING_ALLOCATION SA,     SYSTEM_PARAMETER S1,        ");
                strSQL.Append(" CUSTOMER_MASTER CUST2,  SYSTEM_PARAMETER S1,                                    ");
                strSQL.Append(" SYSTEM_PARAMETER S2,    SYSTEM_PARAMETER S2                                     ");
                strSQL.Append(" WHERE SS.ORDER_NO         = SO.ORDER_NO                                         ");
                strSQL.Append(" AND SS.ORDER_NO           = SOD.ORDER_NO                                        ");
                strSQL.Append(" AND SS.ORDER_NO           = SOD.ORDER_LINE_NO                                   ");
                strSQL.Append(" AND SS.ORDER_NO           = SA.ORDER_NO                                         ");
                //strSQL.Append(" AND SS.ORDER_NO           = SA.ORDER_LINE_NO                                    ");
                //strSQL.Append(" AND SS.SHIP_SEQ           = SA.SHIP_SEQ                                         ");
                strSQL.Append(" AND SOD.ITEM_NO           = I.ITEM_NO(+)                                        ");
                strSQL.Append(" AND SOD.SHIP_WHS          = WHS.WHS_CD(+)                                       ");
                strSQL.Append(" AND SO.CUST_CD            = CUST1.CUST_CD(+)                                    ");
                strSQL.Append(" AND SO.CUST_SUB_CD        = CUST1.CUST_SUB_CD(+)                                ");
                strSQL.Append(" AND SO.SHIP_TO_CD         = CUST2.CUST_CD(+)                                    ");
                strSQL.Append(" AND SO.SHIP_TO_SUB_CD     = CUST2.CUST_SUB_CD(+)                                ");
                strSQL.Append(" AND S1.KEY01              = 'CURRENCY_CD'                                       ");
                strSQL.Append(" AND S1.KEY02              = SOD.CURRENCY                                        ");
                strSQL.Append(" AND S2.KEY01              = 'SCH_ID'                                            ");
                strSQL.Append(" AND S2.KEY02              = I.SCH_ID                                            ");
                strSQL.Append(" AND S3.KEY01              = 'ITEM_UMSR'                                         ");
                strSQL.Append(" AND S3.KEY02              = I.ITEM_UMSR                                         ");
                strSQL.Append(" AND SS.ORDER_STATUS       = 90                                                  ");
                if (actual_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SS.ACTUAL_SHIP_DATE >= :ACTUAL_SHIP_DATE                                ");
                    db.DbPsetInt("ACTUAL_SHIP_DATE_BEG", _actual_ship_date_beg);
                }
                if (actual_ship_date_end != 0)
                {
                    strSQL.Append(" AND SOD.ACTUAL_SHIP_DATE <= :ACTUAL_SHIP_DATE                               ");
                    db.DbPsetInt("ACTUAL_SHIP_DATE_END", _actual_ship_date_end);
                }
            }
            else
            {
                db.DbParametersClear();

                strSQL.Append(" FROM SHIPPING_SCHEDULE SS                                               ");
                strSQL.Append(" LEFT OUTER JOIN SALES_ORDER SO ON SS.ORDER_NO = SO.ORDER_NO             ");
                strSQL.Append(" LEFT OUTER JOIN SALES_ORDER_DETAIL SOD ON SS.ORDER_NO = SOD.ORDER_NO    ");
                strSQL.Append(" AND SS.ORDER_LINE_NO        = SOD.ORDER_LINE_NO                         ");
                //strSQL.Append(" LEFT OUTER JOIN SHIPPING_ALLOCATION SA ON SS.ORDER_NO = SA.ORDER_NO     ");//DEL 20090307 UBIQ-LIU
                //strSQL.Append(" AND SS.ORDER_LINE_NO        = SA.ORDER_LINE_NO                          ");
                //strSQL.Append(" AND SS.SHIP_SEQ             = SA.SHIP_SEQ                               ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON SOD.ITEM_NO          = I.ITEM_NO       ");
                strSQL.Append(" LEFT OUTER JOIN WAREHOUSE_MASTER WHS ON SOD.SHIP_WHS  = WHS.WHS_CD      ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER CUST1 ON SO.CUST_CD   = CUST1.CUST_CD   ");
                strSQL.Append(" AND SO.CUST_SUB_CD       = CUST1.CUST_SUB_CD                            ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER CUST2 ON SO.SHIP_TO_CD= CUST2.CUST_CD   ");
                strSQL.Append(" AND SO.SHIP_TO_SUB_CD       = CUST2.CUST_SUB_CD                         ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY01       = 'CURRENCY_CD'   ");
                strSQL.Append(" AND S1.KEY02                = SOD.CURRENCY                              ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S2 ON S2.KEY01       = 'SCH_ID'        ");
                strSQL.Append(" AND S2.KEY02                = I.SCH_ID                                  ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S3 ON S3.KEY01       = 'ITEM_UMSR'     ");
                strSQL.Append(" AND S3.KEY02                = I.ITEM_UMSR                               ");
                strSQL.Append(" WHERE SS.ORDER_STATUS       = 90                                        ");
                if (actual_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SS.ACTUAL_SHIP_DATE >= @ACTUAL_SHIP_DATE_BEG                                ");
                    db.DbPsetInt("@ACTUAL_SHIP_DATE_BEG", _actual_ship_date_beg);
                }
                if (actual_ship_date_end != 0)
                {
                    strSQL.Append(" AND SOD.ACTUAL_SHIP_DATE <= @ACTUAL_SHIP_DATE_END                               ");
                    db.DbPsetInt("@ACTUAL_SHIP_DATE_END", _actual_ship_date_end);
                }
            }
            strSQL.Append(" ORDER BY SS.ACTUAL_SHIP_DATE,SO.CUST_CD,SO.CUST_SUB_CD,                             ");
            strSQL.Append(" SO.SHIP_TO_CD,SO.SHIP_TO_SUB_CD,SOD.ORDER_NO                                        ");
            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "TABLE");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                }
                if (db.State() == ConnectionState.Open)
                    db.DbClose();

                return ds;
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
        }
        /// <summary>
        /// 出荷実績入力 Dataの取得
        /// 
        /// 使用画面：OrdShipAct
        /// </summary>
        public DataSet GetShipActCancelDetail()//2008.12.08 ADD BY LIU
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT                                                                                      ");
            strSQL.Append(" SA.LOT_NO,	            SA.JOC_CD,              SA.LOCATION,        SA.ACTUAL_SHIP_QTY,     ");
            strSQL.Append(" I.ITEM_UMSR,            S1.DATA_CHAR UMSR_NAME                                              ");
            if (_db_type == "ORACLE")
            {
                db.DbParametersClear();
                strSQL.Append(" FROM SHIPPING_ALLOCATION SA,    ITEM_MASTER I                                   ");
                strSQL.Append(" WHERE SA.ORDER_NO           = :ORDER_NO                                         ");
                strSQL.Append(" AND SA.ORDER_LINE_NO        = :ORDER_LINE_NO                                    ");
                strSQL.Append(" AND SA.SHIP_SEQ             = :SHIP_SEQ                                         ");
                strSQL.Append(" AND SA.ITEM_NO              = I.ITEM_NO(+)                                      ");
                db.DbPsetString("ORDER_NO", _order_no);
                db.DbPsetInt("ORDER_LINE_NO", _order_line_no);
                db.DbPsetInt("SHIP_SEQ", _ship_seq);
            }
            else
            {
                db.DbParametersClear();

                strSQL.Append(" FROM SHIPPING_ALLOCATION SA                                               ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON SA.ITEM_NO              = I.ITEM_NO      ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY01          = 'ITEM_UMSR'    ");
                strSQL.Append(" AND S1.KEY02    =   I.ITEM_UMSR                                           ");
                strSQL.Append(" WHERE SA.ORDER_NO           = @ORDER_NO                                   ");
                strSQL.Append(" AND SA.ORDER_LINE_NO        = @ORDER_LINE_NO                              ");
                strSQL.Append(" AND SA.SHIP_SEQ             = @SHIP_SEQ                                   ");
                db.DbPsetString("@ORDER_NO", _order_no);
                db.DbPsetInt("@ORDER_LINE_NO", _order_line_no);
                db.DbPsetInt("@SHIP_SEQ", _ship_seq);
            }
            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "TABLE");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                }
                if (db.State() == ConnectionState.Open)
                    db.DbClose();

                return ds;
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
        }
        /// <summary>
        /// 出荷伝票 Dataの取得
        /// 
        /// 使用画面：OrdShipInstSlipRpt
        /// </summary>
        public DataSet Get_ShipInstSlipList()//2009.04.02 ADD BY LIU
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT                                                                              ");
            strSQL.Append(" SA.CUST_CD+'-'+SA.CUST_SUB_CD CUST_CD,	    CM.CUST_NAME,     SS.SCH_SHIP_DATE,     ");
            strSQL.Append(" SS.SHIP_NO,         COUNT(*)  DET_QTY                                               ");
            if (_db_type == "ORACLE")
            {
                db.DbParametersClear();
                strSQL.Append(" FROM SHIPPING_SCHEDULE SS,    CUSTOMER_MASTER CM,   SALES_ORDER                 ");
                strSQL.Append(" WHERE SA.ORDER_NO        =    SS.ORDER_NO                                       ");
                strSQL.Append(" AND SA.CUST_SUB_CD    =   CM.CUST_SUB_CD                                        ");
                strSQL.Append(" AND SA.CUST_CD       = CM.CUST_CD                                               ");
                if (cust_cd != "")
                {
                    strSQL.Append(" AND SA.CUST_CD              =  :CUST_CD                                     ");
                    strSQL.Append(" AND SA.CUST_SUB_CD          =  :CUST_SUB_CD                                 ");
                    db.DbPsetString("CUST_CD", _cust_cd);
                    db.DbPsetString("CUST_SUB_CD", _cust_sub_cd);
                }
                if (sch_ship_date_beg != 0)
                {
                    strSQL.Append(" AND SA.SCH_SHIP_DATE        >= :SCH_SHIP_DATE_BEG                           ");
                    db.DbPsetInt("SCH_SHIP_DATE_BEG", _sch_ship_date_beg);
                }
                if (sch_ship_date_end != 0)
                {
                    strSQL.Append(" AND SA.SCH_SHIP_DATE        <= :SCH_SHIP_DATE_END                           ");
                    db.DbPsetInt("SCH_SHIP_DATE_END", _sch_ship_date_end);
                }
            }
            else
            {
                db.DbParametersClear();

                strSQL.Append(" FROM SHIPPING_SCHEDULE SS                                                   ");
                strSQL.Append(" INNER JOIN SALES_ORDER SA ON SA.ORDER_NO        =    SS.ORDER_NO            ");
                strSQL.Append(" INNER JOIN SALES_ORDER_DETAIL SOD ON SOD.ORDER_NO   = SS.ORDER_NO           ");
                strSQL.Append(" AND SS.ORDER_LINE_NO    =   SOD.ORDER_LINE_NO                               ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER CM ON SA.CUST_CD       = CM.CUST_CD         ");
                strSQL.Append(" AND SA.CUST_SUB_CD    =   CM.CUST_SUB_CD                                    ");
                strSQL.Append(" WHERE                                                                       ");
                strSQL.Append(" SS.ORDER_STATUS          <      90                                          ");
                if (print_flag == 0)
                {
                    strSQL.Append(" AND SS.SLIP_PRINT_FLAG          =  0                                 ");
                }
                else
                {
                    strSQL.Append(" AND SS.SLIP_PRINT_FLAG          =  1                                 ");
                }
                if (cust_cd != "")
                {
                    strSQL.Append(" AND SA.CUST_CD              =  @CUST_CD                                     ");
                    strSQL.Append(" AND SA.CUST_SUB_CD          =  @CUST_SUB_CD                                 ");
                    db.DbPsetString("@CUST_CD", _cust_cd);
                    db.DbPsetString("@CUST_SUB_CD", _cust_sub_cd);
                }
                if (sch_ship_date_beg != 0)
                {
                    //strSQL.Append(" AND SA.SCH_SHIP_DATE        >= @SCH_SHIP_DATE_BEG                           ");
                    strSQL.Append(" AND SS.SCH_SHIP_DATE        >= @SCH_SHIP_DATE_BEG                           ");	//2010.04.23 CHG
                    db.DbPsetInt("@SCH_SHIP_DATE_BEG", _sch_ship_date_beg);
                }
                if (sch_ship_date_end != 0)
                {
                    //strSQL.Append(" AND SA.SCH_SHIP_DATE        <= @SCH_SHIP_DATE_END                           ");
                    strSQL.Append(" AND SS.SCH_SHIP_DATE        <= @SCH_SHIP_DATE_END                           ");	//2010.04.23 CHG
                    db.DbPsetInt("@SCH_SHIP_DATE_END", _sch_ship_date_end);
                }
            }
            try
            {
                strSQL.Append(" GROUP BY   SA.CUST_CD+'-'+SA.CUST_SUB_CD,	    CM.CUST_NAME,     SS.SCH_SHIP_DATE,    SS.SHIP_NO  ");
                ds = db.DbDataSet(strSQL.ToString(), "TABLE");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                }
                if (db.State() == ConnectionState.Open)
                    db.DbClose();

                return ds;
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
        }

        /// <summary>
        /// 出荷伝票 Dataの取得
        /// 
        /// 使用画面：OrdShipInstSlipRpt
        /// </summary>
        public DataSet Get_ShipInstSlipRptList()//2009.04.02 ADD BY LIU
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT                                                                                              ");
            strSQL.Append(" S1.DATA_CHAR,	 S1.DATA_CHAR2,   S1.DATA_CHAR3,   S1.DATA_CHAR4,   S1.DATA_CHAR5,                  ");
            strSQL.Append(" S1.DATA_CHAR6,   SA.ORDER_RECV_DATE,    SA.ORDER_NO,        SA.CUST_ORDER_NO,                       ");
            strSQL.Append(" SS.SHIP_NO,      SH.CUST_DESC SHIP_DESC,    SA.ZIP_CD SHIP_ZIP,     SA.ADDRESS1 SHIP_ADD1,          ");
            strSQL.Append(" SA.ADDRESS2 SHIP_ADD2,  SA.ADDRESS3 SHIP_ADD3,  SA.ADDRESS4 SHIP_ADD4,  SA.TELNO  SHIP_TEL,         ");
            strSQL.Append(" SA.FAXNO SHIP_FAX,          SA.CUST_ATTN,          CM.CUST_DESC,       CM.ZIP_CD CUST_ZIP,          ");
            strSQL.Append(" CM.ADDRESS1 CUST_ADD1,  CM.ADDRESS2 CUST_ADD2,  CM.ADDRESS3 CUST_ADD3,  CM.ADDRESS4 CUST_ADD4,      ");
            strSQL.Append(" CM.TELNO CUST_TEL,CM.FAXNO CUST_FAX,    SOD.ITEM_NO,        IM.ITEM_DESC,                           ");
            strSQL.Append(" SOD.SHIP_CNT,    SOD.ORDER_QTY,         SS.SCH_SHIP_QTY,                                            ");
            strSQL.Append(" CASE ISNULL(S5.DATA_INT,0) WHEN 0 THEN  S4.DATA_INT ELSE S5.DATA_INT END LANG                       ");//ADD BY LIU 20090410
            strSQL.Append(" ,SS.ALLOC_QTY                                                                                       ");//Add by ubiq-zyb 20110210 引当数量
            if (_db_type == "ORACLE")
            {
                db.DbParametersClear();
                strSQL.Append(" FROM SHIPPING_SCHEDULE SS,    CUSTOMER_MASTER CM,   SALES_ORDER SA              ");
                strSQL.Append(" ,SALES_ORDER_DETAIL SOD                                                         ");
                strSQL.Append(" WHERE   SS.SHIP_NO              =   :SHIP_NO                                    ");
                strSQL.Append(" AND SA.ORDER_NO                 =   SS.ORDER_NO                                 ");
                strSQL.Append(" AND SOD.ORDER_NO                =   SS.ORDER_NO                                 ");
                strSQL.Append(" AND SS.ORDER_LINE_NO            =   SOD.ORDER_LINE_NO                           ");
                strSQL.Append(" AND SA.CUST_CD                  =   CM.CUST_CD                                  ");
                strSQL.Append(" AND SA.CUST_SUB_CD              =   CM.CUST_SUB_CD                              ");
                strSQL.Append(" AND SA.CUST_CD                  =   SH.CUST_CD                                  ");
                strSQL.Append(" AND SA.CUST_SUB_CD              =   SH.CUST_SUB_CD                              ");
                strSQL.Append(" AND IM.ITEM_NO                  =   SOD.ITEM_NO                                 ");
                strSQL.Append(" AND S1 ON S1.KEY01              =   'COMPANY_CD'                                ");
                strSQL.Append(" AND S1.KEY02                    =   '*'                                         ");
                if (print_flag == 0)
                {
                    strSQL.Append(" AND SS.SLIP_PRINT_FLAG          =  0                                 ");//未発行
                }
                else
                {
                    strSQL.Append(" AND SS.SLIP_PRINT_FLAG          =  1                                 ");//発行済
                }
                db.DbPsetString("SHIP_NO", _ship_no);
            }
            else
            {
                db.DbParametersClear();

                strSQL.Append(" FROM SHIPPING_SCHEDULE SS                                                   ");
                strSQL.Append(" INNER JOIN SALES_ORDER SA ON SA.ORDER_NO        =    SS.ORDER_NO            ");
                strSQL.Append(" INNER JOIN SALES_ORDER_DETAIL SOD ON SOD.ORDER_NO   = SS.ORDER_NO           ");
                strSQL.Append(" AND SS.ORDER_LINE_NO    =   SOD.ORDER_LINE_NO                               ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER CM ON SA.CUST_CD       = CM.CUST_CD         ");
                strSQL.Append(" AND SA.CUST_SUB_CD    =   CM.CUST_SUB_CD                                    ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER SH ON SA.SHIP_TO_CD    = SH.CUST_CD         ");
                strSQL.Append(" AND SA.SHIP_TO_SUB_CD    =   SH.CUST_SUB_CD                                 ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER IM ON IM.ITEM_NO       =    SOD.ITEM_NO         ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY01       = 'COMPANY_CD'        ");
                strSQL.Append(" LEFT JOIN SYSTEM_PARAMETER S4 ON S4.KEY01  = 'PRINT_LANG'                   ");
                strSQL.Append(" AND  S4.KEY02   =   '*'                                                     ");
                strSQL.Append(" LEFT JOIN SYSTEM_PARAMETER S5 ON S5.KEY01  = 'COUNTRY_CD'                   ");
                strSQL.Append(" AND  S5.KEY02   =   CM.COUNTRY_CD                                           ");
                strSQL.Append(" AND S1.KEY02    =   '*'                                                     ");
                strSQL.Append(" WHERE   SS.SHIP_NO              =  @SHIP_NO                                 ");
                strSQL.Append(" AND     SS.ORDER_STATUS         <      90                                   ");
                if (print_flag == 0)
                {
                    strSQL.Append(" AND SS.SLIP_PRINT_FLAG          =  0                                 ");//未発行
                }
                else
                {
                    strSQL.Append(" AND SS.SLIP_PRINT_FLAG          =  1                                 ");//発行済
                }
                db.DbPsetString("@SHIP_NO", _ship_no);
            }
            try
            {
                strSQL.Append(" ORDER BY   SS.SHIP_SEQ  ");
                ds = db.DbDataSet(strSQL.ToString(), "SHIP");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                }
                if (db.State() == ConnectionState.Open)
                    db.DbClose();

                return ds;
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
        }

        /// <summary>
        /// 出荷伝票発行プロシジャ
        /// SP_SHIP_INSTSLIPPRT
        /// 使用画面：OrdShipInstSlipRpt
        /// </summary>
        public int Ship_InstSlipPrt(ComDB db)//2009.04.09 ADD BY LIU
        {
            //ComDB db = new ComDB(_db_type);
            int rtn = 0;
            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_SHIP_NO", _ship_no, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_PGM", _chg_pgm, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_USER_ID", _chg_user_id, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);

            db.DbBeginTrans();
            rtn = db.DbStored("SP_SHIP_INSTSLIPPRT");
            rtn = db.DbPgetInt("RET");
            if (rtn == ComConst.SUCCEED)
            {
                //db.DbCommit();
            }
            else
            {
                _errcode = db.DbPgetInt("@O_ERRCODE");
                _errmsg = db.DbPgetString("@O_MSG");
                _sqlcode = db.DbPgetInt("@O_SQLCODE");
                _dbmsg = db.DbPgetString("@O_SQLMSG");
                _proc_name = db.DbPgetString("@O_PROC_NAME");
                _strErr = _errcode + ":" + _errmsg + "[" + _sqlcode + ":" + _dbmsg + "(" + _proc_name + ")]";
                //db.DbRollback();
                rtn = ComConst.FAILED;
            }
            return rtn;
        }

        /// <summary>
        /// 出荷指示対象データを検索
        /// <para>使用画面：[OrdShipPriceChg]</para> 
        /// </summary>
        public DataSet Get_Ship_Ar_TransPriceList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            strSQL.Append(" SELECT                                                                                      ");
            strSQL.Append(" AT.SLIP_DATE,           AT.TO_VC_CD +'-'+ AT.TO_VC_SUB_CD TO_VC_CD,     C1.CUST_NAME,       ");
            strSQL.Append(" SO.SHIP_TO_CD+'-'+SO.SHIP_TO_SUB_CD SHIP_TO_CD, C2.CUST_NAME SHIP_NAME, AT.ORDER_NO,        ");
            strSQL.Append(" SO.CUST_ORDER_NO,       AT.ITEM_NO,             AT.ITEM_DESC,           AT.QTY,             ");
            strSQL.Append(" S1.DATA_CHAR ITEM_UMSR,  AT.UNIT_PRICE UNIT_PRC_NEW,    AT.AMT,       S2.DATA_CHAR CURRENCY,");
            strSQL.Append(" SUBSTRING(AT.SLIP_NO,1,10) SUB_SLIP_NO,         AT.SLIP_NO,             AT.UNIT_PRICE,      ");
            strSQL.Append(" AT.FLAG   ,ISNULL(S2.DATA_DEC,0) PRC_DEC ,ISNULL(S2.DATA_DEC2,0) AMT_DEC                    ");
            if (_db_type == "ORACLE")
            {
                db.DbParametersClear();
                strSQL.Append(" FROM (SELECT 1 FLAG,    A.*                                                             ");
                strSQL.Append("       FROM AR_TRANS A                                                                   ");
                strSQL.Append("       INNER JOIN (SELECT SUBSTRING(SLIP_NO,1,13) SUB_SLIP_NO,MAX(SLIP_NO) MAX_SLIP_NO   ");
                strSQL.Append("                   FROM AR_TRANS                                                         ");
                strSQL.Append("                   WHERE SLIP_TYPE = '01'                                                ");
                strSQL.Append("                   GROUP BY SUBSTRING(SLIP_NO,1,13)                                      ");
                strSQL.Append("                  ) M ON A.SLIP_NO = M.MAX_SLIP_NO                                       ");
                strSQL.Append("       UNION ALL                                                                         ");
                strSQL.Append("       SELECT 0 FLAG,    A.*                                                             ");
                strSQL.Append("       FROM AR_TRANS A                                                                   ");
                strSQL.Append("       INNER JOIN (SELECT SUBSTRING(SLIP_NO,1,13) SUB_SLIP_NO,MAX(SLIP_NO) MAX_SLIP_NO   ");
                strSQL.Append("                   FROM AR_TRANS                                                         ");
                strSQL.Append("                   WHERE SLIP_TYPE = '01'                                                ");
                strSQL.Append("                   GROUP BY SUBSTRING(SLIP_NO,1,13)                                      ");
                strSQL.Append("                  ) M ON  M.SUB_SLIP_NO = SUBSTRING(A.SLIP_NO,1,13)                      ");
                strSQL.Append("             AND A.SLIP_NO <> M.MAX_SLIP_NO                                              ");
                strSQL.Append("      ) AT                                                                               ");
                strSQL.Append(" LEFT OUTER JOIN SALES_ORDER SO ON AT.ORDER_NO    =   SO.ORDER_NO                        ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER C1 ON AT.TO_VC_CD   =   C1.CUST_CD                      ");
                strSQL.Append("         AND C1.CUST_SUB_CD    =   AT.TO_VC_SUB_CD                                       ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER C2 ON SO.SHIP_TO_CD =   C2.CUST_CD                      ");
                strSQL.Append("         AND C2.CUST_SUB_CD    =   SO.SHIP_TO_SUB_CD                                     ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON    AT.ITEM_NO      =   I.ITEM_NO                       ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY01     =   'ITEM_UMSR'                     ");
                strSQL.Append("         AND S1.KEY02    =   AT.ITEM_UMSR                                                ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S2 ON S2.KEY01     =   'CURRENCY_CD'                   ");
                strSQL.Append("         AND S2.KEY02    =   AT.CURRENCY                                                 ");

                strSQL.Append(" WHERE 1=1  ");
                if (_slip_no != "")
                {
                    strSQL.Append(" AND SUBSTRING(AT.SLIP_NO,1,10) = :SLIP_NO     ");
                    db.DbPsetString("SLIP_NO", _slip_no);
                }
                if (_order_no != "")
                {
                    strSQL.Append(" AND AT.ORDER_NO = :ORDER_NO         ");
                    db.DbPsetString("ORDER_NO", _order_no);
                }
                if (_cust_order_no != "")
                {
                    strSQL.Append(" AND SO.CUST_ORDER_NO = :CUST_ORDER_NO        ");
                    db.DbPsetString("@CUST_ORDER_NO", _cust_order_no);
                }
                if (_cust_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_CD = :CUST_CD");
                    db.DbPsetString("CUST_CD", _cust_cd);
                }
                if (_cust_sub_cd != "")
                {
                    strSQL.Append(" AND SO.CUST_SUB_CD  = :CUST_SUB_CD");
                    db.DbPsetString("CUST_SUB_CD", _cust_sub_cd);
                }
                if (_ship_to_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_CD = @SHIP_TO_CD");
                    db.DbPsetString("@SHIP_TO_CD", _ship_to_cd);
                }
                if (_ship_to_sub_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_SUB_CD = :SHIP_TO_SUB_CD");
                    db.DbPsetString("SHIP_TO_SUB_CD", _ship_to_sub_cd);
                }
                if (_item_no != "")
                {
                    strSQL.Append(" AND AT.ITEM_NO = :ITEM_NO");
                    db.DbPsetString("ITEM_NO", _item_no);
                }
                if (_sch_ship_date_beg != 0)
                {
                    strSQL.Append(" AND AT.SLIP_DATE >= :SLIP_DATE_FROM");
                    db.DbPsetInt("SLIP_DATE_FROM", _sch_ship_date_beg);
                }
                if (_sch_ship_date_end != 0)
                {
                    strSQL.Append(" AND AT.SLIP_DATE <= :SLIP_DATE_TO");
                    db.DbPsetInt("SLIP_DATE_TO", _sch_ship_date_end);
                }
                if (_flag == 1)
                {
                    strSQL.Append(" AND AT.FLAG = :FLAG");
                    db.DbPsetInt("FLAG", _flag);
                }               
            }
            else
            {
                db.DbParametersClear();
                strSQL.Append(" FROM (SELECT 1 FLAG,    A.*                                                             ");
                strSQL.Append("       FROM AR_TRANS A                                                                   ");
                strSQL.Append("       INNER JOIN (SELECT SUBSTRING(SLIP_NO,1,13) SUB_SLIP_NO,MAX(SLIP_NO) MAX_SLIP_NO   ");
                strSQL.Append("                   FROM AR_TRANS                                                         ");
                strSQL.Append("                   WHERE SLIP_TYPE = '01'                                                ");
                strSQL.Append("                   GROUP BY SUBSTRING(SLIP_NO,1,13)                                      ");
                strSQL.Append("                  ) M ON A.SLIP_NO = M.MAX_SLIP_NO                                       ");
                strSQL.Append("       UNION ALL                                                                         ");
                strSQL.Append("       SELECT 0 FLAG,    A.*                                                             ");
                strSQL.Append("       FROM AR_TRANS A                                                                   ");
                strSQL.Append("       INNER JOIN (SELECT SUBSTRING(SLIP_NO,1,13) SUB_SLIP_NO,MAX(SLIP_NO) MAX_SLIP_NO   ");
                strSQL.Append("                   FROM AR_TRANS                                                         ");
                strSQL.Append("                   WHERE SLIP_TYPE = '01'                                                ");
                strSQL.Append("                   GROUP BY SUBSTRING(SLIP_NO,1,13)                                      ");
                strSQL.Append("                  ) M ON  M.SUB_SLIP_NO = SUBSTRING(A.SLIP_NO,1,13)                      ");
                strSQL.Append("             AND A.SLIP_NO <> M.MAX_SLIP_NO                                              ");
                strSQL.Append("      ) AT                                                                               ");
                strSQL.Append(" LEFT OUTER JOIN SALES_ORDER SO ON AT.ORDER_NO    =   SO.ORDER_NO                        ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER C1 ON AT.TO_VC_CD   =   C1.CUST_CD                      ");
                strSQL.Append("         AND C1.CUST_SUB_CD    =   AT.TO_VC_SUB_CD                                       ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER C2 ON SO.SHIP_TO_CD =   C2.CUST_CD                      ");
                strSQL.Append("         AND C2.CUST_SUB_CD    =   SO.SHIP_TO_SUB_CD                                     ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON    AT.ITEM_NO      =   I.ITEM_NO                       ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY01     =   'ITEM_UMSR'                     ");
                strSQL.Append("         AND S1.KEY02    =   AT.ITEM_UMSR                                                ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S2 ON S2.KEY01     =   'CURRENCY_CD'                   ");
                strSQL.Append("         AND S2.KEY02    =   AT.CURRENCY                                                 ");

                strSQL.Append(" WHERE 1=1  ");
                if (_slip_no != "")
                {
                    strSQL.Append(" AND SUBSTRING(AT.SLIP_NO,1,10) = @SLIP_NO     ");
                    db.DbPsetString("@SLIP_NO", _slip_no);
                }
                if (_order_no  != "")
                {
                    strSQL.Append(" AND AT.ORDER_NO = @ORDER_NO         ");
                    db.DbPsetString("@ORDER_NO", _order_no);
                }
                if (_cust_order_no  != "")
                {
                    strSQL.Append(" AND SO.CUST_ORDER_NO = @CUST_ORDER_NO        ");
                    db.DbPsetString("@CUST_ORDER_NO", _cust_order_no);
                }
                if (_cust_cd  != "")
                {
                    strSQL.Append(" AND SO.CUST_CD = @CUST_CD");
                    db.DbPsetString("@CUST_CD", _cust_cd);
                }
                if (_cust_sub_cd  != "")
                {
                    strSQL.Append(" AND SO.CUST_SUB_CD  = @CUST_SUB_CD");
                    db.DbPsetString("@CUST_SUB_CD", _cust_sub_cd);
                }
                if (_ship_to_cd  != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_CD = @SHIP_TO_CD");
                    db.DbPsetString("@SHIP_TO_CD", _ship_to_cd);
                }
                if (_ship_to_sub_cd != "")
                {
                    strSQL.Append(" AND SO.SHIP_TO_SUB_CD = @SHIP_TO_SUB_CD");
                    db.DbPsetString("@SHIP_TO_SUB_CD", _ship_to_sub_cd);
                }
                if (_item_no  != "")
                {
                    //strSQL.Append(" AND AT.ITEM_NO = @ITEM_NO");  //Del 2017.03.01 Ubiq-Sai
                    strSQL.Append(" AND AT.ITEM_NO LIKE @ITEM_NO"); //Add 2017.03.01 Ubiq-Sai
                    db.DbPsetString("@ITEM_NO", _item_no);
                }
                if (_sch_ship_date_beg  != 0)
                {
                    strSQL.Append(" AND AT.SLIP_DATE >= @SLIP_DATE_FROM");
                    db.DbPsetInt("@SLIP_DATE_FROM", _sch_ship_date_beg);
                }
                if (_sch_ship_date_end  != 0)
                {
                    strSQL.Append(" AND AT.SLIP_DATE <= @SLIP_DATE_TO");
                    db.DbPsetInt("@SLIP_DATE_TO", _sch_ship_date_end);
                }
                if (_flag == 1)
                {
                    strSQL.Append(" AND AT.FLAG = @FLAG");
                    db.DbPsetInt("@FLAG", _flag);
                }
            }
            strSQL.Append(" ORDER BY AT.TO_VC_CD ASC,     AT.ITEM_NO,     AT.SLIP_NO ASC    ");
            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "SHIP");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                }
                if (db.State() == ConnectionState.Open)
                    db.DbClose();

                return ds;
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
        }

        /// <summary>
        /// 出荷単価更新処理
        ///
        /// <para>使用画面：[OrdShipPriceChg]</para>
        /// </summary>
        public int Ship_PriceChg()
        {
            ComDB db = new ComDB(_db_type);
            int rtn = 0;

            db.DbParametersClear();
            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_SLIP_NO", _slip_no, ComConst.DB_IN);
            db.DbPsetDouble("@I_ACT_PRC", _act_price, ComConst.DB_IN);

            db.DbPsetString("@I_CHG_PGM", _chg_pgm, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_USER_ID", _chg_user_id, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);
            db.DbBeginTrans();

            rtn = db.DbStored("SP_SHIP_PRICE_CHG");
            rtn = db.DbPgetInt("RET");
            if (rtn == ComConst.SUCCEED)
            {
                db.DbCommit();
            }
            else
            {
                _errcode = db.DbPgetInt("@O_ERRCODE");
                _errmsg = db.DbPgetString("@O_MSG");
                _sqlcode = db.DbPgetInt("@O_SQLCODE");
                _dbmsg = db.DbPgetString("@O_SQLMSG");
                _proc_name = db.DbPgetString("@O_PROC_NAME");
                _strErr = _errcode + ":" + _errmsg + "[" + _sqlcode + ":" + _dbmsg + "(" + _proc_name + ")]";
                db.DbRollback();
                rtn = ComConst.FAILED;
            }

            return rtn;
        }
    }
}
