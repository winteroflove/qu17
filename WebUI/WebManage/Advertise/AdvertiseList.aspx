<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvertiseList.aspx.cs" Inherits="WebUI.WebManage.Advertise.AdvertiseList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>广告列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1><span><b>广告列表</b></span><a href="AdvertiseAdd.aspx">添加广告</a></h1>

        <table class="tableList" cellpadding="0" cellspacing="0">
            <thead>
                <tr>
                    <th width="5%" align="center">ID</th>
                    <th width="10%">图片</th>
                    <th width="35%">名称/标题</th>
                    <th width="25%">广告位置</th>
                    <th width="10%">添加时间</th>
                    <th width="10%">操作</th>
                </tr>
            </thead>
            <tbody>
                <%=dataAdList%>
            </tbody>
        </table>
<div style="height:500px"></div>
</body>
</html>
