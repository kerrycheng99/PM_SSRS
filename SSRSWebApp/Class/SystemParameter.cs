using System;
using System.Web;
using System.Text;
using System.Data;
using System.Web.Configuration;

/// <summary>
/// システムパラメータクラス
/// </summary>
namespace PMClass
{
    public class SystemParameter
    {
        #region : コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SystemParameter()
        {
            try
            {
                _db_type = WebConfigurationManager.AppSettings["db_type"];
            }
            catch { }
        }
        public SystemParameter(string p_user_id, int p_lang)
        {
            _user_id = p_user_id;
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
        //-->ADD BY UBIQ-SUO 2011/02/28
        protected string _rptname = "";
        protected string _rptno = "";
        protected string _creatname = "";
        //<--ADD BY UBIQ-SUO 2011/02/28

        protected string _db_type = "";
        protected string _user_id = "";
        protected int _lang = 1;
        protected string _key01 = "*";
        protected string _key02 = "*";
        protected string _key03 = "*";
        protected string _key04 = "*";
        protected string _data_char0 = "";
        protected string _data_char = "";
        protected string _data_char2 = "";
        protected string _data_char3 = "";
        protected string _data_char4 = "";
        protected string _data_char5 = "";
        protected string _data_char6 = "";
        protected int _data_int = 0;
        protected double _data_dec = 0;
        protected double _data_dec2 = 0;
        protected double _data_dec3 = 0;
        protected double _data_dec4 = 0;
        protected string _remarks1 = "";
        protected string _remarks2 = "";
        protected string _remarks3 = "";
        protected DateTime _entry_date = DateTime.Now;
        protected DateTime _chg_date = DateTime.Now;
        protected string _chg_user_id = "";
        protected int _update_cntr = 0;
        protected string _dbmsg = "";
        protected string _strErr = "";
        protected string _header_desc1 = "";
        protected string _header_desc2 = "";
        protected string _header_desc3 = "";
        protected string _header_desc4 = "";
        protected string _key02_label1 = "";
        protected string _key02_label2 = "";
        protected string _key02_label3 = "";
        protected string _key02_label4 = "";
        protected string _key02_desc1 = "";
        protected string _key02_desc2 = "";
        protected string _key02_desc3 = "";
        protected string _key02_desc4 = "";
        protected int _key02_digit = 0;
        protected string _key03_label1 = "";
        protected string _key03_label2 = "";
        protected string _key03_label3 = "";
        protected string _key03_label4 = "";
        protected string _key03_desc1 = "";
        protected string _key03_desc2 = "";
        protected string _key03_desc3 = "";
        protected string _key03_desc4 = "";
        protected int _key03_digit = 0;
        protected string _key04_label1 = "";
        protected string _key04_label2 = "";
        protected string _key04_label3 = "";
        protected string _key04_label4 = "";
        protected string _key04_desc1 = "";
        protected string _key04_desc2 = "";
        protected string _key04_desc3 = "";
        protected string _key04_desc4 = "";
        protected int _key04_digit = 0;
        protected string _data_char_label1 = "";
        protected string _data_char_label2 = "";
        protected string _data_char_label3 = "";
        protected string _data_char_label4 = "";
        protected string _data_char_desc1 = "";
        protected string _data_char_desc2 = "";
        protected string _data_char_desc3 = "";
        protected string _data_char_desc4 = "";
        protected string _data_char2_label1 = "";
        protected string _data_char2_label2 = "";
        protected string _data_char2_label3 = "";
        protected string _data_char2_label4 = "";
        protected string _data_char2_desc1 = "";
        protected string _data_char2_desc2 = "";
        protected string _data_char2_desc3 = "";
        protected string _data_char2_desc4 = "";
        protected string _data_char3_label1 = "";
        protected string _data_char3_label2 = "";
        protected string _data_char3_label3 = "";
        protected string _data_char3_label4 = "";
        protected string _data_char3_desc1 = "";
        protected string _data_char3_desc2 = "";
        protected string _data_char3_desc3 = "";
        protected string _data_char3_desc4 = "";
        protected string _data_char4_label1 = "";
        protected string _data_char4_label2 = "";
        protected string _data_char4_label3 = "";
        protected string _data_char4_label4 = "";
        protected string _data_char4_desc1 = "";
        protected string _data_char4_desc2 = "";
        protected string _data_char4_desc3 = "";
        protected string _data_char4_desc4 = "";
        protected string _data_char5_label1 = "";
        protected string _data_char5_label2 = "";
        protected string _data_char5_label3 = "";
        protected string _data_char5_label4 = "";
        protected string _data_char5_desc1 = "";
        protected string _data_char5_desc2 = "";
        protected string _data_char5_desc3 = "";
        protected string _data_char5_desc4 = "";
        protected string _data_char6_label1 = "";
        protected string _data_char6_label2 = "";
        protected string _data_char6_label3 = "";
        protected string _data_char6_label4 = "";
        protected string _data_char6_desc1 = "";
        protected string _data_char6_desc2 = "";
        protected string _data_char6_desc3 = "";
        protected string _data_char6_desc4 = "";
        protected string _data_int_label1 = "";
        protected string _data_int_label2 = "";
        protected string _data_int_label3 = "";
        protected string _data_int_label4 = "";
        protected string _data_int_desc1 = "";
        protected string _data_int_desc2 = "";
        protected string _data_int_desc3 = "";
        protected string _data_int_desc4 = "";
        protected string _data_dec_label1 = "";
        protected string _data_dec_label2 = "";
        protected string _data_dec_label3 = "";
        protected string _data_dec_label4 = "";
        protected string _data_dec_desc1 = "";
        protected string _data_dec_desc2 = "";
        protected string _data_dec_desc3 = "";
        protected string _data_dec_desc4 = "";
        protected string _data_dec2_label1 = "";
        protected string _data_dec2_label2 = "";
        protected string _data_dec2_label3 = "";
        protected string _data_dec2_label4 = "";
        protected string _data_dec2_desc1 = "";
        protected string _data_dec2_desc2 = "";
        protected string _data_dec2_desc3 = "";
        protected string _data_dec2_desc4 = "";
        protected string _data_dec3_label1 = "";
        protected string _data_dec3_label2 = "";
        protected string _data_dec3_label3 = "";
        protected string _data_dec3_label4 = "";
        protected string _data_dec3_desc1 = "";
        protected string _data_dec3_desc2 = "";
        protected string _data_dec3_desc3 = "";
        protected string _data_dec3_desc4 = "";
        protected string _data_dec4_label1 = "";
        protected string _data_dec4_label2 = "";
        protected string _data_dec4_label3 = "";
        protected string _data_dec4_label4 = "";
        protected string _data_dec4_desc1 = "";
        protected string _data_dec4_desc2 = "";
        protected string _data_dec4_desc3 = "";
        protected string _data_dec4_desc4 = "";

        protected string _header_desc = "";
        protected string _key02_label = "";
        protected string _key02_desc = "";
        protected string _key03_label = "";
        protected string _key03_desc = "";
        protected string _key04_label = "";
        protected string _key04_desc = "";
        protected string _data_char_label = "";
        protected string _data_char_desc = "";
        protected string _data_char2_label = "";
        protected string _data_char2_desc = "";
        protected string _data_char3_label = "";
        protected string _data_char3_desc = "";
        protected string _data_char4_label = "";
        protected string _data_char4_desc = "";
        protected string _data_char5_label = "";
        protected string _data_char5_desc = "";
        protected string _data_char6_label = "";
        protected string _data_char6_desc = "";
        protected string _data_int_label = "";
        protected string _data_int_desc = "";
        protected string _data_dec_label = "";
        protected string _data_dec_desc = "";
        protected string _data_dec2_label = "";
        protected string _data_dec2_desc = "";
        protected string _data_dec3_label = "";
        protected string _data_dec3_desc = "";
        protected string _data_dec4_label = "";
        protected string _data_dec4_desc = "";

        protected int _year_int = 0;
        protected int _base_cur_flag = 0;

        #endregion

        #region : プロパティ
        ///<summary>
        /// プロパティ
        ///</summary>        
        //-->ADD BY UBIQ-SUO 2011/02/28
        public string rptname
        {
            get { return _rptname; }
            set { _rptname = value; }
        }
        public string rptno
        {
            get { return _rptno; }
            set { _rptno = value; }
        }
        public string creatname
        {
            get { return _creatname; }
            set { _creatname = value; }
        }
        //<--ADD BY UBIQ-SUO 2011/02/28

        public string user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        public int lang
        {
            get { return _lang; }
            set { _lang = value; }
        }
        public string key01
        {
            get { return _key01; }
            set { _key01 = value; }
        }
        public string key02
        {
            get { return _key02; }
            set { _key02 = value; }
        }
        public string key03
        {
            get { return _key03; }
            set { _key03 = value; }
        }
        public string key04
        {
            get { return _key04; }
            set { _key04 = value; }
        }
        public string data_char0
        {
            get { return _data_char0; }
            set { _data_char0 = value; }
        }
        public string data_char
        {
            get { return _data_char; }
            set { _data_char = value; }
        }
        public string data_char2
        {
            get { return _data_char2; }
            set { _data_char2 = value; }
        }
        public string data_char3
        {
            get { return _data_char3; }
            set { _data_char3 = value; }
        }
        public string data_char4
        {
            get { return _data_char4; }
            set { _data_char4 = value; }
        }
        public string data_char5
        {
            get { return _data_char5; }
            set { _data_char5 = value; }
        }
        public string data_char6
        {
            get { return _data_char6; }
            set { _data_char6 = value; }
        }
        public int data_int
        {
            get { return _data_int; }
            set { _data_int = value; }
        }
        public double data_dec
        {
            get { return _data_dec; }
            set { _data_dec = value; }
        }
        public double data_dec2
        {
            get { return _data_dec2; }
            set { _data_dec2 = value; }
        }
        public double data_dec3
        {
            get { return _data_dec3; }
            set { _data_dec3 = value; }
        }
        public double data_dec4
        {
            get { return _data_dec4; }
            set { _data_dec4 = value; }
        }

        public string remarks1
        {
            get { return _remarks1; }
            set { _remarks1 = value; }
        }
        public string remarks2
        {
            get { return _remarks2; }
            set { _remarks2 = value; }
        }
        public string remarks3
        {
            get { return _remarks3; }
            set { _remarks3 = value; }
        }
        public DateTime entry_date
        {
            get { return _entry_date; }
            set { _entry_date = value; }
        }
        public DateTime chg_date
        {
            get { return _chg_date; }
            set { _chg_date = value; }
        }
        public string chg_user_id
        {
            get { return _chg_user_id; }
            set { _chg_user_id = value; }
        }
        public int update_cntr
        {
            get { return _update_cntr; }
            set { _update_cntr = value; }
        }
        public string header_desc1 { get { return _header_desc1; } set { _header_desc1 = value; } }
        public string header_desc2 { get { return _header_desc2; } set { _header_desc2 = value; } }
        public string header_desc3 { get { return _header_desc3; } set { _header_desc3 = value; } }
        public string header_desc4 { get { return _header_desc4; } set { _header_desc4 = value; } }
        public string key02_label1 { get { return _key02_label1; } set { _key02_label1 = value; } }
        public string key02_label2 { get { return _key02_label2; } set { _key02_label2 = value; } }
        public string key02_label3 { get { return _key02_label3; } set { _key02_label3 = value; } }
        public string key02_label4 { get { return _key02_label4; } set { _key02_label4 = value; } }
        public string key02_desc1 { get { return _key02_desc1; } set { _key02_desc1 = value; } }
        public string key02_desc2 { get { return _key02_desc2; } set { _key02_desc2 = value; } }
        public string key02_desc3 { get { return _key02_desc3; } set { _key02_desc3 = value; } }
        public string key02_desc4 { get { return _key02_desc4; } set { _key02_desc4 = value; } }
        public int key02_digit { get { return _key02_digit; } set { _key02_digit = value; } }
        public string key03_label1 { get { return _key03_label1; } set { _key03_label1 = value; } }
        public string key03_label2 { get { return _key03_label2; } set { _key03_label2 = value; } }
        public string key03_label3 { get { return _key03_label3; } set { _key03_label3 = value; } }
        public string key03_label4 { get { return _key03_label4; } set { _key03_label4 = value; } }
        public string key03_desc1 { get { return _key03_desc1; } set { _key03_desc1 = value; } }
        public string key03_desc2 { get { return _key03_desc2; } set { _key03_desc2 = value; } }
        public string key03_desc3 { get { return _key03_desc3; } set { _key03_desc3 = value; } }
        public string key03_desc4 { get { return _key03_desc4; } set { _key03_desc4 = value; } }
        public int key03_digit { get { return _key03_digit; } set { _key03_digit = value; } }
        public string key04_label1 { get { return _key04_label1; } set { _key04_label1 = value; } }
        public string key04_label2 { get { return _key04_label2; } set { _key04_label2 = value; } }
        public string key04_label3 { get { return _key04_label3; } set { _key04_label3 = value; } }
        public string key04_label4 { get { return _key04_label4; } set { _key04_label4 = value; } }
        public string key04_desc1 { get { return _key04_desc1; } set { _key04_desc1 = value; } }
        public string key04_desc2 { get { return _key04_desc2; } set { _key04_desc2 = value; } }
        public string key04_desc3 { get { return _key04_desc3; } set { _key04_desc3 = value; } }
        public string key04_desc4 { get { return _key04_desc4; } set { _key04_desc4 = value; } }
        public int key04_digit { get { return _key04_digit; } set { _key04_digit = value; } }
        public string data_char_label1 { get { return _data_char_label1; } set { _data_char_label1 = value; } }
        public string data_char_label2 { get { return _data_char_label2; } set { _data_char_label2 = value; } }
        public string data_char_label3 { get { return _data_char_label3; } set { _data_char_label3 = value; } }
        public string data_char_label4 { get { return _data_char_label4; } set { _data_char_label4 = value; } }
        public string data_char_desc1 { get { return _data_char_desc1; } set { _data_char_desc1 = value; } }
        public string data_char_desc2 { get { return _data_char_desc2; } set { _data_char_desc2 = value; } }
        public string data_char_desc3 { get { return _data_char_desc3; } set { _data_char_desc3 = value; } }
        public string data_char_desc4 { get { return _data_char_desc4; } set { _data_char_desc4 = value; } }
        public string data_char2_label1 { get { return _data_char2_label1; } set { _data_char2_label1 = value; } }
        public string data_char2_label2 { get { return _data_char2_label2; } set { _data_char2_label2 = value; } }
        public string data_char2_label3 { get { return _data_char2_label3; } set { _data_char2_label3 = value; } }
        public string data_char2_label4 { get { return _data_char2_label4; } set { _data_char2_label4 = value; } }
        public string data_char2_desc1 { get { return _data_char2_desc1; } set { _data_char2_desc1 = value; } }
        public string data_char2_desc2 { get { return _data_char2_desc2; } set { _data_char2_desc2 = value; } }
        public string data_char2_desc3 { get { return _data_char2_desc3; } set { _data_char2_desc3 = value; } }
        public string data_char2_desc4 { get { return _data_char2_desc4; } set { _data_char2_desc4 = value; } }
        public string data_char3_label1 { get { return _data_char3_label1; } set { _data_char3_label1 = value; } }
        public string data_char3_label2 { get { return _data_char3_label2; } set { _data_char3_label2 = value; } }
        public string data_char3_label3 { get { return _data_char3_label3; } set { _data_char3_label3 = value; } }
        public string data_char3_label4 { get { return _data_char3_label4; } set { _data_char3_label4 = value; } }
        public string data_char3_desc1 { get { return _data_char3_desc1; } set { _data_char3_desc1 = value; } }
        public string data_char3_desc2 { get { return _data_char3_desc2; } set { _data_char3_desc2 = value; } }
        public string data_char3_desc3 { get { return _data_char3_desc3; } set { _data_char3_desc3 = value; } }
        public string data_char3_desc4 { get { return _data_char3_desc4; } set { _data_char3_desc4 = value; } }
        public string data_char4_label1 { get { return _data_char4_label1; } set { _data_char4_label1 = value; } }
        public string data_char4_label2 { get { return _data_char4_label2; } set { _data_char4_label2 = value; } }
        public string data_char4_label3 { get { return _data_char4_label3; } set { _data_char4_label3 = value; } }
        public string data_char4_label4 { get { return _data_char4_label4; } set { _data_char4_label4 = value; } }
        public string data_char4_desc1 { get { return _data_char4_desc1; } set { _data_char4_desc1 = value; } }
        public string data_char4_desc2 { get { return _data_char4_desc2; } set { _data_char4_desc2 = value; } }
        public string data_char4_desc3 { get { return _data_char4_desc3; } set { _data_char4_desc3 = value; } }
        public string data_char4_desc4 { get { return _data_char4_desc4; } set { _data_char4_desc4 = value; } }
        public string data_char5_label1 { get { return _data_char5_label1; } set { _data_char5_label1 = value; } }
        public string data_char5_label2 { get { return _data_char5_label2; } set { _data_char5_label2 = value; } }
        public string data_char5_label3 { get { return _data_char5_label3; } set { _data_char5_label3 = value; } }
        public string data_char5_label4 { get { return _data_char5_label4; } set { _data_char5_label4 = value; } }
        public string data_char5_desc1 { get { return _data_char5_desc1; } set { _data_char5_desc1 = value; } }
        public string data_char5_desc2 { get { return _data_char5_desc2; } set { _data_char5_desc2 = value; } }
        public string data_char5_desc3 { get { return _data_char5_desc3; } set { _data_char5_desc3 = value; } }
        public string data_char5_desc4 { get { return _data_char5_desc4; } set { _data_char5_desc4 = value; } }
        public string data_char6_label1 { get { return _data_char6_label1; } set { _data_char6_label1 = value; } }
        public string data_char6_label2 { get { return _data_char6_label2; } set { _data_char6_label2 = value; } }
        public string data_char6_label3 { get { return _data_char6_label3; } set { _data_char6_label3 = value; } }
        public string data_char6_label4 { get { return _data_char6_label4; } set { _data_char6_label4 = value; } }
        public string data_char6_desc1 { get { return _data_char6_desc1; } set { _data_char6_desc1 = value; } }
        public string data_char6_desc2 { get { return _data_char6_desc2; } set { _data_char6_desc2 = value; } }
        public string data_char6_desc3 { get { return _data_char6_desc3; } set { _data_char6_desc3 = value; } }
        public string data_char6_desc4 { get { return _data_char6_desc4; } set { _data_char6_desc4 = value; } }
        public string data_int_label1 { get { return _data_int_label1; } set { _data_int_label1 = value; } }
        public string data_int_label2 { get { return _data_int_label2; } set { _data_int_label2 = value; } }
        public string data_int_label3 { get { return _data_int_label3; } set { _data_int_label3 = value; } }
        public string data_int_label4 { get { return _data_int_label4; } set { _data_int_label4 = value; } }
        public string data_int_desc1 { get { return _data_int_desc1; } set { _data_int_desc1 = value; } }
        public string data_int_desc2 { get { return _data_int_desc2; } set { _data_int_desc2 = value; } }
        public string data_int_desc3 { get { return _data_int_desc3; } set { _data_int_desc3 = value; } }
        public string data_int_desc4 { get { return _data_int_desc4; } set { _data_int_desc4 = value; } }
        public string data_dec_label1 { get { return _data_dec_label1; } set { _data_dec_label1 = value; } }
        public string data_dec_label2 { get { return _data_dec_label2; } set { _data_dec_label2 = value; } }
        public string data_dec_label3 { get { return _data_dec_label3; } set { _data_dec_label3 = value; } }
        public string data_dec_label4 { get { return _data_dec_label4; } set { _data_dec_label4 = value; } }
        public string data_dec_desc1 { get { return _data_dec_desc1; } set { _data_dec_desc1 = value; } }
        public string data_dec_desc2 { get { return _data_dec_desc2; } set { _data_dec_desc2 = value; } }
        public string data_dec_desc3 { get { return _data_dec_desc3; } set { _data_dec_desc3 = value; } }
        public string data_dec_desc4 { get { return _data_dec_desc4; } set { _data_dec_desc4 = value; } }
        public string data_dec2_label1 { get { return _data_dec2_label1; } set { _data_dec2_label1 = value; } }
        public string data_dec2_label2 { get { return _data_dec2_label2; } set { _data_dec2_label2 = value; } }
        public string data_dec2_label3 { get { return _data_dec2_label3; } set { _data_dec2_label3 = value; } }
        public string data_dec2_label4 { get { return _data_dec2_label4; } set { _data_dec2_label4 = value; } }
        public string data_dec2_desc1 { get { return _data_dec2_desc1; } set { _data_dec2_desc1 = value; } }
        public string data_dec2_desc2 { get { return _data_dec2_desc2; } set { _data_dec2_desc2 = value; } }
        public string data_dec2_desc3 { get { return _data_dec2_desc3; } set { _data_dec2_desc3 = value; } }
        public string data_dec2_desc4 { get { return _data_dec2_desc4; } set { _data_dec2_desc4 = value; } }
        public string data_dec3_label1 { get { return _data_dec3_label1; } set { _data_dec3_label1 = value; } }
        public string data_dec3_label2 { get { return _data_dec3_label2; } set { _data_dec3_label2 = value; } }
        public string data_dec3_label3 { get { return _data_dec3_label3; } set { _data_dec3_label3 = value; } }
        public string data_dec3_label4 { get { return _data_dec3_label4; } set { _data_dec3_label4 = value; } }
        public string data_dec3_desc1 { get { return _data_dec3_desc1; } set { _data_dec3_desc1 = value; } }
        public string data_dec3_desc2 { get { return _data_dec3_desc2; } set { _data_dec3_desc2 = value; } }
        public string data_dec3_desc3 { get { return _data_dec3_desc3; } set { _data_dec3_desc3 = value; } }
        public string data_dec3_desc4 { get { return _data_dec3_desc4; } set { _data_dec3_desc4 = value; } }
        public string data_dec4_label1 { get { return _data_dec4_label1; } set { _data_dec4_label1 = value; } }
        public string data_dec4_label2 { get { return _data_dec4_label2; } set { _data_dec4_label2 = value; } }
        public string data_dec4_label3 { get { return _data_dec4_label3; } set { _data_dec4_label3 = value; } }
        public string data_dec4_label4 { get { return _data_dec4_label4; } set { _data_dec4_label4 = value; } }
        public string data_dec4_desc1 { get { return _data_dec4_desc1; } set { _data_dec4_desc1 = value; } }
        public string data_dec4_desc2 { get { return _data_dec4_desc2; } set { _data_dec4_desc2 = value; } }
        public string data_dec4_desc3 { get { return _data_dec4_desc3; } set { _data_dec4_desc3 = value; } }
        public string data_dec4_desc4 { get { return _data_dec4_desc4; } set { _data_dec4_desc4 = value; } }

        public string header_desc { get { return _header_desc; } set { _header_desc = value; } }
        public string key02_label { get { return _key02_label; } set { _key02_label = value; } }
        public string key02_desc { get { return _key02_desc; } set { _key02_desc = value; } }
        public string key03_label { get { return _key03_label; } set { _key03_label = value; } }
        public string key03_desc { get { return _key03_desc; } set { _key03_desc = value; } }
        public string key04_label { get { return _key04_label; } set { _key04_label = value; } }
        public string key04_desc { get { return _key04_desc; } set { _key04_desc = value; } }
        public string data_char_label { get { return _data_char_label; } set { _data_char_label = value; } }
        public string data_char_desc { get { return _data_char_desc; } set { _data_char_desc = value; } }
        public string data_char2_label { get { return _data_char2_label; } set { _data_char2_label = value; } }
        public string data_char2_desc { get { return _data_char2_desc; } set { _data_char2_desc = value; } }
        public string data_char3_label { get { return _data_char3_label; } set { _data_char3_label = value; } }
        public string data_char3_desc { get { return _data_char3_desc; } set { _data_char3_desc = value; } }
        public string data_char4_label { get { return _data_char4_label; } set { _data_char4_label = value; } }
        public string data_char4_desc { get { return _data_char4_desc; } set { _data_char4_desc = value; } }
        public string data_char5_label { get { return _data_char5_label; } set { _data_char5_label = value; } }
        public string data_char5_desc { get { return _data_char5_desc; } set { _data_char5_desc = value; } }
        public string data_char6_label { get { return _data_char6_label; } set { _data_char6_label = value; } }
        public string data_char6_desc { get { return _data_char6_desc; } set { _data_char6_desc = value; } }
        public string data_int_label { get { return _data_int_label; } set { _data_int_label = value; } }
        public string data_int_desc { get { return _data_int_desc; } set { _data_int_desc = value; } }
        public string data_dec_label { get { return _data_dec_label; } set { _data_dec_label = value; } }
        public string data_dec_desc { get { return _data_dec_desc; } set { _data_dec_desc = value; } }
        public string data_dec2_label { get { return _data_dec2_label; } set { _data_dec2_label = value; } }
        public string data_dec2_desc { get { return _data_dec2_desc; } set { _data_dec2_desc = value; } }
        public string data_dec3_label { get { return _data_dec3_label; } set { _data_dec3_label = value; } }
        public string data_dec3_desc { get { return _data_dec3_desc; } set { _data_dec3_desc = value; } }
        public string data_dec4_label { get { return _data_dec4_label; } set { _data_dec4_label = value; } }
        public string data_dec4_desc { get { return _data_dec4_desc; } set { _data_dec4_desc = value; } }

        public string dbmsg { get { return _dbmsg; } set { _dbmsg = value; } }
        public string strErr { get { return _strErr; } set { _strErr = value; } }

        public int year_int
        {
            get { return _year_int; }
            set { _year_int = value; }
        }
        public int base_cur_flag
        {
            get { return _base_cur_flag; }
            set { _base_cur_flag = value; }
        }
        #endregion

        /// <summary>
        /// 基軸通貨フラグを1に設定した場合、他の通貨の基軸通貨フラグを0に更新する
        /// </summary>
        /// <returns></returns>
        protected int CurrencyUpdate(ComDB db)
        {
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;
            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("UPDATE SYSTEM_PARAMETER      ");
                strSQL.Append("SET                          ");
                strSQL.Append("DATA_INT = 0                 ");
                strSQL.Append(" WHERE KEY01 = 'CURRENCY_CD' ");
                strSQL.Append(" AND KEY02 != :KEY02         ");

                db.DbParametersClear();
                db.DbPsetString("KEY02", _key02);
            }
            else
            {
                strSQL.Append("UPDATE SYSTEM_PARAMETER      ");
                strSQL.Append("SET                          ");
                strSQL.Append("DATA_INT = 0                 ");
                strSQL.Append(" WHERE KEY01 = 'CURRENCY_CD' ");
                strSQL.Append(" AND KEY02 != @KEY02         ");

                db.DbParametersClear();
                db.DbPsetString("@KEY02", _key02);       
            }

            db.DbBeginTrans();

            rtn = db.DbExecute(strSQL.ToString());
            if (rtn != ComConst.FAILED)
            {
            }
            else
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
            }

