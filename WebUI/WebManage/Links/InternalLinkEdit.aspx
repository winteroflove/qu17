﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalLinkEdit.aspx.cs" Inherits="WebUI.WebManage.Links.InternalLinkEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑内部链接</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>编辑内部链接</b></span><a href="InternalLinkList.aspx">内部链接列表</a>
    </h1>
    <form class="form-div" action="InternalLinkEdit.aspx?ac=edit" 
    method="post" enctype="multipart/form-data">
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
                <input type="text" name="Title" value="<%=title %>" size="30" />
            </td>
        </tr>
         <tr>
            <td align="right">
                链接地址：
            </td>
            <td>
                <input type="text" name="LinkURL" value="<%=LinkURL %>" size="60" />
            </td>
        </tr>
        
        <tfoot>
            <tr>
                <td></td>
                <td>
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                    <input type="hidden" name="ID" value="<%=newsId %>" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>

</body>
</html>
