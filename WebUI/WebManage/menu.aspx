<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="WebUI.Manager.menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>网站后台管理</title>
    <link href="css/frame.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            padding: 6px 0 0 6px;
            background: #c5e2f0;
            overflow:hidden;
        }
        html{overflow:hidden;}
        
    </style>
</head>
<body>
    <img class="fl" alt="" title="" src="images/nav_top.png" />
    <div id="menu" class="menu">
        <ul id="slide">
            <li class="top"><span onclick="menuToggle(this)">+ 全部展开</span> <span onclick="location.reload();">
                刷新菜单</span></li>

            <li><a class="bigMenu" href="javascript:void(0)">文章管理</a>
                <ul>                    
                    <li><a href="News/NewsList.aspx?cid=1" target="main-frame">旅游攻略</a></li>
                    <li><a href="News/NewsList.aspx?cid=2" target="main-frame">旅游资讯</a></li>
                </ul>
            </li>
            <li style="display: none"><a class="bigMenu" href="javascript:void(0)">文章类型管理</a>
                <ul>
                    <li><a href="NewsClass/NewsClassList.aspx" target="main-frame">文章类型管理</a></li>
                    <li><a href="NewsClass/NewsClassAdd.aspx" target="main-frame">添加文章类型</a></li>
                </ul>
            </li>
            <li><a class="bigMenu" href="javascript:void(0)">路线管理</a>
                <ul>
                    <li><a href="Routes/RouteList.aspx" target="main-frame">路线管理</a></li>
                    <li><a href="Routes/RouteAdd.aspx" target="main-frame">添加路线</a></li>
                    <li><a href="RouteComment/RouteCommentList.aspx" target="main-frame">路线评论管理</a></li>
                </ul>
            </li>
            <li><a class="bigMenu" href="javascript:void(0)">路线类型管理</a>
                <ul>
                    <%=BindRouteClass()%>
                    <li><a href="RouteType/RouteTypeList.aspx" target="main-frame">主题类型管理</a></li>
                </ul>
            </li>
            <li><a class="bigMenu" href="javascript:void(0)">SEO信息管理</a>
                <ul>
                    <li><a href="SeoInfo/SeoInfoList.aspx" target="main-frame">线路列表SEO</a></li>
                </ul>
            </li>
            <li><a class="bigMenu" href="javascript:void(0)">订单管理</a>
                <ul>
                    <li><a href="Orders/OrdersList.aspx" target="main-frame">订单管理</a></li>
                </ul>
            </li>
            <li><a class="bigMenu" href="javascript:void(0)">广告管理</a>
                <ul>
                    <li><a href="Advertise/ScrollImageList.aspx" target="main-frame">首页滚动图片管理</a></li>
                    <li><a href="Advertise/SaleAdvertiseList.aspx" target="main-frame">特价广告管理</a></li>
                    <li><a href="Advertise/AppScrollImageList.aspx" target="main-frame">移动滚动图片管理</a></li>
                </ul>
            </li>
            <li><a class="bigMenu" href="javascript:void(0)">链接管理</a>
                <ul>
                    <li><a href="Links/LinksList.aspx" target="main-frame">友情链接管理</a></li>
                    <li><a href="Links/LinksAdd.aspx" target="main-frame">添加友情链接</a></li>
                    <li><a href="Links/ImportLinks.aspx" target="main-frame">批量导入链接</a></li>
                    <li><a href="Links/InternalLinkList.aspx" target="main-frame">内部链接管理</a></li>
                    <li><a href="Links/InternalLinkAdd.aspx" target="main-frame">添加内部链接</a></li>
                </ul>
            </li>
            <li><a class="bigMenu" href="javascript:void(0)">系统文章</a>
                <ul>
                    <li><a href="SystemArticle/ArticleEdit.aspx?id=1" target="main-frame">关于我们</a></li>
                    <li><a href="SystemArticle/ArticleEdit.aspx?id=2" target="main-frame">联系我们</a></li>
                    <li><a href="SystemArticle/ArticleEdit.aspx?id=3" target="main-frame">网站页脚</a></li>
                    <li><a href="SystemArticle/ArticleEdit.aspx?id=4" target="main-frame">如何预订</a></li>
                </ul>
            </li>
            <li><a class="bigMenu" href="javascript:void(0)">系统管理</a>
                <ul>
                    <li><a href="SystemSet/WebMeta.aspx?id=1" target="main-frame">网站设置</a></li>
                    <li><a href="SystemSet/MemberList.aspx" target="main-frame">会员管理</a></li>
                    <li><a href="Admin/AdminList.aspx" target="main-frame">管理员管理</a></li>
                </ul>
            </li>
        </ul>
    </div>

    <script src="js/jquery.min.js" type="text/javascript"></script>

    <script src="js/menu.js" type="text/javascript"></script>
    <script type="text/javascript">
        var cheight = $("html").height();
        $(".menu").height(cheight-200);
    </script>
</body>
</html>
