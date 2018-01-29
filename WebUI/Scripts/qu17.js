var systemTip = {
    other: '网络故障，请刷新后再试...',
    success: '操作成功',
    error: '操作失败，请刷新后再试...',
    del: '确定要删除吗？',
    del2: '数量减为0，确定要删除吗？',
    delmore: '请选择要删除的数据',
    errorcode: '验证码输入有误',
    areakey: '请输入目的地国家、城市',
    scenickey: '请输入景点名称',
    articlekey:'请输入攻略关键词',
    routekey:'请输入线路编号'
}, empty = '', Myurl = '/WebService.ashx?';
function is_int(str) {
    var r = /^[0-9]*[1-9][0-9]*$/;
    if (r.test(str) == false) {
        return false;
    }
    return true;
}
jQuery.fn.extend({
    selectout: function(options) {
        return this.each(function() {
            new jQuery.SelectOut(this, options);
        });
    }
});

jQuery.SelectOut = function (selectobj, options) {

    var opt = options || {};

    var elm_id = selectobj.id;

    // jquery container object
    //var $container = $(selectobj).parent().find("#" + elm_id + "_box");

    $(document)
	.click(function (e) {
	    e = window.event || e; // 兼容IE7
	    obj = $(e.srcElement || e.target);
	    if (obj.attr('class') && obj.attr('class').indexOf($(selectobj).attr('class')) != -1) return;
	    if (!obj.attr('id') || obj.attr('id').indexOf(elm_id) == -1) {
	    	if ($container.is(':visible')) {
	    	    $container.hide();
	    	}
	    }
	});
}
$(document).ready(function () {
    //$("img").lazyload({ threshold: 200, effect: "fadeIn", skip_invisible: false });

    $("#contact_btn").click(function () {
        var oBtn = document.getElementById('contact_btn');
        if (oBtn.className == "contact_hide") {
            $(".contact_nav").css({ "height": "0px" });
            setTimeout(function () {
                oBtn.className = "contact_show";
                oBtn.innerHTML = "展开联系方式";
                $(".bottom_blank").hide();
            }, 900);
        } else {
            $(".contact_nav").css({ "height": "60px" });
            setTimeout(function () {
                oBtn.className = "contact_hide";
                oBtn.innerHTML = "隐藏联系方式";
                $(".bottom_blank").show();
            }, 900);
        }
    });

    $("#roaddate").click(function (e) {
        $(".dateprice").show();
        var ev = e || window.event;
        if (ev.stopPropagation) {
            ev.stopPropagation();
        }
        else if (window.event) {
            window.event.cancelBubble = true; //兼容IE
        }
    });
    document.onclick = function () {
        $(".dateprice").hide();
    }
    $(".dateprice").click(function (e) {
        var ev = e || window.event;
        if (ev.stopPropagation) {
            ev.stopPropagation();
        }
        else if (window.event) {
            window.event.cancelBubble = true; //兼容IE
        }
    });
    $(".closeqq").click(function () {
        $(".closeqq").hide();
        $(".contacttype").hide(1000, function () {
            $(".openqq").show();
            $(".bottom_blank").hide();
        });
    });
    $(".openqq").click(function () {
        $(".openqq").hide();
        $(".contacttype").show(1000, function () {
            $(".closeqq").show();
            $(".bottom_blank").show();
        });
    });
    var url = window.location.pathname;
    if (url != "/" && url.indexOf("default") < 0) {
        $("#myNav").hover(
        function () {
            $(this).find(".nav_menu").show();
        },
        function () {
            $(this).find(".nav_menu").hide();
        });
    }
    //鼠标移上去显示线路
    $("#myNav .menu_items").hover(
		function () {
		    $(this).find(".menu_left").addClass("active");
		    //$(this).find(".menu_left a").css({ "color": "#37c249" });
		    $(this).find(".menu_left").css({ "z-index": "330" });
		    $(this).find(".menu_left").css({ "position": "relative" });
		    $(this).find(".menu_details").show();
		    $(this).find(".menu_left .item_more").hide();
		    $(this).find("img.lazy").lazyload();
		},
  		function () {
  		    $(this).find(".menu_left").removeClass("active");
  		    //$(this).find(".menu_left a").css({ "color": "#FFFFFF" });
  		    $(this).find(".menu_left").css({ "position": "" });
  		    $(this).find(".menu_details").hide();
  		    $(this).find(".menu_left .item_more").show();
  		}
	);
    $(".morearea").click(function () {
        $("#more_area").find(".hide").show();
        $(this).hide();
    });
    $(".moretheme").click(function () {
        $("#more_theme").find(".hide").show();
        $(this).hide();
    });
    $(".side_nav_items .nav_items_title").click(function () {
        $(".side_nav_items .nav_items_title").removeClass("on");
        $(".side_nav_items .nav_items_list").hide();

        $(this).addClass("on");
        $(this).parent().find(".nav_items_list").show();
    });
    $(".side_rec_items li").hover(function () {
        $(".side_rec_items li").removeClass("on");
        $(this).addClass("on");
    });
});
var JSON = {

    ToString: function(items) {

        if (typeof items != "object")
            return "[]";

        var str = "[";

        for (var i in items) {

            str += "{";

            for (var n in items[i]) {

                var ty = typeof items[i][n];

                switch (ty) {

                    case "string": str += '"' + n + '"' + ':' + '"' + items[i][n] + '"' + ','; break;

                    case "number": str += '"' + n + '"' + ':' + items[i][n] + ','; break;

                    case "boolean": str += '"' + n + '"' + ':' + items[i][n] + ','; break;
                }

            }

            str += "},";

        }

        str += "]";

        str = str.replace(/,}/g, "}").replace(",]", "]");
        return str;

    },

    ForString: function(str) {

        if (typeof str != "string")
            return null;

        return eval('(' + str + ')');

    }

};
location
function AddFavorite() {
    var title = document.title;

    var url = location.href;

    /*if (window.sidebar) {
        window.sidebar.addPanel(title, url, "");
    }
    else if (document.all) {*/
        window.external.AddFavorite(url, title);
    /*}
    else {
        return true;
    }*/
        return false;
}
//cookie
function SetHomePage() {
    var host = location.href;
    host = host.replace("//", "#");
    host = host.substr(0, host.indexOf("/")).replace("#", "//");
    if (document.all) {
        document.body.style.behavior = 'url(#default#homepage)';
        document.body.setHomePage(host);
    }
    else if (window.sidebar) {
        if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            }
            catch (e) {
                alert("该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值该为true");
            }
        }
        var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
        prefs.setCharPref('browser.startup.homepage', host);
    }
}
//end
function checkMobile(f) {
    var mobile = f.value;
    if (mobile != "") {
        if (mobile.length != 11) {
            $("#chkmobile").show();
        } else if (!is_int(mobile)) {
            $("#chkmobile").show();
        } else {
            $("#chkmobile").hide();
        }
    } else {
        $("#chkmobile").hide();
    }
}
function checkEmail(f) {
    var email = f.value;
    if (email != "" && email.indexOf("@") == -1) {
        $("#chkemail").show();
    } else {
        $("#chkemail").hide();
    }
}

