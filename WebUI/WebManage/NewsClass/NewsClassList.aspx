<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsClassList.aspx.cs" Inherits="WebUI.WebManage.NewsClass.NewsClassList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>新闻类型列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>新闻类型列表</b></span><a href="NewsClassAdd.aspx">添加新闻类型</a>
    </h1>
    <table class="tableList">
        <thead>
            <tr>
                <th>
                   序号
                </th>
                <th>
                    新闻类型
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
            <%=dataNewsClassList%>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="9">
                    <div id="turn-page" class="page floatR">
                        <%=pageInfo%>
                    </div>
                </td>
            </tr>
        </tfoot>
    </table>
</body>
</html>
