﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsAdd.aspx.cs" Inherits="WebUI.WebManage.News.NewsAdd"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加文章</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>
    <script type="text/javascript" src="/WebManage/kindsoft/kindeditor.js"></script>

    <script type="text/javascript">
        KindEditor.ready(function(K) {
            K.create('#Content', {
                uploadJson: '/WebManage/kindsoft/upload_json.ashx',
                fileManagerJson: '/WebManage/kindsoft/file_manager_json.ashx',
                allowFileManager: true
            });
        });
    </script>

</head>
<body>
    <h1>
        <a href="NewsList.aspx?cid=<%=newsClassIDs %>">文章列表</a><span><b>添加文章</b></span>
    </h1>
    <form class="form-div" action="NewsAdd.aspx?cid=<%=newsClassIDs %>&ac=add" enctype="multipart/form-data" method="post">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="120" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">
                文章类型：<span>*</span>
            </td>
            <td>
                <select id="newsClassID" name="newsClassID" onchange="changeNewsClass()">
                    <%=newsClassList%>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right">
                所属区域：
            </td>
            <td>
                <select name="routeParentID" id="routeParentID" onchange="updateProvince()">
                    <option value="1">==国内旅游==</option>
                    <option value="2">==出境旅游==</option>
                </select>
                <div id="Province" style="width: 670px;"><%=routeClassList %></div>
                
                <span class="red_text">说明:最多可选择五个省份</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                次级区域：<span>*</span>
            </td>
            <td>
                <div id="ScenicDiv" style="width: 670px;">
                    <span class="red_text">说明:请先选择一个省份或者直辖市</span>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                标题：<span>*</span>
            </td>
            <td>
                <input type="text" name="Title" size="60" />
            </td>
        </tr>
        <tr>
            <td align="right">
                编辑人：
            </td>
            <td>
                <input type="text" name="Editor" size="60" />
            </td>
        </tr>
        <tr>
            <td align="right">
                文章来源：
            </td>
            <td>
                <input type="text" name="Source" size="60" />
            </td>
        </tr>
        <tr>
            <td align="right">
                文章图片：
            </td>
            <td>
                <input type="file" name="Image" onchange="CheckImgFile(this)" />
            </td>
        </tr>
        <tr>
            <td align="right">
                文章标签：
            </td>
            <td>
                <input type="text" name="Ntag" size="60" /> <span>(多个标签请用","隔开)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                内容：<span>*</span>
            </td>
            <td>
                <textarea id="Content" name="Content" cols="1" rows="1" style="width: 700px; height: 300px; visibility: hidden;"></textarea>
            </td>
        </tr>
        <tr>
            <td align="right">
                页面关键字：
            </td>
            <td>
                <textarea name="SeoKeywords" rows="4" cols="70"></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                页面描述：
            </td>
            <td>
                <textarea name="SeoDescription" rows="4" cols="70"></textarea> <span>(SEO用)</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                三峡相关：
            </td>
            <td>
                <input name="IsSanxia" type="radio" value="False" checked="checked" />否
                <input name="IsSanxia" type="radio" value="True" />是
            </td>
        </tr>
        <tr>
            <td align="right">
                显示文章：
            </td>
            <td>
                <input name="isDisplay" type="radio" value="False" />否
                <input name="isDisplay" type="radio" value="True" checked="checked" />是
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="2" align="center">
                    <input class="btn" type="submit" value="确定提交" />
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
