//common
var systemTip = {
    other: '网络故障，请刷新后再试...',
    success: '操作成功',
    error: '操作失败，请刷新后再试...',
    del: '确定要删除吗？',
    resetpsd: '确定要重置当前用户密码吗？',
    copy: '确定要复制当前线路吗？',
    delmore: '请选择要删除的数据',
    existdata: '请删除其下数据后，再删除此类名！'
}, empty = '', url = '../Service.ashx?';
var login = "/WebManage/login.aspx";
/*if (window.top.location == location.href && location.href.indexOf(login) == -1)
    location.href = login;*/

function ajaxAction(queryStr, id, isReload) {
    if (!confirm(systemTip.del)) return;
    $.ajax({ url: url + queryStr, type: "GET", dataType: "text",
    	error: function(XMLHttpRequest) { alert(systemTip.other); },
    	success: function(data) {
    		if (data == "success") {
    			alert(systemTip.success);
    			isReload ? location.reload() : $("#tr_" + id).hide();
            } else if (data == "existdata") { alert(systemTip.existdata); }
    		else { alert(systemTip.error); }
    	}
    });
}
function ajaxActionRoute(queryStr, id, isReload) {
    $.ajax({ url: url + queryStr, type: "GET", dataType: "text",
    	error: function(XMLHttpRequest) { alert(systemTip.other); },
    	success: function(data) {
    		if (data == "success") {
    			alert(systemTip.success);
    			if (isReload) {
    			    location.reload();
    			}
    		} else { alert(systemTip.error); }
    	}
    });
}
function ajaxActionRouteClass(queryStr, isReload) {
    $.ajax({ url: url + queryStr, type: "GET", dataType: "text",
        error: function(XMLHttpRequest) { alert(systemTip.other); },
        success: function(data) {
            document.getElementById("ScenicDiv").innerHTML = data;
        }
    });
}
function ajaxActionRouteProvince(queryStr, isReload) {
    $.ajax({ url: url + queryStr, type: "GET", dataType: "text",
        error: function(XMLHttpRequest) { alert(systemTip.other); },
        success: function(data) {
            document.getElementById("Province").innerHTML = data;
            document.getElementById("ScenicDiv").innerHTML = "<span class='red_text'>说明:请先选择一个省份或者直辖市</span>";
        }
    });
}
$(function() {
    $("#back").bind("click", function() {
        history.back(-1);
    });
});
//end
function is_int(str) {
    var r = /^[0-9]*[1-9][0-9]*$/;
    if (r.test(str) == false) {
        return false;
    }
    return true;
}
function GetSmallClass(o) {
    if (o.value == "" || o.value == "0") {
        $("#sltArea").empty();
        $("#sltArea").append("<option value=''>不限　　　　</option>");
		return;
    }
    //alert(parentID);
    $.ajax({ url: "/service.ashx?ac=getarea&cid=" + o.value + "&parentID=0",
		type: "GET", dataType: "text", error: function(XMLHttpRequest) { },
		success: function(data) {
			$("#sltArea").empty();
			if (data == "") {
				$("#sltArea").append("<option value=''>不限　　　　</option>");
			}
			else if (data.indexOf("<option") > -1) {
				$("#sltArea").append("<option value=''>不限　　　　</option>");
				$("#sltArea").append(data);
			}
		}
	});
}
function ckFormAdvertiseAdd(f) {
	if (f.position.value == 0 || f.position.value.IsNull()) {
		alert("请选择广告位置");
		return false;
	}
	if (!arguments[1]) {
		if (f.Img.value.IsNull()) {
			alert("请选择广告图片");
			return false;
		}
	}
}
function formAccount(f) {
	if (f.Partner.value == "" ||
    f.Key.value == "" ||
    f.SellerAccount.value == "" ||
    f.Description.value == "") {
		alert("请填写完整后再提交"); return false;
	}

	if (f.Description.value.length > 200) {
		alert("说明不能超过200个字符");
		return false;
	}
}

