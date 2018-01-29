<%@ Page Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="links.aspx.cs" Inherits="WebUI.links" Title="无标题页" %>
<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
<div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><i class="next"></i>友情链接</div>
<div class="main">
    <div class="link_box">
        <div class="link_box_title"><h2>友情链接</h2></div>
        <div class="link_box_items">
            <div class="linkArea">
                <ul>
                <%=dataLinkList %>
                </ul>
            </div>
			<div class="clear"></div>
            <div style=" margin-top:5px; border-top:1px solid #999; padding-top:10px;" >
                欢迎百度权重大于4(含4)的网站申请友链，联系QQ：2352559188
            </div>
        </div>
    </div>
</div>

</asp:Content>
