var Mdate = nowDate.getFullYear() + "-" + (nowDate.getMonth() + 1) + "-" + nowDate.getDate();

function event_get(e){return e||window.event;}
function mouseX(event)
{
    return event.pageX
	||(event.clientX+
	   (document.documentElement.scrollLeft||document.body.scrollLeft)
	   );
}

function mouseY(event)
{
    return event.pageY
	||(event.clientY+
	   (document.documentElement.scrollTop||document.body.scrollTop)
	   );
}

function EV_GetMouseXPos(e)
{
    var doc = window.document;
    var body = doc.documentElement ? doc.documentElement : doc.body;
    return is_ie ? (e.x + body.scrollLeft) : e.pageX;
}
function gt(objID) {
    return document.getElementById(objID);
}
function getposition(obj) {
    var r = new Array();
    
    r['x'] = obj.offsetLeft;
    r['y'] = obj.offsetTop;
    
    while(obj = obj.offsetParent) 
    {
        r['x'] += obj.offsetLeft;
        r['y'] += obj.offsetTop;
    }
    return r;
}

function show1(e, obj) {

    var p = (typeof(day_arr[obj]) == 'undefined') ? price_d : day_arr[obj];
    var p_child = (typeof (day_arr_child[obj]) == 'undefined') ? price_child_d : day_arr_child[obj];

    document.getElementById("price_date").value = obj;
    document.getElementById("price_d").value = p;
    document.getElementById("price_child_d").value = p_child;
    
    r = getposition(gt(obj));
    r2 = getposition(gt('main'));
    
    var e = event_get(e);
    var el = gt('price_layer');

    var x = r['x']-r2['x']-130;
    var y = r['y']-r2['y']-80;

    el.style.position = "absolute";
    el.style.left = x+"px";
    el.style.top = y+"px";
    el.style.display = "block";

}
function ajax_del_all() {
    if (confirm('您此次操作将清除所有报价，请确认？')) {
        var datePrice = document.getElementById("DatePrice").value;
        var strPrice = datePrice.split('|');
        var countOPrice = strPrice.length;

        for (var n = 0; n < countOPrice; n++) {
            var strODate = strPrice[n].split(',')[0];
            show_style(strODate, 0, 0);
        }

        document.getElementById("DatePrice").value = "";
    }
}

function ajax_del(price_date) {
    var datePrice = document.getElementById("DatePrice").value;
    //alert(datePrice);
    
    var startPlace = datePrice.indexOf(price_date+",");
    var firstPrice = datePrice.substring(0, startPlace);
    
    var lastPrice = datePrice.substring(startPlace, datePrice.length);
    lastPrice = lastPrice.substring(lastPrice.indexOf("|") + 1, lastPrice.length);
    
    document.getElementById("DatePrice").value = firstPrice + lastPrice + "";

    //alert(document.getElementById("DatePrice").value);
    
    show_style(price_date, 0, 0);
}

function ajax_price(theform){

    var price_date = theform.date.value;
    var price_d = theform.price_d.value;
    var price_child_d = theform.price_child_d.value;
    if (price_child_d == "" || !is_int(price_child_d)) price_child_d = 0;
    if (!is_int(price_d)) { alert("价格必须为正整数"); return false; }
    var nowDatePrice = document.getElementById("DatePrice").value;

    if (nowDatePrice.indexOf(price_date+',') < 0 ) {
        document.getElementById("DatePrice").value += price_date + "," + price_d + "," + price_child_d + "|";
    }
    else {
        var startPlace = nowDatePrice.indexOf(price_date);
        var firstPrice = nowDatePrice.substring(0, startPlace);

        var lastPrice = nowDatePrice.substring(startPlace, nowDatePrice.length);
        lastPrice = lastPrice.substring(lastPrice.indexOf("|") + 1, lastPrice.length);

        document.getElementById("DatePrice").value = firstPrice + price_date + "," + price_d + "," + price_child_d + "|" + lastPrice;
    }
    //alert(document.getElementById("DatePrice").value);
    /*params = "todo=price&line_id="+line_id+"&type_id="+type_id+"&price_date="+price_date+"&price_d="+price_d+"&price_child_d="+price_child_d;
    var url = 'http://'+httphost+script_name+params;

    new ajax.$x(url,deal_price);*/
    //alert(document.getElementById("DatePrice").value);
    deal_price2(theform);
}