function ChangeCode() {
    var _code = document.getElementById("imgcode");
    _code.src = '/random.aspx?data=' + new Date();
}
//判断浏览器类型
function getNagType() {
    var type = navigator.appName;
    var version = navigator.appVersion;
    if (type == "Microsoft Internet Explorer") {
        var start = version.indexOf("MSIE");
        var end = version.indexOf(";", start);
        version = version.substring(start + 5, end);
        type = "IE";
    }
    version = parseFloat(version);
    return type + version;
}
function checkCurrentFilter(cFilter) {
    $("#rootlist_search_ture").html($("#rootlist_search_ture").html() + cFilter);
    if (cFilter.indexOf("景点：") < 0 && $("#areaFilter")) {
        $("#areaFilter").find(".item_list .item_cur a").css({ "background-color": "#ffa901", "color": "#FFF" });
        $("#areaFilter").find(".item_list .item_cur a").attr("href", "javascript:void(0);");
    }
    if (cFilter.indexOf("主题：") < 0 && $("#themeFilter")) {
        $("#themeFilter").find(".item_list .item_cur a").css({ "background-color": "#ffa901", "color": "#FFF" });
        $("#themeFilter").find(".item_list .item_cur a").attr("href", "javascript:void(0);");
    }
    if (cFilter.indexOf("价格：") < 0 && $("#priceFilter")) {
        $("#priceFilter").find(".item_list .item_cur a").css({ "background-color": "#ffa901", "color": "#FFF" });
        $("#priceFilter").find(".item_list .item_cur a").attr("href", "javascript:void(0);");
    }
    if (cFilter.indexOf("天数：") < 0 && $("#daysFilter")) {
        $("#daysFilter").find(".item_list .item_cur a").css({ "background-color": "#ffa901", "color": "#FFF" });
        $("#daysFilter").find(".item_list .item_cur a").attr("href", "javascript:void(0);");
    }
}
function gotoDataList(f) {
    var sk = f.sous.value;

    if (sk == "") {
        alert("请输入目的地国家、城市");
        f.sous.focus();
        return false;
    }
    var curUrl = "/rkey" + encodeURI(sk) + "/";
    
    $(f).attr("action", curUrl);
}

