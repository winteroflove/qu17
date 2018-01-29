<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebUI.Manager.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>网站后台管理</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body, html
        {
            background: #00a0dc url(images/bg.jpg) repeat-x;
            color: white;
        }
        #login
        {
            padding: 110px 0 0 260px;
            position: absolute;
            left: 50%;
            top: 50%;
            margin: -220px 0 0 -305px;
            width: 351px;
            height: 260px;
            background: url(css/images/login.gif) no-repeat;
        }
        .formRow,.formbtn
        {
            height: 40px;
            line-height: 40px;
            color: #0096c8;
        }
        .formRow label
        {
            display: block;
            float: left;
            width: 55px;
            line-height: 40px;
            text-align: right;
        }
        .formRow input.text
        {
            width: 198px;
            height: 25px;
            background: url(css/images/inputbg.gif) no-repeat;
            border: 1px solid #82bedc;
        }
        .formbtn { margin-left:55px}
        input.submit { width:72px;height:29px;line-height:29px;background:url(css/images/btnlogin.gif) no-repeat;color:#fff;border:none}
    </style>
</head>
<body>
    <form method="post" action="login.aspx?ac=login" onsubmit="return ckFormLogin(this)">
    <div id="login">
        <div class="formRow">
            <label>
                用户名：</label>
            <input class="text" name="adminName" type="text" />
        </div>
        <div class="formRow">
            <label>
                密&nbsp;&nbsp;&nbsp;&nbsp;码：</label>
            <input class="text" name="adminPwd" type="password" />
        </div>
        <div class="formbtn">
            <input class="submit" type="submit" value="登录" />
        </div>
    </div>
    </form>

    <script type="text/javascript">
        function ckFormLogin(f) {
            var n = f.adminName.value;
            var p = f.adminPwd.value;
            if (n == "" || p == "") {
                alert("用户名或密码不能为空");return false;
            }
            if (n.indexOf("<") > -1 ||
            n.indexOf(">") > -1 ||
            p.indexOf("<") > -1 ||
            p.indexOf(">") > -1) {
                alert("暂不支持特殊字符");return false;
            }
        }
    </script>

</body>
</html>
