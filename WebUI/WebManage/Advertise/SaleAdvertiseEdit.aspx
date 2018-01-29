<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleAdvertiseEdit.aspx.cs" Inherits="WebUI.WebManage.Advertise.SaleAdvertiseEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑特价广告</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>
    <script src="/WebManage/js/common.js" type="text/javascript"></script>
    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>编辑特价广告</b></span><a href="SaleAdvertiseList.aspx">特价广告列表</a>
    </h1>
    <form class="form-div" action="SaleAdvertiseEdit.aspx?ac=edit" 
    method="post" enctype="multipart/form-data">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="100" class="label" />
            <col />
        </colgroup>
        
        <tr>
            <td align="right">
                广告分类：<span>*</span>
            </td>
            <td>
                <select name="RouteClassId" id="RouteClassId">
                    <%=routeClassList %>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right">
                标题：<span>*</span>
            </td>
            <td>
                <input type="text" name="Title" value="<%=title %>" size="30" />
            </td>
        </tr>
        <tr>
            <td align="right">
                链接地址：<span>*</span>
            </td>
            <td>
                <input type="text" name="LinkURL" value="<%=LinkURL %>" size="60" />
            </td>
        </tr>
        <tr>
            <td align="right">
                图片：<span>*</span>
            </td>
            <td>
                <input type="file" name="Img" onchange="CheckImgFile(this)" /> <span>(不修改请留空)</span>
                <input id="Hidden1" name="Image_Hidden" type="hidden" value="<%=img %>" />
                <br /><br />
                <img src="<%=ClassLibrary.Common.SysConfig.UploadFilePathAdImg+img %>" width="300" alt="" />
            </td>
        </tr>
        <tr>
            <td align="right">
                过期时间：<span>*</span>
            </td>
            <td>
                <input class="Wdate" type="text" name="expiredtime" id="expiredtime" value="<%=expiredtime %>" readonly="readonly" onclick="WdatePicker()" size="12"/>
            </td>
        </tr>
        <tr>
            <td align="right">
                排序：<span>*</span>
            </td>
            <td>
                <input type="text" name="saleorder" size="10" value="<%=saleorder %>" />
            </td>
        </tr>
        <tfoot>
            <tr>
                <td></td>
                <td>
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                    <input type="hidden" name="ID" value="<%=saleId %>" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