function clk_hotel(e, t) {
    $(".condition_item p").each(function() {
        if ($(this).attr("data") == t) {
            var url = $(this).parent().find(".item_list .item_cur a").attr("href");
            location.href = url;
        }
    });
}
function RouteSort(url, f) {
    var vo = $(f).attr("data");
    if (vo != 0) {
        if (vo == 1) {
            $(f).attr("data", 2);
            url = url + "order1";
        } else if (vo == 2) {
            $(f).attr("data", 1);
            url = url + "order2";
        } else if (vo == 3) {
            $(f).attr("data", 4);
            url = url + "order3";
        } else if (vo == 4) {
            $(f).attr("data", 3);
            url = url + "order4";
        }
    } else {
        var cn = $(f).parent().attr("class");
        if (cn == "on") return;
    }
    location.href = url;
}
//cookie
//参数
function GetRequest() {
    var url = location.search; //获取url中"?"符后的字串
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
        }
    }
    return theRequest;
};
function GetCookieVal(offset) {
    var endstr = document.cookie.indexOf(";", offset);
    if (endstr == -1)
        endstr = document.cookie.length;
    return decodeURI(document.cookie.substring(offset, endstr));
}
function SetCookie(name, value, expires, path) {
    var expdate = new Date();
    var argv = SetCookie.arguments;
    var argc = SetCookie.arguments.length;
    var path = (argc > 3) ? argv[3] : null;
    var domain = (argc > 4) ? argv[4] : null;
    var secure = (argc > 5) ? argv[5] : false;
    expdate.setTime(expdate.getTime() + (expires * 24 * 3600 * 1000));
    document.cookie = name + "=" + encodeURI(value) + ((expires == null) ? "" : ("; expires=" + expdate.toGMTString()))
+ ((secure == true) ? "; secure" : "") + ((path == null) ? "" : ("; path=" + path)) + (domain ? "; domain=" + domain : "");
}
function DelCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    document.cookie = name + "=; expires=" + exp.toGMTString();
}
function GetCookie(name) {
    var arg = name + "=";
    var alen = arg.length;
    var clen = document.cookie.length;
    var i = 0;
    while (i < clen) {
        var j = i + alen;
        if (document.cookie.substring(i, j) == arg)
            return GetCookieVal(j);
        i = document.cookie.indexOf(" ", i) + 1;
        if (i == 0) break;
    }
    return null;
}
var cRouteName = "cartRoute";
var routeViewBox = "routeViewBox";
function getCartObject(name) {

    var array = [];

    var oldList = GetCookie(name);

    if (oldList && oldList != "null") {
        array = JSON.ForString(oldList);
    }

    return array;

}
function pushRoutes(id, name, price, img, pingyin) {

    var existsObj = false;

    var obj = { id: id, img: img, name: name, pingyin: pingyin, price: price };
    
    var array = getCartObject(cRouteName);
    for (var n in array) {

        if (obj.id == array[n].id) {
            //existsObj = true;
            array = array.slice(0, n).concat(array.slice(n + 1));
            break;
        }
    }
    //if (!existsObj)
    array.push(obj);

    SetCookie(cRouteName, JSON.ToString(array), 365, "/");

}

