﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppScrollImageAdd.aspx.cs" Inherits="WebUI.WebManage.Advertise.AppScrollImageAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加移动首页图片</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <a href="AppScrollImageList.aspx">首页图片列表</a><span><b>添加首页图片</b></span>
    </h1>
    <form class="form-div" action="AppScrollImageAdd.aspx?ac=add" enctype="multipart/form-data"
    method="post">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="100" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">
                标题：<span>*</span>
            </td>
            <td>
                <input type="text" name="Title" size="30" />
            </td>
        </tr>
        <tr>
            <td align="right">
                图片：<span>*</span>
            </td>
            <td>
                <input type="file" name="Img" onchange="CheckImgFile(this)" />
            </td>
        </tr>
        <tr>
            <td align="right">
                链接地址：<span>*</span>
            </td>
            <td>
                <input type="text" name="LinkURL" value="http://" size="60" />
            </td>
        </tr>
        <tfoot>
            <tr>
                <td></td>
                <td>
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
