<%@ Page Title="" Language="C#" MasterPageFile="~/WebApp/Mip/MipAppMain.Master" AutoEventWireup="true" CodeBehind="appAbout.aspx.cs" Inherits="WebUI.WebApp.Mip.appAbout" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<link rel="canonical" href="http://m.qu17.com/aboutus/">
<style mip-custom>
i { font-style:normal;}
a {text-decoration:none;}
a:hover{text-decoration:none;}
ul {list-style:none;}

.index_header { width:100%; position:relative; z-index:940; background-color:#6aac02;}
.in-head { width:100%; height:40px; line-height:40px; background-color:#51ba2c;}
.backto { float:left; width:10px; height:40px; background:url(/WebApp/css/images/bg_webapp.png) no-repeat -60px -4px;margin-left:2%;margin-right:14px;}
.backto a { display:block; height:40px;}
.location { float:left; width:60%; color:#FFF;font-family:"黑体","宋体"; font-size:18px;}
.location h1 {font-weight:normal;font-size: 18px;}
.backhome { float:right; width:30px; height:40px; text-align:center;margin-right:2%;}
.backhome .icon_h {line-height: 55px;background: url(/WebApp/css/images/bg_webapp.png) no-repeat -143px -161px;display: block;font-size: 12px;color: #FFF;background-size: 400px 600px;height: 38px;}
.article_box3 { width:100%; margin-top:5px; overflow:hidden; padding-top:5px;color:#555;}
.article_title { width:100%; text-align:center; min-height:40px; line-height:40px; color:#555; font-size:20px;}
@media screen and (max-width:400px)  
{
.article_box3 { font-size:13px;}
.article_title { font-size:16px;}
}
.atl_info {width:92%;padding-left:4%; padding-right:4%;}
.atl_info a { color:#ff4400;}

.emptyline { width:100%; height:35px;}
.footer_button {height: 34px;width: 100%; border-top:1px solid #359339; background:#FFF; border-bottom:1px solid #359339; position:fixed;bottom: 0;z-index: 940;}
.footer_button a { float:left; width:33%; display:inline-block; font-size:12px; height:30px; line-height:30px; margin-top:2px; text-align:center;color:#359339; font-weight:bold;}
.footer_button a:not(:last-child) { border-right:1px solid #68ae6b; }
.footer_button a i {display: inline-block; line-height: 30px;padding-left: 25px;}
.footer_button .icon_tel { background:url(/WebApp/css/images/bg_footer.png) no-repeat 5px 5px;background-size: 25px 100px;}
.footer_button .icon_qq { background:url(/WebApp/css/images/bg_footer.png) no-repeat 3px -20px;background-size: 25px 100px;}
.footer_button .icon_msg { background:url(/WebApp/css/images/bg_footer.png) no-repeat 0px -47px;background-size: 25px 100px;}
.footer_button .icon_us { background:url(/WebApp/css/images/bg_footer.png) no-repeat 0px -72px;background-size: 25px 100px;}
.activity_slide{width:100%;position:relative;z-index:1;padding-top: 40px; margin-bottom:3px;}
.activity_slide a {height:100%;width:100%;display:none;position:absolute;z-index:2;top:0;left:0;overflow:hidden}
.activity_slide a mip-img{position:absolute;width: 100%;height: auto;height: 120px;min-width: 320px;max-width: 640px;}
.footer_box { width:100%; background-color:#e5e5e5; text-align:center; padding:7px 0px; color:#555;}
</style>
</asp:Content>

<asp:Content ID="cheader" ContentPlaceHolderID="header" runat="server">
    <div class="index_header">
    <div class="in-head">
        <div class="backto"><a href="#" target="_blank"></a></div>
        <div class="location"><h1>关于青旅</h1></div>
        <div class="backhome">
            <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/mip/" class="icon_h" target="_blank">首页</a>
        </div>
    </div>
    </div>
</asp:Content>

<asp:Content ID="carticle" ContentPlaceHolderID="article" runat="server">
    <div class="article_box3">
        <div class="atl_info">
            <%=dataAbout%>
        </div>
    </div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>
