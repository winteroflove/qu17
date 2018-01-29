<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalLinkList.aspx.cs" Inherits="WebUI.WebManage.Links.InternalLinkList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>内部链接列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>内部链接列表</b></span><a href="InternalLinkAdd.aspx">添加内部链接</a>
    </h1>
    <form class="form-div" action="InternalLinkList.aspx" name="searchForm">
        <div class="search">　
            关键字：
            <input size="15" class="text" name="key" value="<%=searchKey %>" />
            <input value=" 搜索 " class="button" type="submit" />
            <input value="刷新链接" class="button" type="button" onclick="refreshLinks()" />
        </div>
    </form>
    <table class="tableList">
        <thead>
            <tr>
                <th>
                    NO.
                </th>
                <th>
                    标题
                </th>
                <th>
                    链接地址
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
                <td colspan="5">
                    <div id="turn-page" class="page floatR">
                        <%=pageInfo%>
                    </div>
                </td>
            </tr>
        </tfoot>
    </table>
</body>
</html>
