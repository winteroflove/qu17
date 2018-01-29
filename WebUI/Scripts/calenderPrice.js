//common

var nowDate = new Date();
var Mdate = nowDate.getFullYear()+"-"+ (nowDate.getMonth()+1) + "-" + nowDate.getDate();

var d = Mdate;
//var d = new Date().format("yyyy-MM-dd"); 
var lg_c=  0 ;// 当前图片数量，没有为0

function addprice(time,l_price,l_chiprice,l_num)
{
    $(".LG_val").append('       <div class="LG_'+lg_c+'"><table class="main_neirong" width="98%" cellpadding="0" cellspacing="0" bordercolor="#a3a3a3"><tr><td>未添加</td><td><input type="text" value="'+time+'" name="dateinfo_'+lg_c+'"  plugin="datepicker" datatype="*" nullmsg="时间不能为空！"  errormsg="时间格式不对！" /></td><td><div class="Validform_checktip"></div></td><td><input  type="text" value="'+l_price+'" name="price_'+lg_c+'" id="price_'+lg_c+'" datatype="f" nullmsg="价格不能为空！"  errormsg="价格格式不对！" /></td><td><div class="Validform_checktip"></div></td><td><input  type="text" value="'+l_chiprice+'" name="chiprice_'+lg_c+'" id="chiprice_'+lg_c+'" datatype="f" nullmsg="价格不能为空！"  errormsg="价格格式不对！" /></td><td><div class="Validform_checktip"></div></td><td><input  type="text" value="'+l_num+'" name="people_num_'+lg_c+'" id="people_num_'+lg_c+'" datatype="n1-6" nullmsg="人数不能伪空！"  errormsg="人数格式不对！" /></td><td><div class="Validform_checktip"></div></td><td ><input type="button" name="button" id="button" onclick="removepriceno('+lg_c+');" value="删除" /></td></tr></table></div>');

    lg_c++;

	$(".registerform").Validform({
	tiptype:2,
	beforeSubmit:function(data){
		$("#countprice").val(lg_c);	
}
   
});

}
	
/*修改价格信息 */
function editprice(time,l_price,l_chiprice,l_num,lg_temp_i)
{
	 $("input[name=dateinfo_"+lg_temp_i+"]").val(time);
		$("#price_"+lg_temp_i).val(l_price);
		$("#chiprice_"+lg_temp_i).val(l_chiprice);
		$("#people_num_"+lg_temp_i).val(l_num);
	
}
	
function refreshcalender()
	{
	 for(i=0;i<lg_c;i++)
	 {
		 if(typeof($("input[name=dateinfo_"+i+"]").val())== "undefined")
		 {
			 //没有定义
			 }
			 else
			 {
				 time=$("input[name=dateinfo_"+i+"]").val();
				 p_price=$("#price_"+i).val();
				 p_chiprice=$("#chiprice_"+i).val();
				 p_num=$("#people_num_"+i).val();
				 priceid=$("input[name=priceid_"+i+"]").val();
				 
				 y1=time.split('-');
				 y=$("#cal_title").text();
		         y=y.replace("<<",'').replace('<','').replace('>>','').replace('>','').replace(/^\s*(.*?)[\s\n]*$/g,'$1');   
				 y2=y.split('-');
				  
				 if(parseInt(y1[0],10)==parseInt(y2[0],10)){
					  // alert(parseInt(y1[1],10)+':'+parseInt(y2[1],10));
					   if(parseInt(y1[1],10)==parseInt(y2[1],10)){
						//   alert('003');
						                   lg_d=parseInt(y1[2],10);
										 
										   if(typeof(priceid) == "undefined")
										   {
											  
							   $(".lg_d[val="+lg_d+"]").html(lg_d+" <p class=\"calendar_number\">人数:"+p_num+"</p><p class=\"calendar_price\">&yen;"+p_price+"</p>"+"<a href='javascript:return false;' onclick='removepriceno("+i+")'>删除</a>");
										   }
										   else
										   {
                                          $(".lg_d[val="+lg_d+"]").html(lg_d+" <p class=\"calendar_number\">人数:"+p_num+"</p><p class=\"calendar_price\">&yen;"+p_price+"</p>"+"<a href='javascript:return false;' onclick='removeprice("+priceid+","+i+")'>删除</a>");  
											}
							   $(".lg_d[val="+lg_d+"]").attr("data",i);
					  
					                   }
					 }
				 }
		 
		}	
	 }
	 