function formRoute(f, type) {
    
    if (f.Title.value.IsNull()) {
        alert("请输入标题");
        f.Title.focus();
        return false;
    }
    if (f.Price.value.IsNull()) {
        alert("请输入线路价格");
        f.Price.focus();
        return false;
    }
    if (!is_int(f.Price.value) && f.Price.value!="0") {
        alert("线路价格只能输入整数或小数");
        f.Price.focus();
        return false;
    }
    if (!f.ChildPrice.value.IsNull()) {
        if (!is_int(f.ChildPrice.value) && f.ChildPrice.value != "0") {
            alert("线路价格只能输入整数或小数");
            f.ChildPrice.focus();
            return false;
        }
    }
    if (type == "add") {
        var fileExists = false;
        var files = document.getElementsByName("Image");
        for (var i = 0; i < files.length; i++) {
            if (!files[i].value.IsNull()) {
                fileExists = true;
                break;
            }
        }
        if (!fileExists) {
            alert("至少需要上传一张图片");
            files[0].focus();
            return false;
        }
    }

    if (f.StartPosition.value.IsNull()) {
        alert("请输入出发地");
        f.StartPosition.focus();
        return false;
    }

    if (f.Destination.value.IsNull()) {
        alert("请输入目的地");
        f.Destination.focus();
        return false;
    }

    if (f.RouteTime.value.IsNull()) {
        alert("请输入行程天数");
        f.RouteTime.focus();
        return false;
    } else if (!is_int(f.RouteTime.value)) {
        alert("行程天数必须为非0数字");
        f.RouteTime.focus();
        return false;
    }
    if(f.AdvanceDays.value.IsNull()){
        alert("请输入提前报名天数!");
        f.AdvanceDays.focus();
        return false;
    } else if (!is_int(f.AdvanceDays.value)) {
        alert("提前报名天数必须为非0数字");
        f.AdvanceDays.focus();
        return false;
    }
    
    if (f.SeoKeywords.value.length > 500) {
       	alert("页面关键字请控制在500字以内");
       	f.SeoDescription.focus();
       	return false;
    }
    if (f.SeoDescription.value.length > 500) {
       	alert("页面描述请控制在500字以内");
       	f.SeoDescription.focus();
       	return false;
    }
    var prov = document.getElementsByName("ProvinceCheckBox");
    var existProv = false;
    for (var i = 0; i < prov.length; i++) {
        if (prov[i].checked) {
            existProv = true;
            break;
        }
    }
    if (!existProv) {
        alert("请选择线路目的地省市!");
        return false;
    }
}

