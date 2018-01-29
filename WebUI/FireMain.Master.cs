using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Data;

namespace WebUI
{
    public partial class FireMain : System.Web.UI.MasterPage
    {
        protected string userName;
        protected string menuGuonei;
        protected string menuChujin;
        protected string menuZhoubian;
        protected string menuSanxia;
        protected string menuZhuti;
        protected string qqListGn;
        protected string qqListCj;
        protected string qqList;
        protected ClassLibrary.Model.WebMeta webMeta = new ClassLibrary.Model.WebMeta();
        ClassLibrary.BLL.RouteClass routeClassBll = new ClassLibrary.BLL.RouteClass();
        ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
        ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();
        List<ClassLibrary.Model.RouteClass> rcList = new List<ClassLibrary.Model.RouteClass>();
        List<ClassLibrary.Model.RouteType> zjClassList = new List<ClassLibrary.Model.RouteType>();

        //ClassLibrary.BLL.Advertise adBll = new ClassLibrary.BLL.Advertise();
        protected string login = "";
        protected string dataMenu = "";
        protected string dataSearchClass = "";//热门搜索词
        protected string hd_left = "";
        protected string hd_right = "";
        protected string gn_left = "";
        protected string gn_right = "";
        protected string cj_left = "";
        protected string cj_right = "";
        protected string zb_left = "";
        protected string zb_right = "";
        protected string sx_left = "";
        protected string sx_right = "";
        protected string zj_left = "";
        protected string zj_right = "";
        protected string qz_left = "";
        protected string qz_right = "";
        protected string displayNav = "";
        protected string footerNav = "";
        protected string footerContent = "";
        protected string displayShare = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string ac = Request.QueryString["ac"];
            if (ac == "tuichu")
            {
                tuichu();
            }
            rcList = routeClassBll.GetModelList(string.Empty, "ClassOrder asc, CreatedTime Desc");
            zjClassList = rtBll.GetModelList(string.Empty, "ClassOrder asc, CreatedTime Desc");