function addevent()
{
	$(".lg_d .add").click(function(){

	y=$("#cal_title").text();
	y=y.replace("<<",'').replace('<','').replace('>>','').replace('>','').replace(/^\s*(.*?)[\s\n]*$/g,'$1');   
	d=$(this).parent().attr("val");
	//y=$(".year").val();
	//m=$(".month").val();

	time=y+'-'+d;
	//alert(Mdate);
	if(checkdate(Mdate,time))// 点击时间在当前时间之后
	{
	    //alert($("input[value="+time+"]").attr("name"))
        if(typeof($(this).attr("data")) == "undefined")
	    {
		    //alert('无定义');
		    $("input[name=l_time]").val(time);
	    }
	    else
	    {
		    //获取隐藏数据
	 	    lg_temp_i=parseInt($(this).attr("data"));
		    $("input[name=l_time]").val($("input[name=dateinfo_"+lg_temp_i+"]").val());
		    $("input[name=l_price]").val($("#price_"+lg_temp_i).val());
		    $("input[name=l_chiprice]").val($("#chiprice_"+lg_temp_i).val());
		    //$("input[name=l_num]").val($("#people_num_"+lg_temp_i).val());
	     }
	    /*
	    添加新的价格
	    */
    	
	    $.layer({	
	    v_box : 1,
	    v_dom : '#page',	//id
	    v_area : ['600px','300px'],
	    v_btns : 2,
    	
	    v_title:  '添加一个价格',
	    yes : function(){ 
	       p_time=$("input[name=l_time]").val();
           p_price=$("input[name=l_price]").val();
	       p_chiprice=$("input[name=l_chiprice]").val();
	       //p_num=$("input[name=l_num]").val();
	       /*验证*/
	       error=0;
	        if(!/^[\d]+(\.\d+)?$/.test(p_price)){
             $(".lg_msg").html("请正确添加价格格式");
        	 
	          error=1;
             }
	         if(!/^[\d]+(\.\d+)?$/.test(p_chiprice)){
                $(".lg_msg").html("请正确添加价格格式");
	             error=1;
             }
	      /*if(!/^[0-9]{1,5}$/.test(p_num)){
               $(".lg_msg").html("请正确添写人数格式不得少于1位不得大于5位");
	             error=1;
          }*/
	    // 
	    if(error==0){
	      $(".lg_msg").html('');
    	  
	      if(typeof($(".lg_d[val="+d+"]").attr("data")) == "undefined")
	      {
	         //添加
		      $(".lg_d[val="+d+"]").attr("data",lg_c);
	          addprice(time,p_price,p_chiprice,p_num);
	      }
	      else
	      {
	         //修改
	          editprice(time,p_price,p_chiprice,p_num,$(".lg_d[val="+d+"]").attr("data"));
	      }
    	
	       $(".lg_d[val="+d+"]").html(d+ " <p class=\"calendar_price\">&yen;"+p_price+"</p>"+"<a href='javascript:return false;' onclick='removepriceno("+$(".lg_d[val="+d+"]").attr("data")+")'>删除</a>");
	       layer_close();
	    }
    	   
  	    },
	    no: function(){
		     $(".lg_msg").html('');
		      layer_close();
	    },
	    v_offset : ['100px','']	//为空时数据默认
	    });
	}
	else
	{
		//layer_alert('不能添加当天之前的价格');
		layer_alert('不能添加当天之前的价格',function(){layer_close();},"","重庆青旅提示您！");
	 }
    });
		
}
	 
	 
	 
	/*
	 删除图片信息并 删除数据
	 @author lgl
	*/
	function removeprice(id,key)
	{
		if (confirm("是否确认"))  {  
           // t=lg_c-1;//记录当前最后一个元素
             //var deltid=$(".LG_"+t).find("input[name=tid_"+t+"]").val();//找到当前行程中的Tid 没有说明 是新增行程 删除无需向服务器发信息
			 
		
					  if(id!='')
					   {
							  $.get("/route/delprice/priceid/"+id,  function(data){
								  //服务器删除成功
							   if(data){
									   $(".LG_"+key).remove();
									   $(".lg_d[data="+key+"]").html($(".lg_d[data="+key+"]").attr("val")+"<br/><a href='#' class='add'>添加</a></td>");
								       $(".lg_d[data="+key+"]").removeAttr("data");
									   addevent();
							   }
							   else
							   {
								
								alert('删除失败,请重新尝试！');
								}
								 });
			   	  
					  }else
					  {
						 alert('ID 不能为空');
						 }
                
			
		}  else  {}; //弹出框点否

	}
	
	
	 //删除当前图片信息
	function removepriceno(key)
	{
		if (confirm("是否确认"))  {  
         
		    $(".LG_"+key).remove();
			
			$(".lg_d[data="+key+"]").html($(".lg_d[data="+key+"]").attr("val")+"<br/><a href='#' class='add'>添加</a></td>");
			$(".lg_d[data="+key+"]").removeAttr("data");
			addevent();
		}
		
		
    }

