/*!
* common JavaScript Library v1.0
*
* Copyright 2010, Somin
* Dual licensed under the MIT or GPL Version 2 licenses.*
* Include jQuery
* http://www.jquery.com
* 
* Date: 2010-3-5
*/

var empty = '';

String.prototype.Unsafe = function() {

    if (this.indexOf("<") > -1 || this.indexOf(">") > -1)
        return true;

    return false;

}

String.prototype.IsNull = function() {

    if (this == empty)
        return true;

    return false;

}

String.prototype.IsEmail = function() {

    if (/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/.test(this)) {

        return true;

    }

    return false;

}
String.prototype.Trim = function() {

    return this.replace(/(^\s*)|(\s*$)/g, "");

}

String.prototype.LTrim = function() {

    return this.replace(/(^\s*)/g, "");

}

String.prototype.RTrim = function() {

    return this.replace(/(\s*$)/g, "");

}

String.prototype.Format = function() {

    var sz = this.toString();

    if (arguments.length < 1)
        return sz;

    for (var i = 0; i < arguments.length; i++) {

        var arg = arguments[i];

        if (typeof arg == 'string' || typeof arg == 'number') {

            var re = new RegExp("[\{]" + i + "[\}]", "ig");

            sz = sz.replace(re, arg);

        }
    }

    return sz;

}

function SafeHtml() {

    if (arguments.length == 0) return;

    for (var i = 0; i < arguments.length; i++) {
    
        if (typeof arguments[i] == "object" && arguments[i] != null)
            arguments[i].value = arguments[i].value.replace(/</g, "&lt").replace(/>/g, "&gt");

    }

}

function Trim() {

    if (arguments.length == 0) return;

    for (var i = 0; i < arguments.length; i++) {

        if (typeof arguments[i] == "object" && arguments[i] != null)
            arguments[i].value = arguments[i].value.replace(/(^\s*)|(\s*$)/g, "");

    }

}

function SelectAll(ckAll) {

    var checkboxName = "ckbox";

    if (arguments[1]) checkboxName = arguments[1];

    if (ckAll.checked == true) {

        $("input[name=" + checkboxName + "]").each(function(i) {

            $(this).attr("checked", true);

        });

    }

    else {

        $("input[name=" + checkboxName + "]").each(function(i) {

            $(this).attr("checked", false);

        });

    }

}

function AllSelected(checkboxName, isSelected) {

    $("input[name=" + checkboxName + "]").each(function(i) {

    if (!$(this).attr("disabled")) {
        
            if (isSelected) $(this).attr("checked", true);
            else $(this).attr("checked", false);

        }

    });

}

function InverseSelected(checkboxName) {

    $("input[name=" + checkboxName + "]").each(function(i) {

        if (!$(this).attr("disabled")) {

            if (this.checked == true) $(this).attr("checked", false);

            else $(this).attr("checked", true);

        }

    });

}

function GetSelectedIds(selectControlName) {

    var idstr = empty;

    $("input[name=" + selectControlName + "]").each(function(i) {

        if (this.checked == true) {

            idstr += this.value + ",";

            this.checked = false;
        }

    });

    if (idstr != empty) {

        idstr = idstr.substr(0, idstr.length - 1);

    }

    return idstr;

}

function SetSelectedStatus(selectControlName, arrayValue) {

    if (typeof arrayValue != "object") {
    
        arrayValue[0] = arrayValue;

    }

    $("input[name=" + selectControlName + "]").attr("checked", false);

    for (var n = 0; n < arrayValue.length; n++) {

        $("input[name=" + selectControlName + "]").each(function(i) {
        
            if (this.value == arrayValue[n]) {
                this.checked = true;

            }

        });

    }

}

window.onload = function() {

//    if ($("textarea").attr("maxlength")) {

//        $("textarea").bind("keypress", function() {

//            if (this.value.length >= $("textarea").attr("maxlength")) {
//                return false;

//            }

//        });

//    }

    $(".zoom").mouseover(function() {

        var o = $(this).offset();

        $("<img/>")
            .attr("src", this.src)

            .addClass("zoomView")

            .css({

                left: this.width + o.left + 10,

                top: this.height + o.top + 10,

                position: "absolute"
            })

            .appendTo($("body"));

    }).mouseout(function() {

        $(".zoomView").hide();

    });


}