$("#routeday_menu ul li").click(function() {
    var o = $(this);
    o.siblings('li').removeClass('on');
    o.addClass('on');
    var cIndex = o.parent().children().index(this);
    $("html,body").animate({ scrollTop: $(".routeday_content .content_items").eq(cIndex).offset().top - 110 }, 0);
});
//单击线路菜单跳到该项目
$(document).on("click", ".rd_menu ul li", function() {
    var o = $(this);
    o.siblings('li').removeClass('on');
    o.addClass('on');
    var cIndex = o.parent().children().index(this);
    var type = $(".rd_menu").css("position");
    if (type != "fixed") {
        $("html,body").animate({ scrollTop: $(".rd_item").eq(cIndex).offset().top - 144 }, 0);
    } else {
        $("html,body").animate({ scrollTop: $(".rd_item").eq(cIndex).offset().top - 104 }, 0);
    }
});

function scoll() {
    //滚动条滑动时线路描述跟随滚动条滑动
    var o = $(".rd_menu");
    var top = o.offset().top;
    var nagType = getNagType();
    $(window).scroll(function () {
        var st = $(this).scrollTop();
        if (st + 30 > top) {
            if (nagType == "IE6") {
                var temTop = (st - top) + "px";
                o.css({ 'position': "absolute", "top": temTop });
                //o.attr("style", "position:absolute;top:" + temTop);
            }
            else {
                o.attr("style", "position:fixed;top:2px;");
            }
            $(".rd_booking").show();
        }
        else {
            if (nagType.indexOf("IE") >= 0) {
                o.css({ 'position': "" });
                o.attr("style", "position:relative;");
            }
            else {
                o.attr("style", "position:relative;");
            }
            $(".rd_booking").hide();
        }
        if (st < $(".routedetailed_dcontent").eq(0).offset().top) {
            $(".rd_menu").find("ul").find("li").removeClass("on");
            $(".rd_menu").find("ul").find("li").eq(0).addClass("on");
        }
        $(".rd_item").each(function (i) {
            var item = $(this);
            var itemtop = $(this).offset().top;
            if (st + 150 > itemtop) {
                o.find("ul").find("li").removeClass("on");
                o.find("ul").find("li").eq($(".rd_item").index(this)).addClass("on");
            }
        });

    });
    //滚动条滑动时线路描述跟随滚动条滑动    end
}
function scollrout() {
    scoll();
    var dayheight = parseInt($(".rd_description").css("height"));
    var daytop = $(".rd_description").offset().top;
    var nagType = getNagType();
    //var o = $(".rootdetailed_dcontent_menu").css("height");
    $(window).scroll(function () {
        var st = $(this).scrollTop();
        //alert(daytop + "   " + dayheight + "   " + st);
        if (st + 80 > daytop && st + 200 <= daytop + dayheight) {
            var temTop = (st - 200) + "px";
            if (nagType == "IE6") {
                $("#routeday_menu").css({ "position": "absolute", "top": temTop });
            }
            else {
                $("#routeday_menu").attr("style", "position:fixed;top:70px;");
            }
        }
        else {
            if (nagType.indexOf("IE") >= 0) {
                $("#routeday_menu").css({ 'position': "" });
                $("#routeday_menu").attr("style", "position:absolute;");
            }
            else {
                $("#routeday_menu").attr("style", "position:absolute;");
            }
        }
        if ($(".routeday_content .content_items").length > 0) {
            if (st < $(".routeday_content .content_items").eq(0).offset().top) {
                $("#routeday_menu ul li").removeClass("on");
                $("#routeday_menu ul li").eq(0).addClass("on");
            }

            $(".routeday_content .content_items").each(function (i) {
                var daytopt = $(this).offset().top;

                if (st + 120 > daytopt) {
                    $("#routeday_menu ul li").removeClass("on");
                    $("#routeday_menu ul li").eq($(".routeday_content .content_items").index(this)).addClass("on");
                }
            });
        }
        //滚动条滑动时天数菜单跟随滚动条滑动   end
    });
}
$(".info_img_small ul li").hover(function() {
    $(".info_img_small ul li").removeClass("on");
    $(this).addClass("on");

    var imgurl = $(this).find("img").attr("src");
    $(".info_img_big").find("img").attr("src", imgurl);
});
//减人数
$(".price_minus").click(function() {
    var num = parseInt($(this).parent().find(".price_num").val());
    if (num > 0) {
        num = num - 1;
        $(this).parent().find(".price_num").val(num);
    }
});
//加人数
$(".price_add").click(function() {
    var num = parseInt($(this).parent().find(".price_num").val());
    num = num + 1;
    $(this).parent().find(".price_num").val(num);
});
function clearCart() {
    SetCookie("shopcart", "[]", 1, "/");
    showCart();
}
function releaseCart() {
    SetCookie("shopcart", "[]", 1, "/");
}
function showCart() {

    if (!document.getElementById(cartWrapID)) {
        return;
    }
    var cartHtml = "";
    var array = getCartObj();
    for (var n in array) {
        var p = array[n];

        var proPrice = p.adultprice * p.adultnum + p.childprice * p.childnum;
        var viewPage = "http://www.qu17.com/" + p.py + "/" + p.id + ".html";

        cartHtml += '<table class="tableCart_list" id="cartList' + p.id + '_' + p.starttime + '" cellpadding="0" cellspacing="0">';
        cartHtml += '<colgroup>';
        cartHtml += '<col width="30%" />';
        cartHtml += '<col width="10%" />';
        cartHtml += '<col width="10%" />';
        cartHtml += '<col width="10%" />';
        cartHtml += '<col width="10%" />';
        cartHtml += '<col width="10%" />';
        cartHtml += '<col width="10%" />';
        cartHtml += '<col width="10%" />';
        cartHtml += '</colgroup>';
        cartHtml += '<tbody>';
        cartHtml += '<tr>';
        cartHtml += '<td style="text-align:left; padding-left:8px;"><a href="' + viewPage + '" target="_blank">' + p.name + '</a></td>';
        cartHtml += '<td>' + p.starttime + '</td>';
        cartHtml += '<td>' + p.adultprice + '元</td>';
        cartHtml += '<td>';
        cartHtml += '<input type="text" class="text" maxlength="3" id="adultcount_' + p.id + '_' + p.starttime + '" value="' + p.adultnum + '" />';
        cartHtml += '<input type="button" class="button" value="修改" onclick="catChangeCount(' + p.id + ',' + p.adultprice + ',' + p.childprice + ',\'' + p.starttime + '\')" />';
        cartHtml += '</td>';
        cartHtml += '<td>' + p.childprice + '元</td>';
        cartHtml += '<td>';
        cartHtml += '<input type="text" class="text" maxlength="3" id="childcount_' + p.id + '_' + p.starttime + '" value="' + p.childnum + '" />';
        cartHtml += '<input type="button" class="button" value="修改" onclick="catChangeCount(' + p.id + ',' + p.adultprice + ',' + p.childprice + ',\'' + p.starttime + '\')" />';
        cartHtml += '</td>';
        cartHtml += '<td><strong class="color1" id="proPrice_' + p.id + '_' + p.starttime + '">' + proPrice + '元</strong></td>';
        cartHtml += '<td><a class="del" title="删除" onclick="deleteCart(' + p.id + ',\'' + p.starttime + '\')"></a></td>';
        cartHtml += '</tr>';
        cartHtml += '</tbody>';
        cartHtml += '</table>';

        //cartHtml = cartHtml.Format(p.id, p.name, viewPage, p.starttime, p.adultprice, p.adultnum, p.childprice, p.childnum, proPrice);
        //return event.keyCode >= 48 && event.keyCode <= 57
    }
    cartGetTotalCount();

    document.getElementById(cartWrapID).innerHTML = cartHtml;

    document.getElementById("totalPrice").innerHTML = cartGetTotalPrice(); ;

    changeCartCount();

}
function catChangeCount(pid, adultprice, childprice, starttime) {

    var adultcount = document.getElementById("adultcount_" + pid + "_" + starttime).value;

    if (!/^\d+$/.test(adultcount) || adultcount == 0) {
        //adultcount = 1;
        document.getElementById("adultcount_" + pid + "_" + starttime).value = adultcount;
    }

    var childcount = document.getElementById("childcount_" + pid + "_" + starttime).value;

    if (!/^\d+$/.test(childcount) || childcount == 0) {
        //childcount = 1;
        document.getElementById("childcount_" + pid + "_" + starttime).value = childcount;
    }

    document.getElementById("proPrice_" + pid + "_" + starttime).innerHTML = (adultcount * adultprice + childcount * childprice) + "元";

    var array = getCartObj();
    for (var n in array) {
        if (array[n].id == pid && array[n].starttime == starttime) {
            array[n].adultnum = parseInt(adultcount);
            array[n].childnum = parseInt(childcount);
            break;
        }
    }

    SetCookie("shopcart", JSON.ToString(array), 365, "/");

    cartGetTotalCount();
    document.getElementById("totalPrice").innerHTML = cartGetTotalPrice();

    changeCartCount();
}