function clearFile() {

    $("#fileImages").html($("#fileImages").html());
}
function UpdateRouteOrder(id) {
    var routeOrderName = document.getElementById("RouteOrder_" + id);
    var routeOrder = routeOrderName.value;
    ajaxActionRoute("ac=RouteOrderUpdate&id=" + id + "&routeOrder=" + routeOrder, id, false);
}
function UpdateRoutePrice(id) {
    var routePriceName = document.getElementById("RoutePrice_" + id);
    var routePrice = routePriceName.value;
    ajaxActionRoute("ac=RoutePriceUpdate&id=" + id + "&routePrice=" + routePrice, id, false);
}
function newsDelete(id,img) {
    ajaxAction("ac=NewsDelete&id=" + id + "&img="+img, id, false);
}
function newsClassDelete(id) {
    ajaxAction("ac=NewsClassDelete&id=" + id, id, false);
}
function routeClassDelete(id) {
    ajaxAction("ac=RouteClassDelete&id=" + id, id, false);
}
function linksDelete(id) {
    ajaxAction("ac=LinksDelete&id=" + id, id, false);
}
function hotLinksDelete(id) {
    ajaxAction("ac=HotLinksDelete&id=" + id, id, false);
}
function InternalLinkDelete(id) {
    ajaxAction("ac=InternalLinkDelete&id=" + id, id, false);
}
function routeDelete(id) {
    ajaxAction("ac=RouteDelete&id=" + id, id, false);
}
function routeCopy(id) {
    if (!confirm(systemTip.copy)) return;
    ajaxActionRoute("ac=RouteCopy&id=" + id, id, true);
}
function routeCommentDelete(id) {
    ajaxAction("ac=RouteCommentDelete&id=" + id, id, false);
}
function ordersDelete(id) {
    ajaxAction("ac=OrdersDelete&id=" + id, id, false);
}
function adminDelete(id) {
    ajaxAction("ac=AdminDelete&id=" + id, id, false);
}
function memberDelete(id) {
    ajaxAction("ac=MemberDelete&id=" + id, id, false);
}
function resetPassword(id) {
    if (!confirm(systemTip.resetpsd)) return;
    ajaxActionRoute("ac=ResetPassword&id=" + id, id, false);
}
function advertiseDelete(id,img) {
	ajaxAction("ac=AdDelete&id=" + id + "&img=" + img, id, false);
}
function accountDelete(id) {
	ajaxAction("ac=AccountDelete&id=" + id, id, false);
}
function scrollImageDelete(id, img) {
	ajaxAction("ac=ScrollImageDelete&id=" + id + "&img=" + img, id, false);
}
function ThemeDelete(id) {
    ajaxActionRoute("ac=ThemeDelete&id=" + id, id, false);
}
function RouteTypeDelete(id) {
    ajaxAction("ac=RouteTypeDelete&id=" + id, id, false);
}
function SaleAdvertiseDelete(id, img) {
    ajaxAction("ac=SaleAdvertiseDelete&id=" + id + "&img=" + img, id, false);
}
//省份下拉框变动事件
function ProvinceChange(ckb) {
    if (ckb.checked == true) {
        
        var cb = document.getElementsByName("ProvinceCheckBox");
        var str = "";
        var Num = 0;
        for (var i = 0; i < cb.length; i++) {
            if (cb[i].checked == true) {
                Num++;
                str += cb[i].value + ",";
            }
        }

        if (Num > 8) {
            ckb.checked = false;
            ckb.disabled = true;

            for (var i = 0; i < cb.length; i++) {
                if (cb[i].checked == false) {
                    cb[i].disabled = true;
                }
            }
            alert("您已经选择了8个省份！");
            return;
        }

        if (Num == 8) {
            for (var i = 0; i < cb.length; i++) {
                if (cb[i].checked == false) {
                    cb[i].disabled = true;
                }
            }
        }
        str = str.substring(0, str.length - 1);
        ajaxActionRouteClass("ac=GetCity&ids=" + str, false);
    } else {
        document.getElementById("ScenicDiv").innerHTML = "";
        var cb = document.getElementsByName("ProvinceCheckBox");
        var str = "";
        var Num = 0;
        for (var i = 0; i < cb.length; i++) {
            if (cb[i].checked == false) {
                cb[i].disabled = false;
            } else {
                str += cb[i].value + ",";
            }
        }
        if (str.length > 0) {
            str = str.substring(0, str.length - 1);
            ajaxActionRouteClass("ac=GetCity&ids=" + str, false);
        } else {
            document.getElementById("ScenicDiv").innerHTML = "<span class='red_text'>说明:请先选择一个省份或者直辖市</span>";
        }
    }
    LocationChange();
}
function LocationChange() {
    var pcb = document.getElementsByName("ProvinceCheckBox");
    var ccb = document.getElementsByName("ScenicCheckBox");
    var strLocation = "";
    var isfirst = true;
    for (var i = 0; i < pcb.length; i++) {
        if (pcb[i].checked == true) {
            if (isfirst) {
                strLocation += "<input name='locationid' type='radio' value='" + pcb[i].value + "' checked='checked' />" + pcb[i].nextSibling.nodeValue;
            } else {
                strLocation += "<input name='locationid' type='radio' value='" + pcb[i].value + "' />" + pcb[i].nextSibling.nodeValue;
            }
        }
    }
    for (var i = 0; i < ccb.length; i++) {
        if (ccb[i].checked == true) {
            strLocation += "<input name='locationid' type='radio' value='" + ccb[i].value + "' />" + ccb[i].nextSibling.nodeValue;
        }
    }
    document.getElementById("locationDiv").innerHTML = strLocation;
}
function updateProvince() {

    var parentclassid = document.getElementById("routeParentID").value;
    if (parentclassid == 3) $("#trBoat").show();
    else $("#trBoat").hide();
    ajaxActionRouteProvince("ac=UpdateProvince&id=" + parentclassid, false);
}

