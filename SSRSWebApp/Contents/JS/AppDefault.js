
/*|------------------------------------------------------------------------------------------|*/
/*|  JScript ファイル 　                                                                     |*/
/*|  プロジェクト名　：　Product7                                                            |*/
/*|  システム名　　　：　WorkFlow                                                            |*/
/*|  機能名　　　　　：　JavaScript共通処理                                                  |*/
/*|  プログラム名    ：　JavaScript共通処理                                                  |*/
/*|  プログラムID  　：　AppDefault                                                          |*/
/*|------------------------------------------------------------------------------------------|*/
/*|  [履歴]  　                                                                              |*/
/*|  2007/01/31     Ubiq.Matsuno  　新規作成                                                 |*/
/*|------------------------------------------------------------------------------------------|*/

// ---------------------------------------
// メソッド一覧
// ---------------------------------------
// StringBuilderLf    : 文字列の結合[改行コード]　
// StringBuilderComma : 文字列の結合[カンマ編集]
// SetCursor : Mouseポインターの設定
// [ FarPointSpread関連 ]
// SpreadSetColumnLock : 列のロック
// SpreadSetColumnUnLock : 列のロック解除
// SpreadClearValue : データクリア
// [非同期通信関連]
// ChangeText : 入力値変更イベント
// ReceiveServerReturnValue : 入力値変更イベントのサーバー側からのReturn処理
// Count : 文字数チェック


// ---------------------------------------
// 定数
// ---------------------------------------
var LF = String.fromCharCode(10);       // 改行コード(LF)
var CR = String.fromCharCode(13);       // 改行コード(CR)
var TAB = String.fromCharCode(9);       // タブコード(TAB)
var COMMA = String.fromCharCode(44);    // カンマ

/*--------------------------------------------------------------------------------------------*/
/*  文字列の結合[改行コード]　　　　                                                          */
/*                                                                                            */
/*--------------------------------------------------------------------------------------------*/
function StringBuilderLf(key, value){
    var strBuild = ""
    try{    
        strBuild = key + LF + value + LF;
    }catch(e){  
    }
    return strBuild;
}

/*--------------------------------------------------------------------------------------------*/
/*  文字列の結合[カンマ編集] 　　　　                                                         */
/*                                                                                            */
/*--------------------------------------------------------------------------------------------*/
function StringBuilderComma(key, value){
    var strBuild = ""
    try{    
        strBuild = key + COMMA + value + COMMA;
    }catch(e){  
    }
    return strBuild;
}

/*--------------------------------------------------------------------------------------------*/
/*  Mouseポインターの設定   　　　　                                                          */
/*                                                                                            */
/*--------------------------------------------------------------------------------------------*/
function SetCursor(cursorType){
    
    switch(cursorType){
    case "wait":
    case "default":
        break;
    default: return;
    }
    
    document.body.style.cursor = cursorType;
}

/*--------------------------------------------------------------------------------------------*/
/*  KeyEventの設定     　　　　                                                          　　 */
/*                                                                                            */
/*--------------------------------------------------------------------------------------------*/
/*
function KeyEvent() {
    switch (event.keyCode){
    case 13:
        NextTab();
        break;
    }

}
document.onkeydown = KeyEvent;
*/
/*--------------------------------------------------------------------------------------------*/
/*  次のタブへ移動     　　　　                                                          　　 */
/*                                                                                            */
/*--------------------------------------------------------------------------------------------*/
function NextTab() {

    try{
    
        // 下記以外のページはReturnキーを受け入れる
        if (document.URL.indexOf("AppRequest_Detail.aspx") == -1
       　　&& document.URL.indexOf("AppApproval_Input.aspx") == -1
       　　&& document.URL.indexOf("AppFormDef_Definition.aspx") == -1){
            return;
        }    
    
        // 処理対象外チェック
        if (event.keyCode != Event.KEY_RETURN) 
            return;
       
        // Returnキーの場合は次のタブへ移動

        if (event.keyCode == Event.KEY_RETURN){
            var canFocus = false;
            var nowitem = Event.element(event);  
            if (nowitem != null){
                if (nowitem.tagName != "TEXTAREA"){
                    do {
                        nowitem = nowitem.nextSibling;
                        if (nowitem != null){
                            switch(nowitem.tagName){
                            case "INPUT":
                            case "SELECT":
                                canFocus = true;
                                break;
                            }
                        }
                        if (canFocus == true) break;
                    }while(nowitem != null)
                }
            }
        
            // 
            if (canFocus){
                nowitem.focus();
            }
            
            if (nowitem.tagName != "TEXTAREA"){
                // Returnイベントは停止
                Event.stop(event);
            }
        }  
    }catch(e){  
    }
} 
            

