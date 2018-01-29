<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteCommentList.aspx.cs"
    Inherits="WebUI.WebManage.RouteComment.RouteCommentList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>路线评论列表</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>路线评论列表</b></span>
    </h1>
    <table class="tableList">
        <thead>
            <tr>
                <th>
                    线路
                </th>
                <th>
                    评分
                </th>
                <th>
                    用户名
                </th>
                <th>
                    昵称
                </th>
                <th>
                    邮箱
                </th>
                <th>
                    已审核
                </th>
                <th>
                    创建时间
                </th>
                <th>管理</th>
            </tr>
        </thead>
        <tbody>
            <%=dataRouteCommentList%>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="8">
                    <div id="turn-page" class="page floatR">
                        <%=pageInfo%>
                    </div>
                </td>
            </tr>
        </tfoot>
    </table>
</body>
</html>
