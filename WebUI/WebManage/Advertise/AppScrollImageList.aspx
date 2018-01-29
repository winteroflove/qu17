﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppScrollImageList.aspx.cs" Inherits="WebUI.WebManage.Advertise.AppScrollImageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>首页图片列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>首页图片列表</b></span><a href="AppScrollImageAdd.aspx">添加首页图片</a>
    </h1>
    <table class="tableList">
        <thead>
            <tr>
                <th>
                    NO.
                </th>
                <th>图片</th>
                <th>
                    标题
                </th>
                <th>
                    链接地址
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
            <%=linksList%>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="6">
                    <div id="turn-page" class="page floatR">
                        <%=pageInfo%>
                    </div>
                </td>
            </tr>
        </tfoot>
    </table>
</body>
</html>