/*=========================================================================================================*/
/*  FarPointSpread    　                                                                                   */
/*=========================================================================================================*/
/*--------------------------------------------------------------------------------------------*/
/*  列のロック                                                                                */
/*--------------------------------------------------------------------------------------------*/    
function SpreadSetColumnLock(spr, col){
    var view = spr.id + "_view"
    var span = spr.all(view); 
    var table = span.firstChild; 
    var tr; 
    for (var j = 0;j<spr.GetRowCount();j++) { 
        tr= table.rows(j); 
        tc = tr.cells(col);
        tc.setAttribute("FpCellType","readonly"); 
    } 
}
/*--------------------------------------------------------------------------------------------*/
/*  列のロック解除                                                                            */
/*--------------------------------------------------------------------------------------------*/    
function SpreadSetColumnUnLock(spr, col){
    var view = spr.id + "_view"
    var span = spr.all(view); 
    var table = span.firstChild; 
    var tr; 
    for (var j = 0;j<spr.GetRowCount();j++) { 
         tr = table.rows(j); 
         tc = tr.cells(col);
         tc.removeAttribute("FpCellType"); 
    } 
}

/*--------------------------------------------------------------------------------------------*/
/*  データクリア　　                                                                          */
/*--------------------------------------------------------------------------------------------*/    
function SpreadClearValue(spr){
    var i, j; 
    for(i=0;i<spr.GetRowCount();i++) 
    for(j=0;j<spr.GetColCount();j++) 
    spr.SetValue(i,j,""); 
}

/*=========================================================================================================*/
/*  Ajax[非同期通信]    　                                                                                 */
/*=========================================================================================================*/
function ChangeText(event, strUnique, objUniqueID, objID, objType, exdbKbn, exdbString){
/*--------------------------------------------------------------------------------------------*/
/*  入力値変更イベント                                                                        */
/*                                                                                            */
/*--------------------------------------------------------------------------------------------*/    
    try{
        
        try{
            var msg = strUnique + "lblMsg";
            $(msg).innerHTML = "";
        }catch(e){}
        
        var objValue = "";
        switch(objType){
        case 1:     //TextBox
        case 4:     //DateText
            objValue = $(objUniqueID).value;    
            break;
        case 2:     //DropDownList
            var n = $(objUniqueID).selectedIndex;
            objValue = $(objUniqueID).options[n].value;
            break;
        case 3:     //CheckBox
            objValue = 0;
            if ($(objUniqueID).checked) 
                objValue = 1;
            break;
        default: 
            return; 
            break;
        }
        
        //| パラメータ作成
        var paramData = "";
        paramData += StringBuilderComma("UniqueID" , objUniqueID);
        paramData += StringBuilderComma("ID"       , objID);
        paramData += StringBuilderComma("Type"     , objType);
        paramData += StringBuilderComma("Value"    , objValue);
	    paramData += LF;
	    if (exdbKbn != 0){
	        // [改行区切り]を配列に展開
            var arrObj = exdbString.split(":");
            
            // 配列を連想配列に変換
            for (p = 0; p < arrObj.length; p++){
                var arrItems = arrObj[p].split(COMMA);
                var hashRow = new Object();
                for (c = 0; c < arrItems.length; c=c+2){
                    hashRow[arrItems[c]] = arrItems[c + 1];
                }
                arrObj[p] = hashRow;
            }
            
            // 対象コントロールの値を取得
            for (p = 0; p < arrObj.length; p++){
                var hashRow = arrObj[p];
                if (hashRow["UniqueID"] != "undefined"){    
                    var uniqid = hashRow["UniqueID"]; 
                    var itemid = hashRow["ID"]; 
                    var type = hashRow["Type"];
                    var value = "";
                    try{
                        var tarElm = $(hashRow["UniqueID"]);
                        switch (hashRow["Type"]){
                        case "0":   //Label
                        case "1":   //TextBox
                        case "4":   //DateText
                            value = tarElm.value;
                            break;
                        case "2":   //DropDownList
                            n = tarElm.selectedIndex;
                            value = tarElm.options[n].value;
                            break;
                        case "3":   //CheckBox
                            value = 0;
                            if (tarElm.checked){
                                value = 1;
                            }
                            break;
                        }
                        paramData += StringBuilderComma("UniqueID" , uniqid);
                        paramData += StringBuilderComma("ID"       , itemid);
                        paramData += StringBuilderComma("Type"     , type);
                        paramData += StringBuilderComma("Value"    , value);
                        paramData += LF;
                    }catch(e){ }
                }
            }
        }
        
                
        //| サーバーサイド  メソッドの呼び出し
        CallServer(paramData, "");
    }catch(e){  
    }
}

