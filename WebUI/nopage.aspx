<%@ Page Title="" Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="nopage.aspx.cs" Inherits="WebUI.nopage" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
    <div class="main" id="main">
        <div class="box_nopage">
            <div class="nopage_text">
                <p style="font-size:30px; color:Red; padding-top:30px; padding-bottom:20px;">非常抱歉，页面访问失败，需要重新选择。 </p>
                <p style="font-size:18px; padding-bottom:10px;">您可以：</p>
                <p style="font-size:18px; padding-bottom:10px; text-indent:2em;">1. 直接访问重庆中国青年旅行社网站首页<a href="<%=ClassLibrary.Common.SysConfig.webSite %>">www.qu17.com</a></p>
                <p style="font-size:18px; padding-bottom:10px; text-indent:2em;">2. 或致电：400-017-5761(免长话费)，直接咨询国内、出国、重庆周边等旅游线路</p>
            </div>
        </div>
    </div>
    <div class="clear"></div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>