function show_style(price_date, price_d, price_child_d) {
    var obPrice = gt(price_date);
    if (obPrice == null) return;
        var str = gt(price_date).innerHTML;
        arr = price_date.split('-');
        if(!arr[2])alert('出错');
        var day = arr[2];
        if(day.substr(0,1)==0)day = day.substr(1);
           
        if(price_d > 0){
            
            //把值覆给数组
            day_arr_child[price_date] = price_child_d;
            day_arr[price_date] = price_d;            
            
            gt(price_date).className = 'special';
            //str = '<em style=\'float:right;\' onclick="ajax_del(\''+price_date+'\')" title="删除此天价格"><img src=\'../css/images/x.png\'></img></em>';
            str = '<a style=\'float:left; width:100%;\'>';
            str += '<em  style=\'color:red;float:left;\' onclick="show1(event,\'' + price_date + '\')">' + day + '</em>';
            title = '成人价：'+price_d+'元';
            if(price_child_d) title += "\n"+'儿童价：'+price_child_d+'元';
            str += '<em style=\'float:right; \' onclick="ajax_del(\'' + price_date + '\')" title="删除此天价格"><img src=\'../css/images/x.png\'></img></em>';
            str += '<br/><em onclick="show1(event,\'' + price_date + '\')" class="price" title="' + title + '">' + price_d + '元';
            str += '</em></a>';
        }else{
            
            //把值覆给数组
            delete day_arr_child[price_date] ;
            delete day_arr[price_date];

            if (checkdate(Mdate, price_date)) {
                str = "<a onclick=\"show1(event,'" + price_date + "')\"><em style='color:red;'>" + day + "</em></a>";
            }
            else {
                str = '<em>' + day + '</em>';
            }
            
            gt(price_date).className = 'normal';
        }
        //alert(str);
        gt(price_date).innerHTML = str;
}
function deal_price2(theform) {
    var price_date = theform.date.value;
    var price_d = theform.price_d.value;
    var price_child_d = theform.price_child_d.value;
    //在月历上加上样式及价格
    show_style(price_date, price_d, price_child_d);
    gt("price_layer").style.display = 'none';

}
function deal_price(){
    //var reqText = this.req.responseText;
    //if(reqText.substr(0,2) == 'OK'){
	    var theform = document.price_layer;
        var price_date = theform.date.value;
        var price_d = theform.price_d.value;
        var price_child_d = theform.price_child_d.value;
        
        //在月历上加上样式及价格
        show_style(price_date,price_d,price_child_d);
        gt("price_layer").style.display = 'none';
		/*如果是指定日期且第一天
		if(reqText.substr(2,2) == 'FI'){
			jQuery("#group_price_d_"+type_id).html(price_d + "&nbsp;<p></p>");
			jQuery("#group_price_child_d_"+type_id).html(price_child_d + "&nbsp;<p></p>");
		}
    }else{
        alert(reqText);
    }*/
}

function deal_price_del(price_date){
    var reqText = this.req.responseText;
    if(reqText.substr(0,2) == 'OK'){
        var theform = document.price_layer;
        var price_date = theform.date.value;
        //在月历上删除样式及价格
        show_style(price_date,0);
    }else{
        alert(reqText);
    }
}