            GetWebInfo();
            BindLogin();
            BindSearchClass();
            BindMenu();
            BindNavMenu();
            BindFooter();
            BindFooterNav();
        }
        private void BindFooterNav()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<div class='fnav'>");
            sb.AppendFormat("<span><a href='{0}/guonei/' target='_blank'>国内旅游</a></span>", SysConfig.webSite).AppendLine();
            sb.AppendLine("<div class='fnav_right'>");
            List<ClassLibrary.Model.RouteClass> gnList = routeClassBll.GetSubList((int)SysConfig.RouteClass.国内旅游, "Recommend = 1 and ClassLevel > 2", "ClassOrder Asc, CreatedTime Desc");
            foreach (ClassLibrary.Model.RouteClass model in gnList)
            {
                sb.AppendFormat("<a href='{0}/{1}/' target='_blank' >{2}旅游</a>", SysConfig.webSite, model.ClassNamePY, model.ClassName);
            }
            sb.AppendLine("</div></div>");
            sb.AppendLine("<div class='fnav'>");
            sb.AppendFormat("<span><a href='{0}/chujing/' target='_blank'>出国旅游</a></span>", SysConfig.webSite).AppendLine();
            sb.AppendLine("<div class='fnav_right'>");
            List<ClassLibrary.Model.RouteClass> cjList = routeClassBll.GetSubList((int)SysConfig.RouteClass.出境旅游, "Recommend = 1 and ClassLevel > 1", "ClassOrder Asc, CreatedTime Desc");
            foreach (ClassLibrary.Model.RouteClass model in cjList)
            {
                sb.AppendFormat("<a href='{0}/{1}/' target='_blank' >{2}旅游</a>", SysConfig.webSite, model.ClassNamePY, model.ClassName);
            }
            sb.AppendLine("</div></div>");
            footerNav = sb.ToString();
        }
        private void BindSearchClass()
        {
            List<ClassLibrary.Model.RouteClass> listRec = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.Recommend && rc.ClassLevel > 2; }); 
            int indexRec = 0;
            StringBuilder sbRec = new StringBuilder();
            string temRec = "<a href='{2}/{0}/' target='_blank'>{1}</a>";
            foreach (ClassLibrary.Model.RouteClass recModel in listRec)
            {
                if (recModel.ParentID == (int)SysConfig.RouteClass.重庆) continue;
                indexRec++;
                sbRec.AppendFormat(temRec,
                    recModel.ClassNamePY,
                    recModel.ClassName,
                    SysConfig.webSite).AppendLine();
                if (indexRec >= 10) break;
            }
            dataSearchClass = sbRec.ToString();
        }
        public void BindNavMenu()
        {
            StringBuilder sb = new StringBuilder();
            //境外海岛
            int num = 0;
            List<ClassLibrary.Model.RouteClass> tmpList = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.IsHaidao; });
            foreach (ClassLibrary.Model.RouteClass model in tmpList)
            {
                if (model.Recommend)
                {
                    num++;
                    sb.AppendFormat("<a href='{2}/{0}/' title='{1}旅游' target='_blank'>{1}</a>", model.ClassNamePY, model.ClassName, SysConfig.webSite);
                    if (num >= 3)
                    {
                        break;
                    }
                }
            }
            hd_left = sb.ToString();
            sb.Length = 0;
            sb.AppendLine("<ul class='hd_detail'>");
            num = 0;
            foreach (ClassLibrary.Model.RouteClass model in tmpList)
            {
                num++;
                sb.AppendLine("<li>");
                sb.AppendFormat("<a href='{3}/{0}/' title='{1}旅游' target='_blank' rel='nofollow'><img src='{2}' alt='' width='68' height='68' /></a>", model.ClassNamePY, model.ClassName, SysConfig.UploadFilePathClassImg + model.ClassImg, SysConfig.webSite);
                sb.AppendFormat("<a href='{2}/{0}/' title='{1}旅游' target='_blank' >{1}</a>", model.ClassNamePY, model.ClassName, SysConfig.webSite);
                sb.AppendLine("</li>");
                if (num >= 12) break;
            }
            sb.AppendLine("</ul>");
            hd_right = sb.ToString();
            sb.Length = 0;
            
            //国内旅游
            num = 0;
            List<ClassLibrary.Model.RouteClass> gnList = routeClassBll.GetSubList((int)SysConfig.RouteClass.国内旅游, "classLevel>2", "ClassOrder Asc, CreatedTime Desc");
            foreach (ClassLibrary.Model.RouteClass model in gnList)
            {
                if (model.Recommend && model.ParentID != (int)SysConfig.RouteClass.重庆 && model.ID != (int)SysConfig.RouteClass.重庆)
                {
                    num++;
                    sb.AppendFormat("<a href='{2}/{0}/' title='{1}旅游' target='_blank'>{1}</a>", model.ClassNamePY, model.ClassName, SysConfig.webSite).AppendLine();
                    if (num >= 4)
                    {
                        break;
                    }
                }
            }
            gn_left = sb.ToString();
            sb.Length = 0;

            List<ClassLibrary.Model.RouteClass> gnListLevel3 = gnList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ClassLevel == 3 && rc.ID != (int)SysConfig.RouteClass.重庆 && rc.Recommend; });
            sb.AppendLine("<div class='gntitle'>热门目的地</div>");
            sb.AppendLine("<div class='gn_area'>");
            foreach (ClassLibrary.Model.RouteClass model in gnListLevel3)
            {
                sb.AppendFormat("<a href='{0}/{1}/' title='{2}旅游' target='_blank'>{2}</a>", SysConfig.webSite, model.ClassNamePY, model.ClassName).AppendLine();
            }
            sb.AppendLine("</div>");
            sb.AppendLine("<div class='gntitle'>热门景点</div>");
            sb.AppendLine("<div class='gn_area'>");
            List<ClassLibrary.Model.RouteClass> gnListLevel4 = gnList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ClassLevel == 4 && rc.ParentID != (int)SysConfig.RouteClass.重庆 && rc.Recommend; });
            foreach (ClassLibrary.Model.RouteClass model in gnListLevel4)
            {
                sb.AppendFormat("<a href='{0}/{1}/' title='{2}旅游' target='_blank'>{2}</a>", SysConfig.webSite, model.ClassNamePY, model.ClassName).AppendLine();
            }
            sb.AppendLine("</div>");
            gn_right = sb.ToString();
            sb.Length = 0;

            //国外旅游
            num = 0;
            List<ClassLibrary.Model.RouteClass> cjList = routeClassBll.GetSubList((int)SysConfig.RouteClass.出境旅游, "classLevel>1", "ClassOrder asc, CreatedTime Desc");
            foreach (ClassLibrary.Model.RouteClass model in cjList)
            {
                if (model.Recommend)
                {
                    num++;
                    sb.AppendFormat("<a href='{2}/{0}/' title='{1}旅游' target='_blank'>{1}</a>", model.ClassNamePY, model.ClassName, SysConfig.webSite).AppendLine();
                    if (num >= 3)
                    {
                        break;
                    }
                }
            }
            cj_left = sb.ToString();
            sb.Length = 0;

            List<ClassLibrary.Model.RouteClass> cjListLevel2 = cjList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ClassLevel == 2; });
            foreach (ClassLibrary.Model.RouteClass model in cjListLevel2)
            {
                sb.AppendLine("<dl>");
                sb.AppendFormat("<dt><a href='{0}/{1}/' title='{2}旅游' target='_blank'>{2}</a></dt>", SysConfig.webSite, model.ClassNamePY, model.ClassName).AppendLine();
                sb.AppendLine("<dd>");
                List<ClassLibrary.Model.RouteClass> cjListLevel3 = cjList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == model.ID; });
                foreach (ClassLibrary.Model.RouteClass model2 in cjListLevel3)
                {
                    sb.AppendFormat("<em><a href='{2}/{0}/' title='{1}旅游' target='_blank'>{1}</a></em>", model2.ClassNamePY, model2.ClassName, SysConfig.webSite).AppendLine();
                }
                sb.AppendLine("</dd>");
                sb.AppendLine("</dl>");
            }
            cj_right = sb.ToString();
            sb.Length = 0;

            //周边旅游
            num = 0;
            foreach (ClassLibrary.Model.RouteClass model in rcList)
            {
                if (model.Recommend && model.ParentID == (int)SysConfig.RouteClass.重庆)
                {
                    num++;
                    sb.AppendFormat("<a href='{2}/{0}/' title='{1}旅游' target='_blank'>{1}</a>", model.ClassNamePY, model.ClassName, SysConfig.webSite).AppendLine();
                    if (num >= 3)
                    {
                        break;
                    }
                }
            }
            zb_left = sb.ToString();
            sb.Length = 0;

            List<ClassLibrary.Model.RouteClass> cqList = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == (int)SysConfig.RouteClass.重庆; });
            foreach (ClassLibrary.Model.RouteClass model in cqList)
            {
                sb.AppendFormat("<a href='{2}/{0}/' title='{1}旅游' target='_blank'>{1}</a>", model.ClassNamePY, model.ClassName, SysConfig.webSite).AppendLine();
            }
            zb_right = sb.ToString();
            sb.Length = 0;

            //三峡
            num = 0;
            List<ClassLibrary.Model.RouteClass> sxList = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ParentID == (int)SysConfig.RouteClass.豪华船; });
            foreach (ClassLibrary.Model.RouteClass model in sxList)
            {
                sb.AppendFormat("<li><a href='{0}/{1}/' target='_blank'>", SysConfig.webSite, model.ClassNamePY);
                sb.AppendFormat("<img src='{0}' alt='' width='58' height='58' />", SysConfig.UploadFilePathClassImg + model.ClassImg);
                sb.AppendFormat("<span>{0}</span>", model.ClassName);
                sb.AppendLine("</a></li>");
            }
            sx_right = sb.ToString();
            sb.Length = 0;

            //主题
            num = 0;
            foreach (ClassLibrary.Model.RouteType model in zjClassList)
            {
                if (model.Recommend)
                {
                    num++;
                    sb.AppendFormat("<a href='{2}/{0}/' title='{1}旅游' target='_blank'>{1}</a>", model.classNamePY, model.ClassName, SysConfig.webSite);
                    if (num >= 4)
                    {
                        break;
                    }
                }
            }
            zj_left = sb.ToString();
            sb.Length = 0;

            num = 0;
            foreach (ClassLibrary.Model.RouteType model in zjClassList)
            {
                sb.AppendLine("<li>");
                sb.AppendFormat("<a href='{0}/{1}/' title='{2}' target='_blank' rel='nofollow'><img src='{3}' alt='' width='55' height='44' /></a>",
                    SysConfig.webSite, model.classNamePY, model.ClassName, SysConfig.UploadFilePathClassImg+model.ClassImg);
                sb.AppendFormat("<a href='{0}/{1}/' title='{2}' target='_blank' >{2}</a>", SysConfig.webSite, model.classNamePY, model.ClassName);
                sb.AppendLine("</li>");
            }
            zj_right = sb.ToString();
            sb.Length = 0;

        }
        //菜单
        private void BindMenu()
        {
            StringBuilder sb = new StringBuilder();

            int maxId = SelectedMenu();

            sb.AppendFormat("<a href='{0}/' title='重庆青年旅行社'>首页</a>", SysConfig.webSite);

            sb.AppendFormat("<a class='{0}' href='{1}/guonei/' title='国内旅游'>国内游</a>",
                maxId == (int)SysConfig.RouteClass.国内旅游 ? "on" : "", SysConfig.webSite);

            sb.AppendFormat("<a class='{0}' href='{1}/chujing/' title='出境旅游'>出境游</a>",
                maxId == (int)SysConfig.RouteClass.出境旅游 ? "on" : "", SysConfig.webSite);

            sb.AppendFormat("<a class='{0}' href='{1}/chongqing/' title='重庆周边旅游'>周边游</a>",
                maxId == (int)SysConfig.RouteClass.重庆 ? "on" : "", SysConfig.webSite);

            sb.AppendFormat("<a class='{0}' href='{1}/sanxia/' title='重庆三峡旅游'>三峡游</a>",
                maxId == (int)SysConfig.RouteClass.三峡旅游 ? "on" : "", SysConfig.webSite);

            List<ClassLibrary.Model.RouteType> rtList = rtBll.GetModelList(string.Empty, "Recommend Desc, ClassOrder Asc, CreatedTime Desc");
            if (rtList.Count > 0)
            {
                ClassLibrary.Model.RouteType model = rtList[0];
                sb.AppendFormat("<a class='{0}' href='{1}/{2}/' title='重庆{3}'>{3}<em class='hotzt'>Hot<i class='ic'></i></em></a>",
                    maxId == -1 ? "on" : "", SysConfig.webSite, model.classNamePY, model.ClassName);
            }
            sb.AppendFormat("<a class='{0}' href='{1}/sale/' title='特价旅游专区'>特价专区<em class='hotzt'>Hot<i class='ic'></i></em></a>",
                    maxId == -2 ? "on" : "", SysConfig.webSite);
            dataMenu = sb.ToString();
        }

        private int SelectedMenu()
        {
            string url = Request.Url.PathAndQuery.ToLower();
            int maxId = 0;
            if (url.IndexOf("routelist.aspx") > -1)
            {
                string ping = Function.GetQueryString("py");
                if (ping != "")
                {
                    List<ClassLibrary.Model.RouteClass> routelist = rcList.FindAll(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ClassNamePY == ping; });

                    if (routelist.Count > 0)
                    {
                        ClassLibrary.Model.RouteClass model = routelist[0];
                        if (model.ClassLevel == 1)
                        {
                            maxId = model.ID;
                        }
                        else if (model.ID == (int)SysConfig.RouteClass.重庆 || model.ParentID == (int)SysConfig.RouteClass.重庆)
                        {
                            maxId = (int)SysConfig.RouteClass.重庆;
                        }
                        else
                        {
                            List<ClassLibrary.Model.RouteClass> list = routeClassBll.GetParentList(model.ID, "", "classlevel asc");
                            maxId = list[0].ID;
                        }
                    }
                    else
                    {
                        List<ClassLibrary.Model.RouteType> rtList = zjClassList.FindAll(delegate(ClassLibrary.Model.RouteType rc) { return rc.classNamePY == ping; });
                        if (rtList.Count > 0) maxId = -1;
                    }
                }
            }
            else if (url.IndexOf("saleslist.aspx") > -1)
            {
                maxId = -2;
            }

            return maxId;
        }

        //退出登录
        public void tuichu()
        {
            Session["user"] = null;
        }
        //判断是否登录
        public void BindLogin()
        {
            UserInfo u = new UserInfo(CookieName.MemberInfo);
            userName = u.GetInfo(LoginInfo.Nickname);

            if (userName == null || userName == "")
            {
                login = string.Format("<a href='{0}/login/' rel='nofollow'>登录</a><i></i><a class='top_login' href='{0}/register/' rel='nofollow'>免费注册</a>", SysConfig.webSite);
            }
            else
            {
                login = string.Format("<a href='{0}/vip/info/' class='top_login'>个人中心</a><i></i><a  href='{0}/logout/' rel='nofollow'>退出</a>", SysConfig.webSite);
            }
            login += "<i></i>";
            login += string.Format("<a href='{0}/shopcart/' target='_blank' rel='nofollow'>购物车(<label id='cartCount'>0</label>)</a><i></i>", SysConfig.webSite);
            login += string.Format("<a href='{0}/vip/' target='_blank' rel='nofollow'>查看订单</a><i></i>", SysConfig.webSite);
            login += string.Format("<a href='{0}/sitemap/' target='_blank'>网站地图</a>", SysConfig.webSite);
            //login += "<i></i><a href='javascript:void(0)' title='中青旅微信' class='yts_weixin' rel='nofollow'></a>";
        }

        //页脚
        protected void BindFooter()
        {
            ClassLibrary.BLL.SystemArticle bll = new ClassLibrary.BLL.SystemArticle();

            footerContent = bll.GetModel((int)SysConfig.SystemArticle.网站页脚).Content;

        }

        private List<ClassLibrary.Model.RouteClass> getSubClassList(List<ClassLibrary.Model.RouteClass> list, int parentId, int classLevel){
            List<ClassLibrary.Model.RouteClass> classList = new List<ClassLibrary.Model.RouteClass>();

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                if (model.ParentID == parentId && model.ClassLevel == classLevel)
                {
                    classList.Add(model);
                }
            }

            return classList;
        }

        //网站信息
        private void GetWebInfo()
        {
            //网站meta
            ClassLibrary.BLL.WebMeta bll = new ClassLibrary.BLL.WebMeta();
            webMeta = bll.GetModelList(string.Empty)[0];

            string tmpTitle = "_重庆中国青年旅行社";
            string url = HttpContext.Current.Request.CurrentExecutionFilePath.ToLower();

            if (url.IndexOf("default.aspx") < 0) displayNav = "style='display:none;'";
            if (url.IndexOf("articledetail.aspx") < 0)
            {
                displayShare += "<div class='webshare'>";
                displayShare += "<span>分享重庆青年旅行社</span>";
                displayShare += "<div id='bdshare' class='bdshare_t bds_tools get-codes-bdshare'>";
                displayShare += "<a class='bds_qzone'></a><a class='bds_tsina'></a><a class='bds_tqq'></a><span class='bds_more'>更多</span>";
                displayShare += "</div>";
                displayShare += "<script type='text/javascript' id='bdshare_js' data='type=tools'></script>";
                displayShare += "<script type='text/javascript' id='bdshell_js'></script>";
                displayShare += "<script type='text/javascript'>document.getElementById('bdshell_js').src = 'http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=' + new Date().getHours();</script>";
                displayShare += "</div>";
            }

            int pageNo = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            
            if (url.IndexOf("routelist.aspx") > -1)
            {
                string price = Function.GetQueryString("price");
                string ping = Function.GetQueryString("py");
                string themeId = Function.GetQueryString("theme");
                string day = Function.GetQueryString("day");
                string key = Request.QueryString["sk"];
                ClassLibrary.Model.SeoInfo simodel = null;
                if (price != "" || themeId != "" || day != "")
                {
                    ClassLibrary.BLL.SeoInfo siBLL = new ClassLibrary.BLL.SeoInfo();
                    string where = "1=1";
                    where += " and price = '" + price + "'";
                    where += " and themeid = " + (themeId == "" ? 0 : Convert.ToInt32(themeId));
                    where += " and days = " + (day == "" ? 0 : Convert.ToInt32(day));
                    where += " and exists (select * from routeClass where routeClass.ID = routeClassId and classNamePy = '" + ping + "')";
                    List<ClassLibrary.Model.SeoInfo> siList = siBLL.GetModelList(1, where, "CreatedTime Desc");
                    if (siList.Count > 0) simodel = siList[0];
                }
                string theme = "";
                if(day != "") day = Enum.GetName(typeof(SysConfig.Numbers), Convert.ToInt32(day)) + "日游";

                if (Function.IsNumber(themeId))
                {
                    theme = zjClassList.Find(delegate(ClassLibrary.Model.RouteType rt) { return rt.ID == Convert.ToInt32(themeId); }).ClassName;
                }

                if (price != null && price != "")
                {
                    string[] temPrice = price.Split('-');
                    if (temPrice[0] == "0")
                    {
                        price = temPrice[1] + "元以下";
                    }
                    else if (temPrice[1] == "0")
                    {
                        price = temPrice[0] + "元以上";
                    }
                    else
                    {
                        price += "元";
                    }
                }
                if (key != null && key != "")
                {
                    webMeta.Title = key + "旅游线路搜索结果_重庆中国青年旅行社";
                    webMeta.Keyword = "";
                    webMeta.Description = "";
                }
                else
                {
                    ClassLibrary.Model.RouteClass rc = rcList.Find(delegate(ClassLibrary.Model.RouteClass rct) { return rct.ClassNamePY == ping; });
                    if (rc == null)
                    {
                        ClassLibrary.Model.RouteType rt = zjClassList.Find(delegate(ClassLibrary.Model.RouteType rct) { return rct.classNamePY == ping; });
                        webMeta.Title = string.Format("{0}旅游线路_重庆出发{0}旅游报价", rt.ClassName.Replace("游", "")) + tmpTitle;
                        webMeta.Keyword = string.Format("{0}旅游,{0}旅游报价,{0}旅游线路", rt.ClassName.Replace("游", ""));
                        webMeta.Description = string.Format("重庆中国青年旅行社设计{0}旅游线路行程,重庆出发{0}旅游最新报价,{0}跟团游价格,重庆出发{0}旅游选择青旅品质服务享受旅途,重庆青旅热线400-017-5761.", rt.ClassName.Replace("游", ""));
                    }
                    else
                    {
                        if (rc.ClassLevel == 4)
                        {
                            if (price != "" || theme != "" || day != "")
                            {
                                setMetaInfo(rc.ClassName, theme, price, day);
                            }
                            else
                            {
                                if (rc.SeoTitle.Trim() != "")
                                {
                                    webMeta.Title = rc.SeoTitle;
                                }
                                else
                                {
                                    webMeta.Title = string.Format("{0}旅游线路行程_{0}跟团游报价", rc.ClassName) + tmpTitle;
                                }
                                if (rc.SeoKeyword.Trim() != "")
                                {
                                    webMeta.Keyword = rc.SeoKeyword;
                                }
                                else
                                {
                                    webMeta.Keyword = string.Format("{0}旅游,{0}跟团游,{0}旅游行程报价,{0}旅游线路,重庆中青旅{0}旅游团", rc.ClassName);
                                }
                                if (rc.SeoDesc.Trim() != "")
                                {
                                    webMeta.Description = rc.SeoDesc;
                                }
                                else
                                {
                                    webMeta.Description = string.Format("重庆中国青年旅行社设计{0}旅游线路行程,重庆到{0}旅游最新报价,{0}跟团游最具性价比的旅行社,重庆出发{0}旅游选择青旅品质服务享受旅途,重庆青旅热线400-017-5761.", rc.ClassName);
                                }
                            }
                        }
                        else if (rc.ClassLevel == 3)
                        {
                            if (price != "" || theme != "" || day != "")
                            {
                                if (rc.ID == (int)SysConfig.RouteClass.重庆)
                                {
                                    if (theme != "" || day != "")
                                    {
                                        webMeta.Title = string.Format("重庆{0}{1}_重庆周边{0}{1}{2}线路{3}推荐", theme.Replace("游", ""), day, price, price == "" ? "价格" : "") + tmpTitle;
                                        webMeta.Keyword = string.Format("重庆{0}{1},重庆周边{0}{1}线路", theme.Replace("游", ""), day);
                                        webMeta.Description = string.Format("重庆中国青年旅行社提供重庆{0}{1}{2}线路推荐,重庆{0}{1},重庆跟团游费用,详询重庆中青旅电话400-017-5761.", theme.Replace("游", ""), day, price);
                                    }
                                    else
                                    {
                                        webMeta.Title = string.Format("重庆周边{0}线路推荐", price) + tmpTitle;
                                        webMeta.Keyword = string.Format("重庆周边旅游,重庆{0}旅游线路", price);
                                        webMeta.Description = string.Format("重庆中国青年旅行社提供重庆周边{0}旅游线路推荐,重庆跟团游价格,去重庆旅游费用,详询重庆中青旅电话400-017-5761.", price);
                                    }
                                }
                                else if (rc.ParentID == (int)SysConfig.RouteClass.豪华船)
                                {
                                    if (day != "")
                                    {
                                        webMeta.Title = string.Format("三峡{0}游船_重庆三峡{0}豪华船{1}{2}线路{3}推荐", rc.ClassName, day, price, price == "" ? "价格" : "") + tmpTitle;
                                        webMeta.Keyword = string.Format("三峡{0}游船_重庆三峡{0}豪华船{1}", rc.ClassName, day);
                                        webMeta.Description = string.Format("重庆中国青年旅行社提供重庆三峡{1}旅游线路报价,重庆三峡{1}{0}旅游费用,长江三峡豪华游船{0}价格,三峡{1}旅游要多少钱,详询中青旅电话400-017-5761.", day, rc.ClassName);
                                    }
                                    else
                                    {
                                        webMeta.Title = string.Format("重庆三峡{0}豪华船{1}线路推荐", rc.ClassName, price) + tmpTitle;
                                        webMeta.Keyword = string.Format("三峡{0}游船_重庆三峡{0}豪华船价格", rc.ClassName);
                                        webMeta.Description = string.Format("重庆中国青年旅行社提供重庆三峡{0}旅游线路报价,重庆三峡{0}旅游费用,长江三峡豪华游船旅游价格,三峡{0}旅游要多少钱,详询中青旅电话400-017-5761.", rc.ClassName);
                                    }
                                }
                                else
                                {
                                    setMetaInfo(rc.ClassName, theme, price, day);
                                }
                            }
                            else
                            {
                                if (rc.ID == (int)SysConfig.RouteClass.重庆)
                                {
                                    if (rc.SeoTitle.Trim() != "")
                                    {
                                        webMeta.Title = rc.SeoTitle;
                                    }
                                    else
                                    {
                                        webMeta.Title = string.Format("重庆周边游_重庆周边旅游线路报价") + tmpTitle;
                                    }
                                    if (rc.SeoKeyword.Trim() != "")
                                    {
                                        webMeta.Keyword = rc.SeoKeyword;
                                    }
                                    else
                                    {
                                        webMeta.Keyword = string.Format("重庆周边旅游,重庆周边旅游线路,重庆周边旅游行程,重庆周边旅游报价");
                                    }
                                    if (rc.SeoDesc.Trim() != "")
                                    {
                                        webMeta.Description = rc.SeoDesc;
                                    }
                                    else
                                    {
                                        webMeta.Description = string.Format("重庆周边旅游线路、周边旅游行程报价由重庆中国青年旅行社提供设计,重庆青旅热线400-017-5761.");
                                    }
                                }
                                else if (rc.ParentID == (int)SysConfig.RouteClass.豪华船)
                                {
                                    if (rc.SeoTitle.Trim() != "")
                                    {
                                        webMeta.Title = rc.SeoTitle;
                                    }
                                    else
                                    {
                                        webMeta.Title = string.Format("重庆三峡{0}旅游_{0}三峡旅游报价", rc.ClassName) + tmpTitle;
                                    }
                                    if (rc.SeoKeyword.Trim() != "")
                                    {
                                        webMeta.Keyword = rc.SeoKeyword;
                                    }
                                    else
                                    {
                                        webMeta.Keyword = string.Format("重庆三峡{0}旅游,三峡{0}旅游报价,重庆三峡旅游", rc.ClassName);
                                    }
                                    if (rc.SeoDesc.Trim() != "")
                                    {
                                        webMeta.Description = rc.SeoDesc;
                                    }
                                    else
                                    {
                                        webMeta.Description = string.Format("重庆青年旅行社提供重庆三峡{0}旅游线路报价,重庆三峡{0}旅游费用,长江三峡豪华游船旅游价格,三峡{0}旅游要多少钱,详询中青旅电话400-017-5761.", rc.ClassName);
                                    }
                                }
                                else
                                {
                                    if (rc.SeoTitle.Trim() != "")
                                    {
                                        webMeta.Title = rc.SeoTitle;
                                    }
                                    else
                                    {
                                        webMeta.Title = string.Format("{0}旅游线路行程_{0}跟团游报价", rc.ClassName) + tmpTitle;
                                    }
                                    if (rc.SeoKeyword.Trim() != "")
                                    {
                                        webMeta.Keyword = rc.SeoKeyword;
                                    }
                                    else
                                    {
                                        webMeta.Keyword = string.Format("{0}旅游,{0}跟团游,{0}旅游行程报价,{0}旅游线路,重庆中青旅{0}旅游团", rc.ClassName);
                                    }
                                    if (rc.SeoDesc.Trim() != "")
                                    {
                                        webMeta.Description = rc.SeoDesc;
                                    }
                                    else
                                    {
                                        webMeta.Description = string.Format("重庆中国青年旅行社设计{0}旅游线路行程,重庆到{0}旅游最新报价,{0}跟团游最具性价比的旅行社,重庆出发{0}旅游选择青旅品质服务享受旅途,重庆青旅热线400-017-5761.", rc.ClassName);
                                    }
                                }
                            }
                        }
                        else if (rc.ClassLevel == 2)
                        {
                            if (rc.ParentID == (int)SysConfig.RouteClass.三峡旅游)
                            {
                                string filter = "";
                                if (price != "" || day != "")
                                {
                                    filter = "三峡" + rc.ClassName + price + day + "旅游线路" + (price == "" ? "价格/" : "") + "推荐";
                                    webMeta.Title = filter + tmpTitle;
                                    webMeta.Keyword = filter;
                                    webMeta.Description = string.Format("重庆中国青年旅行社提供{0},详情请咨询中青旅400-017-5761.", filter);
                                }
                                else
                                {
                                    if (rc.SeoTitle.Trim() != "")
                                    {
                                        webMeta.Title = rc.SeoTitle;
                                    }
                                    else
                                    {
                                        webMeta.Title = string.Format("三峡{0}旅游_{0}三峡旅游报价", rc.ClassName) + tmpTitle;
                                    }
                                    if (rc.SeoKeyword.Trim() != "")
                                    {
                                        webMeta.Keyword = rc.SeoKeyword;
                                    }
                                    else
                                    {
                                        webMeta.Keyword = string.Format("三峡{0}旅游,重庆三峡旅游,三峡{0}旅游报价,三峡{0}旅游要多少钱", rc.ClassName);
                                    }
                                    if (rc.SeoDesc.Trim() != "")
                                    {
                                        webMeta.Description = rc.SeoDesc;
                                    }
                                    else
                                    {
                                        webMeta.Description = string.Format("重庆青年旅行社提供三峡{0}旅游线路报价,重庆三峡旅游线路,三峡{0}旅游价格,三峡{0}旅游要多少钱,详询中青旅电话400-017-5761.", rc.ClassName);
                                    }
                                }
                            }
                            else
                            {
                                string filter = "";
                                if (price != "" || theme != "" || day != "")
                                {
                                    setMetaInfo(rc.ClassName, theme, price, day);
                                }
                                else
                                {
                                    if (rc.SeoTitle.Trim() != "")
                                    {
                                        webMeta.Title = rc.SeoTitle;
                                    }
                                    else
                                    {
                                        webMeta.Title = string.Format("{0}旅游线路行程_{0}跟团游报价", rc.ClassName) + tmpTitle;
                                    }
                                    if (rc.SeoKeyword.Trim() != "")
                                    {
                                        webMeta.Keyword = rc.SeoKeyword;
                                    }
                                    else
                                    {
                                        webMeta.Keyword = string.Format("{0}旅游,{0}跟团游,{0}旅游行程报价,{0}旅游线路,重庆中青旅{0}旅游团", rc.ClassName);
                                    }
                                    if (rc.SeoDesc.Trim() != "")
                                    {
                                        webMeta.Description = rc.SeoDesc;
                                    }
                                    else
                                    {
                                        webMeta.Description = string.Format("重庆中国青年旅行社设计{0}旅游线路行程,重庆到{0}旅游最新报价,{0}跟团游最具性价比的旅行社,重庆出发{0}旅游选择青旅品质服务享受旅途,重庆青旅热线400-017-5761.", rc.ClassName);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (rc.ID == (int)SysConfig.RouteClass.国内旅游)
                            {
                                string filter = "";
                                if (price != "" || theme != "" || day != "")
                                {
                                    filter = "国内" + price + theme + day + "旅游线路" + (price == "" ? "报价/价格/" : "") + "推荐";
                                    webMeta.Title = filter + tmpTitle;
                                    webMeta.Keyword = filter;
                                    webMeta.Description = string.Format("重庆中国青年旅行社提供{0},详情请咨询中青旅400-017-5761.", filter);
                                }
                                else
                                {
                                    if (rc.SeoTitle.Trim() != "")
                                    {
                                        webMeta.Title = rc.SeoTitle;
                                    }
                                    else
                                    {
                                        webMeta.Title = string.Format("国内旅游线路行程_重庆出发国内旅游线路") + tmpTitle;
                                    }
                                    if (rc.SeoKeyword.Trim() != "")
                                    {
                                        webMeta.Keyword = rc.SeoKeyword;
                                    }
                                    else
                                    {
                                        webMeta.Keyword = string.Format("国内游线路,国内游行程,国内游报价,国内游跟团,重庆出发国内游");
                                    }
                                    if (rc.SeoDesc.Trim() != "")
                                    {
                                        webMeta.Description = rc.SeoDesc;
                                    }
                                    else
                                    {
                                        webMeta.Description = string.Format("重庆出发国内旅游线路、国内旅游行程报价由重庆中国青年旅行社提供设计,重庆青旅热线400-017-5761.");
                                    }
                                }
                            }
                            else if (rc.ID == (int)SysConfig.RouteClass.出境旅游)
                            {
                                string filter = "";
                                if (price != "" || theme != "" || day != "")
                                {
                                    filter = "出境" + price + theme + day + "旅游线路" + (price == "" ? "报价/价格/" : "") + "推荐";
                                    webMeta.Title = filter + tmpTitle;
                                    webMeta.Keyword = filter;
                                    webMeta.Description = string.Format("重庆中国青年旅行社提供{0},详情请咨询中青旅400-017-5761.", filter);
                                }
                                else
                                {
                                    if (rc.SeoTitle.Trim() != "")
                                    {
                                        webMeta.Title = rc.SeoTitle;
                                    }
                                    else
                                    {
                                        webMeta.Title = string.Format("出境旅游线路行程_重庆出发出境旅游线路") + tmpTitle;
                                    }
                                    if (rc.SeoKeyword.Trim() != "")
                                    {
                                        webMeta.Keyword = rc.SeoKeyword;
                                    }
                                    else
                                    {
                                        webMeta.Keyword = string.Format("出境游线路,出境游行程,出境游报价,出境游跟团,重庆出发出境游");
                                    }
                                    if (rc.SeoDesc.Trim() != "")
                                    {
                                        webMeta.Description = rc.SeoDesc;
                                    }
                                    else
                                    {
                                        webMeta.Description = string.Format("重庆出发出境旅游线路、出境旅游行程报价由重庆中国青年旅行社提供设计,重庆青旅热线400-017-5761.");
                                    }
                                }
                            }
                            else if (rc.ID == (int)SysConfig.RouteClass.三峡旅游)
                            {
                                string filter = "";
                                if (price != "" || day != "")
                                {
                                    filter = "重庆三峡" + price + day + "旅游线路" + (price == "" ? "报价/价格/" : "") + "推荐";
                                    webMeta.Title = filter + tmpTitle;
                                    webMeta.Keyword = filter;
                                    webMeta.Description = string.Format("重庆中国青年旅行社提供{0},详情请咨询中青旅400-017-5761.", filter);
                                }
                                else
                                {
                                    if (rc.SeoTitle.Trim() != "")
                                    {
                                        webMeta.Title = rc.SeoTitle;
                                    }
                                    else
                                    {
                                        webMeta.Title = string.Format("重庆长江三峡旅游_重庆三峡旅游行程景点") + tmpTitle;
                                    }
                                    if (rc.SeoKeyword.Trim() != "")
                                    {
                                        webMeta.Keyword = rc.SeoKeyword;
                                    }
                                    else
                                    {
                                        webMeta.Keyword = string.Format("重庆三峡旅游,长江三峡旅游线路,三峡旅游报价,三峡游景点,三峡游船预定");
                                    }
                                    if (rc.SeoDesc.Trim() != "")
                                    {
                                        webMeta.Description = rc.SeoDesc;
                                    }
                                    else
                                    {
                                        webMeta.Description = string.Format("重庆三峡旅游行程、三峡游线路、长江三峡旅游报价由重庆中国青年旅行社提供设计,重庆青旅热线400-017-5761.");
                                    }
                                }
                            }
                        }
                        if (simodel != null)
                        {
                            if (simodel.SeoTitle != "")
                            {
                                webMeta.Title = simodel.SeoTitle;
                            }
                            if (simodel.SeoKeyword != "")
                            {
                                webMeta.Keyword = simodel.SeoKeyword;
                            }
                            if (simodel.SeoDescription != "")
                            {
                                webMeta.Description = simodel.SeoDescription;
                            }
                        }
                    }
                }
            }
            else if (url.IndexOf("routedetail.aspx") > -1)
            {
                string strClassID = Function.GetQueryString("id");
                if (Function.IsNumber(strClassID))
                {
                    ClassLibrary.Model.Routes rModel = routeBll.GetModel(Convert.ToInt32(strClassID));
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
            }
            else if (url.IndexOf("articlelist.aspx") > -1)
            {
                string strClassID = Function.GetQueryString("id");
                if (Function.IsNumber(strClassID))
                {
                    int classid = Convert.ToInt32(strClassID);
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
            }
            else if (url.IndexOf("articledetail.aspx") > -1)
            {
                string strClassID = Function.GetQueryString("id");
                if (Function.IsNumber(strClassID))
                {
                    ClassLibrary.Model.News newsModel = newsBll.GetModel(Convert.ToInt32(strClassID));
                    webMeta.Title = newsModel.Title + tmpTitle;

                    webMeta.Keyword = newsModel.Keywords;

                    if (webMeta.Keyword == "")
                    {
                        webMeta.Keyword = newsModel.Title;
                    }
                    if (newsModel.Description == "")
                    {
                        webMeta.Description = Function.Clip(Function.ClearHtml(newsModel.Content).Replace(" ", "").Replace("	", ""), 100, false);
                    }
                    else
                    {
                        webMeta.Description = newsModel.Description;
                    }
                }
            }
            else if (url.IndexOf("about.aspx") > -1)
            {
                string strClassID = Function.GetQueryString("id");
                if (Function.IsNumber(strClassID))
                {
                    if (Convert.ToInt32(strClassID) == (int)SysConfig.SystemArticle.联系我们)
                    {
                        webMeta.Title = "重庆青年旅行社电话/地址_重庆中青旅联系方式" + tmpTitle;
                        webMeta.Keyword = "重庆青年旅行社电话,重庆青年旅行社地址,重庆中青旅联系方式";
                        webMeta.Description = "重庆中国青年旅行社联系我们页面为您提供重庆青年旅行社电话,重庆青年旅行社地址,重庆中青旅电话,重庆中青旅联系方式,青旅热线400-017-5761.";
                    }
                    else if (Convert.ToInt32(strClassID) == (int)SysConfig.SystemArticle.关于我们)
                    {
                        webMeta.Title = "重庆中国青年旅行社简介_重庆中青旅介绍" + tmpTitle;
                        webMeta.Keyword = "";
                        webMeta.Description = "";
                    }
                    else
                    {
                        webMeta.Title = Enum.GetName(typeof(SysConfig.SystemArticle), Convert.ToInt32(strClassID)) + tmpTitle;
                        webMeta.Keyword = "";
                        webMeta.Description = "";
                    }
                }
            }
            else if (url.IndexOf("shopcart.aspx") > -1)
            {
                webMeta.Title = "旅游线路购物车信息" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("success.aspx") > -1)
            {
                webMeta.Title = "旅游线路预订成功" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("login.aspx") > -1)
            {
                webMeta.Title = "会员登录" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("vip/index.aspx") > -1)
            {
                webMeta.Title = "订单查询" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("info.aspx") > -1)
            {
                webMeta.Title = "会员个人信息" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("vip/message.aspx") > -1)
            {
                webMeta.Title = "旅游线路留言" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("changepwd.aspx") > -1)
            {
                webMeta.Title = "会员密码修改" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("vip/orders.aspx") > -1)
            {
                webMeta.Title = "会员订单信息" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("order.aspx") > -1)
            {
                webMeta.Title = "订单信息" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("orderdetail.aspx") > -1)
            {
                webMeta.Title = "会员订单详情" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("register.aspx") > -1)
            {
                webMeta.Title = "会员注册" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("nopage") > -1)
            {
                webMeta.Title = "页面不存在";
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("forgetpwd.aspx") > -1)
            {
                webMeta.Title = "找回密码" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("forgetpwd2.aspx") > -1)
            {
                webMeta.Title = "密码问题答案" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("forgetpwd3.aspx") > -1)
            {
                webMeta.Title = "设置新密码" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("sitemap.aspx") > -1)
            {
                webMeta.Title = "中青旅网站地图" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("links.aspx") > -1)
            {
                webMeta.Title = "友情链接" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("routesearchlist.aspx") > -1)
            {
                webMeta.Title = "旅游线路搜索结果" + tmpTitle;
                webMeta.Keyword = "";
                webMeta.Description = "";
            }
            else if (url.IndexOf("schedule.aspx") > -1)
            {
                webMeta.Title = "长江三峡豪华游轮船期表_三峡豪华游船船期表" + tmpTitle;
                webMeta.Keyword = "三峡豪华游轮船期表,三峡豪华游船船期表,三峡游船船期表";
                webMeta.Description = "重庆中国青年旅行社提供三峡豪华游船新世纪系列、总统系列、美维系列、黄金系列、长海系列等最新的三峡豪华游轮船期表及游船行程,详询中青旅电话400-017-5761.";
            }
            else if (url.IndexOf("saleslist.aspx") > -1)
            {
                webMeta.Title = "特价旅游专区_最划算的旅游" + tmpTitle;
                webMeta.Keyword = "青旅特价旅游,特价旅游旅行社,重庆旅行社特价团";
                webMeta.Description = "重庆中国青年旅行社特价旅游专区产品为限时限量旅游线路,由于游客临时退位置或者旅行社原因,导致紧急处理的旅游产品,在整个旅游行业可以说是性价比最高,超级划算的特价旅游产品.";
            }
            if (pageNo > 1) webMeta.Title = "第" + pageNo + "页_" + webMeta.Title;

            //在线QQ
            if (!string.IsNullOrEmpty(webMeta.QQ))
            {
                string[] qqs = webMeta.QQ.Split(',');

                for (int i = 0; i < qqs.Length; i++)
                {
                    qqList += string.Format(@"<li><a target='_blank' href='http://wpa.qq.com/msgrd?v=3&uin={0}&site=qq&menu=yes' rel='nofollow'>
                                <img src='/image/button_51.gif' alt='{1}' title='{1}'/>{1}</a>
                            </li>", qqs[i], qqs[++i]);
                }
            }

        }

        public void setMetaInfo(string className, string theme, string price, string day)
        {
            if (theme != "" && price == "" && day == "")
            {
                webMeta.Title = string.Format("{0}{1}_重庆到{0}{2}旅游价格_重庆中国青年旅行社", className, theme, theme.Replace("游", ""));
                webMeta.Keyword = string.Format("{0}{1},重庆到{0}{2}旅游,{0}{2}旅游价格", className, theme, theme.Replace("游", ""));
                webMeta.Description = string.Format("重庆中国青年旅行社提供{0}{1},重庆到{0}{2}旅游价格,重庆出发去{0}旅游路线,{0}跟团游价格,去{0}旅游费用,去{0}旅游要多少钱详询重庆中青旅电话400-017-5761.", className, theme, theme.Replace("游", ""));
            }
            else if (theme != "" && price != "" && day == "")
            {
                webMeta.Title = string.Format("重庆到{0}{1}{2}旅游线路推荐_重庆中国青年旅行社", className, theme, price);
                webMeta.Keyword = string.Format("重庆到{0}旅游, 重庆到{0}{1},重庆到{0}旅游线路", className, theme);
                webMeta.Description = string.Format("重庆中国青年旅行社提供重庆到{0}{1}{2}旅游线路推荐,重庆出发去{0}旅游路线,{0}跟团游价格,去{0}旅游费用,去{0}旅游要多少钱详询重庆中青旅电话400-017-5761.", className, theme, price);
            }
            else if (theme != "" && price == "" && day != "")
            {
                webMeta.Title = string.Format("重庆到{0}{1}{2}旅游线路价格推荐_重庆中国青年旅行社", className, theme.Replace("游", ""), day);
                webMeta.Keyword = string.Format("重庆到{0}{2},重庆到{0}旅游,重庆到{0}{1}", className, theme, day);
                webMeta.Description = string.Format("重庆中国青年旅行社提供重庆到{0}{1}{2}旅游线路推荐,重庆出发去{0}旅游路线,{0}跟团游价格,去{0}旅游费用,去{0}旅游要多少钱详询重庆中青旅电话400-017-5761.", className, theme.Replace("游", ""), day);
            }
            else if (theme != "" && price != "" && day != "")
            {
                webMeta.Title = string.Format("{0}{1}{2}{3}旅游线路推荐_重庆中国青年旅行社", className, theme.Replace("游", ""), day, price);
                webMeta.Keyword = string.Format("重庆到{0}{2},重庆到{0}旅游,重庆到{0}{1}", className, theme, day);
                webMeta.Description = string.Format("重庆中国青年旅行社提供{0}{1}{2}旅游线路推荐,重庆出发去{0}旅游路线,{0}跟团游价格,去{0}旅游费用,详询重庆中青旅电话400-017-5761.", className, theme.Replace("游", ""), day);
            }
            else if (theme == "" && price != "" && day == "")
            {
                webMeta.Title = string.Format("重庆去{0}旅游{1}旅游线路推荐_重庆中国青年旅行社", className, price);
                webMeta.Keyword = string.Format("重庆去{0}旅游,重庆去{0}旅游价格", className);
                webMeta.Description = string.Format("重庆中国青年旅行社提供重庆去{0}{1}旅游线路推荐,重庆出发去{0}旅游路线,{0}跟团游价格,去{0}旅游费用,详询重庆中青旅电话400-017-5761.", className, price);
            }
            else if (theme == "" && price == "" && day != "")
            {
                webMeta.Title = string.Format("重庆到{0}{1}_去{0}旅游要多少钱_重庆中国青年旅行社", className, day);
                webMeta.Keyword = string.Format("重庆到{0}{1},去{0}旅游要多少钱", className, day);
                webMeta.Description = string.Format("重庆中国青年旅行社提供重庆到{0}{1},去{0}要多少钱,重庆出发去{0}旅游路线,{0}跟团游价格,去{0}旅游费用,详询重庆中青旅电话400-017-5761.", className, day);
            }
            else if (theme == "" && price != "" && day != "")
            {
                webMeta.Title = string.Format("重庆到{0}{1}{2}旅游线路推荐_重庆中国青年旅行社", className, day, price);
                webMeta.Keyword = string.Format("重庆到{0}{1}{2}旅游线路推荐", className, day, price);
                webMeta.Description = string.Format("重庆中国青年旅行社提供重庆到{0}{1}{2}旅游线路推荐,重庆出发去{0}旅游路线,{0}跟团游价格,去{0}旅游费用,详询重庆中青旅电话400-017-5761.", className, day, price);
            }
        }

    }
}