function changecal(action,year,month)
{      
      var strcal;
      switch(action)
      {      
      case "nextmonth":
            if(month==11)
            {
                  month = 1;
                  year = year*1 + 1;
            }else{
                  month = month*1 + 2;
            }
            strcal = "<span onmouseover=\"this.className='arrow_over'\" onmouseout=\"this.className='arrow_out'\" class='arrow_out'  onclick='calender(" + year + "," + month +")' title='下一个月' style='cursor:hand;'>></span>";
            break;
      case "premonth":
            if(month==0)
            {
                  month = 12;
                  year = year*1 - 1;
            }
            strcal = "<span onmouseover=\"this.className='arrow_over'\" onmouseout=\"this.className='arrow_out'\" class='arrow_out' onclick='calender(" + year + "," + month +")' title='上一个月' style='cursor:hand;'><</span>";
            break;
      case "nextyear":
            year = year*1 + 1;
            month = month*1 + 1;
            strcal = "<span onmouseover=\"this.className='arrow_over'\" onmouseout=\"this.className='arrow_out'\" class='arrow_out' onclick='calender(" + year + "," + month +")' title='下一年' style='cursor:hand;'>>></span>";
            break;
      case "preyear": 
            year = year*1 - 1;
            month = month*1 + 1;
            strcal = "<span onmouseover=\"this.className='arrow_over'\" onmouseout=\"this.className='arrow_out'\" class='arrow_out' onclick='calender(" + year + "," + month +")' title='上一年' style='cursor:hand;'><<</span>";
            break;
      default:;
      }
      strcal = " " + strcal + " ";
      return(strcal);
}
 
function calender(cyear,cmonth)
{
      
      var d,d_date,d_day,d_month;
      //定义每月天数数组
      var monthdates = ["31","28","31","30","31","30","31","31","30","31","30","31"]      
      d = new Date();
      d_year = d.getYear();      //获取年份
      //判断闰月，把monthdates的二月改成29
      if (((d_year % 4 == 0) && (d_year % 100 != 0)) || (d_year % 400 == 0)) monthdates[1] = "29";
      
      if ((cyear != "" ) || (cmonth != ""))
      {
            //如果用户选择了月份和年份，则当前的时间改为用户设定
            d.setYear(cyear);
           	d.setDate(1);
            d.setMonth(cmonth-1);  
      }
      d_month = d.getMonth();      //获取当前是第几个月
      d_year = d.getYear();      //获取年份
      d_date = d.getDate();      //获取日期
      
      //修正19XX年只显示两位的错误
      if(d_year<2000){d_year = d_year + 1900}      
//===========输出日历===========
      var str;
      str = "<table cellspacing='0' cellpadding='0' id='calender' class='date week'>";
      str += "<tr><td id='cal_title' colspan='7' style='width:100%; background-color:#cbebff; padding-top:5px; font-size:13px; line-height:30px;' >"
      str += changecal("preyear",d_year,d_month) 
      str += changecal("premonth",d_year,d_month) 
      str += d_year + "-" + (d_month*1+1) 
      str += changecal("nextmonth",d_year,d_month) 
      str += changecal("nextyear",d_year,d_month)  
      str += "</td></tr>";
      str += "<tr id='week'><td>Su</td><td>Mo</td><td>Tu</td><td>We</td><td>Th</td><td>Fr</td><td>Sa</td></tr>";
      str += "<tr>";
      var firstday,lastday,totalcounts,firstspace,lastspace,monthdays;
      //需要显示的月份共有几天，可以用已定义的数组来获取
      monthdays = monthdates[d.getMonth()];
      
      //设定日期为月份中的第一天
      d.setDate(1);
      
      //需要显示的月份的第一天是星期几
      firstday = d.getDay();      
      
      //1号前面需要补足的的空单元格的数
      firstspace = firstday;
      
      //设定日期为月份的最后一天
      d.setDate(monthdays);
      
      //需要显示的月份的最后一天是星期几
      lastday = d.getDay();
      
      //最后一天后面需要空单元格数
      lastspace = 6 - lastday;
      
      //前空单元格+总天数+后空单元格，用来控制循环
      totalcounts = firstspace*1 + monthdays*1 + lastspace*1;      
      
      //count：大循环的变量;f_space:输出前空单元格的循环变量;l_space:用于输出后空单元格的循环变量
      var count,flag,f_space,l_space;
      //flag：前空单元格输完后令flag=1不再继续做这个小循环
      flag = 0;
      for(count=1;count<=totalcounts;count++)
      {
            //一开始flag=0，首先输出前空单元格，输完以后flag=1，以后将不再执行这个循环
            if(flag==0)
            {
                  if(firstspace!=0)
                  {      
                        for(f_space=1;f_space<=firstspace;f_space++)
                        {      
                              str += "<td>&nbsp;</td>";
                              if(f_space!= firstspace) count++;      
                        }
                        flag = 1;
                        continue;
                  }
            }            
            
            if((count-firstspace)<=monthdays)
            {
                  //输出月份中的所有天数            
                  curday = d_year+","+(d_month*1+1)+","+(count - firstspace)+"|"
                  linkday = d_year+","+(d_month*1+1)+","+(count - firstspace)
                  var today = new Date();

				  time1=d_year+'-'+(d_month*1+1)+'-'+(count-firstspace);
				  
				  str += "<td class=\"normal\" id=\"" + time1 + "\"><em>" + (count - firstspace) + "</em></td>";
				  
                  if(count%7==0)
                  {
                        if(count<totalcounts)
                        {
                              str += "</tr><tr>";
                        }else{
                              str += "</tr>";
                        }
                  }
            }else{
                  //如果已经输出了月份中的最后一天，就开始输出后空单元格补足
                  for(l_space=1;l_space<=lastspace;l_space++)
                  {
                        str += "<td>&nbsp;</td>";
                        if(l_space!= lastspace) count++;      
                  }
                  continue;
            }
      }
      str += "</table>"
      document.getElementById("calenderdiv").innerHTML = str;
      
      var dateType = document.getElementById("DateType").value;
      
      if (dateType == 'False') {
          var price = document.getElementById("Price").value;
          var cprice = document.getElementById("ChildPrice").value;
          updateCalenderDataForDays(d_year,(d_month * 1 + 1), price, cprice);
      } else {
          var calenderData = document.getElementById("DatePrice").value;
          var currentYM = d_year + '-' + (d_month * 1 + 1);
          
          if (calenderData != null && calenderData != "" && calenderData.indexOf(currentYM) >= 0) {
              updateCalenderData(currentYM);
          }
      }
}

