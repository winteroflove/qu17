<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="WebUI.WebManage.Customer.CustomerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>客服列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>
    <style type="text/css" >
        .tableList { width:58%; float:left; margin-left:5px;margin-top:10px;}
        .tableList a{color:#0C9300;}
        .tableList a:hover{text-decoration:underline;}
        .tableAdd {width:38%; float:left;margin-left:10px;}
    </style>
</head>
<body>
    <h1>
        <span><b>客服列表</b></span>
    </h1>
    
    <table class="tableList">
        <thead>
            <tr>
                <th style="width:100px;">
                    客服分组
                </th>
                <th style="width:150px;">
                    客服名称
                </th>
                <th style="width:120px;">
                    客服QQ号
                </th>
                <th style="width:180px;">
                    客服排序
                </th>
                <th>
                    管理
                </th>
            </tr>
        </thead>
        <tbody>
            <%=customerList %>
        </tbody>
    </table>
    <form class="form-div" action="CustomerList.aspx?ac=add" enctype="multipart/form-data" method="post" onsubmit="return formCustomer(this)">
    <table class="tableAdd">
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
                <input type="text" name="CName" size="20" maxlength="20" />
            </td>
        </tr>
        <tr>
            <td align="right">
                客服QQ号：
            </td>
            <td>
                <input type="text" name="QQNumber" size="20" maxlength="20" />
            </td>
        </tr>
        <tr>
            <td align="right">
                客服电话：
            </td>
            <td>
                <input type="text" name="Phone" size="20" maxlength="20" />
            </td>
        </tr>
        <tr>
            <td align="right">
                客服排序：
            </td>
            <td>
                <input type="text" name="QQorder" size="20" maxlength="2" value="9" />
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
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