            return rtn;
        }

        /// <summary>
        /// システムパラメータの追加
        /// 
        /// 使用画面：MstSysParaMnt
        /// </summary>
        public int Insert()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("INSERT INTO SYSTEM_PARAMETER                             ");
                strSQL.Append("(                                                        ");
                strSQL.Append("KEY01, KEY02, KEY03, KEY04,                              ");
                strSQL.Append("DATA_CHAR, DATA_CHAR2, DATA_CHAR3,                       ");
                strSQL.Append("DATA_CHAR4, DATA_CHAR5, DATA_CHAR6,                      ");
                strSQL.Append("DATA_INT, DATA_DEC, DATA_DEC2, DATA_DEC3, DATA_DEC4,     ");
                strSQL.Append("REMARKS1, REMARKS2, REMARKS3,                            ");
                strSQL.Append("ENTRY_DATE, CHG_DATE, CHG_USER_ID, UPDATE_CNTR           ");
                strSQL.Append(") VALUES (                                               ");
                strSQL.Append(":KEY01, :KEY02, :KEY03, :KEY04,                          ");
                strSQL.Append(":DATA_CHAR, :DATA_CHAR2, :DATA_CHAR3,                    ");
                strSQL.Append(":DATA_CHAR4, :DATA_CHAR5, :DATA_CHAR6,                   ");
                strSQL.Append(":DATA_INT, :DATA_DEC, :DATA_DEC2, :DATA_DEC3, :DATA_DEC4,");
                strSQL.Append(":REMARKS1, :REMARKS2, :REMARKS3,                         ");
                strSQL.Append(":ENTRY_DATE, :CHG_DATE, :CHG_USER_ID, :UPDATE_CNTR)      ");