function changeCartCount() {
    if (document.getElementById("cartCount")) {
        document.getElementById("cartCount").innerHTML = cartGetRowsCount();
    }
}
function cartGetRowsCount() {
    var totalCount = 0;
    var array = getCartObject("shopcart");
    totalCount = array.length;
    return totalCount;
}
function cartGetTotalCount() {

    var totalAdCount = 0;
    var totalChCount = 0;
    var array = getCartObj();

    for (var n in array) {
        totalAdCount += array[n].adultnum * 1;
        totalChCount += array[n].childnum * 1;
    }
    document.getElementById("totalAdCount").innerHTML = totalAdCount;

    document.getElementById("totalChCount").innerHTML = totalChCount;

}
function showOrderCart() {

    if (!document.getElementById(cartWrapID))
        return;

    var cartHtml = "";
    var array = getCartObj();
    var productList = "";
    for (var n in array) {
        var p = array[n];
        var proPrice = p.adultnum * p.adultprice + p.childnum * p.childprice;
        var pcount = p.adultnum + "大" + p.childnum + "小";
        cartHtml += '<tr>';
        cartHtml += '<td align="left">' + p.name + '</td>';
        cartHtml += '<td>' + p.days + '</td>';
        cartHtml += '<td>' + p.starttime + '</td>';
        cartHtml += '<td>' + pcount + '</td>';
        cartHtml += '<td>&yen;' + proPrice + '元</td>';
        cartHtml += '</tr>';
        productList += p.id + ","
                         + p.name + ","
                         + pcount + ","
                         + proPrice + ","
                         + p.days + ","
                         + p.starttime + "|";
    }
    if (productList != "") productList = productList.substr(0, productList.length - 1);
    
    $("#" + cartWrapID + " tbody tr").slice(0).remove();
    $(cartHtml).appendTo("#" + cartWrapID + " tbody");

    var totalPrice = cartGetTotalPrice();

    $("#productList").val(productList);
    $(".txtTotalPrice").html(totalPrice);
    $("#totalPrice").val(totalPrice);
    cartGetTotalCount2();

}
function cartGetTotalCount2() {

    var totalAdCount = 0;
    var totalChCount = 0;
    var array = getCartObj();
    for (var n in array) {
        totalAdCount += array[n].adultnum * 1;
        totalChCount += array[n].childnum * 1;
    }
    document.getElementById("totalAdCount").value = totalAdCount;

    document.getElementById("totalChCount").value = totalChCount;

}
function cartGetTotalPrice() {

    var totalPrice = 0;
    var array = getCartObj();
    for (var n in array) {
        var proPrice = array[n].adultnum * array[n].adultprice + array[n].childnum * array[n].childprice;
        totalPrice += proPrice;
    }
    return totalPrice;

}
function checkout(url) {
    var cartCount = 0;
    var array = getCartObj();
    cartCount = array.length;
    if (cartCount == 0) {
        alert("您的购物车中没有商品");
    } else {
        var exist0 = false;
        for (var n = 0; n < array.length; n++) {
            if (array[n].adultnum == 0) {
                exist0 = true;
                break;
            }
        }
        if (!exist0) {
            location.href = "/" + url + "/";
        } else {
            alert("购物车中有人数为0的线路，请先删除或者修改！");
        }
    }
}
function deleteCart(pid, starttime) {

    var array = getCartObj();

    for (var n = 0; n < array.length; n++) {

        if (pid == array[n].id && starttime == array[n].starttime) {

            array = array.slice(0, n).concat(array.slice(n + 1));

        }
    }

    SetCookie("shopcart", JSON.ToString(array), 365, "/");

    showCart();
}
//查询线路cookic并绑定到页面
//shopping cart
var cartWrapID = "cartWrap";
function buy2(id, name, days, py) {
    var starttime = document.getElementById("stdate").value;
    var adultprice = document.getElementById("aprice").value;
    var childprice = document.getElementById("cprice").value;
    var adultnum = document.getElementById("adnum").value;
    var childnum = document.getElementById("childnum").value;
    if (adultnum == 0 && childnum == 0) {
        alert("请输入预订人数");
        return;
    }
    name = name.replace(/,/g, "，").replace(/\|/g, "｜");
    days = days.replace(/,/g, "，").replace(/\|/g, "｜");

    if (name.length > 15) {
        name = name.substring(0, 14) + "...";
    }

    buy(id, name, days, starttime, adultprice, childprice, adultnum, childnum, py);
}
function getCartObj() {

    var array = [];

    var oldList = GetCookie("shopcart");

    if (oldList && oldList != "null") {
        array = JSON.ForString(oldList);
    }
    return array;
}
function buy(id, name, days, starttime, adultprice, childprice, adultnum, childnum, py) {

    var existsObj = false;
    var num = ""; //编号[没用到]
    var obj = { id: id, name: name, days: days, starttime: starttime,
        adultprice: adultprice, childprice: childprice, adultnum: adultnum, childnum: childnum, py: py
    };

    var array = getCartObj();
    for (var n in array) {

        if (obj.id == array[n].id && obj.starttime == array[n].starttime) {
            existsObj = true;
            array[n].adultnum = array[n].adultnum * 1 + adultnum * 1;
            array[n].childnum = array[n].childnum * 1 + childnum * 1;
            break;
        }

    }
    if (!existsObj)
        array.push(obj);

    SetCookie("shopcart", JSON.ToString(array), 365, "/");
    
    location.href = '/shopcart/';
}
function formForgetpwd(f) {

    if (f.UserName.value == "") {
        alert("请输入您在本站的用户名");
        return false;
    }
}
function formForgetpwd2(f) {

    if (f.SafetyAnswer.value == "") {
        alert("请输入密码保护答案");
        return false;
    }
}
function formForgetpwd3(f) {

    if (f.Password.value == "") {
        alert("请输入新密码");
        return false;
    }
    if (f.Password2.value != f.Password.value) {
        alert("两次密码输入不一致");
        return false;
    }
}
function formOrder(f) {
    if (f.Linkman.value == "") {
        alert("联系人姓名不能为空");
        f.Linkman.focus();
        return false;
    }
    if (f.Mobile.value == "") {
        alert("请输入手机号，以便我们及时与您取得联系");
        f.Mobile.focus();
        return false;
    } else if (f.Mobile.value.length != 11) {
        f.Mobile.focus();
        alert("请输入11位手机号码!");
        return false;
    } else if (!is_int(f.Mobile.value)) {
        f.Mobile.focus();
        alert("手机号码只能为数字!");
        return false;
    }
}
$("#calender td.special").hover(function() {
    var price = $(this).find("a").attr("data").split(',');
    var py = document.getElementById("pingyin").value;
    var rid = document.getElementById("routeID").value;
    var time = document.getElementById("routetime").value;
    var title = document.getElementById("routetitle").value;
    if (title.length > 15) {
        title = title.substring(0, 14) + "...";
    }
    var atprice = "电询";
    var cdprice = "电询";
    if (price[0] != 0) {
        atprice = "&yen;<span>" + price[0] + "</span>元";
    }
    if (price[1] != 0) {
        cdprice = "&yen;<span>" + price[1] + "</span>元";
    }
    var str = "<div class='price_box'>";
    str += "<div class='price_up'></div>";
    //str += "<div class='price_close'></div>";
    str += "<div class='price_box_top'>价格详情(仅供参考)</div>";
    str += "<dl class='price_box_title'><dd>标题</dd><dd>价格</dd></dl>";
    str += "<dl class='price_box_item'><dd>成人</dd><dd class='pricenum'>" + atprice + "</dd></dl>";
    str += "<dl class='price_box_item'><dd>儿童</dd><dd class='pricenum'>" + cdprice + "</dd></dl>";
    //str += "<div class='box_buy'><a onclick='buy(\"" + rid + "\",\"" + title + "\",\"" + time + "\",\"" + $(this).attr("id") + "\",\"" + price[0] + "\",\"" + price[1] + "\",1,0,\"" + py + "\")'>立即预订</a></div>";
    str += "</div>";
    $(this).css("z-index", "20");
    $(this).append(str);

    $(".price_box .price_close").click(function() {
        $(this).parent().parent().css("z-index", "0");
        $(this).parent().hide();
        $(this).parent().remove();
    });
}, function() {
    $(this).css("z-index", "0");
    $(this).children(".price_box").hide();
    $(this).children(".price_box").remove();
});
$(".close_date").click(function () {
    $(".dateprice").hide();
});
$(".price_desc").hover(function() {
    $(".pd_detail").show();
}, function() {
    $(".pd_detail").hide();
});
$(".child_desc").hover(function() {
    $(".cd_detail").show();
}, function() {
    $(".cd_detail").hide();
});