function ReceiveServerReturnValue(arg, context){
/*--------------------------------------------------------------------------------------------*/
/*  サーバーサイド[非同期](Return)                                                            */
/*  共通：サーバー側からのReturn処理                                                          */
/*                                                                                            */
/*--------------------------------------------------------------------------------------------*/
    try{
        //| サーバー戻り値[改行区切り]を配列に展開
        var arrObj = arg.split(LF);
        
        //| 配列を連想配列に変換
        for (p = 0; p < arrObj.length; p++){
            var arrProperty = arrObj[p].split(COMMA);
            var hashRow = new Object();
            for (c = 0; c < arrProperty.length; c=c+2){
                hashRow[arrProperty[c]] = arrProperty[c + 1];
            }
            arrObj[p] = hashRow;
        }
        
        //| 対象コントロールに値を設定
        for (p = 0; p < arrObj.length; p++){
            var hashRow = arrObj[p];
            if (hashRow["UniqueID"] != "undefined"){    
                var tarElm = $(hashRow["UniqueID"]);
                switch (hashRow["Type"]){
                case "0":   //Label
                    if ((n = hashRow["UniqueID"].indexOf("lblMsg")) != -1){
                        tarElm.innerHTML = hashRow["Value"]
                        tarElm.style.color  = "red";
                    }else{
                        tarElm.value = hashRow["Value"]
                    }
                    break;
                case "1":   //TextBox
                case "4":   //DateText
                    tarElm.value = hashRow["Value"]
                    break;
                case "2":   //DropDownList
                    for (n=0; n<tarElm.length; n++){
                        if (tarElm.options[n].value == hashRow["Value"]){
                            tarElm.selectedIndex = n;
                            break;
                        }
                    }
                    break;
                case "3":   //CheckBox
                    tarElm.checked = false;
                    if (hashRow["Value"] == "1"){
                        tarElm.checked = true;
                    }
                    break;
                }
            }
        }
        
    }catch(e){  
    }
}

function Count(text,long){
/*--------------------------------------------------------------------------------------------*/
/*  文字数チェック　　　　　　　　　                                                          */
/*  　　　　　　　　　　　　　　　　　                                                        */
/*--------------------------------------------------------------------------------------------*/
	var maxlength = new Number(long); // Change number to your max length.
	if (text.value.length > maxlength){

		//text.value = text.value.substring(0,maxlength);
		alert(" Only " + long + " chars");
		
	}
}