                db.DbParametersClear();
                db.DbPsetString("KEY01", _key01);
                db.DbPsetString("KEY02", _key02);
                db.DbPsetString("KEY03", _key03);
                db.DbPsetString("KEY04", _key04);
                db.DbPsetString("DATA_CHAR", _data_char);
                db.DbPsetString("DATA_CHAR2", _data_char2);
                db.DbPsetString("DATA_CHAR3", _data_char3);
                db.DbPsetString("DATA_CHAR4", _data_char4);
                db.DbPsetString("DATA_CHAR5", _data_char5);
                db.DbPsetString("DATA_CHAR6", _data_char6);
                db.DbPsetInt("DATA_INT", _data_int);
                db.DbPsetDouble("DATA_DEC", _data_dec);
                db.DbPsetDouble("DATA_DEC2", _data_dec2);
                db.DbPsetDouble("DATA_DEC3", _data_dec3);
                db.DbPsetDouble("DATA_DEC4", _data_dec4);
                db.DbPsetString("REMARKS1", _remarks1);
                db.DbPsetString("REMARKS2", _remarks2);
                db.DbPsetString("REMARKS3", _remarks3);
                db.DbPsetDate("ENTRY_DATE", DateTime.Now);
                db.DbPsetDate("CHG_DATE", DateTime.Now);
                db.DbPsetString("CHG_USER_ID", _chg_user_id);
                db.DbPsetInt("UPDATE_CNTR", _update_cntr);
            }
            else
            {
                strSQL.Append("INSERT INTO SYSTEM_PARAMETER                             ");
                strSQL.Append("(                                                        ");
                strSQL.Append("KEY01, KEY02, KEY03, KEY04,                              ");
                strSQL.Append("DATA_CHAR, DATA_CHAR2, DATA_CHAR3,                       ");
                strSQL.Append("DATA_CHAR4, DATA_CHAR5, DATA_CHAR6,                      ");
                strSQL.Append("DATA_INT, DATA_DEC, DATA_DEC2, DATA_DEC3, DATA_DEC4,     ");
                strSQL.Append("REMARKS1, REMARKS2, REMARKS3,                            ");
                strSQL.Append("ENTRY_DATE, CHG_DATE, CHG_USER_ID, UPDATE_CNTR           ");
                strSQL.Append(") VALUES (                                               ");
                strSQL.Append("@KEY01, @KEY02, @KEY03, @KEY04,                          ");
                strSQL.Append("@DATA_CHAR, @DATA_CHAR2, @DATA_CHAR3,                    ");
                strSQL.Append("@DATA_CHAR4, @DATA_CHAR5, @DATA_CHAR6,                   ");
                strSQL.Append("@DATA_INT, @DATA_DEC, @DATA_DEC2, @DATA_DEC3, @DATA_DEC4,");
                strSQL.Append("@REMARKS1, @REMARKS2, @REMARKS3,                         ");
                strSQL.Append("@ENTRY_DATE, @CHG_DATE, @CHG_USER_ID, @UPDATE_CNTR)      ");

                db.DbParametersClear();
                db.DbPsetString("@KEY01", _key01);
                db.DbPsetString("@KEY02", _key02);
                db.DbPsetString("@KEY03", _key03);
                db.DbPsetString("@KEY04", _key04);
                db.DbPsetString("@DATA_CHAR", _data_char);
                db.DbPsetString("@DATA_CHAR2", _data_char2);
                db.DbPsetString("@DATA_CHAR3", _data_char3);
                db.DbPsetString("@DATA_CHAR4", _data_char4);
                db.DbPsetString("@DATA_CHAR5", _data_char5);
                db.DbPsetString("@DATA_CHAR6", _data_char6);
                db.DbPsetInt("@DATA_INT", _data_int);
                db.DbPsetDouble("@DATA_DEC", _data_dec);
                db.DbPsetDouble("@DATA_DEC2", _data_dec2);
                db.DbPsetDouble("@DATA_DEC3", _data_dec3);
                db.DbPsetDouble("@DATA_DEC4", _data_dec4);
                db.DbPsetString("@REMARKS1", _remarks1);
                db.DbPsetString("@REMARKS2", _remarks2);
                db.DbPsetString("@REMARKS3", _remarks3);
                db.DbPsetDate("@ENTRY_DATE", DateTime.Now);
                db.DbPsetDate("@CHG_DATE", DateTime.Now);
                db.DbPsetString("@CHG_USER_ID", _chg_user_id);
                db.DbPsetInt("@UPDATE_CNTR", _update_cntr);
            }

            db.DbBeginTrans();

            rtn = db.DbExecute(strSQL.ToString());
            if (rtn != ComConst.FAILED)
            {
                if (_key01 == "CURRENCY_CD" && _data_int == 1)
                {
                    // 
                    // 基軸通貨フラグを1に設定した場合、他の通貨の基軸通貨フラグを0に更新する
                    //
                    rtn = CurrencyUpdate(db);
                    if (rtn == ComConst.FAILED)
                    {
                        db.DbRollback();
                        return rtn;
                    }
                }
                db.DbCommit();
            }
            else
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                db.DbRollback();
            }

            return rtn;
        }

        /// <summary>
        /// システムパラメータの変更
        /// 指定したKEY01-KEY04の内容を変更する
        /// 
        /// 使用画面：MstSysParaMnt
        /// </summary>
        public int Update()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("UPDATE SYSTEM_PARAMETER      ");
                strSQL.Append("SET                          ");
                strSQL.Append("DATA_CHAR = :DATA_CHAR,      ");
                strSQL.Append("DATA_CHAR2 = :DATA_CHAR2,    ");
                strSQL.Append("DATA_CHAR3 = :DATA_CHAR3,    ");
                strSQL.Append("DATA_CHAR4 = :DATA_CHAR4,    ");
                strSQL.Append("DATA_CHAR5 = :DATA_CHAR5,    ");
                strSQL.Append("DATA_CHAR6 = :DATA_CHAR6,    ");
                strSQL.Append("DATA_INT = :DATA_INT,        ");
                strSQL.Append("DATA_DEC = :DATA_DEC,        ");
                strSQL.Append("DATA_DEC2 = :DATA_DEC2,      ");
                strSQL.Append("DATA_DEC3 = :DATA_DEC3,      ");
                strSQL.Append("DATA_DEC4 = :DATA_DEC4,      ");
                strSQL.Append("REMARKS1 = :REMARKS1,        ");
                strSQL.Append("REMARKS2 = :REMARKS2,        ");
                strSQL.Append("REMARKS3 = :REMARKS3,        ");
                strSQL.Append("CHG_DATE = :CHG_DATE,        ");
                strSQL.Append("CHG_USER_ID = :CHG_USER_ID,  ");
                strSQL.Append("UPDATE_CNTR = UPDATE_CNTR + 1");
                strSQL.Append(" WHERE KEY01 = :KEY01        ");
                strSQL.Append(" AND KEY02 = :KEY02          ");
                strSQL.Append(" AND KEY03 = :KEY03          ");
                strSQL.Append(" AND KEY04 = :KEY04          ");

                db.DbParametersClear();
                db.DbPsetString("DATA_CHAR", _data_char);
                db.DbPsetString("DATA_CHAR2", _data_char2);
                db.DbPsetString("DATA_CHAR3", _data_char3);
                db.DbPsetString("DATA_CHAR4", _data_char4);
                db.DbPsetString("DATA_CHAR5", _data_char5);
                db.DbPsetString("DATA_CHAR6", _data_char6);
                db.DbPsetInt("DATA_INT", _data_int);
                db.DbPsetDouble("DATA_DEC", _data_dec);
                db.DbPsetDouble("DATA_DEC2", _data_dec2);
                db.DbPsetDouble("DATA_DEC3", _data_dec3);
                db.DbPsetDouble("DATA_DEC4", _data_dec4);
                db.DbPsetString("REMARKS1", _remarks1);
                db.DbPsetString("REMARKS2", _remarks2);
                db.DbPsetString("REMARKS3", _remarks3);
                db.DbPsetDate("CHG_DATE", DateTime.Now);
                db.DbPsetString("CHG_USER_ID", _chg_user_id);
                db.DbPsetString("KEY01", _key01);
                db.DbPsetString("KEY02", _key02);
                db.DbPsetString("KEY03", _key03);
                db.DbPsetString("KEY04", _key04);
            }
            else
            {
                strSQL.Append("UPDATE SYSTEM_PARAMETER      ");
                strSQL.Append("SET                          ");
                strSQL.Append("DATA_CHAR = @DATA_CHAR,      ");
                strSQL.Append("DATA_CHAR2 = @DATA_CHAR2,    ");
                strSQL.Append("DATA_CHAR3 = @DATA_CHAR3,    ");
                strSQL.Append("DATA_CHAR4 = @DATA_CHAR4,    ");
                strSQL.Append("DATA_CHAR5 = @DATA_CHAR5,    ");
                strSQL.Append("DATA_CHAR6 = @DATA_CHAR6,    ");
                strSQL.Append("DATA_INT = @DATA_INT,        ");
                strSQL.Append("DATA_DEC = @DATA_DEC,        ");
                strSQL.Append("DATA_DEC2 = @DATA_DEC2,      ");
                strSQL.Append("DATA_DEC3 = @DATA_DEC3,      ");
                strSQL.Append("DATA_DEC4 = @DATA_DEC4,      ");
                strSQL.Append("REMARKS1 = @REMARKS1,        ");
                strSQL.Append("REMARKS2 = @REMARKS2,        ");
                strSQL.Append("REMARKS3 = @REMARKS3,        ");
                strSQL.Append("CHG_DATE = @CHG_DATE,        ");
                strSQL.Append("CHG_USER_ID = @CHG_USER_ID,  ");
                strSQL.Append("UPDATE_CNTR = UPDATE_CNTR + 1");
                strSQL.Append(" WHERE KEY01 = @KEY01        ");
                strSQL.Append(" AND KEY02 = @KEY02          ");
                strSQL.Append(" AND KEY03 = @KEY03          ");
                strSQL.Append(" AND KEY04 = @KEY04          ");

                db.DbParametersClear();
                db.DbPsetString("@DATA_CHAR", _data_char);
                db.DbPsetString("@DATA_CHAR2", _data_char2);
                db.DbPsetString("@DATA_CHAR3", _data_char3);
                db.DbPsetString("@DATA_CHAR4", _data_char4);
                db.DbPsetString("@DATA_CHAR5", _data_char5);
                db.DbPsetString("@DATA_CHAR6", _data_char6);
                db.DbPsetInt("@DATA_INT", _data_int);
                db.DbPsetDouble("@DATA_DEC", _data_dec);
                db.DbPsetDouble("@DATA_DEC2", _data_dec2);
                db.DbPsetDouble("@DATA_DEC3", _data_dec3);
                db.DbPsetDouble("@DATA_DEC4", _data_dec4);
                db.DbPsetString("@REMARKS1", _remarks1);
                db.DbPsetString("@REMARKS2", _remarks2);
                db.DbPsetString("@REMARKS3", _remarks3);
                db.DbPsetDate("@CHG_DATE", DateTime.Now);
                db.DbPsetString("@CHG_USER_ID", _chg_user_id);
                db.DbPsetString("@KEY01", _key01);
                db.DbPsetString("@KEY02", _key02);
                db.DbPsetString("@KEY03", _key03);
                db.DbPsetString("@KEY04", _key04);
            }

            db.DbBeginTrans();

            rtn = db.DbExecute(strSQL.ToString());
            if (rtn != ComConst.FAILED)
            {
                if (_key01 == "CURRENCY_CD" && _data_int == 1)
                {
                    // 
                    // 基軸通貨フラグを1に設定した場合、他の通貨の基軸通貨フラグを0に更新する
                    //
                    rtn = CurrencyUpdate(db);
                    if (rtn == ComConst.FAILED)
                    {
                        db.DbRollback();
                        return rtn;
                    }
                }
                db.DbCommit();
            }
            else
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                db.DbRollback();
            }
            return rtn;
        }

        /// <summary>
        /// システムパラメータの削除
        /// 
        /// 使用画面：MstSysParaMnt
        /// </summary>
        public int Delete()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("DELETE FROM SYSTEM_PARAMETER ");
                strSQL.Append(" WHERE KEY01 = :KEY01");
                strSQL.Append(" AND KEY02 = :KEY02");
                strSQL.Append(" AND KEY03 = :KEY03");
                strSQL.Append(" AND KEY04 = :KEY04");

                db.DbParametersClear();
                db.DbPsetString("KEY01", _key01);
                db.DbPsetString("KEY02", _key02);
                db.DbPsetString("KEY03", _key03);
                db.DbPsetString("KEY04", _key04);
            }
            else
            {
                strSQL.Append("DELETE FROM SYSTEM_PARAMETER ");
                strSQL.Append(" WHERE KEY01 = @KEY01");
                strSQL.Append(" AND KEY02 = @KEY02");
                strSQL.Append(" AND KEY03 = @KEY03");
                strSQL.Append(" AND KEY04 = @KEY04");

                db.DbParametersClear();
                db.DbPsetString("@KEY01", _key01);
                db.DbPsetString("@KEY02", _key02);
                db.DbPsetString("@KEY03", _key03);
                db.DbPsetString("@KEY04", _key04);
            }

            db.DbBeginTrans();

            rtn = db.DbExecute(strSQL.ToString());
            if (rtn != ComConst.FAILED)
            {
                db.DbCommit();
            }
            else
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                db.DbRollback();
            }

            return rtn;
        }

        /// <summary>
        /// システムパラメータ詳細の取得
        /// 指定したKEY01-KEY04の内容を取得する
        /// 
        /// 使用画面：MstSysParaMnt
        /// </summary>
        public int GetDetail()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            strSQL.Append("SELECT KEY02, DATA_CHAR, DATA_CHAR2, DATA_CHAR3,");
            strSQL.Append("DATA_CHAR4, DATA_CHAR5, DATA_CHAR6,");

            switch (_lang)
            {
                case 2:
                    strSQL.Append("DATA_CHAR2 AS DATA_CHAR0, ");
                    break;
                case 3:
                    strSQL.Append("DATA_CHAR3 AS DATA_CHAR0, ");
                    break;
                default:
                    strSQL.Append("DATA_CHAR AS DATA_CHAR0, ");
                    break;
            }

            strSQL.Append("DATA_INT, DATA_DEC, DATA_DEC2, DATA_DEC3, DATA_DEC4,");
            strSQL.Append("REMARKS1, REMARKS2, REMARKS3,");
            strSQL.Append("ENTRY_DATE, CHG_DATE, CHG_USER_ID, UPDATE_CNTR");
            strSQL.Append(" FROM SYSTEM_PARAMETER ");

            if (_db_type == "ORACLE")
            {
                strSQL.Append(" WHERE KEY01 = :KEY01");                
                
                db.DbParametersClear();
                db.DbPsetString("KEY01", _key01);
                
                if (base_cur_flag == 1)
                {
                    strSQL.Append(" AND DATA_INT = @DATA_INT ");
                    db.DbPsetInt("@DATA_INT", _data_int);
                }
                else
                {
                    strSQL.Append(" AND KEY02 = :KEY02");
                    strSQL.Append(" AND KEY03 = :KEY03");
                    strSQL.Append(" AND KEY04 = :KEY04");
                    db.DbPsetString("KEY02", _key02);
                    db.DbPsetString("KEY03", _key03);
                    db.DbPsetString("KEY04", _key04);
                }
            }
            else
            {
                strSQL.Append(" WHERE KEY01 = @KEY01");
                        

                db.DbParametersClear();
                db.DbPsetString("@KEY01", _key01);
                
                if (base_cur_flag == 1)
                {
                    strSQL.Append(" AND DATA_INT = @DATA_INT ");
                    db.DbPsetInt("@DATA_INT", _data_int);
                }
                else
                {
                    strSQL.Append(" AND KEY02 = @KEY02");
                    strSQL.Append(" AND KEY03 = @KEY03");
                    strSQL.Append(" AND KEY04 = @KEY04");
                    db.DbPsetString("@KEY02", _key02);
                    db.DbPsetString("@KEY03", _key03);
                    db.DbPsetString("@KEY04", _key04);
                }               
            }

            rtn = db.DbExecuteReader(strSQL.ToString());
            if (rtn == ComConst.FAILED)
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
            }
            else
            {
                _key02 = db.Row("KEY02");//add by zhao 20090520
                _data_char = db.Row("DATA_CHAR");
                _data_char2 = db.Row("DATA_CHAR2");
                _data_char3 = db.Row("DATA_CHAR3");
                _data_char4 = db.Row("DATA_CHAR4");
                _data_char5 = db.Row("DATA_CHAR5");
                _data_char6 = db.Row("DATA_CHAR6");
                _data_char0 = db.Row("DATA_CHAR0");
                _data_int = int.Parse(db.Row("DATA_INT"));
                _data_dec = double.Parse(db.Row("DATA_DEC"));
                _data_dec2 = double.Parse(db.Row("DATA_DEC2"));
                _data_dec3 = double.Parse(db.Row("DATA_DEC3"));
                _data_dec4 = double.Parse(db.Row("DATA_DEC4"));
                _remarks1 = db.Row("REMARKS1");
                _remarks2 = db.Row("REMARKS2");
                _remarks3 = db.Row("REMARKS3");
                _entry_date = DateTime.Parse(db.Row("ENTRY_DATE"));
                _chg_date = DateTime.Parse(db.Row("CHG_DATE"));
                _chg_user_id = db.Row("CHG_USER_ID");
                _update_cntr = int.Parse(db.Row("UPDATE_CNTR"));
            }
            if (db.State() == ConnectionState.Open)
                db.DbClose();

            return rtn;
        }

        /// <summary>
        /// システムパラメータ一覧の取得
        /// 指定したKEY01のシステムパラメータ一覧を取得する
        /// 
        /// 使用画面：MstSysParaMnt
        /// </summary>
        public DataSet GetDetailList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append("SELECT KEY02, KEY03, KEY04,                          ");
            strSQL.Append("DATA_CHAR, DATA_CHAR2, DATA_CHAR3,                   ");
            strSQL.Append("DATA_CHAR4, DATA_CHAR5, DATA_CHAR6,                  ");
            strSQL.Append("DATA_INT, DATA_DEC, DATA_DEC2, DATA_DEC3, DATA_DEC4, ");
            strSQL.Append("REMARKS1, REMARKS2, REMARKS3                         ");
            strSQL.Append(" FROM SYSTEM_PARAMETER                               ");

            if (_db_type == "ORACLE")
            {
                strSQL.Append(" WHERE KEY01 = :KEY01");

                strSQL.Append(" ORDER BY KEY01, KEY02, KEY03, KEY04");
                db.DbParametersClear();
                db.DbPsetString("KEY01", _key01);
            }
            else
            {
                strSQL.Append(" WHERE KEY01 = @KEY01");

                strSQL.Append(" ORDER BY KEY01, KEY02, KEY03, KEY04");
                db.DbParametersClear();
                db.DbPsetString("@KEY01", _key01);
            }

            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "sp");
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

        //Add 10.11.10 Ubiq-Sai Start
        /// <summary>
        /// システムパラメータ一覧の取得
        /// 指定したKEY01,Data_intのシステムパラメータ一覧を取得する
        /// 
        /// 使用画面：MstSysParaMnt
        /// </summary>
        public DataSet GetDetailList2()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append("SELECT KEY02, KEY03, KEY04,                          ");
            strSQL.Append("DATA_CHAR, DATA_CHAR2, DATA_CHAR3,                   ");
            strSQL.Append("DATA_CHAR4, DATA_CHAR5, DATA_CHAR6,                  ");
            strSQL.Append("DATA_INT, DATA_DEC, DATA_DEC2, DATA_DEC3, DATA_DEC4, ");
            strSQL.Append("REMARKS1, REMARKS2, REMARKS3                         ");
            strSQL.Append(" FROM SYSTEM_PARAMETER                               ");

            if (_db_type == "ORACLE")
            {
                strSQL.Append(" WHERE KEY01 = :KEY01");
                strSQL.Append("   AND DATA_CHAR2 = :DATA_CHAR2");

                strSQL.Append(" ORDER BY KEY01, KEY02, KEY03, KEY04");
                db.DbParametersClear();
                db.DbPsetString("KEY01", _key01);
                db.DbPsetString("DATA_CHAR2", _data_char2);
            }
            else
            {
                strSQL.Append(" WHERE KEY01 = @KEY01");
                strSQL.Append("   AND DATA_CHAR2 = @DATA_CHAR2");

                strSQL.Append(" ORDER BY KEY01, KEY02, KEY03, KEY04");
                db.DbParametersClear();
                db.DbPsetString("@KEY01", _key01);
                db.DbPsetString("@DATA_CHAR2", _data_char2);
            }

            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "sp");
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
        //Add 10.11.10 Ubiq-Sai End

        /// <summary>
        /// システムパラメータ一覧の取得
        /// 指定したKEY01のシステムパラメータ一覧を取得する
        /// 
        /// 使用画面：InvStockTakingAct
        /// </summary>
        public DataSet GetDetailList1()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append("SELECT KEY02, KEY03, KEY04,                          ");
            strSQL.Append("DATA_CHAR, DATA_CHAR2, DATA_CHAR3,                   ");
            strSQL.Append("DATA_CHAR4, DATA_CHAR5, DATA_CHAR6,                  ");
            strSQL.Append("DATA_INT, DATA_DEC, DATA_DEC2, DATA_DEC3, DATA_DEC4, ");
            strSQL.Append("REMARKS1, REMARKS2, REMARKS3                         ");
            strSQL.Append(" FROM SYSTEM_PARAMETER                               ");

            if (_db_type == "ORACLE")
            {
                strSQL.Append(" WHERE KEY01 = :KEY01");
                strSQL.Append(" AND KEY02 = :KEY02");

                strSQL.Append(" ORDER BY KEY01, KEY02, KEY03, KEY04");
                db.DbParametersClear();
                db.DbPsetString("KEY01", _key01);
                db.DbPsetString("KEY02", _key02);
            }
            else
            {
                strSQL.Append(" WHERE KEY01 = @KEY01");
                strSQL.Append(" AND KEY02 = @KEY02");

                strSQL.Append(" ORDER BY KEY01, KEY02, KEY03, KEY04");
                db.DbParametersClear();
                db.DbPsetString("@KEY01", _key01);
                db.DbPsetString("@KEY02", _key02);
            }

            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "sp");
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
        /// システムパラメータ一覧の取得
        /// 指定したKEY01のシステムパラメータの値と名称を取得する
        /// 
        /// 使用画面：MstUserMnt, MstInfoMnt
        /// </summary>
        public DataSet GetDetailValueAndDispList(int p_search)
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            if (p_search == 1)
            {
                strSQL.Append("SELECT '0' AS SORT_KEY, 'ALL' AS VALUE, NULL AS DISP ");

                if (_db_type == "ORACLE")
                {
                    strSQL.Append("FROM DUAL ");
                }
                else
                {
                }

                strSQL.Append(" UNION ");

            }

            if (p_search == 2)  // LANG用
            {
                strSQL.Append("SELECT '0' AS SORT_KEY, '-1' AS VALUE, 'ALL' AS DISP ");

                if (_db_type == "ORACLE")
                {
                    strSQL.Append("FROM DUAL ");
                }
                else
                {
                }

                strSQL.Append(" UNION ALL ");

                strSQL.Append("SELECT '0' AS SORT_KEY, '0' AS VALUE, 'COMMON' AS DISP ");

                if (_db_type == "ORACLE")
                {
                    strSQL.Append("FROM DUAL ");
                }
                else
                {
                }

                strSQL.Append(" UNION ALL ");

            }

            if (p_search == 3)  // LANG用
            {
                strSQL.Append("SELECT '0' AS SORT_KEY, '0' AS VALUE, 'COMMON' AS DISP ");

                if (_db_type == "ORACLE")
                {
                    strSQL.Append("FROM DUAL ");
                }
                else
                {
                }

                strSQL.Append(" UNION ALL ");

            }

            strSQL.Append("SELECT KEY02 AS SORT_KEY, KEY02 AS VALUE, ");

            switch (_lang)
            {
                case 2:
                    strSQL.Append("DATA_CHAR2 AS DISP ");
                    break;
                case 3:
                    strSQL.Append("DATA_CHAR3 AS DISP ");
                    break;
                case 4:
                    strSQL.Append("DATA_CHAR4 AS DISP ");//2009.03.19 ADD
                    break;
                default:
                    strSQL.Append("DATA_CHAR AS DISP ");
                    break;
            }

            strSQL.Append(" FROM SYSTEM_PARAMETER ");

            if (_db_type == "ORACLE")
            {
                strSQL.Append(" WHERE KEY01 = :KEY01");
                strSQL.Append(" ORDER BY 1, 2");
                db.DbParametersClear();
                db.DbPsetString("KEY01", _key01);
            }
            else
            {
                strSQL.Append(" WHERE KEY01 = @KEY01");
                strSQL.Append(" ORDER BY 1, 2");
                db.DbParametersClear();
                db.DbPsetString("@KEY01", _key01);
            }


            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "sp");
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
        /// システムパラメータヘッダーの追加
        /// 
        /// 使用画面：MstSysParaHeaderMnt
        /// </summary>
        public int InsertHeader()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("INSERT INTO SYSTEM_PARAMETER_HEADER ");
                strSQL.Append("(");
                strSQL.Append("KEY01, HEADER_DESC1, HEADER_DESC2, HEADER_DESC3, HEADER_DESC4,");
                strSQL.Append("KEY02_LABEL1, KEY02_LABEL2, KEY02_LABEL3, KEY02_LABEL4,");
                strSQL.Append("KEY02_DESC1, KEY02_DESC2, KEY02_DESC3, KEY02_DESC4, KEY02_DIGIT,");
                strSQL.Append("KEY03_LABEL1, KEY03_LABEL2, KEY03_LABEL3, KEY03_LABEL4,");
                strSQL.Append("KEY03_DESC1, KEY03_DESC2, KEY03_DESC3, KEY03_DESC4, KEY03_DIGIT,");
                strSQL.Append("KEY04_LABEL1, KEY04_LABEL2, KEY04_LABEL3, KEY04_LABEL4,");
                strSQL.Append("KEY04_DESC1, KEY04_DESC2, KEY04_DESC3, KEY04_DESC4, KEY04_DIGIT,");
                strSQL.Append("DATA_CHAR_LABEL1, DATA_CHAR_LABEL2, DATA_CHAR_LABEL3, DATA_CHAR_LABEL4,");
                strSQL.Append("DATA_CHAR_DESC1, DATA_CHAR_DESC2, DATA_CHAR_DESC3, DATA_CHAR_DESC4, ");
                strSQL.Append("DATA_CHAR2_LABEL1, DATA_CHAR2_LABEL2, DATA_CHAR2_LABEL3, DATA_CHAR2_LABEL4,");
                strSQL.Append("DATA_CHAR2_DESC1, DATA_CHAR2_DESC2, DATA_CHAR2_DESC3, DATA_CHAR2_DESC4,");
                strSQL.Append("DATA_CHAR3_LABEL1, DATA_CHAR3_LABEL2, DATA_CHAR3_LABEL3, DATA_CHAR3_LABEL4,");
                strSQL.Append("DATA_CHAR3_DESC1, DATA_CHAR3_DESC2, DATA_CHAR3_DESC3, DATA_CHAR3_DESC4,");
                strSQL.Append("DATA_CHAR4_LABEL1, DATA_CHAR4_LABEL2, DATA_CHAR4_LABEL3, DATA_CHAR4_LABEL4,");
                strSQL.Append("DATA_CHAR4_DESC1, DATA_CHAR4_DESC2, DATA_CHAR4_DESC3, DATA_CHAR4_DESC4,");
                strSQL.Append("DATA_CHAR5_LABEL1, DATA_CHAR5_LABEL2, DATA_CHAR5_LABEL3, DATA_CHAR5_LABEL4,");
                strSQL.Append("DATA_CHAR5_DESC1, DATA_CHAR5_DESC2, DATA_CHAR5_DESC3, DATA_CHAR5_DESC4,");
                strSQL.Append("DATA_CHAR6_LABEL1, DATA_CHAR6_LABEL2, DATA_CHAR6_LABEL3, DATA_CHAR6_LABEL4,");
                strSQL.Append("DATA_CHAR6_DESC1, DATA_CHAR6_DESC2, DATA_CHAR6_DESC3, DATA_CHAR6_DESC4,");
                strSQL.Append("DATA_INT_LABEL1, DATA_INT_LABEL2, DATA_INT_LABEL3, DATA_INT_LABEL4,");
                strSQL.Append("DATA_INT_DESC1, DATA_INT_DESC2, DATA_INT_DESC3, DATA_INT_DESC4,");
                strSQL.Append("DATA_DEC_LABEL1, DATA_DEC_LABEL2, DATA_DEC_LABEL3, DATA_DEC_LABEL4,");
                strSQL.Append("DATA_DEC_DESC1, DATA_DEC_DESC2, DATA_DEC_DESC3, DATA_DEC_DESC4,");
                strSQL.Append("DATA_DEC2_LABEL1, DATA_DEC2_LABEL2, DATA_DEC2_LABEL3, DATA_DEC2_LABEL4,");
                strSQL.Append("DATA_DEC2_DESC1, DATA_DEC2_DESC2, DATA_DEC2_DESC3, DATA_DEC2_DESC4,");
                strSQL.Append("DATA_DEC3_LABEL1, DATA_DEC3_LABEL2, DATA_DEC3_LABEL3, DATA_DEC3_LABEL4,");
                strSQL.Append("DATA_DEC3_DESC1, DATA_DEC3_DESC2, DATA_DEC3_DESC3, DATA_DEC3_DESC4,");
                strSQL.Append("DATA_DEC4_LABEL1, DATA_DEC4_LABEL2, DATA_DEC4_LABEL3, DATA_DEC4_LABEL4,");
                strSQL.Append("DATA_DEC4_DESC1, DATA_DEC4_DESC2, DATA_DEC4_DESC3, DATA_DEC4_DESC4,");
                strSQL.Append("ENTRY_DATE, CHG_DATE, CHG_USER_ID, UPDATE_CNTR");
                strSQL.Append(") VALUES (");
                strSQL.Append(":KEY01, :HEADER_DESC1, :HEADER_DESC2, :HEADER_DESC3, :HEADER_DESC4,");
                strSQL.Append(":KEY02_LABEL1, :KEY02_LABEL2, :KEY02_LABEL3, :KEY02_LABEL4,");
                strSQL.Append(":KEY02_DESC1, :KEY02_DESC2, :KEY02_DESC3, :KEY02_DESC4, :KEY02_DIGIT,");
                strSQL.Append(":KEY03_LABEL1, :KEY03_LABEL2, :KEY03_LABEL3, :KEY03_LABEL4,");
                strSQL.Append(":KEY03_DESC1, :KEY03_DESC2, :KEY03_DESC3, :KEY03_DESC4, :KEY03_DIGIT,");
                strSQL.Append(":KEY04_LABEL1, :KEY04_LABEL2, :KEY04_LABEL3, :KEY04_LABEL4,");
                strSQL.Append(":KEY04_DESC1, :KEY04_DESC2, :KEY04_DESC3, :KEY04_DESC4, :KEY04_DIGIT,");
                strSQL.Append(":DATA_CHAR_LABEL1, :DATA_CHAR_LABEL2, :DATA_CHAR_LABEL3, :DATA_CHAR_LABEL4,");
                strSQL.Append(":DATA_CHAR_DESC1, :DATA_CHAR_DESC2, :DATA_CHAR_DESC3, :DATA_CHAR_DESC4,");
                strSQL.Append(":DATA_CHAR2_LABEL1, :DATA_CHAR2_LABEL2, :DATA_CHAR2_LABEL3, :DATA_CHAR2_LABEL4,");
                strSQL.Append(":DATA_CHAR2_DESC1, :DATA_CHAR2_DESC2, :DATA_CHAR2_DESC3, :DATA_CHAR2_DESC4,");
                strSQL.Append(":DATA_CHAR3_LABEL1, :DATA_CHAR3_LABEL2, :DATA_CHAR3_LABEL3, :DATA_CHAR3_LABEL4,");
                strSQL.Append(":DATA_CHAR3_DESC1, :DATA_CHAR3_DESC2, :DATA_CHAR3_DESC3, :DATA_CHAR3_DESC4,");
                strSQL.Append(":DATA_CHAR4_LABEL1, :DATA_CHAR4_LABEL2, :DATA_CHAR4_LABEL3, :DATA_CHAR4_LABEL4,");
                strSQL.Append(":DATA_CHAR4_DESC1, :DATA_CHAR4_DESC2, :DATA_CHAR4_DESC3, :DATA_CHAR4_DESC4,");
                strSQL.Append(":DATA_CHAR5_LABEL1, :DATA_CHAR5_LABEL2, :DATA_CHAR5_LABEL3, :DATA_CHAR5_LABEL4,");
                strSQL.Append(":DATA_CHAR5_DESC1, :DATA_CHAR5_DESC2, :DATA_CHAR5_DESC3, :DATA_CHAR5_DESC4,");
                strSQL.Append(":DATA_CHAR6_LABEL1, :DATA_CHAR6_LABEL2, :DATA_CHAR6_LABEL3, :DATA_CHAR6_LABEL4,");
                strSQL.Append(":DATA_CHAR6_DESC1, :DATA_CHAR6_DESC2, :DATA_CHAR6_DESC3, :DATA_CHAR6_DESC4,");
                strSQL.Append(":DATA_INT_LABEL1, :DATA_INT_LABEL2, :DATA_INT_LABEL3, :DATA_INT_LABEL4,");
                strSQL.Append(":DATA_INT_DESC1, :DATA_INT_DESC2, :DATA_INT_DESC3, :DATA_INT_DESC4,");
                strSQL.Append(":DATA_DEC_LABEL1, :DATA_DEC_LABEL2, :DATA_DEC_LABEL3, :DATA_DEC_LABEL4,");
                strSQL.Append(":DATA_DEC_DESC1, :DATA_DEC_DESC2, :DATA_DEC_DESC3, :DATA_DEC_DESC4,");
                strSQL.Append(":DATA_DEC2_LABEL1, :DATA_DEC2_LABEL2, :DATA_DEC2_LABEL3, :DATA_DEC2_LABEL4,");
                strSQL.Append(":DATA_DEC2_DESC1, :DATA_DEC2_DESC2, :DATA_DEC2_DESC3, :DATA_DEC2_DESC4,");
                strSQL.Append(":DATA_DEC3_LABEL1, :DATA_DEC3_LABEL2, :DATA_DEC3_LABEL3, :DATA_DEC3_LABEL4,");
                strSQL.Append(":DATA_DEC3_DESC1, :DATA_DEC3_DESC2, :DATA_DEC3_DESC3, :DATA_DEC3_DESC4,");
                strSQL.Append(":DATA_DEC4_LABEL1, :DATA_DEC4_LABEL2, :DATA_DEC4_LABEL3, :DATA_DEC4_LABEL4,");
                strSQL.Append(":DATA_DEC4_DESC1, :DATA_DEC4_DESC2, :DATA_DEC4_DESC3, :DATA_DEC4_DESC4,");
                strSQL.Append(":ENTRY_DATE, :CHG_DATE, :CHG_USER_ID, :UPDATE_CNTR)");

                db.DbParametersClear();
                db.DbPsetString("KEY01", _key01);
                db.DbPsetString("HEADER_DESC1", _header_desc1);
                db.DbPsetString("HEADER_DESC2", _header_desc2);
                db.DbPsetString("HEADER_DESC3", _header_desc3);
                db.DbPsetString("HEADER_DESC4", _header_desc4);
                db.DbPsetString("KEY02_LABEL1", _key02_label1);
                db.DbPsetString("KEY02_LABEL2", _key02_label2);
                db.DbPsetString("KEY02_LABEL3", _key02_label3);
                db.DbPsetString("KEY02_LABEL4", _key02_label4);
                db.DbPsetString("KEY02_DESC1", _key02_desc1);
                db.DbPsetString("KEY02_DESC2", _key02_desc2);
                db.DbPsetString("KEY02_DESC3", _key02_desc3);
                db.DbPsetString("KEY02_DESC4", _key02_desc4);
                db.DbPsetInt("KEY02_DIGIT", _key02_digit);
                db.DbPsetString("KEY03_LABEL1", _key03_label1);
                db.DbPsetString("KEY03_LABEL2", _key03_label2);
                db.DbPsetString("KEY03_LABEL3", _key03_label3);
                db.DbPsetString("KEY03_LABEL4", _key03_label4);
                db.DbPsetString("KEY03_DESC1", _key03_desc1);
                db.DbPsetString("KEY03_DESC2", _key03_desc2);
                db.DbPsetString("KEY03_DESC3", _key03_desc3);
                db.DbPsetString("KEY03_DESC4", _key03_desc4);
                db.DbPsetInt("KEY03_DIGIT", _key03_digit);
                db.DbPsetString("KEY04_LABEL1", _key04_label1);
                db.DbPsetString("KEY04_LABEL2", _key04_label2);
                db.DbPsetString("KEY04_LABEL3", _key04_label3);
                db.DbPsetString("KEY04_LABEL4", _key04_label4);
                db.DbPsetString("KEY04_DESC1", _key04_desc1);
                db.DbPsetString("KEY04_DESC2", _key04_desc2);
                db.DbPsetString("KEY04_DESC3", _key04_desc3);
                db.DbPsetString("KEY04_DESC4", _key04_desc4);
                db.DbPsetInt("KEY04_DIGIT", _key04_digit);
                db.DbPsetString("DATA_CHAR_LABEL1", _data_char_label1);
                db.DbPsetString("DATA_CHAR_LABEL2", _data_char_label2);
                db.DbPsetString("DATA_CHAR_LABEL3", _data_char_label3);
                db.DbPsetString("DATA_CHAR_LABEL4", _data_char_label4);
                db.DbPsetString("DATA_CHAR_DESC1", _data_char_desc1);
                db.DbPsetString("DATA_CHAR_DESC2", _data_char_desc2);
                db.DbPsetString("DATA_CHAR_DESC3", _data_char_desc3);
                db.DbPsetString("DATA_CHAR_DESC4", _data_char_desc4);
                db.DbPsetString("DATA_CHAR2_LABEL1", _data_char2_label1);
                db.DbPsetString("DATA_CHAR2_LABEL2", _data_char2_label2);
                db.DbPsetString("DATA_CHAR2_LABEL3", _data_char2_label3);
                db.DbPsetString("DATA_CHAR2_LABEL4", _data_char2_label4);
                db.DbPsetString("DATA_CHAR2_DESC1", _data_char2_desc1);
                db.DbPsetString("DATA_CHAR2_DESC2", _data_char2_desc2);
                db.DbPsetString("DATA_CHAR2_DESC3", _data_char2_desc3);
                db.DbPsetString("DATA_CHAR2_DESC4", _data_char2_desc4);
                db.DbPsetString("DATA_CHAR3_LABEL1", _data_char3_label1);
                db.DbPsetString("DATA_CHAR3_LABEL2", _data_char3_label2);
                db.DbPsetString("DATA_CHAR3_LABEL3", _data_char3_label3);
                db.DbPsetString("DATA_CHAR3_LABEL4", _data_char3_label4);
                db.DbPsetString("DATA_CHAR3_DESC1", _data_char3_desc1);
                db.DbPsetString("DATA_CHAR3_DESC2", _data_char3_desc2);
                db.DbPsetString("DATA_CHAR3_DESC3", _data_char3_desc3);
                db.DbPsetString("DATA_CHAR3_DESC4", _data_char3_desc4);
                db.DbPsetString("DATA_CHAR4_LABEL1", _data_char4_label1);
                db.DbPsetString("DATA_CHAR4_LABEL2", _data_char4_label2);
                db.DbPsetString("DATA_CHAR4_LABEL3", _data_char4_label3);
                db.DbPsetString("DATA_CHAR4_LABEL4", _data_char4_label4);
                db.DbPsetString("DATA_CHAR4_DESC1", _data_char4_desc1);
                db.DbPsetString("DATA_CHAR4_DESC2", _data_char4_desc2);
                db.DbPsetString("DATA_CHAR4_DESC3", _data_char4_desc3);
                db.DbPsetString("DATA_CHAR4_DESC4", _data_char4_desc4);
                db.DbPsetString("DATA_CHAR5_LABEL1", _data_char5_label1);
                db.DbPsetString("DATA_CHAR5_LABEL2", _data_char5_label2);
                db.DbPsetString("DATA_CHAR5_LABEL3", _data_char5_label3);
                db.DbPsetString("DATA_CHAR5_LABEL4", _data_char5_label4);
                db.DbPsetString("DATA_CHAR5_DESC1", _data_char5_desc1);
                db.DbPsetString("DATA_CHAR5_DESC2", _data_char5_desc2);
                db.DbPsetString("DATA_CHAR5_DESC3", _data_char5_desc3);
                db.DbPsetString("DATA_CHAR5_DESC4", _data_char5_desc4);
                db.DbPsetString("DATA_CHAR6_LABEL1", _data_char6_label1);
                db.DbPsetString("DATA_CHAR6_LABEL2", _data_char6_label2);
                db.DbPsetString("DATA_CHAR6_LABEL3", _data_char6_label3);
                db.DbPsetString("DATA_CHAR6_LABEL4", _data_char6_label4);
                db.DbPsetString("DATA_CHAR6_DESC1", _data_char6_desc1);
                db.DbPsetString("DATA_CHAR6_DESC2", _data_char6_desc2);
                db.DbPsetString("DATA_CHAR6_DESC3", _data_char6_desc3);
                db.DbPsetString("DATA_CHAR6_DESC4", _data_char6_desc4);
                db.DbPsetString("DATA_INT_LABEL1", _data_int_label1);
                db.DbPsetString("DATA_INT_LABEL2", _data_int_label2);
                db.DbPsetString("DATA_INT_LABEL3", _data_int_label3);
                db.DbPsetString("DATA_INT_LABEL4", _data_int_label4);
                db.DbPsetString("DATA_INT_DESC1", _data_int_desc1);
                db.DbPsetString("DATA_INT_DESC2", _data_int_desc2);
                db.DbPsetString("DATA_INT_DESC3", _data_int_desc3);
                db.DbPsetString("DATA_INT_DESC4", _data_int_desc4);
                db.DbPsetString("DATA_DEC_LABEL1", _data_dec_label1);
                db.DbPsetString("DATA_DEC_LABEL2", _data_dec_label2);
                db.DbPsetString("DATA_DEC_LABEL3", _data_dec_label3);
                db.DbPsetString("DATA_DEC_LABEL4", _data_dec_label4);
                db.DbPsetString("DATA_DEC_DESC1", _data_dec_desc1);
                db.DbPsetString("DATA_DEC_DESC2", _data_dec_desc2);
                db.DbPsetString("DATA_DEC_DESC3", _data_dec_desc3);
                db.DbPsetString("DATA_DEC_DESC4", _data_dec_desc4);
                db.DbPsetString("DATA_DEC2_LABEL1", _data_dec2_label1);
                db.DbPsetString("DATA_DEC2_LABEL2", _data_dec2_label2);
                db.DbPsetString("DATA_DEC2_LABEL3", _data_dec2_label3);
                db.DbPsetString("DATA_DEC2_LABEL4", _data_dec2_label4);
                db.DbPsetString("DATA_DEC2_DESC1", _data_dec2_desc1);
                db.DbPsetString("DATA_DEC2_DESC2", _data_dec2_desc2);
                db.DbPsetString("DATA_DEC2_DESC3", _data_dec2_desc3);
                db.DbPsetString("DATA_DEC2_DESC4", _data_dec2_desc4);
                db.DbPsetString("DATA_DEC3_LABEL1", _data_dec3_label1);
                db.DbPsetString("DATA_DEC3_LABEL2", _data_dec3_label2);
                db.DbPsetString("DATA_DEC3_LABEL3", _data_dec3_label3);
                db.DbPsetString("DATA_DEC3_LABEL4", _data_dec3_label4);
                db.DbPsetString("DATA_DEC3_DESC1", _data_dec3_desc1);
                db.DbPsetString("DATA_DEC3_DESC2", _data_dec3_desc2);
                db.DbPsetString("DATA_DEC3_DESC3", _data_dec3_desc3);
                db.DbPsetString("DATA_DEC3_DESC4", _data_dec3_desc4);
                db.DbPsetString("DATA_DEC4_LABEL1", _data_dec4_label1);
                db.DbPsetString("DATA_DEC4_LABEL2", _data_dec4_label2);
                db.DbPsetString("DATA_DEC4_LABEL3", _data_dec4_label3);
                db.DbPsetString("DATA_DEC4_LABEL4", _data_dec4_label4);
                db.DbPsetString("DATA_DEC4_DESC1", _data_dec4_desc1);
                db.DbPsetString("DATA_DEC4_DESC2", _data_dec4_desc2);
                db.DbPsetString("DATA_DEC4_DESC3", _data_dec4_desc3);
                db.DbPsetString("DATA_DEC4_DESC4", _data_dec4_desc4);
                db.DbPsetDate("ENTRY_DATE", _entry_date);
                db.DbPsetDate("CHG_DATE", _chg_date);
                db.DbPsetString("CHG_USER_ID", _chg_user_id);
                db.DbPsetInt("UPDATE_CNTR", _update_cntr);
            }
            else
            {
                strSQL.Append("INSERT INTO SYSTEM_PARAMETER_HEADER ");
                strSQL.Append("(");
                strSQL.Append("KEY01, HEADER_DESC1, HEADER_DESC2, HEADER_DESC3, HEADER_DESC4,");
                strSQL.Append("KEY02_LABEL1, KEY02_LABEL2, KEY02_LABEL3, KEY02_LABEL4,");
                strSQL.Append("KEY02_DESC1, KEY02_DESC2, KEY02_DESC3, KEY02_DESC4, KEY02_DIGIT,");
                strSQL.Append("KEY03_LABEL1, KEY03_LABEL2, KEY03_LABEL3, KEY03_LABEL4,");
                strSQL.Append("KEY03_DESC1, KEY03_DESC2, KEY03_DESC3, KEY03_DESC4, KEY03_DIGIT,");
                strSQL.Append("KEY04_LABEL1, KEY04_LABEL2, KEY04_LABEL3, KEY04_LABEL4,");
                strSQL.Append("KEY04_DESC1, KEY04_DESC2, KEY04_DESC3, KEY04_DESC4, KEY04_DIGIT,");
                strSQL.Append("DATA_CHAR_LABEL1, DATA_CHAR_LABEL2, DATA_CHAR_LABEL3, DATA_CHAR_LABEL4,");
                strSQL.Append("DATA_CHAR_DESC1, DATA_CHAR_DESC2, DATA_CHAR_DESC3, DATA_CHAR_DESC4,");
                strSQL.Append("DATA_CHAR2_LABEL1, DATA_CHAR2_LABEL2, DATA_CHAR2_LABEL3, DATA_CHAR2_LABEL4,");
                strSQL.Append("DATA_CHAR2_DESC1, DATA_CHAR2_DESC2, DATA_CHAR2_DESC3, DATA_CHAR2_DESC4,");
                strSQL.Append("DATA_CHAR3_LABEL1, DATA_CHAR3_LABEL2, DATA_CHAR3_LABEL3, DATA_CHAR3_LABEL4,");
                strSQL.Append("DATA_CHAR3_DESC1, DATA_CHAR3_DESC2, DATA_CHAR3_DESC3, DATA_CHAR3_DESC4,");
                strSQL.Append("DATA_CHAR4_LABEL1, DATA_CHAR4_LABEL2, DATA_CHAR4_LABEL3, DATA_CHAR4_LABEL4,");
                strSQL.Append("DATA_CHAR4_DESC1, DATA_CHAR4_DESC2, DATA_CHAR4_DESC3, DATA_CHAR4_DESC4,");
                strSQL.Append("DATA_CHAR5_LABEL1, DATA_CHAR5_LABEL2, DATA_CHAR5_LABEL3, DATA_CHAR5_LABEL4,");
                strSQL.Append("DATA_CHAR5_DESC1, DATA_CHAR5_DESC2, DATA_CHAR5_DESC3, DATA_CHAR5_DESC4,");
                strSQL.Append("DATA_CHAR6_LABEL1, DATA_CHAR6_LABEL2, DATA_CHAR6_LABEL3, DATA_CHAR6_LABEL4,");
                strSQL.Append("DATA_CHAR6_DESC1, DATA_CHAR6_DESC2, DATA_CHAR6_DESC3, DATA_CHAR6_DESC4,");
                strSQL.Append("DATA_INT_LABEL1, DATA_INT_LABEL2, DATA_INT_LABEL3, DATA_INT_LABEL4,");
                strSQL.Append("DATA_INT_DESC1, DATA_INT_DESC2, DATA_INT_DESC3, DATA_INT_DESC4,");
                strSQL.Append("DATA_DEC_LABEL1, DATA_DEC_LABEL2, DATA_DEC_LABEL3, DATA_DEC_LABEL4,");
                strSQL.Append("DATA_DEC_DESC1, DATA_DEC_DESC2, DATA_DEC_DESC3, DATA_DEC_DESC4,");
                strSQL.Append("DATA_DEC2_LABEL1, DATA_DEC2_LABEL2, DATA_DEC2_LABEL3, DATA_DEC2_LABEL4,");
                strSQL.Append("DATA_DEC2_DESC1, DATA_DEC2_DESC2, DATA_DEC2_DESC3, DATA_DEC2_DESC4,");
                strSQL.Append("DATA_DEC3_LABEL1, DATA_DEC3_LABEL2, DATA_DEC3_LABEL3, DATA_DEC3_LABEL4,");
                strSQL.Append("DATA_DEC3_DESC1, DATA_DEC3_DESC2, DATA_DEC3_DESC3, DATA_DEC3_DESC4,");
                strSQL.Append("DATA_DEC4_LABEL1, DATA_DEC4_LABEL2, DATA_DEC4_LABEL3, DATA_DEC4_LABEL4,");
                strSQL.Append("DATA_DEC4_DESC1, DATA_DEC4_DESC2, DATA_DEC4_DESC3, DATA_DEC4_DESC4,");
                strSQL.Append("ENTRY_DATE, CHG_DATE, CHG_USER_ID, UPDATE_CNTR");
                strSQL.Append(") VALUES (");
                strSQL.Append("@KEY01, @HEADER_DESC1, @HEADER_DESC2, @HEADER_DESC3,@HEADER_DESC4,");
                strSQL.Append("@KEY02_LABEL1, @KEY02_LABEL2, @KEY02_LABEL3,@KEY02_LABEL4,");
                strSQL.Append("@KEY02_DESC1, @KEY02_DESC2, @KEY02_DESC3, @KEY02_DESC4, @KEY02_DIGIT,");
                strSQL.Append("@KEY03_LABEL1, @KEY03_LABEL2, @KEY03_LABEL3,@KEY03_LABEL4,");
                strSQL.Append("@KEY03_DESC1, @KEY03_DESC2, @KEY03_DESC3, @KEY03_DESC4, @KEY03_DIGIT,");
                strSQL.Append("@KEY04_LABEL1, @KEY04_LABEL2, @KEY04_LABEL3, @KEY04_LABEL4,");
                strSQL.Append("@KEY04_DESC1, @KEY04_DESC2, @KEY04_DESC3, @KEY04_DESC4, @KEY04_DIGIT,");
                strSQL.Append("@DATA_CHAR_LABEL1, @DATA_CHAR_LABEL2, @DATA_CHAR_LABEL3, @DATA_CHAR_LABEL4,");
                strSQL.Append("@DATA_CHAR_DESC1, @DATA_CHAR_DESC2, @DATA_CHAR_DESC3, @DATA_CHAR_DESC4,");
                strSQL.Append("@DATA_CHAR2_LABEL1, @DATA_CHAR2_LABEL2, @DATA_CHAR2_LABEL3, @DATA_CHAR2_LABEL4,");
                strSQL.Append("@DATA_CHAR2_DESC1, @DATA_CHAR2_DESC2, @DATA_CHAR2_DESC3, @DATA_CHAR2_DESC4,");
                strSQL.Append("@DATA_CHAR3_LABEL1, @DATA_CHAR3_LABEL2, @DATA_CHAR3_LABEL3, @DATA_CHAR3_LABEL4,");
                strSQL.Append("@DATA_CHAR3_DESC1, @DATA_CHAR3_DESC2, @DATA_CHAR3_DESC3, @DATA_CHAR3_DESC4,");
                strSQL.Append("@DATA_CHAR4_LABEL1, @DATA_CHAR4_LABEL2, @DATA_CHAR4_LABEL3, @DATA_CHAR4_LABEL4,");
                strSQL.Append("@DATA_CHAR4_DESC1, @DATA_CHAR4_DESC2, @DATA_CHAR4_DESC3, @DATA_CHAR4_DESC4,");
                strSQL.Append("@DATA_CHAR5_LABEL1, @DATA_CHAR5_LABEL2, @DATA_CHAR5_LABEL3, @DATA_CHAR5_LABEL4,");
                strSQL.Append("@DATA_CHAR5_DESC1, @DATA_CHAR5_DESC2, @DATA_CHAR5_DESC3, @DATA_CHAR5_DESC4,");
                strSQL.Append("@DATA_CHAR6_LABEL1, @DATA_CHAR6_LABEL2, @DATA_CHAR6_LABEL3, @DATA_CHAR6_LABEL4,");
                strSQL.Append("@DATA_CHAR6_DESC1, @DATA_CHAR6_DESC2, @DATA_CHAR6_DESC3, @DATA_CHAR6_DESC4,");
                strSQL.Append("@DATA_INT_LABEL1, @DATA_INT_LABEL2, @DATA_INT_LABEL3, @DATA_INT_LABEL4,");
                strSQL.Append("@DATA_INT_DESC1, @DATA_INT_DESC2, @DATA_INT_DESC3, @DATA_INT_DESC4,");
                strSQL.Append("@DATA_DEC_LABEL1, @DATA_DEC_LABEL2, @DATA_DEC_LABEL3, @DATA_DEC_LABEL4,");
                strSQL.Append("@DATA_DEC_DESC1, @DATA_DEC_DESC2, @DATA_DEC_DESC3, @DATA_DEC_DESC4,");
                strSQL.Append("@DATA_DEC2_LABEL1, @DATA_DEC2_LABEL2, @DATA_DEC2_LABEL3, @DATA_DEC2_LABEL4,");
                strSQL.Append("@DATA_DEC2_DESC1, @DATA_DEC2_DESC2, @DATA_DEC2_DESC3, @DATA_DEC2_DESC4,");
                strSQL.Append("@DATA_DEC3_LABEL1, @DATA_DEC3_LABEL2, @DATA_DEC3_LABEL3, @DATA_DEC3_LABEL4,");
                strSQL.Append("@DATA_DEC3_DESC1, @DATA_DEC3_DESC2, @DATA_DEC3_DESC3, @DATA_DEC3_DESC4,");
                strSQL.Append("@DATA_DEC4_LABEL1, @DATA_DEC4_LABEL2, @DATA_DEC4_LABEL3, @DATA_DEC4_LABEL4,");
                strSQL.Append("@DATA_DEC4_DESC1, @DATA_DEC4_DESC2, @DATA_DEC4_DESC3, @DATA_DEC4_DESC4,");
                strSQL.Append("@ENTRY_DATE, @CHG_DATE, @CHG_USER_ID, @UPDATE_CNTR)");

                db.DbParametersClear();
                db.DbPsetString("@KEY01", _key01);
                db.DbPsetString("@HEADER_DESC1", _header_desc1);
                db.DbPsetString("@HEADER_DESC2", _header_desc2);
                db.DbPsetString("@HEADER_DESC3", _header_desc3);
                db.DbPsetString("@HEADER_DESC4", _header_desc4);
                db.DbPsetString("@KEY02_LABEL1", _key02_label1);
                db.DbPsetString("@KEY02_LABEL2", _key02_label2);
                db.DbPsetString("@KEY02_LABEL3", _key02_label3);
                db.DbPsetString("@KEY02_LABEL4", _key02_label4);
                db.DbPsetString("@KEY02_DESC1", _key02_desc1);
                db.DbPsetString("@KEY02_DESC2", _key02_desc2);
                db.DbPsetString("@KEY02_DESC3", _key02_desc3);
                db.DbPsetString("@KEY02_DESC4", _key02_desc4);
                db.DbPsetInt("@KEY02_DIGIT", _key02_digit);
                db.DbPsetString("@KEY03_LABEL1", _key03_label1);
                db.DbPsetString("@KEY03_LABEL2", _key03_label2);
                db.DbPsetString("@KEY03_LABEL3", _key03_label3);
                db.DbPsetString("@KEY03_LABEL4", _key03_label4);
                db.DbPsetString("@KEY03_DESC1", _key03_desc1);
                db.DbPsetString("@KEY03_DESC2", _key03_desc2);
                db.DbPsetString("@KEY03_DESC3", _key03_desc3);
                db.DbPsetString("@KEY03_DESC4", _key03_desc4);
                db.DbPsetInt("@KEY03_DIGIT", _key03_digit);
                db.DbPsetString("@KEY04_LABEL1", _key04_label1);
                db.DbPsetString("@KEY04_LABEL2", _key04_label2);
                db.DbPsetString("@KEY04_LABEL3", _key04_label3);
                db.DbPsetString("@KEY04_LABEL4", _key04_label4);
                db.DbPsetString("@KEY04_DESC1", _key04_desc1);
                db.DbPsetString("@KEY04_DESC2", _key04_desc2);
                db.DbPsetString("@KEY04_DESC3", _key04_desc3);
                db.DbPsetString("@KEY04_DESC4", _key04_desc4);
                db.DbPsetInt("@KEY04_DIGIT", _key04_digit);
                db.DbPsetString("@DATA_CHAR_LABEL1", _data_char_label1);
                db.DbPsetString("@DATA_CHAR_LABEL2", _data_char_label2);
                db.DbPsetString("@DATA_CHAR_LABEL3", _data_char_label3);
                db.DbPsetString("@DATA_CHAR_LABEL4", _data_char_label4);
                db.DbPsetString("@DATA_CHAR_DESC1", _data_char_desc1);
                db.DbPsetString("@DATA_CHAR_DESC2", _data_char_desc2);
                db.DbPsetString("@DATA_CHAR_DESC3", _data_char_desc3);
                db.DbPsetString("@DATA_CHAR_DESC4", _data_char_desc4);
                db.DbPsetString("@DATA_CHAR2_LABEL1", _data_char2_label1);
                db.DbPsetString("@DATA_CHAR2_LABEL2", _data_char2_label2);
                db.DbPsetString("@DATA_CHAR2_LABEL3", _data_char2_label3);
                db.DbPsetString("@DATA_CHAR2_LABEL4", _data_char2_label4);
                db.DbPsetString("@DATA_CHAR2_DESC1", _data_char2_desc1);
                db.DbPsetString("@DATA_CHAR2_DESC2", _data_char2_desc2);
                db.DbPsetString("@DATA_CHAR2_DESC3", _data_char2_desc3);
                db.DbPsetString("@DATA_CHAR2_DESC4", _data_char2_desc4);
                db.DbPsetString("@DATA_CHAR3_LABEL1", _data_char3_label1);
                db.DbPsetString("@DATA_CHAR3_LABEL2", _data_char3_label2);
                db.DbPsetString("@DATA_CHAR3_LABEL3", _data_char3_label3);
                db.DbPsetString("@DATA_CHAR3_LABEL4", _data_char3_label4);
                db.DbPsetString("@DATA_CHAR3_DESC1", _data_char3_desc1);
                db.DbPsetString("@DATA_CHAR3_DESC2", _data_char3_desc2);
                db.DbPsetString("@DATA_CHAR3_DESC3", _data_char3_desc3);
                db.DbPsetString("@DATA_CHAR3_DESC4", _data_char3_desc4);
                db.DbPsetString("@DATA_CHAR4_LABEL1", _data_char4_label1);
                db.DbPsetString("@DATA_CHAR4_LABEL2", _data_char4_label2);
                db.DbPsetString("@DATA_CHAR4_LABEL3", _data_char4_label3);
                db.DbPsetString("@DATA_CHAR4_LABEL4", _data_char4_label4);
                db.DbPsetString("@DATA_CHAR4_DESC1", _data_char4_desc1);
                db.DbPsetString("@DATA_CHAR4_DESC2", _data_char4_desc2);
                db.DbPsetString("@DATA_CHAR4_DESC3", _data_char4_desc3);
                db.DbPsetString("@DATA_CHAR4_DESC4", _data_char4_desc4);
                db.DbPsetString("@DATA_CHAR5_LABEL1", _data_char5_label1);
                db.DbPsetString("@DATA_CHAR5_LABEL2", _data_char5_label2);
                db.DbPsetString("@DATA_CHAR5_LABEL3", _data_char5_label3);
                db.DbPsetString("@DATA_CHAR5_LABEL4", _data_char5_label4);
                db.DbPsetString("@DATA_CHAR5_DESC1", _data_char5_desc1);
                db.DbPsetString("@DATA_CHAR5_DESC2", _data_char5_desc2);
                db.DbPsetString("@DATA_CHAR5_DESC3", _data_char5_desc3);
                db.DbPsetString("@DATA_CHAR5_DESC4", _data_char5_desc4);
                db.DbPsetString("@DATA_CHAR6_LABEL1", _data_char6_label1);
                db.DbPsetString("@DATA_CHAR6_LABEL2", _data_char6_label2);
                db.DbPsetString("@DATA_CHAR6_LABEL3", _data_char6_label3);
                db.DbPsetString("@DATA_CHAR6_LABEL4", _data_char6_label4);
                db.DbPsetString("@DATA_CHAR6_DESC1", _data_char6_desc1);
                db.DbPsetString("@DATA_CHAR6_DESC2", _data_char6_desc2);
                db.DbPsetString("@DATA_CHAR6_DESC3", _data_char6_desc3);
                db.DbPsetString("@DATA_CHAR6_DESC4", _data_char6_desc4);
                db.DbPsetString("@DATA_INT_LABEL1", _data_int_label1);
                db.DbPsetString("@DATA_INT_LABEL2", _data_int_label2);
                db.DbPsetString("@DATA_INT_LABEL3", _data_int_label3);
                db.DbPsetString("@DATA_INT_LABEL4", _data_int_label4);
                db.DbPsetString("@DATA_INT_DESC1", _data_int_desc1);
                db.DbPsetString("@DATA_INT_DESC2", _data_int_desc2);
                db.DbPsetString("@DATA_INT_DESC3", _data_int_desc3);
                db.DbPsetString("@DATA_INT_DESC4", _data_int_desc4);
                db.DbPsetString("@DATA_DEC_LABEL1", _data_dec_label1);
                db.DbPsetString("@DATA_DEC_LABEL2", _data_dec_label2);
                db.DbPsetString("@DATA_DEC_LABEL3", _data_dec_label3);
                db.DbPsetString("@DATA_DEC_LABEL4", _data_dec_label4);
                db.DbPsetString("@DATA_DEC_DESC1", _data_dec_desc1);
                db.DbPsetString("@DATA_DEC_DESC2", _data_dec_desc2);
                db.DbPsetString("@DATA_DEC_DESC3", _data_dec_desc3);
                db.DbPsetString("@DATA_DEC_DESC4", _data_dec_desc4);
                db.DbPsetString("@DATA_DEC2_LABEL1", _data_dec2_label1);
                db.DbPsetString("@DATA_DEC2_LABEL2", _data_dec2_label2);
                db.DbPsetString("@DATA_DEC2_LABEL3", _data_dec2_label3);
                db.DbPsetString("@DATA_DEC2_LABEL4", _data_dec2_label4);
                db.DbPsetString("@DATA_DEC2_DESC1", _data_dec2_desc1);
                db.DbPsetString("@DATA_DEC2_DESC2", _data_dec2_desc2);
                db.DbPsetString("@DATA_DEC2_DESC3", _data_dec2_desc3);
                db.DbPsetString("@DATA_DEC2_DESC4", _data_dec2_desc4);
                db.DbPsetString("@DATA_DEC3_LABEL1", _data_dec3_label1);
                db.DbPsetString("@DATA_DEC3_LABEL2", _data_dec3_label2);
                db.DbPsetString("@DATA_DEC3_LABEL3", _data_dec3_label3);
                db.DbPsetString("@DATA_DEC3_LABEL4", _data_dec3_label4);
                db.DbPsetString("@DATA_DEC3_DESC1", _data_dec3_desc1);
                db.DbPsetString("@DATA_DEC3_DESC2", _data_dec3_desc2);
                db.DbPsetString("@DATA_DEC3_DESC3", _data_dec3_desc3);
                db.DbPsetString("@DATA_DEC3_DESC4", _data_dec3_desc4);
                db.DbPsetString("@DATA_DEC4_LABEL1", _data_dec4_label1);
                db.DbPsetString("@DATA_DEC4_LABEL2", _data_dec4_label2);
                db.DbPsetString("@DATA_DEC4_LABEL3", _data_dec4_label3);
                db.DbPsetString("@DATA_DEC4_LABEL4", _data_dec4_label4);
                db.DbPsetString("@DATA_DEC4_DESC1", _data_dec4_desc1);
                db.DbPsetString("@DATA_DEC4_DESC2", _data_dec4_desc2);
                db.DbPsetString("@DATA_DEC4_DESC3", _data_dec4_desc3);
                db.DbPsetString("@DATA_DEC4_DESC4", _data_dec4_desc4);
                db.DbPsetDate("@ENTRY_DATE", _entry_date);
                db.DbPsetDate("@CHG_DATE", _chg_date);
                db.DbPsetString("@CHG_USER_ID", _chg_user_id);
                db.DbPsetInt("@UPDATE_CNTR", _update_cntr);
            }


            db.DbBeginTrans();

            rtn = db.DbExecute(strSQL.ToString());
            if (rtn != ComConst.FAILED)
            {
                db.DbCommit();
            }
            else
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                db.DbRollback();
            }

            return rtn;
        }

        /// <summary>
        /// システムパラメータヘッダーの変更
        /// 
        /// 使用画面：MstSysParaHeaderMnt
        /// </summary>
        public int UpdateHeader()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("UPDATE SYSTEM_PARAMETER_HEADER ");
                strSQL.Append("SET ");
                strSQL.Append("HEADER_DESC1 = :HEADER_DESC1,");
                strSQL.Append("HEADER_DESC2 = :HEADER_DESC2,");
                strSQL.Append("HEADER_DESC3 = :HEADER_DESC3,");
                strSQL.Append("HEADER_DESC4 = :HEADER_DESC4,");
                strSQL.Append("KEY02_LABEL1 = :KEY02_LABEL1,");
                strSQL.Append("KEY02_LABEL2 = :KEY02_LABEL2,");
                strSQL.Append("KEY02_LABEL3 = :KEY02_LABEL3,");
                strSQL.Append("KEY02_LABEL4 = :KEY02_LABEL4,");
                strSQL.Append("KEY02_DESC1 = :KEY02_DESC1,");
                strSQL.Append("KEY02_DESC2 = :KEY02_DESC2,");
                strSQL.Append("KEY02_DESC3 = :KEY02_DESC3,");
                strSQL.Append("KEY02_DESC4 = :KEY02_DESC4,");
                strSQL.Append("KEY02_DIGIT = :KEY02_DIGIT,");
                strSQL.Append("KEY03_LABEL1 = :KEY03_LABEL1,");
                strSQL.Append("KEY03_LABEL2 = :KEY03_LABEL2,");
                strSQL.Append("KEY03_LABEL3 = :KEY03_LABEL3,");
                strSQL.Append("KEY03_LABEL4 = :KEY03_LABEL4,");
                strSQL.Append("KEY03_DESC1 = :KEY03_DESC1,");
                strSQL.Append("KEY03_DESC2 = :KEY03_DESC2,");
                strSQL.Append("KEY03_DESC3 = :KEY03_DESC3,");
                strSQL.Append("KEY03_DESC4 = :KEY03_DESC4,");
                strSQL.Append("KEY03_DIGIT = :KEY03_DIGIT,");
                strSQL.Append("KEY04_LABEL1 = :KEY04_LABEL1,");
                strSQL.Append("KEY04_LABEL2 = :KEY04_LABEL2,");
                strSQL.Append("KEY04_LABEL3 = :KEY04_LABEL3,");
                strSQL.Append("KEY04_LABEL4 = :KEY04_LABEL4,");
                strSQL.Append("KEY04_DESC1 = :KEY04_DESC1,");
                strSQL.Append("KEY04_DESC2 = :KEY04_DESC2,");
                strSQL.Append("KEY04_DESC3 = :KEY04_DESC3,");
                strSQL.Append("KEY04_DESC4 = :KEY04_DESC4,");
                strSQL.Append("KEY04_DIGIT = :KEY04_DIGIT,");
                strSQL.Append("DATA_CHAR_LABEL1 = :DATA_CHAR_LABEL1,");
                strSQL.Append("DATA_CHAR_LABEL2 = :DATA_CHAR_LABEL2,");
                strSQL.Append("DATA_CHAR_LABEL3 = :DATA_CHAR_LABEL3,");
                strSQL.Append("DATA_CHAR_LABEL4 = :DATA_CHAR_LABEL4,");
                strSQL.Append("DATA_CHAR_DESC1 = :DATA_CHAR_DESC1,");
                strSQL.Append("DATA_CHAR_DESC2 = :DATA_CHAR_DESC2,");
                strSQL.Append("DATA_CHAR_DESC3 = :DATA_CHAR_DESC3,");
                strSQL.Append("DATA_CHAR_DESC4 = :DATA_CHAR_DESC4,");
                strSQL.Append("DATA_CHAR2_LABEL1 = :DATA_CHAR2_LABEL1,");
                strSQL.Append("DATA_CHAR2_LABEL2 = :DATA_CHAR2_LABEL2,");
                strSQL.Append("DATA_CHAR2_LABEL3 = :DATA_CHAR2_LABEL3,");
                strSQL.Append("DATA_CHAR2_LABEL4 = :DATA_CHAR2_LABEL4,");
                strSQL.Append("DATA_CHAR2_DESC1 = :DATA_CHAR2_DESC1,");
                strSQL.Append("DATA_CHAR2_DESC2 = :DATA_CHAR2_DESC2,");
                strSQL.Append("DATA_CHAR2_DESC3 = :DATA_CHAR2_DESC3,");
                strSQL.Append("DATA_CHAR2_DESC4 = :DATA_CHAR2_DESC4,");
                strSQL.Append("DATA_CHAR3_LABEL1 = :DATA_CHAR3_LABEL1,");
                strSQL.Append("DATA_CHAR3_LABEL2 = :DATA_CHAR3_LABEL2,");
                strSQL.Append("DATA_CHAR3_LABEL3 = :DATA_CHAR3_LABEL3,");
                strSQL.Append("DATA_CHAR3_LABEL4 = :DATA_CHAR3_LABEL4,");
                strSQL.Append("DATA_CHAR3_DESC1 = :DATA_CHAR3_DESC1,");
                strSQL.Append("DATA_CHAR3_DESC2 = :DATA_CHAR3_DESC2,");
                strSQL.Append("DATA_CHAR3_DESC3 = :DATA_CHAR3_DESC3,");
                strSQL.Append("DATA_CHAR3_DESC4 = :DATA_CHAR3_DESC4,");
                strSQL.Append("DATA_CHAR4_LABEL1 = :DATA_CHAR4_LABEL1,");
                strSQL.Append("DATA_CHAR4_LABEL2 = :DATA_CHAR4_LABEL2,");
                strSQL.Append("DATA_CHAR4_LABEL3 = :DATA_CHAR4_LABEL3,");
                strSQL.Append("DATA_CHAR4_LABEL4 = :DATA_CHAR4_LABEL4,");
                strSQL.Append("DATA_CHAR4_DESC1 = :DATA_CHAR4_DESC1,");
                strSQL.Append("DATA_CHAR4_DESC2 = :DATA_CHAR4_DESC2,");
                strSQL.Append("DATA_CHAR4_DESC3 = :DATA_CHAR4_DESC3,");
                strSQL.Append("DATA_CHAR4_DESC4 = :DATA_CHAR4_DESC4,");
                strSQL.Append("DATA_CHAR5_LABEL1 = :DATA_CHAR5_LABEL1,");
                strSQL.Append("DATA_CHAR5_LABEL2 = :DATA_CHAR5_LABEL2,");
                strSQL.Append("DATA_CHAR5_LABEL3 = :DATA_CHAR5_LABEL3,");
                strSQL.Append("DATA_CHAR5_LABEL4 = :DATA_CHAR5_LABEL4,");
                strSQL.Append("DATA_CHAR5_DESC1 = :DATA_CHAR5_DESC1,");
                strSQL.Append("DATA_CHAR5_DESC2 = :DATA_CHAR5_DESC2,");
                strSQL.Append("DATA_CHAR5_DESC3 = :DATA_CHAR5_DESC3,");
                strSQL.Append("DATA_CHAR5_DESC4 = :DATA_CHAR5_DESC4,");
                strSQL.Append("DATA_CHAR6_LABEL1 = :DATA_CHAR6_LABEL1,");
                strSQL.Append("DATA_CHAR6_LABEL2 = :DATA_CHAR6_LABEL2,");
                strSQL.Append("DATA_CHAR6_LABEL3 = :DATA_CHAR6_LABEL3,");
                strSQL.Append("DATA_CHAR6_LABEL4 = :DATA_CHAR6_LABEL4,");
                strSQL.Append("DATA_CHAR6_DESC1 = :DATA_CHAR6_DESC1,");
                strSQL.Append("DATA_CHAR6_DESC2 = :DATA_CHAR6_DESC2,");
                strSQL.Append("DATA_CHAR6_DESC3 = :DATA_CHAR6_DESC3,");
                strSQL.Append("DATA_CHAR6_DESC4 = :DATA_CHAR6_DESC4,");
                strSQL.Append("DATA_INT_LABEL1 = :DATA_INT_LABEL1,");
                strSQL.Append("DATA_INT_LABEL2 = :DATA_INT_LABEL2,");
                strSQL.Append("DATA_INT_LABEL3 = :DATA_INT_LABEL3,");
                strSQL.Append("DATA_INT_LABEL4 = :DATA_INT_LABEL4,");
                strSQL.Append("DATA_INT_DESC1 = :DATA_INT_DESC1,");
                strSQL.Append("DATA_INT_DESC2 = :DATA_INT_DESC2,");
                strSQL.Append("DATA_INT_DESC3 = :DATA_INT_DESC3,");
                strSQL.Append("DATA_INT_DESC4 = :DATA_INT_DESC4,");
                strSQL.Append("DATA_DEC_LABEL1 = :DATA_DEC_LABEL1,");
                strSQL.Append("DATA_DEC_LABEL2 = :DATA_DEC_LABEL2,");
                strSQL.Append("DATA_DEC_LABEL3 = :DATA_DEC_LABEL3,");
                strSQL.Append("DATA_DEC_LABEL4 = :DATA_DEC_LABEL4,");
                strSQL.Append("DATA_DEC_DESC1 = :DATA_DEC_DESC1,");
                strSQL.Append("DATA_DEC_DESC2 = :DATA_DEC_DESC2,");
                strSQL.Append("DATA_DEC_DESC3 = :DATA_DEC_DESC3,");
                strSQL.Append("DATA_DEC_DESC4 = :DATA_DEC_DESC4,");
                strSQL.Append("DATA_DEC2_LABEL1 = :DATA_DEC2_LABEL1,");
                strSQL.Append("DATA_DEC2_LABEL2 = :DATA_DEC2_LABEL2,");
                strSQL.Append("DATA_DEC2_LABEL3 = :DATA_DEC2_LABEL3,");
                strSQL.Append("DATA_DEC2_LABEL4 = :DATA_DEC2_LABEL4,");
                strSQL.Append("DATA_DEC2_DESC1 = :DATA_DEC2_DESC1,");
                strSQL.Append("DATA_DEC2_DESC2 = :DATA_DEC2_DESC2,");
                strSQL.Append("DATA_DEC2_DESC3 = :DATA_DEC2_DESC3,");
                strSQL.Append("DATA_DEC2_DESC4 = :DATA_DEC2_DESC4,");
                strSQL.Append("DATA_DEC3_LABEL1 = :DATA_DEC3_LABEL1,");
                strSQL.Append("DATA_DEC3_LABEL2 = :DATA_DEC3_LABEL2,");
                strSQL.Append("DATA_DEC3_LABEL3 = :DATA_DEC3_LABEL3,");
                strSQL.Append("DATA_DEC3_LABEL4 = :DATA_DEC3_LABEL4,");
                strSQL.Append("DATA_DEC3_DESC1 = :DATA_DEC3_DESC1,");
                strSQL.Append("DATA_DEC3_DESC2 = :DATA_DEC3_DESC2,");
                strSQL.Append("DATA_DEC3_DESC3 = :DATA_DEC3_DESC3,");
                strSQL.Append("DATA_DEC3_DESC4 = :DATA_DEC3_DESC4,");
                strSQL.Append("DATA_DEC4_LABEL1 = :DATA_DEC4_LABEL1,");
                strSQL.Append("DATA_DEC4_LABEL2 = :DATA_DEC4_LABEL2,");
                strSQL.Append("DATA_DEC4_LABEL3 = :DATA_DEC4_LABEL3,");
                strSQL.Append("DATA_DEC4_LABEL4 = :DATA_DEC4_LABEL4,");
                strSQL.Append("DATA_DEC4_DESC1 = :DATA_DEC4_DESC1,");
                strSQL.Append("DATA_DEC4_DESC2 = :DATA_DEC4_DESC2,");
                strSQL.Append("DATA_DEC4_DESC3 = :DATA_DEC4_DESC3,");
                strSQL.Append("DATA_DEC4_DESC4 = :DATA_DEC4_DESC4,");
                strSQL.Append("CHG_DATE = :CHG_DATE,");
                strSQL.Append("CHG_USER_ID = :CHG_USER_ID,");
                strSQL.Append("UPDATE_CNTR = UPDATE_CNTR + 1");
                strSQL.Append(" WHERE KEY01 = :KEY01");

                db.DbParametersClear();
                db.DbPsetString("HEADER_DESC1", _header_desc1);
                db.DbPsetString("HEADER_DESC2", _header_desc2);
                db.DbPsetString("HEADER_DESC3", _header_desc3);
                db.DbPsetString("HEADER_DESC4", _header_desc4);
                db.DbPsetString("KEY02_LABEL1", _key02_label1);
                db.DbPsetString("KEY02_LABEL2", _key02_label2);
                db.DbPsetString("KEY02_LABEL3", _key02_label3);
                db.DbPsetString("KEY02_LABEL4", _key02_label4);
                db.DbPsetString("KEY02_DESC1", _key02_desc1);
                db.DbPsetString("KEY02_DESC2", _key02_desc2);
                db.DbPsetString("KEY02_DESC3", _key02_desc3);
                db.DbPsetString("KEY02_DESC4", _key02_desc4);
                db.DbPsetInt("KEY02_DIGIT", _key02_digit);
                db.DbPsetString("KEY03_LABEL1", _key03_label1);
                db.DbPsetString("KEY03_LABEL2", _key03_label2);
                db.DbPsetString("KEY03_LABEL3", _key03_label3);
                db.DbPsetString("KEY03_LABEL4", _key03_label4);
                db.DbPsetString("KEY03_DESC1", _key03_desc1);
                db.DbPsetString("KEY03_DESC2", _key03_desc2);
                db.DbPsetString("KEY03_DESC3", _key03_desc3);
                db.DbPsetString("KEY03_DESC4", _key03_desc4);
                db.DbPsetInt("KEY03_DIGIT", _key03_digit);
                db.DbPsetString("KEY04_LABEL1", _key04_label1);
                db.DbPsetString("KEY04_LABEL2", _key04_label2);
                db.DbPsetString("KEY04_LABEL3", _key04_label3);
                db.DbPsetString("KEY04_LABEL4", _key04_label4);
                db.DbPsetString("KEY04_DESC1", _key04_desc1);
                db.DbPsetString("KEY04_DESC2", _key04_desc2);
                db.DbPsetString("KEY04_DESC3", _key04_desc3);
                db.DbPsetString("KEY04_DESC4", _key04_desc4);
                db.DbPsetInt("KEY04_DIGIT", _key04_digit);
                db.DbPsetString("DATA_CHAR_LABEL1", _data_char_label1);
                db.DbPsetString("DATA_CHAR_LABEL2", _data_char_label2);
                db.DbPsetString("DATA_CHAR_LABEL3", _data_char_label3);
                db.DbPsetString("DATA_CHAR_LABEL4", _data_char_label4);
                db.DbPsetString("DATA_CHAR_DESC1", _data_char_desc1);
                db.DbPsetString("DATA_CHAR_DESC2", _data_char_desc2);
                db.DbPsetString("DATA_CHAR_DESC3", _data_char_desc3);
                db.DbPsetString("DATA_CHAR_DESC4", _data_char_desc4);
                db.DbPsetString("DATA_CHAR2_LABEL1", _data_char2_label1);
                db.DbPsetString("DATA_CHAR2_LABEL2", _data_char2_label2);
                db.DbPsetString("DATA_CHAR2_LABEL3", _data_char2_label3);
                db.DbPsetString("DATA_CHAR2_LABEL4", _data_char2_label4);
                db.DbPsetString("DATA_CHAR2_DESC1", _data_char2_desc1);
                db.DbPsetString("DATA_CHAR2_DESC2", _data_char2_desc2);
                db.DbPsetString("DATA_CHAR2_DESC3", _data_char2_desc3);
                db.DbPsetString("DATA_CHAR2_DESC4", _data_char2_desc4);
                db.DbPsetString("DATA_CHAR3_LABEL1", _data_char3_label1);
                db.DbPsetString("DATA_CHAR3_LABEL2", _data_char3_label2);
                db.DbPsetString("DATA_CHAR3_LABEL3", _data_char3_label3);
                db.DbPsetString("DATA_CHAR3_LABEL4", _data_char3_label4);
                db.DbPsetString("DATA_CHAR3_DESC1", _data_char3_desc1);
                db.DbPsetString("DATA_CHAR3_DESC2", _data_char3_desc2);
                db.DbPsetString("DATA_CHAR3_DESC3", _data_char3_desc3);
                db.DbPsetString("DATA_CHAR3_DESC4", _data_char3_desc4);
                db.DbPsetString("DATA_CHAR4_LABEL1", _data_char4_label1);
                db.DbPsetString("DATA_CHAR4_LABEL2", _data_char4_label2);
                db.DbPsetString("DATA_CHAR4_LABEL3", _data_char4_label3);
                db.DbPsetString("DATA_CHAR4_LABEL4", _data_char4_label4);
                db.DbPsetString("DATA_CHAR4_DESC1", _data_char4_desc1);
                db.DbPsetString("DATA_CHAR4_DESC2", _data_char4_desc2);
                db.DbPsetString("DATA_CHAR4_DESC3", _data_char4_desc3);
                db.DbPsetString("DATA_CHAR4_DESC4", _data_char4_desc4);
                db.DbPsetString("DATA_CHAR5_LABEL1", _data_char5_label1);
                db.DbPsetString("DATA_CHAR5_LABEL2", _data_char5_label2);
                db.DbPsetString("DATA_CHAR5_LABEL3", _data_char5_label3);
                db.DbPsetString("DATA_CHAR5_LABEL4", _data_char5_label4);
                db.DbPsetString("DATA_CHAR5_DESC1", _data_char5_desc1);
                db.DbPsetString("DATA_CHAR5_DESC2", _data_char5_desc2);
                db.DbPsetString("DATA_CHAR5_DESC3", _data_char5_desc3);
                db.DbPsetString("DATA_CHAR5_DESC4", _data_char5_desc4);
                db.DbPsetString("DATA_CHAR6_LABEL1", _data_char6_label1);
                db.DbPsetString("DATA_CHAR6_LABEL2", _data_char6_label2);
                db.DbPsetString("DATA_CHAR6_LABEL3", _data_char6_label3);
                db.DbPsetString("DATA_CHAR6_LABEL4", _data_char6_label4);
                db.DbPsetString("DATA_CHAR6_DESC1", _data_char6_desc1);
                db.DbPsetString("DATA_CHAR6_DESC2", _data_char6_desc2);
                db.DbPsetString("DATA_CHAR6_DESC3", _data_char6_desc3);
                db.DbPsetString("DATA_CHAR6_DESC4", _data_char6_desc4);
                db.DbPsetString("DATA_INT_LABEL1", _data_int_label1);
                db.DbPsetString("DATA_INT_LABEL2", _data_int_label2);
                db.DbPsetString("DATA_INT_LABEL3", _data_int_label3);
                db.DbPsetString("DATA_INT_LABEL4", _data_int_label4);
                db.DbPsetString("DATA_INT_DESC1", _data_int_desc1);
                db.DbPsetString("DATA_INT_DESC2", _data_int_desc2);
                db.DbPsetString("DATA_INT_DESC3", _data_int_desc3);
                db.DbPsetString("DATA_INT_DESC4", _data_int_desc4);
                db.DbPsetString("DATA_DEC_LABEL1", _data_dec_label1);
                db.DbPsetString("DATA_DEC_LABEL2", _data_dec_label2);
                db.DbPsetString("DATA_DEC_LABEL3", _data_dec_label3);
                db.DbPsetString("DATA_DEC_LABEL4", _data_dec_label4);
                db.DbPsetString("DATA_DEC_DESC1", _data_dec_desc1);
                db.DbPsetString("DATA_DEC_DESC2", _data_dec_desc2);
                db.DbPsetString("DATA_DEC_DESC3", _data_dec_desc3);
                db.DbPsetString("DATA_DEC_DESC4", _data_dec_desc4);
                db.DbPsetString("DATA_DEC2_LABEL1", _data_dec2_label1);
                db.DbPsetString("DATA_DEC2_LABEL2", _data_dec2_label2);
                db.DbPsetString("DATA_DEC2_LABEL3", _data_dec2_label3);
                db.DbPsetString("DATA_DEC2_LABEL4", _data_dec2_label4);
                db.DbPsetString("DATA_DEC2_DESC1", _data_dec2_desc1);
                db.DbPsetString("DATA_DEC2_DESC2", _data_dec2_desc2);
                db.DbPsetString("DATA_DEC2_DESC3", _data_dec2_desc3);
                db.DbPsetString("DATA_DEC2_DESC4", _data_dec2_desc4);
                db.DbPsetString("DATA_DEC3_LABEL1", _data_dec3_label1);
                db.DbPsetString("DATA_DEC3_LABEL2", _data_dec3_label2);
                db.DbPsetString("DATA_DEC3_LABEL3", _data_dec3_label3);
                db.DbPsetString("DATA_DEC3_LABEL4", _data_dec3_label4);
                db.DbPsetString("DATA_DEC3_DESC1", _data_dec3_desc1);
                db.DbPsetString("DATA_DEC3_DESC2", _data_dec3_desc2);
                db.DbPsetString("DATA_DEC3_DESC3", _data_dec3_desc3);
                db.DbPsetString("DATA_DEC3_DESC4", _data_dec3_desc4);
                db.DbPsetString("DATA_DEC4_LABEL1", _data_dec4_label1);
                db.DbPsetString("DATA_DEC4_LABEL2", _data_dec4_label2);
                db.DbPsetString("DATA_DEC4_LABEL3", _data_dec4_label3);
                db.DbPsetString("DATA_DEC4_LABEL4", _data_dec4_label4);
                db.DbPsetString("DATA_DEC4_DESC1", _data_dec4_desc1);
                db.DbPsetString("DATA_DEC4_DESC2", _data_dec4_desc2);
                db.DbPsetString("DATA_DEC4_DESC3", _data_dec4_desc3);
                db.DbPsetString("DATA_DEC4_DESC4", _data_dec4_desc4);
                db.DbPsetDate("CHG_DATE", _chg_date);
                db.DbPsetString("CHG_USER_ID", _chg_user_id);
                db.DbPsetString("KEY01", _key01);

            }
            else
            {
                strSQL.Append("UPDATE SYSTEM_PARAMETER_HEADER ");
                strSQL.Append("SET ");
                strSQL.Append("HEADER_DESC1 = @HEADER_DESC1,");
                strSQL.Append("HEADER_DESC2 = @HEADER_DESC2,");
                strSQL.Append("HEADER_DESC3 = @HEADER_DESC3,");
                strSQL.Append("HEADER_DESC4 = @HEADER_DESC4,");
                strSQL.Append("KEY02_LABEL1 = @KEY02_LABEL1,");
                strSQL.Append("KEY02_LABEL2 = @KEY02_LABEL2,");
                strSQL.Append("KEY02_LABEL3 = @KEY02_LABEL3,");
                strSQL.Append("KEY02_LABEL4 = @KEY02_LABEL4,");
                strSQL.Append("KEY02_DESC1 = @KEY02_DESC1,");
                strSQL.Append("KEY02_DESC2 = @KEY02_DESC2,");
                strSQL.Append("KEY02_DESC3 = @KEY02_DESC3,");
                strSQL.Append("KEY02_DESC4 = @KEY02_DESC4,");
                strSQL.Append("KEY02_DIGIT = @KEY02_DIGIT,");
                strSQL.Append("KEY03_LABEL1 = @KEY03_LABEL1,");
                strSQL.Append("KEY03_LABEL2 = @KEY03_LABEL2,");
                strSQL.Append("KEY03_LABEL3 = @KEY03_LABEL3,");
                strSQL.Append("KEY03_LABEL4 = @KEY03_LABEL4,");
                strSQL.Append("KEY03_DESC1 = @KEY03_DESC1,");
                strSQL.Append("KEY03_DESC2 = @KEY03_DESC2,");
                strSQL.Append("KEY03_DESC3 = @KEY03_DESC3,");
                strSQL.Append("KEY03_DESC4 = @KEY03_DESC4,");
                strSQL.Append("KEY03_DIGIT = @KEY03_DIGIT,");
                strSQL.Append("KEY04_LABEL1 = @KEY04_LABEL1,");
                strSQL.Append("KEY04_LABEL2 = @KEY04_LABEL2,");
                strSQL.Append("KEY04_LABEL3 = @KEY04_LABEL3,");
                strSQL.Append("KEY04_LABEL4 = @KEY04_LABEL4,");
                strSQL.Append("KEY04_DESC1 = @KEY04_DESC1,");
                strSQL.Append("KEY04_DESC2 = @KEY04_DESC2,");
                strSQL.Append("KEY04_DESC3 = @KEY04_DESC3,");
                strSQL.Append("KEY04_DESC4 = @KEY04_DESC4,");
                strSQL.Append("KEY04_DIGIT = @KEY04_DIGIT,");
                strSQL.Append("DATA_CHAR_LABEL1 = @DATA_CHAR_LABEL1,");
                strSQL.Append("DATA_CHAR_LABEL2 = @DATA_CHAR_LABEL2,");
                strSQL.Append("DATA_CHAR_LABEL3 = @DATA_CHAR_LABEL3,");
                strSQL.Append("DATA_CHAR_LABEL4 = @DATA_CHAR_LABEL4,");
                strSQL.Append("DATA_CHAR_DESC1 = @DATA_CHAR_DESC1,");
                strSQL.Append("DATA_CHAR_DESC2 = @DATA_CHAR_DESC2,");
                strSQL.Append("DATA_CHAR_DESC3 = @DATA_CHAR_DESC3,");
                strSQL.Append("DATA_CHAR_DESC4 = @DATA_CHAR_DESC4,");
                strSQL.Append("DATA_CHAR2_LABEL1 = @DATA_CHAR2_LABEL1,");
                strSQL.Append("DATA_CHAR2_LABEL2 = @DATA_CHAR2_LABEL2,");
                strSQL.Append("DATA_CHAR2_LABEL3 = @DATA_CHAR2_LABEL3,");
                strSQL.Append("DATA_CHAR2_LABEL4 = @DATA_CHAR2_LABEL4,");
                strSQL.Append("DATA_CHAR2_DESC1 = @DATA_CHAR2_DESC1,");
                strSQL.Append("DATA_CHAR2_DESC2 = @DATA_CHAR2_DESC2,");
                strSQL.Append("DATA_CHAR2_DESC3 = @DATA_CHAR2_DESC3,");
                strSQL.Append("DATA_CHAR2_DESC4 = @DATA_CHAR2_DESC4,");
                strSQL.Append("DATA_CHAR3_LABEL1 = @DATA_CHAR3_LABEL1,");
                strSQL.Append("DATA_CHAR3_LABEL2 = @DATA_CHAR3_LABEL2,");
                strSQL.Append("DATA_CHAR3_LABEL3 = @DATA_CHAR3_LABEL3,");
                strSQL.Append("DATA_CHAR3_LABEL4 = @DATA_CHAR3_LABEL4,");
                strSQL.Append("DATA_CHAR3_DESC1 = @DATA_CHAR3_DESC1,");
                strSQL.Append("DATA_CHAR3_DESC2 = @DATA_CHAR3_DESC2,");
                strSQL.Append("DATA_CHAR3_DESC3 = @DATA_CHAR3_DESC3,");
                strSQL.Append("DATA_CHAR3_DESC4 = @DATA_CHAR3_DESC4,");
                strSQL.Append("DATA_CHAR4_LABEL1 = @DATA_CHAR4_LABEL1,");
                strSQL.Append("DATA_CHAR4_LABEL2 = @DATA_CHAR4_LABEL2,");
                strSQL.Append("DATA_CHAR4_LABEL3 = @DATA_CHAR4_LABEL3,");
                strSQL.Append("DATA_CHAR4_LABEL4 = @DATA_CHAR4_LABEL4,");
                strSQL.Append("DATA_CHAR4_DESC1 = @DATA_CHAR4_DESC1,");
                strSQL.Append("DATA_CHAR4_DESC2 = @DATA_CHAR4_DESC2,");
                strSQL.Append("DATA_CHAR4_DESC3 = @DATA_CHAR4_DESC3,");
                strSQL.Append("DATA_CHAR4_DESC4 = @DATA_CHAR4_DESC4,");
                strSQL.Append("DATA_CHAR5_LABEL1 = @DATA_CHAR5_LABEL1,");
                strSQL.Append("DATA_CHAR5_LABEL2 = @DATA_CHAR5_LABEL2,");
                strSQL.Append("DATA_CHAR5_LABEL3 = @DATA_CHAR5_LABEL3,");
                strSQL.Append("DATA_CHAR5_LABEL4 = @DATA_CHAR5_LABEL4,");
                strSQL.Append("DATA_CHAR5_DESC1 = @DATA_CHAR5_DESC1,");
                strSQL.Append("DATA_CHAR5_DESC2 = @DATA_CHAR5_DESC2,");
                strSQL.Append("DATA_CHAR5_DESC3 = @DATA_CHAR5_DESC3,");
                strSQL.Append("DATA_CHAR5_DESC4 = @DATA_CHAR5_DESC4,");
                strSQL.Append("DATA_CHAR6_LABEL1 = @DATA_CHAR6_LABEL1,");
                strSQL.Append("DATA_CHAR6_LABEL2 = @DATA_CHAR6_LABEL2,");
                strSQL.Append("DATA_CHAR6_LABEL3 = @DATA_CHAR6_LABEL3,");
                strSQL.Append("DATA_CHAR6_LABEL4 = @DATA_CHAR6_LABEL4,");
                strSQL.Append("DATA_CHAR6_DESC1 = @DATA_CHAR6_DESC1,");
                strSQL.Append("DATA_CHAR6_DESC2 = @DATA_CHAR6_DESC2,");
                strSQL.Append("DATA_CHAR6_DESC3 = @DATA_CHAR6_DESC3,");
                strSQL.Append("DATA_CHAR6_DESC4 = @DATA_CHAR6_DESC4,");
                strSQL.Append("DATA_INT_LABEL1 = @DATA_INT_LABEL1,");
                strSQL.Append("DATA_INT_LABEL2 = @DATA_INT_LABEL2,");
                strSQL.Append("DATA_INT_LABEL3 = @DATA_INT_LABEL3,");
                strSQL.Append("DATA_INT_LABEL4 = @DATA_INT_LABEL4,");
                strSQL.Append("DATA_INT_DESC1 = @DATA_INT_DESC1,");
                strSQL.Append("DATA_INT_DESC2 = @DATA_INT_DESC2,");
                strSQL.Append("DATA_INT_DESC3 = @DATA_INT_DESC3,");
                strSQL.Append("DATA_INT_DESC4 = @DATA_INT_DESC4,");
                strSQL.Append("DATA_DEC_LABEL1 = @DATA_DEC_LABEL1,");
                strSQL.Append("DATA_DEC_LABEL2 = @DATA_DEC_LABEL2,");
                strSQL.Append("DATA_DEC_LABEL3 = @DATA_DEC_LABEL3,");
                strSQL.Append("DATA_DEC_LABEL4 = @DATA_DEC_LABEL4,");
                strSQL.Append("DATA_DEC_DESC1 = @DATA_DEC_DESC1,");
                strSQL.Append("DATA_DEC_DESC2 = @DATA_DEC_DESC2,");
                strSQL.Append("DATA_DEC_DESC3 = @DATA_DEC_DESC3,");
                strSQL.Append("DATA_DEC_DESC4 = @DATA_DEC_DESC4,");
                strSQL.Append("DATA_DEC2_LABEL1 = @DATA_DEC2_LABEL1,");
                strSQL.Append("DATA_DEC2_LABEL2 = @DATA_DEC2_LABEL2,");
                strSQL.Append("DATA_DEC2_LABEL3 = @DATA_DEC2_LABEL3,");
                strSQL.Append("DATA_DEC2_LABEL4 = @DATA_DEC2_LABEL4,");
                strSQL.Append("DATA_DEC2_DESC1 = @DATA_DEC2_DESC1,");
                strSQL.Append("DATA_DEC2_DESC2 = @DATA_DEC2_DESC2,");
                strSQL.Append("DATA_DEC2_DESC3 = @DATA_DEC2_DESC3,");
                strSQL.Append("DATA_DEC2_DESC4 = @DATA_DEC2_DESC4,");
                strSQL.Append("DATA_DEC3_LABEL1 = @DATA_DEC3_LABEL1,");
                strSQL.Append("DATA_DEC3_LABEL2 = @DATA_DEC3_LABEL2,");
                strSQL.Append("DATA_DEC3_LABEL3 = @DATA_DEC3_LABEL3,");
                strSQL.Append("DATA_DEC3_LABEL4 = @DATA_DEC3_LABEL4,");
                strSQL.Append("DATA_DEC3_DESC1 = @DATA_DEC3_DESC1,");
                strSQL.Append("DATA_DEC3_DESC2 = @DATA_DEC3_DESC2,");
                strSQL.Append("DATA_DEC3_DESC3 = @DATA_DEC3_DESC3,");
                strSQL.Append("DATA_DEC3_DESC4 = @DATA_DEC3_DESC4,");
                strSQL.Append("DATA_DEC4_LABEL1 = @DATA_DEC4_LABEL1,");
                strSQL.Append("DATA_DEC4_LABEL2 = @DATA_DEC4_LABEL2,");
                strSQL.Append("DATA_DEC4_LABEL3 = @DATA_DEC4_LABEL3,");
                strSQL.Append("DATA_DEC4_LABEL4 = @DATA_DEC4_LABEL4,");
                strSQL.Append("DATA_DEC4_DESC1 = @DATA_DEC4_DESC1,");
                strSQL.Append("DATA_DEC4_DESC2 = @DATA_DEC4_DESC2,");
                strSQL.Append("DATA_DEC4_DESC3 = @DATA_DEC4_DESC3,");
                strSQL.Append("DATA_DEC4_DESC4 = @DATA_DEC4_DESC4,");
                strSQL.Append("CHG_DATE = @CHG_DATE,");
                strSQL.Append("CHG_USER_ID = @CHG_USER_ID,");
                strSQL.Append("UPDATE_CNTR = UPDATE_CNTR + 1");
                strSQL.Append(" WHERE KEY01 = @KEY01");

                db.DbParametersClear();
                db.DbPsetString("@HEADER_DESC1", _header_desc1);
                db.DbPsetString("@HEADER_DESC2", _header_desc2);
                db.DbPsetString("@HEADER_DESC3", _header_desc3);
                db.DbPsetString("@HEADER_DESC4", _header_desc4);
                db.DbPsetString("@KEY02_LABEL1", _key02_label1);
                db.DbPsetString("@KEY02_LABEL2", _key02_label2);
                db.DbPsetString("@KEY02_LABEL3", _key02_label3);
                db.DbPsetString("@KEY02_LABEL4", _key02_label4);
                db.DbPsetString("@KEY02_DESC1", _key02_desc1);
                db.DbPsetString("@KEY02_DESC2", _key02_desc2);
                db.DbPsetString("@KEY02_DESC3", _key02_desc3);
                db.DbPsetString("@KEY02_DESC4", _key02_desc4);
                db.DbPsetInt("@KEY02_DIGIT", _key02_digit);
                db.DbPsetString("@KEY03_LABEL1", _key03_label1);
                db.DbPsetString("@KEY03_LABEL2", _key03_label2);
                db.DbPsetString("@KEY03_LABEL3", _key03_label3);
                db.DbPsetString("@KEY03_LABEL4", _key03_label4);
                db.DbPsetString("@KEY03_DESC1", _key03_desc1);
                db.DbPsetString("@KEY03_DESC2", _key03_desc2);
                db.DbPsetString("@KEY03_DESC3", _key03_desc3);
                db.DbPsetString("@KEY03_DESC4", _key03_desc4);
                db.DbPsetInt("@KEY03_DIGIT", _key03_digit);
                db.DbPsetString("@KEY04_LABEL1", _key04_label1);
                db.DbPsetString("@KEY04_LABEL2", _key04_label2);
                db.DbPsetString("@KEY04_LABEL3", _key04_label3);
                db.DbPsetString("@KEY04_LABEL4", _key04_label4);
                db.DbPsetString("@KEY04_DESC1", _key04_desc1);
                db.DbPsetString("@KEY04_DESC2", _key04_desc2);
                db.DbPsetString("@KEY04_DESC3", _key04_desc3);
                db.DbPsetString("@KEY04_DESC4", _key04_desc4);
                db.DbPsetInt("@KEY04_DIGIT", _key04_digit);
                db.DbPsetString("@DATA_CHAR_LABEL1", _data_char_label1);
                db.DbPsetString("@DATA_CHAR_LABEL2", _data_char_label2);
                db.DbPsetString("@DATA_CHAR_LABEL3", _data_char_label3);
                db.DbPsetString("@DATA_CHAR_LABEL4", _data_char_label4);
                db.DbPsetString("@DATA_CHAR_DESC1", _data_char_desc1);
                db.DbPsetString("@DATA_CHAR_DESC2", _data_char_desc2);
                db.DbPsetString("@DATA_CHAR_DESC3", _data_char_desc3);
                db.DbPsetString("@DATA_CHAR_DESC4", _data_char_desc4);
                db.DbPsetString("@DATA_CHAR2_LABEL1", _data_char2_label1);
                db.DbPsetString("@DATA_CHAR2_LABEL2", _data_char2_label2);
                db.DbPsetString("@DATA_CHAR2_LABEL3", _data_char2_label3);
                db.DbPsetString("@DATA_CHAR2_LABEL4", _data_char2_label4);
                db.DbPsetString("@DATA_CHAR2_DESC1", _data_char2_desc1);
                db.DbPsetString("@DATA_CHAR2_DESC2", _data_char2_desc2);
                db.DbPsetString("@DATA_CHAR2_DESC3", _data_char2_desc3);
                db.DbPsetString("@DATA_CHAR2_DESC4", _data_char2_desc4);
                db.DbPsetString("@DATA_CHAR3_LABEL1", _data_char3_label1);
                db.DbPsetString("@DATA_CHAR3_LABEL2", _data_char3_label2);
                db.DbPsetString("@DATA_CHAR3_LABEL3", _data_char3_label3);
                db.DbPsetString("@DATA_CHAR3_LABEL4", _data_char3_label4);
                db.DbPsetString("@DATA_CHAR3_DESC1", _data_char3_desc1);
                db.DbPsetString("@DATA_CHAR3_DESC2", _data_char3_desc2);
                db.DbPsetString("@DATA_CHAR3_DESC3", _data_char3_desc3);
                db.DbPsetString("@DATA_CHAR3_DESC4", _data_char3_desc4);
                db.DbPsetString("@DATA_CHAR4_LABEL1", _data_char4_label1);
                db.DbPsetString("@DATA_CHAR4_LABEL2", _data_char4_label2);
                db.DbPsetString("@DATA_CHAR4_LABEL3", _data_char4_label3);
                db.DbPsetString("@DATA_CHAR4_LABEL4", _data_char4_label4);
                db.DbPsetString("@DATA_CHAR4_DESC1", _data_char4_desc1);
                db.DbPsetString("@DATA_CHAR4_DESC2", _data_char4_desc2);
                db.DbPsetString("@DATA_CHAR4_DESC3", _data_char4_desc3);
                db.DbPsetString("@DATA_CHAR4_DESC4", _data_char4_desc4);
                db.DbPsetString("@DATA_CHAR5_LABEL1", _data_char5_label1);
                db.DbPsetString("@DATA_CHAR5_LABEL2", _data_char5_label2);
                db.DbPsetString("@DATA_CHAR5_LABEL3", _data_char5_label3);
                db.DbPsetString("@DATA_CHAR5_LABEL4", _data_char5_label4);
                db.DbPsetString("@DATA_CHAR5_DESC1", _data_char5_desc1);
                db.DbPsetString("@DATA_CHAR5_DESC2", _data_char5_desc2);
                db.DbPsetString("@DATA_CHAR5_DESC3", _data_char5_desc3);
                db.DbPsetString("@DATA_CHAR5_DESC4", _data_char5_desc4);
                db.DbPsetString("@DATA_CHAR6_LABEL1", _data_char6_label1);
                db.DbPsetString("@DATA_CHAR6_LABEL2", _data_char6_label2);
                db.DbPsetString("@DATA_CHAR6_LABEL3", _data_char6_label3);
                db.DbPsetString("@DATA_CHAR6_LABEL4", _data_char6_label4);
                db.DbPsetString("@DATA_CHAR6_DESC1", _data_char6_desc1);
                db.DbPsetString("@DATA_CHAR6_DESC2", _data_char6_desc2);
                db.DbPsetString("@DATA_CHAR6_DESC3", _data_char6_desc3);
                db.DbPsetString("@DATA_CHAR6_DESC4", _data_char6_desc4);
                db.DbPsetString("@DATA_INT_LABEL1", _data_int_label1);
                db.DbPsetString("@DATA_INT_LABEL2", _data_int_label2);
                db.DbPsetString("@DATA_INT_LABEL3", _data_int_label3);
                db.DbPsetString("@DATA_INT_LABEL4", _data_int_label4);
                db.DbPsetString("@DATA_INT_DESC1", _data_int_desc1);
                db.DbPsetString("@DATA_INT_DESC2", _data_int_desc2);
                db.DbPsetString("@DATA_INT_DESC3", _data_int_desc3);
                db.DbPsetString("@DATA_INT_DESC4", _data_int_desc4);
                db.DbPsetString("@DATA_DEC_LABEL1", _data_dec_label1);
                db.DbPsetString("@DATA_DEC_LABEL2", _data_dec_label2);
                db.DbPsetString("@DATA_DEC_LABEL3", _data_dec_label3);
                db.DbPsetString("@DATA_DEC_LABEL4", _data_dec_label4);
                db.DbPsetString("@DATA_DEC_DESC1", _data_dec_desc1);
                db.DbPsetString("@DATA_DEC_DESC2", _data_dec_desc2);
                db.DbPsetString("@DATA_DEC_DESC3", _data_dec_desc3);
                db.DbPsetString("@DATA_DEC_DESC4", _data_dec_desc4);
                db.DbPsetString("@DATA_DEC2_LABEL1", _data_dec2_label1);
                db.DbPsetString("@DATA_DEC2_LABEL2", _data_dec2_label2);
                db.DbPsetString("@DATA_DEC2_LABEL3", _data_dec2_label3);
                db.DbPsetString("@DATA_DEC2_LABEL4", _data_dec2_label4);
                db.DbPsetString("@DATA_DEC2_DESC1", _data_dec2_desc1);
                db.DbPsetString("@DATA_DEC2_DESC2", _data_dec2_desc2);
                db.DbPsetString("@DATA_DEC2_DESC3", _data_dec2_desc3);
                db.DbPsetString("@DATA_DEC2_DESC4", _data_dec2_desc4);
                db.DbPsetString("@DATA_DEC3_LABEL1", _data_dec3_label1);
                db.DbPsetString("@DATA_DEC3_LABEL2", _data_dec3_label2);
                db.DbPsetString("@DATA_DEC3_LABEL3", _data_dec3_label3);
                db.DbPsetString("@DATA_DEC3_LABEL4", _data_dec3_label4);
                db.DbPsetString("@DATA_DEC3_DESC1", _data_dec3_desc1);
                db.DbPsetString("@DATA_DEC3_DESC2", _data_dec3_desc2);
                db.DbPsetString("@DATA_DEC3_DESC3", _data_dec3_desc3);
                db.DbPsetString("@DATA_DEC3_DESC4", _data_dec3_desc4);
                db.DbPsetString("@DATA_DEC4_LABEL1", _data_dec4_label1);
                db.DbPsetString("@DATA_DEC4_LABEL2", _data_dec4_label2);
                db.DbPsetString("@DATA_DEC4_LABEL3", _data_dec4_label3);
                db.DbPsetString("@DATA_DEC4_LABEL4", _data_dec4_label4);
                db.DbPsetString("@DATA_DEC4_DESC1", _data_dec4_desc1);
                db.DbPsetString("@DATA_DEC4_DESC2", _data_dec4_desc2);
                db.DbPsetString("@DATA_DEC4_DESC3", _data_dec4_desc3);
                db.DbPsetString("@DATA_DEC4_DESC4", _data_dec4_desc4);
                db.DbPsetDate("@ENTRY_DATE", _entry_date);
                db.DbPsetDate("@CHG_DATE", _chg_date);
                db.DbPsetString("@CHG_USER_ID", _chg_user_id);
                db.DbPsetInt("@UPDATE_CNTR", _update_cntr);
                db.DbPsetString("@KEY01", _key01);
            }

            db.DbBeginTrans();

            rtn = db.DbExecute(strSQL.ToString());
            if (rtn != ComConst.FAILED)
            {
                db.DbCommit();
            }
            else
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                db.DbRollback();
            }

            return rtn;
        }

        /// <summary>
        /// システムパラメータヘッダーの削除
        /// 
        /// 使用画面：MstSysParaHeaderMnt
        /// </summary>
        public int DeleteHeader()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("DELETE FROM SYSTEM_PARAMETER_HEADER ");
                strSQL.Append(" WHERE KEY01 = :KEY01");
                db.DbParametersClear();

                db.DbPsetString("KEY01", _key01);
            }
            else
            {
                strSQL.Append("DELETE FROM SYSTEM_PARAMETER_HEADER ");
                strSQL.Append(" WHERE KEY01 = @KEY01");
                db.DbParametersClear();

                db.DbPsetString("@KEY01", _key01);
            }


            db.DbBeginTrans();

            rtn = db.DbExecute(strSQL.ToString());
            if (rtn != ComConst.FAILED)
            {
                db.DbCommit();
            }
            else
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                db.DbRollback();
            }

            return rtn;
        }

        /// <summary>
        /// システムパラメータヘッダー詳細の取得
        /// 指定したKEY01の内容を取得する
        /// 
        /// 使用画面：MstSysParaMnt, MstSysParaHeaderMnt
        /// </summary>
        public int GetHeader()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            strSQL.Append("SELECT HEADER_DESC1, HEADER_DESC2, HEADER_DESC3, HEADER_DESC4,");
            strSQL.Append("KEY02_LABEL1, KEY02_LABEL2, KEY02_LABEL3, KEY02_LABEL4,");
            strSQL.Append("KEY02_DESC1, KEY02_DESC2, KEY02_DESC3, KEY02_DESC4, KEY02_DIGIT,");
            strSQL.Append("KEY03_LABEL1, KEY03_LABEL2, KEY03_LABEL3, KEY03_LABEL4,");
            strSQL.Append("KEY03_DESC1, KEY03_DESC2, KEY03_DESC3, KEY03_DESC4, KEY03_DIGIT,");
            strSQL.Append("KEY04_LABEL1, KEY04_LABEL2, KEY04_LABEL3, KEY04_LABEL4,");
            strSQL.Append("KEY04_DESC1, KEY04_DESC2, KEY04_DESC3, KEY04_DESC4, KEY04_DIGIT,");
            strSQL.Append("DATA_CHAR_LABEL1, DATA_CHAR_LABEL2, DATA_CHAR_LABEL3, DATA_CHAR_LABEL4,");
            strSQL.Append("DATA_CHAR_DESC1, DATA_CHAR_DESC2, DATA_CHAR_DESC3, DATA_CHAR_DESC4,");
            strSQL.Append("DATA_CHAR2_LABEL1, DATA_CHAR2_LABEL2, DATA_CHAR2_LABEL3, DATA_CHAR2_LABEL4,");
            strSQL.Append("DATA_CHAR2_DESC1, DATA_CHAR2_DESC2, DATA_CHAR2_DESC3, DATA_CHAR2_DESC4,");
            strSQL.Append("DATA_CHAR3_LABEL1, DATA_CHAR3_LABEL2, DATA_CHAR3_LABEL3, DATA_CHAR3_LABEL4,");
            strSQL.Append("DATA_CHAR3_DESC1, DATA_CHAR3_DESC2, DATA_CHAR3_DESC3, DATA_CHAR3_DESC4,");
            strSQL.Append("DATA_CHAR4_LABEL1, DATA_CHAR4_LABEL2, DATA_CHAR4_LABEL3, DATA_CHAR4_LABEL4,");
            strSQL.Append("DATA_CHAR4_DESC1, DATA_CHAR4_DESC2, DATA_CHAR4_DESC3, DATA_CHAR4_DESC4,");
            strSQL.Append("DATA_CHAR5_LABEL1, DATA_CHAR5_LABEL2, DATA_CHAR5_LABEL3, DATA_CHAR5_LABEL4,");
            strSQL.Append("DATA_CHAR5_DESC1, DATA_CHAR5_DESC2, DATA_CHAR5_DESC3, DATA_CHAR5_DESC4,");
            strSQL.Append("DATA_CHAR6_LABEL1, DATA_CHAR6_LABEL2, DATA_CHAR6_LABEL3, DATA_CHAR6_LABEL4,");
            strSQL.Append("DATA_CHAR6_DESC1, DATA_CHAR6_DESC2, DATA_CHAR6_DESC3, DATA_CHAR6_DESC4,");
            strSQL.Append("DATA_INT_LABEL1, DATA_INT_LABEL2, DATA_INT_LABEL3, DATA_INT_LABEL4,");
            strSQL.Append("DATA_INT_DESC1, DATA_INT_DESC2, DATA_INT_DESC3, DATA_INT_DESC4,");
            strSQL.Append("DATA_DEC_LABEL1, DATA_DEC_LABEL2, DATA_DEC_LABEL3, DATA_DEC_LABEL4,");
            strSQL.Append("DATA_DEC_DESC1, DATA_DEC_DESC2, DATA_DEC_DESC3, DATA_DEC_DESC4,");
            strSQL.Append("DATA_DEC2_LABEL1, DATA_DEC2_LABEL2, DATA_DEC2_LABEL3, DATA_DEC2_LABEL4,");
            strSQL.Append("DATA_DEC2_DESC1, DATA_DEC2_DESC2, DATA_DEC2_DESC3, DATA_DEC2_DESC4,");
            strSQL.Append("DATA_DEC3_LABEL1, DATA_DEC3_LABEL2, DATA_DEC3_LABEL3, DATA_DEC3_LABEL4,");
            strSQL.Append("DATA_DEC3_DESC1, DATA_DEC3_DESC2, DATA_DEC3_DESC3, DATA_DEC3_DESC4,");
            strSQL.Append("DATA_DEC4_LABEL1, DATA_DEC4_LABEL2, DATA_DEC4_LABEL3, DATA_DEC4_LABEL4,");
            strSQL.Append("DATA_DEC4_DESC1, DATA_DEC4_DESC2, DATA_DEC4_DESC3, DATA_DEC4_DESC4,");

            switch (_lang)
            {
                case 2:
                    strSQL.Append("HEADER_DESC2 AS HEADER_DESC,");
                    strSQL.Append("KEY02_LABEL2 AS KEY02_LABEL,");
                    strSQL.Append("KEY02_DESC2 AS KEY02_DESC,");
                    strSQL.Append("KEY03_LABEL2 AS KEY03_LABEL,");
                    strSQL.Append("KEY03_DESC2 AS KEY03_DESC,");
                    strSQL.Append("KEY04_LABEL2 AS KEY04_LABEL,");
                    strSQL.Append("KEY04_DESC2 AS KEY04_DESC,");
                    strSQL.Append("DATA_CHAR_LABEL2 AS DATA_CHAR_LABEL,");
                    strSQL.Append("DATA_CHAR_DESC2 AS DATA_CHAR_DESC,");
                    strSQL.Append("DATA_CHAR2_LABEL2 AS DATA_CHAR2_LABEL,");
                    strSQL.Append("DATA_CHAR2_DESC2 AS DATA_CHAR2_DESC,");
                    strSQL.Append("DATA_CHAR3_LABEL2 AS DATA_CHAR3_LABEL,");
                    strSQL.Append("DATA_CHAR3_DESC2 AS DATA_CHAR3_DESC,");
                    strSQL.Append("DATA_CHAR4_LABEL2 AS DATA_CHAR4_LABEL,");
                    strSQL.Append("DATA_CHAR4_DESC2 AS DATA_CHAR4_DESC,");
                    strSQL.Append("DATA_CHAR5_LABEL2 AS DATA_CHAR5_LABEL,");
                    strSQL.Append("DATA_CHAR5_DESC2 AS DATA_CHAR5_DESC,");
                    strSQL.Append("DATA_CHAR6_LABEL2 AS DATA_CHAR6_LABEL,");
                    strSQL.Append("DATA_CHAR6_DESC2 AS DATA_CHAR6_DESC,");
                    strSQL.Append("DATA_INT_LABEL2 AS DATA_INT_LABEL,");
                    strSQL.Append("DATA_INT_DESC2 AS DATA_INT_DESC,");
                    strSQL.Append("DATA_DEC_LABEL2 AS DATA_DEC_LABEL,");
                    strSQL.Append("DATA_DEC_DESC2 AS DATA_DEC_DESC,");
                    strSQL.Append("DATA_DEC2_LABEL2 AS DATA_DEC2_LABEL,");
                    strSQL.Append("DATA_DEC2_DESC2 AS DATA_DEC2_DESC,");
                    strSQL.Append("DATA_DEC3_LABEL2 AS DATA_DEC3_LABEL,");
                    strSQL.Append("DATA_DEC3_DESC2 AS DATA_DEC3_DESC,");
                    strSQL.Append("DATA_DEC4_LABEL2 AS DATA_DEC4_LABEL,");
                    strSQL.Append("DATA_DEC4_DESC2 AS DATA_DEC4_DESC,");
                    break;

                case 3:
                    strSQL.Append("HEADER_DESC3 AS HEADER_DESC,");
                    strSQL.Append("KEY02_LABEL3 AS KEY02_LABEL,");
                    strSQL.Append("KEY02_DESC3 AS KEY02_DESC,");
                    strSQL.Append("KEY03_LABEL3 AS KEY03_LABEL,");
                    strSQL.Append("KEY03_DESC3 AS KEY03_DESC,");
                    strSQL.Append("KEY04_LABEL3 AS KEY04_LABEL,");
                    strSQL.Append("KEY04_DESC3 AS KEY04_DESC,");
                    strSQL.Append("DATA_CHAR_LABEL3 AS DATA_CHAR_LABEL,");
                    strSQL.Append("DATA_CHAR_DESC3 AS DATA_CHAR_DESC,");
                    strSQL.Append("DATA_CHAR2_LABEL3 AS DATA_CHAR2_LABEL,");
                    strSQL.Append("DATA_CHAR2_DESC3 AS DATA_CHAR2_DESC,");
                    strSQL.Append("DATA_CHAR3_LABEL3 AS DATA_CHAR3_LABEL,");
                    strSQL.Append("DATA_CHAR3_DESC3 AS DATA_CHAR3_DESC,");
                    strSQL.Append("DATA_CHAR4_LABEL3 AS DATA_CHAR4_LABEL,");
                    strSQL.Append("DATA_CHAR4_DESC3 AS DATA_CHAR4_DESC,");
                    strSQL.Append("DATA_CHAR5_LABEL3 AS DATA_CHAR5_LABEL,");
                    strSQL.Append("DATA_CHAR5_DESC3 AS DATA_CHAR5_DESC,");
                    strSQL.Append("DATA_CHAR6_LABEL3 AS DATA_CHAR6_LABEL,");
                    strSQL.Append("DATA_CHAR6_DESC3 AS DATA_CHAR6_DESC,");
                    strSQL.Append("DATA_INT_LABEL3 AS DATA_INT_LABEL,");
                    strSQL.Append("DATA_INT_DESC3 AS DATA_INT_DESC,");
                    strSQL.Append("DATA_DEC_LABEL3 AS DATA_DEC_LABEL,");
                    strSQL.Append("DATA_DEC_DESC3 AS DATA_DEC_DESC,");
                    strSQL.Append("DATA_DEC2_LABEL3 AS DATA_DEC2_LABEL,");
                    strSQL.Append("DATA_DEC2_DESC3 AS DATA_DEC2_DESC,");
                    strSQL.Append("DATA_DEC3_LABEL3 AS DATA_DEC3_LABEL,");
                    strSQL.Append("DATA_DEC3_DESC3 AS DATA_DEC3_DESC,");
                    strSQL.Append("DATA_DEC4_LABEL3 AS DATA_DEC4_LABEL,");
                    strSQL.Append("DATA_DEC4_DESC3 AS DATA_DEC4_DESC,");
                    break;

                case 4:
                    strSQL.Append("HEADER_DESC4 AS HEADER_DESC,");
                    strSQL.Append("KEY02_LABEL4 AS KEY02_LABEL,");
                    strSQL.Append("KEY02_DESC4 AS KEY02_DESC,");
                    strSQL.Append("KEY03_LABEL4 AS KEY03_LABEL,");
                    strSQL.Append("KEY03_DESC4 AS KEY03_DESC,");
                    strSQL.Append("KEY04_LABEL4 AS KEY04_LABEL,");
                    strSQL.Append("KEY04_DESC4 AS KEY04_DESC,");
                    strSQL.Append("DATA_CHAR_LABEL4 AS DATA_CHAR_LABEL,");
                    strSQL.Append("DATA_CHAR_DESC4 AS DATA_CHAR_DESC,");
                    strSQL.Append("DATA_CHAR2_LABEL4 AS DATA_CHAR2_LABEL,");
                    strSQL.Append("DATA_CHAR2_DESC4 AS DATA_CHAR2_DESC,");
                    strSQL.Append("DATA_CHAR3_LABEL4 AS DATA_CHAR3_LABEL,");
                    strSQL.Append("DATA_CHAR3_DESC4 AS DATA_CHAR3_DESC,");
                    strSQL.Append("DATA_CHAR4_LABEL4 AS DATA_CHAR4_LABEL,");
                    strSQL.Append("DATA_CHAR4_DESC4 AS DATA_CHAR4_DESC,");
                    strSQL.Append("DATA_CHAR5_LABEL4 AS DATA_CHAR5_LABEL,");
                    strSQL.Append("DATA_CHAR5_DESC4 AS DATA_CHAR5_DESC,");
                    strSQL.Append("DATA_CHAR6_LABEL4 AS DATA_CHAR6_LABEL,");
                    strSQL.Append("DATA_CHAR6_DESC4 AS DATA_CHAR6_DESC,");
                    strSQL.Append("DATA_INT_LABEL4 AS DATA_INT_LABEL,");
                    strSQL.Append("DATA_INT_DESC4 AS DATA_INT_DESC,");
                    strSQL.Append("DATA_DEC_LABEL4 AS DATA_DEC_LABEL,");
                    strSQL.Append("DATA_DEC_DESC4 AS DATA_DEC_DESC,");
                    strSQL.Append("DATA_DEC2_LABEL4 AS DATA_DEC2_LABEL,");
                    strSQL.Append("DATA_DEC2_DESC4 AS DATA_DEC2_DESC,");
                    strSQL.Append("DATA_DEC3_LABEL4 AS DATA_DEC3_LABEL,");
                    strSQL.Append("DATA_DEC3_DESC4 AS DATA_DEC3_DESC,");
                    strSQL.Append("DATA_DEC4_LABEL4 AS DATA_DEC4_LABEL,");
                    strSQL.Append("DATA_DEC4_DESC4 AS DATA_DEC4_DESC,");
                    break;

                default:
                    strSQL.Append("HEADER_DESC1 AS HEADER_DESC,");
                    strSQL.Append("KEY02_LABEL1 AS KEY02_LABEL,");
                    strSQL.Append("KEY02_DESC1 AS KEY02_DESC,");
                    strSQL.Append("KEY03_LABEL1 AS KEY03_LABEL,");
                    strSQL.Append("KEY03_DESC1 AS KEY03_DESC,");
                    strSQL.Append("KEY04_LABEL1 AS KEY04_LABEL,");
                    strSQL.Append("KEY04_DESC1 AS KEY04_DESC,");
                    strSQL.Append("DATA_CHAR_LABEL1 AS DATA_CHAR_LABEL,");
                    strSQL.Append("DATA_CHAR_DESC1 AS DATA_CHAR_DESC,");
                    strSQL.Append("DATA_CHAR2_LABEL1 AS DATA_CHAR2_LABEL,");
                    strSQL.Append("DATA_CHAR2_DESC1 AS DATA_CHAR2_DESC,");
                    strSQL.Append("DATA_CHAR3_LABEL1 AS DATA_CHAR3_LABEL,");
                    strSQL.Append("DATA_CHAR3_DESC1 AS DATA_CHAR3_DESC,");
                    strSQL.Append("DATA_CHAR4_LABEL1 AS DATA_CHAR4_LABEL,");
                    strSQL.Append("DATA_CHAR4_DESC1 AS DATA_CHAR4_DESC,");
                    strSQL.Append("DATA_CHAR5_LABEL1 AS DATA_CHAR5_LABEL,");
                    strSQL.Append("DATA_CHAR5_DESC1 AS DATA_CHAR5_DESC,");
                    strSQL.Append("DATA_CHAR6_LABEL1 AS DATA_CHAR6_LABEL,");
                    strSQL.Append("DATA_CHAR6_DESC1 AS DATA_CHAR6_DESC,");
                    strSQL.Append("DATA_INT_LABEL1 AS DATA_INT_LABEL,");
                    strSQL.Append("DATA_INT_DESC1 AS DATA_INT_DESC,");
                    strSQL.Append("DATA_DEC_LABEL1 AS DATA_DEC_LABEL,");
                    strSQL.Append("DATA_DEC_DESC1 AS DATA_DEC_DESC,");
                    strSQL.Append("DATA_DEC2_LABEL1 AS DATA_DEC2_LABEL,");
                    strSQL.Append("DATA_DEC2_DESC1 AS DATA_DEC2_DESC,");
                    strSQL.Append("DATA_DEC3_LABEL1 AS DATA_DEC3_LABEL,");
                    strSQL.Append("DATA_DEC3_DESC1 AS DATA_DEC3_DESC,");
                    strSQL.Append("DATA_DEC4_LABEL1 AS DATA_DEC4_LABEL,");
                    strSQL.Append("DATA_DEC4_DESC1 AS DATA_DEC4_DESC,");
                    break;
            }

            strSQL.Append("ENTRY_DATE, CHG_DATE, CHG_USER_ID, UPDATE_CNTR");
            strSQL.Append(" FROM SYSTEM_PARAMETER_HEADER ");

            if (_db_type == "ORACLE")
            {
                strSQL.Append(" WHERE KEY01 = :KEY01");
                db.DbParametersClear();

                db.DbPsetString("KEY01", _key01);
            }
            else
            {
                strSQL.Append(" WHERE KEY01 = @KEY01");
                db.DbParametersClear();

                db.DbPsetString("@KEY01", _key01);
            }


            rtn = db.DbExecuteReader(strSQL.ToString());
            if (rtn == ComConst.FAILED)
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
            }
            else
            {
                _header_desc1 = db.Row("HEADER_DESC1");
                _header_desc2 = db.Row("HEADER_DESC2");
                _header_desc3 = db.Row("HEADER_DESC3");
                _header_desc4 = db.Row("HEADER_DESC4");
                _key02_label1 = db.Row("KEY02_LABEL1");
                _key02_label2 = db.Row("KEY02_LABEL2");
                _key02_label3 = db.Row("KEY02_LABEL3");
                _key02_label4 = db.Row("KEY02_LABEL4");
                _key02_desc1 = db.Row("KEY02_DESC1");
                _key02_desc2 = db.Row("KEY02_DESC2");
                _key02_desc3 = db.Row("KEY02_DESC3");
                _key02_desc4 = db.Row("KEY02_DESC4");
                _key02_digit = int.Parse(db.Row("KEY02_DIGIT"));
                _key03_label1 = db.Row("KEY03_LABEL1");
                _key03_label2 = db.Row("KEY03_LABEL2");
                _key03_label3 = db.Row("KEY03_LABEL3");
                _key03_label4 = db.Row("KEY03_LABEL4");
                _key03_desc1 = db.Row("KEY03_DESC1");
                _key03_desc2 = db.Row("KEY03_DESC2");
                _key03_desc3 = db.Row("KEY03_DESC3");
                _key03_desc4 = db.Row("KEY03_DESC4");
                _key03_digit = int.Parse(db.Row("KEY03_DIGIT"));
                _key04_label1 = db.Row("KEY04_LABEL1");
                _key04_label2 = db.Row("KEY04_LABEL2");
                _key04_label3 = db.Row("KEY04_LABEL3");
                _key04_label4 = db.Row("KEY04_LABEL4");
                _key04_desc1 = db.Row("KEY04_DESC1");
                _key04_desc2 = db.Row("KEY04_DESC2");
                _key04_desc3 = db.Row("KEY04_DESC3");
                _key04_desc4 = db.Row("KEY04_DESC4");
                _key04_digit = int.Parse(db.Row("KEY04_DIGIT"));
                _data_char_label1 = db.Row("DATA_CHAR_LABEL1");
                _data_char_label2 = db.Row("DATA_CHAR_LABEL2");
                _data_char_label3 = db.Row("DATA_CHAR_LABEL3");
                _data_char_label4 = db.Row("DATA_CHAR_LABEL4");
                _data_char_desc1 = db.Row("DATA_CHAR_DESC1");
                _data_char_desc2 = db.Row("DATA_CHAR_DESC2");
                _data_char_desc3 = db.Row("DATA_CHAR_DESC3");
                _data_char_desc4 = db.Row("DATA_CHAR_DESC4");
                _data_char2_label1 = db.Row("DATA_CHAR2_LABEL1");
                _data_char2_label2 = db.Row("DATA_CHAR2_LABEL2");
                _data_char2_label3 = db.Row("DATA_CHAR2_LABEL3");
                _data_char2_label4 = db.Row("DATA_CHAR2_LABEL4");
                _data_char2_desc1 = db.Row("DATA_CHAR2_DESC1");
                _data_char2_desc2 = db.Row("DATA_CHAR2_DESC2");
                _data_char2_desc3 = db.Row("DATA_CHAR2_DESC3");
                _data_char2_desc4 = db.Row("DATA_CHAR2_DESC4");
                _data_char3_label1 = db.Row("DATA_CHAR3_LABEL1");
                _data_char3_label2 = db.Row("DATA_CHAR3_LABEL2");
                _data_char3_label3 = db.Row("DATA_CHAR3_LABEL3");
                _data_char3_label4 = db.Row("DATA_CHAR3_LABEL4");
                _data_char3_desc1 = db.Row("DATA_CHAR3_DESC1");
                _data_char3_desc2 = db.Row("DATA_CHAR3_DESC2");
                _data_char3_desc3 = db.Row("DATA_CHAR3_DESC3");
                _data_char3_desc4 = db.Row("DATA_CHAR3_DESC4");
                _data_char4_label1 = db.Row("DATA_CHAR4_LABEL1");
                _data_char4_label2 = db.Row("DATA_CHAR4_LABEL2");
                _data_char4_label3 = db.Row("DATA_CHAR4_LABEL3");
                _data_char4_label4 = db.Row("DATA_CHAR4_LABEL4");
                _data_char4_desc1 = db.Row("DATA_CHAR4_DESC1");
                _data_char4_desc2 = db.Row("DATA_CHAR4_DESC2");
                _data_char4_desc3 = db.Row("DATA_CHAR4_DESC3");
                _data_char4_desc4 = db.Row("DATA_CHAR4_DESC4");
                _data_char5_label1 = db.Row("DATA_CHAR5_LABEL1");
                _data_char5_label2 = db.Row("DATA_CHAR5_LABEL2");
                _data_char5_label3 = db.Row("DATA_CHAR5_LABEL3");
                _data_char5_label4 = db.Row("DATA_CHAR5_LABEL4");
                _data_char5_desc1 = db.Row("DATA_CHAR5_DESC1");
                _data_char5_desc2 = db.Row("DATA_CHAR5_DESC2");
                _data_char5_desc3 = db.Row("DATA_CHAR5_DESC3");
                _data_char5_desc4 = db.Row("DATA_CHAR5_DESC4");
                _data_char6_label1 = db.Row("DATA_CHAR6_LABEL1");
                _data_char6_label2 = db.Row("DATA_CHAR6_LABEL2");
                _data_char6_label3 = db.Row("DATA_CHAR6_LABEL3");
                _data_char6_label4 = db.Row("DATA_CHAR6_LABEL4");
                _data_char6_desc1 = db.Row("DATA_CHAR6_DESC1");
                _data_char6_desc2 = db.Row("DATA_CHAR6_DESC2");
                _data_char6_desc3 = db.Row("DATA_CHAR6_DESC3");
                _data_char6_desc4 = db.Row("DATA_CHAR6_DESC4");
                _data_int_label1 = db.Row("DATA_INT_LABEL1");
                _data_int_label2 = db.Row("DATA_INT_LABEL2");
                _data_int_label3 = db.Row("DATA_INT_LABEL3");
                _data_int_label4 = db.Row("DATA_INT_LABEL4");
                _data_int_desc1 = db.Row("DATA_INT_DESC1");
                _data_int_desc2 = db.Row("DATA_INT_DESC2");
                _data_int_desc3 = db.Row("DATA_INT_DESC3");
                _data_int_desc4 = db.Row("DATA_INT_DESC4");
                _data_dec_label1 = db.Row("DATA_DEC_LABEL1");
                _data_dec_label2 = db.Row("DATA_DEC_LABEL2");
                _data_dec_label3 = db.Row("DATA_DEC_LABEL3");
                _data_dec_label4 = db.Row("DATA_DEC_LABEL4");
                _data_dec_desc1 = db.Row("DATA_DEC_DESC1");
                _data_dec_desc2 = db.Row("DATA_DEC_DESC2");
                _data_dec_desc3 = db.Row("DATA_DEC_DESC3");
                _data_dec_desc4 = db.Row("DATA_DEC_DESC4");
                _data_dec2_label1 = db.Row("DATA_DEC2_LABEL1");
                _data_dec2_label2 = db.Row("DATA_DEC2_LABEL2");
                _data_dec2_label3 = db.Row("DATA_DEC2_LABEL3");
                _data_dec2_label4 = db.Row("DATA_DEC2_LABEL4");
                _data_dec2_desc1 = db.Row("DATA_DEC2_DESC1");
                _data_dec2_desc2 = db.Row("DATA_DEC2_DESC2");
                _data_dec2_desc3 = db.Row("DATA_DEC2_DESC3");
                _data_dec2_desc4 = db.Row("DATA_DEC2_DESC4");
                _data_dec3_label1 = db.Row("DATA_DEC3_LABEL1");
                _data_dec3_label2 = db.Row("DATA_DEC3_LABEL2");
                _data_dec3_label3 = db.Row("DATA_DEC3_LABEL3");
                _data_dec3_label4 = db.Row("DATA_DEC3_LABEL4");
                _data_dec3_desc1 = db.Row("DATA_DEC3_DESC1");
                _data_dec3_desc2 = db.Row("DATA_DEC3_DESC2");
                _data_dec3_desc3 = db.Row("DATA_DEC3_DESC3");
                _data_dec3_desc4 = db.Row("DATA_DEC3_DESC4");
                _data_dec4_label1 = db.Row("DATA_DEC4_LABEL1");
                _data_dec4_label2 = db.Row("DATA_DEC4_LABEL2");
                _data_dec4_label3 = db.Row("DATA_DEC4_LABEL3");
                _data_dec4_label4 = db.Row("DATA_DEC4_LABEL4");
                _data_dec4_desc1 = db.Row("DATA_DEC4_DESC1");
                _data_dec4_desc2 = db.Row("DATA_DEC4_DESC2");
                _data_dec4_desc3 = db.Row("DATA_DEC4_DESC3");
                _data_dec4_desc4 = db.Row("DATA_DEC4_DESC4");

                _header_desc = db.Row("HEADER_DESC");
                _key02_label = db.Row("KEY02_LABEL");
                _key02_desc = db.Row("KEY02_DESC");
                _key03_label = db.Row("KEY03_LABEL");
                _key03_desc = db.Row("KEY03_DESC");
                _key04_label = db.Row("KEY04_LABEL");
                _key04_desc = db.Row("KEY04_DESC");
                _data_char_label = db.Row("DATA_CHAR_LABEL");
                _data_char_desc = db.Row("DATA_CHAR_DESC");
                _data_char2_label = db.Row("DATA_CHAR2_LABEL");
                _data_char2_desc = db.Row("DATA_CHAR2_DESC");
                _data_char3_label = db.Row("DATA_CHAR3_LABEL");
                _data_char3_desc = db.Row("DATA_CHAR3_DESC");
                _data_char4_label = db.Row("DATA_CHAR4_LABEL");
                _data_char4_desc = db.Row("DATA_CHAR4_DESC");
                _data_char5_label = db.Row("DATA_CHAR5_LABEL");
                _data_char5_desc = db.Row("DATA_CHAR5_DESC");
                _data_char6_label = db.Row("DATA_CHAR6_LABEL");
                _data_char6_desc = db.Row("DATA_CHAR6_DESC");
                _data_int_label = db.Row("DATA_INT_LABEL");
                _data_int_desc = db.Row("DATA_INT_DESC");
                _data_dec_label = db.Row("DATA_DEC_LABEL");
                _data_dec_desc = db.Row("DATA_DEC_DESC");
                _data_dec2_label = db.Row("DATA_DEC2_LABEL");
                _data_dec2_desc = db.Row("DATA_DEC2_DESC");
                _data_dec3_label = db.Row("DATA_DEC3_LABEL");
                _data_dec3_desc = db.Row("DATA_DEC3_DESC");
                _data_dec4_label = db.Row("DATA_DEC4_LABEL");
                _data_dec4_desc = db.Row("DATA_DEC4_DESC");

                _entry_date = DateTime.Parse(db.Row("ENTRY_DATE"));
                _chg_date = DateTime.Parse(db.Row("CHG_DATE"));
                _chg_user_id = db.Row("CHG_USER_ID");
                _update_cntr = int.Parse(db.Row("UPDATE_CNTR"));
            }
            if (db.State() == ConnectionState.Open)
                db.DbClose();

            return rtn;
        }

        /// <summary>
        /// システムパラメータヘッダーの一覧
        /// システムパラメータヘッダー一覧を取得する
        /// 
        /// 使用画面：MstSysParaMnt, MstSysParaHeaderMnt
        /// </summary>
        public DataSet GetHeaderList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append("SELECT KEY01, HEADER_DESC1, HEADER_DESC2, HEADER_DESC3, HEADER_DESC4,");

            switch (_lang)
            {
                case 2:
                    strSQL.Append("HEADER_DESC2 AS HEADER_DESC, ");
                    break;
                case 3:
                    strSQL.Append("HEADER_DESC3 AS HEADER_DESC, ");
                    break;
                case 4:
                    strSQL.Append("HEADER_DESC4 AS HEADER_DESC, ");
                    break;
                default:
                    strSQL.Append("HEADER_DESC1 AS HEADER_DESC, ");
                    break;
            }

            strSQL.Append("KEY02_LABEL1, KEY02_LABEL2, KEY02_LABEL3, KEY02_LABEL4,");
            strSQL.Append("KEY02_DESC1, KEY02_DESC2, KEY02_DESC3, KEY02_DESC4, KEY02_DIGIT,");
            strSQL.Append("KEY03_LABEL1, KEY03_LABEL2, KEY03_LABEL3, KEY03_LABEL4,");
            strSQL.Append("KEY03_DESC1, KEY03_DESC2, KEY03_DESC3, KEY03_DESC4, KEY03_DIGIT,");
            strSQL.Append("KEY04_LABEL1, KEY04_LABEL2, KEY04_LABEL3, KEY04_LABEL4,");
            strSQL.Append("KEY04_DESC1, KEY04_DESC2, KEY04_DESC3, KEY04_DESC4, KEY04_DIGIT,");
            strSQL.Append("DATA_CHAR_LABEL1, DATA_CHAR_LABEL2, DATA_CHAR_LABEL3, DATA_CHAR_LABEL4,");
            strSQL.Append("DATA_CHAR_DESC1, DATA_CHAR_DESC2, DATA_CHAR_DESC3, DATA_CHAR_DESC4,");
            strSQL.Append("DATA_CHAR2_LABEL1, DATA_CHAR2_LABEL2, DATA_CHAR2_LABEL3, DATA_CHAR2_LABEL4,");
            strSQL.Append("DATA_CHAR2_DESC1, DATA_CHAR2_DESC2, DATA_CHAR2_DESC3, DATA_CHAR2_DESC4,");
            strSQL.Append("DATA_CHAR3_LABEL1, DATA_CHAR3_LABEL2, DATA_CHAR3_LABEL3, DATA_CHAR3_LABEL4,");
            strSQL.Append("DATA_CHAR3_DESC1, DATA_CHAR3_DESC2, DATA_CHAR3_DESC3, DATA_CHAR3_DESC4,");
            strSQL.Append("DATA_CHAR4_LABEL1, DATA_CHAR4_LABEL2, DATA_CHAR4_LABEL3, DATA_CHAR4_LABEL4,");
            strSQL.Append("DATA_CHAR4_DESC1, DATA_CHAR4_DESC2, DATA_CHAR4_DESC3, DATA_CHAR4_DESC4,");
            strSQL.Append("DATA_CHAR5_LABEL1, DATA_CHAR5_LABEL2, DATA_CHAR5_LABEL3, DATA_CHAR5_LABEL4,");
            strSQL.Append("DATA_CHAR5_DESC1, DATA_CHAR5_DESC2, DATA_CHAR5_DESC3, DATA_CHAR5_DESC4,");
            strSQL.Append("DATA_CHAR6_LABEL1, DATA_CHAR6_LABEL2, DATA_CHAR6_LABEL3, DATA_CHAR6_LABEL4,");
            strSQL.Append("DATA_CHAR6_DESC1, DATA_CHAR6_DESC2, DATA_CHAR6_DESC3, DATA_CHAR6_DESC4,");
            strSQL.Append("DATA_INT_LABEL1, DATA_INT_LABEL2, DATA_INT_LABEL3, DATA_INT_LABEL4,");
            strSQL.Append("DATA_INT_DESC1, DATA_INT_DESC2, DATA_INT_DESC3, DATA_INT_DESC4,");
            strSQL.Append("DATA_DEC_LABEL1, DATA_DEC_LABEL2, DATA_DEC_LABEL3, DATA_DEC_LABEL4,");
            strSQL.Append("DATA_DEC_DESC1, DATA_DEC_DESC2, DATA_DEC_DESC3, DATA_DEC_DESC4,");
            strSQL.Append("DATA_DEC2_LABEL1, DATA_DEC2_LABEL2, DATA_DEC2_LABEL3, DATA_DEC2_LABEL4,");
            strSQL.Append("DATA_DEC2_DESC1, DATA_DEC2_DESC2, DATA_DEC2_DESC3, DATA_DEC2_DESC4,");
            strSQL.Append("DATA_DEC3_LABEL1, DATA_DEC3_LABEL2, DATA_DEC3_LABEL3, DATA_DEC3_LABEL4,");
            strSQL.Append("DATA_DEC3_DESC1, DATA_DEC3_DESC2, DATA_DEC3_DESC3, DATA_DEC3_DESC4,");
            strSQL.Append("DATA_DEC4_LABEL1, DATA_DEC4_LABEL2, DATA_DEC4_LABEL3, DATA_DEC4_LABEL4,");
            strSQL.Append("DATA_DEC4_DESC1, DATA_DEC4_DESC2, DATA_DEC4_DESC3, DATA_DEC4_DESC4,");
            strSQL.Append("ENTRY_DATE, CHG_DATE, CHG_USER_ID, UPDATE_CNTR");
            strSQL.Append(" FROM SYSTEM_PARAMETER_HEADER ");
            strSQL.Append(" ORDER BY KEY01");

            //db.DbParametersClear();

            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "header");
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
        /// 
        /// 
        /// 
        /// 使用画面：InvStockTakingAbstract
        /// </summary>
        public DataSet Get_ParameterDetail()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append(" SELECT KEY02, KEY03, KEY04,                         ");
            strSQL.Append(" DATA_CHAR, DATA_CHAR2, DATA_CHAR3,                  ");
            strSQL.Append(" DATA_CHAR4, DATA_CHAR5, DATA_CHAR6,                 ");
            strSQL.Append(" DATA_INT, DATA_DEC, DATA_DEC2, DATA_DEC3, DATA_DEC4,");
            strSQL.Append(" REMARKS1, REMARKS2, REMARKS3                        ");

            db.DbParametersClear();

            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM SYSTEM_PARAMETER                               ");
                strSQL.Append(" WHERE   KEY01       =       :KEY01                  ");
                strSQL.Append(" AND     KEY02       =       :KEY02                  ");
                db.DbPsetString("KEY01", _key01);
                db.DbPsetString("KEY02", _key02);
            }
            else
            {
                strSQL.Append(" FROM SYSTEM_PARAMETER                               ");
                strSQL.Append(" WHERE   KEY01       =       @KEY01                  ");
                strSQL.Append(" AND     KEY02       =       @KEY02                  ");
                db.DbPsetString("@KEY01", _key01);
                db.DbPsetString("@KEY02", _key02);
            }

            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "SYSTEM_Detail");
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
        /// システムパラメータヘッダー詳細の取得
        /// 指定したKEY01の内容を取得する
        /// 
        /// 使用画面：MstSysParaMnt, MstSysParaHeaderMnt
        /// </summary>
        public int GetRptInformation()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            strSQL.Append(" SELECT                                              ");
            strSQL.Append(" DATA_CHAR, DATA_CHAR2                               ");         

            db.DbParametersClear();

            if (_db_type == "ORACLE")
            {
                strSQL.Append(" FROM SYSTEM_PARAMETER                               ");
                strSQL.Append(" WHERE   KEY01       =       :KEY01                  ");
                strSQL.Append(" AND     KEY02       =       :KEY02                  ");
                db.DbPsetString("KEY01", "SLIP_NUMBER");
                db.DbPsetString("KEY02", _rptname);
            }
            else
            {
                strSQL.Append(" FROM SYSTEM_PARAMETER                               ");
                strSQL.Append(" WHERE   KEY01       =       @KEY01                  ");
                strSQL.Append(" AND     KEY02       =       @KEY02                  ");
                db.DbPsetString("@KEY01", "SLIP_NUMBER");
                db.DbPsetString("@KEY02", _rptname);
            }

            rtn = db.DbExecuteReader(strSQL.ToString());
            if (rtn == ComConst.FAILED)
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
            }
            else
            {
                _rptno = db.Row("DATA_CHAR");
                _creatname = db.Row("DATA_CHAR2");
            }
            if (db.State() == ConnectionState.Open)
                db.DbClose();

            return rtn;
        }

        /// <summary>
        /// 計画担当者パスワードチェック
        /// </summary>
        public bool SchedulerPasswordCheck(string pSchId, string pPass)
        {
            Encrypto en = new Encrypto();
            string codeStr;
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();

            if (pPass == "")
                codeStr = "";
            else
                codeStr = en.Code(pPass);

            _key01 = "SCH_ID";
            _key02 = pSchId;
            _key03 = "*";
            _key04 = "*";

            if (this.GetDetail() == ComConst.FAILED)
            {
                return false;
            }
            else
            {
                if (codeStr == _remarks3)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 計画担当者パスワードチェック
        /// </summary>
        public int SchedulerPasswordUpd(string pSchId, string pPass)
        {
            Encrypto en = new Encrypto();
            string codeStr;
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();

            if (pPass == "")
                codeStr = "";
            else
                codeStr = en.Code(pPass);

            int rtn = 0;
            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("UPDATE SYSTEM_PARAMETER      ");
                strSQL.Append("SET                          ");
                strSQL.Append("REMARKS3 = :REMARKS3     ");
                strSQL.Append(" WHERE KEY01 = 'SCH_ID'      ");
                strSQL.Append(" AND KEY02 = :KEY02          ");

                db.DbParametersClear();
                db.DbPsetString("KEY02", _key02);
            }
            else
            {
                strSQL.Append("UPDATE SYSTEM_PARAMETER      ");
                strSQL.Append("SET                          ");
                strSQL.Append("REMARKS3 = @REMARKS3     ");
                strSQL.Append(" WHERE KEY01 = 'SCH_ID'      ");
                strSQL.Append(" AND KEY02 = @KEY02          ");

                db.DbParametersClear();
                db.DbPsetString("@KEY02", pSchId);
                db.DbPsetString("@REMARKS3", codeStr);
            }

            db.DbBeginTrans();

            rtn = db.DbExecute(strSQL.ToString());
            if (rtn != ComConst.FAILED)
            {
                db.DbCommit();
                rtn = ComConst.SUCCEED;
            }
            else
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
                db.DbRollback();
            }

            return rtn;
        }
    }
}