<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteEdit.aspx.cs" Inherits="WebUI.WebManage.Routes.RouteEdit"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑路线</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

    <script type="text/javascript" src="/WebManage/kindsoft/kindeditor.js"></script>
    <link href="/WebManage/calender/calendar.css" rel="stylesheet" type="text/css" />
    <script src="/WebManage/calender/calenderPrice.js" type="text/javascript" ></script>
    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        KindEditor.ready(function(K) {
            K.create('#DescriptionRoute', {
                uploadJson: '/WebManage/kindsoft/upload_json_route.ashx',
                fileManagerJson: '/WebManage/kindsoft/file_manager_json.ashx',
                allowFileManager: true
            });
        });
        KindEditor.ready(function(K) {
            K.create('#DescriptionPrice', {
            uploadJson: '/WebManage/kindsoft/upload_json_route.ashx',
                fileManagerJson: '/WebManage/kindsoft/file_manager_json.ashx',
                allowFileManager: true
            });
        });
        KindEditor.ready(function(K) {
            K.create('#RouteFeature', {
            uploadJson: '/WebManage/kindsoft/upload_json_route.ashx',
                fileManagerJson: '/WebManage/kindsoft/file_manager_json.ashx',
                allowFileManager: true
            });
        });
        KindEditor.ready(function(K) {
            K.create('#RouteNotice', {
            uploadJson: '/WebManage/kindsoft/upload_json_route.ashx',
                fileManagerJson: '/WebManage/kindsoft/file_manager_json.ashx',
                allowFileManager: true
            });
        });

        KindEditor.ready(function(K) {
            K.create('#routeDetailDiv textarea', {
            uploadJson: '/WebManage/kindsoft/upload_json_route.ashx',
                fileManagerJson: '/WebManage/kindsoft/file_manager_json.ashx',
                allowFileManager: true
            });
        });
    </script>

<style type="text/css">
    #fileImages div{margin-bottom:10px;}
    #fileImages img{vertical-align:middle;margin-bottom:10px;}
</style>