//shopping cart
var cartWrapID = "cartWrap";
function getCartObj() {

    var array = [];

    var oldList = GetCookie("shopcart");

    if (oldList && oldList != "null") {
        array = JSON.ForString(oldList);
    }

    return array;

}

function buy(id, name, model, units, count, price) {

    if (isNaN(parseInt(count)) || count < 1) count = 1;
    else count = parseInt(count, 10);

    var existsObj = false;
    var obj = { id: id, name: name, model: model, units: units, count: count, price: price };

    var array = getCartObj();
    for (var n in array) {

        if (obj.id == array[n].id) {
            existsObj = true;
            array[n].count = parseInt(array[n].count, 10) + count;
            break;
        }
    }
    if (!existsObj)
        array.push(obj);

    SetCookie("shopcart", JSON.ToString(array), 365, "/");
    showCart();

}

function showCart() {

    if (!document.getElementById(cartWrapID))
        return;

    var cartHtml = "";
    var array = getCartObj();

    var productList = "";

    for (var n in array) {
        var p = array[n];

        var proPrice = Math.round(p.count * p.price * 100) / 100;

        cartHtml += '<ul>';
        cartHtml += '<li>产品名：{1}<a onclick="deleteCart({0})">x</a></li>';
        cartHtml += '<li>产品型号：{2}</li>';
        cartHtml += '<li>单位：{3}</li>';
        cartHtml += '<li>单价：<input type="text" maxlength="11" value="{4}" id="_price{0}" onblur="catChangeCountOrPrice({0})" /></li>';
        cartHtml += '<li>数量：<input type="text" maxlength="6" value="{5}" id="_count{0}" onblur="catChangeCountOrPrice({0})" /></li>';
        cartHtml += '<li>金额：￥<span id="_pTotalPrice{0}">{6}</span></li>';
        cartHtml += '</ul>';

        productList += p.id + ","
                         + p.name + ","
                         + p.model + ","
                         + p.units + ","
                         + p.count + ","
                         + p.price + ","
                         + proPrice + "|";

        cartHtml = cartHtml.Format(p.id, p.name, p.model, p.units, p.price, p.count, proPrice);

    }

    if (productList != "") productList = productList.substr(0, productList.length - 1);

    $("#" + cartWrapID).html(cartHtml);

    var totalPrice = cartGetTotalPrice();
    var totalCount = cartGetTotalCount();

    $("#totalPrice").val(totalPrice);
    $("#totalCount").val(totalCount);
    $("#prlductList").val(productList);

}

clearCart();
function clearCart() {

    SetCookie("shopcart", "[]", 1, "/");

}

function deleteCart(pid) {

    var array = getCartObj();

    for (var n = 0; n < array.length; n++) {
        if (pid == array[n].id) {
            array = array.slice(0, n).concat(array.slice(n + 1));
        }
    }

    SetCookie("shopcart", JSON.ToString(array), 365, "/");
    showCart();
}

function catChangeCountOrPrice(pid) {

    var newPrice = document.getElementById("_price" + pid).value;
    var newCount = document.getElementById("_count" + pid).value;

    if (!/^\d+$/.test(newCount) || newCount == 0) {
        newCount = 1;
    }
    if (!/^\d{1,8}(\.\d{1,2})?$/.test(newPrice)) {
        newPrice = 1;
    }

    var array = getCartObj();
    for (var n in array) {
        if (array[n].id == pid) {
            array[n].price = newPrice;
            array[n].count = parseInt(newCount, 10);
            break;
        }
    }

    SetCookie("shopcart", JSON.ToString(array), 365, "/");
    showCart();

}

