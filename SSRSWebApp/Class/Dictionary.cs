using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// 辞書クラス
/// </summary>
namespace PMClass
{
    public class Dictionary
    {
        #region : コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Dictionary()
        {
            try
            {
                _db_type = WebConfigurationManager.AppSettings["db_type"];
            }
            catch { }
        }
        public Dictionary(string p_user_id, int p_lang)
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
        protected string _std_item = "";
        protected string _item_desc = "";
        protected string _item_desc1 = "";
        protected string _item_desc2 = "";
        protected string _item_desc3 = "";
        protected string _item_desc4 = "";
        protected string _screen_id = "";
        protected string _control_id = "";
        protected DateTime _entry_date = DateTime.Now;
        protected DateTime _chg_date = DateTime.Now;
        protected string _chg_user_id = "";
        protected int _update_cntr = 0;
        protected string _dbmsg = "";
        protected string _strErr = "";
        #endregion

        #region : プロパティ
        ///<summary>
        /// プロパティ
        ///</summary>
        public int lang
        {
            get { return _lang; }
            set { _lang = value; }
        }
        public string std_item
        {
            get { return _std_item; }
            set { _std_item = value; }
        }
        public string item_desc
        {
            get { return _item_desc; }
            set { _item_desc = value; }
        }
        public string item_desc1
        {
            get { return _item_desc1; }
            set { _item_desc1 = value; }
        }
        public string item_desc2
        {
            get { return _item_desc2; }
            set { _item_desc2 = value; }
        }
        public string item_desc3
        {
            get { return _item_desc3; }
            set { _item_desc3 = value; }
        }
        public string item_desc4
        {
            get { return _item_desc4; }
            set { _item_desc4 = value; }
        }
        public string screen_id
        {
            get { return _screen_id; }
            set { _screen_id = value; }
        }
        public string control_id
        {
            get { return control_id; }
            set { _control_id = value; }
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
        public string dbmsg { get { return _dbmsg; } set { _dbmsg = value; } }
        public string strErr { get { return _strErr; } set { _strErr = value; } }
        #endregion

        /// <summary>
        /// 辞書の追加
        /// 
        /// 使用画面：MstDicMnt
        /// </summary>
        public int Insert()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("INSERT INTO DICTIONARY_MASTER ");
                strSQL.Append("(");
                strSQL.Append("STD_ITEM, ITEM_DESC1, ITEM_DESC2, ITEM_DESC3, ITEM_DESC4,");
                strSQL.Append("ENTRY_DATE, CHG_DATE, CHG_USER_ID, UPDATE_CNTR");
                strSQL.Append(") VALUES (");
                strSQL.Append(":STD_ITEM, :ITEM_DESC1, :ITEM_DESC2, :ITEM_DESC3, :ITEM_DESC4,");
                strSQL.Append(":ENTRY_DATE, :CHG_DATE, :CHG_USER_ID, :UPDATE_CNTR)");

                db.DbParametersClear();
                db.DbPsetString("STD_ITEM", _std_item);
                db.DbPsetString("ITEM_DESC1", _item_desc1);
                db.DbPsetString("ITEM_DESC2", _item_desc2);
                db.DbPsetString("ITEM_DESC3", _item_desc3);
                db.DbPsetString("ITEM_DESC4", _item_desc4);
                db.DbPsetDate("ENTRY_DATE", DateTime.Now);
                db.DbPsetDate("CHG_DATE", DateTime.Now);
                db.DbPsetString("CHG_USER_ID", _chg_user_id);
                db.DbPsetInt("UPDATE_CNTR", _update_cntr);
            }
            else
            {
                strSQL.Append("INSERT INTO DICTIONARY_MASTER ");
                strSQL.Append("(");
                strSQL.Append("STD_ITEM, ITEM_DESC1, ITEM_DESC2, ITEM_DESC3, ITEM_DESC4,");
                strSQL.Append("ENTRY_DATE, CHG_DATE, CHG_USER_ID, UPDATE_CNTR");
                strSQL.Append(") VALUES (");
                strSQL.Append("@STD_ITEM, @ITEM_DESC1, @ITEM_DESC2, @ITEM_DESC3, @ITEM_DESC4,");
                strSQL.Append("@ENTRY_DATE, @CHG_DATE, @CHG_USER_ID, @UPDATE_CNTR)");

                db.DbParametersClear();
                db.DbPsetString("@STD_ITEM", _std_item);
                db.DbPsetString("@ITEM_DESC1", _item_desc1);
                db.DbPsetString("@ITEM_DESC2", _item_desc2);
                db.DbPsetString("@ITEM_DESC3", _item_desc3);
                db.DbPsetString("@ITEM_DESC4", _item_desc4);
                db.DbPsetDate("@ENTRY_DATE", DateTime.Now);
                db.DbPsetDate("@CHG_DATE", DateTime.Now);
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
        /// 辞書の変更
        /// 
        /// 使用画面：MstDicMnt
        /// </summary>
        public int Update()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("UPDATE DICTIONARY_MASTER ");
                strSQL.Append("SET ");
                strSQL.Append("ITEM_DESC1 = :ITEM_DESC1,");
                strSQL.Append("ITEM_DESC2 = :ITEM_DESC2,");
                strSQL.Append("ITEM_DESC3 = :ITEM_DESC3,");
                strSQL.Append("ITEM_DESC4 = :ITEM_DESC4,");
                strSQL.Append("CHG_DATE = :CHG_DATE,");
                strSQL.Append("CHG_USER_ID = :CHG_USER_ID,");
                strSQL.Append("UPDATE_CNTR = UPDATE_CNTR + 1");
                strSQL.Append(" WHERE STD_ITEM = :STD_ITEM");

                db.DbParametersClear();
                db.DbPsetString("ITEM_DESC1", _item_desc1);
                db.DbPsetString("ITEM_DESC2", _item_desc2);
                db.DbPsetString("ITEM_DESC3", _item_desc3);
                db.DbPsetString("ITEM_DESC4", _item_desc4);
                db.DbPsetDate("CHG_DATE", DateTime.Now);
                db.DbPsetString("CHG_USER_ID", _chg_user_id);
                db.DbPsetString("STD_ITEM", _std_item);
            }
            else
            {
                strSQL.Append("UPDATE DICTIONARY_MASTER ");
                strSQL.Append("SET ");
                strSQL.Append("ITEM_DESC1 = @ITEM_DESC1,");
                strSQL.Append("ITEM_DESC2 = @ITEM_DESC2,");
                strSQL.Append("ITEM_DESC3 = @ITEM_DESC3,");
                strSQL.Append("ITEM_DESC4 = @ITEM_DESC4,");
                strSQL.Append("CHG_DATE = @CHG_DATE,");
                strSQL.Append("CHG_USER_ID = @CHG_USER_ID,");
                strSQL.Append("UPDATE_CNTR = UPDATE_CNTR + 1");
                strSQL.Append(" WHERE STD_ITEM = @STD_ITEM");

                db.DbParametersClear();
                db.DbPsetString("@ITEM_DESC1", _item_desc1);
                db.DbPsetString("@ITEM_DESC2", _item_desc2);
                db.DbPsetString("@ITEM_DESC3", _item_desc3);
                db.DbPsetString("@ITEM_DESC4", _item_desc4);
                db.DbPsetDate("@CHG_DATE", DateTime.Now);
                db.DbPsetString("@CHG_USER_ID", _chg_user_id);
                db.DbPsetString("@STD_ITEM", _std_item);
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
        /// 辞書の削除
        /// 
        /// 使用画面：MstDicMnt
        /// </summary>
        public int Delete()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("DELETE FROM DICTIONARY_MASTER ");
                strSQL.Append(" WHERE STD_ITEM = :STD_ITEM");

                db.DbParametersClear();
                db.DbPsetString("STD_ITEM", _std_item);
            }
            else
            {
                strSQL.Append("DELETE FROM DICTIONARY_MASTER ");
                strSQL.Append(" WHERE STD_ITEM = @STD_ITEM");

                db.DbParametersClear();
                db.DbPsetString("@STD_ITEM", _std_item);
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
        /// 辞書一覧の取得
        /// 
        /// 使用画面：MstDicMnt
        /// </summary>
        public DataSet GetDictionaryList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append("SELECT STD_ITEM, ITEM_DESC1, ITEM_DESC2, ITEM_DESC3, ITEM_DESC4,");
            strSQL.Append(" ENTRY_DATE, CHG_DATE, CHG_USER_ID,");
            strSQL.Append(" UPDATE_CNTR");
            strSQL.Append(" FROM DICTIONARY_MASTER ");

            db.DbParametersClear();

            bool condFlag = false;
            if (_std_item != "")
            {
                if (condFlag)
                {
                    strSQL.Append(" AND STD_ITEM LIKE '%" + _std_item + "%'");
                }
                else
                {
                    strSQL.Append(" WHERE STD_ITEM LIKE '%" + _std_item + "%'");
                    condFlag = true;
                }
//Del 20070518 T.Sawada
                //db.DbPsetString("STD_ITEM", _std_item);
//End Del
            }

            if (_item_desc1 != "")
            {
                if (condFlag)
                {
                    strSQL.Append(" AND ITEM_DESC1 LIKE '%" + _item_desc1 + "%'");
                }
                else
                {
                    strSQL.Append(" WHERE ITEM_DESC1 LIKE '%" + _item_desc1 + "%'");
                    condFlag = true;
                }
//Del 20070518 T.Sawada
                //db.DbPsetString("ITEM_DESC1", _item_desc1);
//End Del
            }
            
            if (_item_desc2 != "")
            {
                if (condFlag)
                {
                    strSQL.Append(" AND ITEM_DESC2 LIKE '%" + _item_desc2 + "%'");
                }
                else
                {
                    strSQL.Append(" WHERE ITEM_DESC2 LIKE '%" + _item_desc2 + "%'");
                    condFlag = true;
                }
//Del 20070518 T.Sawada
                //db.DbPsetString("ITEM_DESC2", _item_desc2);
//End Del
            }

            if (_item_desc3 != "")
            {
                if (condFlag)
                {
                    strSQL.Append(" AND ITEM_DESC3 LIKE '" + _item_desc3 + "%'");
                }
                else
                {
                    strSQL.Append(" WHERE ITEM_DESC3 LIKE '" + _item_desc3 + "%'");
                    condFlag = true;
                }
                //Del 20070518 T.Sawada
                //db.DbPsetString("ITEM_DESC3", _item_desc3);
                //End Del
            }

            if (_item_desc4 != "")
            {
                if (condFlag)
                {
                    strSQL.Append(" AND ITEM_DESC4 LIKE '" + _item_desc4 + "%'");
                }
                else
                {
                    strSQL.Append(" WHERE ITEM_DESC4 LIKE '" + _item_desc4 + "%'");
                    condFlag = true;
                }
//Del 20070518 T.Sawada
                //db.DbPsetString("ITEM_DESC4", _item_desc4);
//End Del
            }
            
            strSQL.Append(" ORDER BY STD_ITEM");

            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "dic");
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
        /// 辞書詳細の取得
        /// 
        /// 使用画面：AppUserMenu, MstDicMnt
        /// </summary>
        public int GetDictionaryDetail()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            strSQL.Append("SELECT ITEM_DESC1, ITEM_DESC2, ITEM_DESC3, ITEM_DESC4,");
            
