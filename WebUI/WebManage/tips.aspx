<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tips.aspx.cs" Inherits="WebUI.Manager.tips" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站后台管理</title>
    <meta http-equiv="Refresh" content="<%=time %>;url=<%=backUrl %>" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css"> 
        h2 { padding:30px 0;font-size:14px;color:#000;text-align:center}
        p{ text-align:center}
    </style>
</head>
<body>
    <h1>
        <span><b>系统提示信息</b></span>
    </h1>
    <h2>
        <%=title %>：<%=message %>
    </h2>
    <p id="redirectionMsg">
        <%if (!string.IsNullOrEmpty(backUrl)) Response.Write("系统<span id='num'></span>秒后自动返回，<a href='/WebManage/" + backUrl + "'>如果没有自动跳转,请点击这里</a>"); %>
    </p>

    <script type="text/javascript">
        var time = <%=time %>;
        function autoDrop() {
            time--;
            document.getElementById("num").innerHTML = time;
            if (time == 0) {
                location.href = "/WebManage/<%=backUrl %>";
            }
            if(time <=0) time = 0;
        }
        setInterval("autoDrop()", 1000);
        window.onerror = function(){return true;}
    </script>

</body>
</html>
