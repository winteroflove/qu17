<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMeta.aspx.cs" Inherits="WebUI.WebManage.SystemSet.WebMeta" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站信息管理</title>
    <link href="/WebManage/css/main.css" rel="stylesheet" type="text/css" />

    <script src="/WebManage/js/jquery.min.js" type="text/javascript"></script>

    <script src="/WebManage/js/common.js" type="text/javascript"></script>

    <script src="/WebManage/js/WebManage.js" type="text/javascript"></script>

</head>
<body>
    <h1>
        <span><b>网站信息管理</b></span>
    </h1>
    <form class="form-div" action="WebMeta.aspx?ac=edit" method="post">
    <table width="100%" class="tableAdd">
        <colgroup>
            <col width="140" class="label" />
            <col />
        </colgroup>
        <tr>
            <td align="right">
                网站名称：
            </td>
            <td>
                <input type="text" name="Title" value="<%=title%>" maxlength="100" size="50" />
            </td>
        </tr>
        <tr>
            <td align="right">
                网站关键字：
            </td>
            <td>
                <textarea name="Keyword" cols="80" rows="4"><%=keyword%></textarea>
            </td>
        </tr>
        <tr>
            <td align="right">
                网站描述：
            </td>
            <td>
                <textarea name="Description" cols="80" rows="5"><%=description%></textarea>
            </td>
        </tr>
        <tr>
            <td align="right">
                联系电话：
            </td>
            <td>
                <input type="text" name="Telphone" maxlength="50" value="<%=telphone %>" size="30" />
            </td>
        </tr>
        <tr>
            <td align="right">
                在线客服QQ：
            </td>
            <td>
                <input type="text" name="QQ" maxlength="500" value="<%=QQ %>" size="100" /><br /> 
                <span>(多个QQ以逗号分隔，当在线客服系统代码为空时才会在前台显示)</span>
            </td>
        </tr>
		<tr>
            <td align="right">
                在线客服系统代码：
            </td>
            <td>
                <textarea name="OnlineService" cols="90" rows="5"><%=OnlineService%></textarea><br />
				<span>(这里可以输入您申请的在线客服系统代码，如TQ、53KF、Live800等，为空则不显示)</span>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="2" align="center">
                    <input class="btn" type="submit" value="保存" />
                    <input type="hidden" name="ID" value="<%=id %>" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
