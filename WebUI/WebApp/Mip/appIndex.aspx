<%@ Page Title="" Language="C#" MasterPageFile="~/WebApp/Mip/MipAppMain.Master" AutoEventWireup="true" CodeBehind="appIndex.aspx.cs" Inherits="WebUI.WebApp.Mip.appIndex" ValidateRequest="true" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<link rel="canonical" href="http://m.qu17.com/">
<style mip-custom>
input {margin:0px; padding:0px;}
i { font-style:normal;}
a {text-decoration:none;}
a:hover{text-decoration:none;}
ul {list-style:none;}

.index_header { width:100%; position:relative; z-index:940; background-color:#6aac02;}
.appheader {height:40px; }
.in-head-sous { width:100%; height:33px;padding-left:50px; padding-right:35px;box-sizing:border-box;padding-top: 7px;}
.in-head-sous .logo { width:50px; height:40px; position:absolute; background:url(/WebApp/css/images/bg_webapp.png) no-repeat -54px -287px; left:0px;top: 1px;}
.in-head-sous .search { margin:0px 0.5%; width:99%; height:25px;border:1px solid #FFF; position:relative;overflow: hidden;}
.in-head-sous .search .sous { border:none; width:100%; padding-right:65px; height:25px; padding-left:5px;box-shadow: none;box-sizing: border-box;color: #716f6f;-webkit-appearance: none;}
.in-head-sous .search .submit { border:none; border-left:1px solid #60b340; position:absolute; top:0px; right:0px; width:60px; color:#46a720; background-color:#fff;height:100%;background:url(/WebApp/css/images/bg_webapp.png) no-repeat -10px -7px;padding-left: 20px; border-radius:0px;}
.in-head-sous .main_nav {width:25px; height:40px;text-align:center; position:absolute; right:5px;top: 0px;}
.in-head-sous .icon_m {color: #FFF;font-size: 12px;display: block;width: 25px;background: url(/WebApp/css/images/bg_webapp.png) no-repeat -285px -293px;margin: auto;height: 40px;line-height: 64px;background-size: 500px 500px;}
.in-head-sous .search .submit { background-position:-10px -5px;}
.article_box { width:96%; padding-left:2%; padding-right:2%; margin-top:5px; overflow:hidden;}
.box_cgz { width:100%; height:120px;}
.box_cgz .box_gn { float:left; width:39%; margin-right:1%;background-color:#3bd12f; text-align:center; line-height:120px; font-size:20px; border-radius:3px;}
.box_cgz .box_gn .gnlink {color:#FFF; font-family:"黑体","宋体"; display:block;}
.div_gnl { width:100px; height:120px; margin:0 auto;}
.div_gnl .icon_gn { width:40px; float:left; height:40px; margin-top:40px; background:url(/WebApp/css/images/bg_webapp.png) no-repeat -253px -287px;}
.div_gnl .title_gn { width:55px; float:left; text-align:center;line-height:120px; font-size:16px; }
@media screen and (max-width:300px) 
{
.div_gnl { width:60px;}
.div_gnl .icon_gn { width:60px; height: 35px;background: url(/WebApp/css/images/bg_webapp.png) no-repeat -242px -288px;}
.div_gnl .title_gn { width:60px; line-height:20px;font-size:14px; }
}

.box_cgz .box_gz { float:left; width:60%;}
.box_gz .box_cj { width:100%; height:58px; margin-bottom:4px; background-color:#00baff;border-radius:3px;}
.box_cgz .box_cj .cjlink {color:#FFF; display:block; font-weight:bold;}
.div_cjl { width:100px; height:55px; margin:0 auto;}
.div_cjl .icon_cj { width:45px; float:left; height: 55px;background: url(/WebApp/css/images/bg_webapp.png) no-repeat -54px -219px;}
.div_cjl .title_cj { width:50px; float:left; text-align:center;line-height:60px;font-size:14px; }

.box_gz .box_zbsx {width:100%; height:58px;}
.box_gz .box_zb { width:49.5%; float:left; height:58px; background-color:#e5639a;border-radius:3px;}
.box_cgz .box_zb .zblink {color:#FFF; display:block; font-weight:bold;}
.div_zbl { width:100px; height:55px; margin:0 auto;}
.div_zbl .icon_zb { width:40px; float:left; height: 55px;background: url(/WebApp/css/images/bg_webapp.png) no-repeat  -124px -219px;}
.div_zbl .title_zb { width:55px; float:left; text-align:center;line-height:60px;font-size:14px; }

.box_gz .box_sx { width:49.5%; float:right; height:58px; background-color:#ffbe24;border-radius:3px;}
.box_cgz .box_sx .sxlink {color:#FFF; display:block; font-weight:bold;}
.div_sxl { width:100px; height:55px; margin:0 auto;}
.div_sxl .icon_sx { width:40px; float:left; height: 55px;background: url(/WebApp/css/images/bg_webapp.png) no-repeat -185px -220px;}
.div_sxl .title_sx { width:55px; float:left; text-align:center;line-height:60px;font-size:14px; }

@media screen and (max-width:400px)  
{
.div_zbl { width:60px;}
.div_zbl .icon_zb { width:60px; height: 35px;background: url(/WebApp/css/images/bg_webapp.png) no-repeat -116px -229px;}
.div_zbl .title_zb { width:60px; line-height:20px;font-size:12px; }
.div_sxl { width:60px;}
.div_sxl .icon_sx { width:60px; height: 35px;background: url(/WebApp/css/images/bg_webapp.png) no-repeat -178px -230px;}
.div_sxl .title_sx { width:60px; line-height:20px;font-size:12px; }
}
.box_art { width:100%; height:30px;font-size:12px; line-height:30px; margin-top:3px;}
.art_tip { float:left; width:85%; padding-left:3px; border:1px solid #6aac02; border-radius:3px 0px 0px 3px; color:#6aac02; box-sizing:border-box;}
.art_tip span { float:left;}
.art_tip .art_list { float:left;height:30px;overflow: hidden;}
.art_tip .art_list a { color:#6aac02;}
.art_tip .art_list li { height:30px;}
.art_more { float:left; width:15%; text-align:center;border:1px solid #6aac02; border-left:none; border-radius:0px 3px 3px 0px; box-sizing:border-box;}
.art_more a { color:#6aac02;display: block;}

@media screen and (max-width:300px)  
{
    .art_tip { width:79%;}
    .art_tip .art_list { width:70%; overflow:hidden;}
    .art_more { width:21%;}
}

.box_zhuti { width:100%; height:80px; margin-top:3px;}
.box_zhuti ul { float:left; width:100%;}
.box_zhuti ul li:nth-child(1) { background-color:#93ce3a;}
.box_zhuti ul li:nth-child(2) { background-color:#ff813c;}
.box_zhuti ul li:nth-child(3) { background-color:#4dd1ff;}
.box_zhuti ul li:nth-child(4) { background-color:#ff7171;}
.box_zhuti ul .box_item { float:left; width:23.5%; height:100%; margin-left:2%; border-radius:3px;}
.box_zhuti ul li:first-child { margin-left:0px;}
.box_zhuti ul .box_item a { display:block;}
.box_zhuti ul .item_text {width:60px; height:80px; margin:0 auto;}
.box_zhuti ul .icon_img {height: 40px; width:60px; padding-top: 5px; text-align:center;}
.box_zhuti ul .icon_img mip-img {width:44px; margin-left:8px;}
.box_zhuti ul .item_title {text-align:center;line-height:20px;font-size:14px; color:#FFF;}
.box_zhuti .zt_more { float:left; width:8%; background-color:#ff5f00;border-radius: 3px 6px;}
.box_zhuti .zt_more .morelink { width: 15px;margin: auto;height: 100%;display: block;font-size: 12px;color: #FFF;line-height: 11px;text-align: center;padding-top: 2px;padding-bottom: 1px;}

.hotRoute { width:100%; overflow:hidden;}
.hotRoute .hot_tip { width:100%; height:26px; line-height: 26px; font-size:14px; background-color:#6aac02; margin:3px 0px;}
.hotRoute .hot_tip span:first-child { color:#FFF; text-align:center; width:60px; float:left;} 
.hotRoute .hot_tip span:last-child { color:#FFF; text-align:center; width:30px; float:right;} 
.hotRoute ul { width:100%;border-bottom:1px solid #6dc100;}
.hotRoute ul li { width:100%; height:67px;padding-left:105px; margin-top:3px; box-sizing:border-box; position:relative; border-bottom:1px solid #dfdfdf; }
.hotRoute ul li a { display:block;}
.hotRoute ul .lastline { border:none;}
.hot_img { width:100px; height:64px; position:absolute; left:0px; top:0px; background-size:cover;}
.hot_title { width:100%;color:#555;background-color:#FFF; font-size:14px; height:34px; padding:3px 0px; overflow:hidden;}
.hot_price { width:100%; text-align:right; color:#ff7200; font-size:12px; height:20px;}
.hot_price em {font-style:normal; font-size:16px;}

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
    <div class="index_header appheader">
        <div class="in-head-sous">
            <a class="logo" href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/mip/" target="_blank"></a>
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
    <div class="article_box">
        <!-- 首页广告轮播开始 -->
        <div class="activity_slide">
        <mip-carousel 
            autoplay
            defer="3000"
            width="640"
            height="120"
            layout="fixed-height">
            <%=dataScroll%>
        </mip-carousel>
        </div>
        <!-- 首页广告轮播结束 -->
        <div class="box_cgz">
            <div class="box_gn">
                <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/mip/sale/" class="gnlink" target="_blank">
                    <div class="div_gnl">
                        <div class="icon_gn"></div>
                        <div class="title_gn">聚划算</div>
                    </div>
                </a>
            </div>
            <div class="box_gz">
                <div class="box_cj">
                    <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/mip/chujing/" class="cjlink" target="_blank">
                        <div class="div_cjl">
                            <div class="icon_cj"></div>
                            <div class="title_cj">出境游</div>
                        </div>
                    </a>
                </div>
                <div class="box_zbsx">
                    <div class="box_zb">
                        <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/mip/guonei/" class="zblink" target="_blank">
                            <div class="div_zbl">
                                <div class="icon_zb"></div>
                                <div class="title_zb">国内游</div>
                            </div>
                        </a>
                    </div>
                    <div class="box_sx">
                        <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/mip/chongqing/" class="sxlink" target="_blank">
                            <div class="div_sxl">
                                <div class="icon_sx"></div>
                                <div class="title_sx">周边游</div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <div class="box_art">
            <div class="art_tip">
                <span>资讯：</span>
                <ul class="art_list" id="art_list">
                    <%=dataArticleList%>
                </ul>
            </div>
            <div class="art_more"><a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/mip/zhinan/" target="_blank">更多...</a></div>
        </div>
        <div class="box_zhuti">
            <ul>
                <%=dataZhutiList%>
            </ul>
        </div>
        <div class="hotRoute">
            <div class="hot_tip"><span>青旅推荐</span><span>HOT</span></div>
            <ul>
                <%=dataRouteList%>
            </ul>
        </div>
  </div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>