function cartGetProductCount(pid) {
    var totalCount = 0;
    var array = getCartObj();

    for (var n in array) {

        if (pid == array[n].id) {
            totalCount += array[n].count;
        }
    }
    return totalCount;

}
function cartGetTotalCount() {
    var totalCount = 0;
    var array = getCartObj();

    for (var n in array) {
        totalCount += parseInt(array[n].count);
    }
    return totalCount;
}
function cartGetTotalPrice() {

    var totalPrice = 0;
    var array = getCartObj();

    for (var n in array) {
        var proPrice = array[n].count * array[n].price;
        totalPrice += proPrice;
    }
    return Math.round(totalPrice * 100) / 100;

}

//shopping cart end


function selectProduct() {

    var strPro = document.getElementById("prolist").value;
    if (strPro == 0) {
        return;
    }

    var pro = eval('(' + strPro + ')');

    buy(pro.id, pro.name, pro.model, pro.units, 1, pro.price);

}

function gotoPage(url) {
    var page = document.getElementById("gotoPage").value;

    window.location.href = url + page;
}

function hiddenRoutes() {
    var param = '';
    var check = 0;
    var if_hide = 0;

    $("input[name='routeCheckbox']").each(function(i) {
        if ($(this).attr("checked") == true) {
            if (check == 0) {
                if (window.confirm('您确定要隐藏所选线路吗？')) {
                    if_hide = 1;
                }
                check = 1;
            }
            param += $(this).val() + ',';
        }
    });
    if (if_hide == 1) {
        if (param == '') {
            alert('请至少选择1条线路！');
            return;
        } else {
            param = param.substr(0, param.length - 1);
        }
        ajaxActionRoute("ac=HiddenRoutes&ids=" + param, param, true);
    }
}

function displayRoutes() {
    var param = '';
    var check = 0;
    var if_hide = 0;

    $("input[name='routeCheckbox']").each(function(i) {
        if ($(this).attr("checked") == true) {
            if (check == 0) {
                if (window.confirm('您确定要显示所选线路吗？')) {
                    if_hide = 1;
                }
                check = 1;
            }
            param += $(this).val() + ',';
        }
    });
    if (if_hide == 1) {
        if (param == '') {
            alert('请至少选择1条线路！');
            return;
        } else {
            param = param.substr(0, param.length - 1);
        }
        ajaxActionRoute("ac=DisplayRoutes&ids=" + param, param, true);
    }
}
function selectAllRoute(ckAll) {
    if (ckAll.checked == true) {
        $("input[name='routeCheckbox']").each(function(i) {
            $(this).attr("checked",true);
        });
    } else {
        $("input[name='routeCheckbox']").each(function(i) {
            $(this).attr("checked",false);
        });
    }
}
function hiddenNews() {
    var param = '';
    var check = 0;
    var if_hide = 0;

    $("input[name='newsCheckbox']").each(function(i) {
        if ($(this).attr("checked") == true) {
            if (check == 0) {
                if (window.confirm('您确定要隐藏所选文章吗？')) {
                    if_hide = 1;
                }
                check = 1;
            }
            param += $(this).val() + ',';
        }
    });
    if (if_hide == 1) {
        if (param == '') {
            alert('请至少选择1篇文章！');
            return;
        } else {
            param = param.substr(0, param.length - 1);
        }
        ajaxActionRoute("ac=HiddenNews&ids=" + param, param, true);
    }
}

