using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.Configuration;
using PMClass;

/// <summary>
/// 受注テーブルクラス
/// </summary>
namespace PMClass
{
    public class Sales
    {
        #region : コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Sales()
        {
            try
            {
                _db_type = WebConfigurationManager.AppSettings["db_type"];
            }
            catch { }
        }
        public Sales(string p_user_id, int p_lang)
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
        protected string _order_no = "";
        protected string _cust_order_no = "";
        protected int _order_status = 0;
        protected int _po_type = 0;
        protected int _order_recv_date = 0;
        protected string _cust_cd = "";
        protected string _cust_sub_cd = "";
        protected string _ship_to_cd = "";
        protected string _ship_to_sub_cd = "";
        protected string _zip_cd = "";
        protected string _country_cd = "";
        protected string _state = "";
        protected string _address1 = "";
        protected string _address2 = "";
        protected string _address3 = "";
        protected string _address4 = "";
        protected string _telno = "";
        protected string _faxno = "";
        protected string _cust_attn = "";
        protected string _notify1 = "";
        protected string _notify2 = "";
        protected string _remarks = "";
        protected string _input_user_id = "";
        protected string _approve_user_id = "";
        protected string _umsr_desc = "";

        protected string _data_char1 = "";
        protected string _data_char2 = "";
        protected string _data_char3 = "";
        protected string _data_char4 = "";
        protected string _data_char5 = "";
        protected string _data_char6 = "";
        protected string _data_char7 = "";
        protected string _data_char8 = "";
        protected string _data_char9 = "";
        protected string _data_char10 = "";
        protected double _data_num1 = 0;
        protected double _data_num2 = 0;
        protected double _data_num3 = 0;
        protected double _data_num4 = 0;
        protected double _data_num5 = 0;
        protected double _data_num6 = 0;
        protected double _data_num7 = 0;
        protected double _data_num8 = 0;
        protected double _data_num9 = 0;
        protected double _data_num10 = 0;
        protected int _data_flag1 = 0;
        protected int _data_flag2 = 0;
        protected int _data_flag3 = 0;
        protected int _data_flag4 = 0;
        protected int _data_flag5 = 0;
        protected int _data_flag6 = 0;
        protected int _data_flag7 = 0;
        protected int _data_flag8 = 0;
        protected int _data_flag9 = 0;
        protected int _data_flag10 = 0;

        protected int _order_line_no = 0;
        protected int _deliv_date = 0;
        protected int _ship_req_date = 0;
        protected string _cust_name = "";
        protected string _item_no = "";
        protected string _item_desc = "";
        protected string _custm_item_no = "";
        protected double _order_qty = 0;
        protected double _unit_price = 0;
        protected string _currency = "";
        protected string _ship_whs = "";
        protected int _deliv_beg_date = 0;
        protected int _deliv_end_date = 0;
        protected int _order_recv_beg_date = 0;
        protected int _order_recv_end_date = 0;
        protected int _ship_req_beg_date = 0;
        protected int _ship_req_end_date = 0;
        protected string _ship_to_name = "";
        protected string _pay_terms = "";
        protected double _amount = 0.0;
        protected string _return_no = "";
        protected int _return_date1 = 0;
        protected int _return_date2 = 0;
        protected string _mark = "";
        protected string _cur_cd = "";
        protected string _cur_desc = "";
        protected string _joc_cd = "";
        protected int _item_addn_order_ratio = 0;

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
        //OrdSORpt 使用
        protected string _sch_id = "";
        protected int _beg_date = 0;
        protected int _end_date = 0;
        protected string _cust_name1 = "";
        protected string _sch_name = "";

        //OrdReturn 使用
        protected int _actual_ship_date = 0;
        protected int _actual_ship_qty = 0;

        //Add UBIQ-LIU 2010/08/02
        protected double _free_qty = 0;
        protected double _plan_qty = 0;

        /// <summary>
        /// 単価小数点以下桁数
        /// </summary>
        protected int _price_dec = 0;
        /// <summary>
        /// 単価小数点以下桁数
        /// </summary>
        public int price_dec { get { return _price_dec; } set { _price_dec = value; } }
        /// <summary>
        /// 金額小数点以下桁数
        /// </summary>
        protected int _amt_dec = 0;
        /// <summary>
        /// 金額小数点以下桁数
        /// </summary>
        public int amt_dec { get { return _amt_dec; } set { _amt_dec = value; } }
        #endregion

        #region : プロパティ
        ///<summary>
        /// プロパティ
        ///</summary>
        public int lang { get { return _lang; } set { _lang = value; } }

        public string order_no { get { return _order_no; } set { _order_no = value; } }
        public string cust_order_no { get { return _cust_order_no; } set { _cust_order_no = value; } }
        public int order_status { get { return _order_status; } set { _order_status = value; } }
        public int po_type { get { return _po_type; } set { _po_type = value; } }
        public int order_recv_date { get { return _order_recv_date; } set { _order_recv_date = value; } }
        public string cust_cd { get { return _cust_cd; } set { _cust_cd = value; } }
        public string cust_sub_cd { get { return _cust_sub_cd; } set { _cust_sub_cd = value; } }
        public string ship_to_cd { get { return _ship_to_cd; } set { _ship_to_cd = value; } }
        public string ship_to_sub_cd { get { return _ship_to_sub_cd; } set { _ship_to_sub_cd = value; } }
        public string zip_cd { get { return _zip_cd; } set { _zip_cd = value; } }
        public string country_cd { get { return _country_cd; } set { _country_cd = value; } }
        public string state { get { return _state; } set { _state = value; } }
        public string address1 { get { return _address1; } set { _address1 = value; } }
        public string address2 { get { return _address2; } set { _address2 = value; } }
        public string address3 { get { return _address3; } set { _address3 = value; } }
        public string address4 { get { return _address4; } set { _address4 = value; } }
        public string telno { get { return _telno; } set { _telno = value; } }
        public string faxno { get { return _faxno; } set { _faxno = value; } }
        public string cust_attn { get { return _cust_attn; } set { _cust_attn = value; } }
        public string notify1 { get { return _notify1; } set { _notify1 = value; } }
        public string notify2 { get { return _notify2; } set { _notify2 = value; } }
        public string remarks { get { return _remarks; } set { _remarks = value; } }
        public string input_user_id { get { return _input_user_id; } set { _input_user_id = value; } }
        public string approve_user_id { get { return _approve_user_id; } set { _approve_user_id = value; } }
        public string data_char1 { get { return _data_char1; } set { _data_char1 = value; } }
        public string data_char2 { get { return _data_char2; } set { _data_char2 = value; } }
        public string data_char3 { get { return _data_char3; } set { _data_char3 = value; } }
        public string data_char4 { get { return _data_char4; } set { _data_char4 = value; } }
        public string data_char5 { get { return _data_char5; } set { _data_char5 = value; } }
        public string data_char6 { get { return _data_char6; } set { _data_char6 = value; } }
        public string data_char7 { get { return _data_char7; } set { _data_char7 = value; } }
        public string data_char8 { get { return _data_char8; } set { _data_char8 = value; } }
        public string data_char9 { get { return _data_char9; } set { _data_char9 = value; } }
        public string data_char10 { get { return _data_char10; } set { _data_char10 = value; } }
        public double data_num1 { get { return _data_num1; } set { _data_num1 = value; } }
        public double data_num2 { get { return _data_num2; } set { _data_num2 = value; } }
        public double data_num3 { get { return _data_num3; } set { _data_num3 = value; } }
        public double data_num4 { get { return _data_num4; } set { _data_num4 = value; } }
        public double data_num5 { get { return _data_num5; } set { _data_num5 = value; } }
        public double data_num6 { get { return _data_num6; } set { _data_num6 = value; } }
        public double data_num7 { get { return _data_num7; } set { _data_num7 = value; } }
        public double data_num8 { get { return _data_num8; } set { _data_num8 = value; } }
        public double data_num9 { get { return _data_num9; } set { _data_num9 = value; } }
        public double data_num10 { get { return _data_num10; } set { _data_num10 = value; } }
        public int data_flag1 { get { return _data_flag1; } set { _data_flag1 = value; } }
        public int data_flag2 { get { return _data_flag2; } set { _data_flag2 = value; } }
        public int data_flag3 { get { return _data_flag3; } set { _data_flag3 = value; } }
        public int data_flag4 { get { return _data_flag4; } set { _data_flag4 = value; } }
        public int data_flag5 { get { return _data_flag5; } set { _data_flag5 = value; } }
        public int data_flag6 { get { return _data_flag6; } set { _data_flag6 = value; } }
        public int data_flag7 { get { return _data_flag7; } set { _data_flag7 = value; } }
        public int data_flag8 { get { return _data_flag8; } set { _data_flag8 = value; } }
        public int data_flag9 { get { return _data_flag9; } set { _data_flag9 = value; } }
        public int data_flag10 { get { return _data_flag10; } set { _data_flag10 = value; } }

