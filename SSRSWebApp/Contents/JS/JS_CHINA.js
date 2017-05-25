/*|------------------------------------------------------------------------------------------|*/
/*|  JScript ファイル 　                                                                     |*/
/*|  プロジェクト名　：　                                                                    |*/
/*|  システム名　　　：　                                                                    |*/
/*|  機能名　　　　　：　JavaScript共通処理                                                  |*/
/*|  プログラム名    ：　JavaScript共通処理                                                  |*/
/*|  プログラムID  　：　                                                                    |*/
/*|------------------------------------------------------------------------------------------|*/
/*|  [履歴]  　                                                                              |*/
/*|  2008/11/20     Ubiq.LIU      　新規作成                                                 |*/
/*|------------------------------------------------------------------------------------------|*/


/*--------------------------------------------------------------------------------------------*/
/*  DropDownList SelectChange     ADD BY LIU 2008.11.20     　　　　　                        */
/*  selectValue to lable(TextBox)　　　　　　　　　　　                                       */
/*--------------------------------------------------------------------------------------------*/
function ddlSelectChange(lable) {
    lable.value = event.srcElement.value;
}

/*--------------------------------------------------------------------------------------------*/
/*  GridView AllChecked     ADD BY LIU 2008.11.27     　　　　　                              */
/*  tabName = GridView.ID ,chkCol = checkBox.colomsindex　　　　　　　　　　　                */
/*--------------------------------------------------------------------------------------------*/
function CheckAll(tabName, chkCol) {
    objTable = document.getElementById(tabName);
    if (objTable == null)
        return;

    for (i = 1; i < objTable.childNodes[0].childNodes.length; i++) {
        objTable.childNodes[0].childNodes[i].cells[chkCol].firstChild.checked = event.srcElement.checked;
    }
}
/*--------------------------------------------------------------------------------------------*/
/*  Cancel Check Clear GRID  ADD BY LIU 2009.04.02     　　　　　                             */
/*  　　　 NO USE 　　　　　　　                                                              */
/*--------------------------------------------------------------------------------------------*/
function CancelCheck(tabName, chkCol, chkAll) {
     objTable = document.getElementById(tabName);
     if (objTable == null)
         return;
     for (i = 1; i < objTable.childNodes[0].childNodes.length; i++) {
         objTable.childNodes[0].childNodes[i].cells[0].firstChild.checked = false;
     }
     objTable.style.display = 'none';
     chk = document.getElementById(chkAll);
     chk.checked = false;
}

/*--------------------------------------------------------------------------------------------*/
/*  Select Row TextBox Change Color  ADD BY LIU 2009.04.02     　　　　　                     */
/*  　　　  共通　　　　　　　　                                                              */
/*--------------------------------------------------------------------------------------------*/
function frmLoadLocal(tabName)
{ 
	var objTR = null;
	var objTD = null;
    objTable = document.getElementById(tabName);
    if (objTable == null)
         return;
         
    for (i = 0; i < objTable.childNodes[0].childNodes.length; i++)//UPD 20100318 UBIQ-LIU [i=1]->[i=0]
	{
	if(objTable.childNodes[0].childNodes[i].className=="GVSelectedRow")
		{
		objTR = objTable.childNodes[0].childNodes[i];
		}
	} 
	if(objTR==null)
	    return;
	    
	for(i=0;i<objTR.children.length;i++)
	{
		objTD=objTR.children(i);
		
		if(objTD.children.length > 0)
		{
			for(j=0;j<objTD.children.length;j++)
			{
			    if(objTD.children(j).readOnly)
			    {
				objTD.children(j).style.color="white";
				objTD.children(j).style.fontWeight="bold";
				}
			}
		}	
	}
}
var objLastSelectedTR = null;
var objClass = null;
var constColor = "black";

function ClearSelectedGridRow()
{
	var i;
	var j;
	var objTD;
				
	objLastSelectedTR.className = objClass;//"GVRow";
	
	//alert(objTR.children.length);
	//return;
	for(i=0;i<objLastSelectedTR.children.length;i++)
	{
        //objTD=objLastSelectedTR.children(i);
		objTD=objLastSelectedTR.children[i];
		
		objTD.style.color= constColor;
		objTD.style.fontWeight="normal";
				
		if(objTD.children.length > 0)
		{
			for(j=0;j<objTD.children.length;j++)
			{
				objTD.children[j].style.color= constColor;
				objTD.children[j].style.fontWeight="normal";
			}
		}	
	}
	objLastSelectedTR=null;
	//alert(objTD.);
}

