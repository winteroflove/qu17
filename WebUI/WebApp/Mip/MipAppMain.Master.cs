using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;

namespace WebUI.WebApp.Mip
{
    public partial class MipAppMain : System.Web.UI.MasterPage
    {
        protected ClassLibrary.Model.WebMeta webMeta = new ClassLibrary.Model.WebMeta();
        ClassLibrary.BLL.WebMeta bll = new ClassLibrary.BLL.WebMeta();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetWebInfo();
        }
        //网站信息
        private void GetWebInfo()
        {
            webMeta.Title = "重庆青年旅行社_重庆旅行社_重庆中国青年旅行社_重庆中青旅行社";
            webMeta.Description = "重庆中国青年旅行社（www.qu17.com）称重庆青旅，旅游热线：400-017-5761.共青团市委直属重庆旅行社，中青旅集团成员单位，优质服务示范重庆旅行社，重庆青年旅行社具有国家旅游局颁证的出境旅游资质的国际旅行社，旅游品质最高的重庆旅行社，重庆十大金牌旅行社，出入境游、国内游、重庆周边游、长江三峡游为主导。";
            webMeta.Keyword = "重庆旅行社,重庆青年旅行社,重庆中青旅,重庆中国青年旅行社,重庆旅游网";
            string url = HttpContext.Current.Request.CurrentExecutionFilePath.ToLower();
            string tmpTitle = "_重庆中国青年旅行社";
            if (url.IndexOf("approutesearch.aspx") > -1)
            {
                webMeta.Title = "旅游线路搜索结果" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("approutelist.aspx") > -1)
            {
                string ping = Function.GetQueryString("py");
                ClassLibrary.BLL.RouteClass routeClassBll = new ClassLibrary.BLL.RouteClass();
                List<ClassLibrary.Model.RouteClass> rcList = routeClassBll.GetModelList("classNamePy='" + ping + "'");
                if (rcList.Count > 0)
                {
                    ClassLibrary.Model.RouteClass rc = rcList[0];
                    if (rc.ClassLevel == 4)
                    {
                        webMeta.Title = string.Format("{0}旅游线路行程_{0}跟团游报价_重庆中国青年旅行社", rc.ClassName);
                        webMeta.Keyword = string.Format("{0}旅游,{0}跟团游,{0}旅游行程报价,{0}旅游线路,重庆中青旅{0}旅游团", rc.ClassName);
                        webMeta.Description = string.Format("重庆中国青年旅行社设计{0}旅游线路行程,重庆到{0}旅游最新报价,{0}跟团游最具性价比的旅行社,重庆出发{0}旅游选择青旅品质服务享受旅途,重庆青旅热线400-017-5761.", rc.ClassName);
                    }
                    else if (rc.ClassLevel == 3)
                    {
                        if (rc.ID == (int)SysConfig.RouteClass.重庆)
                        {
                            webMeta.Title = "重庆周边游_重庆周边旅游线路报价_重庆中国青年旅行社";
                            webMeta.Keyword = "重庆周边旅游,重庆周边旅游线路,重庆周边旅游行程,重庆周边旅游报价";
                            webMeta.Description = "重庆周边旅游线路、周边旅游行程报价由重庆中国青年旅行社提供设计,重庆青旅热线400-017-5761.";
                        }
                        else if (rc.ParentID == (int)SysConfig.RouteClass.豪华船)
                        {
                            webMeta.Title = string.Format("重庆三峡{0}旅游_{0}三峡旅游报价", rc.ClassName);
                            webMeta.Keyword = string.Format("重庆三峡{0}旅游,三峡{0}旅游报价,重庆三峡旅游", rc.ClassName);
                            webMeta.Description = string.Format("重庆青年旅行社提供重庆三峡{0}旅游线路报价,重庆三峡{0}旅游费用,长江三峡豪华游船旅游价格,三峡{0}旅游要多少钱,详询中青旅电话400-017-5761.", rc.ClassName);
                        }
                        else
                        {
                            webMeta.Title = string.Format("{0}旅游线路行程_{0}跟团游报价_重庆中国青年旅行社", rc.ClassName);
                            webMeta.Keyword = string.Format("{0}旅游,{0}跟团游,{0}旅游行程报价,{0}旅游线路,重庆中青旅{0}旅游团", rc.ClassName);
                            webMeta.Description = string.Format("重庆中国青年旅行社设计{0}旅游线路行程,重庆到{0}旅游最新报价,{0}跟团游最具性价比的旅行社,重庆出发{0}旅游选择青旅品质服务享受旅途,重庆青旅热线400-017-5761.", rc.ClassName);
                        }
                    }
                    else if (rc.ClassLevel == 2)
                    {
                        if (rc.ParentID == (int)SysConfig.RouteClass.三峡旅游)
                        {
                            if (rc.ID == (int)SysConfig.RouteClass.豪华船)
                            {
                                webMeta.Title = "三峡豪华游船_豪华游船航期表_重庆三峡豪华游轮_重庆中国青年旅行社";
                                webMeta.Keyword = "重庆三峡豪华游船,长江三峡游船,豪华游船航期表,三峡涉外豪华游轮";
                                webMeta.Description = "重庆中国青年旅行社提供各系列长江三峡豪华游轮,以及三峡涉外豪华游轮旅游品质服务,重庆三峡涉外豪华游轮预定,重庆中青旅热线：400-017-5761";
                            }
                            else
                            {
                                webMeta.Title = "三峡国内游船_重庆三峡国内船_重庆中国青年旅行社";
                                webMeta.Keyword = "重庆三峡国内游船,长江三峡游船,三峡国内游轮";
                                webMeta.Description = "重庆中国青年旅行社提供长江三峡国内游船,长江三峡旅游品质服务,重庆三峡国内游船预定,重庆中青旅热线：400-017-5761";
                            }
                        }
                        else
                        {
                            webMeta.Title = string.Format("{0}旅游线路行程_{0}跟团游报价_重庆中国青年旅行社", rc.ClassName);
                            webMeta.Keyword = string.Format("{0}旅游,{0}跟团游,{0}旅游行程报价,{0}旅游线路,重庆中青旅{0}旅游团", rc.ClassName);
                            webMeta.Description = string.Format("重庆中国青年旅行社设计{0}旅游线路行程,重庆到{0}旅游最新报价,{0}跟团游最具性价比的旅行社,重庆出发{0}旅游选择青旅品质服务享受旅途,重庆青旅热线400-017-5761.", rc.ClassName);
                        }
                    }
                    else
                    {
                        if (rc.ID == (int)SysConfig.RouteClass.国内旅游)
                        {
                            webMeta.Title = "国内旅游线路行程_重庆出发国内旅游线路_重庆中国青年旅行社";
                            webMeta.Keyword = "国内游线路,国内游行程,国内游报价,国内游跟团,重庆出发国内游";
                            webMeta.Description = "重庆出发国内旅游线路、国内旅游行程报价由重庆中国青年旅行社提供设计,重庆青旅热线400-017-5761.";
                        }
                        else if (rc.ID == (int)SysConfig.RouteClass.出境旅游)
                        {
                            webMeta.Title = "出境旅游线路行程_重庆出发出境旅游线路_重庆中国青年旅行社";
                            webMeta.Keyword = "出境游线路,出境游行程,出境游报价,出境游跟团,重庆出发出境游";
                            webMeta.Description = "重庆出发出境旅游线路、出境旅游行程报价由重庆中国青年旅行社提供设计,重庆青旅热线400-017-5761.";
                        }
                        else if (rc.ID == (int)SysConfig.RouteClass.三峡旅游)
                        {
                            webMeta.Title = "重庆长江三峡旅游_重庆三峡旅游行程景点_重庆中国青年旅行社";
                            webMeta.Keyword = "重庆三峡旅游,长江三峡旅游线路,三峡旅游报价,三峡游景点,三峡游船预定";
                            webMeta.Description = "重庆三峡旅游行程、三峡游线路、长江三峡旅游报价由重庆中国青年旅行社提供设计,重庆青旅热线400-017-5761.";
                        }
                    }
                }
                else
                {
                    ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();
                    List<ClassLibrary.Model.RouteType> rtList = rtBll.GetModelList("classNamePy='" + ping + "'");
                    if (rtList.Count > 0)
                    {
                        ClassLibrary.Model.RouteType rtc = rtList[0];
                        webMeta.Title = string.Format("{0}旅游线路_重庆出发{0}旅游报价", rtc.ClassName.Replace("游", "")) + tmpTitle;
                        webMeta.Keyword = string.Format("{0}旅游,{0}旅游报价,{0}旅游线路", rtc.ClassName.Replace("游", ""));
                        webMeta.Description = string.Format("重庆中国青年旅行社设计{0}旅游线路行程,重庆出发{0}旅游最新报价,{0}跟团游价格,重庆出发{0}旅游选择青旅品质服务享受旅途,重庆青旅热线400-017-5761.", rtc.ClassName.Replace("游", ""));
                    }
                }
            }
            else if (url.IndexOf("approutedetail.aspx") > -1)
            {
                int id = Convert.ToInt32(Function.GetQueryString("id"));
                ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
                ClassLibrary.Model.Routes rModel = routeBll.GetModel(id);
                webMeta.Title = rModel.Title + tmpTitle;
                if (rModel.SeoTitle != null && rModel.SeoTitle.Trim() != "")
                {
                    webMeta.Title = rModel.SeoTitle;
                }
                webMeta.Keyword = rModel.SeoKeywords;
                if (webMeta.Keyword == "")
                {
                    webMeta.Keyword = rModel.Title;
                }

                webMeta.Description = rModel.SeoDescription;
                if (webMeta.Description == "")
                {
                    webMeta.Description = Function.Clip(Function.ClearHtml(rModel.RouteFeature + rModel.DescriptionRoute).Replace(" ", "").Replace("	", ""), 80, false);
                }
            }
            else if (url.IndexOf("appabout.aspx") > -1)
            {
                webMeta.Title = "重庆中国青年旅行社简介";
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("apparticlelist.aspx") > -1)
            {
                string strId = Function.GetQueryString("id");
                if (strId != "")
                {
                    int classid = Convert.ToInt32(strId);
                    if (classid == (int)SysConfig.NewsClass.旅游资讯)
                    {
                        webMeta.Title = "重庆旅行社旅游资讯_最新旅游资讯指南" + tmpTitle;
                        webMeta.Description = "重庆旅游资讯,重庆旅游指南,旅游最新资讯,重庆旅行社资讯";
                        webMeta.Keyword = "重庆青年旅行社旅游资讯大致包含旅行社资讯,旅游相关实时新闻,旅游行业最新资讯消息,重庆以及周边旅游指南,重庆中青旅一如既往的高品质服务游客.";
                    }
                    else if (classid == (int)SysConfig.NewsClass.旅游攻略)
                    {
                        webMeta.Title = "重庆旅行社旅游攻略_最新旅游攻略" + tmpTitle;
                        webMeta.Description = "重庆旅游攻略,重庆旅游指南,旅游最新攻略";
                        webMeta.Keyword = "重庆青年旅行社旅游攻略大致包含旅游的吃、住、行、游、购、娱方面的介绍以及方式方法,重庆青旅更新的旅游攻略内容板块将更加方便您的出游.";
                    }
                }
                else
                {
                    webMeta.Title = "旅游攻略网_旅游景点网_最新旅游指南_重庆中国青年旅行社";
                    webMeta.Keyword = "旅游攻略网,旅游景点网,最新旅游指南";
                    webMeta.Description = "重庆中国青年旅行社旅游攻略网旅游景点网提供各种旅游攻略,旅游景点排行,最新旅游资讯,旅游景点推荐,详情请咨询中青旅400-017-5761";
                }
            }
            else if (url.IndexOf("apparticledetail.aspx") > -1)
            {
                int id = Convert.ToInt32(Function.GetQueryString("id"));
                ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
                ClassLibrary.Model.News rModel = newsBll.GetModel(id);
                webMeta.Title = rModel.Title + tmpTitle;
                webMeta.Keyword = rModel.Keywords;
                if (webMeta.Keyword == "")
                {
                    webMeta.Keyword = rModel.Title;
                }

                webMeta.Description = rModel.Description;
                if (webMeta.Description == "")
                {
                    webMeta.Description = Function.Clip(Function.ClearHtml(rModel.Description).Replace(" ", "").Replace("	", ""), 80, false);
                }
            }
            else if (url.IndexOf("appnav.aspx") > -1)
            {
                webMeta.Title = "旅游目的地导航" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("apporder.aspx") > -1)
            {
                webMeta.Title = "订单提交信息" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("appshopcart.aspx") > -1)
            {
                webMeta.Title = "旅游订单信息" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("appsaleslist.aspx") > -1)
            {
                webMeta.Title = "特价旅游专区_最划算的旅游" + tmpTitle;
                webMeta.Keyword = "青旅特价旅游,特价旅游旅行社,重庆旅行社特价团";
                webMeta.Description = "重庆中国青年旅行社特价旅游专区产品为限时限量旅游线路,由于游客临时退位置或者旅行社原因,导致紧急处理的旅游产品,在整个旅游行业可以说是性价比最高,超级划算的特价旅游产品.";
            }
        }
    }
}