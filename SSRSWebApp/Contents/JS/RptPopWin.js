/*|------------------------------------------------------------------------------------------|*/
/*|  JScript ファイル 　                                                                     |*/
/*|  プロジェクト名　：　ProductionMaster                                                    |*/
/*|  システム名　　　：　                                                                    |*/
/*|  機能名　　　　　：　JavaScript共通処理                                                  |*/
/*|  プログラム名    ：　JavaScript共通処理                                                  |*/
/*|  プログラムID  　：　RptPopWin                                                           |*/
/*|------------------------------------------------------------------------------------------|*/
/*|  [履歴]  　                                                                              |*/
/*|  2017/03/14     Ubiq_SH  　新規作成                                                      |*/
/*|------------------------------------------------------------------------------------------|*/

function showRptPopWin(str) {
    //根据自己需求注意宽度和高度的调整
    var iWidth = document.documentElement.clientWidth;
    var iHeight = document.documentElement.clientHeight;
    var rptw, rpth, bordercolor;
    rptw = iWidth - 200; //账票窗口的宽度
    rpth = iHeight - 100; //账票口的高度
    titleheight = 25 //账票口标题高度
    bordercolor = "#d5d5d5"; //账票口的边框颜色
    titlecolor = "#f7f7f7"; //账票口的标题颜色


    //账票遮罩层
    var bgObj = document.createElement("div");
    bgObj.setAttribute("id", "bgObj"); //设置ID
    bgObj.style.background = "#000000";
    bgObj.style.width = "100%";
    bgObj.style.height = "100%";
    bgObj.style.position = "fixed";
    bgObj.style.top = "0";
    bgObj.style.left = "0";
    bgObj.style.zIndex = "1001";
    bgObj.style.opacity = "0.6";
    bgObj.style.filter = "Alpha(opacity=60)";
    document.body.appendChild(bgObj);

    //账票弹出窗口
    var rptObj = document.createElement("div");
    rptObj.setAttribute("id", "rptDiv"); //可以用bgObj.id="rptDiv"的方法，是为div指定属性值
    //rptObj.setAttribute("align", "center"); //为div的align赋值
    rptObj.style.background = "white"; //背景颜色为白色
    rptObj.style.border = "5px solid " + bordercolor; //边框属性，颜色在上面已经赋值
    rptObj.style.position = "absolute"; //绝对定位
    rptObj.style.left = (iWidth - rptw) / 2 + "px"; //从左侧开始位置
    rptObj.style.top = (iHeight - rpth) / 2 + "px"; //从上部开始位置
    rptObj.style.font = "12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif"; //字体属性
    rptObj.style.width = rptw + "px"; //提示框的宽(上面定义过)
    rptObj.style.height = rpth + "px"; //提示框的高(上面定义过)
    //rptObj.style.textAlign = "center"; //文本位置属性，居中。
    rptObj.style.lineHeight = "25px"; //行间距
    rptObj.style.zIndex = "1002"; //层的z轴位置
    document.body.appendChild(rptObj);

    //账票弹出窗口标题区
    var title = document.createElement("div"); //创建一个标题对象
    title.setAttribute("id", "rptTitle"); //为标题对象填加id
    title.style.cssText = "position:relative; margin-left:500px; height:33px;border:none;cursor:move;"
    title.style.zIndex = "1000";
    rptObj.appendChild(title); //在弹出窗口中增加标题栏
    //账票标题区关闭按钮
    var closebtn = document.createElement("div"); //创建一个标题对象
    closebtn.setAttribute("id", "rptClose"); //为标题对象填加id
    closebtn.style.cssText = "position:relative;float:right;margin-top:8px;margin-right:8px !important;margin-right:1px; width:14px; height:14px;border:none; background:url('../../Contents/Image/BackGround/popclose.gif') no-repeat 3px center; cursor:pointer;"
    closebtn.style.zIndex = "1000";
    closebtn.onclick = function () { closeDiv(); }// 绑定关闭事件
    closebtn.onmouseover = function () { closebtn.style.backgroundPosition = "right 0"; }
    closebtn.onmouseout = function () { closebtn.style.backgroundPosition = "3px 0"; }
    title.appendChild(closebtn); //在标题栏中增加关闭按钮

    // 账票弹出窗口内容区
    var rpt = document.getElementById("rptContent");
    rpt.style.display = "block";
    rpt.style.position = "absolute";
    rpt.style.left = "0px"; 
    rpt.style.top = "0px"; 
    rpt.style.width = "100%"; 
    rpt.style.height = "100%"; 
    rptObj.appendChild(rpt); //在弹出窗口中增加账票


    //标题栏设置窗口可移动
    var posX;
    var posY;
    title.onmousedown = function (e) {
        if (!e) e = window.event; //IE
        posX = e.clientX - parseInt(rptObj.style.left);
        posY = e.clientY - parseInt(rptObj.style.top);
        document.onmousemove = mousemove;
    }
    document.onmouseup = function () {
        document.onmousemove = null;
    }
    function mousemove(ev) {
        if (ev == null) ev = window.event; //IEs
        rptObj.style.left = (ev.clientX - posX) + "px";
        rptObj.style.top = (ev.clientY - posY) + "px";
    }
}

//添加关闭功能
function closeDiv() {
    var rptTitelObject = document.getElementById("rptDiv");
    document.body.removeChild(rptTitelObject);
    var bgObj = document.getElementById("bgObj");
    document.body.removeChild(bgObj);
}