using System;
using System.Data;
//using System.Data.OracleClient;   // future use
using System.Data.SqlClient;
using System.Web.Configuration;
//using System.Collections.Specialized;

/// <summary>
/// DataBase接続クラス
/// </summary>
/// <remarks></remarks>
namespace PMClass
{
    public class ComDB
    {

        #region : コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ComDB()
        {
            //コネクション インスタンスの作成
            _cn = new SqlConnection();
            //コマンド インスタンスの作成
            _cm = new SqlCommand();

            //web.configよりコネクションストリングを取得
            _cn.ConnectionString = WebConfigurationManager.ConnectionStrings["PM"].ConnectionString;
        }

        public ComDB(string p_db_type)
        {
            _db_type = p_db_type;

            if (_db_type == "ORACLE")
            {
                /*
                //コネクション インスタンスの作成
                _cn_ora = new OracleConnection();
                //コマンド インスタンスの作成
                _cm_ora = new OracleCommand();

                //web.configよりコネクションストリングを取得
                //        _cn.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"];
                _cn_ora.ConnectionString = WebConfigurationManager.ConnectionStrings["PM"].ConnectionString;
                */
            }
            else
            {
                //コネクション インスタンスの作成
                _cn = new SqlConnection();
                //コマンド インスタンスの作成
                _cm = new SqlCommand();

                //web.configよりコネクションストリングを取得
                //        _cn.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"];
                _cn.ConnectionString = WebConfigurationManager.ConnectionStrings["PM"].ConnectionString;
            }
        }

        public ComDB(string p_db_type, string p_db)
        {
            _db_type = p_db_type;
            _db = p_db;

            if (_db_type == "ORACLE")
            {
                /*
                //コネクション インスタンスの作成
                _cn_ora = new OracleConnection();
                //コマンド インスタンスの作成
                _cm_ora = new OracleCommand();

                //web.configよりコネクションストリングを取得
                //        _cn.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"];
                _cn_ora.ConnectionString = WebConfigurationManager.ConnectionStrings["PM"].ConnectionString;
                */
            }
            else
            {
                //コネクション インスタンスの作成
                _cn = new SqlConnection();
                //コマンド インスタンスの作成
                _cm = new SqlCommand();

                //web.configよりコネクションストリングを取得
                //        _cn.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"];
                if (_db == "PM")
                {
                    _cn.ConnectionString = WebConfigurationManager.ConnectionStrings["PM"].ConnectionString;
                }
                else
                {
                    _cn.ConnectionString = WebConfigurationManager.ConnectionStrings["COM"].ConnectionString;
                }
            }
        }
        #endregion

        #region : フィールド
        /// <summary>
        /// フィールド
        /// </summary>
        protected SqlConnection _cn;
        protected SqlCommand _cm;
        protected SqlDataReader _dr;
        protected SqlDataAdapter _da;
        protected SqlTransaction _trans;
        /*
        protected OracleConnection _cn_ora;
        protected OracleCommand _cm_ora;
        protected OracleDataReader _dr_ora;
        protected OracleDataAdapter _da_ora;
        protected OracleTransaction _trans_ora;
        */
        protected string _db_type;
        protected string _db;
        protected string _strErr;
        protected string _expmsg;

        /// <summary>
        /// 定数定義
        /// </summary>
        //public const int SUCCEED = 0;
        //public const int FAILED = -1;
        #endregion

        #region : プロパティ
        /// <summary>
        /// プロパティ
        /// </summary>
        /*
        public SqlConnection cn
        {
            get { return _cn; }
            set { _cn = value; }
        }

        public SqlCommand cm
        {
            get { return _cm; }
            set { _cm = value; }
        }

        public SqlDataReader dr
        {
            get { return _dr; }
            set { _dr = value; }
        }

        public SqlDataAdapter da
        {
            get { return _da; }
            set { _da = value; }
        }
        */
        public string strErr
        {
            get { return _strErr; }
            set { _strErr = value; }
        }

        public string expmsg
        {
            get { return _expmsg; }
            set { _expmsg = value; }
        }
        #endregion

        #region : データーベース接続
        /// <summary>
        /// データーベース接続
        /// 
        /// 未使用
        /// </summary>
        public SqlConnection DbConnection()
        {
            try
            {
                _cn.Open();
                return _cn;

            }
            catch (Exception e)
            {
                String strErr;

                strErr = e.ToString();
                System.Console.Out.Write(strErr);
                return _cn;
            }

        }
        #endregion