function displayNews() {
    var param = '';
    var check = 0;
    var if_hide = 0;

    $("input[name='newsCheckbox']").each(function(i) {
        if ($(this).attr("checked") == true) {
            if (check == 0) {
                if (window.confirm('您确定要显示所选文章吗？')) {
                    if_hide = 1;
                }
                check = 1;
            }
            param += $(this).val() + ',';
        }
    });
    if (if_hide == 1) {
        if (param == '') {
            alert('请至少选择1篇文章！');
            return;
        } else {
            param = param.substr(0, param.length - 1);
        }
        ajaxActionRoute("ac=DisplayNews&ids=" + param, param, true);
    }
}
function deleteNews() {
    var param = '';
    var check = 0;
    var if_hide = 0;

    $("input[name='newsCheckbox']").each(function(i) {
        if ($(this).attr("checked") == true) {
            if (check == 0) {
                if (window.confirm('删除后不可恢复，您确定要删除所选文章吗？')) {
                    if_hide = 1;
                }
                check = 1;
            }
            param += $(this).val() + ',';
        }
    });
    if (if_hide == 1) {
        if (param == '') {
            alert('请至少选择1篇文章！');
            return;
        } else {
            param = param.substr(0, param.length - 1);
        }
        ajaxActionRoute("ac=DeleteNews&ids=" + param, param, true);
    }
}
function selectAllNews(ckAll) {
    if (ckAll.checked == true) {
        $("input[name='newsCheckbox']").each(function(i) {
            $(this).attr("checked", true);
        });
    } else {
        $("input[name='newsCheckbox']").each(function(i) {
            $(this).attr("checked", false);
        });
    }
}
function updateAdSize(f) {
    var o = $("#position");
    var aid = o.val();
    var size = o.find("option:selected").attr("data");
    $("#adsize").html(size);
    document.getElementById("imgSize").value = size;
}
function UpdateOrderDetailPrice(id, no) {

    var price = document.getElementById("price_" + id).value;

    if ($.trim(price) == "") {
        alert('请输入价格');
        return;
    }
    if (!is_int(price)) {
        alert('请正确输入价格');
        return;
    }
    
    ajaxActionRoute("ac=UpdateOrderDetailPrice&id=" + id + "&no=" + no + "&price=" + price, id, true);
}
function refreshLinks() {
    alert("开始更新内链,请稍等...");
    $.ajax({ url: url + "ac=RefreshLinks", type: "GET", dataType: "text",
        error: function(XMLHttpRequest) { alert(systemTip.other); },
        success: function(data) {
            if (data == "success") {
                alert(systemTip.success);
            } else {
                alert(systemTip.error);
            }
        }
    });
}
function setNewsImg(id) {
    alert("开始更新文章图片,请稍等...");
    $.ajax({ url: url + "ac=setNewsImg&id="+id, type: "GET", dataType: "text",
        error: function(XMLHttpRequest) { alert(systemTip.other); },
        success: function(data) {
            if (data == "success") {
                alert(systemTip.success);
            } else {
                alert(systemTip.error);
            }
        }
    });
}
function updateNewsImg() {
    alert("开始更新景点图片大小,请稍等...");
    $.ajax({ url: url + "ac=updateNewsImg", type: "GET", dataType: "text",
        error: function(XMLHttpRequest) { alert(systemTip.other); },
        success: function(data) {
            if (data == "success") {
                alert(systemTip.success);
            } else {
                alert(systemTip.error);
            }
        }
    });
}
function updateRouteImg() {
    alert("开始更新线路图片大小,请稍等...");
    $.ajax({ url: url + "ac=updateRouteImg", type: "GET", dataType: "text",
        error: function(XMLHttpRequest) { alert(systemTip.other); },
        success: function(data) {
            if (data == "success") {
                alert(systemTip.success);
            } else {
                alert(systemTip.error);
            }
        }
    });
}
function setPriceByDay() {
    document.getElementById('datePriceLayer').style.display = 'block';
    $(".setprice").show();
}
function setPriceEveryDay() {
    document.getElementById('datePriceLayer').style.display = 'none';
    $(".setprice").hide();
}
function GrapBaiduMsg() {
    alert("开始抓取问答,请稍等...");
    $.ajax({ url: url + "ac=GrapBaiduMsg", type: "GET", dataType: "text",
        error: function(XMLHttpRequest) { alert(systemTip.other); },
        success: function(data) {
            if (data == "success") {
                alert(systemTip.success);
                location.reload();
            } else {
                alert(systemTip.error);
            }
        }
    });
}
function updateImgAddress() {
    alert("开始更新图片地址,请稍等...");
    $.ajax({ url: url + "ac=updateImgAddress", type: "GET", dataType: "text",
        error: function(XMLHttpRequest) { alert(systemTip.other); },
        success: function(data) {
            if (data == "success") {
                alert(systemTip.success);
            } else {
                alert(systemTip.error);
            }
        }
    });
}
function UpdateQQorder(id) {
    var qqOrderName = document.getElementById("QQorder_" + id);
    var qqOrder = qqOrderName.value;
    ajaxActionRoute("ac=UpdateQQorder&id=" + id + "&qqOrder=" + qqOrder, id, true);
}
function CustomerDelete(id) {
    if (!confirm(systemTip.del)) return;
    ajaxActionRoute("ac=CustomerDelete&id=" + id, id, true);
}
function DisplayCustomer(id, inUse) {
    ajaxActionRoute("ac=DisplayCustomer&id=" + id + "&inuse=" + inUse, id, true);
}
function formCustomer(f) {
    if (f.CName.value.IsNull()) {
        alert("请输入客服名称！");
        f.CName.focus();
        return false;
    }
    if (f.QQNumber.value.IsNull()) {
        alert("请输入QQ号码！");
        f.QQNumber.focus();
        return false;
    }
    if (f.Phone.value.IsNull()) {
        alert("请输入客服电话！");
        f.Phone.focus();
        return false;
    }
    if (!f.QQorder.value.IsNull()) {
        if (!is_int(f.QQorder.value) && f.QQorder.value != "0") {
            alert("QQ排序只能输入整数");
            f.QQorder.focus();
            return false;
        }
    }
}
function seoClassChange(o) {
    GetSmallClass(o);
    UpdateSeoDays(o.value);
    UpdateSeoPrice(o.value);
    if (o.value == "5") {
        $("#trTheme").hide();
    } else {
        $("#trTheme").show();
    }
}
function UpdateSeoDays(id) {
    var days = "<option value='0'>==请选择==</option>";
    if (id == "2") {
        days += "<option value='5'>五日游及以下</option>";
        days += "<option value='6'>六日游</option>";
        days += "<option value='7'>七日游</option>";
        days += "<option value='8'>八日游</option>";
        days += "<option value='9'>九日游</option>";
        days += "<option value='10'>十日游</option>";
        days += "<option value='11'>十一日游及以上</option>";
    } else if (id != "0") {
        days += "<option value='1'>一日游</option>";
        days += "<option value='2'>二日游</option>";
        days += "<option value='3'>三日游</option>";
        days += "<option value='4'>四日游</option>";
        days += "<option value='5'>五日游</option>";
        days += "<option value='6'>六日游</option>";
        days += "<option value='7'>七日游及以上</option>";
    }
    $("#routeDays").empty();
    $("#routeDays").append(days);
}
function UpdateSeoPrice(id) {
    var price = "<option value=''>==请选择==</option>";
    if (id == "2") {
        price += "<option value='0-3000'>3000以下</option>";
        price += "<option value='3000-8000'>3000-8000元</option>";
        price += "<option value='8000-15000'>8000-15000元</option>";
        price += "<option value='15000-20000'>15000-20000元</option>";
        price += "<option value='20000-0'>20000元以上</option>";
    } else if (id != "0") {
        price += "<option value='0-500'>500以下</option>";
        price += "<option value='500-1500'>500-1500元</option>";
        price += "<option value='1500-3000'>1500-3000元</option>";
        price += "<option value='3000-10000'>3000-10000元</option>";
        price += "<option value='10000-0'>10000元以上</option>";
    }
    $("#routePrice").empty();
    $("#routePrice").append(price);
}
function seoInfoDelete(id) {
    ajaxAction("ac=seoInfoDelete&id=" + id, id, false);
}
function formSeoInfo(f) {
    if (f.classId1.valueOf == "0") {
        alert("请选择目的地！");
        return false;
    }
    if (f.themeId.valueOf == "0" && f.routeDays.valueOf == "0" && f.routePrice.valueOf == "") {
        alert("请选择组合条件！");
        return false;
    }
}
function deleteLinks() {
    var param = '';
    var check = 0;
    var if_hide = 0;

    $("input[name='linksCheckbox']").each(function (i) {
        if ($(this).attr("checked") == true) {
            if (check == 0) {
                if (window.confirm('删除后不可恢复，您确定要删除所选链接吗？')) {
                    if_hide = 1;
                }
                check = 1;
            }
            param += $(this).val() + ',';
        }
    });
    if (if_hide == 1) {
        if (param == '') {
            alert('请至少选择1个链接！');
            return;
        } else {
            param = param.substr(0, param.length - 1);
        }
        ajaxActionRoute("ac=DeleteLinks&ids=" + param, param, true);
    }
}
function selectAllLinks(ckAll) {
    if (ckAll.checked == true) {
        $("input[name='linksCheckbox']").each(function (i) {
            $(this).attr("checked", true);
        });
    } else {
        $("input[name='linksCheckbox']").each(function (i) {
            $(this).attr("checked", false);
        });
    }
}
function route_add_file() {
    
    var div = document.getElementById('fileImages');

    var i, days = 0;
    var last_set_node = null;
    var ds = div.getElementsByTagName('div');

    last_set_node = ds[ds.length - 1];

    var node = document.createElement('div');

    node.innerHTML = "<input type=\"file\" name=\"Image\" onchange=\"CheckImgFile(this)\" />";

    div.insertBefore(node, last_set_node.nextSibling);

}
$(document).ready(function () {
    $(".rorder").click(function () {
        $("#torder").val("0");
        var ro = $("#rorder").val();
        if (ro == "1") {
            //$(".rorder").css("background-image", "url(images/icon_down.png)");
            $("#rorder").val("2");
            $(".form-div").submit();
        } else {
            //$(".rorder").css("background-image", "url(images/icon_up.png)");
            $("#rorder").val("1");
            $(".form-div").submit();
        }
    });
    $(".torder").click(function () {
        $("#rorder").val("0");
        var to = $("#torder").val();
        if (to == "1") {
            //$(".torder").css("background-image", "url(images/icon_up.png)");
            $("#torder").val("2");
            $(".form-div").submit();
        } else {
            //$(".torder").css("background-image", "url(images/icon_down.png)");
            $("#torder").val("1");
            $(".form-div").submit();
        }
    });
    $(".sorder").click(function () {
        var ro = $("#sorder").val();
        if (ro == "1") {
            $("#sorder").val("2");
            $(".form-div").submit();
        } else {
            $("#sorder").val("1");
            $(".form-div").submit();
        }
    });
});
function updateOrderIcon() {
    var ro = $("#rorder").val();
    if (ro == "1") {
        $(".rorder").css("background-image", "url(/WebManage/css/images/icon_up.png)");
    } else if (ro == "2") {
        $(".rorder").css("background-image", "url(/WebManage/css/images/icon_down.png)");
    }
    var to = $("#torder").val();
    if (to == "1") {
        $(".torder").css("background-image", "url(/WebManage/css/images/icon_down.png)");
    } else if (to == "2") {
        $(".torder").css("background-image", "url(/WebManage/css/images/icon_up.png)");
    }
}
function updateSaleOrderIcon() {
    var ro = $("#sorder").val();
    if (ro == "1") {
        $(".sorder").css("background-image", "url(/WebManage/css/images/icon_up.png)");
    } else if (ro == "2") {
        $(".sorder").css("background-image", "url(/WebManage/css/images/icon_down.png)");
    }
}
function UpdateSaleOrder(id) {
    var saleOrderName = document.getElementById("SaleOrder_" + id);
    var saleOrder = saleOrderName.value;
    ajaxActionRoute("ac=SaleOrderUpdate&id=" + id + "&saleOrder=" + saleOrder, id, false);
}
function SubmitSale() {
    $("#sorder").val("0");
}
function SubmitRoute() {
    $("#rorder").val("0");
    $("#torder").val("0");
}