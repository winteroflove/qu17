<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAdd.aspx.cs" Inherits="WebUI.WebManage.Admin.AdminAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加管理员</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <a href="AdminList.aspx">管理员列表</a><span><b>添加管理员</b></span>
    </h1>
    <form class="form-div" action="AdminAdd.aspx?ac=add" enctype="multipart/form-data"
    method="post">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="120" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">
                管理员账号：<span>*</span>
            </td>
            <td>
                <input type="text" name="UserName" size="60" />
            </td>
        </tr>
        <tr>
            <td align="right">
                管理员密码：
            </td>
            <td>
                <input type="password" name="Password" />
            </td>
        </tr>
         <tr>
            <td align="right">
                确认密码：
            </td>
            <td>
                <input type="password" name="RePassword" />
            </td>
        </tr>
        <tfoot>
            <tr>
                <td></td>
                <td>
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
