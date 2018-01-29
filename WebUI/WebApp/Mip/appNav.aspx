<%@ Page Title="" Language="C#" MasterPageFile="~/WebApp/Mip/MipAppMain.Master" AutoEventWireup="true" CodeBehind="appNav.aspx.cs" Inherits="WebUI.WebApp.Mip.appNav" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<link rel="canonical" href="http://m.qu17.com/daohang/">
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

.hot_nav { width:96%; margin-left:2%; margin-right:2%; font-size:12px; position:relative; margin-top:76px;}
.hot_nav span { position:absolute; left:0px; top:0px; width:40px; line-height:40px; color:#333;}
.hot_nav_list { width:100%; padding-top:8px; padding-left:40px; box-sizing:border-box;}
.hot_nav_list a { border:1px solid #ff4400; padding:2px 8px; width:auto; margin-right:8px; border-radius:8px;color:#ff4400; display:inline-block; margin-bottom:10px;}

.article_nav { width:100%; position:relative;height:100%; }
.mnav_item { width:98%; margin-left:1%; position:relative;}
.nav_left { width:100%;border-bottom: 1px solid #2b8f08;border-top: 1px solid #4cdb5e;border-left: 1px solid #37c249;background-color: #37c249;
            color:#FFF; text-align:center; height:35px; line-height:35px; z-index:1;position: relative;}
.nav_left a {color:#FFF; }
.nav_right { width:100%; border: 1px solid #37c249; height:auto; min-height:100%;
             background-color:#FFF; padding-top:6px;padding-bottom:5px; z-index:5;}
.navlist { width:100%; line-height:20px;}
.navlist a {color:#777; padding:2px 4px; display:inline-block; margin-left:2px; margin-bottom:5px; border:1px solid #8a8a8a; border-radius:5px;}
.navlist .hot { color:#ff4400;}
.mnav_item .current { background-color:#FFF; color:#37c249;z-index:10;}
.t_cj { top:-37px;}
.t_gn { top:-74px;}
.t_sx { top:-111px;}
.t_zb { top:-148px;}
.t_zt { top:-185px;}
.t_qz { top:-222px;}

.nrlitem { width:100%; border-bottom:1px solid #dfdfdf;}
.nrlitem .navgroup { width:100%; height:32px; line-height:34px; color:#ff4400; position:relative;}
.nrlitem .navgroup a { color:#ff4400;padding:2px 4px;}
.nrlitem .navgroup .grouplist { position:absolute; right:5%; top:0px; width:30px; height:32px; background:url(/WebApp/css/images/bg_webapp.png) no-repeat -227px -165px;}
.nrlitem .navgroup .on { background-position:-193px -165px;}
.nrlitem .navlist { border-top:1px dashed #dfdfdf; padding-top:5px;}

</style>
</asp:Content>

<asp:Content ID="cheader" ContentPlaceHolderID="header" runat="server">
<mip-fixed type="top">
<div class="index_header">
    <div class="in-head">
        <div class="backto"><a href="#" target="_blank"></a></div>
        <div class="location"><h1>中青旅导航</h1></div>
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
    <div class="hot_nav">
        <span>热门：</span>
        <div class="hot_nav_list">
            <%=hotList %>
        </div>
    </div>
</asp:Content>

<asp:Content ID="carticle" ContentPlaceHolderID="article" runat="server">
    <div class="article_nav">
        <%=navList%>
        <!--div class='mnav_item'>
        <mip-accordion sessions-key="mip_1" type="automatic">
        <section>
        <h4 class='nav_left'>海岛</h4>
<div class='nav_right'>
<div class='navlist'>
<a href='http://m.qu17.com/pujidao/'>普吉岛</a>
<a href='http://m.qu17.com/maerdaifu/'>马尔代夫</a>
<a href='http://m.qu17.com/balidao/'>巴厘岛</a>
<a href='http://m.qu17.com/saibandao/'>塞班岛</a>
<a href='http://m.qu17.com/maoliqiusi/'>毛里求斯</a>
<a href='http://m.qu17.com/sumeidao/'>苏梅岛</a>
<a href='http://m.qu17.com/jizhoudao/'>济州岛</a>
<a href='http://m.qu17.com/saisheer/'>塞舌尔</a>
<a href='http://m.qu17.com/sililanka/'>斯里兰卡</a>
<a href='http://m.qu17.com/palao/'>帕劳</a>
<a href='http://m.qu17.com/shaba/'>沙巴</a>
<a href='http://m.qu17.com/daxidi/'>大溪地</a>
<a href='http://m.qu17.com/changtandao/'>长滩岛</a>
<a href='http://m.qu17.com/feiji/'>斐济</a>
</div>
</div></section>
<section>
<h4 class='nav_left'>国内</h4>
<div class='nav_right'>
<div class='nrlitem'>
<div class='navgroup'><a href='http://m.qu17.com/yunnan/'>云南</a><span class='grouplist'></span></div>
<div class='navlist'>
<a href='http://m.qu17.com/lijiang/'>丽江</a>
<a href='http://m.qu17.com/dali/'>大理</a>
<a href='http://m.qu17.com/xianggelila/'>香格里拉</a>
<a href='http://m.qu17.com/tengchong/'>腾冲</a>
<a href='http://m.qu17.com/xishuangbanna/'>西双版纳</a>
<a href='http://m.qu17.com/luguhu/'>泸沽湖</a>
</div>
</div>
<div class='nrlitem'>
<div class='navgroup'><a href='http://m.qu17.com/sichuan/'>四川</a><span class='grouplist'></span></div>
<div class='navlist'>
<a href='http://m.qu17.com/jiuzhaigou/'>九寨沟</a>
<a href='http://m.qu17.com/daocheng/'>稻城亚丁</a>
<a href='http://m.qu17.com/emeishan/'>峨眉山</a>
<a href='http://m.qu17.com/xilingxueshan/'>西岭雪山</a>
</div>
</div>
</div>

</section>

</mip-accordion></div-->
    </div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>