function CheckImgFile(fi) {

    var ext = fi.value.substr(fi.value.lastIndexOf("."), fi.value.length).toLowerCase();

    if (ext != ".jpg" && ext != ".gif" && ext != ".png") {

        fi.outerHTML = fi.outerHTML;
        
        alert("只支持 .jpg|.gif|.png 格式的文件");

    }

}

function CheckFile(fi, format) {

    var ext = fi.value.substr(fi.value.lastIndexOf("."), fi.value.length).toLowerCase();
    
    var items = format.split('|'), exist = false;
    
    for (var i = 0; i < items.length; i++) {

        if (ext == items[i]) {

            exist = true;

        }

    }

    if (!exist) {
    
        fi.outerHTML = fi.outerHTML;

        alert("请选择 " + format + " 格式的文件");

    }
    
}

function ShowTab(clickObj, idName, count, index, className) {

    $(clickObj).parent().parent().find("li").removeClass(className);
    
    $(clickObj).parent().addClass(className);

    for (var i = 1; i <= count; i++) {

        var obj = document.getElementById(idName + i);

        if (i == index) {

            obj.style.display = empty;

        }

        else {

            obj.style.display = 'none';

        }
        
    }
    
}


function HtmlEncodeChar(c) {

    switch (c) {
        case '<': return "&lt;";
        
        case '>': return "&gt;";
        
        case '&': return "&amp;";
        
        case '"': return "&quot;";

        case "'": return "&#39;";
        
        default: return "&#" + c.charCodeAt(0) + ";";
        
    }
    
}

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

function GetTodayOfWeek() {

    var day = new Date();

    var today = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六");

    return today[day.getDay()];

}

function GetTodayOfYMD() {

    var day = new Date();

    return day.getFullYear() + "-" + (day.getMonth() + 1) + "-" + day.getDate();

}


function master_setInterval(callback, timeout, param) {

    var args = Array.prototype.slice.call(arguments, 2);

    var _cb = function() {

        callback.apply(null, args);

    }

    window.setInterval(_cb, timeout);

}


//cookie
function GetCookieVal(offset) {

    var endstr = document.cookie.indexOf(";", offset);

    if (endstr == -1)
        endstr = document.cookie.length;

    return unescape(document.cookie.substring(offset, endstr));

}

function SetCookie(name, value, expires) {

    var expdate = new Date();

    var argv = SetCookie.arguments;

    var argc = SetCookie.arguments.length;

    var path = (argc > 3) ? argv[3] : null;

    var domain = (argc > 4) ? argv[4] : null;

    var secure = (argc > 5) ? argv[5] : false;

    expdate.setTime(expdate.getTime() + (expires * 24 * 3600 * 1000));

    document.cookie = name + "=" + escape(value) + ((expires == null) ? "" : ("; expires=" + expdate.toGMTString()))
                    + ((path == null) ? "" : ("; path=" + path)) + ((domain == null) ? "" : ("; domain=" + domain))
                    + ((secure == true) ? "; secure" : "");

}

function DelCookie(name) {

    var exp = new Date();

    exp.setTime(exp.getTime() - 1);

    var cval = GetCookie(name);

    document.cookie = name + "=" + cval + "; expires=" + exp.toGMTString();

}

function GetCookie2(name) {

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

function GetCookie3(name) {

    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    
    if (arr != null)
        return unescape(arr[2]);

    return null;

}


var common = new Object();
common.cok = {
    text: document.cookie,
    GetCookie: function(ck_n, ck_k) {
        var u_ck, ck_v;
        var __t_1 = onlinemsg.cok.text.substring(onlinemsg.cok.text.indexOf(ck_n), onlinemsg.cok.text.length);
        var __t_2 = __t_1.substring((ck_n.length + 1), __t_1.length);
        var __t_ary = __t_2.split(';');
        u_ck = __t_ary[0];
        var u_ck_ary = u_ck.split('&');
        for (var i in u_ck_ary) {
            var kv = u_ck_ary[i].split('=');
            if (kv[0] == ck_k) {
                ck_v = unescape(kv[1]); break;
            }
        } return ck_v;
    },
    SetCookie: function(ck_n, ck_v) {
        var Days = 30;
        var exp = new Date();
        exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
        document.cookie = ck_n + "=" + escape(ck_v);
    },
    DeleteCookie: function(ck_n) {
        var exp = new Date();
        exp.setTime(exp.getTime() - 1);
        var cval = GetCookie(ck_n);
        document.cookie = ck_n + "=" + cval + "; expires=" + exp.toGMTString();
    }
};

//end