            switch (_lang)
            {
                case 2:
                    strSQL.Append(" ITEM_DESC2 AS ITEM_DESC, ");
                    break;
                case 3:
                    strSQL.Append(" ITEM_DESC3 AS ITEM_DESC, ");
                    break;
                case 4:
                    strSQL.Append(" ITEM_DESC4 AS ITEM_DESC, ");
                    break;
                default:
                    strSQL.Append(" ITEM_DESC1 AS ITEM_DESC, ");
                    break;
            }

            strSQL.Append(" ENTRY_DATE, CHG_DATE, CHG_USER_ID,");
            strSQL.Append(" UPDATE_CNTR");
            strSQL.Append(" FROM DICTIONARY_MASTER ");
            
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" WHERE STD_ITEM = :STD_ITEM");

                db.DbParametersClear();
                db.DbPsetString("STD_ITEM", _std_item);
            }
            else
            {
                strSQL.Append(" WHERE STD_ITEM = @STD_ITEM");

                db.DbParametersClear();
                db.DbPsetString("@STD_ITEM", _std_item);
            }


            rtn = db.DbExecuteReader(strSQL.ToString());
            if (rtn == ComConst.FAILED)
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
            }
            else
            {
                _item_desc1 = db.Row("ITEM_DESC1");
                _item_desc2 = db.Row("ITEM_DESC2");
                _item_desc3 = db.Row("ITEM_DESC3");
                _item_desc4 = db.Row("ITEM_DESC4");
                _item_desc = db.Row("ITEM_DESC");
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
        /// 画面ラベルの追加
        /// </summary>
        public int InsertScreenLabel()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("INSERT INTO SCREEN_LABEL_MASTER ");
                strSQL.Append("(");
                strSQL.Append("SCREEN_ID, CONTROL_ID, STD_ITEM, ");
                strSQL.Append("ENTRY_DATE, CHG_DATE, CHG_USER_ID,");
                strSQL.Append("UPDATE_CNTR");
                strSQL.Append(") VALUES (");
                strSQL.Append(":SCREEN_ID, :CONTROL_ID, :STD_ITEM,");
                strSQL.Append(":ENTRY_DATE, :CHG_DATE, :CHG_USER_ID, :UPDATE_CNTR)");

                db.DbParametersClear();
                db.DbPsetString("SCREEN_ID", _screen_id);
                db.DbPsetString("CONTROL_ID", _control_id);
                db.DbPsetString("STD_ITEM", _std_item);
                db.DbPsetDate("ENTRY_DATE", DateTime.Now);
                db.DbPsetDate("CHG_DATE", DateTime.Now);
                db.DbPsetString("CHG_USER_ID", _chg_user_id);
                db.DbPsetInt("UPDATE_CNTR", _update_cntr);
            }
            else
            {
                strSQL.Append("INSERT INTO SCREEN_LABEL_MASTER ");
                strSQL.Append("(");
                strSQL.Append("SCREEN_ID, CONTROL_ID, STD_ITEM, ");
                strSQL.Append("ENTRY_DATE, CHG_DATE, CHG_USER_ID,");
                strSQL.Append("UPDATE_CNTR");
                strSQL.Append(") VALUES (");
                strSQL.Append("@SCREEN_ID, @CONTROL_ID, @STD_ITEM,");
                strSQL.Append("@ENTRY_DATE, @CHG_DATE, @CHG_USER_ID, @UPDATE_CNTR)");

                db.DbParametersClear();
                db.DbPsetString("@SCREEN_ID", _screen_id);
                db.DbPsetString("@CONTROL_ID", _control_id);
                db.DbPsetString("@STD_ITEM", _std_item);
                db.DbPsetDate("@ENTRY_DATE", DateTime.Now);
                db.DbPsetDate("@CHG_DATE", DateTime.Now);
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
        /// 画面ラベルの変更
        /// </summary>
        public int UpdateScreenLabel()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("UPDATE SCREEN_LABEL_MASTER ");
                strSQL.Append("SET ");
                strSQL.Append("STD_ITEM = :STD_ITEM,");
                strSQL.Append("CHG_DATE = :CHG_DATE,");
                strSQL.Append("CHG_USER_ID = :CHG_USER_ID,");
                strSQL.Append("UPDATE_CNTR = UPDATE_CNTR + 1");
                strSQL.Append(" WHERE SCREEN_ID = :SCREEN_ID");
                strSQL.Append("   AND CONTROL_ID = :CONTROL_ID");

                db.DbParametersClear();
                db.DbPsetString("STD_ITEM", _std_item);
                db.DbPsetDate("CHG_DATE", DateTime.Now);
                db.DbPsetString("CHG_USER_ID", _chg_user_id);
                db.DbPsetString("SCREEN_ID", _screen_id);
                db.DbPsetString("CONTROL_ID", _control_id);
            }
            else
            {
                strSQL.Append("UPDATE SCREEN_LABEL_MASTER ");
                strSQL.Append("SET ");
                strSQL.Append("STD_ITEM = @STD_ITEM,");
                strSQL.Append("CHG_DATE = @CHG_DATE,");
                strSQL.Append("CHG_USER_ID = @CHG_USER_ID,");
                strSQL.Append("UPDATE_CNTR = UPDATE_CNTR + 1");
                strSQL.Append(" WHERE SCREEN_ID = @SCREEN_ID");
                strSQL.Append("   AND CONTROL_ID = @CONTROL_ID");

                db.DbParametersClear();
                db.DbPsetString("STD_ITEM", _std_item);
                db.DbPsetDate("CHG_DATE", DateTime.Now);
                db.DbPsetString("CHG_USER_ID", _chg_user_id);
                db.DbPsetString("SCREEN_ID", _screen_id);
                db.DbPsetString("CONTROL_ID", _control_id);
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
        /// 画面ラベルの削除
        /// </summary>
        public int DeleteScreenLabel()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            if (_db_type == "ORACLE")
            {
                strSQL.Append("DELETE FROM SCREEN_LABEL_MASTER ");
                strSQL.Append(" WHERE SCREEN_ID = :SCREEN_ID");
                strSQL.Append("   AND CONTROL_ID = :CONTROL_ID");

                db.DbParametersClear();
                db.DbPsetString("SCREEN_ID", _screen_id);
                db.DbPsetString("CONTROL_ID", _control_id);
            }
            else
            {
                strSQL.Append("DELETE FROM SCREEN_LABEL_MASTER ");
                strSQL.Append(" WHERE SCREEN_ID = @SCREEN_ID");
                strSQL.Append("   AND CONTROL_ID = @CONTROL_ID");
                
                db.DbParametersClear();
                db.DbPsetString("@SCREEN_ID", _screen_id);
                db.DbPsetString("@CONTROL_ID", _control_id);
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
        /// 指定画面の画面ラベル一覧
        /// </summary>
        public DataSet GetScreenLabelList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append("SELECT CONTROL_ID, STD_ITEM,");
            strSQL.Append(" ENTRY_DATE, CHG_DATE, CHG_USER_ID, UPDATE_CNTR");
            strSQL.Append(" FROM SCREEN_LABEL_MASTER");
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" WHERE SCREEN_ID = :SCREEN_ID");
                strSQL.Append(" ORDER BY CONTROL_ID");

                db.DbParametersClear();
                db.DbPsetString("SCREEN_ID", _screen_id);
            }
            else
            {
                strSQL.Append(" WHERE SCREEN_ID = @SCREEN_ID");
                strSQL.Append(" ORDER BY CONTROL_ID");

                db.DbParametersClear();
                db.DbPsetString("@SCREEN_ID", _screen_id);
            }

            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "screen");
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
        /// 画面ラベル詳細の取得
        /// </summary>
        public int GetScreenLabelDetail()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            int rtn = 0;

            //--- sql
            strSQL.Append("SELECT STD_ITEM,");
            strSQL.Append(" ENTRY_DATE, CHG_DATE, CHG_USER_ID,");
            strSQL.Append(" UPDATE_CNTR");
            strSQL.Append(" FROM DICTIONARY_MASTER ");
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" WHERE SCREEN_ID = :SCREEN_ID");
                strSQL.Append("   AND CONTROL_ID = :CONTROL_ID");

                db.DbParametersClear();
                db.DbPsetString("SCREEN_ID", _screen_id);
                db.DbPsetString("CONTROL_ID", _control_id);
            }
            else
            {
                strSQL.Append(" WHERE SCREEN_ID = @SCREEN_ID");
                strSQL.Append("   AND CONTROL_ID = @CONTROL_ID");

                db.DbParametersClear();
                db.DbPsetString("@SCREEN_ID", _screen_id);
                db.DbPsetString("@CONTROL_ID", _control_id);
            }


            rtn = db.DbExecuteReader(strSQL.ToString());
            if (rtn == ComConst.FAILED)
            {
                _dbmsg = db.expmsg;
                _strErr = db.strErr;
            }
            else
            {
                _std_item = db.Row("STD_ITEM");
                _entry_date = DateTime.Parse(db.Row("ENTRY_DATE"));
                _chg_date = DateTime.Parse(db.Row("CHG_DATE"));
                _chg_user_id = db.Row("CHG_USER_ID");
                _update_cntr = int.Parse(db.Row("UPDATE_CNTR"));
            }
            //if (db.State() == ConnectionState.Open)
            if (db.State() == ConnectionState.Open)
                db.DbClose();

            return rtn;
        }
        
        
        /// <summary>
        /// 指定画面のラベル項目名一覧
        /// </summary>
        public DataSet GetLabelOfScreenList()
        {
            ComDB db = new ComDB(_db_type);
            StringBuilder strSQL = new StringBuilder();
            DataSet ds = new DataSet();

            //--- sql
            strSQL.Append("SELECT SL.CONTROL_ID, ");

            switch (_lang)
            {
                case 2:
                    strSQL.Append(" D.ITEM_DESC2 AS ITEM_DESC ");
                    break;
                case 3:
                    strSQL.Append(" D.ITEM_DESC3 AS ITEM_DESC ");
                    break;
                case 4:
                    strSQL.Append(" D.ITEM_DESC4 AS ITEM_DESC ");
                    break;
                default:
                    strSQL.Append(" D.ITEM_DESC1 AS ITEM_DESC ");
                    break;
            }
            
            strSQL.Append(" FROM SCREEN_LABEL_MASTER SL, DICTIONARY_MASTER D");
            
            if (_db_type == "ORACLE")
            {
                strSQL.Append(" WHERE SL.SCREEN_ID = :SCREEN_ID");
                strSQL.Append("   AND SL.STD_ITEM = D.STD_ITEM");
                strSQL.Append(" ORDER BY SL.CONTROL_ID");

                db.DbParametersClear();
                db.DbPsetString("SCREEN_ID", _screen_id);
            }
            else
            {
                strSQL.Append(" WHERE SL.SCREEN_ID = @SCREEN_ID");
                strSQL.Append("   AND SL.STD_ITEM = D.STD_ITEM");
                strSQL.Append(" ORDER BY SL.CONTROL_ID");

                db.DbParametersClear();
                db.DbPsetString("@SCREEN_ID", _screen_id);
            }
            


            try
            {
                ds = db.DbDataSet(strSQL.ToString(), "label");
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