        #region : データーベース接続の終了
        /// <summary>
        /// データーベース接続の終了
        /// </summary>
        public Boolean DbClose()
        {
            try
            {
                if (_db_type == "ORACLE")
                {
                    /*
                    _cn_ora.Close();
                    _cn_ora.Dispose();
                     */
                }
                else
                {
                    if (_trans != null)  // 2012/03/02
                    {
                        try
                        {
                            _trans.Rollback();
                        }
                        catch { }
                        _trans = null;  //ADD 2009/3/18
                    }
                    _cn.Close();
                    _cn.Dispose();
                }

                return true;

            }
            catch (Exception e)
            {
                String strErr;

                strErr = e.ToString();
                System.Console.Out.Write(strErr);
                return false;
            }
        }
        #endregion

        #region: コネクション状態
        /// <summary>
        /// コネクション状態
        /// </summary>
        public ConnectionState State()
        {
            /*
            if (_db_type == "ORACLE")
            {
                return _cn_ora.State;
            }
            else
            {
             */
            return _cn.State;
            //}
        }
        #endregion

        #region: トランザクション開始
        /// <summary>
        /// トランザクション開始
        /// </summary>
        public void DbBeginTrans()
        {

            try
            {
                if (_db_type == "ORACLE")
                {
                    /*
                    if (_cn_ora.State != ConnectionState.Open)
                        _cn_ora.Open();
                    _trans_ora = _cn_ora.BeginTransaction(IsolationLevel.ReadCommitted);
                    _cm_ora.Transaction = _trans_ora;
                     */
                }
                else
                {
                    if (_cn.State != ConnectionState.Open)
                        _cn.Open();
                    _trans = _cn.BeginTransaction(IsolationLevel.ReadCommitted);
                    _cm.Transaction = _trans;
                }
            }
            catch (Exception e)
            {
                _expmsg = e.Message;
                _strErr = e.ToString();
            }
        }
        #endregion


        #region : コミット
        /// <summary>
        /// コミット
        /// </summary>
        public void DbCommit()
        {
            try
            {
                if (_db_type == "ORACLE")
                {
                    /*
                    _trans_ora.Commit();
                    _cn_ora.Close();
                     */
                }
                else
                {
                    try
                    {
                        _trans.Commit();
                    }
                    catch { }
                    _trans = null;  //ADD 2009/3/18
                    _cn.Close();
                    _cn.Dispose();  //ADD 2012/3/2
                }
            }
            catch (Exception e)
            {
                string strErr;

                strErr = e.ToString();
                System.Console.Out.Write(strErr);
            }
        }
        #endregion

        #region : ロールバック
        /// <summary>
        /// ロールバック
        /// </summary>
        public void DbRollback()
        {
            try
            {
                if (_db_type == "ORACLE")
                {
                    /*
                    _trans_ora.Rollback();
                    _cn_ora.Close();
                     */
                }
                else
                {
                    if (_trans != null)  // 2012/03/02
                    {
                        try
                        {
                            _trans.Rollback();
                        }
                        catch { }
                        _trans = null;  //ADD 2009/3/18
                    }
                    _cn.Close();
                    _cn.Dispose();  //ADD 2012/3/2
                }
            }
            catch (Exception e)
            {
                _expmsg = e.Message;
                _strErr = e.ToString();
            }
        }
        #endregion

        #region : SQLの実行
        /// <summary>
        /// SQLの実行
        /// </summary>
        public int DbExecute(string strSql)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.CommandType = CommandType.Text;
            //    try
            //    {
            //        int rtn;
            //        if (_cn_ora.State != ConnectionState.Open)
            //            _cn_ora.Open();
            //        _cm_ora.Connection = _cn_ora;
            //        _cm_ora.CommandText = strSql;

            //        rtn = _cm_ora.ExecuteNonQuery();

            //        return rtn;
            //    }
            //    catch (Exception e)
            //    {
            //        _expmsg = e.Message;
            //        _strErr = e.ToString();
            //        return ComConst.FAILED;
            //    }
            //}
            //else
            //{
            _cm.CommandType = CommandType.Text;
            try
            {
                int rtn;
                if (_cn.State != ConnectionState.Open)
                    _cn.Open();
                _cm.Connection = _cn;
                _cm.CommandText = strSql;
                _cm.CommandTimeout = 0;     // 2010.09.24 add 0は無限

                rtn = _cm.ExecuteNonQuery();

                return rtn;
            }
            catch (Exception e)
            {
                _expmsg = e.Message;
                _strErr = e.ToString();
                return ComConst.FAILED;
            }
            //}
        }
        #endregion

