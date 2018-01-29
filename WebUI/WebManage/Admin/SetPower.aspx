<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetPower.aspx.cs" Inherits="WebUI.WebManage.SystemConfig.SetPower" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/WebManage/js/jquery.min.js"></script>
    <script type="text/javascript" src="/WebManage/js/common.js"></script>
    <script type="text/javascript" src="/WebManage/js/WebManage.js"></script>
    <style type="text/css">
        dl { margin-bottom: 20px; clear: both; overflow:hidden;margin-top:20px; }
        dl dt { font-weight:bolder;margin-bottom:5px; }
        dl dd { float: left;margin-right:1em; }        
    </style>
</head>
<body>
    <h1>
        <a href="AdminList.aspx">管理员列表</a> <span><b>设置 <%=adminName %> 的权限</b></span></h1>
    <form class="form-div" action="SetPower.aspx?ac=set" method="post" onsubmit="formPower(this)">
        <table width="100%" class="tableAdd">
            <tr>
                <td>
                    <%=dataColumnList%>
                    <%--<dl>
                        <dt>
                            <input type="checkbox" />新闻管理
                        </dt>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                    </dl>
                    <dl>
                        <dt>
                            <input type="checkbox" />新闻管理</dt>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                        <dd>
                            <input type="checkbox" />新闻管理</dd>
                    </dl>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <input value="保存设置" class="btn" type="submit" />　
                    <input type="button" class="btn2" onclick="history.back()" value="返回" />
                    <input type="hidden" id="power" name="power" />
                    <input type="hidden" name="ID" value="<%=adminID %>" />
                </td>
            </tr>
        </table>
    </form>

    <script type="text/javascript">
        var powers = "<%=adminPower %>";
        $(document).ready(function() {
            //select all
            $(":checkbox[name='mainColumn']").bind("click", function() {
                $(this).parent().parent().nextAll().find(":checkbox").attr("checked", this.checked);
            });

            //init selected
            $(":checkbox").each(function() {
                if (this.value != "") {
                    if (powers.indexOf(this.value) > -1) {
                        this.checked = true;
                    }
                }
            });
            $("dl").each(function() {
                if ($(this).find("input:checked").length > 0) {
                    $(this).find("input:first").attr("checked", true);
                }
            });

        });

        function formPower(f) {
            var str = "";
            $("input:checked").each(function() {
                str += this.value + "|";
            });
            f.power.value = str;
        }

    </script>

</body>
</html>
