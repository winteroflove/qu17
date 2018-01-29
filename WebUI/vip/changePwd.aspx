<%@ Page Title="" Language="C#" MasterPageFile="~/vip.Master" AutoEventWireup="true" CodeBehind="changePwd.aspx.cs" Inherits="WebUI.vip.changePwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

		    <h2>
        修改密码</h2>
    <form method="post" action="/vip/changePwd/post" onsubmit="return formChangePwd(this)">
    <table width="100%" class="vip martop8">
        <colgroup>
            <col class="label" width="20%" />
            <col />
        </colgroup>
        <tbody>
            <tr>
                <td>
                    用户名：
                </td>
                <td>
                    &nbsp;<%=userName %>
                </td>
            </tr>
            <tr>
                <td>
                    旧密码：
                </td>
                <td>
                    <input class="text" type="password" name="oldPwd" />
                </td>
            </tr>
            <tr>
                <td>
                    新密码：
                </td>
                <td>
                    <input class="text" type="password" name="newPwd" maxlength="20" />
                </td>
            </tr>
            <tr>
                <td>
                    确认密码：
                </td>
                <td>
                    <input class="text" type="password" name="newPwd2" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <input class="button" type="submit" value="保存" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>

</asp:Content>
