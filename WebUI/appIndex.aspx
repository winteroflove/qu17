<%@ Page Title="" Language="C#" MasterPageFile="~/WebApp/AppMain.Master" AutoEventWireup="true" CodeBehind="appIndex.aspx.cs" Inherits="WebUI.WebApp.appIndex" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<link rel="miphtml" href="http://m.qu17.com/mip/" />
<script src="/WebApp/js/fs2.js" type="text/javascript"></script>
<script src="/WebApp/js/webapp.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="cheader" ContentPlaceHolderID="header" runat="server">
    <div class="index_header appheader">
        <div class="in-head-sous">
            <a class="logo" href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>"></a>
            <div class="search">
                <form action="/" method="post" onsubmit="return gotoDataList(this)">
                    <input type="text" placeholder="搜索旅游目的地..." id="skey" name="skey" class="sous" />
                    <input type="submit" class="submit" value="搜索" />
                </form>
            </div>
            <div class="main_nav">
                <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/daohang/" class="icon_m">导航</a>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="carticle" ContentPlaceHolderID="article" runat="server">
    <div class="article_box">
        <!-- 首页广告轮播开始 -->
        <div class="activity_slide">
			<ul class="activity_images">
                <%=dataScroll%>
			</ul>
			<div class="activity_titles clearfix">
                <%=dataScrollTitles%>
	   		</div>
        </div>
        <!-- 首页广告轮播结束 -->
        <div class="box_cgz">
            <div class="box_gn">
                <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/sale/" class="gnlink">
                    <div class="div_gnl">
                        <div class="icon_gn"></div>
                        <div class="title_gn">聚划算</div>
                    </div>
                </a>
            </div>
            <div class="box_gz">
                <div class="box_cj">
                    <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/chujing/" class="cjlink">
                        <div class="div_cjl">
                            <div class="icon_cj"></div>
                            <div class="title_cj">出境游</div>
                        </div>
                    </a>
                </div>
                <div class="box_zbsx">
                    <div class="box_zb">
                        <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/guonei/" class="zblink">
                            <div class="div_zbl">
                                <div class="icon_zb"></div>
                                <div class="title_zb">国内游</div>
                            </div>
                        </a>
                    </div>
                    <div class="box_sx">
                        <a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/chongqing/" class="sxlink">
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
            <div class="art_more"><a href="<%=ClassLibrary.Common.SysConfig.webSiteApp %>/zhinan/">更多...</a></div>
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
    <script type="text/javascript">
        activity_slide();
        activity_artlist();
    </script>
</asp:Content>