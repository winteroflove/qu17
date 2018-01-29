<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteAdd.aspx.cs" Inherits="WebUI.WebManage.Routes.RouteAdd"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加路线</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>
    
    <link href="/WebManage/calender/calendar.css" rel="stylesheet" type="text/css" />
    <script src="/WebManage/calender/calenderPrice.js" type="text/javascript" ></script>
    
    <script type="text/javascript" src="/WebManage/kindsoft/kindeditor.js"></script>
    
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
        
    </script>

<style type="text/css">
    #fileImages div{margin-bottom:10px;}
</style>

</head>
<body>
    <div id="main">
    <h1>
        <a href="RouteList.aspx">路线列表</a><span><b>添加路线</b></span>
    </h1>
    <form class="form-div" action="RouteAdd.aspx?ac=add" enctype="multipart/form-data" method="post" onsubmit="return formRoute(this,'add')">
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
                <input type="text" name="Title" size="60" maxlength="100" />
            </td>
        </tr>
        <tr>
            <td align="right">
                线路价格：
            </td>
            <td>
                <input type="text" name="Price" size="20" maxlength="10" />&nbsp;&nbsp;小孩：<input type="text" name="ChildPrice" size="20" maxlength="10" value="0" />
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
                <div id="ScenicDiv" style="width: 670px;">
                    <span class="red_text">说明:请先选择一个省份或者直辖市</span>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                链接地址：<span>*</span>
            </td>
            <td>
                <div id="locationDiv" style="width: 670px;">
                    
                </div>
            </td>
        </tr>
        <tr id="trBoat">
            <td align="right">
                游船名称：
            </td>
            <td>
                <input type="text" name="BoatName" size="30" maxlength="10" />
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
                <span class="red">(图片大小不能超过1M，支持格式包括 .jpg | .gif | .png ，最佳图尺寸为 500*310px)</span>
                <div id="fileImages">
                    <div><input type="file" name="Image" onchange="CheckImgFile(this)" /></div>
                    <div><input type="file" name="Image" onchange="CheckImgFile(this)" /></div>
                    <div><input type="file" name="Image" onchange="CheckImgFile(this)" /></div>
                </div>
                <a href="javascript:clearFile()">重置已选图片</a>&nbsp;&nbsp;<a onclick="javascript:route_add_file()">添加图片</a>
            </td>
        </tr>
        <tr>
            <td align="right">
                出发地：<span>*</span>
            </td>
            <td>
                <input type="text" name="StartPosition" size="30" value="重庆" maxlength="30" />
            </td>
        </tr>
        <tr>
            <td align="right">
                目的地：<span>*</span>
            </td>
            <td>
                <input type="text" name="Destination" size="30" maxlength="30" />
            </td>
        </tr>
        <tr>
            <td align="right">
                行程天数：<span>*</span>
            </td>
            <td>
                <input type="text" id="RouteTime" name="RouteTime" size="30" maxlength="20" />
                <input type="hidden" id="oldRouteTime" name="oldRouteTime" value="" />
            </td>
        </tr>
        <tr>
            <td align="right">
                提前报名天数：<span>*</span>
            </td>
            <td>
                <input type="text" name="AdvanceDays" size="30" maxlength="20" />
            </td>
        </tr>
        <tr>
            <td align="right">
                交通方式：<span>*</span>
            </td>
            <td>
                <select name="TrafficModel1">
                    <%=trafficModelList%>
                </select>&nbsp;去&nbsp;
                <select name="TrafficModel2">
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
                <input type="hidden" id="DatePrice" name="DatePrice" value="" />
                
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
                <input type="text" name="RouteBright" size="100" maxlength="100" />
            </td>
        </tr>
        <tr>
            <td align="right">
                线路特色：
            </td>
            <td>
                <textarea id="RouteFeature" name="RouteFeature" cols="1" rows="1" style="width: 740px; height: 300px;
                    visibility: hidden;"></textarea>
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
                    visibility: hidden;"></textarea>
                </div>
                <div id="forDays">
                    <div id='routeDetailDiv' >
                        <div class='fieldset xingcheng-by-day' id='day_1'>
                            <dl><dd><b>第1天：<input type="radio" name="rdo_title_1" value="False" checked="checked" onclick="checkTitle(this,1)" />按标题<input class='text' id='route_1_0' name='route_1_0'  style='width:300px;' />
                            <input type="radio" name="rdo_title_1" value="True" onclick="checkTitle(this,1)" />按景点</b></dd></dl>
                            <dl><dt>行程安排：</dt>
                            <dd><div class='add_del_box'>
                            <textarea id='route_1_1' name='route_1_1' style='width:700px;' rows='15'></textarea>
                            </div></dd></dl>
                            <dl class='hotel'><dd>
                            <div class="floatL">早餐：<input id='route_1_2' name='route_1_2' type='checkbox'  /><input class='text text160' id='route_1_6' name='route_1_6' type='text' size='20' /></div>
                            <div class="floatL">中餐：<input id='route_1_3' name='route_1_3' type='checkbox'  /><input class='text text160' id='route_1_7' name='route_1_7' type='text' size='20' /></div>
                            <div class="floatL">晚餐：<input id='route_1_4' name='route_1_4' type='checkbox'  /><input class='text text160' id='route_1_8' name='route_1_8' type='text' size='20' /></div>
                            </dd></dl>
                            <dl><dt>住宿：<input type='text' class='text text160' id='route_1_5' name='route_1_5' value=''/></dt></dl>
                        </div>
                        <div class="add_day">
		                    <a href="#?" onclick="xingcheng_add_day();return false;">+ 添加第<b id="xingcheng-next-day-no">2</b>天行程</a>
		                </div>
		                <span id="sch_day"></span>
                    </div>
                </div>
                <input type="hidden" id="xing_day" name="xing_day" value="1" />
            </td>
        </tr>
        <tr>
            <td align="right">
                费用说明：
            </td>
            <td>
                <textarea id="DescriptionPrice" name="DescriptionPrice" cols="1" rows="1" style="width: 740px; height: 300px;
                    visibility: hidden;"></textarea>
            </td>
        </tr>
        <tr>
            <td align="right">
                预订须知：
            </td>
            <td>
                <textarea id="RouteNotice" name="RouteNotice" cols="1" rows="1" style="width: 740px; height: 300px;
                    visibility: hidden;"></textarea>
            </td>
        </tr>
        <tr>
            <td align="right">
                SEO标题：
            </td>
            <td>
                <textarea name="SeoTitle" rows="2" cols="70"></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                页面关键字：
            </td>
            <td>
                <textarea name="SeoKeywords" rows="4" cols="70"></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                页面描述：
            </td>
            <td>
                <textarea name="SeoDescription" rows="4" cols="70"></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                地接名称：
            </td>
            <td>
                <input type="text" name="SupplierName" size="30" maxlength="20" />
            </td>
        </tr>
        <tr>
            <td align="right">
                地接电话：
            </td>
            <td>
                <input type="text" name="SupplierTel" size="30" maxlength="20" />
            </td>
        </tr>
        <tr>
            <td align="right">
                热门线路：
            </td>
            <td>
                <input name="RecommendHot" type="radio" value="False" checked="checked" />否
                <input name="RecommendHot" type="radio" value="True" />是
            </td>
        </tr>
        <tr>
            <td align="right">
                显示线路：
            </td>
            <td>
                <input name="isDisplay" type="radio" value="False" />否
                <input name="isDisplay" type="radio" value="True" checked="checked" />是
            </td>
        </tr>
        <tr>
            <td align="right">
                线路排序：
            </td>
            <td>
                <input type="text" name="routeOrder" size="20" maxlength="5" value="9999"/>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="2" align="center">
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
    </div>
    <script type="text/javascript">
        $("#trBoat").hide();
    </script>
</body>
</html>
