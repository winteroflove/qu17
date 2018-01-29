<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="WebUI.WebManage.Customer.CustomerEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>修改客服</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>
</head>
<body>
    <h1>
        <span><b>修改客服</b></span><a href="CustomerList.aspx">酒店列表</a>
    </h1>
    <form class="form-div" action="CustomerEdit.aspx?ac=edit" enctype="multipart/form-data" method="post" onsubmit="return formCustomer(this)">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="130" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">
                客服分组：<span>*</span>
            </td>
            <td>
                <select name="QQtype" id="QQtype">
                    <option value="1">国内客服</option>
                    <option value="2">出境客服</option>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right">
                客服名称：<span>*</span>
            </td>
            <td>
                <input type="text" name="CName" size="20" maxlength="20" value="<%=cmodel.Name %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                客服QQ号：
            </td>
            <td>
                <input type="text" name="QQNumber" size="20" maxlength="20" value="<%=cmodel.QQ %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                客服电话：
            </td>
            <td>
                <input type="text" name="Phone" size="20" maxlength="20" value="<%=cmodel.Phone %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                客服排序：
            </td>
            <td>
                <input type="text" name="QQorder" size="20" maxlength="2" value="<%=cmodel.QQorder %>" />
            </td>
        </tr>
        <tr>
            <td align="right">
                是否启用：
            </td>
            <td>
                <input name="InUse" type="radio" value="False" />否
                <input name="InUse" type="radio" value="True" checked="checked" />是
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="2" align="center">
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                    <input type="hidden" name="ID" value="<%=cmodel.ID %>" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
    <script type="text/javascript">
        var qqtype = '<%=qqtype %>';
        document.getElementById("QQtype").value = qqtype;
        
        document.getElementsByName("InUse")[<%=cmodel.InUse?1:0%>].checked = true;

    </script>
</body>
</html>