function checkdate(a,b){
	
    var arr = a.split("-");
    var starttime = new Date(arr[0], arr[1], arr[2]);
    var starttimes = starttime.getTime();

    var arrs = b.split("-");
    var lktime = new Date(arrs[0], arrs[1], arrs[2]);
    var lktimes = lktime.getTime();

    if (starttimes >= lktimes) 
    {
        return false;
    }
    else
        return true;
}

function updateCalenderData(ym) {
    var calenderData = document.getElementById("DatePrice").value;
    var datePrices = calenderData.split("|");
    for (var k = 0; k < datePrices.length; k++) {
        
        if (datePrices[k].indexOf(ym) < 0) {
            continue;
        }

        var date = datePrices[k].toString().split(",");
        
        show_style(date[0], date[1], date[2]);
    }
}

function updateCalenderDataForDays(year, month, price, cprice) {
    //return;
    var monthdates = ["31", "28", "31", "30", "31", "30", "31", "31", "30", "31", "30", "31"];
    var cYear = new Date().getFullYear();
    var cMonth = new Date().getMonth()+1;
    var cDay = new Date().getDate();
    
    if ((year == cYear && ((month - cMonth) == 0 || (month - cMonth) == 1)) || (((year - cYear) == 1) && ((cMonth - month) == 11))){
        var k = cDay + 1;
        if ((month - cMonth) == 1) k = 1;
        for (; k <= monthdates[month - 1]; k++) {
            var mycday = year + "-" + month + "-" + k;

            show_style(mycday, price, cprice);
        }
    }
}

function show_style(price_date, price_d, price_child_d) {
    
    var str = gt(price_date).innerHTML;
    arr = price_date.split('-');
    if (!arr[2]) alert('出错');
    var day = arr[2];
    if (day.substr(0, 1) == 0) day = day.substr(1);
    if (price_d > 0) {
        gt(price_date).className = 'special';
        str = '<a onclick=\'javascript:genOrder("' + price_date + '","' + price_d + '","' + price_child_d + '")\'><em>' + day + '</em>';
        title = '成人价：' + price_d + '元';
        if (price_child_d) title += "\n" + '儿童价：' + price_child_d + '元';
        str += '<em style="color:red;" title="' + title + '">' + price_d + '元';
        str += '</em></a>';
    }
    //alert(str);
    gt(price_date).innerHTML = str;
}
function gt(objID) {
    return document.getElementById(objID);
}
function checkdate(a, b) {

    var arr = a.split("-");
    var starttime = new Date(arr[0], arr[1], arr[2]);
    var starttimes = starttime.getTime();

    var arrs = b.split("-");
    var lktime = new Date(arrs[0], arrs[1], arrs[2]);
    var lktimes = lktime.getTime();

    if (starttimes >= lktimes) {
        return false;
    }
    else
        return true;
}
function genOrder(day, price, cprice) {
    
    document.getElementById("roaddate").value = day;
    document.getElementById("aprice").value = price;
    document.getElementById("cprice").value = cprice == 0 ? price : cprice;
    document.getElementById("datePriceLayer").style.display = 'none';
}