function ajax_between(tform){
    var from_date = tform.from_date.value;
    var end_date = tform.end_date.value;
	var price_cncn = tform.price_cncn_c.value;
	var price_cncn_child = tform.price_cncn_child_c.value;
	if(is_int(price_cncn) == false){alert("欣欣优惠价必须为正整数");return false;}
	if(parseInt(price_cncn) > parseInt(price) && parseInt(price) != 0){
		alert("欣欣优惠价必须小于门市价");return false;
	}	
    params = "todo=between&line_id="+line_id+"&type_id="+type_id+"&from_date="+from_date+"&end_date="+end_date +"&price_cncn="+price_cncn +"&price_cncn_child="+price_cncn_child;
    var url = 'http://'+httphost+script_name+params;
    new ajax.$x(url,deal_weekend);        
}
function weekend(tform){
    var weekday = tform.weekday;
	var price_cncn = tform.price_cncn_c.value;
	var price_cncn_child = tform.price_cncn_child_c.value;
    var str = str2 = '';
	if(is_int(price_cncn)  == false){alert("欣欣优惠价必须为正整数");return false;}	
	if(parseInt(price_cncn) > parseInt(price) && parseInt(price) != 0){
		alert("欣欣优惠价必须小于门市价");return false;
	}
    //var arr_weekname = ['日','一','二','三','四','五','六'];
    for(i=0;i<7;i++){
        if(weekday[i].checked){
            str += ','+ weekday[i].value;    
            //str2 += '、周'+arr_weekname[i];
        }
    }
    if(str == ''){
        alert("请选择！");
        return;
    }
    //str2 = str2.substr(1);
    //str2 = "您确认要添加所有的"+str2+"日为指定日期吗？其它日期的指定报价将会被清空！";
    
    //找下是否有数据
        var arr_td = document.getElementsByTagName("td");
        var td_no = arr_td.length;
        has_price = 0;
        Outer:
        for(i=0;i<td_no;i++){
            price_date = arr_td[i].getAttribute('id');
            if(day_arr[price_date]){
                has_price = 1;break Outer;
            }
        }
    var need_update = 0;
    if(has_price){
        str2 = '此次操作将清空之前所有的指定日期报价，将无法恢复，请确认';
        if(confirm(str2)){
            need_update = 1;
        }
    }else{
        need_update = 1;
    }
    

    if(need_update){
        params = "todo=weekday&line_id="+line_id+"&type_id="+type_id+"&weekday="+str+"&price_cncn="+price_cncn +"&price_cncn_child="+price_cncn_child;
        var url = 'http://'+httphost+script_name+params;
        new ajax.$x(url,deal_weekend);    
    }
}

function deal_weekend(){
    var reqText = this.req.responseText;
        if(reqText.substr(2,1) == '1'){
			price_d = document.getElementsByName("price_cncn_c")[0].value;
			price_child_d = document.getElementsByName("price_cncn_child_c")[0].value;		
		}else if(reqText.substr(2,1) == '2'){
			price_d = document.getElementsByName("price_cncn_c")[1].value;
			price_child_d = document.getElementsByName("price_cncn_child_c")[1].value;		
		}
    if(reqText.substr(0,2) == 'OK'){
        reqText = reqText.substr(4);
        var has_date , del_date;
        var tmp_arr = reqText.split('|');    
        has_date = tmp_arr[0];
        if(tmp_arr[1]) del_date = tmp_arr[1];
        
        //在月历上显示样式及价格
        arr_date = has_date.split(',');
        for(i=arr_date.length-1;i>=0;i--){
            show_style(arr_date[i],price_d,price_child_d);
        }
        if(del_date){
        arr_date = del_date.split(',');
        for(i=arr_date.length-1;i>=0;i--){
            show_style(arr_date[i],0);
        }        
        }
    }else{
        if(reqText){
            alert(reqText);
        }
    }
}
function all_clear(){
    if(confirm('您此次操作将清除所有选中的日期及报价，请确认？')){
        params = "todo=all_clear&line_id="+line_id+"&type_id="+type_id;
        var url = 'http://'+httphost+script_name+params;
        //alert(url);
        new ajax.$x(url,deal_all_clear);
    }
}

