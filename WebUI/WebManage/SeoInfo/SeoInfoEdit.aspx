<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeoInfoEdit.aspx.cs" Inherits="WebUI.WebManage.SeoInfo.SeoInfoEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑SEO信息</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>
</head>
<body>
    <h1>
        <a href="SeoInfoList.aspx">SEO信息列表</a><span><b>编辑SEO信息</b></span>
    </h1>
    <form class="form-div" action="SeoInfoEdit.aspx?ac=add" enctype="multipart/form-data" method="post" onsubmit="return formSeoInfo(this)">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="120" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">
                目的地：<span>*</span>
            </td>
            <td>
                <select name="classId1" onchange="seoClassChange(this)">
                    <option value="0">==选择==</option>
                    <%=routeClassList%>
                </select>
                <select name="classId2" id="sltArea">
                    <%=subRClassList %>
                </select>
            </td>
        </tr>
        <tr id="trTheme">
            <td align="right">
                主题分类：<span>*</span>
            </td>
            <td>
                <select name="themeId" id="themeId">
                    <option value="0">==请选择==</option>
                    <%=themeClassList %>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right">
                行程天数：<span>*</span>
            </td>
            <td>
                <select name="routeDays" id="routeDays">
                    <option value="0">==请选择==</option>
                    <%=daysList%>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right">
                行程预算：<span>*</span>
            </td>
            <td>
                <select name="routePrice" id="routePrice">
                    <option value="">==请选择==</option>
                    <%=priceList %>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right">
                SEO标题：
            </td>
            <td>
                <input type="text" size="90" maxlength="80" name="SeoTitle" value="<%=seoTitle %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                SEO关键字：
            </td>
            <td>
                <textarea name="SeoKeywords" rows="4" cols="70"><%=seoKey %></textarea>
            </td>
        </tr>
        <tr>
            <td align="right">
                SEO描述：
            </td>
            <td>
                <textarea name="SeoDescription" rows="4" cols="70"><%=seoDesc %></textarea>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="2" align="center">
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                    <input type="hidden" name="seoId" value="<%=seoId %>" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
    <script type="text/javascript">
        var maxId = "<%=maxClassId %>";
        if (maxId == "5") {
            $("#trTheme").hide();
        } else {
            $("#trTheme").show();
        }
    </script>
</body>
</html>
