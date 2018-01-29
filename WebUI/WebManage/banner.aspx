<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="banner.aspx.cs" Inherits="WebUI.Manager.banner" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站后台管理</title>
    <link href="css/frame.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="header">
        <span>网站后台管理</span>
    </div>
    <div class="banNav">
        <ul>
            <li><a title="" href="main.aspx" target="main-frame">管理首页</a></li>
            <li><a title="" href="logout.aspx" target="_top">退出管理</a></li>
            <li><a title="" href="/" target="_blank">网站首页</a></li>
        </ul>
        <p>
            您好， <%=name %>　今天是 <%=time %></p>
    </div>
</body>
</html>
