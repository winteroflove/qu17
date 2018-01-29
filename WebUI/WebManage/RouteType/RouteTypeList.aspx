<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteTypeList.aspx.cs"
    Inherits="WebUI.WebManage.RouteType.RouteTypeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>主题类型列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>主题类型列表</b></span><a href="RouteTypeAdd.aspx">添加主题类型</a>
    </h1>
    <table class="tableList">
        <thead>
            <tr>
                <th>
                    序号
                </th>
                <th>
                    主题类型
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
            <%=dataRouteTypeList%>
        </tbody>
        
    </table>
</body>
</html>
