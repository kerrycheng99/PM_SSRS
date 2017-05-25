/*|------------------------------------------------------------------------------------------|*/
/*|  JScript ファイル 　                                                                     |*/
/*|  プロジェクト名　：　ProductionMaster                                                    |*/
/*|  システム名　　　：　                                                                    |*/
/*|  機能名　　　　　：　JavaScript共通処理                                                  |*/
/*|  プログラム名    ：　JavaScript共通処理                                                  |*/
/*|  プログラムID  　：　RptPopWin                                                           |*/
/*|------------------------------------------------------------------------------------------|*/
/*|  [履歴]  　                                                                              |*/
/*|  2017/04/05     Ubiq_SH  　新規作成                                                      |*/
/*|------------------------------------------------------------------------------------------|*/

//
//[layer.js] Shortcut function
//Usage:
//  <script src="/jquery/1.12.3/jquery.min.js"></script>
//  <script src="/layer/layer.js"></script>
//  <script src="/RptPopWinMulti.js"></script>
//
//   jRptPopWin( rptID, [title] )

(function ($) {
    jRptPopWin = function (p_rptDomID, p_title) {
        if (p_title == null) p_title = 'SSRS Report';
        var blankW = 300;
        var blankH = 150;
        var maxW = 1110;
        var rptW = ((($(window).width() - blankW) > maxW) ? maxW : ($(window).width() - blankW)) + "px";  //账票窗口的宽度
        var rptH = ($(window).height() - blankH) + "px"; //账票窗口的高度
        var isShade = ($('div').is('.layui-layer-shade')) ? 0 : 0.3;

        layer.open({
            title: [p_title, 'height:38px;font-weight:bold;color: #E70000;'],
            type: 1,                            //type：0（信息框，默认）1（页面层）2（iframe层）3（加载层）4（tips层）
            maxmin: true,                       //最大最小化
            area: [rptW, rptH],                 //定义宽高
            offset: [Math.random() * blankH * 0.5
                , Math.random() * blankW * 0.5],//定义top、left坐标
            shade: isShade,                     //遮罩层
            content: $("#" + p_rptDomID),       //内容
            id: 'rptBox_' + p_rptDomID,
            zIndex: layer.zIndex,
            success: function (layero) {
                layer.setTop(layero);           //当前窗口置顶
                //$("#rptBox_" + p_rptDomID).css({ overflow: "hidden" });
                $("#rptBox_" + p_rptDomID).css({ height: "auto", background: "#fff", overflow: "hidden" });
            },
            end: function () {
                if ($('div').is('.layui-layer') && !$('div').is('.layui-layer-shade')) {
                    var bgObj = $('<div></div>');
                    bgObj.attr('id', 'bgDiv'); //设置ID
                    bgObj.addClass('layui-layer-shade');
                    bgObj.css({ zIndex: "19891014", background: "#000", opacity: "0.3", filter: "alpha(opacity=30)" });
                    $('body').append(bgObj);
                }
                if ($('.layui-layer').length <= 0) {
                    $("#bgDiv").remove();
                }
            }
        });
    };
})(jQuery);
