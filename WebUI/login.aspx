<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebUI.login" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="adverse" ContentPlaceHolderID="adverse" runat="server">
<div class="login_main">
   <div class="main">
       <div class="login_wrap">
            <div class="login_top"><span class="login_title">登录中青旅</span><span class="reg_link"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/register/">注册</a></span></div>
            <form action="/login/" onsubmit="return CheckLogin(this)" method="post">
                <ul>
                    <li><div class="login_info"><i class="login_name"></i><input id="login_name" type="text" name="UserName" maxlength="30" placeholder="请输入您的Email登录地址" value=""/></div></li>
                    <li><div class="login_info"><i class="login_password"></i><input id="login_pwd" type="password" name="Password" maxlength="20" placeholder="密码" /></div></li>
                    <li><div class="login_info2"><i class="login_random"></i><input  id="login_code" type="text" name="code" placeholder="验证码" value=""/></div>
                        <img src="/random.aspx" id="imgcode" onclick="ChangeCode()" alt="验证码" />
                    </li>
                    <li>
                        <div class="login_submit"><input type="submit" class="submit" value="立即登录" />
                        <span class="forgetpwd">忘了密码？请联系客服重置密码！</span></div>
                    </li>
                </ul>
            </form>
        </div>
    </div>
</div>

</asp:Content>
