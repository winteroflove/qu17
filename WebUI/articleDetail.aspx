<%@ Page Language="C#" MasterPageFile="~/FireMain.Master" AutoEventWireup="true" CodeBehind="ArticleDetail.aspx.cs" Inherits="WebUI.articleDetail" ValidateRequest="false" %>

<asp:Content ID="chead" ContentPlaceHolderID="head" runat="server">
<meta name="mobile-agent" content="format=html5;url=<%=appurl %>" /><script type="text/javascript">
    uaredirect("<%=appurl %>");
</script>
</asp:Content>

<asp:Content ID="cbody" ContentPlaceHolderID="body" runat="server">
<div class="location" ><i class="icon"></i><a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" title="">重庆青年旅行社</a><%=location %></div>
    <div class="main">
        <div class="sidebar">
            <div class="side_sales side_rec">
                <div class="side_rec_top">当季推荐</div>
			    <ul class="sales_items">
			        <%=dataSalesList %>
                </ul>
            </div>
            <div class="side_gonglue">
                <div class="side_gonglue_top">最新旅游攻略</div>
                <ul class="side_news_items ">
                    <%=dataGongLuList %>
                </ul>
            </div>
        </div>
        <div class="index_left">
            <div class='articleDetail_box'>
                <%=routelistAds %>
                <div class='articleDetail_summary'>
                    <div class='articleDetail_title'><h1><%=articleTitle%></h1></div>
                    <div class='articleDetail_writer'><span><%=news.Editor%></span><span><%=news.CreatedTime.ToString("yyyy-MM-dd HH:mm") %></span><span><%=ntag %></span><span><%=news.ViewCount %>人浏览</span>
                        <div class="ads_zan">
                            <i></i><a href="javascript:void(0)" onclick="javascript:Support(<%=newsID %>)">赞一下（<s id="ads_zan"><%=zanCount%></s>）</a>
                        </div>
                    </div>
                </div>
                <div class="articleDetail_content">
                    <%=news.Content %>
                </div>
                <div class="articleDetail_share">
                    <div class="detail_link">
                        <a href="<%=ClassLibrary.Common.SysConfig.webSite %>/" rel='nofollow'>返回重庆青年旅行社首页</a><a href='<%=ClassLibrary.Common.SysConfig.webSite %>/<%=displayPing %>/' target='_blank'><%=displayName %>旅游线路</a>
                    </div>
                    <div class="bdsharebuttonbox"><a href="#" class="bds_more" data-cmd="more"></a><a href="#" class="bds_qzone" data-cmd="qzone" title="分享到QQ空间"></a><a href="#" class="bds_tsina" data-cmd="tsina" title="分享到新浪微博"></a><a href="#" class="bds_tqq" data-cmd="tqq" title="分享到腾讯微博"></a><a href="#" class="bds_weixin" data-cmd="weixin" title="分享到微信"></a></div>
                    <script type="text/javascript">window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "24" }, "share": {} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>
                </div>
                <div class="articleDetail_footer">
                    <%=prevAndNexLink%>                </div>
            </div>
            <div class="articledetail_relate">
                <div class="adr_top">
                    <h2>相关攻略</h2>
                </div>
                <ul>
                    <%=relateArticleList %>
                </ul>
            </div>
        </div>
    </div>
    <div class="clear"></div>
</asp:Content>

<asp:Content ID="cfooter" ContentPlaceHolderID="footer" runat="server">

</asp:Content>