        #region : データリーダ
        public int DbExecuteReader(string strSql)
        {
            //if (_db_type == "ORACLE")
            //{
            //    try
            //    {
            //        _expmsg = "";
            //        _strErr = "";
            //        if (_cn_ora.State != ConnectionState.Open)
            //            _cn_ora.Open();

            //        _cm_ora.CommandType = CommandType.Text;
            //        _cm_ora.Connection = _cn_ora;
            //        _cm_ora.CommandText = strSql;
            //        //            _cm.Connection.Open();

            //        _dr_ora = _cm_ora.ExecuteReader();

            //        if (_dr_ora.Read())
            //        {
            //            return 0;
            //        }
            //        else
            //        {
            //            return ComConst.FAILED;
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        _expmsg = e.Message;
            //        _strErr = e.ToString();
            //        return -1;
            //    }
            //}
            //else
            //{
            try
            {
                _expmsg = "";
                _strErr = "";
                if (_cn.State != ConnectionState.Open)
                    _cn.Open();

                _cm.CommandType = CommandType.Text;
                _cm.Connection = _cn;
                _cm.CommandText = strSql;
                _cm.CommandTimeout = 0;     // 2010.09.24 add 0は無限
                //            _cm.Connection.Open();

                _dr = _cm.ExecuteReader();

                if (_dr.Read())
                {
                    return 0;
                }
                else
                {
                    return ComConst.FAILED;
                }
            }
            catch (Exception e)
            {
                _expmsg = e.Message;
                _strErr = e.ToString();
                return -1;
            }
            //}
        }
        public string Row(string p_field_name)
        {
            //if (_db_type == "ORACLE")
            //{
            //    return _dr_ora[p_field_name].ToString();
            //}
            //else
            //{
            return _dr[p_field_name].ToString();
            //}
        }
        public int DbCloseReader()
        {
            try
            {
                _expmsg = "";
                _strErr = "";
                //if (_db_type == "ORACLE")
                //{
                //    _dr_ora.Close();
                //}
                //else
                //{
                _dr.Close();
                //}
            }
            catch
            {
            }
            return 0;
        }
        #endregion

        public DataSet DbDataSet(string strSql, string tblName)
        {
            //if (_db_type == "ORACLE")
            //{
            //try
            //{
            //    DataSet ds = new DataSet();
            //    _da_ora = new OracleDataAdapter();
            //    _cm_ora.CommandType = CommandType.Text;
            //    _cm_ora.Connection = _cn_ora;
            //    _da_ora.SelectCommand = _cm_ora;

            //    //--- Connection Open
            //    if (_cn_ora.State != ConnectionState.Open)
            //        _cn_ora.Open();

            //    //'--- Fill
            //    _cm_ora.CommandText = strSql;
            //    _da_ora.Fill(ds, tblName);

            //    return ds;
            //}
            //catch (Exception e)
            //{
            //    _expmsg = e.Message;
            //    _strErr = e.ToString();
            //    return null;
            //}
            //}
            //else
            //{
            try
            {
                DataSet ds = new DataSet();
                _da = new SqlDataAdapter();
                _cm.CommandType = CommandType.Text;
                _cm.Connection = _cn;
                _cm.CommandTimeout = 0;     // 2010.09.24 add 0は無限
                _da.SelectCommand = _cm;

                //--- Connection Open
                if (_cn.State != ConnectionState.Open)
                    _cn.Open();

                //'--- Fill
                _cm.CommandText = strSql;
                _da.Fill(ds, tblName);

                return ds;
            }
            catch (Exception e)
            {
                _expmsg = e.Message;
                _strErr = e.ToString();
                return null;
            }
            //}
        }

