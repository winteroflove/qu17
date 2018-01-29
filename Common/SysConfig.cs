using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;
using System.Collections;

namespace ClassLibrary.Common
{
    public class ValidateLogin
    {
        public static void Admin()
        {
            UserInfo u = new UserInfo(CookieName.AdminInfo);
            if (!u.IsLogin())
            {
                Function.goMessagePage("系统提示", "登录信息已过期，请重新登录!", "javascript:top.location.href='login.aspx'");
            }
        }
        public static void Member()
        {
            UserInfo u = new UserInfo(CookieName.MemberInfo);
            if (!u.IsLogin())
            {
                HttpContext.Current.Response.Redirect("default.aspx");
                //HttpContext.Current.Response.Write("<script>alert('请先登录后再操作！');location.href='default.aspx';</script>");
            }
        }
    }

    public class SysConfig
    {
        /// <summary>
        /// 默认线路ID (重庆)
        /// </summary>
        public static int DefaultRouteID = 14;

        /// <summary>
        /// 新闻图片路径
        /// </summary>
        public static string UploadFilePathNewsImg = "/images/newsImg/";

        /// <summary>
        /// 友情链接图片路径
        /// </summary>
        public static string UploadFilePathLinksImg = "/images/linksImg/";

        /// <summary>
        /// 路线图片路径
        /// </summary>
        public static string UploadFilePathRoutesImg = "/images/routeImg/";

        /// <summary>
        /// 旅行社图片路径
        /// </summary>
        public static string UploadFilePathCompanyImg = "/images/companyImg/";

        /// <summary>
        /// 首页滚动图片路径
        /// </summary>
        public static string UploadFilePathScrollImg = "/images/scrollImg/";
        /// <summary>
        /// LOG文件路径
        /// </summary>
        public static string UploadFilePathLogFile = "/images/Log/";
        /// <summary>
        /// 签证图片路径
        /// </summary>
        public static string UploadFilePathClassImg = "/images/classImg/";
        /// <summary>
        /// 签证图片路径
        /// </summary>
        public static string UploadFilePathVisasImg = "/images/visaImg/";
        /// <summary>
        /// 文章内容图片路径
        /// </summary>
        public static string UploadFilePathContentImg = "/images/";
        /// <summary>
        /// 网站域名
        /// </summary>
        public static string webName = "重庆中青旅";
        public static string webSite = "http://www.qu17.com";
        public static string webSiteApp = "http://m.qu17.com";
        public static string msgName = "CQJS000700";
        public static string msgPass = "zgqn@888";

        /// <summary>
        /// 内部链接数量
        /// </summary>
        public static int linkCount = 3;
        /// <summary>
        /// 广告图片路径
        /// </summary>
        public static string UploadFilePathAdImg = "/images/stcImg/";
        /// <summary>
        /// 线路价格
        /// </summary>
        public static string chujingPriceStr = "v0v3000v8000v15000v20000v0";
        public static string guoneiPriceStr = "v0v500v1500v3000v10000v0";

        /// <summary>
        /// 获取线路的第一张图
        /// </summary>
        public static string GetRoutePhoto(string photos)
        {
            string photo = string.Empty;

            photo = photos.Split(',')[0];

            return UploadFilePathRoutesImg + photo;
        }

        /// <summary>
        /// 获取旅行社的第一张图
        /// </summary>
        public static string GetCompPhoto(string photo)
        {
            return UploadFilePathCompanyImg + photo;
        }

        /// <summary>
        /// 站点名
        /// </summary>
        public static string WebSiteName
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteName"].ToString();
            }
        }


        public static string AutoLink
        {
            get
            {
                return "<br> 本网站由：<a title='' href='' target='_blank'>****</a> 提供技术支持";
            }
        }

        public enum AdPosition
        {
            guonei_ad = 1,
            chujing_ad = 2,
            sanxia_ad = 3,
            chongqing_ad = 5
        }

        public enum SystemArticle
        {
            关于我们 = 1,
            联系我们 = 2,
            网站页脚 = 3,
            如何预订 = 4
        }

        public enum NewsClass
        {
            旅游攻略 = 1,
            旅游资讯 = 2
        }

        public enum NewsClassPY
        {
            article = 1,
            news = 2
        }

        public enum RouteClass
        {
            国内旅游 = 1,
            出境旅游 = 2,
            三峡旅游 = 3,
            重庆 = 5,
            豪华船 = 6,
            国内船 = 7
        }

        public enum TrafficModel
        {
            自理,
            飞机,
            火车,
            汽车,
            轮船,
            自驾,
            动车
        }

        public enum OrderType
        {
            未付款待处理,
            已付款处理中,
            已完成,
            无效订单
        }

        public enum Payment
        {
            支付宝,
            银行转账,
            上门付款,
            稍后付款
        }

        public enum RecommendIndex
        {
            推荐 = 1,
            热门 = 2,
            新品 = 3,
            特价 = 4
        }
        public enum Numbers
        {
            一 = 1,
            二 = 2,
            三 = 3,
            四 = 4,
            五 = 5,
            六 = 6,
            七 = 7,
            八 = 8,
            九 = 9,
            十 = 10,
            十一 = 11,
            十二 = 12
        }
    }
}