//评论验证
function commentAdd() {
    if ($("#Nickname").val() == "") {
        $("#Nickname").focus();
        alert("昵称不能为空！");
        return false;
    }
    if ($("#Email").val() != "") {
        var email = $("#Email").val();
        if (email != "" && email.indexOf("@") == -1) {
            $("#Email").focus();
            alert("请正确输入联系邮箱!");
            return false;
        }
    }
    if ($("#Content").val() == "") {
        $("#Content").focus();
        alert("评论内容不能为空！");
        return false;
    } else {
        if ($("#Content").val().lenght < 10) {
            $("#Content").focus();
            alert("评论内容至少要有10个字！");
            return false;
        }
        if ($("#Content").val().lenght > 200) {
            $("#Content").focus();
            alert("评论内容最多支持200个字！");
            return false;
        }
    }
    if ($("#yanz").val() == "") {
        $("#yanz").focus();
        alert("验证码不能为空！");
        return false;
    }
}

function Support(id) {
    $.ajax({ url: Myurl + "ac=articleSup&id=" + id, type: "GET", dataType: "text",
        error: function(XMLHttpRequest) { alert(systemTip.other); },
        success: function(data) {
            if (data != "") {
                $("#ads_zan").text(data);
            } else { }
        }
    });
}
function clearFilter(ping, type) {
    var url = 'http://www.qu17.com/' + ping + '/';
    if (type != "") {
        url += type + "/";
    }
    location.href = url;
}
function newBridge() {
    $("#newBridge .nb-icon-base .nb-icon-inner-wrap").css("border-radius", "0px");
    $("#newBridge .nb-invite-wrap-base .nb-invite-btn-base").css("bottom", "8px");
    $("#newBridge .nb-invite-wrap .nb-invite-text").css({ "top": "34px", "left": "58px" });

    var btnHtml = '<a href="javascript:;" target="_self" class="qiao-icon-close"></a><a href="javascript:;" target="_self" class="qiao-icon-min"></a>';
    $("#qiao-icon-wrap").append(btnHtml);

    $(".qiao-icon-close").click(function () {
        $(this).hide();
        $("#nb_icon_wrap").hide();
        $(".qiao-icon-min").show();
    });

    $(".qiao-icon-min").click(function () {
        $(this).hide();
        $("#nb_icon_wrap").show();
        $(".qiao-icon-close").show();
    });
}