function deal_all_clear(){
    var reqText = this.req.responseText;
    if(reqText.substr(0,2) == 'OK'){
        reqText = reqText.substr(2);
        //在月历上删除所有样式及价格
        var arr_td = document.getElementsByTagName("td");
        var td_no = arr_td.length;

        for(i=0;i<td_no;i++){
            if(price_date = arr_td[i].getAttribute('id')){
                show_style(price_date,0);
            }
        }
    }else{
        alert(reqText);
    }
}
function is_int(str){
	//var r = /^[0-9]*[1-9][0-9]*$/;
    var r = /^[1-9]*[1-9][0-9]*$/;
	if(r.test(str) == false){
        return false;
    }
    return true;
}
function checkDays(f) {
    //alert(document.getElementById("RouteTime"));
    var numStr = document.getElementById("RouteTime").value;

    if (numStr == null || numStr == "") {
        document.getElementsByName("DetailType")[0].checked = true;
        alert("请输入行程天数!");
        return;
    }

    if (is_int(numStr)) {
        document.getElementById('notForDays').style.display = 'none';
        document.getElementById('forDays').style.display = 'block';
        
        updateRouteTime();
    }
    else {
        document.getElementsByName("DetailType")[0].checked = true;
        alert("行程天数请输入正整数!");
        f.RouteTime.focus();
    }

}

