<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="success.aspx.cs" Inherits="WebUI.success" %>
<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
<div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><i class="next"></i>提示信息</div>

<div class="main">
    <div class="order_box">
        <div class="order_box_title"><h2>提示信息</h2></div>
        <div class="order">
            <div class="step s3">第三步</div>
            <div class="content box">
                <div class="success_img"></div>
                <div class="success_line"></div>
                <div class="success_msg">
                    <p><%=payMessage%>您的订单已经成功提交，流水号是 <a href="<%=ClassLibrary.Common.SysConfig.webSite %>/vip/o<%=orderNumber %>.html"><%=orderNumber %></a></p>
                    <p>请牢记您的订单流水号，方便以后查询订单信息。</p>
                    <p>您可以进入 <a href="<%=ClassLibrary.Common.SysConfig.webSite %>/vip/">订单管理</a> 页面查看您的订单情况，也可以拨打我们的客服热线：<strong class="color1">400-017-5761</strong> 进行详细咨询，谢谢！</p>
                </div>
                <div class="success_bgn">
                    <a href="<%=ClassLibrary.Common.SysConfig.webSite %>/"><img src="/image/btn_back.gif" alt="返回首页" /></a>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">releaseCart();</script>

</asp:Content>
