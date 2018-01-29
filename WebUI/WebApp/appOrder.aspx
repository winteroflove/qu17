<%@ Page Title="" Language="C#" MasterPageFile="~/WebApp/AppMain.Master" AutoEventWireup="true" CodeBehind="appOrder.aspx.cs" Inherits="WebUI.WebApp.appOrder" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="cheader" ContentPlaceHolderID="header" runat="server">
    <div class="in-head">
        <div class="backto"><a href="javascript:history.back();"></a></div>
        <div class="location"><h1>订单信息</h1></div>
        <div class="backhome">
            <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>" class="icon_h">首页</a>
        </div>
    </div>
</asp:Content>

<asp:Content ID="carticle" ContentPlaceHolderID="article" runat="server">
    <div class="order_msg">
        <p style="font-size:18px;" >订单已提交成功</p>
        <p>订单号：<span><%=orderNumber%></span></p>
        <p style="font-size:13px; padding-top:10px;">备注:稍后客服将联系您，或者您可以拨打我们的客服热线详细咨询！<br/><a href="tel:4000175761" class="telno">400-017-5761</a><br/>谢谢！</p>
    </div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">
<script type="text/javascript">
    clearCart();
</script>
</asp:Content>