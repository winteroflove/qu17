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
    articlekey: '请输入攻略关键词',
    routekey: '请输入线路编号'
}, empty = '', Myurl = '/WebApp/appService.ashx?';
var backtop = function () {
    $("#gotoTop").click(function () {
        $('html,body').animate({ scrollTop: 0 }, 0);
    });
    /*$('html,body').animate({ scrollTop: 0 }, 0);*/
    $(window).scroll(function () {
        var min_height = 240;
        //获取窗口的滚动条的垂直位置
        var s = $(window).scrollTop();
        //当窗口的滚动条的垂直位置大于页面的最小高度时，让返回顶部元素渐现，否则渐隐
        if (s > min_height) {
            //$("#gotoTop").fadeIn(100);
            $("#gotoTop").attr("style", "display:block;");
        } else {
            //$("#gotoTop").fadeOut(200);
            $("#gotoTop").attr("style", "display:none;");
        };
    });
}
var switchdetl = function () {
    $(".detl_nav li").click(function () {
        $(".detl_nav li").removeClass("on");
        $(this).addClass("on");
        $(".detl_content .detl_item").hide();
        $(".detl_content .detl_item").eq($(this).parent().children().index(this)).show();
    });
    //减人数
    $(".minus").click(function () {
        var num = parseInt($(this).parent().find(".price_num").val());
        if (num > 0) {
            num = num - 1;
            $(this).parent().find(".price_num").val(num);
        }
    });
    //加人数
    $(".plus").click(function () {
        var num = parseInt($(this).parent().find(".price_num").val());
        num = num + 1;
        $(this).parent().find(".price_num").val(num);
    });
}
var switchnav = function () {
    $(".mnav_item .nav_left").click(function () {
        $(".mnav_item .nav_left").removeClass("current");
        $(this).addClass("current");
        $(".mnav_item .nav_right").hide();
        $(this).parent().find(".nav_right").show();
    });
    $("#navcj .nrlitem .navgroup .grouplist").click(function () {
        if ($(this).hasClass("on")) {
            $(this).removeClass("on");
            $("#navcj .nrlitem .navlist").hide();
        } else {
            $("#navcj .nrlitem .navgroup .grouplist").removeClass("on");
            $(this).addClass("on");
            $("#navcj .nrlitem .navlist").hide();
            $(this).parent().parent().find(".navlist").show();
        }
    });
    $("#navgn .nrlitem .navgroup .grouplist").click(function () {
        if ($(this).hasClass("on")) {
            $(this).removeClass("on");
            $("#navgn .nrlitem .navlist").hide();
        } else {
            $("#navgn .nrlitem .navgroup .grouplist").removeClass("on");
            $(this).addClass("on");
            $("#navgn .nrlitem .navlist").hide();
            $(this).parent().parent().find(".navlist").show();
        }
    });
    /*$("#navqz .nrlitem .navgroup .grouplist").click(function () {
        if ($(this).hasClass("on")) {
            $(this).removeClass("on");
            $("#navqz .nrlitem .navlist").hide();
        } else {
            $("#navqz .nrlitem .navgroup .grouplist").removeClass("on");
            $(this).addClass("on");
            $("#navqz .nrlitem .navlist").hide();
            $(this).parent().parent().find(".navlist").show();
        }
    });*/
}
var switchvisa = function () {
    $(".visa_items .visa_group .visa_m").click(function () {
        $(".visa_items .visa_group .visa_m").removeClass("on");
        $(this).addClass("on");
        $(".visa_items .visaList").hide();
        $(this).parent().parent().find(".visaList").show();
    });
}
var JSON = {

    ToString: function (items) {

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

    ForString: function (str) {

        if (typeof str != "string")
            return null;

        return eval('(' + str + ')');

    }

};
function is_int(str) {
    var r = /^[0-9]*[1-9][0-9]*$/;
    if (r.test(str) == false) {
        return false;
    }
    return true;
}
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
function getCartObj() {

    var array = [];

    var oldList = GetCookie("shopcart");

    if (oldList && oldList != "null") {
        array = JSON.ForString(oldList);
    }
    return array;
}
function clearCart() {
    SetCookie("shopcart", "[]", 1, "/");
    SetCookie("shopcartvisa", "[]", 1, "/");
}
function buy2(id, name, days, py) {
    clearCart();
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
function showOrderCart(){
    var cartHtml = "";
    var array = getCartObj();
    var productList = "";
    for (var n in array) {
        var p = array[n];
        var proPrice = p.adultnum * p.adultprice + p.childnum * p.childprice;
        var pcount = p.adultnum + "大" + p.childnum + "小";
        cartHtml += '<li>编号：ZQL' + p.id + '</li>';
        var viewPage = "http://m.fireflytrip.com/" + p.py + "/r" + p.id + ".html";
        cartHtml += '<li>名称：<a href="' + viewPage + '">' + p.name + '</a></li>';
        cartHtml += '<li>日期：' + p.starttime + '</li>';
        cartHtml += '<li>天数：' + p.days + '天</li>';
        cartHtml += '<li>人数：成人<input type="text" name="adultnum" id="adultnum" class="numinput" maxlength="3" value="' + p.adultnum + '" onchange="catChangeCount(' + p.id + ',' + p.adultprice + ',' + p.childprice + ',\'' + p.starttime + '\')" />儿童<input type="text" name="childnum" id="childnum" class="numinput" maxlength="3" value="' + p.childnum + '" onchange="catChangeCount(' + p.id + ',' + p.adultprice + ',' + p.childprice + ',\'' + p.starttime + '\')" /></li>';
        cartHtml += '<li>价格：成人<em>' + p.adultprice + '</em>元/人<i></i>儿童<em>' + p.childprice + '</em>元/人</li>';
        
        productList += p.id + ","
                         + p.name + ","
                         + pcount + ","
                         + proPrice + ","
                         + p.days + ","
                         + p.starttime + "|";
    }
    if (productList != "") productList = productList.substr(0, productList.length - 1);

    document.getElementById("orderinfo").innerHTML = cartHtml;

    $("#productList").val(productList);
    var totalPrice = cartGetTotalPrice();

    document.getElementById("op_total").innerHTML = totalPrice + "元";
    //document.getElementById("totalPrice").innerHTML = totalPrice;
    //$("#op_total").val(totalPrice);
    $("#totalPrice").val(totalPrice);
}
function catChangeCount(pid, adultprice, childprice, starttime) {

    var adultcount = document.getElementById("adultnum").value;

    if (!/^\d+$/.test(adultcount) || adultcount == 0) {
        //adultcount = 1;
        document.getElementById("adultnum").value = adultcount;
    }

    var childcount = document.getElementById("childnum").value;

    if (!/^\d+$/.test(childcount) || childcount == 0) {
        //childcount = 1;
        document.getElementById("childnum").value = childcount;
    }

    document.getElementById("op_total").innerHTML = (adultcount * adultprice + childcount * childprice) + "元";

    $("#totalPrice").val(adultcount * adultprice + childcount * childprice);

}
function catChangeVisaCount(price) {

    var adultcount = document.getElementById("adultnum").value;

    if (!/^\d+$/.test(adultcount) || adultcount == 0) {
        //adultcount = 1;
        document.getElementById("adultnum").value = adultcount;
    }

    document.getElementById("op_total").innerHTML = adultcount * price + "元";

    $("#totalPrice").val(adultcount * price);

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

    var cartCount = 0;
    var array = getCartObj();
    cartCount = array.length;
    if (cartCount == 0) {
        alert("您的购物车中没有商品");
        return false;
    }
}
function formVisaOrder(f) {
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

    var cartCount = 0;
    var array = getVisaCartObj();
    cartCount = array.length;
    if (cartCount == 0) {
        alert("您的购物车中没有商品");
        return false;
    }
}
function gotoDataList(f) {
    var sk = f.skey.value;

    if (sk == "") {
        alert("请输入旅游目的地");
        f.skey.focus();
        return false;
    }
    var curUrl = "/rkey" + encodeURI(sk) + "/";

    $(f).attr("action", curUrl);
}
function getVisaCartObj() {

    var array = [];

    var oldList = GetCookie("shopcartvisa");

    if (oldList && oldList != "null") {
        array = JSON.ForString(oldList);
    }
    return array;
}
function buyvisa(cpy, name, price, num, ppy) {
    clearCart();
    var existsObj = false;
    var obj = { cpy: cpy, name: name, price: price, num: num, ppy: ppy };

    var array = getVisaCartObj();
    for (var n in array) {

        if (obj.cpy == array[n].cpy) {
            existsObj = true;
            array[n].num = array[n].num * 1 + num * 1;
            break;
        }

    }
    if (!existsObj)
        array.push(obj);

    SetCookie("shopcartvisa", JSON.ToString(array), 365, "/");

    location.href = '/visacart/';
}

function showVisaCart() {
    var cartHtml = "";
    var array = getVisaCartObj();
    var productList = "";
    var totalPrice = 0;
    for (var n in array) {
        var p = array[n];
        var proPrice = p.num * p.price;
        totalPrice += proPrice;
        var pcount = p.num + "大0小";
        var viewPage = "http://m.fireflytrip.com/" + p.ppy + "/" + p.cpy + ".html";
        cartHtml += '<li>名称：<a href="' + viewPage + '">' + p.name + '旅游签证</a></li>';
        cartHtml += '<li>人数：<input type="text" name="adultnum" id="adultnum" class="numinput" maxlength="3" value="' + p.num + '" onchange="catChangeVisaCount(' + p.price + ')" />人</li>';
        cartHtml += '<li>价格：<em>' + p.price + '</em>元/人</li>';

        productList += p.cpy + ","
                         + p.name + ","
                         + pcount + ","
                         + proPrice + ","
                         + p.ppy + "|";
    }
    if (productList != "") productList = productList.substr(0, productList.length - 1);

    document.getElementById("orderinfo").innerHTML = cartHtml;

    $("#productList").val(productList);
    //var totalPrice = cartGetTotalPrice();
    document.getElementById("op_total").innerHTML = totalPrice + "元";
    $("#totalPrice").val(totalPrice);
}
function ChangeCode() {
    var _code = document.getElementById("imgcode");
    _code.src = '/random.aspx?data=' + new Date();
}
function formMessage(f) {
    var name = document.getElementById("Name").value;
    if (name == "") {
        document.getElementById("Name").focus();
        alert("请输入您的姓名或称呼!");
        return false;
    } else if (name.length > 5) {
        document.getElementById("Name").focus();
        alert("姓名或称呼最多可5个字!");
        return false;
    }
    var mobile = document.getElementById("Mobile").value;

    if (mobile == "") {
        document.getElementById("Mobile").focus();
        alert("请输入联系手机!");
        return false;
    } else if (mobile.length != 11) {
        document.getElementById("Mobile").focus();
        alert("请输入11位手机号码!");
        return false;
    } else if (!is_int(mobile)) {
        document.getElementById("Mobile").focus();
        alert("手机号码只能为数字!");
        return false;
    }
    var title = document.getElementById("Title").value;
    if (title == "") {
        document.getElementById("Title").focus();
        alert("请输入留言标题!");
        return false;
    } else if (title.length > 30) {
        document.getElementById("Title").focus();
        alert("留言标题最多可30个字!");
        return false;
    }
    var content = document.getElementById("Content").value;
    if (content == "") {
        document.getElementById("Content").focus();
        alert("请输入留言内容!");
        return false;
    }
    if (content.length > 200) {
        alert("留言内容请精简到200字以内");
        return false;
    }
    var code = document.getElementById("code").value;
    if (code == "" || !is_int(code)) {
        document.getElementById("code").focus();
        alert("请正确输入验证码!");
        return false;
    }
}
var loadMore = function (cid, pid) {
    $(window).scroll(function () {
        var scrollTop = $(this).scrollTop();               //滚动条距离顶部的高度
        var scrollHeight = $(document).height();           //当前页面的总高度
        var windowHeight = $(this).height();               //当前可视的页面高度
        if (scrollTop + windowHeight >= (scrollHeight - 30)) {    //距离顶部+当前高度 >=文档总高度 即代表滑动到底部 
            if (currentPage > totalPage) {                        //如果加载ajax达到2次 停止加载
                //$(".pagelink").hide();                    //提示滚动 图片隐藏
                return false;                              //如果条件满足 停止运行该判断
            }
            loadMoreRoute(cid, pid); //开始加载ajax
            //$("#loading_text").show();
        }
    });
    function loadMoreRoute(cid, pid) {
        if (currentPage > totalPage || isRequest == false) {
            return currentPage;                       //判断页码是否达到限定的加载次数;
            return false;
        }
        currentPage++;
        isRequest = false;
        var div = document.getElementById('routelist');
        $.ajax({ url: Myurl + "ac=loadMoreRoute&cid=" + cid + "&pid=" + pid + "&page=" + currentPage, type: "GET", dataType: "text",
            error: function (XMLHttpRequest) { alert(systemTip.other); },
            success: function (data) {
                if (data != "") {
                    div.innerHTML = div.innerHTML + data;
                } else { }
                isRequest = true;
            }
        });
        return currentPage;
    }
}
var loadMoreSous = function (skey) {
    $(window).scroll(function () {
        var scrollTop = $(this).scrollTop();               //滚动条距离顶部的高度
        var scrollHeight = $(document).height();           //当前页面的总高度
        var windowHeight = $(this).height();               //当前可视的页面高度
        if (scrollTop + windowHeight >= (scrollHeight - 30)) {    //距离顶部+当前高度 >=文档总高度 即代表滑动到底部 
            if (currentPage > totalPage) {                        //如果加载ajax达到2次 停止加载
                //$(".pagelink").hide();                    //提示滚动 图片隐藏
                return false;                              //如果条件满足 停止运行该判断
            }
            loadMoreSearch(skey); //开始加载ajax
            //$("#loading_text").show();
        }
    });
    function loadMoreSearch(skey) {
        if (currentPage > totalPage || isRequest == false) {
            return currentPage;                       //判断页码是否达到限定的加载次数;
            return false;
        }
        currentPage++;
        isRequest = false;
        var div = document.getElementById('routelist');
        $.ajax({ url: Myurl + "ac=loadMoreSearch&skey=" + encodeURIComponent(skey) + "&page=" + currentPage, type: "GET", dataType: "text",
            error: function (XMLHttpRequest) { alert(systemTip.other); },
            success: function (data) {
                if (data != "") {
                    div.innerHTML = div.innerHTML + data;
                } else { }
                isRequest = true;
            }
        });
        return currentPage;
    }
}
var loadMoreArticle = function (typeid) {
    $(window).scroll(function () {
        var scrollTop = $(this).scrollTop();               //滚动条距离顶部的高度
        var scrollHeight = $(document).height();           //当前页面的总高度
        var windowHeight = $(this).height();               //当前可视的页面高度
        if (scrollTop + windowHeight >= (scrollHeight - 30)) {    //距离顶部+当前高度 >=文档总高度 即代表滑动到底部 
            if (currentPage > totalPage) {                        //如果加载ajax达到2次 停止加载
                //$(".pagelink").hide();                    //提示滚动 图片隐藏
                return false;                              //如果条件满足 停止运行该判断
            }
            loadArticleList(typeid); //开始加载ajax
            //$("#loading_text").show();
        }
    });
    function loadArticleList(typeid) {
        if (currentPage > totalPage || isRequest == false) {
            return currentPage;                       //判断页码是否达到限定的加载次数;
            return false;
        }
        currentPage++;
        isRequest = false;
        var div = document.getElementById('newsList');
        $.ajax({ url: Myurl + "ac=loadArticleList&typeid=" + typeid + "&page=" + currentPage, type: "GET", dataType: "text",
            error: function (XMLHttpRequest) { alert(systemTip.other); },
            success: function (data) {
                if (data != "") {
                    div.innerHTML = div.innerHTML + data;
                } else { }
                isRequest = true;
            }
        });
        return currentPage;
    }
}
var fixHeader = function () {
    $(window).scroll(function () {
        var st = $(this).scrollTop();
        if (st > 100) {
            $(".index_header").attr("style", "position:fixed;top:0px;");
        }
        else {
            $(".index_header").attr("style", "position:relative;");
        }
    });
}