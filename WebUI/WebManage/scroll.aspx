<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="scroll.aspx.cs" Inherits="WebUI.Manager.scroll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站后台管理</title>
    <link href="css/frame.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
var view_flag=1;
function my_menu_view(id) {
    var el = document.getElementById(id);
    if (view_flag == 1) {

        top.frames[0].document.getElementById("frame2").cols = "0,10,*";
        el.className = "extend";

    }
    else {
        top.frames[0].document.getElementById("frame2").cols = "212,10,*";
        el.className = "hide";

    }

    view_flag = 1 - view_flag;
    // window.parent.frames.main.location.reload();
}

var isShow = true;
function showMenu(id) {
    if (isShow) {
        top.document.getElementById('frame2').attributes["cols"].value = "0,10,*";
        document.getElementById(id).className = "extend";
        isShow = false;
    }
    else {
        top.document.getElementById('frame2').attributes["cols"].value = "212,10,*";
        document.getElementById(id).className = "hide";
        isShow = true;
    }
}

    </script>

    <style type="text/css">
        body
        {
            background: #c5e2f0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="scroll">
        <a class="hide" href="javascript:showMenu('arrow')" id="arrow" title="显示/隐藏左侧菜单">
        </a>
    </div>
    </form>
</body>
</html>
