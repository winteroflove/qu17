<%@ Page Title="" Language="C#" MasterPageFile="~/WebApp/Mip/MipAppMain.Master" AutoEventWireup="true" CodeBehind="appRouteDetail.aspx.cs" Inherits="WebUI.WebApp.Mip.appRouteDetail" ValidateRequest="false" %>

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

.article_box2 { width:100%; margin-top:5px;overflow:hidden; padding-top:5px;}
.detail_box { margin-top:0px;}
.detail_info { width:100%; max-width:500px; margin:auto; margin-top:76px;}
.detl_img { width:100%;background-size:cover; height:300px;}
.detl_tp { width:100%; height:40px; margin-top:-40px; position:relative;}
.detl_title { width:100%; background:url(/WebApp/css/images/opacity.png) repeat; height:40px; z-index:1; color:#FFF; padding-right:90px;
              box-shadow: none;box-sizing: border-box;-webkit-appearance: none; line-height:40px; font-size:13px; overflow:hidden;}
@media screen and (max-width:500px) { 
.detl_title { line-height:20px;}
}
.detl_price { position:absolute; right:0; top:0; width:90px; text-align:center; height:40px; background-color:#f18c1b; z-index:99; line-height:40px; font-size:12px; color:#FFF;}
.detl_price i { font-size:22px; color:#FFF;font-style:normal;}
.detl_content { width:100%; overflow:hidden;}
.date_top { width:100%; height:32px; border-bottom:1px solid #8a8a8a; line-height:32px; font-size:12px; color:#595959; background-color:#FFF;}
.date_top span { color:#359a07; font-size:14px; font-weight:bold; padding-left:4%;}
.date_top span:before { content:""; padding:5px 15px; background:url(/WebApp/css/images/bg_webapp.png) no-repeat -247px -12px;}
.booking_go {width:100%; overflow:hidden; background-color:#FFF; padding-bottom:6px;padding-top: 6px;}
.booking_go a { margin-left:4%; width:100px; height:30px; display:block; text-align:center; color:#FFF; line-height:30px; background-color:#6dba42; border-radius:3px; cursor:pointer;}
.detl_ts_top {width:100%; background-color:#FFF;border-bottom:1px solid #8a8a8a;border-top:1px solid #8a8a8a; height:30px;color:#595959; line-height:30px;overflow:hidden;}
.detl_ts_top span { padding-left:4%;}
.detl_ts_top span:before { content:""; padding:5px 15px; background:url(/WebApp/css/images/bg_webapp.png) no-repeat -172px -50px;}
.detl_ts_txt { width:92%; padding:8px 0; padding-left:4%; padding-right:4%; background-color:#FFF; color:#555;}
/*.detl_ts_txt img { width:100%; height:auto; max-width:605px;}*/
.detl_dp_top {width:100%; background-color:#FFF;border-top:1px solid #8a8a8a;border-bottom:1px solid #8a8a8a; height:30px;color:#595959; line-height:30px;overflow:hidden;}
.detl_dp_top span { padding-left:4%;}
.detl_dp_top span:before { content:""; padding:5px 15px; background:url(/WebApp/css/images/bg_webapp.png) no-repeat -172px -11px;}
.detl_dp_txt { width:92%;padding-left:4%; padding-right:4%; height:35px;border-bottom:1px solid #8a8a8a; line-height:35px; color:#595959; background:#FFF;}
.detl_dp_txt span { color:#f18c1c; font-size:22px;}
.detl_myd { float:left;}
.detl_dpn { float:right; text-align:right;}
.route_date { height:30px; width:100%; line-height:30px; position:relative;}
.icon_r { width:20px;height: 30px; position:absolute;left:-10px;top:0;background:url(/WebApp/css/images/bg_webapp.png) no-repeat -10px -233px;}
.rdtitle { width:100%; padding-left:15px; box-sizing:border-box; position:relative; color:#33bd61;}
.date_no { width: 65px;position: absolute;left: 15px;top: 0px;}/*background: url(images/bg_webapp.png) no-repeat -106px -168px;font-size: 12px;padding-left: 10px;*/
.date_title { width:100%; padding-left:65px; box-sizing:border-box; overflow:hidden; height:30px;}
.route_dtl { padding:8px 0px; padding-left:15px; padding-right:2%; color:#666;}
.route_dtl mip-img { max-width:363px; height:auto;}
.route_tips {padding:10px; margin-left:15px; margin-right:2%; background-color:#eefaf7;border-radius: 4px;color:#33bd61;}
.catering { width:100%; line-height:25px;}
.catering span { padding-right:10px;}
@media screen and (max-width:275px) { 
.catering span { display:block;}
}
.hotel {width:100%; line-height:25px; overflow:hidden;}
</style>
</asp:Content>

<asp:Content ID="cheader" ContentPlaceHolderID="header" runat="server">
<mip-fixed type="top">
<div class="index_header">
    <div class="in-head">
        <div class="backto"><a href="#" target="_blank"></a></div>
        <div class="location">线路详情</div>
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
    <div class="article_box2 detail_box">
        <div class="detail_info">
            <mip-img class="detl_img" src="<%=image%>"></mip-img>
            <div class="detl_tp">
                <div class="detl_title"><%=route.Title %></div>
                <div class="detl_price">&yen;<i><%=price %></i>起</div>
            </div>
        </div>
        <div class="detl_content">
            <div class="detl_item">
                <div class="date_top"><span>出发日期与价格</span>[详询业务人员]</div>
                <div class="booking_go"><a href="<%=buyEventStr %>" target="_blank">立即预订</a></div>
                <div class="detl_ts_top"><span>线路特色</span></div>
                <div class="detl_ts_txt">
                    <%=routeFeature %>
                </div>
                <div class="detl_ts_top"><span>行程介绍</span></div>
                <div class="detl_ts_txt">
                    <%=routedays%>
                </div>
                <div class="detl_ts_top"><span>费用说明</span></div>
                <div class="detl_ts_txt">
                    <%=descriptionPrice%>
                </div>
                <div class="detl_ts_top"><span>预订须知</span></div>
                <div class="detl_ts_txt">
                    <%=routeNotice%>
                </div>
                <div class="detl_dp_top"><span>游客点评</span></div>
                <div class="detl_dp_txt">
                    <div class="detl_myd">满意度：<span><%=commentGrade%></span></div>
                    <div class="detl_dpn"><span><%=commentCount%></span>人点评</div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>