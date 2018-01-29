<%@ Page Title="" Language="C#" MasterPageFile="~/WebApp/Mip/MipAppMain.Master" AutoEventWireup="true" CodeBehind="appArticleDetail.aspx.cs" Inherits="WebUI.WebApp.Mip.appArticleDetail" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<link rel="canonical" href="<%=mipUrl %>">
<style mip-custom>
body,h1{ font-size:100%;}
input {margin:0px; padding:0px;}
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

.in-head-sous2 { width:100%;height: 32px; background-color:#FFF; padding:2px 0px;}
.in-head-sous2 .search { margin:0px 5%; width:90%; height:26px;border:1px solid #60b340; position:relative;overflow: hidden;}
.in-head-sous2 .search .sous { border:none; width:100%; padding-right:65px; height:25px; padding-left:10px;box-shadow: none;box-sizing: border-box;color: #716f6f;-webkit-appearance: none;}
.in-head-sous2 .search .submit { border:none; border-left:1px solid #60b340; position:absolute; top:0px; right:0px; width:64px; color:#46a720; background-color:#fff;height:100%;background:url(/WebApp/css/images/bg_webapp.png) no-repeat -10px -7px;padding-left: 20px; border-radius:0px;}
.in-head-sous2 .search { margin:0px 0.5%; width:84%; float:left; height:30px;}
.in-head-sous2 .search .sous { height:29px;}
.in-head-sous2 .main_nav { float:left; width:14%; height:32px;text-align:center;}
.in-head-sous2 .icon_m {color: #46a720;font-size: 12px;display: block;width: 28px;background: url(/WebApp/css/images/bg_webapp.png) no-repeat -236px -136px;margin: auto;height: 32px;line-height: 46px;background-size: 500px 500px;}
.in-head-sous2 .search .submit { background-position:-10px -5px;}

.article_box3 { width:100%; margin-top:5px; overflow:hidden; padding-top:5px;color:#555;margin-top: 76px;}
.article_title { width:100%; text-align:center; min-height:40px; line-height:40px; color:#555; font-size:20px;}
@media screen and (max-width:400px)  
{
.article_box3 { font-size:13px;}
.article_title { font-size:16px;}
}
.article_info { width:100%;text-align:center; border-top:1px solid #edecea;border-bottom:1px solid #edecea; line-height:24px;}
.article_info span { padding-right:15px;}
@media screen and (max-width:550px)  
{
    .article_info { text-align:left;}
    .article_info span { display:block; padding-left:20px; padding-right:0px;}
}
.article_content { padding-left:4%; padding-right:4%; padding-top:10px; padding-bottom:10px; font-size:16px; line-height:16px;}
.article_content a { color:#ff4400;}
.article_content mip-img { width:100%; max-width:605px; height:auto; border-radius:8px; padding:5px 0px; display:block;margin: auto;}
.atlralte { width:92%; padding-left:4%; font-size:14px; padding-bottom:6px;}
.atlralte div { height:25px; line-height:25px; overflow:hidden; color:#359a07;}
.atlralte a { color:#555;}

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
<mip-fixed type="top">
<div class="index_header">
    <div class="in-head">
        <div class="backto"><a href="#" target="_blank"></a></div>
        <div class="location">旅游指南</div>
        <div class="backhome">
            <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/mip/" class="icon_h" target="_blank">首页</a>
        </div>
    </div>
    <div class="in-head-sous2">
        <div class="search">
            <mip-form action="/" method="post" url="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/mip/search/">
                <input type="text" placeholder="搜索旅游目的地..." id="skey" name="skey" class="sous" />
                <input type="submit" class="submit" value="搜索" />
            </mip-form>
        </div>
        <div class="main_nav">
            <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/mip/daohang/" class="icon_m" target="_blank">导航</a>
        </div>
    </div>
</div>
</mip-fixed>
</asp:Content>

<asp:Content ID="carticle" ContentPlaceHolderID="article" runat="server">
    <div class="article_box3">
        <div class="article_title"><h1><%=articleTitle%></h1></div>
        <div class="article_info">
            <span>作者：<%=news.Editor %></span>
            <span>发表时间：<%=news.CreatedTime.ToString("yyyy-MM-dd HH:mm") %></span>
            <span>人气：<%=news.ViewCount %></span>
        </div>
        <div class="article_content">
            <%=articleData%>
        </div>
        <div class="atlralte">
            <%=prevAndNexLink%>
        </div>
    </div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>