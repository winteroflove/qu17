<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebUI.register" ValidateRequest="false" %>
<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="adverse" ContentPlaceHolderID="adverse" runat="server">
<div class="login_main">
   <div class="main">
       <div class="reg_wrap">
            <div class="login_top"><span class="login_title">注册中青旅</span><span class="reg_link"><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/login/">登录</a></span></div>
            <form action="/register/" onsubmit="return CheckRegister(this)" method="post">
                <ul>
                    <li><div class="login_info"><i class="reg_name"></i>
                        <input type="text" id="reg_username" name="UserName" maxlength="30" onblur="checkEmail(this)" placeholder="Email地址" value=""/></div>
                        <div id="chkemail" class="checkinput hide">请输入正确的电子邮箱地址！</div>
                    </li>
                    <li><div class="login_info"><i class="login_name"></i>
                        <input type="text" name="Nickname" id="reg_nickname" maxlength="20" placeholder="常用昵称,可输入中文或英文" value="" /></div>
                    </li>
                    <li><div class="login_info"><i class="reg_tel"></i>
                        <input type="text" name="Telphone" id="reg_tel" maxlength="11" onblur="checkMobile(this)" placeholder="手机号" value="" /></div>
                        <div id="chkmobile" class="checkinput hide">请输入正确的手机号码！</div>
                    </li>
                    <li><div class="login_info"><i class="login_password"></i>
                        <input type="password" id="login_pwd" name="Password" maxlength="20" placeholder="密码" /></div>
                    </li>
                    <li><div class="login_info"><i class="login_password"></i>
                        <input type="password" id="reg_pwd" name="Password2" placeholder="确认密码" /></div></li>
                    <li><div class="login_info2"><i class="login_random"></i><input  id="login_code" type="text" name="code" value="" placeholder="验证码" /></div>
                        <img src="/random.aspx" id="imgcode" onclick="ChangeCode()" alt="验证码" />
                    </li>
                    <li><div class="login_submit"><input type="submit" class="submit" value="立即注册" /></div></li>
                </ul>
            </form>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(".login_main").attr("background", "url(/image/sanxia.png) repeat-y");
</script>
</asp:Content>