/*--------------------------------------------------------------------------------------------*/
/*  アイコンの操作関連　　　　　　　                                                          */
/*  　　　　　　　　　　　　　　　　　                                                        */
/*--------------------------------------------------------------------------------------------*/
function MM_swapImgRestore() { //v3.0
    var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
}

function MM_preloadImages() { //v3.0
    var d = document; if (d.images) {
        if (!d.MM_p) d.MM_p = new Array();
        var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
            if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; } 
    }
}

function MM_findObj(n, d) { //v3.0
    var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
        d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
    }
    if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
    for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document); return x;
}

function MM_swapImage() { //v3.0
    var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
        if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
}


/*--------------------------------------------------------------------------------------------*/
/*  キー操作              　　　　　                                                          */
/*  　　　　　　　　　　　　　　　　　                                                        */
/*--------------------------------------------------------------------------------------------*/
function onKeyDown() {
    if (event.keyCode == 13) {
        event.keyCode = 9;

    }
}

function onKeyDown_Body() {
    if (event.keyCode == 8) {
        event.keyCode = 0;
    }
}

/*--------------------------------------------------------------------------------------------*/
/*  操作説明起動          　　　　　                                                          */
/*  　　　　　　　　　　　　　　　　　                                                        */
/*--------------------------------------------------------------------------------------------*/
function helpPopUp(loc) {
    w = 450;
    h = 400;
    menubar = "";

    //      if (loc == null) loc = "http://localhost/Accounting/AccPro/Apps/help/操作説明ヘルプ.htm";

    if (loc == null || loc == "") {
        loc = "../../help/help.html";
    }
    else {
        loc = "../../help/" + loc + ".html";
    }



    // Need the var or else IE4 blows up not recognizing editorWin

    var helpWin = window.open(loc, "",
                                "toolbar=yes,location=no,menubar=yes,status=yes,resizable=yes,scrollbars=yes,width=650, height=' + h,top=0,left=0");
    //if( !helpWin.opener )
    //newWin.opener = window;
    helpWin.focus();
    //causing intermittent errors
}

/*--------------------------------------------------------------------------------------------*/
/*  ブラウザの高さを取得  　　　　　                                                          */
/*  　　　　　　　　　　　　　　　　　                                                        */
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

/*--------------------------------------------------------------------------------------------*/
/*  Cookieの取得  　　　　　                                                                   */
/*  12.12.26 UBIQ_SH 　　　　　　　　                                                          */
/*--------------------------------------------------------------------------------------------*/
function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=")
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1
            c_end = document.cookie.indexOf("&", c_start)
            if (c_end == -1) c_end = document.cookie.length
            return unescape(document.cookie.substring(c_start, c_end))
        }
    }
    return ""
}
/*--------------------------------------------------------------------------------------------*/
/*  ReLoad CSS file　　　　                                                                   */
/*  12.12.26 UBIQ_SH 　　　　　　　　                                                          */
/*--------------------------------------------------------------------------------------------*/
function loadCss(filepath, cssid) {
    var cssTag = document.getElementById(cssid);
    var head = document.getElementsByTagName('head').item(0);
    if (cssTag) head.removeChild(cssTag);
    css = document.createElement('link');
    css.href = filepath;
    css.rel = 'stylesheet';
    css.type = 'text/css';
    css.id = 'loadCss';
    head.appendChild(css);
}

/*--------------------------------------------------------------------------------------------*/
/*  窗体最大化      　　　　                                                                   */
/*  12.12.26 UBIQ_SH 　　　　　　　　                                                          */
/*--------------------------------------------------------------------------------------------*/
function autoFit() {
    if (window.screen) {
        var fullWidth = screen.availWidth;
        var fullHeight = screen.availHeight;
        window.moveTo(0, 0);
        window.resizeTo(fullWidth, fullHeight);
    }
} 