        public int DbUpdateByDS(DataSet ds, string tblName)
        {
            //if (_db_type == "ORACLE")
            //{
            //try
            //{
            //    DataTable dt = ds.Tables[tblName];

            //    // First process deletes.
            //    _da_ora.Update(dt.Select(null, null, DataViewRowState.Deleted));

            //    // Next process updates.
            //    _da_ora.Update(dt.Select(null, null, DataViewRowState.ModifiedCurrent));

            //    // Finally, process inserts.
            //    _da_ora.Update(dt.Select(null, null, DataViewRowState.Added));

            //    return 0;
            //}
            //catch (Exception e)
            //{
            //    _expmsg = e.Message;
            //    _strErr = e.ToString();
            //    return ComConst.FAILED;
            //}
            //}
            //else
            //{
            try
            {
                DataTable dt = ds.Tables[tblName];

                // First process deletes.
                _da.Update(dt.Select(null, null, DataViewRowState.Deleted));

                // Next process updates.
                _da.Update(dt.Select(null, null, DataViewRowState.ModifiedCurrent));

                // Finally, process inserts.
                _da.Update(dt.Select(null, null, DataViewRowState.Added));

                return 0;
            }
            catch (Exception e)
            {
                _expmsg = e.Message;
                _strErr = e.ToString();
                return ComConst.FAILED;
            }
            //}
        }

        public int DbStored(string procnm)
        {
            int rtn;

            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Connection = _cn_ora;
            //    _cm_ora.CommandText = procnm;
            //    _cm_ora.CommandType = CommandType.StoredProcedure;
            //    rtn = _cm_ora.ExecuteNonQuery();
            //    //if (rtn == 1)
            //    //{
            //    //    return int.Parse(_cm_ora.Parameters["rtn"].Value.ToString());
            //    //}
            //    //else
            //    //{
            //    //    return ComConst.FAILED;
            //    //}
            //    try
            //    {
            //        return int.Parse(_cm_ora.Parameters["rtn"].Value.ToString());
            //    }
            //    catch
            //    {
            //        return ComConst.FAILED;
            //    }
            //}
            //else
            //{
            // 2011.03.08
            if (_cn.State != ConnectionState.Open)
                _cn.Open();

            _cm.Connection = _cn;
            _cm.CommandText = procnm;
            _cm.CommandType = CommandType.StoredProcedure;
            _cm.CommandTimeout = 0;     // 2010.09.24 add 0は無限

            try
            {
                rtn = _cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _cm.Parameters["RET"].Value = ComConst.FAILED;
                strErr = ex.Message;
                return ComConst.FAILED; ;
            }
            //if (rtn == 1)
            //{
            //    return int.Parse(_cm.Parameters["rtn"].Value.ToString());
            //}
            //else
            //{
            //    return ComConst.FAILED;
            //}
            try
            {
                return int.Parse(_cm.Parameters["RET"].Value.ToString());
            }
            catch
            {
                return ComConst.FAILED;
            }
            //}
        }