function SelectGridRow(obj,hdnindex,no)
{
	var i;
	var j;
	var objTR;
	var objTD;
	
	if(objLastSelectedTR!=null)
	{
		ClearSelectedGridRow();
	}	
	
	objTR=obj;
	
	while(obj.tagName != "TR")
	{
		//if(obj.tagName != "TR")
		objTR=objTR.parentNode;
	}
	objClass=objTR.className;
	constColor = objTR.style.color;
	objTR.className = "GVSelectedRow";
	
	//alert(objTR.children.length);
	//return;
	for(i=0;i<objTR.children.length;i++)
	{
        //objTD=objTR.children(i);
		objTD=objTR.children[i];

		objTD.style.color="white";
		objTD.style.fontWeight="bold";
		
		if(objTD.children.length > 0)
		{
			for(j=0;j<objTD.children.length;j++)
			{
			    if(objTD.children[j].readOnly)
			    {
				objTD.children[j].style.color="white";
				objTD.children[j].style.fontWeight="bold";
				}
			}
		}	
	}
	objHdn = document.getElementById(hdnindex);
	objHdn.value=objTR.children[no].innerText;
	//alert(objHdn.value);
	//alert(WebForm1.txtSelectedValue.value);
	objLastSelectedTR=objTR;
	//alert(objTD.);
}
/*--------------------------------------------------------------------------------------------*/
/*  New Window Open  ADD BY LIU 2009.04.29     　　　　　                                     */
/*  　　　  共通　　　　　　　　                                                              */
/*--------------------------------------------------------------------------------------------*/
function NewWindowOpen(url,name)
{
//strurl=url.toString();
window.open(url);
}
/*--------------------------------------------------------------------------------------------*/
/*  The number of calculation  ADD BY LIU 2009.05.25     　　　　　                           */
/*  　　　  共通　　　　　　　　                                                              */
/*--------------------------------------------------------------------------------------------*/
function NumberOnChange(num1,num2,oper,rtn)
{
    var regS = new RegExp(",","gi");
    a =parseFloat((document.getElementById(num1)).value.replace(regS,""));
    if(isNaN(a))
    {
        a=0;
    }
    b =parseFloat((document.getElementById(num2)).value.replace(regS,""));
    if(isNaN(b))
    {
        b=0;
    }
    switch (oper)
    {
    case '+':
        c=a+b;break;
    case '-':
        c=a-b;break;
    case '*':
        c=a*b;break;
    case '/':
        if(b!=0)
            c=a/b;
        else
            c=0;
    break;
    }
    (document.getElementById(rtn)).value=c.toFixed(2);
}
function NumberKeyEnter(num1,num2,oper,rtn)
{
    if (event.keyCode == 13) 
    {
        NumberOnChange(num1,num2,oper,rtn);
    }
}

/*--------------------------------------------------------------------------------------------*/
/*  Change grid checked row backgroundcolor                                                   */
/*  2013.07.01 for SAT                                                                        */
/*--------------------------------------------------------------------------------------------*/
function CheckedTRbgColor(obj, tr) {
    if (obj.checked)
        tr.style.backgroundColor = '#96c2f1';
    else
        tr.style.backgroundColor = '';
}
//
// format number
//
function NumberFormat(s, n) {
    n = n > 0 && n <= 20 ? n : 2;
    s = parseFloat((s + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";
    var l = s.split(".")[0].split("").reverse(),
   r = s.split(".")[1];
    t = "";
    for (i = 0; i < l.length; i++) {
        t += l[i] + ((i + 1) % 3 == 0 && (i + 1) != l.length ? "," : "");
    }
    return t.split("").reverse().join("") + "." + r;
} 
/// <summary>
/// 文字列の数値[int]への変換
/// </summary>
/// <param name="strValue"></param>
/// <returns></returns>
function StringToInt(strValue) {
    var rtnValue = 0;

    var regS = new RegExp(",", "gi");
    strValue = strValue.replace(regS, "");
    if (strValue == "") {
    }
    else {
        if (isNaN(parseInt(strValue, 10))) {
            //| 数値の時以外の時はとりあえず0をReturn　：　保留
        }
        else {
            strValue = parseInt(strValue, 10);
        }
    }

    return rtnValue;
}

/// <summary>
/// 文字列の数値[int]への変換
/// </summary>
/// <param name="strValue"></param>
/// <returns></returns>
function StringToDouble(strValue) {
    var rtnValue = 0;

    var regS = new RegExp(",", "gi");
    strValue = strValue.replace(regS, "");
    if (strValue == "") {
    }
    else {
        if (isNaN(parseFloat(strValue))) {
            //| 数値の時以外の時はとりあえず0をReturn　：　保留
        }
        else {
            rtnValue = parseFloat(strValue);
        }
    }
    return rtnValue;
}

// 金額の計算
function Calc_Amt(txtQty, txtPrc, txtAmt) {
    var amt = 0;
    var qty = (document.getElementById(txtQty)).value;
    var prc = (document.getElementById(txtPrc)).value;
    if (!qty)
        qty = (document.getElementById(txtQty)).innerHTML.replace(/<.+?>/gim, '');
    if (!prc)
        prc = (document.getElementById(txtPrc)).innerHTML.replace(/<.+?>/gim, '');

    // 金額の計算
    amt = StringToDouble(qty) * StringToDouble(prc);
    amt = NumberFormat(amt, 2);
    //alert(amt);
    (document.getElementById(txtAmt)).value = amt;
}