</head>
<body id="main">
    <h1>
        <span><b>编辑路线</b></span><a href="RouteList.aspx">路线列表</a>
    </h1>
    <form class="form-div" action="RouteEdit.aspx?ac=edit" enctype="multipart/form-data" method="post" onsubmit="return formRoute(this,'edit')">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="120" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">
                标题：<span>*</span>
            </td>
            <td>
                <input type="text" name="Title" size="60" maxlength="100" value="<%=title %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                线路价格：
            </td>
            <td>
                <input type="text" name="Price" size="20" maxlength="10" value="<%=price %>" />&nbsp;&nbsp;小孩：<input type="text" name="ChildPrice" size="20" maxlength="10" value="<%=childPrice %>" />
                <input id="Price_Hidden" name="Price_Hidden" type="hidden" value="<%=price %>" />
                <input id="ChildPrice_Hidden" name="ChildPrice_Hidden" type="hidden" value="<%=childPrice %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                目的地省市：<span>*</span>
            </td>
            <td>
                <select name="routeParentID" id="routeParentID" onchange="updateProvince()">
                    <option value="1">==国内旅游==</option>
                    <option value="2">==出境旅游==</option>
                    <option value="3">==三峡旅游==</option>
                </select>
                <div id="Province" style="width: 670px;"><%=routeClassList %></div>
                
                <span class="red_text">说明:最多可选择五个省份</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                途经景点：<span>*</span>
            </td>
            <td>
                <div id="ScenicDiv" style="width: 670px;"><%=routeSubClassList%></div>
            </td>
        </tr>
        <tr>
            <td align="right">
                链接地址：<span>*</span>
            </td>
            <td>
                <div id="locationDiv" style="width: 670px;">
                    <%=locationids %>
                </div>
            </td>
        </tr>
        <tr id="trBoat">
            <td align="right">
                游船名称：
            </td>
            <td>
                <input type="text" name="BoatName" size="30" maxlength="10" value="<%=boatName %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                所属主题：
            </td>
            <td>
                <div style="width: 670px;"><%=themeList%></div>
            </td>
        </tr>
        <tr>
            <td align="right">
                图片：
            </td>
            <td>
                <span class="red">
                图片大小不能超过1M，支持格式包括 .jpg | .gif | .png ，最佳图尺寸为 500*310px<br />
                不修改请留空，选择的新图片将会覆盖后面的旧图片。
                </span>
                <div id="fileImages">
                    <%=routeImage %>
                </div>
                <a href="javascript:clearFile()">重置已选图片</a>&nbsp;&nbsp;<a onclick="javascript:route_add_file()">添加图片</a>
                <input id="Hidden1" name="Image_Hidden" type="hidden" value="<%=image %>" />
                <input id="Hidden2" name="appImage_Hidden" type="hidden" value="<%=appImage %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                出发地：<span>*</span>
            </td>
            <td>
                <input type="text" name="StartPosition" size="60" maxlength="30" value="<%=startPosition %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                目的地：<span>*</span>
            </td>
            <td>
                <input type="text" name="Destination" size="60" maxlength="30" value="<%=destination %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                行程天数：<span>*</span>
            </td>
            <td>
                <input type="text" id="RouteTime" name="RouteTime" size="60" maxlength="20" value="<%=routeTime %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                提前报名天数：<span>*</span>
            </td>
            <td>
                <input type="text" name="AdvanceDays" size="30" maxlength="20" value="<%=advanceDays %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                交通方式：<span>*</span>
            </td>
            <td>
                <select name="TrafficModel1" id="TrafficModel1">
                    <%=trafficModelList%>
                </select>&nbsp;去&nbsp;
                <select name="TrafficModel2" id="TrafficModel2">
                    <%=trafficModelList%>
                </select>&nbsp;回
            </td>
        </tr>
        <tr>
            <td align="right">
                发团时间：<span>*</span>
            </td>
            <td>
            	<script type="text/javascript">
            	    var type_id = 1;
            	    var price = 0;
            	    var price_d = '0';
            	    var price_child_d = '0';
            	    var day_arr = new Array();
            	    var day_arr_child = [];
	    	    </script>
    	        <script src="/WebManage/js/line_price.js" type="text/javascript" charset="GBK"></script>
                <script src="/WebManage/js/calendar_ajax.js" type="text/javascript"></script>
                <input name="DateType" type="radio" value="False" checked="checked" onclick="setPriceEveryDay()" />天天发团
                <input name="DateType" type="radio" value="True" onclick="setPriceByDay()" />按期发团
                <input type="hidden" id="DatePrice" name="DatePrice" value="<%=datePrice %>" />
                
                <div id="datePriceLayer" style="margin-top:10px;display:none;">
                    <script type="text/javascript">                        //调用函数
                        document.writeln("<div id='calenderdiv'>日历加载中...</div>");
                        calender("", "");
                    </script>
                </div>
                
                <div id="price_layer" style="display:none;">
                    <!--form action="" name="price_layer"-->
                        <div class="baojia"><a href="#?" onclick="gt('price_layer').style.display='none'"></a><input type="text" class="rq" value="#date#" name="date" id="price_date" readonly=readonly />报价</div>
                        <p>成人价<input type="text" class="text text40" name="price_d" id="price_d" value="" size="3" onKeypress="if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;"/> 儿童价 <input type="text" class="text text40" name="price_child_d" id="price_child_d" value="" size="3" onKeypress="if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;"/></p>
                        <div class="ok"><input type="button" class="button" name="Submit" value="确定保存" onclick="ajax_price(this.form)" /></div>
                    <!--/form-->
                </div>
                <div class="setprice">
                    <p>指定时间段：<input class="Wdate" type="text" name="starttime" id="starttime" readonly="readonly" onclick="WdatePicker()" size="12"/>
                    至：<input class="Wdate" type="text" name="enftime" id="endtime" readonly="readonly" onclick="WdatePicker()" size="12"/></p>
                    <p><input type="checkbox" name="week_select" value="0" checked="checked" />周日
                       <input type="checkbox" name="week_select" value="1" checked="checked" />周一
                       <input type="checkbox" name="week_select" value="2" checked="checked" />周二
                       <input type="checkbox" name="week_select" value="3" checked="checked" />周三
                       <input type="checkbox" name="week_select" value="4" checked="checked" />周四
                       <input type="checkbox" name="week_select" value="5" checked="checked" />周五
                       <input type="checkbox" name="week_select" value="6" checked="checked" />周六
                    </p>
                    <p>成人价格：<input type="text" name="aprice" id="aprice" size="5" maxlength="6" />
                    儿童价格：<input type="text" name="cprice" id="cprice" size="5" maxlength="6" /></p>
                    <p><input type='button' class='button' value='确定' onclick='UpdateRoutePrice()' />
                    <input type='button' class='button' value='清除全部' onclick='ajax_del_all()' /></p>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                线路亮点：
            </td>
            <td>
                <input type="text" name="RouteBright" size="100" maxlength="100" value="<%=bright %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                线路特色：
            </td>
            <td>
                <textarea id="RouteFeature" name="RouteFeature" cols="1" rows="1" style="width: 740px; height: 400px;
                    visibility: hidden;"><%=routeFeature %></textarea>
            </td>
        </tr>
        <tr>
            <td align="right">
                线路描述：
            </td>
            <td>
                <input name="DetailType" type="radio" value="False" checked="checked" onclick="javascript:document.getElementById('forDays').style.display='none';document.getElementById('notForDays').style.display='block';" />可视编辑
                <input name="DetailType" type="radio" value="True" onclick="checkDays(this)" />按天编辑
                <div id="notForDays"><textarea id="DescriptionRoute" name="DescriptionRoute" cols="1" rows="1" style="width: 740px; height: 400px;
                    visibility: hidden;"><%=descriptionRoute%></textarea>
                </div>
                <div id="forDays">
                    <div id='routeDetailDiv'>
                        <%=routeDetails %>
                        <div class="add_day">
		                    <a href="#?" onclick="xingcheng_add_day();return false;">+ 添加第<b id="xingcheng-next-day-no"><%=Convert.ToInt32(routeTime)+1 %></b>天行程</a>
		                </div>
		                <span id="sch_day"></span>
                    </div>
                </div>
                <input type="hidden" name="DetailType_Hidden" id="DetailType_Hidden" value="<%=detailType %>" />
                <input type="hidden" id="xing_day" name="xing_day" value="<%=(detailType)?routeTime:"1" %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                费用说明：
            </td>
            <td>
                <textarea id="DescriptionPrice" name="DescriptionPrice" cols="1" rows="1" style="width: 740px; height: 400px;
                    visibility: hidden;"><%=descriptionPrice%></textarea>
            </td>
        </tr>
        <tr>
            <td align="right">
                预订须知：
            </td>
            <td>
                <textarea id="RouteNotice" name="RouteNotice" cols="1" rows="1" style="width: 740px; height: 400px;
                    visibility: hidden;"><%=routeNotice %></textarea>
            </td>
        </tr>
        <tr>
            <td align="right">
                SEO标题：
            </td>
            <td>
                <textarea name="SeoTitle" rows="2" cols="70"><%=seoTitle %></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                页面关键字：
            </td>
            <td>
                <textarea name="SeoKeywords" rows="4" cols="70"><%=seoKeywords %></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                页面描述：
            </td>
            <td>
                <textarea name="SeoDescription" rows="4" cols="70"><%=seoDescription %></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                地接名称：
            </td>
            <td>
                <input type="text" name="SupplierName" size="30" maxlength="20" value="<%=supplierName %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                地接电话：
            </td>
            <td>
                <input type="text" name="SupplierTel" size="30" maxlength="20" value="<%=supplierTel %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                热门线路：
            </td>
            <td>
                <input name="RecommendHot" id="RecommendHot" type="radio" value="False" checked="checked" />否
                <input name="RecommendHot" type="radio" value="True" />是
            </td>
        </tr>
        <tr>
            <td align="right">
                显示线路：
            </td>
            <td>
                <input name="isDisplay" id="isDisplay" type="radio" value="False" />否
                <input name="isDisplay" id="isDisplay" type="radio" value="True" checked="checked" />是
            </td>
        </tr>
        <tr>
            <td align="right">
                线路排序：
            </td>
            <td>
                <input type="text" name="routeOrder" size="20" maxlength="5" value="<%=routeOrder %>" />
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="2" align="center">
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                    <input type="hidden" name="ID" value="<%=routeId %>" />
                    <input type="hidden" name="ViewCount" value="<%=viewCount %>" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>

    <script type="text/javascript">
        //var themeID = '<%=themeID %>';
        //document.getElementById("ThemeID").value = themeID;
        
        var parentID = '<%=routeParentId %>';
        document.getElementById("routeParentID").value = parentID;
        if(parentID == '3') $("#trBoat").show();
        else $("#trBoat").hide();
        
        var trafficModel1 = '<%=trafficModel1 %>';
        var trafficModel2 = '<%=trafficModel2 %>';
        document.getElementById("TrafficModel1").value = trafficModel1;
        document.getElementById("TrafficModel2").value = trafficModel2;
        
        document.getElementsByName("RecommendHot")[<%=recommendHot?1:0%>].checked = true;
        document.getElementsByName("isDisplay")[<%=isdisplay?1:0%>].checked = true;
        document.getElementsByName("DetailType")[<%=detailType?1:0%>].checked = true;
        document.getElementsByName("DateType")[<%=dateType?1:0%>].checked = true;
        
        if(document.getElementsByName("DateType")[1].checked) {
           document.getElementById("datePriceLayer").style.display='block';
           $(".setprice").show();
        }
        if(document.getElementsByName("DetailType")[1].checked) {
           document.getElementById("notForDays").style.display = 'none';
           document.getElementById("forDays").style.display = 'block';
           //checkDays(this);
        }
    </script>

</body>
</html>
