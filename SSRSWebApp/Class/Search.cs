﻿/*|------------------------------------------------------------------------------------------|*/
/*|  [History]                                                                               |*/
/*|  2009/01/08     Ubiq_Liu   　Mod CreateSearchWindow() ADD WS_CD                          |*/
/*|  2010/07/14     Ubiq_Liu   　「営業倉庫検索画面」追加　                                　|*/
/*|------------------------------------------------------------------------------------------|*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMClass
{
    public class Search
    {
        //ADD BY LIU 2009.1.8
        protected string _ws_cd;
        public string ws_cd
        {
            get { return _ws_cd; }
            set { _ws_cd = value; }
        }
        protected int _submit_type = 0;
        public int submit_type
        {
            get { return _submit_type; }
            set { _submit_type = value; }
        }
        protected string _btn_id = "";
        public string btn_id
        {
            get { return _btn_id; }
            set { _btn_id = value; }
        }
        protected string _controlItemno = "";
        public string controlItemno
        {
            get { return _controlItemno; }
            set { _controlItemno = value; }
        }

        protected bool _SchInvAdjAct = false;
        public bool SchInvAdjAct
        {
            get { return _SchInvAdjAct; }
            set { _SchInvAdjAct = value; }
        }

        private string _rdoControl = null;
        public string rdoControl
        {
            get { return _rdoControl; }
            set { _rdoControl = value; }
        }

        //Add 2015.12.08 Ubiq-Sai Begin
        protected string _check_flag = string.Empty;
        public string check_flag { get { return _check_flag; } set { _check_flag = value; } }
        //Add 2015.12.08 Ubiq-Sai End

        #region : 各検索画面の情報 : ここに検索画面固有の情報を記入してください
        //|====================================================================================
        //|  各検索画面の定数定義
        //|====================================================================================

        /// <summary>
        /// 伝票番号検索画面
        /// </summary>
        public class SrchInvAdjAct
        {
            //伝票番号検索画面URL
            public const string URL = "../../Common/Search/SchInvAdjAct.aspx";

            public const string FUNCTION_NAME = "ReturnSrchInvAdjAct";
            //画面の高さ
            public const int HEIGHT = 560;
            //画面の幅
            public const int WIDTH = 960;
        }

        /// <summary>
        /// 倉庫検索画面
        /// </summary>
        public class SrchWhs
        {
            //倉庫検索画面URL
            public const string URL = "../../Common/Search/SrchWhs.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchWhs";
            //画面の高さ
            public const int HEIGHT = 450;
            //画面の幅

            public const int WIDTH = 600;
        }
        //--> ADD BY UBIQ-SUO 2010/09/19
        /// <summary>
        /// MRP倉庫検索画面
        /// </summary>
        public class SrchMrpWhs
        {
            //MRP倉庫検索画面URL
            public const string URL = "../../Common/Search/SrchMrpWhs.aspx";
            //呼出元に追加されるJavaScriptのFunction名


            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい



            public const string FUNCTION_NAME = "ReturnSearchMrpWhs";
            //画面の高さ
            public const int HEIGHT = 450;
            //画面の幅


            public const int WIDTH = 600;
        }
        //<-- ADD BY UBIQ-SUO 2010/09/19
        /// <summary>
        /// 仕入先検索画面
        /// </summary>
        public class SrchVendor
        {
            //仕入先検索画面URL
            public const string URL = "../../Common/Search/SrchVendor.aspx";
            public const string URL2 = "../../Common/Search/SrchPurchasePrice.aspx";

            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchVendor";
            //画面の高さ
            public const int HEIGHT = 570;  //UPD BY UBIQ-SUO 2010/09/26 550 => 570
            //画面の幅

            public const int WIDTH = 940;
        }
        /// <summary>
        /// 顧客先検索画面
        /// </summary>
        public class SrchCustomer
        {
            //顧客検索画面URL
            public const string URL = "../../Common/Search/SrchCustomer.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchCustomer";
            //画面の高さ
            public const int HEIGHT = 570;      //UPD BY UBIQ-SUO 2010/09/26 550 => 570
            //画面の幅

            public const int WIDTH = 700;
        }
        /// <summary>
        /// 品目検索画面
        /// </summary>
        public class SrchItem
        {
            //品目検索画面URL
            public const string URL = "../../Common/Search/SrchItem.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchItem";
            //画面の高さ
            public const int HEIGHT = 520;   //UPD BY UBIQ-SUO 2010/09/26 500 => 520
            //画面の幅

            public const int WIDTH = 700;
        }
        /// <summary>
        /// 作業区検索画面
        /// </summary>
        public class SrchWorkshop
        {
            //作業区検索画面URL
            public const string URL = "../../Common/Search/SrchWorkshop.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchWorkshop";
            //画面の高さ
            public const int HEIGHT = 550;
            //画面の幅

            public const int WIDTH = 600;
        }

        /// <summary>
        /// 品目作業場所検索画面
        /// </summary>
        public class SrchItem_WS
        {
            //品目作業場検索画面URL
            public const string URL = "../../Common/Search/SrchItem_WS.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchItem_WS";
            //画面の高さ
            public const int HEIGHT = 550;
            //画面の幅

            public const int WIDTH = 600;
        }

        /// <summary>
        /// 工程検索画面
        /// </summary>
        public class SrchProcess
        {
            //工程検索画面URL
            public const string URL = "../../Common/Search/SrchProcess.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchProcess";
            //画面の高さ
            public const int HEIGHT = 550;
            //画面の幅

            public const int WIDTH = 600;
        }
        /// <summary>
        /// システムパラメータ検索画面
        /// </summary>
        public class SrchSysPara
        {
            //システムパラメータ画面URL
            public const string URL = "../../Common/Search/SrchSysPara.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSystemParameter";
            //画面の高さ
            public const int HEIGHT = 550;
            //画面の幅

            public const int WIDTH = 650;
        }
        /// <summary>
        /// システムパラメータヘッダー検索画面
        /// </summary>
        public class SrchSysParaHead
        {
            //システムパラメータヘッダー画面URL
            public const string URL = "../../Common/Search/SrchSysParaHead.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSystemParameter";
            //画面の高さ
            public const int HEIGHT = 550;
            //画面の幅

            public const int WIDTH = 910;
        }
        /// <summary>
        /// 検査方法検索検索画面
        /// </summary>
        public class SrchInspection
        {
            //検査方法画面URL
            public const string URL = "../../Common/Search/SrchInspection.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchInspection";
            //画面の高さ
            public const int HEIGHT = 500;
            //画面の幅

            public const int WIDTH = 660;
        }
        /// <summary>
        /// 発注担当者検索
        /// </summary>
        public class Buyer
        {
            //発注担当者検索画面URL
            public const string URL = "../../Common/Search/SrchBuyer.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchBuyer";
            //画面の高さ
            public const int HEIGHT = 550;
            //画面の幅

            public const int WIDTH = 600;
        }
        /// <summary>
        /// JOC検索画面
        /// </summary>
        public class Joc
        {
            //JOC検索画面URL
            public const string URL = "../../Common/Search/SrchJoc.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchJoc";
            //画面の高さ
            public const int HEIGHT = 620;  //UPD BY UBIQ-SUO 2010/09/26 600 => 620
            //画面の幅

            public const int WIDTH = 930;
        }
        /// <summary>
        /// JOC検索2画面
        /// </summary>
        public class Joc2
        {
            //JOC検索2画面URL
            public const string URL = "../../Common/Search/SrchJoc2.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchJoc2";
            //画面の高さ
            public const int HEIGHT = 620;  //UPD BY UBIQ-SUO 2010/09/26 600 => 620
            //画面の幅

            public const int WIDTH = 720;
        }
        /// <summary>
        /// JOC検索3画面
        /// Add 2015.01.19 Ubiq-Sai
        /// </summary>
        public class Joc3
        {
            //JOC検索2画面URL
            public const string URL = "../../Common/Search/SrchJoc3.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchJoc3";
            //画面の高さ
            public const int HEIGHT = 620;
            //画面の幅

            public const int WIDTH = 720;
        }
        /// <summary>
        /// 原価集計コード検索画面
        /// </summary>
        public class CostCenter
        {
            //原価集計コード検索画面URL
            public const string URL = "../../Common/Search/SrchCostCenter.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchCostCenter";
            //画面の高さ
            public const int HEIGHT = 550;
            //画面の幅

            public const int WIDTH = 600;
        }
        /// <summary>
        /// 計画担当 [Not Used]
        /// </summary>
        public class SchId
        {
            //計画担当検索画面URL
            public const string URL = "../../Common/Search/SrchSchId.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchSchId";
            //画面の高さ
            public const int HEIGHT = 550;
            //画面の幅

            public const int WIDTH = 600;
        }
        /// <summary>
        /// ユーザ検索画面
        /// </summary>
        public class User
        {
            //ユーザ検索画面URL
            public const string URL = "../../Common/Search/SrchUser.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchUser";
            //画面の高さ
            public const int HEIGHT = 500;
            //画面の幅

            public const int WIDTH = 530;
        }
        /// <summary>
        /// ロール検索画面
        /// </summary>
        public class SrchRole
        {
            //検索画面URL
            public const string URL = "../../Common/Search/SrchRole.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchRole";
            //画面の高さ
            public const int HEIGHT = 450;
            //画面の幅

            public const int WIDTH = 530;
        }
        /// <summary>
        /// 用户组検索画面
        /// </summary>
        public class SrchMenugrp
        {
            //検索画面URL
            public const string URL = "../../Common/Search/SrchMenugrp.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchMenugrp";
            //画面の高さ
            public const int HEIGHT = 450;
            //画面の幅

            public const int WIDTH = 600;
        }
        /// <summary>
        /// 辞書検索画面
        /// </summary>
        public class SrchDic
        {
            //検索画面URL
            public const string URL = "../../Common/Search/SrchDictionary.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchDic";
            //画面の高さ
            public const int HEIGHT = 650;
            //画面の幅

            public const int WIDTH = 900;
        }
        /// <summary>
        /// プログラム索画面
        /// </summary>
        public class SrchProgramID
        {
            //検索画面URL
            public const string URL = "../../Common/Search/SrchProgramID.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSrchProgramID";
            //画面の高さ
            public const int HEIGHT = 550;
            //画面の幅

            public const int WIDTH = 620;
        }
        /// <summary>
        /// 项目検索画面
        /// </summary>
        public class SrchProject
        {
            //项目検索画面URL
            public const string URL = "../../Common/Search/SrchProject.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSrchProject";
            //画面の高さ
            public const int HEIGHT = 600;
            //画面の幅

            public const int WIDTH = 670;
        }
        /// <summary>
        /// 部門検索画面
        /// </summary>
        public class Dept
        {
            //部門検索画面URL
            public const string URL = "../../Common/Search/SrchDept.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchDept";
            //画面の高さ
            public const int HEIGHT = 470;
            //画面の幅

            public const int WIDTH = 670;
        }
        /// <summary>
        /// 間接費グループ検索画面
        /// </summary>
        public class OverheadGroup
        {
            //間接費グループ検索画面URL
            public const string URL = "../../Common/Search/SrchOverheadGroup.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchOverheadGroup";
            //画面の高さ
            public const int HEIGHT = 500;
            //画面の幅

            public const int WIDTH = 650;
        }
        /// <summary>
        /// 作業者検索画面
        /// </summary>
        public class Worker
        {
            //作業者検索画面URL
            public const string URL = "../../Common/Search/SrchWorker.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchWorker";
            //画面の高さ
            public const int HEIGHT = 500;
            //画面の幅

            public const int WIDTH = 600;
        }
        /// <summary>
        /// 科目検索画面
        /// </summary>
        public class Subject
        {
            //科目検索画面URL
            public const string URL = "../../Common/Search/SrchSubject.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchSubject";
            //画面の高さ
            public const int HEIGHT = 500;
            //画面の幅

            public const int WIDTH = 650;
        }
        /// <summary>
        /// 資源検索画面
        /// </summary>
        public class Resource
        {
            //資源検索画面URL
            public const string URL = "../../Common/Search/SrchResource.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchResource";
            //画面の高さ
            public const int HEIGHT = 450;
            //画面の幅

            public const int WIDTH = 610;
        }
        /// <summary>
        /// 仕様検索画面
        /// </summary>
        public class Spec
        {
            //仕様検索画面URL
            public const string URL = "../../Common/Search/SrchSpec.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSrchSpec";
            //画面の高さ
            public const int HEIGHT = 450;
            //画面の幅

            public const int WIDTH = 610;
        }
        /// <summary>
        /// 直接部門検索画面
        /// </summary>
        public class DirectDept
        {
            //検索画面URL
            public const string URL = "../../Common/Search/SrchDirectDept.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい

            public const string FUNCTION_NAME = "ReturnSearchSrchDirectDept";
            //画面の高さ
            public const int HEIGHT = 460;
            //画面の幅

            public const int WIDTH = 625;
        }

        /// <summary>
        /// 営業倉庫検索画面
        /// </summary>
        public class SrchSDMWhs
        {
            //倉庫検索画面URL
            public const string URL = "../../Common/Search/SrchSDMWhs.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSearchSDMWhs";
            //画面の高さ
            public const int HEIGHT = 450;
            //画面の幅

            public const int WIDTH = 600;
        }
        //-->ADD BY UBIQ-SUO 2011/1/27
        /// <summary>
        /// 出庫指示検索画面
        /// </summary>
        public class SrchInvDisbAct
        {
            //倉庫検索画面URL
            public const string URL = "../../Common/Search/SrchInvDisbAct.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSrchInvDisbAct";
            //画面の高さ
            public const int HEIGHT = 570;
            //画面の幅

            public const int WIDTH = 1050;
        }

        /// <summary>
        /// 販売単価検索画面
        /// </summary>
        public class SrchUnitPrice
        {
            //倉庫検索画面URL
            public const string URL = "../../Common/Search/SrchUnitPrice.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSrchUnitPrice";
            //画面の高さ
            public const int HEIGHT = 500;
            //画面の幅

            public const int WIDTH = 850;
        }
        //<--ADD BY UBIQ-SUO 2011/1/27

        //-->ADD BY UBIQ-MATSUNO 2011.06.15
        /// <summary>
        /// 出庫実績検索画面
        /// </summary>
        public class SrchInvDisbActCancel
        {
            //倉庫検索画面URL
            public const string URL = "../../Common/Search/SrchInvDisbActCancel.aspx";
            //呼出元に追加されるJavaScriptのFunction名

            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい


            public const string FUNCTION_NAME = "ReturnSrchInvDisbActCancel";
            //画面の高さ
            public const int HEIGHT = 570;
            //画面の幅

            public const int WIDTH = 1050;
        }

        /// <summary>
        /// 作業指示番号検索画面
        /// add by ubiq_sai 2015.12.08
        /// </summary>
        public class SrchMfgJobOrderNo
        {
            //検索画面URL
            public const string URL = "../../Common/Search/SrchMfgJobOrderNo.aspx";
            //呼出元に追加されるJavaScriptのFunction名
            //  画面内で重ならないようにして下さい：ただし同一の検索画面は画面内で連番をふりますので気にしないで下さい
            public const string FUNCTION_NAME = "ReturnSrchMfgJobOrderNo";

            //画面の高さ
            public const int HEIGHT = 640;
            //画面の幅
            public const int WIDTH = 930;
        }

        //|====================================================================================
        //|  検索画面タイプの追加
        //| 
        //|  　呼出元で指定するタイプです

        //|====================================================================================
        public enum SearchType
        {
            /// <summary>
            /// 倉庫検索画面
            /// </summary>
            WHS,
            //-->ADD BY UBIQ-SUO 2010/09/19
            /// <summary>
            /// MRP倉庫検索画面
            /// </summary>
            MRPWHS,
            //<--ADD BY UBIQ-SUO 2010/09/19
            /// <summary>
            /// 仕入先検索画面
            /// </summary>
            VENDOR,
            /// <summary>
            /// 顧客検索画面
            /// </summary>
            CUSTOMER,
            /// <summary>
            /// 品目検索画面
            /// </summary>
            ITEM,
            /// <summary>
            /// 作業区検索画面
            /// </summary>
            WORKSHOP,
            /// <summary>
            /// 品目作業場所検索画面
            /// </summary>
            ITEM_WS,
            /// <summary>
            /// 工程検索画面
            /// </summary>
            PROCESS,
            /// <summary>
            /// システムパラメータ検索画面
            /// </summary>
            SYSPARA,
            /// <summary>
            /// システムパラメータヘッダー検索画面
            /// </summary>
            SYSPARAHEAD,
            /// <summary>
            /// 検査方法検索
            /// </summary>
            INSPECTION,
            /// <summary>
            /// 発注担当者検索
            /// </summary>
            BUYER,
            /// <summary>
            /// JOC検索
            /// </summary>
            JOC,
            /// <summary>
            /// 製番検索2
            /// </summary>
            JOC2,
            /// <summary>
            /// 製番検索3
            /// Add 2015.01.19 Ubiq-Sai
            /// </summary>
            JOC3,
            /// <summary>
            ///原価集計コード検索
            /// </summary
            COSTCENTER,
            /// <summary>
            ///計画担当

            /// </summary
            SCHID,
            /// <summary>
            ///ユーザー検索
            /// </summary
            USER,
            /// <summary>
            ///ロール検索
            /// </summary>
            ROLE,
            /// <summary>
            ///用户组検索画面
            /// </summary> 
            MENUGRP,
            /// <summary>
            ///辞書
            /// </summary> 
            DIC,
            /// <summary>
            ///プログラム索画面
            /// </summary> 
            PROGRAMID,
            /// <summary>
            ///PROJECT索画面
            /// </summary> 
            PROJECT,
            /// <summary>
            /// DEPT索画面
            /// </summary> 
            DEPT,
            /// <summary>
            /// OVERHEADGROUP 索画面
            /// </summary> 
            OVERHEADGROUP,
            /// <summary>
            /// WORKER 索画面
            /// </summary> 
            WORKER,
            /// <summary>
            /// SUBJECT 索画面
            /// </summary> 
            SUBJECT,
            /// <summary>
            /// RESOURCE 索画面
            /// </summary> 
            RESOURCE,
            /// <summary>
            /// SPEC 索画面
            /// </summary> 
            SPEC,
            /// <summary>
            /// DIRECTDEPT 索画面
            /// </summary>
            DIRECTDEPT,
            /// <summary>
            /// 営業倉庫索画面
            /// </summary>
            SDMWHS,
            /// <summary>
            /// 出庫指示検索画面
            /// </summary>
            INVDISBACT,
            /// <summary>
            /// 販売単価検索画面
            /// </summary>
            UNITPRICE,
            /// <summary>
            /// 出庫実績検索画面 2011.06.15
            /// </summary>
            INVDISBACTCANCEL,
            /// <summary>
            /// 作業指示番号検索画面
            /// Add 2015.12.08 Ubiq-Sai
            /// </summary>
            JOB_ORDER_NO,

            /// <summary>
            /// 伝票番号検索画面
            /// Add 2016.06.30 Ubiq-x
            /// </summary>
            SCHINVADJACT
        }
        //|------------------------------------------------------------------------------------
        #endregion

        #region : コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Search()
        {
        }
        #endregion

        #region : フィールド


        /// <summary>
        /// フィールド

        /// </summary>
        // protected
        protected SearchType _search_type;
        //protected HtmlInputButton _opener_button;
        protected HtmlImage _opener_button;
        protected Page _opener;
        protected ArrayList _return_controls;
        //ADD UBIQ-LIU 2010/6/28
        protected string _open_window_name = "singleton_window";
        #endregion

        #region : プロパティ
        ///<summary>
        /// プロパティ
        ///</summary>
        public SearchType search_type
        {
            get { return _search_type; }
            set { _search_type = value; }
        }
        public Page opener
        {
            get { return _opener; }
            set { _opener = value; }
        }
        //public HtmlInputButton opener_button
        //{
        //    get { return _opener_button; }
        //    set { _opener_button = value; }
        //}
        public HtmlImage opener_button
        {
            get { return _opener_button; }
            set { _opener_button = value; }
        }
        public ArrayList return_controls
        {
            get { return _return_controls; }
            set { _return_controls = value; }
        }

        public string open_window_name { get { return _open_window_name; } set { _open_window_name = value; } }
        #endregion

        /// <summary>
        ///     固定のロジック  Fixed Logic
        /// </summary>
        /// <param name="p_searchType"></param>
        /// <param name="p_btnOpen"></param>
        /// <param name="p_page"></param>
        /// <param name="p_arrObj"></param>
        /// <returns></returns>
        public int CreateSearchWindow()
        {
            int rtn = 0;

            // 検索画面情報の取得

            string strSearchUrl = ""; string strSearchUrl2 = ""; string strReturnFunctionName = ""; int intHeight = 0; int intWidth = 0;
            rtn = GetSerchFormInfo(out strSearchUrl, out strSearchUrl2, out strReturnFunctionName, out intHeight, out intWidth);

            // スクリプトの編集(検索結果を設定)
            StringBuilder strReturnScript = new StringBuilder();
            strReturnScript.Append("\n<script type='text/javascript'>\n");
            strReturnScript.Append("<!--\n");
            strReturnScript.Append("    function " + strReturnFunctionName + "(elemValue){\n");
            for (int i = 0; i < _return_controls.Count; i++)
            {
                Control obj = (Control)_return_controls[i];
                if (obj != null)
                {
                    //strReturnScript.Append("   $('" + obj.ClientID + "').");
                    strReturnScript.Append("   document.forms[0].elements['" + obj.ClientID + "'].");

                    if (obj.GetType().Name == "Label")
                        strReturnScript.Append("innerHTML=elemValue[" + i + "];\n");
                    else if (obj.GetType().Name == "ComboBox")                        //ADD 20090327 UBIQ-LIU                    
                        strReturnScript.Append("value=elemValue[" + i + "];\n");
                    else
                        strReturnScript.Append("value=elemValue[" + i + "];\n");
                    //ADD 20090323 UBIQ-LIU                    
                    if (i == _return_controls.Count - 2)
                        strReturnScript.Append("   document.forms[0].elements['" + obj.ClientID + "'].select();\n");
                }
            }
            if (_submit_type != 0)
            {
                strReturnScript.Append("document.forms[0].elements['" + btn_id + "'].click();\n");
            }
            strReturnScript.Append(" try{ if(typeof(eval('Get_WHS_Vendor')) == 'function') Get_WHS_Vendor(); }catch(e){}");
            //strReturnScript.Append(" document.forms[0].elements['" + ((Control)_return_controls[1]).ClientID + "'].focus();\n");
            strReturnScript.Append("}\n");


            // スクリプトの編集(Window.Open)
            StringBuilder strOpenScriptPart = new StringBuilder();
            strOpenScriptPart.Append("ScriptName=").Append(strReturnFunctionName).Append("&WS_CD='+encodeURIComponent('" + ws_cd + "') ");    //Add 2015.12.08 Ubiq-Sai
            strOpenScriptPart.Append("+'&CHECK_FLAG='+'" + check_flag + "', ");  //Add 2015.12.08 Ubiq-Sai
            strOpenScriptPart.Append("'" + _open_window_name + "', 'left=400, top=100, status=no, toolbar= no, location= no, menubar= no ");
            strOpenScriptPart.Append(",height=" + intHeight.ToString());
            strOpenScriptPart.Append(",width=" + intWidth.ToString());
            strOpenScriptPart.Append("');");

            StringBuilder strOpenScript = new StringBuilder();
            if (controlItemno == "")
            {
                if (SchInvAdjAct)
                {

                    strOpenScript.Append("\n var type; ");
                    strOpenScript.Append("\n var rdolist = document.getElementById('" + rdoControl + "');");
                    strOpenScript.Append("\n var rdos = rdolist.getElementsByTagName('INPUT');");
                    strOpenScript.Append("\n for(var i = 0;i<rdos.length;i++) { ");
                    strOpenScript.Append("\n if(rdos[i].checked) type=rdos[i].value  ");
                    strOpenScript.Append("\n } ");

                    strOpenScript.Append("\n window.open('" + strSearchUrl + "?inout='+type+'&" + strOpenScriptPart.ToString());
                }
                else
                    strOpenScript.Append("\n window.open('" + strSearchUrl + "?" + strOpenScriptPart.ToString());
            }
            else
            {
                strOpenScript.Append("\n var itemno = document.getElementById('" + controlItemno + "').value;");
                strOpenScript.Append("\n if(itemno) { ");
                strOpenScript.Append("\n window.open('" + strSearchUrl2).Append("?itemno='+itemno+'&" + strOpenScriptPart.ToString());
                strOpenScript.Append("\n} else {  ");
                strOpenScript.Append("\n window.open('" + strSearchUrl + "?" + strOpenScriptPart.ToString());
                strOpenScript.Append("\n }  \n");
            }

            strReturnScript.Append(" \n function " + strReturnFunctionName + "_Search(){");
            strReturnScript.Append(strOpenScript.ToString());
            strReturnScript.Append("\n }\n");

            strReturnScript.Append("// -->\n");
            strReturnScript.Append("</script>\n");

            // クライアントスクリプトブロックの登録
            ClientScriptManager clientScriptManager = (ClientScriptManager)_opener.ClientScript;
            clientScriptManager.RegisterClientScriptBlock(_opener.GetType(), strReturnFunctionName, strReturnScript.ToString());



            // ボタンへイベントを登録
            _opener_button.Attributes.Add("onclick", strReturnFunctionName + "_Search();");

            // ページのバインド

            _opener.DataBind();
            return ComConst.SUCCEED;
        }

        /// <summary>
        /// 検索画面情報の取得

        /// </summary>
        /// <param name="p_searchType"></param>
        /// <param name="p_searchUrl"></param>
        /// <param name="p_returnFunctionName"></param>
        /// <param name="p_height"></param>
        /// <param name="p_width"></param>
        /// <returns></returns>
        private int GetSerchFormInfo(out string p_searchUrl, out string p_searchUrl2, out string p_returnFunctionName, out int p_height, out int p_width)
        {
            int cnt = 0;
            p_searchUrl = "";
            p_searchUrl2 = "";
            p_returnFunctionName = "";
            p_height = 250;
            p_width = 300;
            ClientScriptManager clientScriptManager = (ClientScriptManager)_opener.ClientScript;

            switch (_search_type)
            {
                case SearchType.SCHINVADJACT: // 伝票番号検索画面
                    p_searchUrl = SrchInvAdjAct.URL;
                    p_returnFunctionName = SrchWhs.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchWhs.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchInvAdjAct.HEIGHT;
                    p_width = SrchInvAdjAct.WIDTH;
                    break;
                case SearchType.WHS: // 倉庫検索画面
                    p_searchUrl = SrchWhs.URL;
                    p_returnFunctionName = SrchWhs.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchWhs.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchWhs.HEIGHT;
                    p_width = SrchWhs.WIDTH;
                    break;
                //-->ADD BY UBIQ-SUO 2010/09/19
                case SearchType.MRPWHS: // MRP倉庫検索画面
                    p_searchUrl = SrchMrpWhs.URL;
                    p_returnFunctionName = SrchMrpWhs.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchMrpWhs.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchMrpWhs.HEIGHT;
                    p_width = SrchMrpWhs.WIDTH;
                    break;
                //<--ADD BY UBIQ-SUO 2010/09/19
                case SearchType.VENDOR: // 仕入先検索画面
                    p_searchUrl = SrchVendor.URL;
                    p_searchUrl2 = SrchVendor.URL2;
                    p_returnFunctionName = SrchVendor.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchVendor.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchVendor.HEIGHT;
                    p_width = SrchVendor.WIDTH;
                    break;
                case SearchType.CUSTOMER: // 顧客検索画面
                    p_searchUrl = SrchCustomer.URL;
                    p_returnFunctionName = SrchCustomer.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchCustomer.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchCustomer.HEIGHT;
                    p_width = SrchCustomer.WIDTH;
                    break;
                case SearchType.ITEM: // 品目検索画面
                    p_searchUrl = SrchItem.URL;
                    p_returnFunctionName = SrchItem.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchItem.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchItem.HEIGHT;
                    p_width = SrchItem.WIDTH;
                    break;
                case SearchType.WORKSHOP: //作業区検索画面
                    p_searchUrl = SrchWorkshop.URL;
                    p_returnFunctionName = SrchWorkshop.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchWorkshop.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchWorkshop.HEIGHT;
                    p_width = SrchWorkshop.WIDTH;
                    break;
                case SearchType.ITEM_WS: //品目作業場所検索画面
                    p_searchUrl = SrchItem_WS.URL;
                    p_returnFunctionName = SrchItem_WS.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchItem_WS.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchItem_WS.HEIGHT;
                    p_width = SrchItem_WS.WIDTH;
                    break;

                case SearchType.PROCESS: //工程検索画面
                    p_searchUrl = SrchProcess.URL;
                    p_returnFunctionName = SrchProcess.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchProcess.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchProcess.HEIGHT;
                    p_width = SrchProcess.WIDTH;
                    break;
                case SearchType.SYSPARA: //システムパラメータ検索画面
                    p_searchUrl = SrchSysPara.URL;
                    p_returnFunctionName = SrchSysPara.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchSysPara.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchSysPara.HEIGHT;
                    p_width = SrchSysPara.WIDTH;
                    break;
                case SearchType.SYSPARAHEAD: //システムパラメータヘッダー検索画面
                    p_searchUrl = SrchSysParaHead.URL;
                    p_returnFunctionName = SrchSysParaHead.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchSysParaHead.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchSysParaHead.HEIGHT;
                    p_width = SrchSysParaHead.WIDTH;
                    break;
                case SearchType.INSPECTION: //購買检查方法検索画面
                    p_searchUrl = SrchInspection.URL;
                    p_returnFunctionName = SrchInspection.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchInspection.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchInspection.HEIGHT;
                    p_width = SrchInspection.WIDTH;
                    break;
                case SearchType.BUYER: //購買発注担当者検索画面
                    p_searchUrl = Buyer.URL;
                    p_returnFunctionName = Buyer.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = Buyer.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = Buyer.HEIGHT;
                    p_width = Buyer.WIDTH;
                    break;
                case SearchType.JOC: //JOC検索画面
                    p_searchUrl = Joc.URL;
                    p_returnFunctionName = Joc.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = Joc.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = Joc.HEIGHT;
                    p_width = Joc.WIDTH;
                    break;
                case SearchType.JOC2: //製番検索2画面
                    p_searchUrl = Joc2.URL;
                    p_returnFunctionName = Joc2.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = Joc2.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = Joc2.HEIGHT;
                    p_width = Joc2.WIDTH;
                    break;
                case SearchType.JOC3: //製番検索3検索画面   //Add 2015.01.19 Ubiq-Sai
                    p_searchUrl = Joc3.URL;
                    p_returnFunctionName = Joc3.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = Joc3.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = Joc3.HEIGHT;
                    p_width = Joc3.WIDTH;
                    break;
                case SearchType.COSTCENTER: //JOC検索画面
                    p_searchUrl = CostCenter.URL;
                    p_returnFunctionName = CostCenter.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = CostCenter.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = CostCenter.HEIGHT;
                    p_width = CostCenter.WIDTH;
                    break;
                case SearchType.SCHID:                  //計画担当


                    p_searchUrl = SchId.URL;
                    p_returnFunctionName = SchId.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SchId.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SchId.HEIGHT;
                    p_width = SchId.WIDTH;
                    break;
                case SearchType.USER:                  //ユーザー
                    p_searchUrl = User.URL;
                    p_returnFunctionName = SchId.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = User.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = User.HEIGHT;
                    p_width = User.WIDTH;
                    break;
                case SearchType.ROLE:                  //ロール
                    p_searchUrl = SrchRole.URL;
                    p_returnFunctionName = SrchRole.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchRole.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchRole.HEIGHT;
                    p_width = SrchRole.WIDTH;
                    break;
                case SearchType.MENUGRP:                  //用户组


                    p_searchUrl = SrchMenugrp.URL;
                    p_returnFunctionName = SrchMenugrp.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchMenugrp.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchMenugrp.HEIGHT;
                    p_width = SrchMenugrp.WIDTH;
                    break;
                case SearchType.DIC:                  //辞書
                    p_searchUrl = SrchDic.URL;
                    p_returnFunctionName = SrchDic.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchDic.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchDic.HEIGHT;
                    p_width = SrchDic.WIDTH;
                    break;
                case SearchType.PROGRAMID:                  //プログラム検索画面
                    p_searchUrl = SrchProgramID.URL;
                    p_returnFunctionName = SrchProgramID.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchProgramID.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchProgramID.HEIGHT;
                    p_width = SrchProgramID.WIDTH;
                    break;
                case SearchType.PROJECT:                  //SrchProject検索画面
                    p_searchUrl = SrchProject.URL;
                    p_returnFunctionName = SrchProject.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchProject.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchProject.HEIGHT;
                    p_width = SrchProject.WIDTH;
                    break;
                case SearchType.DEPT:                  //SrchDept検索画面
                    p_searchUrl = Dept.URL;
                    p_returnFunctionName = Dept.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = Dept.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = Dept.HEIGHT;
                    p_width = Dept.WIDTH;
                    break;
                case SearchType.OVERHEADGROUP:                  //SrchOverheadGroup検索画面
                    p_searchUrl = OverheadGroup.URL;
                    p_returnFunctionName = OverheadGroup.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = OverheadGroup.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = OverheadGroup.HEIGHT;
                    p_width = OverheadGroup.WIDTH;
                    break;
                case SearchType.WORKER:                  //作業者

                    p_searchUrl = Worker.URL;
                    p_returnFunctionName = Worker.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = Worker.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = Worker.HEIGHT;
                    p_width = Worker.WIDTH;
                    break;
                case SearchType.SUBJECT:                  //科目検索画面
                    p_searchUrl = Subject.URL;
                    p_returnFunctionName = Subject.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = Subject.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = Subject.HEIGHT;
                    p_width = Subject.WIDTH;
                    break;
                case SearchType.RESOURCE:                  //資源検索画面

                    p_searchUrl = Resource.URL;
                    p_returnFunctionName = Resource.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = Resource.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = Resource.HEIGHT;
                    p_width = Resource.WIDTH;
                    break;
                case SearchType.SPEC:                  //仕様検索画面
                    p_searchUrl = Spec.URL;
                    p_returnFunctionName = Spec.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = Spec.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = Spec.HEIGHT;
                    p_width = Spec.WIDTH;
                    break;
                case SearchType.DIRECTDEPT:                  //直接部門検索画面
                    p_searchUrl = DirectDept.URL;
                    p_returnFunctionName = DirectDept.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = DirectDept.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = DirectDept.HEIGHT;
                    p_width = DirectDept.WIDTH;
                    break;
                case SearchType.SDMWHS: // 倉庫検索画面
                    p_searchUrl = SrchSDMWhs.URL;
                    p_returnFunctionName = SrchSDMWhs.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchSDMWhs.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchSDMWhs.HEIGHT;
                    p_width = SrchSDMWhs.WIDTH;
                    break;
                //-->ADD BY UBIQ-SUO 2011/1/27
                case SearchType.INVDISBACT://出庫指示検索画面
                    p_searchUrl = SrchInvDisbAct.URL;
                    p_returnFunctionName = SrchInvDisbAct.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchInvDisbAct.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchInvDisbAct.HEIGHT;
                    p_width = SrchInvDisbAct.WIDTH;
                    break;

                case SearchType.UNITPRICE://販売単価検索画面
                    p_searchUrl = SrchUnitPrice.URL;
                    p_returnFunctionName = SrchUnitPrice.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchUnitPrice.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchUnitPrice.HEIGHT;
                    p_width = SrchUnitPrice.WIDTH;
                    break;
                //<--ADD BY UBIQ-SUO 2011/1/27

                //-->ADD BY UBIQ-MATSUNO 2011.06.15
                case SearchType.INVDISBACTCANCEL://出庫実績検索画面
                    p_searchUrl = SrchInvDisbActCancel.URL;
                    p_returnFunctionName = SrchInvDisbActCancel.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchInvDisbActCancel.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchInvDisbActCancel.HEIGHT;
                    p_width = SrchInvDisbActCancel.WIDTH;
                    break;

                case SearchType.JOB_ORDER_NO:    // 作業指示番号検索画面 Add 2015.12.08 Ubiq-Sai  
                    p_searchUrl = SrchMfgJobOrderNo.URL;
                    p_returnFunctionName = SrchMfgJobOrderNo.FUNCTION_NAME + "_0";
                    cnt = 0;
                    while (clientScriptManager.IsClientScriptBlockRegistered(_opener.GetType(), p_returnFunctionName))
                    {
                        cnt++;
                        p_returnFunctionName = SrchMfgJobOrderNo.FUNCTION_NAME + "_" + cnt.ToString();
                    }
                    p_height = SrchMfgJobOrderNo.HEIGHT;
                    p_width = SrchMfgJobOrderNo.WIDTH;
                    break;
            }
            return ComConst.SUCCEED;
        }
    }
}
