/*|======================================================================================|*/
/*|   JScript ファイル                                                                   |*/
/*|   プロジェクト名　：　ProductionMaster                                               |*/
/*|   システム名　　　：　PM                                                             |*/
/*|   機能名　　　　　：　GridViewスクロールバー処理                                     |*/
/*|   プログラム名    ：　superTables                                                    |*/
/*|   プログラムID  　：　superTables                                                    |*/
/*|--------------------------------------------------------------------------------------|*/
/*| [履歴]                                                                               |*/
/*|                                                                                      |*/
/*| 2010/03/02     Wanghui  　新規作成                                                   |*/
/*| 2010/05/19     UBIQ-LIU  「表示幅の計算」の追加;                                     |*/
/*|                           ファイルの整理;                                            |*/
/*|                           注釈の簡単な日本語翻訳;                                    |*/
/*|======================================================================================|*/
//実体宣言
var superTables = [];

//ステートメントメソッド
var superTable = function(tableId) {
    var x = superTables.length;
    this.index = x;
    superTables[x] = this;

    this.sourceTable = document.getElementById(tableId); //オブジェクトを取得 * 对象取得
    this.hasOptions = (arguments.length > 1) ? true : false; //検査パラメータが空です * 检查参数是否为空

    this.rowHeadHeight = 27;                                          //設置Headerデフォルトの高さ
    this.rowFootHeight = 0;                                           //設置Footerデフォルトの高さ

    this.rowsCount = this.sourceTable.tBodies[0].rows.length;         //RowsCountの取得する
    this.callbackFunc = (this.hasOptions && arguments[1].onFinish) ? arguments[1].onFinish : function() { return this; }; //パラメータなしの場合、戻る * 为空返回

    this.PagerFlag = 0; // ページングのフラグ「0：ページングなし,1:ページング」
    //行のCSS名は「GVPager」の場合、この行はフッター行. * 判断是否有分页（检查最后一行的CSS是否为“GVPager”仅限该项目的条件判断）
    if (sourceTable.tBodies[0].rows[sourceTable.tBodies[0].rows.length - 1].className == "GVPager") {
        this.PagerFlag = 1;
        this.rowFootHeight = 27;                                     //ページングの場合、Footerデフォルトの高さ
    }

    //カラムINDEX
    var i;
    //オブジェクトの親容器　*　对象的父容器操作
    this.sParent = this.sourceTable.parentNode;
    this.sParentHeight = arguments[1].fixHeight; //GridViewの表示高い
    //UPDATE UBIQ-LIU 2010/05/19 <WHEN NOT SET fixWidth THEN AUTO SET THE WIDTH>
    if(arguments[1].fixWidth > 0) {
        //表示幅が指定の場合、指定された幅を使用して
        this.sParentWidth = arguments[1].fixWidth;
    }
    else {
        //表示幅が指定されていません、計算幅を使用して
        this.sParentWidth = this.sourceTable.tBodies[0].offsetWidth + 19;
    }
    this.sParent.style.width = sParentWidth + "px";//親容器幅の指定
    //alert(this.sParentWidth);
    this.sParent.removeChild(this.sourceTable); //削除元のオブジェク*ト原对象删除

    //定義サブDIV-sBase。
    this.sBase = document.createElement("DIV");
    //sBaseのサブDIV-sHeaderの追加「Header div」
    this.sHeader = this.sBase.cloneNode(false);

    //sBaseのサブDIV-sDataの追加「DATA div」
    this.sData = this.sBase.cloneNode(false);

    //ページングの場合、sBaseのサブDIV-sFooterの追加「Footer div」*　如果有分页的情况 为sBase创建一个子容器-sFooter，用来存放最终Foot部分
    if (this.PagerFlag > 0) {
        this.sFooter = this.sBase.cloneNode(false);
    }
    
    //ヘッダーのdivが作成されます * 创建Header部分的DIV
    this.sHeader.style.width = sParentWidth - 17 + "px";  //ヘッダーのdivの表示幅の設定「GridViewの表示幅-17px(DATAのDIVに垂直スクロールバーの幅)」
    this.sHeader.id = this.sourceTable.id + "haed";       //divのid設定「overlay」、スクロールバーを同期するために使用
    this.sHeader.style.overflow = "hidden";               //ヘッドのDIVのスクロールバーが表示されないに設定され  *  设置div滚动条不可见

    var clonHeaderMold = sourceTable.cloneNode(true);
    this.sHeader.appendChild(clonHeaderMold);
    clonHeaderMold.id = "overlayHead";
    for (i = 0; i < rowsCount - 1; i++) {
        //ヘッダー以外の行は削除する。
        clonHeaderMold.deleteRow(1);
    }

    //フッターのdivが作成されます * 创建Footer部分的DIV
    if (this.PagerFlag > 0) {
        this.sFooter.style.overflow = "hidden";
        this.sFooter.style.width = sParentWidth + "px";
        this.sFooter.style.background = "Gray";

        var clonFooterMold = sourceTable.cloneNode(true);
        this.sFooter.appendChild(clonFooterMold);
        clonFooterMold.id = "overlayFoot";
        for (i = 0; i < rowsCount - 1; i++) {
            //フッター以外の行は削除する。
            clonFooterMold.deleteRow(0);
        }
        clonFooterMold.style.width = sParentWidth;
    }

    //データのdivが作成されます * 创建Data部分的DIV
    this.sData.id = this.sourceTable.id + "body";
    this.sData.style.width = sParentWidth + "px";
    this.sData.style.height = sParentHeight - rowHeadHeight - rowFootHeight + "px";
    this.sData.style.overflowY = "scroll"; //垂直スクロールバーは常に表示(必要)   * 竖滚动条一直显示（必须，隐藏的话会使GridView横滚动不同步）
    this.sData.style.overflowX = "auto"; //水平スクロールバーは自動に表示されます * 横滚动条根据情况显示

    var clonDataMold = sourceTable.cloneNode(true); //オブジェクトの複製*克隆对象

    this.sData.appendChild(clonDataMold);

    clonDataMold.deleteRow(0);                      //最初の行を削除する(HEADER ROW) * Header行删除
    if (this.PagerFlag > 0) {                        
        clonDataMold.deleteRow(clonDataMold.rows.length - 1); //最後の行を削除する *Footer行删除
    }
    sData.style.width = sParentWidth;
    sData.style.background = "#D5D5D5";
    sBase.appendChild(sHeader);
    sBase.appendChild(sData);
    if (this.PagerFlag > 0) {
        sBase.appendChild(sFooter);
    }
    this.sParent.appendChild(this.sBase);

    //データのdivにonscrollイベントを追加 「フッターのdivのonscrollイベントの同期化」*DATA部分DIV增加onscroll事件[与head部分的横滚动条事件同步]
    this.sData.onscroll = function() {
        superTables[x].sHeader.scrollLeft = superTables[x].sData.scrollLeft;
        return true;
    }
    return this.callbackFunc();
}

/*--------------------------------------------------------------------------------------------*/
/*  ブラウザの高さを取得  　　　　　                                                          */
/*  西安側移入「PM 4.26 日本側追加」　　　　　　　                                            */
/*--------------------------------------------------------------------------------------------*/
function getBrowserHeight() {
        if ( window.innerHeight ) {
                return window.innerHeight;
        }
        else if ( document.documentElement && document.documentElement.clientHeight != 0 ) {
                return document.documentElement.clientHeight;
        }
        else if ( document.body ) {
                return document.body.clientHeight;
        }
        return 0;
}