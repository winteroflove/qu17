<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteClassAdd.aspx.cs" Inherits="WebUI.WebManage.RouteClass.RouteClassAdd"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加路线类型</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>
</head>
<body>
    <h1>
        <a href="RouteClassList.aspx?cid=<%=maxClassID %>">路线类型列表</a><span><b>添加路线类型</b></span>
    </h1>
    <form class="form-div" action="RouteClassAdd.aspx?ac=add&cid=<%=maxClassID %>" method="post" enctype="multipart/form-data">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="120" class="label" />
            <col />
        </colgroup>
         <tr>
            <td align="right">
                所属上级：<span>*</span>
            </td>
            <td>
                <select name="routeClassID">
                    <%=routeClassList%>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right">
                类型名称：<span>*</span>
            </td>
            <td>
                <input type="text" name="ClassName" size="30" />
            </td>
        </tr>
        <tr>
            <td align="right">
                类型拼音：<span>*</span>
            </td>
            <td>
                <input type="text" name="ClassNamePinYin" size="30" />
            </td>
        </tr>
        <tr id="trImage" class="hide">
            <td align="right">
                类型图片：
            </td>
            <td>
                <input type="file" name="Image" onchange="CheckImgFile(this)" />
            </td>
        </tr>
        <tr>
            <td align="right">
                类型标题：
            </td>
            <td>
                <input type="text" size="90" maxlength="80" name="SeoTitle" /><span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                类型关键字：
            </td>
            <td>
                <textarea name="SeoKeywords" rows="4" cols="70"></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                类型描述：
            </td>
            <td>
                <textarea name="SeoDescription" rows="4" cols="70"></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr id="trHaidao" class="hide">
            <td align="right">
                是否海岛：
            </td>
            <td>
                <input name="IsHaidao" type="radio" value="False" checked="checked" />否
                <input name="IsHaidao" type="radio" value="True" />是
            </td>
        </tr>
        <tr>
            <td align="right">
                推荐到首页：
            </td>
            <td>
                <input name="Recommend" type="radio" value="False" checked="checked" />否
                <input name="Recommend" type="radio" value="True" />是
            </td>
        </tr>
        <tr>
            <td align="right">
                类型排序：
            </td>
            <td>
                <input type="text" name="classOrder" size="20" maxlength="5" value="9999"/>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="2" align="center">
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                    <input type="hidden" name="maxid" value="<%=maxClassID %>" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
    <script type="text/javascript">
        var maxId = <%=maxClassID %>;
        if(maxId == 2){
            $("#trHaidao").show();
        }
        if(maxId == 3 || maxId == 2){
            $("#trImage").show();
        }
    </script>
</body>
</html>