        public int deliv_date { get { return _deliv_date; } set { _deliv_date = value; } }
        public int ship_req_date { get { return _ship_req_date; } set { _ship_req_date = value; } }
        public string cust_name { get { return _cust_name; } set { _cust_name = value; } }
        public string item_no { get { return _item_no; } set { _item_no = value; } }
        public string item_desc { get { return _item_desc; } set { _item_desc = value; } }
        public string custm_item_no { get { return _custm_item_no; } set { _custm_item_no = value; } }
        public double order_qty { get { return _order_qty; } set { _order_qty = value; } }
        public double unit_price { get { return _unit_price; } set { _unit_price = value; } }
        public string currency { get { return _currency; } set { _currency = value; } }
        public string ship_whs { get { return _ship_whs; } set { _ship_whs = value; } }
        public int deliv_beg_date { get { return _deliv_beg_date; } set { _deliv_beg_date = value; } }
        public int deliv_end_date { get { return _deliv_end_date; } set { _deliv_end_date = value; } }
        public int order_recv_beg_date { get { return _order_recv_beg_date; } set { _order_recv_beg_date = value; } }
        public int order_recv_end_date { get { return _order_recv_end_date; } set { _order_recv_end_date = value; } }
        public int ship_req_beg_date { get { return _ship_req_beg_date; } set { _ship_req_beg_date = value; } }
        public int ship_req_end_date { get { return _ship_req_end_date; } set { _ship_req_end_date = value; } }
        public int order_line_no { get { return _order_line_no; } set { _order_line_no = value; } }
        public string ship_to_name { get { return _ship_to_name; } set { _ship_to_name = value; } }
        public string pay_terms { get { return _pay_terms; } set { _pay_terms = value; } }
        public double amount { get { return _amount; } set { _amount = value; } }
        public int return_date1 { get { return _return_date1; } set { _return_date1 = value; } }
        public int return_date2 { get { return _return_date2; } set { _return_date2 = value; } }
        public string return_no { get { return _return_no; } set { _return_no = value; } }
        public string mark { get { return _mark; } set { _mark = value; } }
        public string umsr_desc { get { return _umsr_desc; } set { _umsr_desc = value; } }
        public string cur_cd { get { return _cur_cd; } set { _cur_cd = value; } }
        public string cur_desc { get { return _cur_desc; } set { _cur_desc = value; } }
        public string joc_cd { get { return _joc_cd; } set { _joc_cd = value; } }
        public int item_addn_order_ratio { get { return _item_addn_order_ratio; } set { _item_addn_order_ratio = value; } }
        public double free_qty { get { return _free_qty; } set { _free_qty = value; } }
        public double plan_qty { get { return _plan_qty; } set { _plan_qty = value; } }

        public DateTime entry_date { get { return _entry_date; } set { _entry_date = value; } }
        public DateTime chg_date { get { return _chg_date; } set { _chg_date = value; } }
        public string chg_user_id { get { return _chg_user_id; } set { _chg_user_id = value; } }
        public string chg_pgm { get { return _chg_pgm; } set { _chg_pgm = value; } }
        public int update_cntr { get { return _update_cntr; } set { _update_cntr = value; } }
        public string dbmsg { get { return _dbmsg; } set { _dbmsg = value; } }
        public string strErr { get { return _strErr; } set { _strErr = value; } }

        //OrdSORpt 使用

        public string sch_id { get { return _sch_id; } set { _sch_id = value; } }
        public int beg_date { get { return _beg_date; } set { _beg_date = value; } }
        public int end_date { get { return _end_date; } set { _end_date = value; } }
        //public string cust_name { get { return _cust_name1; } set { _cust_name1 = value; } }
        public string sch_name { get { return _sch_name; } set { _sch_name = value; } }

        //OrdReturn 使用
        public int actual_ship_date { get { return _actual_ship_date; } set { _actual_ship_date = value; } }
        public int actual_ship_qty { get { return _actual_ship_qty; } set { _actual_ship_qty = value; } }
        #endregion

        /// <summary>
        /// 受注テーブルの追加
        /// 
        /// 使用画面：OrdSOUpd
        /// </summary>
        public int SalesOrderInsert(ComDB db)
        {
            int rtn = 0;

            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);

            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_ORDER_NO", _cust_order_no, ComConst.DB_IN);
            db.DbPsetInt("@I_PO_TYPE", _po_type, ComConst.DB_IN);
            db.DbPsetInt("@I_ORDER_RECV_DATE", _order_recv_date, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_CD", _cust_cd, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_SUB_CD", _cust_sub_cd, ComConst.DB_IN);
            db.DbPsetString("@I_SHIP_TO_CD", _ship_to_cd, ComConst.DB_IN);
            db.DbPsetString("@I_SHIP_TO_SUB_CD", _ship_to_sub_cd, ComConst.DB_IN);
            db.DbPsetString("@I_ZIP_CD", _zip_cd, ComConst.DB_IN);
            db.DbPsetString("@I_COUNTRY_CD", _country_cd, ComConst.DB_IN);
            db.DbPsetString("@I_STATE", _state, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS1", _address1, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2", _address2, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS3", _address3, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS4", _address4, ComConst.DB_IN);
            db.DbPsetString("@I_TELNO", _telno, ComConst.DB_IN);
            db.DbPsetString("@I_FAXNO", _faxno, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_ATTN", _cust_attn, ComConst.DB_IN);
            db.DbPsetString("@I_NOTIFY1", _notify1, ComConst.DB_IN);
            db.DbPsetString("@I_NOTIFY2", _notify2, ComConst.DB_IN);
            db.DbPsetString("@I_REMARKS", _remarks, ComConst.DB_IN);
            db.DbPsetString("@I_INPUT_USER_ID", _input_user_id, ComConst.DB_IN);
            db.DbPsetString("@I_APPROVE_USER_ID", _approve_user_id, ComConst.DB_IN);
            //db.DbPsetInt("@I_ORDER_STATUS", _order_status, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR1", _data_char1, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR2", _data_char2, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR3", _data_char3, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR4", _data_char4, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR5", _data_char5, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR6", _data_char6, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR7", _data_char7, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR8", _data_char8, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR9", _data_char9, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR10", _data_char10, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM1", _data_num1, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM2", _data_num2, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM3", _data_num3, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM4", _data_num4, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM5", _data_num5, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM6", _data_num6, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM7", _data_num7, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM8", _data_num8, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM9", _data_num9, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM10", _data_num10, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG1", _data_flag1, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG2", _data_flag2, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG3", _data_flag3, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG4", _data_flag4, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG5", _data_flag5, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG6", _data_flag6, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG7", _data_flag7, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG8", _data_flag8, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG9", _data_flag9, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG10", _data_flag10, ComConst.DB_IN);
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
            rtn = db.DbStored("SP_SALES_ORDER_INSERT");
            rtn = db.DbPgetInt("RET");
            if (rtn == ComConst.SUCCEED)
            {
                // db.DbCommit();
            }
            else
            {
                _errcode = db.DbPgetInt("@O_ERRCODE");
                _errmsg = db.DbPgetString("@O_MSG");
                _sqlcode = db.DbPgetInt("@O_SQLCODE");
                _dbmsg = db.DbPgetString("@O_SQLMSG");
                _proc_name = db.DbPgetString("@O_PROC_NAME");
                _strErr = _errcode + ":" + _errmsg + "[" + _sqlcode + ":" + _dbmsg + "(" + _proc_name + ")]";
                // db.DbRollback();
                rtn = ComConst.FAILED;
            }

            return rtn;
        }

