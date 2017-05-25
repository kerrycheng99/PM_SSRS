using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.Configuration;

namespace PMClass
{
    public class Customer
    {
        #region : コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Customer()
        {
            try
            {
                _db_type = WebConfigurationManager.AppSettings["db_type"];
            }
            catch { }
        }
        public Customer(string p_userid, int p_lang)
        {
            _chg_userid = p_userid;
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
        //protected int _lang = 1;
        protected string _cust_cd = "";
        protected string _cust_sub_cd = "";
        protected string _cust_name = "";
        protected string _cust_desc = "";
        protected string _cust_name2 = "";
        protected string _cust_desc2 = "";
        protected string _country_cd = "";
        protected int _foreign_flag = 0;
        protected string _cur_cd = "";
        protected string _ship_whs = "";
        protected string _ship_whs_desc = "";
        protected int _trans_lt = 0;
        protected string _pay_terms = "";
        protected string _ship_slip_type = "";
        protected double _eval_ratio = 0;

        protected string _cust_attn = "";
        protected string _telno = "";
        protected string _faxno = "";
        protected string _zip_cd = "";
        protected string _state = "";

        protected string _address1 = "";
        protected string _address2 = "";
        protected string _address3 = "";
        protected string _address4 = "";
        protected string _state2 = "";
        protected string _address2_1 = "";
        protected string _address2_2 = "";
        protected string _address2_3 = "";
        protected string _address2_4 = "";

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

        protected string _cur_desc = "";

        protected string _chg_pgm = "";
        protected string _chg_userid = "";
        protected int _lang = 0;
        protected int _update_cntr = 0;
        protected int _errcode = 0;
        protected string _errmsg = "";
        protected string _dbmsg = "";
        protected int _sqlcode = 0;
        protected string _sqlmsg = "";
        protected string _proc_name = "";
        protected string _strErr = "";

        protected string _whs_cd = "";
        protected string _whs_desc = "";

        protected bool _range;  //ADD BY UBIQ-SUO 2010/09/25


        protected int _price_dec = 0;
        /// <summary>
        /// 単価小数点以下桁数
        /// </summary>
        public int price_dec { get { return _price_dec; } set { _price_dec = value; } }
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
        ///
        public string cust_cd { get { return _cust_cd; } set { _cust_cd = value; } }
        public string cust_sub_cd { get { return _cust_sub_cd; } set { _cust_sub_cd = value; } }
        public string cust_name { get { return _cust_name; } set { _cust_name = value; } }
        public string cust_desc { get { return _cust_desc; } set { _cust_desc = value; } }
        public string cust_name2 { get { return _cust_name2; } set { _cust_name2 = value; } }
        public string cust_desc2 { get { return _cust_desc2; } set { _cust_desc2 = value; } }
        public string country_cd { get { return _country_cd; } set { _country_cd = value; } }
        public int foreign_flag { get { return _foreign_flag; } set { _foreign_flag = value; } }

        public string cur_cd { get { return _cur_cd; } set { _cur_cd = value; } }
        public string ship_whs { get { return _ship_whs; } set { _ship_whs = value; } }
        public string ship_whs_desc { get { return _ship_whs_desc; } set { _ship_whs_desc = value; } }
        public int trans_lt { get { return _trans_lt; } set { _trans_lt = value; } }
        public string pay_terms { get { return _pay_terms; } set { _pay_terms = value; } }
        public string ship_slip_type { get { return _ship_slip_type; } set { _ship_slip_type = value; } }
        public double eval_ratio { get { return _eval_ratio; } set { _eval_ratio = value; } }

        public string cust_attn { get { return _cust_attn; } set { _cust_attn = value; } }
        public string telno { get { return _telno; } set { _telno = value; } }
        public string faxno { get { return _faxno; } set { _faxno = value; } }
        public string zip_cd { get { return _zip_cd; } set { _zip_cd = value; } }
        public string state { get { return _state; } set { _state = value; } }

        public string address1 { get { return _address1; } set { _address1 = value; } }
        public string address2 { get { return _address2; } set { _address2 = value; } }
        public string address3 { get { return _address3; } set { _address3 = value; } }
        public string address4 { get { return _address4; } set { _address4 = value; } }
        public string state2 { get { return _state2; } set { _state2 = value; } }
        public string address2_1 { get { return _address2_1; } set { _address2_1 = value; } }
        public string address2_2 { get { return _address2_2; } set { _address2_2 = value; } }
        public string address2_3 { get { return _address2_3; } set { _address2_3 = value; } }
        public string address2_4 { get { return _address2_4; } set { _address2_4 = value; } }

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

        public string cur_desc { get { return _cur_desc; } set { _cur_desc = value; } }

        public string chg_pgm { get { return _chg_pgm; } set { _chg_pgm = value; } }
        public string chg_userid { get { return _chg_userid; } set { _chg_userid = value; } }
        public int lang { get { return _lang; } set { _lang = value; } }
        public int update_cntr { get { return _update_cntr; } set { _update_cntr = value; } }
        //public int errcode { get { return _errcode; } set { _errcode = value; } }
        public string dbmsg { get { return _dbmsg; } set { _dbmsg = value; } }
        //public int sqlcode { get { return _sqlcode; } set { _sqlcode = value; } }
        //public string sqlmsg { get { return _sqlmsg; } set { _sqlmsg = value; } }
        //public string proc_name { get { return _proc_name; } set { _proc_name = value; } }
        public string strErr { get { return _strErr; } set { _strErr = value; } }

        public string whs_cd { get { return _whs_cd; } set { _whs_cd = value; } }
        public string whs_desc { get { return _whs_desc; } set { _whs_desc = value; } }

        public bool range { get { return _range; } set { _range = value; } } //ADD BY UBIQ-SUO 2010/09/25
        #endregion

        /// <summary>
        /// 仕入先の追加
        /// 
        /// 使用画面：MstWhsMnt
        /// </summary>
        public int Insert()
        {
            ComDB db = new ComDB(_db_type);
            int rtn = 0;

            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_CUST_CD", _cust_cd, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_SUB_CD", _cust_sub_cd, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_NAME", _cust_name, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_DESC", _cust_desc, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_NAME2", _cust_name2, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_DESC2", _cust_desc2, ComConst.DB_IN);
            db.DbPsetString("@I_COUNTRY_CD", _country_cd, ComConst.DB_IN);
            db.DbPsetInt("@I_FOREIGN_FLAG", _foreign_flag, ComConst.DB_IN);
            db.DbPsetString("@I_CUR_CD", _cur_cd, ComConst.DB_IN);
            db.DbPsetString("@I_SHIP_WHS", _ship_whs, ComConst.DB_IN);
            db.DbPsetInt("@I_TRANS_LT", _trans_lt, ComConst.DB_IN);
            db.DbPsetString("@I_SHIP_SLIP_TYPE", _ship_slip_type, ComConst.DB_IN);
            db.DbPsetString("@I_PAY_TERMS", _pay_terms, ComConst.DB_IN);
            db.DbPsetDouble("@I_EVAL_RATIO", _eval_ratio, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_ATTN", _cust_attn, ComConst.DB_IN);
            db.DbPsetString("@I_TELNO", _telno, ComConst.DB_IN);
            db.DbPsetString("@I_FAXNO", _faxno, ComConst.DB_IN);
            db.DbPsetString("@I_ZIP_CD", _zip_cd, ComConst.DB_IN);
            db.DbPsetString("@I_STATE", _state, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS1", _address1, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2", _address2, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS3", _address3, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS4", _address4, ComConst.DB_IN);
            db.DbPsetString("@I_STATE2", _state2, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2_1", _address2_1, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2_2", _address2_2, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2_3", _address2_3, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2_4", _address2_4, ComConst.DB_IN);
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
            db.DbPsetString("@I_CHG_USERID", _chg_userid, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@I_UPDATE_CNTR", _update_cntr, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);

            db.DbBeginTrans();
            rtn = db.DbStored("SP_CUSTOMER_INSERT");
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
        /// 仕入先の変更
        /// 
        /// 使用画面：MstWhsMnt
        /// </summary>
        public int Update()
        {
            ComDB db = new ComDB(_db_type);
            int rtn = 0;

            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_CUST_CD", _cust_cd, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_SUB_CD", _cust_sub_cd, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_NAME", _cust_name, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_DESC", _cust_desc, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_NAME2", _cust_name2, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_DESC2", _cust_desc2, ComConst.DB_IN);
            db.DbPsetString("@I_COUNTRY_CD", _country_cd, ComConst.DB_IN);
            db.DbPsetInt("@I_FOREIGN_FLAG", _foreign_flag, ComConst.DB_IN);
            db.DbPsetString("@I_CUR_CD", _cur_cd, ComConst.DB_IN);
            db.DbPsetString("@I_SHIP_WHS", _ship_whs, ComConst.DB_IN);
            db.DbPsetInt("@I_TRANS_LT", _trans_lt, ComConst.DB_IN);
            db.DbPsetString("@I_SHIP_SLIP_TYPE", _ship_slip_type, ComConst.DB_IN);
            db.DbPsetString("@I_PAY_TERMS", _pay_terms, ComConst.DB_IN);
            db.DbPsetDouble("@I_EVAL_RATIO", _eval_ratio, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_ATTN", _cust_attn, ComConst.DB_IN);
            db.DbPsetString("@I_TELNO", _telno, ComConst.DB_IN);
            db.DbPsetString("@I_FAXNO", _faxno, ComConst.DB_IN);
            db.DbPsetString("@I_ZIP_CD", _zip_cd, ComConst.DB_IN);
            db.DbPsetString("@I_STATE", _state, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS1", _address1, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2", _address2, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS3", _address3, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS4", _address4, ComConst.DB_IN);
            db.DbPsetString("@I_STATE2", _state2, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2_1", _address2_1, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2_2", _address2_2, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2_3", _address2_3, ComConst.DB_IN);
            db.DbPsetString("@I_ADDRESS2_4", _address2_4, ComConst.DB_IN);
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
            db.DbPsetString("@I_CHG_USERID", _chg_userid, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@I_UPDATE_CNTR", _update_cntr, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);

            db.DbBeginTrans();
            rtn = db.DbStored("SP_CUSTOMER_UPDATE");
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
        /// 仕入先の削除
        /// 
        /// 使用画面：MstWhsMnt
        /// </summary>
        public int Delete()
        {
            ComDB db = new ComDB(_db_type);
            int rtn = 0;

            db.DbParametersClear();

            db.DbPsetInt("RET", rtn, ComConst.DB_RTN);
            db.DbPsetString("@I_CUST_CD", _cust_cd, ComConst.DB_IN);
            db.DbPsetString("@I_CUST_SUB_CD", _cust_sub_cd, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_PGM", _chg_pgm, ComConst.DB_IN);
            db.DbPsetString("@I_CHG_USERID", _chg_userid, ComConst.DB_IN);
            db.DbPsetInt("@I_LANG", _lang, ComConst.DB_IN);
            db.DbPsetInt("@I_UPDATE_CNTR", _update_cntr, ComConst.DB_IN);
            db.DbPsetInt("@O_ERRCODE", _errcode, ComConst.DB_OUT);
            db.DbPsetString("@O_MSG", _errmsg, ComConst.DB_OUT);
            db.DbPsetInt("@O_SQLCODE", _sqlcode, ComConst.DB_OUT);
            db.DbPsetString("@O_SQLMSG", _dbmsg, ComConst.DB_OUT);
            db.DbPsetString("@O_PROC_NAME", _proc_name, ComConst.DB_OUT);

            db.DbBeginTrans();
            rtn = db.DbStored("SP_CUSTOMER_DELETE");
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
        /// 仕入先一覧の取得
        /// 
        /// 使用画面：MstVendorMnt, SrchVendor
        /// </summary>
        public DataSet GetCustomerList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();
            ComLibrary comlibrary = new ComLibrary();

            //--- sql
            //-->ADD BY UBIQ-SUO 2010/09/25
            strSQL.Append("SELECT COUNT(*)");
            //strSQL.Append("CUST_CD,			    CUST_SUB_CD,	");
            //strSQL.Append("CUST_NAME,			CUST_DESC,            CUST_NAME2,		CUST_DESC2,	");
            //strSQL.Append("COUNTRY_CD,		    FOREIGN_FLAG,	      CUR_CD,	        SHIP_WHS,		");
            //strSQL.Append("TRANS_LT,		    SHIP_SLIP_TYPE,	      PAY_TERMS, 	");
            //strSQL.Append("EVAL_RATIO,   		CUST_ATTN,    	      TELNO,      	    FAXNO,  		");
            //strSQL.Append("ZIP_CD,         		STATE,          	  ADDRESS1,      	ADDRESS2,  		");
            //strSQL.Append("ADDRESS3,         	ADDRESS4,             STATE2,          	ADDRESS2_1,     ");
            //strSQL.Append("ADDRESS2_2,         	ADDRESS2_3,           ADDRESS2_4,         ");
            //strSQL.Append("DATA_CHAR1,			DATA_CHAR2,			");
            //strSQL.Append("DATA_CHAR3,			DATA_CHAR4,			DATA_CHAR5,			DATA_CHAR6,			");
            //strSQL.Append("DATA_CHAR7,			DATA_CHAR8,			DATA_CHAR9,			DATA_CHAR10,		");
            //strSQL.Append("DATA_NUM1,			DATA_NUM2,			DATA_NUM3,			DATA_NUM4,			");
            //strSQL.Append("DATA_NUM5,			DATA_NUM6,			DATA_NUM7,			DATA_NUM8,			");
            //strSQL.Append("DATA_NUM9,			DATA_NUM10,			DATA_FLAG1,			DATA_FLAG2,			");
            //strSQL.Append("DATA_FLAG3,			DATA_FLAG4,			DATA_FLAG5,			DATA_FLAG6,			");
            //strSQL.Append("DATA_FLAG7,			DATA_FLAG8,			DATA_FLAG9,			DATA_FLAG10,		");
            //strSQL.Append("CHG_PGM,			CHG_USERID,			");
            //strSQL.Append("UPDATE_CNTR");
            strSQL.Append(" FROM CUSTOMER_MASTER ");
            db.DbParametersClear();
            if (_cust_cd != "" || _cust_name != "")
            {
                strSQL.Append(" WHERE ");
                if (_cust_cd != "")
                {
                    strSQL.Append(" CUST_CD LIKE '" + _cust_cd + "%'");
                    if (_cust_name != "")
                    {
                        strSQL.Append(" AND ");
                    }
                }
                if (_cust_name != "")
                {
                    strSQL.Append(" CUST_NAME LIKE '%" + _cust_name + "%'");
                }

            }

            //strSQL.Append(" ORDER BY  CUST_CD");

            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "TABLE");
                if (ds == null)
                {
                    _dbmsg = db.expmsg;
                    _strErr = db.strErr;
                    return null;
                }
                //if (db.State() == ConnectionState.Open)
                //    db.DbClose();

                if (comlibrary.StringToInt(ds.Tables[0].Rows[0][0].ToString()) > 2000)
                {
                    _range = true;
                }
                else
                {
                    _range = false;
                }
            }
            catch
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                if (db.State() == ConnectionState.Open)
                    db.DbClose();
                return null;
            }
            strSQL = new StringBuilder();
            //<--ADD BY UBIQ-SUO 2010/09/25

            strSQL.Append("SELECT TOP 2000");
            strSQL.Append("CUST_CD,			    CUST_SUB_CD,	");
            strSQL.Append("CUST_NAME,			CUST_DESC,            CUST_NAME2,		CUST_DESC2,	");
            strSQL.Append("COUNTRY_CD,		    FOREIGN_FLAG,	      CUR_CD,	        SHIP_WHS,		");
            strSQL.Append("TRANS_LT,		    SHIP_SLIP_TYPE,	      PAY_TERMS, 	");
            strSQL.Append("EVAL_RATIO,   		CUST_ATTN,    	      TELNO,      	    FAXNO,  		");
            strSQL.Append("ZIP_CD,         		STATE,          	  ADDRESS1,      	ADDRESS2,  		");
            strSQL.Append("ADDRESS3,         	ADDRESS4,             STATE2,          	ADDRESS2_1,     ");
            strSQL.Append("ADDRESS2_2,         	ADDRESS2_3,           ADDRESS2_4,         ");
            strSQL.Append("DATA_CHAR1,			DATA_CHAR2,			");
            strSQL.Append("DATA_CHAR3,			DATA_CHAR4,			DATA_CHAR5,			DATA_CHAR6,			");
            strSQL.Append("DATA_CHAR7,			DATA_CHAR8,			DATA_CHAR9,			DATA_CHAR10,		");
            strSQL.Append("DATA_NUM1,			DATA_NUM2,			DATA_NUM3,			DATA_NUM4,			");
            strSQL.Append("DATA_NUM5,			DATA_NUM6,			DATA_NUM7,			DATA_NUM8,			");
            strSQL.Append("DATA_NUM9,			DATA_NUM10,			DATA_FLAG1,			DATA_FLAG2,			");
            strSQL.Append("DATA_FLAG3,			DATA_FLAG4,			DATA_FLAG5,			DATA_FLAG6,			");
            strSQL.Append("DATA_FLAG7,			DATA_FLAG8,			DATA_FLAG9,			DATA_FLAG10,		");
            strSQL.Append("CHG_PGM,			CHG_USERID,			");
            strSQL.Append("UPDATE_CNTR");
            strSQL.Append(" FROM CUSTOMER_MASTER ");
            db.DbParametersClear();
            if (_cust_cd != "" || _cust_name != "")
            {
                strSQL.Append(" WHERE ");
                if (_cust_cd != "")
                {
                    strSQL.Append(" CUST_CD LIKE '" + _cust_cd + "%'");
                    if (_cust_name != "")
                    {
                        strSQL.Append(" AND ");
                    }
                }
                if (_cust_name != "")
                {
                    strSQL.Append(" CUST_NAME LIKE '%" + _cust_name + "%'");
                }

            }

            strSQL.Append(" ORDER BY  CUST_CD");

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
        /// 仕入先詳細の取得
        /// 
        /// 使用画面：MstVendorMnt
        /// </summary>
        public int GetCustomerDetail()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            strSQL.Append("SELECT ");
            strSQL.Append("C.CUST_CD,			C.CUST_SUB_CD,	");
            strSQL.Append("C.CUST_NAME,			C.CUST_DESC,        C.CUST_NAME2,		C.CUST_DESC2,	");
            strSQL.Append("C.COUNTRY_CD,		C.FOREIGN_FLAG,	    C.CUR_CD,	        C.SHIP_WHS,		");
            strSQL.Append("C.TRANS_LT,		    C.SHIP_SLIP_TYPE,	C.PAY_TERMS, 	    W.WHS_DESC,     ");
            strSQL.Append("C.EVAL_RATIO,   		C.CUST_ATTN,    	C.TELNO,      	    C.FAXNO,  		");
            strSQL.Append("C.ZIP_CD,         	C.STATE,          	C.ADDRESS1,      	C.ADDRESS2,  	");
            strSQL.Append("C.ADDRESS3,         	C.ADDRESS4,         C.STATE2,          	C.ADDRESS2_1,   ");
            strSQL.Append("C.ADDRESS2_2,        C.ADDRESS2_3,       C.ADDRESS2_4,                       ");
            strSQL.Append("C.DATA_CHAR1,		C.DATA_CHAR2,			                                ");
            strSQL.Append("C.DATA_CHAR3,		C.DATA_CHAR4,		C.DATA_CHAR5,		C.DATA_CHAR6,	");
            strSQL.Append("C.DATA_CHAR7,		C.DATA_CHAR8,		C.DATA_CHAR9,		C.DATA_CHAR10,	");
            strSQL.Append("C.DATA_NUM1,			C.DATA_NUM2,		C.DATA_NUM3,		C.DATA_NUM4,	");
            strSQL.Append("C.DATA_NUM5,			C.DATA_NUM6,		C.DATA_NUM7,		C.DATA_NUM8,	");
            strSQL.Append("C.DATA_NUM9,			C.DATA_NUM10,		C.DATA_FLAG1,		C.DATA_FLAG2,	");
            strSQL.Append("C.DATA_FLAG3,		C.DATA_FLAG4,		C.DATA_FLAG5,		C.DATA_FLAG6,	");
            strSQL.Append("C.DATA_FLAG7,		C.DATA_FLAG8,		C.DATA_FLAG9,		C.DATA_FLAG10,	");
            strSQL.Append("C.CHG_PGM,			C.CHG_USERID,			                                ");
            strSQL.Append("C.UPDATE_CNTR,       S.DATA_CHAR CUR_DESC                                    ");
            strSQL.Append(",ISNULL(S.DATA_DEC,0) PRICE_DEC          ,ISNULL(S.DATA_DEC2,0)  AMT_DEC     ");
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM CUSTOMER_MASTER C, WAREHOUSE_MASTER W");
                strSQL.Append(" WHERE C.CUST_CD = :CUST_CD");
                strSQL.Append(" AND C.CUST_SUB_CD = :CUST_SUB_CD");
                strSQL.Append(" AND C.SHIP_WHS = W.WHS_CD(+)");
                db.DbParametersClear();
                db.DbPsetString("CUST_CD", _cust_cd);
                db.DbPsetString("CUST_SUB_CD", _cust_sub_cd);
            }
            else
            {
                strSQL.Append(" FROM CUSTOMER_MASTER C ");
                strSQL.Append(" LEFT OUTER JOIN WAREHOUSE_MASTER W ON C.SHIP_WHS = W.WHS_CD                         ");
                strSQL.Append(" LEFT OUTER JOIN SYSTEM_PARAMETER S ON S.KEY01 = 'CURRENCY_CD' AND KEY02 = C.CUR_CD  ");
                strSQL.Append(" WHERE CUST_CD = @CUST_CD");
                strSQL.Append(" AND CUST_SUB_CD = @CUST_SUB_CD");
                db.DbParametersClear();
                db.DbPsetString("@CUST_CD", _cust_cd);
                db.DbPsetString("@CUST_SUB_CD", _cust_sub_cd);
            }

            rtn = db.DbExecuteReader(strSQL.ToString());
            if (rtn == ComConst.FAILED)
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
            }
            else
            {
                _cust_cd = db.Row("CUST_CD");
                _cust_sub_cd = db.Row("CUST_SUB_CD");
                _cust_name = db.Row("CUST_NAME");
                _cust_desc = db.Row("CUST_DESC");
                _cust_name2 = db.Row("CUST_NAME2");
                _cust_desc2 = db.Row("CUST_DESC2");
                _country_cd = db.Row("COUNTRY_CD");
                _foreign_flag = int.Parse(db.Row("FOREIGN_FLAG"));
                _cur_cd = db.Row("CUR_CD");
                _ship_whs = db.Row("SHIP_WHS");
                _ship_whs_desc = db.Row("WHS_DESC");
                _trans_lt = int.Parse(db.Row("TRANS_LT"));
                _ship_slip_type = db.Row("SHIP_SLIP_TYPE");
                //_po_slip_type = db.Row("PO_SLIP_TYPE");
                //_fcst_flag = int.Parse(db.Row("FCST_FLAG"));
                _eval_ratio = double.Parse(db.Row("EVAL_RATIO"));
                _pay_terms = db.Row("PAY_TERMS");
                _cust_attn = db.Row("CUST_ATTN");
                _telno = db.Row("TELNO");
                _faxno = db.Row("FAXNO");
                _zip_cd = db.Row("ZIP_CD");
                _state = db.Row("STATE");
                _address1 = db.Row("ADDRESS1");
                _address2 = db.Row("ADDRESS2");
                _address3 = db.Row("ADDRESS3");
                _address4 = db.Row("ADDRESS4");
                _state2 = db.Row("STATE2");
                _address2_1 = db.Row("ADDRESS2_1");
                _address2_2 = db.Row("ADDRESS2_2");
                _address2_3 = db.Row("ADDRESS2_3");
                _address2_4 = db.Row("ADDRESS2_4");
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
                _cur_desc = db.Row("CUR_DESC");
                //_entry_date = DateTime.Parse(db.Row("ENTRY_DATE"));
                //_chg_date = DateTime.Parse(db.Row("CHG_DATE"));
                _chg_pgm = db.Row("CHG_PGM");
                _chg_userid = db.Row("CHG_USERID");
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
        public int whs_nameSelect()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //sql
            strSQL.Append("SELECT ");
            strSQL.Append("WHS_CD,			    WHS_DESC,	");
            strSQL.Append(" FROM WAREHOUSE_MASTER ");
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" WHERE WHS_CD              = :WHS_CD");

                db.DbParametersClear();
                db.DbPsetString("WHS_CD", _whs_cd);
            }
            else
            {
                strSQL.Append(" WHERE WHS_CD = @WHS_CD");

                db.DbParametersClear();
                db.DbPsetString("@WHS_CD", _whs_cd);
            }

            rtn = db.DbExecuteReader(strSQL.ToString());
            if (rtn == ComConst.FAILED)
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
            }
            else
            {
                _cust_cd = db.Row("WHS_CD");
                _cust_desc = db.Row("WHS_DESC");
            }

            if (db.State() == ConnectionState.Open)
                db.DbClose();
            return rtn;

        }
        /// <summary>
        /// 仕入先一覧の取得
        /// 
        /// 使用画面：MstVendorMnt, SrchVendor
        /// </summary>
        public DataSet GetCustomerExistList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append("SELECT ");
            strSQL.Append("CUST_CD,			    CUST_SUB_CD,	");
            strSQL.Append("CUST_NAME,			CUST_DESC,            CUST_NAME2,		CUST_DESC2,	");
            strSQL.Append("COUNTRY_CD,		    FOREIGN_FLAG,	      CUR_CD,	        SHIP_WHS,		");
            strSQL.Append("TRANS_LT,		    SHIP_SLIP_TYPE,	      PAY_TERMS, 	");
            strSQL.Append("EVAL_RATIO,   		CUST_ATTN,    	      TELNO,      	    FAXNO,  		");
            strSQL.Append("ZIP_CD,         		STATE,          	  ADDRESS1,      	ADDRESS2,  		");
            strSQL.Append("ADDRESS3,         	ADDRESS4,             STATE2,          	ADDRESS2_1,     ");
            strSQL.Append("ADDRESS2_2,         	ADDRESS2_3,           ADDRESS2_4,         ");
            strSQL.Append("DATA_CHAR1,			DATA_CHAR2,			");
            strSQL.Append("DATA_CHAR3,			DATA_CHAR4,			DATA_CHAR5,			DATA_CHAR6,			");
            strSQL.Append("DATA_CHAR7,			DATA_CHAR8,			DATA_CHAR9,			DATA_CHAR10,		");
            strSQL.Append("DATA_NUM1,			DATA_NUM2,			DATA_NUM3,			DATA_NUM4,			");
            strSQL.Append("DATA_NUM5,			DATA_NUM6,			DATA_NUM7,			DATA_NUM8,			");
            strSQL.Append("DATA_NUM9,			DATA_NUM10,			DATA_FLAG1,			DATA_FLAG2,			");
            strSQL.Append("DATA_FLAG3,			DATA_FLAG4,			DATA_FLAG5,			DATA_FLAG6,			");
            strSQL.Append("DATA_FLAG7,			DATA_FLAG8,			DATA_FLAG9,			DATA_FLAG10,		");
            strSQL.Append("CHG_PGM,			CHG_USERID,			");
            strSQL.Append("UPDATE_CNTR");
            strSQL.Append(" FROM CUSTOMER_MASTER ");
            db.DbParametersClear();
            //add 2009.08.20
            strSQL.Append(" WHERE CUST_CD = @CUST_CD        ");
            db.DbParametersClear();
            db.DbPsetString("@CUST_CD", _cust_cd);

            strSQL.Append(" ORDER BY  CUST_CD");

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
    }
}
