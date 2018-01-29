<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="WebUI.Manager.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>网站后台管理</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .form-div p{font-size:36px;text-align:center;margin-top:20px;font-family: "幼圆","微软雅黑";font-weight:bold;color:#2C504F;line-height:66px;}
    </style>
</head>
<body>

    <div style="font-size:16px;text-align:center; margin-top:100px;">
        <%=checkNewOrder() %>
        <br/>
        <%=checkNewComment() %>
    </div>
    <div class="form-div">
        <p>欢迎光临重庆中国青年旅行社<br />网站后台管理中心</p>
    </div>
    
</body>
</html>