        /// <summary>
        /// 受注テーブルの変更
        /// 
        /// 使用画面：OrdSOUpd
        /// </summary>
        public int SalesOrderUpdate(ComDB db)
        {
            int rtn = 0;

            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_ORDER_NO", _cust_order_no, ComConst.DB_IN);
            db.DbPsetInt("@I_PO_TYPE", _po_type, ComConst.DB_IN);
            db.DbPsetInt("@I_ORDER_RECV_DATE", _order_recv_date, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_CD", _cust_cd, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_SUB_CD", _cust_sub_cd, ComConst.DB_IN);
            db.DbPsetString("@I_SHIP_TO_CD", _ship_to_cd, ComConst.DB_IN);
            db.DbPsetString("@I_SHIP_TO_SUB_CD", _ship_to_sub_cd, ComConst.DB_IN);
            db.DbPsetString("@I_ZIP_CD", _zip_cd, ComConst.DB_IN);
            db.DbPsetString("@I_COUNTRY_CD", _country_cd, ComConst.DB_IN);
            db.DbPsetString("@I_STATE", _state, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS1", _address1, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2", _address2, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS3", _address3, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS4", _address4, ComConst.DB_IN);
            db.DbPsetString("@I_TELNO", _telno, ComConst.DB_IN);
            db.DbPsetString("@I_FAXNO", _faxno, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_ATTN", _cust_attn, ComConst.DB_IN);
            db.DbPsetString("@I_NOTIFY1", _notify1, ComConst.DB_IN);
            db.DbPsetString("@I_NOTIFY2", _notify2, ComConst.DB_IN);
            db.DbPsetString("@I_REMARKS", _remarks, ComConst.DB_IN);
            db.DbPsetString("@I_INPUT_USER_ID", _input_user_id, ComConst.DB_IN);
            db.DbPsetString("@I_APPROVE_USER_ID", _approve_user_id, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR1", _data_char1, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR2", _data_char2, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR3", _data_char3, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR4", _data_char4, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR5", _data_char5, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR6", _data_char6, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR7", _data_char7, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR8", _data_char8, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR9", _data_char9, ComConst.DB_IN);
            db.DbPsetString("@I_DATA_CHAR10", _data_char10, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM1", _data_num1, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM2", _data_num2, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM3", _data_num3, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM4", _data_num4, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM5", _data_num5, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM6", _data_num6, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM7", _data_num7, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM8", _data_num8, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM9", _data_num9, ComConst.DB_IN);
            db.DbPsetDouble("@I_DATA_NUM10", _data_num10, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG1", _data_flag1, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG2", _data_flag2, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG3", _data_flag3, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG4", _data_flag4, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG5", _data_flag5, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG6", _data_flag6, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG7", _data_flag7, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG8", _data_flag8, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG9", _data_flag9, ComConst.DB_IN);
            db.DbPsetInt("@I_DATA_FLAG10", _data_flag10, ComConst.DB_IN);
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
            rtn = db.DbStored("SP_SALES_ORDER_UPDATE");
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
        /// 受注テーブルの削除
        /// 
        /// 使用画面：OrdSOUpd
        /// </summary>
        public int SalesOrderDelete()
        {
            ComDB db = new ComDB(_db_type);

            int rtn = 0;

            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
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
            rtn = db.DbStored("SP_SALES_ORDER_DELETE");
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
        /// 受注明細の追加
        /// 
        /// 使用画面：OrdSOUpd
        /// </summary>
        public int SalesOrderDetailInsert(ComDB db)
        {
            int rtn = 0;

            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);

            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
            db.DbPsetInt("@I_ORDER_LINE_NO", _order_line_no, ComConst.DB_IN);
            db.DbPsetInt("@I_DELIV_DATE", _deliv_date, ComConst.DB_IN);
            db.DbPsetInt("@I_SHIP_REQ_DATE", _ship_req_date, ComConst.DB_IN);
            db.DbPsetString("@I_ITEM_NO", _item_no, ComConst.DB_IN);
            db.DbPsetString("@I_CUSTM_ITEM_NO", _custm_item_no, ComConst.DB_IN);
            db.DbPsetDouble("@I_ORDER_QTY", _order_qty, ComConst.DB_IN);
            db.DbPsetDouble("@I_UNIT_PRICE", _unit_price, ComConst.DB_IN);
            db.DbPsetString("@I_CURRENCY", _cur_cd, ComConst.DB_IN);
            db.DbPsetString("@I_SHIP_WHS", _ship_whs, ComConst.DB_IN);

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
            rtn = db.DbStored("SP_SALES_ORDER_DETAIL_INSERT");
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
        /// 受注明細の変更
        /// 
        /// 使用画面：OrdSOUpd
        /// </summary>
        public int SalesOrderDetailUpdate(ComDB db)
        {
            int rtn = 0;

            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
            db.DbPsetInt("@I_ORDER_LINE_NO", _order_line_no, ComConst.DB_IN);
            db.DbPsetInt("@I_DELIV_DATE", _deliv_date, ComConst.DB_IN);
            db.DbPsetInt("@I_SHIP_REQ_DATE", _ship_req_date, ComConst.DB_IN);
            db.DbPsetString("@I_ITEM_NO", _item_no, ComConst.DB_IN);
            db.DbPsetString("@I_CUSTM_ITEM_NO", _custm_item_no, ComConst.DB_IN);
            db.DbPsetDouble("@I_ORDER_QTY", _order_qty, ComConst.DB_IN);
            db.DbPsetDouble("@I_FREE_QTY", _free_qty, ComConst.DB_IN);//ADD UBIQ-LIU 2010/08/02
            db.DbPsetDouble("@I_PLAN_QTY", _plan_qty, ComConst.DB_IN);//ADD UBIQ-LIU 2010/08/02
            db.DbPsetDouble("@I_UNIT_PRICE", _unit_price, ComConst.DB_IN);
            db.DbPsetString("@I_CURRENCY", _cur_cd, ComConst.DB_IN);
            db.DbPsetString("@I_SHIP_WHS", _ship_whs, ComConst.DB_IN);

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
            rtn = db.DbStored("SP_SALES_ORDER_DETAIL_UPDATE");
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
        /// 受注明細の削除
        /// 
        /// 使用画面：OrdSOUpd
        /// </summary>
        public int SalesOrderDetailDelete(ComDB db)
        {
            int rtn = 0;

            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_ORDER_NO", _order_no, ComConst.DB_IN);
            db.DbPsetInt("@I_ORDER_LINE_NO", _order_line_no, ComConst.DB_IN);

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
            rtn = db.DbStored("[SP_SALES_ORDER_DETAIL_DELETE]");
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
        /// 受注テーブル一覧の取得
        /// 
        /// 使用画面：OrdSOUpd,OrdSOInq
        /// </summary>
        public DataSet GetSalesOrderList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql           
            strSQL.Append("SELECT ");
            strSQL.Append("S.ORDER_NO,			S.CUST_ORDER_NO,		S.ORDER_STATUS,		S.PO_TYPE,			");
            strSQL.Append("S.ORDER_RECV_DATE,	S.CUST_CD,			    S.CUST_SUB_CD,		S.SHIP_TO_CD,	        ");
            strSQL.Append("S.SHIP_TO_SUB_CD,    S.ZIP_CD,	            S.COUNTRY_CD,		S.STATE,		        ");
            strSQL.Append("S.ADDRESS1,	        S.ADDRESS2,             S.ADDRESS3,	        S.ADDRESS4,			");
            strSQL.Append("S.TELNO,		        S.FAXNO,	            S.CUST_ATTN,        S.NOTIFY1,	  		");
            strSQL.Append("S.NOTIFY2,			S.REMARKS,              S.INPUT_USER_ID,	S.APPROVE_USER_ID,	    		");
            strSQL.Append("S.DATA_CHAR1,		S.DATA_CHAR2,			");
            strSQL.Append("S.DATA_CHAR3,		S.DATA_CHAR4,			S.DATA_CHAR5,		S.DATA_CHAR6,			");
            strSQL.Append("S.DATA_CHAR7,		S.DATA_CHAR8,			S.DATA_CHAR9,		S.DATA_CHAR10,		");
            strSQL.Append("S.DATA_NUM1,			S.DATA_NUM2,			S.DATA_NUM3,		S.DATA_NUM4,			");
            strSQL.Append("S.DATA_NUM5,			S.DATA_NUM6,			S.DATA_NUM7,		S.DATA_NUM8,			");
            strSQL.Append("S.DATA_NUM9,			S.DATA_NUM10,			S.DATA_FLAG1,		S.DATA_FLAG2,			");
            strSQL.Append("S.DATA_FLAG3,		S.DATA_FLAG4,			S.DATA_FLAG5,		S.DATA_FLAG6,			");
            strSQL.Append("S.DATA_FLAG7,		S.DATA_FLAG8,			S.DATA_FLAG9,			S.DATA_FLAG10,		");
            strSQL.Append("S.ENTRY_DATE,		S.CHG_DATE,			    S.CHG_PGM,			S.CHG_USERID,			");
            strSQL.Append("S.UPDATE_CNTR, ");
            strSQL.Append("C.CUST_NAME, 		SD.ITEM_NO,			I.ITEM_DESC,	    SD.CUSTM_ITEM_NO,");
            strSQL.Append("SD.ORDER_QTY,	    SD.DELIV_DATE,		SD.SHIP_REQ_DATE,	SD.SHIP_WHS, ");
            strSQL.Append("SD.ORDER_LINE_NO,    SHIP_TO.CUST_NAME SHIP_TO_NAME	");

            if (_db_type == "ORACLE")
            {
                db.DbParametersClear();

                strSQL.Append(" FROM SALES_ORDER S, SALES_ORDER_DETAIL SD, CUSTOMER_MASTER C,CUSTOMER_MASTER SHIP_TO,ITEM_MASTER I ");
                strSQL.Append(" WHERE  ");
                strSQL.Append("   S.ORDER_STATUS                 <     90 ");
                strSQL.Append("   AND SD.ORDER_STATUS                <     90 ");
                strSQL.Append("   AND S.ORDER_NO              = SD.ORDER_NO ");
                strSQL.Append("   AND S.CUST_CD             = C.CUST_CD");
                strSQL.Append("   AND S.CUST_SUB_CD             = C.CUST_SUB_CD");
                strSQL.Append("   AND S.SHIP_TO_CD             = SHIP_TO.CUST_CD");
                strSQL.Append("   AND S.SHIP_TO_SUB_CD             = SHIP_TO.CUST_SUB_CD");
                strSQL.Append("   AND SD.ITEM_NO            = I.ITEM_NO");
                if (order_no != "")
                {
                    strSQL.Append("  AND S.ORDER_NO              = :ORDER_NO ");
                    db.DbPsetString("ORDER_NO", _order_no);
                }
                if (cust_order_no != "")
                {
                    strSQL.Append("   AND S.CUST_ORDER_NO         = :CUST_ORDER_NO ");
                    db.DbPsetString("CUST_ORDER_NO", _cust_order_no);
                }
                if (cust_cd != "")
                {
                    strSQL.Append("   AND S.CUST_CD               = :CUST_CD ");
                    db.DbPsetString("CUST_CD", _cust_cd);
                }
                if (cust_sub_cd != "")
                {
                    strSQL.Append("   AND S.CUST_SUB_CD               = :CUST_SUB_CD ");
                    db.DbPsetString("CUST_SUB_CD", _cust_sub_cd);
                }
                if (ship_to_cd != "")
                {
                    strSQL.Append("   AND S.SHIP_TO_CD            = :SHIP_TO_CD ");
                    db.DbPsetString("SHIP_TO_CD", _ship_to_cd);
                }
                if (ship_to_sub_cd != "")
                {
                    strSQL.Append("   AND S.SHIP_TO_SUB_CD        = :SHIP_TO_SUB_CD ");
                    db.DbPsetString("SHIP_TO_SUB_CD", _ship_to_sub_cd);
                }
                if (item_no != "")
                {
                    strSQL.Append("   AND SD.ITEM_NO              = :ITEM_NO ");
                    db.DbPsetString("ITEM_NO", _item_no);
                }
                if (custm_item_no != "")
                {
                    strSQL.Append("   AND SD.CUSTM_ITEM_NO        = :CUSTM_ITEM_NO ");
                    db.DbPsetString("CUSTMITEM_NO", _custm_item_no);
                }
                if (deliv_beg_date != 0)
                {
                    strSQL.Append("   AND SD.DELIV_DATE           >= :DELIV_BEG_DATE ");
                    db.DbPsetInt("DELIV_BEG_DATE", _deliv_beg_date);
                }
                if (deliv_end_date != 0)
                {
                    strSQL.Append("   AND SD.DELIV_DATE           <= :DELIV_END_DATE ");
                    db.DbPsetInt("DELIV_END_DATE", _deliv_end_date);
                }
                if (order_recv_beg_date != 0)
                {
                    strSQL.Append("   AND S.ORDER_RECV_DATE       >= :ORDER_RECV_BEG_DATE ");
                    db.DbPsetInt("ORDER_RECV_BEG_DATE", _order_recv_beg_date);
                }
                if (order_recv_end_date != 0)
                {
                    strSQL.Append("   AND S.ORDER_RECV_DATE       <= :ORDER_RECV_END_DATE ");
                    db.DbPsetInt("ORDER_RECV_END_DATE", _order_recv_end_date);
                }
                if (ship_req_beg_date != 0)
                {
                    strSQL.Append("   AND SD.SHIP_REQ_DATE         >= :SHIP_REQ_BEG_DATE ");
                    db.DbPsetInt("SHIP_REQ_BEG_DATE", _ship_req_beg_date);
                }
                if (ship_req_end_date != 0)
                {
                    strSQL.Append("   AND SD.SHIP_REQ_DATE         <= :SHIP_REQ_END_DATE ");
                    db.DbPsetInt("SHIP_REQ_END_DATE", _ship_req_end_date);
                }


            }
            else
            {
                strSQL.Append(" FROM SALES_ORDER S ");
                strSQL.Append(" LEFT OUTER JOIN SALES_ORDER_DETAIL SD ON S.ORDER_NO = SD.ORDER_NO");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER C ON S.CUST_CD = C.CUST_CD AND S.CUST_SUB_CD = C.CUST_SUB_CD ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER SHIP_TO ON S.SHIP_TO_CD = SHIP_TO.CUST_CD AND S.SHIP_TO_SUB_CD = SHIP_TO.CUST_SUB_CD ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON SD.ITEM_NO = I.ITEM_NO");

                db.DbParametersClear();

                strSQL.Append(" WHERE  ");
                strSQL.Append("   S.ORDER_STATUS                 <     90 ");
                strSQL.Append("   AND SD.ORDER_STATUS                <     90 ");
                if (order_no != "")
                {
                    strSQL.Append("   AND S.ORDER_NO              = @ORDER_NO ");
                    db.DbPsetString("@ORDER_NO", _order_no);
                }
                if (cust_order_no != "")
                {
                    strSQL.Append("   AND S.CUST_ORDER_NO         = @CUST_ORDER_NO ");
                    db.DbPsetString("@CUST_ORDER_NO", _cust_order_no);
                }
                if (cust_cd != "")
                {
                    strSQL.Append("   AND S.CUST_CD               = @CUST_CD ");
                    db.DbPsetString("@CUST_CD", _cust_cd);
                }
                if (cust_sub_cd != "")
                {
                    strSQL.Append("   AND S.CUST_SUB_CD           = @CUST_SUB_CD ");
                    db.DbPsetString("@CUST_SUB_CD", _cust_sub_cd);
                }
                if (ship_to_cd != "")
                {
                    strSQL.Append("   AND S.SHIP_TO_CD            = @SHIP_TO_CD ");
                    db.DbPsetString("@SHIP_TO_CD", _ship_to_cd);
                }
                if (ship_to_sub_cd != "")
                {
                    strSQL.Append("   AND S.SHIP_TO_SUB_CD        = @SHIP_TO_SUB_CD ");
                    db.DbPsetString("@SHIP_TO_SUB_CD", _ship_to_sub_cd);
                }
                if (item_no != "")
                {
                    //strSQL.Append("   AND SD.ITEM_NO              = @ITEM_NO ");  //Del 2016.10.05 Ubiq-Sai
                    strSQL.Append("   AND SD.ITEM_NO           LIKE @ITEM_NO ");    //Add 2016.10.05 Ubiq-Sai
                    db.DbPsetString("@ITEM_NO", _item_no);
                }
                if (custm_item_no != "")
                {
                    strSQL.Append("   AND SD.CUSTM_ITEM_NO        = @CUSTM_ITEM_NO ");
                    db.DbPsetString("@CUSTM_ITEM_NO", _custm_item_no);
                }
                if (deliv_beg_date != 0)
                {
                    strSQL.Append("   AND SD.DELIV_DATE           >= @DELIV_BEG_DATE ");
                    db.DbPsetInt("@DELIV_BEG_DATE", _deliv_beg_date);
                }
                if (deliv_end_date != 0)
                {
                    strSQL.Append("   AND SD.DELIV_DATE           <= @DELIV_END_DATE ");
                    db.DbPsetInt("@DELIV_END_DATE", _deliv_end_date);
                }
                if (order_recv_beg_date != 0)
                {
                    strSQL.Append("   AND S.ORDER_RECV_DATE       >= @ORDER_RECV_BEG_DATE ");
                    db.DbPsetInt("@ORDER_RECV_BEG_DATE", _order_recv_beg_date);
                }
                if (order_recv_end_date != 0)
                {
                    strSQL.Append("   AND S.ORDER_RECV_DATE       <= @ORDER_RECV_END_DATE ");
                    db.DbPsetInt("@ORDER_RECV_END_DATE", _order_recv_end_date);
                }
                if (ship_req_beg_date != 0)
                {
                    strSQL.Append("   AND SD.SHIP_REQ_DATE         >= @SHIP_REQ_BEG_DATE ");
                    db.DbPsetInt("@SHIP_REQ_BEG_DATE", _ship_req_beg_date);
                }
                if (ship_req_end_date != 0)
                {
                    strSQL.Append("   AND SD.SHIP_REQ_DATE         <= @SHIP_REQ_END_DATE ");
                    db.DbPsetInt("@SHIP_REQ_END_DATE", _ship_req_end_date);
                }
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
        /// 受注テーブル詳細の取得
        /// 
        /// 使用画面：OrdSOUpd
        /// </summary>
        public int GetSalesOrderDetail()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql            
            strSQL.Append("SELECT ");
            strSQL.Append("S.ORDER_NO,			S.CUST_ORDER_NO,		S.ORDER_STATUS,		S.PO_TYPE,			");
            strSQL.Append("S.ORDER_RECV_DATE,	S.CUST_CD,			    S.CUST_SUB_CD,		S.SHIP_TO_CD,	    ");
            strSQL.Append("S.SHIP_TO_SUB_CD,    S.ZIP_CD,	            S.COUNTRY_CD,		S.STATE,		    ");
            strSQL.Append("S.ADDRESS1,	        S.ADDRESS2,             S.ADDRESS3,	        S.ADDRESS4,			");
            strSQL.Append("S.TELNO,		        S.FAXNO,	            S.CUST_ATTN,        S.NOTIFY1,	  		");
            strSQL.Append("S.NOTIFY2,			S.REMARKS,              S.INPUT_USER_ID,	S.APPROVE_USER_ID,	");
            strSQL.Append("S.DATA_CHAR1,		S.DATA_CHAR2,			                                        ");
            strSQL.Append("S.DATA_CHAR3,		S.DATA_CHAR4,			S.DATA_CHAR5,		S.DATA_CHAR6,		");
            strSQL.Append("S.DATA_CHAR7,		S.DATA_CHAR8,			S.DATA_CHAR9,		S.DATA_CHAR10,		");
            strSQL.Append("S.DATA_NUM1,			S.DATA_NUM2,			S.DATA_NUM3,		S.DATA_NUM4,		");
            strSQL.Append("S.DATA_NUM5,			S.DATA_NUM6,			S.DATA_NUM7,		S.DATA_NUM8,		");
            strSQL.Append("S.DATA_NUM9,			S.DATA_NUM10,			S.DATA_FLAG1,		S.DATA_FLAG2,		");
            strSQL.Append("S.DATA_FLAG3,		S.DATA_FLAG4,			S.DATA_FLAG5,		S.DATA_FLAG6,		");
            strSQL.Append("S.DATA_FLAG7,		S.DATA_FLAG8,			S.DATA_FLAG9,		S.DATA_FLAG10,		");
            strSQL.Append("S.ENTRY_DATE,		S.CHG_DATE,			    S.CHG_PGM,			S.CHG_USERID,		");
            strSQL.Append("S.UPDATE_CNTR,                                                                       ");
            strSQL.Append("C.CUST_NAME, 		C.PAY_TERMS,	        C.CUR_CD,                               ");
            strSQL.Append("SHIP_TO.CUST_NAME SHIP_TO_NAME,SP.DATA_CHAR CUR_DESC                                 ");
            strSQL.Append(",ISNULL(SP.DATA_DEC,0) PRICE_DEC          ,ISNULL(SP.DATA_DEC2,0)  AMT_DEC           ");

            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM SALES_ORDER S, CUSTOMER_MASTER C,CUSTOMER_MASTER SHIP_TO,SYSTEM_PARAMETER SP ");
                strSQL.Append(" WHERE S.ORDER_NO              = :ORDER_NO ");
                strSQL.Append("   AND S.CUST_CD             = C.CUST_CD");
                strSQL.Append("   AND S.CUST_SUB_CD         = C.CUST_SUB_CD");
                strSQL.Append("   AND S.SHIP_TO_CD          = SHIP_TO.CUST_CD");
                strSQL.Append("   AND S.SHIP_TO_SUB_CD      = SHIP_TO.CUST_SUB_CD");
                strSQL.Append("   AND SP.KEY01      = 'CURRENCY_CD' ");
                strSQL.Append("   AND SP.KEY02      = C.CUR_CD ");

                db.DbParametersClear();
                db.DbPsetString("ORDER_NO", _order_no);
            }
            else
            {
                strSQL.Append(" FROM SALES_ORDER S ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER C ON S.CUST_CD = C.CUST_CD AND S.CUST_SUB_CD = C.CUST_SUB_CD ");
                strSQL.Append(" LEFT OUTER JOIN CUSTOMER_MASTER SHIP_TO ON S.SHIP_TO_CD = SHIP_TO.CUST_CD AND S.SHIP_TO_SUB_CD = SHIP_TO.CUST_SUB_CD ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER SP ON SP.KEY01 = 'CURRENCY_CD' AND SP.KEY02      = C.CUR_CD ");

                strSQL.Append(" WHERE S.ORDER_NO              = @ORDER_NO ");

                db.DbParametersClear();

                db.DbPsetString("@ORDER_NO", _order_no);
            }

            rtn = db.DbExecuteReader(strSQL.ToString());
            if (rtn == ComConst.FAILED)
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
            }
            else
            {
                _order_no = db.Row("ORDER_NO");
                _cust_order_no = db.Row("CUST_ORDER_NO");
                _order_status = int.Parse(db.Row("ORDER_STATUS"));
                _po_type = int.Parse(db.Row("PO_TYPE"));
                _order_recv_date = int.Parse(db.Row("ORDER_RECV_DATE"));
                _cust_cd = db.Row("CUST_CD");
                _cust_sub_cd = db.Row("CUST_SUB_CD");
                _ship_to_cd = db.Row("SHIP_TO_CD");
                _ship_to_sub_cd = db.Row("SHIP_TO_SUB_CD");
                _zip_cd = db.Row("ZIP_CD");     //Add by ubiq-chen 2013.05.02
                _country_cd = db.Row("COUNTRY_CD");
                _state = db.Row("STATE");
                _address1 = db.Row("ADDRESS1");
                _address2 = db.Row("ADDRESS2");
                _address3 = db.Row("ADDRESS3");
                _address4 = db.Row("ADDRESS4");
                _telno = db.Row("TELNO");
                _faxno = db.Row("FAXNO");
                _cust_attn = db.Row("CUST_ATTN");
                _notify1 = db.Row("NOTIFY1");
                _notify2 = db.Row("NOTIFY2");
                _remarks = db.Row("REMARKS");
                _input_user_id = db.Row("INPUT_USER_ID");
                _approve_user_id = db.Row("APPROVE_USER_ID");
                _data_char1 = db.Row("DATA_CHAR1");
                _data_char2 = db.Row("DATA_CHAR2");
                _data_char3 = db.Row("DATA_CHAR3");
                _data_char4 = db.Row("DATA_CHAR4");
                _data_char5 = db.Row("DATA_CHAR5");
                _data_char6 = db.Row("DATA_CHAR6");
                _data_char7 = db.Row("DATA_CHAR7");
                _data_char8 = db.Row("DATA_CHAR8");
                _data_char9 = db.Row("DATA_CHAR9");
                _data_char10 = db.Row("DATA_CHAR10");
                _data_num1 = double.Parse(db.Row("DATA_NUM1"));
                _data_num2 = double.Parse(db.Row("DATA_NUM2"));
                _data_num3 = double.Parse(db.Row("DATA_NUM3"));
                _data_num4 = double.Parse(db.Row("DATA_NUM4"));
                _data_num5 = double.Parse(db.Row("DATA_NUM5"));
                _data_num6 = double.Parse(db.Row("DATA_NUM6"));
                _data_num7 = double.Parse(db.Row("DATA_NUM7"));
                _data_num8 = double.Parse(db.Row("DATA_NUM8"));
                _data_num9 = double.Parse(db.Row("DATA_NUM9"));
                _data_num10 = double.Parse(db.Row("DATA_NUM10"));
                _data_flag1 = int.Parse(db.Row("DATA_FLAG1"));
                _data_flag2 = int.Parse(db.Row("DATA_FLAG2"));
                _data_flag3 = int.Parse(db.Row("DATA_FLAG3"));
                _data_flag4 = int.Parse(db.Row("DATA_FLAG4"));
                _data_flag5 = int.Parse(db.Row("DATA_FLAG5"));
                _data_flag6 = int.Parse(db.Row("DATA_FLAG6"));
                _data_flag7 = int.Parse(db.Row("DATA_FLAG7"));
                _data_flag8 = int.Parse(db.Row("DATA_FLAG8"));
                _data_flag9 = int.Parse(db.Row("DATA_FLAG9"));
                _data_flag10 = int.Parse(db.Row("DATA_FLAG10"));
                _cust_name = db.Row("CUST_NAME");
                _pay_terms = db.Row("PAY_TERMS");
                _cur_cd = db.Row("CUR_CD");
                _ship_to_name = db.Row("SHIP_TO_NAME");
                _cur_desc = db.Row("CUR_DESC");
                _entry_date = DateTime.Parse(db.Row("ENTRY_DATE"));
                _chg_date = DateTime.Parse(db.Row("CHG_DATE"));
                _chg_pgm = db.Row("CHG_PGM");
                _chg_user_id = db.Row("CHG_USERID");
                _update_cntr = int.Parse(db.Row("UPDATE_CNTR"));
                //ADD BY UBIQ-LIU 2016-7-5 →BEGIN
                _price_dec = int.Parse(db.Row("PRICE_DEC"));
                _amt_dec = int.Parse(db.Row("AMT_DEC"));
                //ADD BY UBIQ-LIU 2016-7-5 ←END
            }

            if (db.State() == ConnectionState.Open)
                db.DbClose();
            return rtn;
        }

        /// <summary>
        /// 受注テーブル一覧の取得
        /// 
        /// 使用画面：OrdSOUpd
        /// </summary>
        public DataSet GetSalesOrderDetailList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql             

            strSQL.Append("SELECT ");
            strSQL.Append("SD.ORDER_NO,			SD.ORDER_LINE_NO,		SD.ORDER_STATUS,		SD.DELIV_DATE,		");
            strSQL.Append("SD.SHIP_REQ_DATE,	SD.ITEM_NO,			    SD.CUSTM_ITEM_NO,		SD.ORDER_QTY,	    ");
            strSQL.Append("SD.UNIT_PRICE,       SD.CURRENCY CUR_CD,     SD.SHIP_WHS,		SD.ACTUAL_SHIP_QTY,		");
            strSQL.Append("SD.ACTUAL_SHIP_DATE,	SD.ACTUAL_RETURN_QTY,   SD.OSI_STATUS,	    SD.ALLOC_STATUS,		");
            strSQL.Append("SD.JOC_CD,		    SD.SHIP_CNT,	  		                                            ");
            strSQL.Append("SD.DATA_CHAR1,		SD.DATA_CHAR2,			                                            ");
            strSQL.Append("SD.DATA_CHAR3,		SD.DATA_CHAR4,			SD.DATA_CHAR5,		SD.DATA_CHAR6,			");
            strSQL.Append("SD.DATA_CHAR7,		SD.DATA_CHAR8,			SD.DATA_CHAR9,		SD.DATA_CHAR10,		    ");
            strSQL.Append("SD.DATA_NUM1,		SD.DATA_NUM2,			SD.DATA_NUM3,		SD.DATA_NUM4,			");
            strSQL.Append("SD.DATA_NUM5,		SD.DATA_NUM6,			SD.DATA_NUM7,		SD.DATA_NUM8,			");
            strSQL.Append("SD.DATA_NUM9,		SD.DATA_NUM10,			SD.DATA_FLAG1,		SD.DATA_FLAG2,			");
            strSQL.Append("SD.DATA_FLAG3,		SD.DATA_FLAG4,			SD.DATA_FLAG5,		SD.DATA_FLAG6,			");
            strSQL.Append("SD.DATA_FLAG7,		SD.DATA_FLAG8,			SD.DATA_FLAG9,			SD.DATA_FLAG10,		");
            strSQL.Append("SD.ENTRY_DATE,		SD.CHG_DATE,			    SD.CHG_PGM,			SD.CHG_USERID,		");
            strSQL.Append("SD.UPDATE_CNTR,      'EXIST' MARK,                                                       ");//ADD UPDFLAG MARK
            strSQL.Append("I.ITEM_DESC,         I.PO_TYPE,     I.ITEM_ADDN_ORDER_RATIO,     S.DATA_CHAR CUR_DESC    ");//手配区分と添加率を追加
            strSQL.Append(",ISNULL(S.DATA_DEC,0) PRC_DEC,		ISNULL(S.DATA_DEC2,0) AMT_DEC 						");//ADD BY UBIQ-LIU 2016-7-18

            if (_db_type == "ORACLE")
            {
                db.DbParametersClear();

                strSQL.Append(" FROM SALES_ORDER_DETAIL SD, ITEM_MASTER I ");
                strSQL.Append(" WHERE  SD.ITEM_NO = I.ITEM_NO");

                strSQL.Append("  AND SD.ORDER_NO              = :ORDER_NO ");
                db.DbPsetString("ORDER_NO", _order_no);
            }
            else
            {
                strSQL.Append(" FROM SALES_ORDER_DETAIL SD                                                              ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON SD.ITEM_NO = I.ITEM_NO                                 ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S ON S.KEY01 = 'CURRENCY_CD' AND S.KEY02 = SD.CURRENCY ");

                db.DbParametersClear();
                strSQL.Append(" WHERE  ");
                strSQL.Append("  SD.ORDER_NO              = @ORDER_NO ");
                strSQL.Append(" ORDER BY SD.ORDER_LINE_NO ");   //Add 2015.05.27 Ubiq-Sai

                db.DbPsetString("@ORDER_NO", _order_no);
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
        /// 受注テーブル詳細の取得
        /// 
        /// 使用画面：OrdSOUpd
        /// </summary>
        public int GetSalesOrderDetail1()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql            
            strSQL.Append("SELECT ");
            strSQL.Append("SD.ORDER_NO,			SD.ORDER_LINE_NO,		SD.ORDER_STATUS,		SD.DELIV_DATE,			");
            strSQL.Append("SD.SHIP_REQ_DATE,	SD.ITEM_NO,			    SD.CUSTM_ITEM_NO,		SD.ORDER_QTY,	        ");
            strSQL.Append("SD.UNIT_PRICE,       SD.CURRENCY CUR_CD,     SD.SHIP_WHS,			                        ");
            //strSQL.Append("SD.ACTUAL_SHIP_QTY,	SD.ACTUAL_SHIP_DATE,	    SD.ACTUAL_RETURN_QTY,  	");
            //strSQL.Append(" SD.OSI_STATUS,	    SD.ALLOC_STATUS,		SD.JOC_CD,		        SD.SHIP_CNT,	  		");
            strSQL.Append("SD.DATA_CHAR1,		SD.DATA_CHAR2,			");
            strSQL.Append("SD.DATA_CHAR3,		SD.DATA_CHAR4,			SD.DATA_CHAR5,		SD.DATA_CHAR6,			    ");
            strSQL.Append("SD.DATA_CHAR7,		SD.DATA_CHAR8,			SD.DATA_CHAR9,		SD.DATA_CHAR10,		        ");
            strSQL.Append("SD.DATA_NUM1,		SD.DATA_NUM2,			SD.DATA_NUM3,		SD.DATA_NUM4,			    ");
            strSQL.Append("SD.DATA_NUM5,		SD.DATA_NUM6,			SD.DATA_NUM7,		SD.DATA_NUM8,			    ");
            strSQL.Append("SD.DATA_NUM9,		SD.DATA_NUM10,			SD.DATA_FLAG1,		SD.DATA_FLAG2,			    ");
            strSQL.Append("SD.DATA_FLAG3,		SD.DATA_FLAG4,			SD.DATA_FLAG5,		SD.DATA_FLAG6,			    ");
            strSQL.Append("SD.DATA_FLAG7,		SD.DATA_FLAG8,			SD.DATA_FLAG9,		SD.DATA_FLAG10,		        ");
            strSQL.Append("SD.ENTRY_DATE,		SD.CHG_DATE,			SD.CHG_PGM,			SD.CHG_USERID,			    ");
            strSQL.Append("SD.UPDATE_CNTR,                                                                              ");
            strSQL.Append("I.ITEM_DESC,         S.DATA_CHAR CUR_DESC                                                    ");

            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM  SALES_ORDER_DETAIL SD, ITEM_MASTER I ");
                strSQL.Append(" WHERE SD.ORDER_NO              = :ORDER_NO ");
                strSQL.Append(" AND SD.ORDER_LINE_NO         = :ORDER_LINE_NO ");
                strSQL.Append("   AND SD.ITEM_NO            = I.ITEM_NO");


                db.DbParametersClear();
                db.DbPsetString("ORDER_NO", _order_no);
                db.DbPsetInt("ORDER_LINE_NO", _order_line_no);

            }
            else
            {
                strSQL.Append(" FROM SALES_ORDER_DETAIL SD ");
                strSQL.Append(" LEFT OUTER JOIN ITEM_MASTER I ON SD.ITEM_NO = I.ITEM_NO");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S ON S.KEY01 = 'CURRENCY_CD' AND S.KEY02 = SD.CURRENCY ");

                strSQL.Append(" WHERE SD.ORDER_NO              = @ORDER_NO ");
                strSQL.Append("   AND SD.ORDER_LINE_NO         = @ORDER_LINE_NO ");

                db.DbParametersClear();

                db.DbPsetString("@ORDER_NO", _order_no);
                db.DbPsetInt("@ORDER_LINE_NO", _order_line_no);
            }

            rtn = db.DbExecuteReader(strSQL.ToString());
            if (rtn == ComConst.FAILED)
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
            }
            else
            {
                _order_no = db.Row("ORDER_NO");
                _order_line_no = int.Parse(db.Row("ORDER_LINE_NO"));
                _order_status = int.Parse(db.Row("ORDER_STATUS"));
                _deliv_date = int.Parse(db.Row("DELIV_DATE"));
                _ship_req_date = int.Parse(db.Row("SHIP_REQ_DATE"));
                _item_no = db.Row("ITEM_NO");
                _custm_item_no = db.Row("CUSTM_ITEM_NO");
                _order_qty = double.Parse(db.Row("ORDER_QTY"));
                _unit_price = double.Parse(db.Row("UNIT_PRICE"));
                _cur_cd = db.Row("CUR_CD");
                _ship_whs = db.Row("SHIP_WHS");
                //_actual_ship_qty = db.Row("ACTUAL_SHIP_QTY");
                //_actual_ship_date = db.Row("ACTUAL_SHIP_DATE");
                //_actual_return_qty = db.Row("ACTUAL_RETURN_QTY");
                //_osi_status = db.Row("OSI_STATUS");
                //_alloc_status = db.Row("ALLOC_STATUS");
                //_joc_cd = db.Row("JOC_CD");
                //_ship_cnt = db.Row("SHIP_CNT");

                _data_char1 = db.Row("DATA_CHAR1");
                _data_char2 = db.Row("DATA_CHAR2");
                _data_char3 = db.Row("DATA_CHAR3");
                _data_char4 = db.Row("DATA_CHAR4");
                _data_char5 = db.Row("DATA_CHAR5");
                _data_char6 = db.Row("DATA_CHAR6");
                _data_char7 = db.Row("DATA_CHAR7");
                _data_char8 = db.Row("DATA_CHAR8");
                _data_char9 = db.Row("DATA_CHAR9");
                _data_char10 = db.Row("DATA_CHAR10");
                _data_num1 = double.Parse(db.Row("DATA_NUM1"));
                _data_num2 = double.Parse(db.Row("DATA_NUM2"));
                _data_num3 = double.Parse(db.Row("DATA_NUM3"));
                _data_num4 = double.Parse(db.Row("DATA_NUM4"));
                _data_num5 = double.Parse(db.Row("DATA_NUM5"));
                _data_num6 = double.Parse(db.Row("DATA_NUM6"));
                _data_num7 = double.Parse(db.Row("DATA_NUM7"));
                _data_num8 = double.Parse(db.Row("DATA_NUM8"));
                _data_num9 = double.Parse(db.Row("DATA_NUM9"));
                _data_num10 = double.Parse(db.Row("DATA_NUM10"));
                _data_flag1 = int.Parse(db.Row("DATA_FLAG1"));
                _data_flag2 = int.Parse(db.Row("DATA_FLAG2"));
                _data_flag3 = int.Parse(db.Row("DATA_FLAG3"));
                _data_flag4 = int.Parse(db.Row("DATA_FLAG4"));
                _data_flag5 = int.Parse(db.Row("DATA_FLAG5"));
                _data_flag6 = int.Parse(db.Row("DATA_FLAG6"));
                _data_flag7 = int.Parse(db.Row("DATA_FLAG7"));
                _data_flag8 = int.Parse(db.Row("DATA_FLAG8"));
                _data_flag9 = int.Parse(db.Row("DATA_FLAG9"));
                _data_flag10 = int.Parse(db.Row("DATA_FLAG10"));
                _item_desc = db.Row("ITEM_DESC");
                _cur_desc = db.Row("CUR_DESC");
                _entry_date = DateTime.Parse(db.Row("ENTRY_DATE"));
                _chg_date = DateTime.Parse(db.Row("CHG_DATE"));
                _chg_pgm = db.Row("CHG_PGM");
                _chg_user_id = db.Row("CHG_USERID");
                _update_cntr = int.Parse(db.Row("UPDATE_CNTR"));

            }

            if (db.State() == ConnectionState.Open)
                db.DbClose();
            return rtn;
        }

        /// <summary>
        /// 报表数据的获得
        /// 
        /// 使用画面：OrdSORpt
        /// </summary>
        public DataSet GetOrdSORptList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT                                                                                              ");
            strSQL.Append(" SA.CUST_CD+'-'+SA.CUST_SUB_CD AS CUST_CD		,CU.CUST_NAME				,SA.ORDER_RECV_DATE	  ,	");
            strSQL.Append(" I.SCH_ID				    ,S.DATA_CHAR				,SA.PO_TYPE	,                               ");
            strSQL.Append(" SA.CUST_SUB_CD			    ,SA.SHIP_TO_CD+'-'+SA.SHIP_TO_SUB_CD AS SHIP_TO_CD ,	                ");
            strSQL.Append(" CU1.CUST_NAME SHIP_TO_NAME	,	                                                                    "); //Add 2016.04.05 Ubiq-Sai
            strSQL.Append(" SA.ORDER_NO					,SA.CUST_ORDER_NO			,SAD.ITEM_NO	,                           ");
            strSQL.Append(" I.ITEM_DESC				    ,SAD.ORDER_QTY				,SAD.ACTUAL_SHIP_QTY	,                   ");
            strSQL.Append(" I.ITEM_UMSR		            ,SAD.UNIT_PRICE				,SAD.UNIT_PRICE * ORDER_QTY AS AllMoney	,   ");
            strSQL.Append(" SAD.CURRENCY			    ,SAD.DELIV_DATE				,SAD.SHIP_REQ_DATE	,	                    ");
            strSQL.Append(" SAD.JOC_CD                  ,SAD.SHIP_WHS               ,W.WHS_DESC ,                               ");
            strSQL.Append(" S2.DATA_CHAR AS DATA_CHAR2  ,S3.DATA_CHAR as DATA_CHAR3                                             ");
            strSQL.Append(",ISNULL(S3.DATA_DEC,0) PRC_DEC,		ISNULL(S3.DATA_DEC2,0) AMT_DEC 						");//ADD BY UBIQ-LIU 2016-7-18
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM SALES_ORDER SA, ITEM_MASTER I,SALES_ORDER_DETAIL SAD, SYSTEM_PARAMETER S ,CUSTOMER_MASTER CU,  ");
                strSQL.Append(" WAREHOUSE_MASTER W  ,   SYSTEM_PARAMETER S2 ,SYSTEM_PARAMETER S3                                    ");
                strSQL.Append(" WHERE SA.CUST_CD = CU.CUST_CD(+)  AND SA.CUST_SUB_CD=CU.CUST_SUB_CD                                 ");
                strSQL.Append(" AND SA.ITEM_NO = I.ITEM_NO(+)                                                                       ");
                strSQL.Append(" AND SA.ORDER_NO = SAD.ORDER_NO(+)                                                                   ");
                strSQL.Append(" AND S.KEY01='SCH_ID' AND S.KEY02=I.SCH_ID(+)                                                        ");
                strSQL.Append(" AND SAD.SHIP_WHS=W.WHS_CD(+)                                                                        ");// add by zhao 2009/01/05
                strSQL.Append(" AND S2.KEY01='ITEM_UMSR' AND S2.KEY02=I.ITEM_UMSR(+)                                                ");
                strSQL.Append(" AND S3.KEY01='CURRENCY' AND  S3.KEY02=SAD.CURRENCY(+)                                               ");

                db.DbParametersClear();
                if (_cust_cd != "")
                {
                    strSQL.Append("   AND SA.CUST_CD      = :CUST_CD");
                    db.DbPsetString("@CUST_CD", _cust_cd);
                }
                if (_cust_sub_cd != "")
                {
                    strSQL.Append("   AND SA.CUST_SUB_CD      = :CUST_SUB_CD");
                    db.DbPsetString("CUST_SUB_CD", _cust_sub_cd);
                }
                if (_sch_id != "")
                {
                    strSQL.Append(" AND I.SCH_ID = :SCH_ID");

                    db.DbPsetString("SCH_ID", _sch_id);
                }
                if (_beg_date != 0)
                {
                    strSQL.Append("   AND SA.ORDER_RECV_DATE       >= :BEG_DATE");
                    strSQL.Append("   AND SA.ORDER_RECV_DATE      <= :END_DATE");

                    db.DbPsetInt("BEG_DATE", _beg_date);
                    db.DbPsetInt("END_DATE", _end_date);
                }

            }
            else
            {
                strSQL.Append(" FROM SALES_ORDER SA                                                                          ");
                strSQL.Append(" LEFT JOIN CUSTOMER_MASTER CU ON SA.CUST_CD=CU.CUST_CD AND SA.CUST_SUB_CD=CU.CUST_SUB_CD      ");
                strSQL.Append(" LEFT JOIN CUSTOMER_MASTER CU1 ON SA.SHIP_TO_CD=CU1.CUST_CD AND SA.SHIP_TO_SUB_CD=CU1.CUST_SUB_CD ");    //Add 2016.04.05 Ubiq-Sai
                strSQL.Append(" LEFT JOIN SALES_ORDER_DETAIL SAD  ON  SA.ORDER_NO=SAD.ORDER_NO                               ");
                strSQL.Append(" LEFT JOIN ITEM_MASTER I ON SAD.ITEM_NO = I.ITEM_NO                                           ");
                strSQL.Append(" LEFT JOIN SYSTEM_PARAMETER  S ON S.KEY01='SCH_ID' AND S.KEY02=I.SCH_ID                       ");
                strSQL.Append(" LEFT JOIN WAREHOUSE_MASTER W  ON SAD.SHIP_WHS=W.WHS_CD                                       ");// add by zhao 2009/01/05
                strSQL.Append(" LEFT JOIN SYSTEM_PARAMETER S2 ON S2.KEY01='ITEM_UMSR' AND S2.KEY02=I.ITEM_UMSR               ");
                strSQL.Append(" LEFT JOIN SYSTEM_PARAMETER S3 ON S3.KEY01='CURRENCY_CD' AND  S3.KEY02=SAD.CURRENCY            ");
                strSQL.Append(" WHERE 1=1                                                                                    ");

                db.DbParametersClear();
                if (_cust_cd != "")
                {
                    strSQL.Append("   AND SA.CUST_CD =@CUST_CD");
                    db.DbPsetString("@CUST_CD", _cust_cd);
                }
                if (_cust_sub_cd != "")
                {
                    strSQL.Append("   AND SA.CUST_SUB_CD      = @CUST_SUB_CD");
                    db.DbPsetString("@CUST_SUB_CD", _cust_sub_cd);
                }
                if (_sch_id != "")
                {
                    strSQL.Append(" AND I.SCH_ID = @SCH_ID");
                    db.DbPsetString("@SCH_ID", _sch_id);
                }
                if (_beg_date != 0)
                {
                    strSQL.Append("   AND SA.ORDER_RECV_DATE       >= @BEG_DATE");
                    db.DbPsetInt("@BEG_DATE", _beg_date);

                }
                if (_end_date != 0)
                {
                    strSQL.Append("   AND SA.ORDER_RECV_DATE      <= @END_DATE");
                    db.DbPsetInt("@END_DATE", _end_date);
                }

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
        /// 返品処理
        /// 
        /// 使用画面：OrdReturn
        /// </summary>
        public int GetOrdReturnDetail()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            strSQL.Append(" SELECT                                                                                     ");
            strSQL.Append(" SOD.ITEM_NO                        ,I.ITEM_DESC                 ,SO.CUST_CD              , ");
            strSQL.Append(" SO.CUST_SUB_CD                     ,C.CUST_NAME                 ,SOD.ACTUAL_SHIP_DATE    , ");
            strSQL.Append(" SO.SHIP_TO_CD                      ,SO.SHIP_TO_SUB_CD           ,SOD.ACTUAL_SHIP_QTY     , ");
            strSQL.Append(" S2.DATA_CHAR AS  UMSR_DESC                                                                 ");
            strSQL.Append(" ,SOD.UNIT_PRICE ,SOD.CURRENCY,S1.DATA_CHAR CUR_NAME                                        ");//ADD BY UBIQ-LIU 2015/05/03
            strSQL.Append(",ISNULL(S1.DATA_DEC,0) PRICE_DEC          ,ISNULL(S1.DATA_DEC2,0)  AMT_DEC                  ");//ADD BY UBIQ-LIU 2016-7-13

            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM SALES_ORDER SO, ITEM_MASTER I,SALES_ORDER_DETAIL SOD, CUSTOMER_MASTER C    ");
                strSQL.Append(" WHERE SO.CUST_CD   = C.CUST_CD(+)                                               ");
                strSQL.Append(" AND SO.ITEM_NO     = I.ITEM_NO(+)                                               ");
                strSQL.Append(" AND SO.ORDER_NO    = SOD.ORDER_NO(+)                                            ");
                strSQL.Append(" AND SOD.ORDER_STATUS    !='99'                                                  ");
                strSQL.Append(" AND SOD.ACTUAL_SHIP_QTY  > 0                                                    ");
                strSQL.Append(" AND SOD.ORDER_NO      = @ORDER_NO                                               ");
                strSQL.Append(" AND SOD.ORDER_LINE_NO      = @ORDER_LINE_NO                                     ");

                db.DbParametersClear();

                db.DbPsetString("@ORDER_NO", _order_no);
                db.DbPsetInt("@ORDER_LINE_NO", _order_line_no);

            }
            else
            {
                strSQL.Append(" FROM SALES_ORDER SO                                                             ");
                strSQL.Append(" LEFT JOIN CUSTOMER_MASTER C ON SO.CUST_CD=C.CUST_CD                             ");
                strSQL.Append(" LEFT JOIN SALES_ORDER_DETAIL SOD  ON  SO.ORDER_NO=SOD.ORDER_NO                  ");
                strSQL.Append(" LEFT JOIN ITEM_MASTER I ON SOD.ITEM_NO = I.ITEM_NO                              ");
                strSQL.Append(" LEFT JOIN SYSTEM_PARAMETER S2 ON S2.KEY01='ITEM_UMSR' AND S2.KEY02=I.ITEM_UMSR  ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY01 = 'CURRENCY_CD'					");//ADD BY UBIQ-LIU 2015/05/03
                strSQL.Append(" AND S1.KEY02 = SOD.CURRENCY														");
                strSQL.Append(" WHERE SOD.ORDER_STATUS    !='99'                                                ");
                strSQL.Append(" AND SOD.ACTUAL_SHIP_QTY  > 0                                                    ");
                strSQL.Append(" AND SOD.ORDER_NO      = @ORDER_NO                                               ");
                strSQL.Append(" AND SOD.ORDER_LINE_NO      = @ORDER_LINE_NO                                     ");

                db.DbParametersClear();

                db.DbPsetString("@ORDER_NO", _order_no);
                db.DbPsetInt("@ORDER_LINE_NO", _order_line_no);


            }
            rtn = db.DbExecuteReader(strSQL.ToString());
            if (rtn == ComConst.FAILED)
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
            }
            else
            {
                _item_no = db.Row("ITEM_NO");
                _item_desc = db.Row("ITEM_DESC");
                _cust_cd = db.Row("CUST_CD");
                _cust_sub_cd = db.Row("CUST_SUB_CD");
                _cust_name = db.Row("CUST_NAME");
                _ship_to_cd = db.Row("SHIP_TO_CD");
                _ship_to_sub_cd = db.Row("SHIP_TO_SUB_CD");
                _actual_ship_qty = int.Parse(db.Row("ACTUAL_SHIP_QTY"));
                _actual_ship_date = int.Parse(db.Row("ACTUAL_SHIP_DATE"));
                _umsr_desc = db.Row("UMSR_DESC");
                _unit_price = double.Parse(db.Row("UNIT_PRICE"));
                _cur_cd = db.Row("CURRENCY");
                _cur_desc = db.Row("CUR_NAME");
                //ADD BY UBIQ-LIU 2016-7-13
                _price_dec = int.Parse(db.Row("PRICE_DEC"));
                _amt_dec = int.Parse(db.Row("AMT_DEC"));
            }
            if (db.State() == ConnectionState.Open)
                db.DbClose();
            return rtn;
        }

        /// <summary>
        /// 返品取消
        /// 使用画面：OrdReturnCancel
        /// </summary>
        public DataSet GetOrdReturnCancelList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT                                                                                                                                  ");
            strSQL.Append(" SA.RETURN_NO                 ,(SA.CUST_CD+'-'+SA.CUST_SUB_CD) AS CUST_CD              ,C.CUST_NAME ,                                        ");
            strSQL.Append(" (SAD.ORDER_NO+CONVERT( VARCHAR(3), SAD.ORDER_LINE_NO)) AS ORDER_NO                ,SA.ITEM_NO             ,I.ITEM_DESC ,                ");
            strSQL.Append(" SA.RETURN_QTY                ,SA.RETURN_DATE             ,SA.RETURN_WHS           ,W.WHS_DESC                                           ");
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM SALES_RETURN SA, ITEM_MASTER I,SALES_ORDER_DETAIL SAD, CUSTOMER_MASTER C ，");
                strSQL.Append(" WAREHOUSE_MASTER W                                                              ");
                strSQL.Append(" WHERE SA.CUST_CD      = C.CUST_CD(+)                                            ");
                strSQL.Append(" AND SA.CUST_SUB_CD    = C.CUST_SUB_CD                                           ");
                strSQL.Append(" AND SA.ITEM_NO        = I.ITEM_NO(+)                                            ");
                strSQL.Append(" AND SA.RETURN_WHS     = W.WHS_CD(+)                                             ");
                strSQL.Append(" AND SA.ORDER_NO       = SAD.ORDER_NO(+)                                         ");
                strSQL.Append(" AND SA.ORDER_LINE_NO  = SAD.ORDER_LINE_NO                                       ");
                strSQL.Append(" AND SA.ORDER_STATUS   <= :1                                                     ");

                db.DbParametersClear();
                if (_return_no != "")
                {
                    strSQL.Append("   AND SA.RETURN_NO      = ：RETURN_NO");
                    db.DbPsetString("RETURN_NO", _return_no);
                }
                if (_order_no != "")
                {
                    strSQL.Append("   AND SA.ORDER_NO      = ：ORDER_NO");
                    db.DbPsetString("ORDER_NO", _order_no);
                }
                if (_cust_cd != "")
                {
                    strSQL.Append("   AND SA.CUST_CD      = ：CUST_CD");
                    db.DbPsetString("CUST_CD", _cust_cd);
                }
                if (_cust_sub_cd != "")
                {
                    strSQL.Append("   AND SA.CUST_SUB_CD      = ：CUST_SUB_CD");
                    db.DbPsetString("CUST_SUB_CD", _cust_sub_cd);
                }
                if (_item_no != "")
                {
                    strSQL.Append("   AND SA.ITEM_NO     = ：ITEM_NO ");
                    db.DbPsetString("ITEM_NO", _item_no);
                }
                if (_return_date1 != 0)
                {
                    strSQL.Append("   AND SA.RETURN_DATE     >= ：RETURN_DATE1 ");
                    db.DbPsetDouble("RETURN_DATE1", _return_date1);

                }
                if (_return_date2 != 0)
                {
                    strSQL.Append(" AND SA.RETURN_DATE     =< ：RETURN_DATE2 ");
                    db.DbPsetDouble("RETURN_DATE2", _return_date1);
                }

            }
            else
            {
                strSQL.Append(" FROM SALES_RETURN SA                                                ");
                strSQL.Append(" LEFT JOIN CUSTOMER_MASTER C ON SA.CUST_CD=C.CUST_CD                 ");
                strSQL.Append(" AND SA.CUST_SUB_CD       = C.CUST_SUB_CD                            ");
                strSQL.Append(" LEFT JOIN ITEM_MASTER I  ON SA.ITEM_NO=I.ITEM_NO                    ");
                strSQL.Append(" LEFT JOIN WAREHOUSE_MASTER W  ON SA.RETURN_WHS=W.WHS_CD             ");
                strSQL.Append(" LEFT JOIN SALES_ORDER_DETAIL SAD ON SA.ORDER_NO=SAD.ORDER_NO        ");
                strSQL.Append(" AND SA.ORDER_LINE_NO       = SAD.ORDER_LINE_NO                      ");
                strSQL.Append(" WHERE SA.ORDER_STATUS   <= 1                                        ");

                db.DbParametersClear();
                if (_return_no != "")
                {
                    strSQL.Append("   AND SA.RETURN_NO      = @RETURN_NO");
                    db.DbPsetString("@RETURN_NO", _return_no);
                }
                if (_order_no != "")
                {
                    strSQL.Append("   AND SA.ORDER_NO      = @ORDER_NO");
                    db.DbPsetString("@ORDER_NO", _order_no);
                }
                if (_cust_cd != "")
                {
                    strSQL.Append("   AND SA.CUST_CD      = @CUST_CD");
                    db.DbPsetString("@CUST_CD", _cust_cd);
                }
                if (_cust_sub_cd != "")
                {
                    strSQL.Append("   AND SA.CUST_SUB_CD      = @CUST_SUB_CD");
                    db.DbPsetString("@CUST_SUB_CD", _cust_sub_cd);
                }
                if (_item_no != "")
                {
                    //strSQL.Append("   AND SA.ITEM_NO     = @ITEM_NO ");   //Del 2017.03.01 Ubiq-Sai
                    strSQL.Append("   AND SA.ITEM_NO  LIKE @ITEM_NO ");     //Add 2017.03.01 Ubiq-Sai
                    db.DbPsetString("@ITEM_NO", _item_no);
                }
                if (_return_date1 != 0)
                {
                    strSQL.Append("   AND SA.RETURN_DATE     >= @RETURN_DATE1 ");
                    db.DbPsetInt("@RETURN_DATE1", _return_date1);

                }
                if (_return_date2 != 0)
                {
                    strSQL.Append(" AND SA.RETURN_DATE     <= @RETURN_DATE2 ");
                    db.DbPsetInt("@RETURN_DATE2", _return_date2);
                }

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

        //-->ADD BY UBIQ-SUO 2011/1/28
        /// <summary>
        /// 販売単価検索
        /// 
        /// 使用画面：SrchUnitPrice
        /// </summary>
        public DataSet GetUnitPriceList(int mode)
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();
            if (mode == 1)
            {
                _cust_cd = "*";
            }

            //--- sql
            strSQL.Append(" SELECT                                                                             ");
            strSQL.Append(" SPM.BEG_EFF_DATE, SPM.END_EFF_DATE, SPM.CUST_CD,	CT.CUST_NAME, SPM.EXP_TYPE,    ");
            strSQL.Append(" SPM.SALES_PRC, SPM.CURRENCY, S.DATA_CHAR, SPM.CUSTM_ITEM_NO	                ");
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM SALES_PRICE_MASTER SPM, CUSTOMER_MASTER CM,SYSTEM_PARAMETER S");
                strSQL.Append(" WHERE SPM.CUST_CD = CM.CUST_CD(+)  AND SA.CUST_SUB_CD=CU.CUST_SUB_CD                                 ");
                strSQL.Append(" AND S.KEY01='CURRENCY' AND  S.KEY02=SPM.CURRENCY(+)                                               ");
                strSQL.Append(" AND SPM.BEG_EFF_DATE <= CONVERT(int,CONVERT(NVARCHAR(12),GETDATE(),112))                          ");
                strSQL.Append(" AND SPM.END_EFF_DATE >= CONVERT(int,CONVERT(NVARCHAR(12),GETDATE(),112))                          ");
                if (_cust_cd != "")
                {
                    strSQL.Append(" AND SPM.CUST_CD = @CUST_CD                                               ");
                    db.DbPsetString("@CUST_CD", _cust_cd);
                }
                if (_item_no != "")
                {
                    strSQL.Append(" AND SPM.ITEM_NO = @ITEM_NO                                               ");
                    db.DbPsetString("@ITEM_NO", _item_no);
                }
            }
            else
            {
                strSQL.Append(" FROM SALES_PRICE_MASTER SPM                                                                          ");
                strSQL.Append(" LEFT JOIN (SELECT  A.CUST_CD,A.CUST_NAME FROM CUSTOMER_MASTER A  ");
                strSQL.Append(" INNER JOIN (SELECT CUST_CD,MIN(CUST_SUB_CD) CUST_SUB_CD FROM CUSTOMER_MASTER GROUP BY CUST_CD) B ON A.CUST_CD=B.CUST_CD ");
                strSQL.Append(" AND A.CUST_SUB_CD = B.CUST_SUB_CD) CT ON SPM.CUST_CD = CT.CUST_CD");
                strSQL.Append(" LEFT JOIN SYSTEM_PARAMETER S ON S.KEY01='CURRENCY_CD' AND  S.KEY02=SPM.CURRENCY            ");
                strSQL.Append(" WHERE SPM.BEG_EFF_DATE <= CONVERT(int,CONVERT(NVARCHAR(12),GETDATE(),112))                          ");
                strSQL.Append(" AND SPM.END_EFF_DATE >= CONVERT(int,CONVERT(NVARCHAR(12),GETDATE(),112))                          ");
                db.DbParametersClear();
                if (_cust_cd != "")
                {
                    strSQL.Append(" AND SPM.CUST_CD = @CUST_CD                                               ");
                    db.DbPsetString("@CUST_CD", _cust_cd);
                }
                if (_item_no != "")
                {
                    strSQL.Append(" AND SPM.ITEM_NO = @ITEM_NO                                               ");
                    db.DbPsetString("@ITEM_NO", _item_no);
                }
            }
            strSQL.Append("ORDER BY BEG_EFF_DATE,CUST_CD,EXP_TYPE,CURRENCY");
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
        //<--ADD BY UBIQ-SUO 2011/1/28
    }
}
