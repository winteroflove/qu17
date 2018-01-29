<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteTypeEdit.aspx.cs" Inherits="WebUI.WebManage.RouteType.RouteTypeEdit"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加主题类型</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>编辑主题类型</b></span><a href="RouteTypeList.aspx">主题类型列表</a>
    </h1>
    <form class="form-div" action="RouteTypeEdit.aspx?ac=edit" method="post" enctype="multipart/form-data">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="120" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">
                类型名称：<span>*</span>
            </td>
            <td>
                <input type="text" name="ClassName" value="<%=className %>" size="30" />
            </td>
        </tr>
        <tr>
            <td align="right">
                类型拼音：<span>*</span>
            </td>
            <td>
                <input type="text" name="ClassNamePinYin" size="30" value="<%=classNamePinYin %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                类型图片：
            </td>
            <td>
                <div><input type="file" name="Image" onchange="CheckImgFile(this)" /></div>
                <input id="Image_Hidden" name="Image_Hidden" type="hidden" value="<%=image %>" />
                
                <%if (!string.IsNullOrEmpty(image)){ %>
                <p><br /><img src="<%=ClassLibrary.Common.SysConfig.UploadFilePathClassImg + image  %>" width="100" /></p>
                <%} %>
            </td>
        </tr>
        <tr>
            <td align="right">
                移动端图片：
            </td>
            <td>
                <div><input type="file" name="appImage" onchange="CheckImgFile(this)" /></div>
                <input id="appImage_Hidden" name="appImage_Hidden" type="hidden" value="<%=appImg %>" />
                
                <%if (!string.IsNullOrEmpty(appImg))
                  { %>
                <p><br /><img src="<%=ClassLibrary.Common.SysConfig.UploadFilePathClassImg + appImg  %>" width="100" /></p>
                <%} %>
            </td>
        </tr>
        <tr>
            <td align="right">
                类型标题：
            </td>
            <td>
                <input type="text" size="90" maxlength="80" name="SeoTitle" value="<%=seoTitle %>" /><span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                类型关键字：
            </td>
            <td>
                <textarea name="SeoKeywords" rows="4" cols="70"><%=seoKeyword %></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                类型描述：
            </td>
            <td>
                <textarea name="SeoDescription" rows="4" cols="70"><%=seoDesc %></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                推荐到首页：
            </td>
            <td>
                <input name="Recommend" id="Recommend" type="radio" value="False" checked="checked" />否
                <input name="Recommend" type="radio" value="True" />是
            </td>
        </tr>
        <tr>
            <td align="right">
                类型排序：
            </td>
            <td>
                <input type="text" name="classOrder" size="20" maxlength="5" value="<%=classOrder %>"/>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="2" align="center">
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                    <input type="hidden" name="ID" value="<%=routeTypeId %>" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
    
    <script type="text/javascript">
        document.getElementsByName("Recommend")[<%=recommend?1:0%>].checked = true;
    </script>
    
</body>
</html>
