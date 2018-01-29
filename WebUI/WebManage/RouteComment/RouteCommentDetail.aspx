<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteCommentDetail.aspx.cs"
    Inherits="WebUI.WebManage.RouteComment.RouteCommentDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>>路线评论</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>路线评论</b></span><a href="RouteCommentList.aspx">路线评论列表</a>
    </h1>
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="100" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">
                线路：
            </td>
            <td>
               <%=route %> 
            </td>
        </tr>
        <tr>
            <td align="right">
                内容：
            </td>
            <td>
              <%=content %>
            </td>
        </tr>
        <tr>
            <td align="right">
                评分：
            </td>
            <td>
             <%=grade %>
            </td>
        </tr>
        <tr>
            <td align="right">
                用户名：
            </td>
            <td>
                <%=userName %>
            </td>
        </tr>
        <tr>
            <td align="right">
                昵称：
            </td>
            <td>
                <%=nickname %>
            </td>
        </tr>
        <tr>
            <td align="right">
                是否匿名：
            </td>
            <td>
               <%=anonymous %>
            </td>
        </tr>
        <tr>
            <td align="right">
                邮箱：
            </td>
            <td>
                <%=email %>
            </td>
        </tr>
        <tr>
            <td align="right">
                审核：
            </td>
            <td>
               <%=checkeds %>
            </td>
        </tr>
        <tr>
            <td align="right">
                创建时间：
            </td>
            <td>
             <%=createdTime %>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="2" align="center">
                    <input type="button" class="btn2" value="返回" onclick="history.back(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
</body>
</html>
