<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminList.aspx.cs" Inherits="WebUI.WebManage.Admin.AdminList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理员列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>管理员列表</b></span><a href="AdminAdd.aspx">添加管理员</a>
    </h1>
    <table class="tableList">
        <thead>
            <tr>
                <th>NO.</th>
                <th>
                    管理员账号
                </th>
                <th>
                    创建时间
                </th>
                   <th>
                   管理
                </th>
            </tr>
        </thead>
        <tbody>
            <%=adminList%>
        </tbody>

    </table>
</body>
</html>
