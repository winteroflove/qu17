<%@ Page Title="" Language="C#" MasterPageFile="~/vip.Master" AutoEventWireup="true"
    CodeBehind="info.aspx.cs" Inherits="WebUI.vip.info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        个人资料</h2>
    <form method="post" action="/vip/info/post" onsubmit="return formInfo(this)">
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
                    &nbsp;<%=member.UserName %>
                </td>
            </tr>
            <tr>
                <td>
                    昵称：
                </td>
                <td>
                    <input class="text" type="text" name="Nickname" maxlength="20" value="<%=member.Nickname %>" />
                    <span class="red">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    联系电话：
                </td>
                <td>
                    <input class="text" type="text" name="Telphone" maxlength="12" value="<%=member.Telphone %>" onblur="checkMobile(this)" />
                    <span class="red">*</span>
                    <div id="chkmobile" class="checkinput hide">请输入正确的手机号码！</div>
                </td>
            </tr>
            <tr>
                <td>
                    联系QQ：
                </td>
                <td>
                    <input class="text" type="text" name="QQ" maxlength="20" value="<%=member.QQ %>" />
                </td>
            </tr>
            <tr>
                <td>
                    密码保护问题：
                </td>
                <td>
                    &nbsp;&nbsp;<select name="SafetyQuestion">
                        <option style="color: #666" value="0">请选择密码提示问题</option>
                        <option value="您母亲的姓名是?">您母亲的姓名是?</option>
                        <option value="您父亲的姓名是?">您父亲的姓名是?</option>
                        <option value="您配偶的姓名是?">您配偶的姓名是?</option>
                        <option value="您母亲的生日是?">您母亲的生日是?</option>
                        <option value="您父亲的生日是?">您父亲的生日是?</option>
                        <option value="您配偶的生日是?">您配偶的生日是?</option>
                        <option value="您的出生地是?">您的出生地是?</option>
                        <option value="您的小学校名是?">您的小学校名是?</option>
                        <option value="您的中学校名是?">您的中学校名是?</option>
                        <option value="您的大学校名是?">您的大学校名是?</option>
                    </select>
                    <span class="red">*</span>

                    <script type="text/javascript">
                        document.getElementsByName("SafetyQuestion")[0].value = "<%=member.SafetyQuestion %>";
                    </script>

                </td>
            </tr>
            <tr>
                <td>
                    密码保护答案：
                </td>
                <td>
                    <input class="text" type="text" name="SafetyAnswer" maxlength="50" value="<%=member.SafetyAnswer %>" />
                    <span class="red">*</span>
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
    <input type="hidden" name="ID" value="<%=member.ID %>" />
    </form>
</asp:Content>
