// JavaScript Document

/*
@author lgl
*/
/*比较时间大小函数
 @author lgl
  a>=b return false
  a<b  return true
 */

	
function $Nav()
{
	if(window.navigator.userAgent.indexOf("MSIE")>=1) return 'IE';
	else if(window.navigator.userAgent.indexOf("Firefox")>=1) return 'FF';
	else return "OT";
}

function SelectTravel(fname)
{
	if($Nav()=='IE'){ var posLeft = window.event.clientX-100; var posTop = window.event.clientY; }
	else{ var posLeft = 100; var posTop = 100; }
	if(!fname) fname = 'form1.picname';
	//if(imgsel) imgsel = '&noeditor=yes';
	//if(!stype) stype = '';
	//window.open("/trlagent/listtrlagent/?f="+fname+"&noeditor=yes&imgstick="+stype+imgsel, "popUpImagesWin", "scrollbars=yes,resizable=yes,statebar=no,width=650,height=400,left="+posLeft+", top="+posTop);
	window.open("/trlagent/listtrlagent/f/"+fname, "popUpImagesWin", "scrollbars=yes,resizable=yes,statebar=no,width=650,height=400,left="+posLeft+", top="+posTop);

}

/*格式化时间函数
@author lgj
*/
Date.prototype.format = function(format)
{
var o = {
"M+" : this.getMonth()+1, //month
"d+" : this.getDate(), //day
"h+" : this.getHours(), //hour
"m+" : this.getMinutes(), //minute
"s+" : this.getSeconds(), //second
"q+" : Math.floor((this.getMonth()+3)/3), //quarter
"S" : this.getMilliseconds() //millisecond
}
if(/(y+)/.test(format)) format=format.replace(RegExp.$1,
(this.getFullYear()+"").substr(4 - RegExp.$1.length));
for(var k in o)if(new RegExp("("+ k +")").test(format))
format = format.replace(RegExp.$1,
RegExp.$1.length==1 ? o[k] :
("00"+ o[k]).substr((""+ o[k]).length));
return format;
}