        //--------------------------------------------------------------
        // パラメータの設定
        //--------------------------------------------------------------
        // パラメータのクリア
        public void DbParametersClear()
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Clear();
            //}
            //else
            //{
            _cm.Parameters.Clear();
            //}
        }

        // 戻値
        public void DbPsetReturn()
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Clear();
            //    _cm_ora.Parameters.Add("rtn", OracleType.Int32, 1).Value = 0;
            //    _DirectionSet("rtn", ComConst.DB_RTN);
            //}
            //else
            //{
            _cm.Parameters.Clear();
            _cm.Parameters.Add("rtn", SqlDbType.Int, 1).Value = 0;
            _DirectionSet("rtn", ComConst.DB_RTN);
            //}
        }

        // string	
        public void DbPsetString(string name, string val)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.VarChar, 1024).Value = val;
            //}
            //else
            //{
            //_cm.Parameters.Add(name, SqlDbType.NVarChar, 1024).Value = val;       //Del 2016.08.23 Ubiq-Sai
            _cm.Parameters.Add(name, SqlDbType.NVarChar, 1024).Value = val.Trim();  //Add 2016.08.23 Ubiq-Sai
            //}
        }
        public void DbPsetString(string name, string val, int direction)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.VarChar, 1024).Value = val;
            //}
            //else
            //{
            //_cm.Parameters.Add(name, SqlDbType.NVarChar, 1024).Value = val;       //Del 2016.08.23 Ubiq-Sai
            _cm.Parameters.Add(name, SqlDbType.NVarChar, 1024).Value = val.Trim();  //Add 2016.08.23 Ubiq-Sai
            //}
            _DirectionSet(name, direction);
        }

        // Add 2016.10.12 Ubiq-Sai Begin
        public void DbPsetStringVarChar(string name, string val)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.VarChar, 1024).Value = val;
            //}
            //else
            //{
            _cm.Parameters.Add(name, SqlDbType.VarChar, 1024).Value = val.Trim();
            //}
        }
        public void DbPsetStringVarChar(string name, string val, int direction)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.VarChar, 1024).Value = val;
            //}
            //else
            //{
            _cm.Parameters.Add(name, SqlDbType.VarChar, 1024).Value = val.Trim();
            //}
            _DirectionSet(name, direction);
        }
        // Add 2016.10.12 Ubiq-Sai End

        // int
        public void DbPsetInt(string name, int val)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.Int32, 1).Value = val;
            //}
            //else
            //{
            _cm.Parameters.Add(name, SqlDbType.Int, 1).Value = val;
            //}
        }
        public void DbPsetInt(string name, int val, int direction)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.Int32, 1).Value = val;
            //}
            //else
            //{
            _cm.Parameters.Add(name, SqlDbType.Int, 1).Value = val;
            //}
            _DirectionSet(name, direction);
        }

        // double
        public void DbPsetDouble(string name, double val)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.Double, 1).Value = val;
            //}
            //else
            //{
            //_cm.Parameters.Add(name, SqlDbType.Decimal, 1).Value = val;   //Del 2016.10.01 Ubiq-Sai
            _cm.Parameters.Add(name, SqlDbType.Float).Value = val;          //Add 2016.10.01 Ubiq-Sai
            //}
        }
        public void DbPsetDouble(string name, double val, int direction)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.Double, 1).Value = val;
            //}
            //else
            //{
            //_cm.Parameters.Add(name, SqlDbType.Decimal, 1).Value = val;   //Del 2016.10.01 Ubiq-Sai
            _cm.Parameters.Add(name, SqlDbType.Float).Value = val;          //Add 2016.10.01 Ubiq-Sai
            //}
            _DirectionSet(name, direction);
        }

        // date
        public void DbPsetDate(string name, DateTime val)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.DateTime, 1).Value = val;
            //}
            //else
            //{
            _cm.Parameters.Add(name, SqlDbType.DateTime, 1).Value = val;
            //}
        }
        public void DbPsetDate(string name, DateTime val, int direction)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.DateTime, 1).Value = val;
            //}
            //else
            //{
            _cm.Parameters.Add(name, SqlDbType.DateTime, 1).Value = val;
            //}
            _DirectionSet(name, direction);
        }
        // xml	2014.07.11
        public void DbPsetXml(string name, string val, int intSize)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.VarChar, 1024).Value = val;
            //}
            //else
            //{
            //_cm.Parameters.Add(name, SqlDbType.VarChar, 1024).Value = val;
            _cm.Parameters.Add(name, SqlDbType.Xml, intSize).Value = val;
            //}
        }
        public void DbPsetXml(string name, string val, int intSize, int direction)
        {
            //if (_db_type == "ORACLE")
            //{
            //    _cm_ora.Parameters.Add(name, OracleType.VarChar, 1024).Value = val;
            //}
            //else
            //{
            //_cm.Parameters.Add(name, SqlDbType.VarChar, 1024).Value = val;
            _cm.Parameters.Add(name, SqlDbType.Xml, intSize).Value = val;
            //}
            _DirectionSet(name, direction);
        }

        // ﾊﾟﾗﾒｰﾀの属性設定
        private void _DirectionSet(string name, int direction)
        {
            ////if (_db_type == "ORACLE")
            ////{
            ////    switch (direction)
            ////    {
            ////        case ComConst.DB_RTN:
            ////            _cm_ora.Parameters[name].Direction = ParameterDirection.ReturnValue;
            ////            break;
            ////        case ComConst.DB_IN:
            ////            _cm_ora.Parameters[name].Direction = ParameterDirection.Input;
            ////            break;
            ////        case ComConst.DB_INOUT:
            ////            _cm_ora.Parameters[name].Direction = ParameterDirection.InputOutput;
            ////            break;
            ////        case ComConst.DB_OUT:
            ////            _cm_ora.Parameters[name].Direction = ParameterDirection.Output;
            ////            break;
            ////    }
            ////}
            ////else
            ////{
            switch (direction)
            {
                case ComConst.DB_RTN:
                    _cm.Parameters[name].Direction = ParameterDirection.ReturnValue;
                    break;
                case ComConst.DB_IN:
                    _cm.Parameters[name].Direction = ParameterDirection.Input;
                    break;
                case ComConst.DB_INOUT:
                    _cm.Parameters[name].Direction = ParameterDirection.InputOutput;
                    break;
                case ComConst.DB_OUT:
                    _cm.Parameters[name].Direction = ParameterDirection.Output;
                    break;
            }
            //}
        }

        //--------------------------------------------------------------
        // パラメータの獲得
        //--------------------------------------------------------------
        // string	
        public string DbPgetString(string name)
        {
            string val = "";
            //if (_db_type == "ORACLE")
            //{
            //    val = _cm_ora.Parameters[name].Value.ToString();
            //}
            //else
            //{
            val = _cm.Parameters[name].Value.ToString();
            //}
            return val;
        }

        // int
        public int DbPgetInt(string name)
        {
            int rtn = 0;
            try
            {
                //if (_db_type == "ORACLE")
                //{
                //    rtn = int.Parse(_cm_ora.Parameters[name].Value.ToString());
                //}
                //else
                //{
                rtn = int.Parse(_cm.Parameters[name].Value.ToString());
                //}
            }
            catch { }
            return rtn;
        }

        // double
        public double DbPgetDouble(string name)
        {
            double rtn = 0;
            try
            {
                //if (_db_type == "ORACLE")
                //{
                //    rtn = double.Parse(_cm_ora.Parameters[name].Value.ToString());
                //}
                //else
                //{
                rtn = double.Parse(_cm.Parameters[name].Value.ToString());
                //}
            }
            catch { }
            return rtn;
        }

        #region ↓ADD 2010/01/06 USE BY 目配り↓
        //==================  ↓ADD 2010/01/06 USE BY 目配り↓  ====================
        /// <summary>
        /// ﾃﾞｰﾀ操作用自動ｺﾏﾝﾄﾞ生成ｸﾗｽ
        /// </summary>
        protected SqlCommandBuilder ManipulateCB=new SqlCommandBuilder();

        #region DbManipulateDT : ﾃﾞｰﾀ操作用ﾃﾞｰﾀﾃｰﾌﾞﾙを作成して返す
        //-------------------------------------------------------------------
        // ﾃﾞｰﾀ操作用ﾃﾞｰﾀﾃｰﾌﾞﾙを作成して返す
        //-------------------------------------------------------------------
        /// <summary>
        /// ﾃﾞｰﾀ操作用ﾃﾞｰﾀﾃｰﾌﾞﾙを作成して返す
        /// </summary>
        /// <param name="strSql">実行対象のSQL文</param>
        /// <param name="tblName">ﾃｰﾌﾞﾙ名</param>
        /// <returns>DataSet(ｴﾗｰ時は例外を投げる)</returns>
        public DataSet DbManipulateDS(string strSql, string tblName)
        {
            DataSet ds = new DataSet();
            _da = new SqlDataAdapter();
            _cm.CommandType = CommandType.Text;
            _cm.Connection = _cn;
            _da.SelectCommand = _cm;

            //--- Connection Open
            if (_cn.State != ConnectionState.Open)
                _cn.Open();

            //'--- Fill
            _cm.CommandText = strSql;
            //ﾃﾞｰﾀ操作用ﾃﾞｰﾀｱﾀﾞﾌﾟﾀｰにｺﾏﾝﾄﾞを設定
            //ManipulateDA.SelectCommand = oc;

            //ｺﾏﾝﾄﾞﾋﾞﾙﾀﾞｰのﾃﾞｰﾀｱﾀﾞﾌﾟﾀｰをﾃﾞｰﾀ操作用ﾃﾞｰﾀｱﾀﾞﾌﾟﾀｰに設定
            ManipulateCB.DataAdapter = _da;

            _da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            try
            {
                _da.Fill(ds, tblName);                
                return ds;
            }
            catch (SqlException e)
            {
                //_oracode = (long)e.Number;
                _expmsg = e.Message;
                _strErr = e.ToString();
                return null;
                //throw new ComException(e.Message, e.Number.ToString(), strSql, MethodInfo.GetCurrentMethod().Name);

            }
            catch
            {
                return null;
                //throw new ComException(ex.Message, null, null, MethodInfo.GetCurrentMethod().Name);
            }

        }
        #endregion      
        #endregion 20100106 ADD END
    }
}