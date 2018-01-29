<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteClassList.aspx.cs"
    Inherits="WebUI.WebManage.RouteClass.RouteClassList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>路线类型列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>路线类型列表</b></span><a href="RouteClassAdd.aspx?cid=<%=maxClassID %>">添加路线类型</a>
    </h1>
    <table class="tableList">
        <thead>
            <tr>
                <th>
                    序号
                </th>
                <th>
                    路线类型
                </th>
                <th>
                    父路线
                </th>
                <th>首页推荐</th>
                <th>
                    创建时间
                </th>
                <th>
                    管理
                </th>
            </tr>
        </thead>
        <tbody>
            <%=dataRouteClassList%>
        </tbody>
        
    </table>
</body>
</html>