function callRouteDetail(i,dayNum) {
    var str = "";
    if (dayNum >= i) {
        for (; i <= dayNum; i++) {
            str += "<div class='fieldset xingcheng-by-day' id='day_" + i + "'>";
            str += "<dl><dd><b>第" + i + "天：<input class='text text380' id='route_" + i + "_0' name='route_" + i + "_0'  style='width:480px;' rows='1' /></b></dd></dl>";
            str += "<dl><dt>行程安排：</dt>";
            str += "<dd><div class='add_del_box'>";
            str += "<textarea id='route_" + i + "_1' name='route_" + i + "_1' style='width:620px;' rows='12'></textarea>";
            str += "</div></dd></dl>";
            str += "<dl class='hotel'><dd>";
            str += "<label>早餐：<input id='route_" + i + "_2' name='route_" + i + "_2' type='checkbox'  /><input class='text text160' id='route_" + i + "_6' name='route_" + i + "_6' type='text' size='20' /></label>";
            str += "<label>中餐：<input id='route_" + i + "_3' name='route_" + i + "_3' type='checkbox'  /><input class='text text160' id='route_" + i + "_7' name='route_" + i + "_7' type='text' size='20' /></label>";
            str += "<label>晚餐：<input id='route_" + i + "_4' name='route_" + i + "_4' type='checkbox'  /><input class='text text160' id='route_" + i + "_8' name='route_" + i + "_8' type='text' size='20' /></label>";
            str += "</dd></dl>";
            str += "<dl><dt>住宿：<input type='text' class='text text160' id='route_" + i + "_5' name='route_" + i + "_5' value=''/></dt></dl></div>";
        }

        document.getElementById("routeDetailDiv").innerHTML += str;
    }
    else {
        var currntDetail = document.getElementById("routeDetailDiv").innerHTML;
        var nowDays = parseInt(dayNum) + 1;
        currntDetail = currntDetail.substring(0, currntDetail.indexOf("<div id=\"day_" + nowDays + "\" class=\"fieldset xingcheng-by-day\">"));
        document.getElementById("routeDetailDiv").innerHTML = currntDetail;
    }
    document.getElementById("oldRouteTime").value = dayNum;
}
function has_css_class_name(elem, cname) {
    return (elem && cname) ? new RegExp('\\b' + cname + '\\b').test(elem.className) : false;
}
function xingcheng_add_jd(d) {
    if (gt("jd_title_sc" + d).value >= 10) {
        alert("最多可添加10个目的地！")
        return;
    }
    var div = gt('jd_title_'+d);

    var i, dd = 0;
    var last_set_node = null;
    var ds = div.getElementsByTagName('dd');
    dd = ds.length;
    last_set_node = ds[dd - 1];
    var cd = document.getElementById("jd_title_sc" + d).value;
    var node = document.createElement('dd');
    //node.className = 'fileset xingcheng-by-day';
    //node.setAttribute("id", "day_" + (days + 1));
    var tmphtml = "";
    tmphtml = "<select name='s_route_" + d + "_0_" + (cd - 1) + "'><option value='1'>=飞机=</option><option value='2'>=汽车=</option><option value='3'>=轮船=</option><option value='4'>=火车=</option></select>";
    tmphtml += "<input class='text' id='route_" + d + "_0_" + cd + "' name='route_" + d + "_0_" + cd + "' size='10' />";
    node.innerHTML = tmphtml;
    div.insertBefore(node, last_set_node.nextSibling);

    gt("jd_title_sc" + d).value = gt("jd_title_sc" + d).value * 1 + 1;
}
function xingcheng_remove_jd(d) {
    var div = gt('jd_title_' + d);

    var i, dd = 0;
    var last_set_node = null;
    var ds = div.getElementsByTagName('dd');

    dd = ds.length;
    last_set_node = ds[dd - 1];

    if (dd <= 2) return;
    last_set_node.parentNode.removeChild(last_set_node);

    gt("jd_title_sc" + d).value = gt("jd_title_sc" + d).value * 1 - 1;

}
function checkTitle(f, d) {
    if (f.value == 'False') {
        $("#route_" + d + "_0").show();
        if (gt("jd_title_" + d)) {
            $("#jd_title_" + d).hide();
        }
    } else {
        $("#route_" + d + "_0").hide();
        if (!gt("jd_title_" + d)) {
            add_title(d);
        } else {
            $("#jd_title_" + d).show();
        }
    }
}
function add_title(d) {
    var div = gt('day_' + d);
    var ds = div.getElementsByTagName('dl');
    var first_set_node = ds[0];
    var node = document.createElement('dl');
    node.className = 'titleByJd';
    node.setAttribute("id", "jd_title_" + d);
    
    var tmphtml = "";
    tmphtml = "<dd><input class='text' id='route_" + d + "_0_0' name='route_" + d + "_0_0' size='10' /></dd>";
    tmphtml += "<dd><select name='s_route_" + d + "_0_0'><option value='1'>=飞机=</option><option value='2'>=汽车=</option><option value='3'>=轮船=</option><option value='4'>=火车=</option></select>";
    tmphtml += "<input class='text' id='route_" + d + "_0_1' name='route_" + d + "_0_1' size='10' /></dd>";
    tmphtml += "<a href='#?' onclick='xingcheng_add_jd(" + d + ");'>+添加</a><a href='#?' onclick='xingcheng_remove_jd(" + d + ");'>-减少</a>";
    tmphtml += "<input type='hidden' id='jd_title_sc" + d + "' name='jd_title_sc" + d + "' value='2' />";
    node.innerHTML = tmphtml;
    div.insertBefore(node, first_set_node.nextSibling);
}
function xingcheng_add_day() {

    var div = gt('routeDetailDiv');

    var i, days = 0;
    var last_set_node = null;
    var ds = div.getElementsByTagName('DIV');

    for (i = 0; ds.length && i < ds.length; i++) {
        var node = ds[i];
        if (has_css_class_name(node, 'xingcheng-by-day')) {
            days++;
            last_set_node = node;
        }
    }
    
    var node = document.createElement('div');
    node.className = 'fileset xingcheng-by-day';
    node.setAttribute("id", "day_" + (days + 1));
    var tmphtml = "";
    //tmphtml = "<dl><dd><b>第" + (days + 1) + "天：<input class='text text380' id='route_" + (days + 1) + "_0' name='route_" + (days + 1) + "_0'  style='width:480px;' /></b>&nbsp;<a id='remove_day" + (days + 1) + "' href='#' onclick='xingcheng_remove_day();return false;'>删除第" + (days + 1) + "天行程</a></dd></dl>";
    tmphtml += "<dl><dd><b>第" + (days + 1) + "天：<input type='radio' name='rdo_title_" + (days + 1) + "' value='False' checked='checked' onclick='checkTitle(this," + (days + 1) + ")' />按标题<input class='text' id='route_" + (days + 1) + "_0' name='route_" + (days + 1) + "_0'  style='width:300px;' />";
    tmphtml += "<input type='radio' name='rdo_title_" + (days + 1) + "' value='True' onclick='checkTitle(this," + (days + 1) + ")' />按景点</b>&nbsp;&nbsp;<a id='remove_day" + (days + 1) + "' href='#' onclick='xingcheng_remove_day();return false;'>删除第" + (days + 1) + "天行程</a></dd></dl>";
    tmphtml += "<dl><dt>行程安排：</dt>";
    tmphtml += "<dd><div class='add_del_box'>";
    tmphtml += "<textarea id='route_"+(days+1)+"_1' name='route_"+(days+1)+"_1' style='width:700px;' rows='15'></textarea>";
    tmphtml += "</div></dd></dl>";
    tmphtml += "<dl class='hotel'><dd>";
    tmphtml += "<div class='floatL'>早餐：<input id='route_"+(days+1)+"_2' name='route_"+(days+1)+"_2' type='checkbox'  /><input class='text text160' id='route_"+(days+1)+"_6' name='route_"+(days+1)+"_6' type='text' size='20' /></div>";
    tmphtml += "<div class='floatL'>中餐：<input id='route_"+(days+1)+"_3' name='route_"+(days+1)+"_3' type='checkbox'  /><input class='text text160' id='route_"+(days+1)+"_7' name='route_"+(days+1)+"_7' type='text' size='20' /></div>";
    tmphtml += "<div class='floatL'>晚餐：<input id='route_"+(days+1)+"_4' name='route_"+(days+1)+"_4' type='checkbox'  /><input class='text text160' id='route_"+(days+1)+"_8' name='route_"+(days+1)+"_8' type='text' size='20' /></div>";
    tmphtml += "</dd></dl>";
    tmphtml += "<dl><dt>住宿：<input type='text' class='text text160' id='route_" + (days + 1) + "_5' name='route_" + (days + 1) + "_5' value=''/></dt></dl>";
    node.innerHTML = tmphtml;
    div.insertBefore(node, last_set_node.nextSibling);

    gt('xingcheng-next-day-no').innerHTML = days + 2;

    if (gt('remove_day' + gt("xing_day").value)) {
        gt('remove_day' + gt("xing_day").value).style.display = 'none';
    }
    gt("xing_day").value = gt("xing_day").value * 1 + 1;

    gt('sch_day').innerHTML = '';

    xingcheng_kindEditor(days * 1 + 1);
}
function xingcheng_remove_day() {
    var div = gt('routeDetailDiv');

    var i, days = 0;
    var last_set_node = null;
    var ds = div.getElementsByTagName('div');

    for (i = 0; ds.length && i < ds.length; i++) {
        var node = ds[i];
        if (node.className.indexOf('xingcheng-by-day') > -1) {
            days++;
            last_set_node = node;
        }
    }

    if (days <= 1) return;
    last_set_node.parentNode.removeChild(last_set_node);

    gt('xingcheng-next-day-no').innerHTML = days;

    gt("xing_day").value = gt("xing_day").value * 1 - 1;
    if (gt('remove_day' + gt("xing_day").value)) {
        gt('remove_day' + gt("xing_day").value).style.display = '';
    }

    gt('sch_day').innerHTML = '';

}
function updateRouteTime() {
    var nowDays = document.getElementById("RouteTime").value;
    //var oldDetail = document.getElementById("DetailType_Hidden");
    var xingDay = document.getElementById("xing_day").value;
    if (xingDay > 1) return;
    
    xingcheng_kindEditor(1);

    for (var days = 2; days <= nowDays; days++) {
        xingcheng_add_day();
    }
}
function xingcheng_kindEditor(id) {
    $.getScript('/WebManage/kindsoft/kindeditor.js', function() {
    eval("KindEditor.create('#route_" + id + "_1', {uploadJson: '/WebManage/kindsoft/upload_json_route.ashx',fileManagerJson: '/WebManage/kindsoft/file_manager_json.ashx',allowFileManager: true});");
    });
}
function checkdate(a, b) {

    var arr = a.split("-");
    var starttime = new Date(arr[0], arr[1] - 1, arr[2]);
    var starttimes = starttime.getTime();

    var arrs = b.split("-");
    var lktime = new Date(arrs[0], arrs[1] - 1, arrs[2]);
    var lktimes = lktime.getTime();

    if (starttimes >= lktimes) {
        return false;
    }
    else
        return true;
}
function UpdateRoutePrice() {
    var dd = new Date();
    var aprice = document.getElementById("aprice").value;
    var cprice = document.getElementById("cprice").value;
    if (!is_int(aprice)) {
        alert("成人价格必须为正整数"); return false;
    }
    if (!is_int(cprice)) {
        cprice = 0;
    }
    var priceWeekDays = document.getElementsByName("week_select");
    var selectWeek = false;
    var weekDays = "";
    for(var s = 0; s < priceWeekDays.length; s++){
        if(priceWeekDays[s].checked){
            selectWeek = true;
            weekDays += priceWeekDays[s].value + ",";
        }
    }
    if (weekDays == "") { alert("请指定时间段星期！"); return false; }
    
    var sdate = document.getElementById("starttime").value;
    var edate = document.getElementById("endtime").value;
    
    if (sdate == "") {
        var today = new Date();
        today.setDate(today.getDate() + 1);
        sdate = today.getFullYear() + "-" + (today.getMonth() * 1 + 1) + "-" + today.getDate();
    }
    if (edate == "") {
        var today = new Date();
        today.setDate(today.getDate() + 90);
        edate = today.getFullYear() + "-" + (today.getMonth() * 1 + 1) + "-" + today.getDate();
    }
    if (checkdate(edate, sdate)) { alert("截止日期必须大于起始日期！"); return false; }

    var ndate = dd.getFullYear() + "-" + (dd.getMonth() * 1 + 1) + "-" + dd.getDate();

    if (!checkdate(ndate, sdate) && ndate != sdate) { alert("起始日期必须大于当天！"); return false; }
    var sd = sdate.split('-');
    var strSdate = new Date(sd[0], sd[1] - 1, sd[2]);
    
    var ed = edate.split('-');
    var strEdate = new Date(ed[0], ed[1] - 1, ed[2]);

    var strNdate = new Date(dd.getFullYear(), dd.getMonth(), dd.getDate());

    var intDay = Math.abs(strEdate - strNdate) / (1000 * 3600 * 24);

    if (intDay > 90) { alert("截止日期必须当前日期后90天内！"); return false; }

    var nowDatePrice = ""; //document.getElementById("DatePrice").value;

    var maxDay = new Date(dd.getFullYear(), dd.getMonth() + 1, 0).getDate();
    var countDay = Math.abs(strEdate - strSdate) / (1000 * 3600 * 24) + 1;

    for (var i = 0; i < countDay; i++) {
        var weekDay = strSdate.getDay();
        if (weekDays.indexOf(weekDay) < 0) {
            strSdate.setDate(strSdate.getDate() + 1);
            continue;
        }
        var tempDate = strSdate.getFullYear() + "-" + (strSdate.getMonth() * 1 + 1) + "-" + strSdate.getDate();
        nowDatePrice += tempDate + "," + aprice + "," + cprice + "|";
        strSdate.setDate(strSdate.getDate() + 1);
        show_style(tempDate, aprice, cprice);
    }
    var oldDatePrice = document.getElementById("DatePrice").value;

    if (oldDatePrice != "") {
        var oPrice = oldDatePrice.split('|');
        var countOPrice = oPrice.length;

        for (var n = 0; n < countOPrice; n++) {
            var strODate = oPrice[n].split(',')[0];
            if (nowDatePrice.indexOf(strODate+",") < 0) {
                nowDatePrice += oPrice[n] + "|";
            }
        }
    }

    document.getElementById("DatePrice").value = nowDatePrice;
}