using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Text;
using ClassLibrary.Common;
using System.Net.Mail;
using System.Web.UI;
using System.Web.SessionState;

namespace WebUI
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>

    public class WebService : IHttpHandler, IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["ac"] == null)
                return;

            string action = context.Request.QueryString["ac"];
            switch (action)
            {
                case"findhomeRoute":
                    findhomeRoute(context);
                    break;
                case "findoutRoute":
                    findoutRoute(context);
                    break;
                case "finuserEmail":
                    finuserEmail(context);
                    break;
                case "fsEmail":
                    fsEmail(context);
                    break;
                case "FindIndexRoute":
                    FindIndexRoute(context);
                    break;
                case "findZhutiRoute":
                    findZhutiRoute(context);
                    break;
                case "findSanxiaRoute":
                    findSanxiaRoute(context);
                    break;
                case "articleSup":
                    articleSup(context);
                    break;
            }
        }
        public void articleSup(HttpContext context)
        {
            ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            //string ip = context.Request.ServerVariables["REMOTE_ADDR"];
            if (newsBll.Updates("zanCount = zanCount + 1", "id = " + id) > 0)
            {
                int zc = newsBll.GetModel(id).ZanCount;
                Print(context, zc.ToString());
            }
            else
            {
                Print(context, "0");
            }
        }
        public void findSanxiaRoute(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.QueryString["where"]);
            ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
            ClassLibrary.BLL.RouteClass routeClassBll = new ClassLibrary.BLL.RouteClass();
            List<ClassLibrary.Model.RouteClass> globalList = routeClassBll.GetSubList((int)SysConfig.RouteClass.三峡旅游);

            List<ClassLibrary.Model.Routes> routeList = routeBLL.GetModelList(6, "isdisplay=1 and (CHARINDEX('," + id + ",',','+routesPrentClassID+',') > 0)", "RouteOrder Asc,Createdtime Desc");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ul>");
            foreach (ClassLibrary.Model.Routes model in routeList)
            {
                ClassLibrary.Model.RouteClass temModel = globalList.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == model.LocationID; });
                sb.AppendLine("<li>");
                sb.AppendFormat("<a href='{4}/{2}/{3}.html' title='{1}' class='blk' ><img class='lazy' data-original='{0}' alt='' width='222' height='137' /></a>",
                    SysConfig.UploadFilePathRoutesImg + model.Image.Split(',')[0], model.Title, temModel.ClassNamePY, model.ID, SysConfig.webSite).AppendLine();
                sb.AppendFormat("<p class='item_t'><a href='{4}/{2}/{3}.html' title='{1}'>{0}</a></p>",
                    Function.Clip(model.Title, 14, false), model.Title, temModel.ClassNamePY, model.ID, SysConfig.webSite).AppendLine();
                sb.AppendFormat("<p class='item_f' title='{0}'>{1}</p>", model.Bright, Function.Clip(model.Bright, 18, false)).AppendLine();
                string tp = string.Format("&yen;{0}<span>起</span>", Convert.ToInt32(model.Price));
                if (Convert.ToInt32(model.Price) == 0) tp = "电询";
                sb.AppendFormat("<p class='item_p'>{0}</p>", tp).AppendLine();
                sb.AppendLine("</li>");
            }
            sb.AppendLine("</ul>");

            Print(context, sb.ToString());
        }
        public void findZhutiRoute(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.QueryString["where"]);
            string className =context.Request.QueryString["name"];

            StringBuilder sbc = new StringBuilder();
            ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
            ClassLibrary.BLL.RouteClass routeClassBll = new ClassLibrary.BLL.RouteClass();
            List<ClassLibrary.Model.RouteClass> globalList = routeClassBll.GetModelList(string.Empty);

            sbc.AppendLine("<div class='ztc_img'>");
            //if (ztAdList.Count > 0)
            //{
            //    ztModel = ztAdList[0];
            //}
            //sbc.AppendFormat("<a href='{0}' title='{1}'><img class='lazy' data-original='{2}' alt='' width='222' height='467' /></a>",
            //    ztModel.LinkURL, ztModel.Title, SysConfig.UploadFilePathAdImg + ztModel.Img).AppendLine();
            sbc.AppendLine("</div>");
            sbc.AppendLine("<ul class='ztc_items'>");

            List<ClassLibrary.Model.Routes> ztRouteListm = routeBLL.GetModelList(6, "isdisplay=1 and charindex('," + id + ",',','+ThemeID+',')>0 and CHARINDEX('1',RecommendIndex) > 0", "routeOrder Asc, CreatedTime Desc");
            string ztids = "";
            foreach (ClassLibrary.Model.Routes rm in ztRouteListm)
            {
                ClassLibrary.Model.RouteClass tmpc = globalList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == rm.LocationID; });
                sbc.AppendLine("<li>");
                sbc.AppendFormat("<a href='{0}/{1}/{2}.html' title='{3}' class='blk' ><img class='lazy' data-original='{4}' alt='' width='222' height='139' /></a>",
                    SysConfig.webSite, tmpc.ClassNamePY, rm.ID, rm.Title, SysConfig.UploadFilePathRoutesImg + rm.Image.Split(',')[0]).AppendLine();
                sbc.AppendFormat("<p class='item_t'><a href='{0}/{1}/{2}.html' title='{3}'>{4}</a></p>",
                    SysConfig.webSite, tmpc.ClassNamePY, rm.ID, rm.Title, Function.Clip(rm.Title, 15, false)).AppendLine();
                //sbc.AppendFormat("<p class='item_f' title='{0}'>{1}</p>", rm.Bright, Function.Clip(rm.Bright, 19, false)).AppendLine();
                string tp = string.Format("&yen;{0}<span>起</span>", Convert.ToInt32(rm.Price));
                if (Convert.ToInt32(rm.Price) == 0) tp = "电询";
                sbc.AppendFormat("<p class='item_p'>{0}</p>", tp).AppendLine();
                sbc.AppendLine("</li>");
                ztids += rm.ID + ",";
            }
            if (ztids.Length > 0) ztids = ztids.Substring(0, ztids.Length - 1);
            sbc.AppendLine("</ul>");
            sbc.AppendLine("<div class='ztc_more'>");
            sbc.AppendLine("<dl class='ztc_more_gn'>");
            sbc.AppendFormat("<dt>国内热门{0}旅游线路</dt>", className).AppendLine();
            if (ztids.Length > 0)
            {
                List<ClassLibrary.Model.Routes> ztRouteListg = routeBLL.GetModelList(6, "isdisplay=1 and id not in (" + ztids + ") and charindex('," + id + ",',','+ThemeID+',')>0 and charindex('," + (int)SysConfig.RouteClass.国内旅游 + ",',','+routesPrentClassID+',')>0", "routeOrder Asc, CreatedTime Desc");
                foreach (ClassLibrary.Model.Routes rm in ztRouteListg)
                {
                    ClassLibrary.Model.RouteClass tmpc = globalList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == rm.LocationID; });
                    string tp = string.Format("&yen;{0}起", Convert.ToInt32(rm.Price));
                    if (Convert.ToInt32(rm.Price) == 0) tp = "电询";
                    sbc.AppendFormat("<dd><a href='{0}/{1}/{2}.html' title='{3}'>{4}</a><span>{5}</span></dd>",
                        SysConfig.webSite, tmpc.ClassNamePY, rm.ID, rm.Title, Function.Clip(rm.Title, 10, false), tp).AppendLine();
                }
            }
            sbc.AppendLine("</dl>");
            sbc.AppendLine("<dl class='ztc_more_cj'>");
            sbc.AppendFormat("<dt>出境热门{0}旅游线路</dt>", className).AppendLine();
            if (ztids.Length > 0)
            {
                List<ClassLibrary.Model.Routes> ztRouteListc = routeBLL.GetModelList(6, "isdisplay=1 and id not in (" + ztids + ") and charindex('," + id + ",',','+ThemeID+',')>0 and charindex('," + (int)SysConfig.RouteClass.出境旅游 + ",',','+routesPrentClassID+',')>0", "routeOrder Asc, CreatedTime Desc");
                foreach (ClassLibrary.Model.Routes rm in ztRouteListc)
                {
                    ClassLibrary.Model.RouteClass tmpc = globalList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ID == rm.LocationID; });
                    string tp = string.Format("&yen;{0}起", Convert.ToInt32(rm.Price));
                    if (Convert.ToInt32(rm.Price) == 0) tp = "电询";
                    sbc.AppendFormat("<dd><a href='{0}/{1}/{2}.html' title='{3}'>{4}</a><span>{5}</span></dd>",
                        SysConfig.webSite, tmpc.ClassNamePY, rm.ID, rm.Title, Function.Clip(rm.Title, 10, false), Convert.ToInt32(rm.Price)).AppendLine();
                }
            }
            sbc.AppendLine("</dl>");
            //sbc.AppendLine("<div class='ztc_more_img'>");
            //sbc.AppendFormat("<a href='{0}' title='{1}'><img src='{2}' alt='' width='190' height='111' /></a>",
            //    ztModel.LinkURL, ztModel.Title, SysConfig.UploadFilePathAdImg + ztImgr).AppendLine();
            //sbc.AppendLine("</div>");
            sbc.AppendLine("<div class='inx_zt_bg_right'></div>");
            sbc.AppendLine("</div>");
            Print(context, sbc.ToString());
        }

        //特色旅游 推荐 热门等等  不查三峡旅游
        public void FindIndexRoute(HttpContext context)
        {
            int sanid = (int)SysConfig.RouteClass.三峡旅游;
            string type = context.Request.QueryString["type"];
            ClassLibrary.BLL.Routes routebll = new ClassLibrary.BLL.Routes();
            DataSet mySet = routebll.GetPageData(8, 1, "  isdisplay=1 and CHARINDEX('," + sanid + ",',','+routesPrentClassID+',') = 0 and CHARINDEX('" + type + "',RecommendIndex) > 0 ", " RouteOrder,CreatedTime desc ");
            DataTable table = mySet.Tables["Data"];
            StringBuilder sb = new StringBuilder();

            ClassLibrary.BLL.RouteClass rcBLL = new ClassLibrary.BLL.RouteClass();
            List<ClassLibrary.Model.RouteClass> rcList = rcBLL.GetModelList(String.Empty);

            int q = 0;
            sb.Append("<div class='main_hot_body'>");
            foreach (DataRow dr in table.Rows)
            {
                q++;
                string temClassPy = rcList.Find(delegate(ClassLibrary.Model.RouteClass trc) { return trc.ID == Convert.ToInt32(dr["LocationID"].ToString()); }).ClassNamePY;

                if (q <= 4)
                {
                    sb.Append("<div class='main_hot_body_item'>");
                    string[] imgs = dr["Image"].ToString().Split(',');
                    sb.AppendFormat("<img alt='{0}' src='{1}' width='230px' height='147px'/>", dr["Title"], ClassLibrary.Common.SysConfig.UploadFilePathRoutesImg + imgs[0]);
                    sb.AppendFormat("<p><span class='c_destin'>{1}</span><span class='c_price'>&yen;{0}起</span></p>", Convert.ToInt32(dr["Price"]), Function.Clip(dr["Destination"].ToString(), 8, true));
                    sb.Append("<div class='main_hot_body_font'><ul>");
                    sb.AppendFormat(" <li><a href='{3}/{2}/{1}.html' style='width:100%;'>{0}</a></li>", ClassLibrary.Common.Function.Clip(dr["Title"].ToString(), 10, true), dr["ID"], temClassPy, SysConfig.webSite);
                    sb.AppendFormat(" <li>{0}</li>", ClassLibrary.Common.Function.Clip(ClassLibrary.Common.Function.ClearHtml(dr["RouteFeature"].ToString()), 18, true));
                    sb.AppendFormat("<li><a href='{2}/{1}/{0}.html' target='_blank' >查看线路</a></li>", dr["ID"], temClassPy, SysConfig.webSite);
                    sb.Append("</ul></div> </div>");
                    if (q==4)
                    {
                        sb.Append("</div><div class='main_hot_bottom'><ul>");
                    }
                }
                else
                {
                    sb.AppendFormat("<li><a href='{3}/{2}/{1}.html' target='_blank' >{0}</a></li>", ClassLibrary.Common.Function.Clip(dr["Title"].ToString(), 18, true), dr["ID"], temClassPy, SysConfig.webSite);
                    sb.AppendFormat("<li class='hei'>&yen;<em>{0}</em>元起</li>", Convert.ToInt32(dr["Price"]));
                }
               
            }
            sb.Append("</ul></div>");
            if (q==0)
            {
                 Print(context, "");
            }
            else
            {
                Print(context, sb.ToString());
            }
        }
        
        /// <summary>     
        /// 发送邮件    
        /// /// </summary> 
        /// /// <param name="to">接收者</param>    
        /// /// <param name="title">标题</param> 
        /// /// <param name="content">内容-支持HTML</param> 
        /// /// <param name="host">SMTP服务器</param> 
        /// /// <param name="username">用户名</param>
        /// /// <param name="password">密码</param> 
        /// /// <param name="port">SMTP端口</param>
        /// /// <param name="ssl">安全套接层协议</param>
        /// /// <returns></returns> 
        public static bool SendEmail(string to, string title, string content, string host, string username, string password, int port, bool ssl)
        {         
            bool bl; 
            try { 
                SmtpClient client = new SmtpClient(); 
                client.Host = host; 
                client.Port = port; 
                client.EnableSsl = ssl; 
                client.UseDefaultCredentials = false; 
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(username, password);
                client.Credentials = basicAuthenticationInfo; 
                client.DeliveryMethod = SmtpDeliveryMethod.Network;  
                MailMessage message = new MailMessage(username, to, title, content);
                message.BodyEncoding = Encoding.UTF8;     
                message.Priority = MailPriority.High;  
                message.IsBodyHtml = true; 
                client.Send(message);    
                bl = true;         }  
            catch (SmtpException ex)         {   
                bl = false;          
                throw ex;       
            }      
            return bl;     }
        public void fsEmail(HttpContext context)
        {
            string email = context.Request.QueryString["email"];
            string num = context.Request.QueryString["num"];
            bool qa = SendEmail(email, "邮箱验证码", num, "smtp.qq.com", "852625623@qq.com", "72361687zyh", 25, false);
            if (qa)
            {
                Print(context, "1");
            }
            else
            {
                Print(context, "2");
            }
        }
        public void finuserEmail(HttpContext context)
        {
           
        }
        //出境
        public void findoutRoute(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.QueryString["where"]);
            ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
            DataTable mytable = routeBLL.GetData(4, "isdisplay=1 and (CHARINDEX('," + id + ",',','+routesPrentClassID+',') > 0) and RecommendHot = 1", "Createdtime Desc");
            mytable.Merge(routeBLL.GetData(16, "isdisplay=1 and (CHARINDEX('," + id + ",',','+routesPrentClassID+',') > 0)", "RouteOrder Asc,Createdtime Desc"));
            mytable = mytable.AsDataView().ToTable(true);
            List<ClassLibrary.Model.Routes> routeList = routeBLL.GetModelList(mytable);
            //List<ClassLibrary.Model.Routes> routeList = routeBLL.GetModelList(8, "(CHARINDEX('," + id + ",',','+routesPrentClassID+',') > 0)", "RouteOrder Asc,Createdtime Desc");
            List<ClassLibrary.Model.RouteClass> globalList = routeClassBLL.GetSubList((int)SysConfig.RouteClass.出境旅游);
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            int count = 0;
            sb.AppendLine("<ul class='cjc_down'>");
            sb2.AppendLine("<ul class='cjc_up'>");
            foreach (ClassLibrary.Model.Routes model in routeList)
            {
                if (count >= 16) break;
                ClassLibrary.Model.RouteClass temModel = globalList.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == model.LocationID; });
                if (count < 4)
                {
                    sb2.AppendLine("<li>");
                    sb2.AppendFormat("<a href='{4}/{2}/{3}.html' title='{1}' class='blk' target='_blank'><img class='lazy' data-original='{0}' alt='' width='222' height='138' /></a>",
                        SysConfig.UploadFilePathRoutesImg + model.Image.Split(',')[0], model.Title, temModel.ClassNamePY, model.ID, SysConfig.webSite).AppendLine();
                    sb2.AppendFormat("<p class='item_t'><a href='{4}/{2}/{3}.html' title='{1}' target='_blank'>{0}</a></p>",
                        Function.Clip(model.Title, 28, false), model.Title, temModel.ClassNamePY, model.ID, SysConfig.webSite).AppendLine();
                    sb2.AppendFormat("<p class='item_f' title='{0}'>{1}&nbsp;</p>", model.Bright, Function.Clip(model.Bright, 16, false)).AppendLine();
                    string tp = string.Format("&yen;{0}<span>起</span>", Convert.ToInt32(model.Price));
                    if (Convert.ToInt32(model.Price) == 0) tp = "电询";
                    sb2.AppendFormat("<p class='item_p'>{0}</p>", tp).AppendLine();
                    sb2.AppendLine("</li>");
                }
                else
                {
                    sb.AppendLine("<li>");
                    sb.AppendFormat("<p class='item_title'><a href='{4}/{2}/{3}.html' title='{1}' target='_blank'>{0}</a></p>",
                        Function.Clip(model.Title, 26, false), model.Title, temModel.ClassNamePY, model.ID, SysConfig.webSite).AppendLine();
                    string tp = string.Format("&yen;{0}起", Convert.ToInt32(model.Price));
                    if (Convert.ToInt32(model.Price) == 0) tp = "电询";
                    sb.AppendFormat("<div class='cjc_left_price'>{0}</div>", tp).AppendLine();
                    sb.AppendLine("</li>");
                }
                count++;
            }
            sb.AppendLine("</ul>");
            sb2.AppendLine("</ul>");
            Print(context, sb2.ToString() + sb.ToString());
        }
        //国内
        public void findhomeRoute(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.QueryString["where"]);
            ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
            DataTable mytable = routeBLL.GetData(4, "isdisplay=1 and (CHARINDEX('," + id + ",',','+routesPrentClassID+',') > 0) and RecommendHot = 1", "Createdtime Desc");
            mytable.Merge(routeBLL.GetData(16, "isdisplay=1 and (CHARINDEX('," + id + ",',','+routesPrentClassID+',') > 0)", "RouteOrder Asc,Createdtime Desc"));
            mytable = mytable.AsDataView().ToTable(true);
            List<ClassLibrary.Model.Routes> routeList = routeBLL.GetModelList(mytable);
            //List<ClassLibrary.Model.Routes> routeList = routeBLL.GetModelList(8, "(CHARINDEX('," + id + ",',','+routesPrentClassID+',') > 0)", "RouteOrder Asc,Createdtime Desc");
            List<ClassLibrary.Model.RouteClass> globalList = routeClassBLL.GetSubList((int)SysConfig.RouteClass.国内旅游);

            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            int count = 0;
            sb.AppendLine("<ul class='gnc_down'>");
            sb2.AppendLine("<ul class='gnc_up'>");
            foreach (ClassLibrary.Model.Routes model in routeList)
            {
                if (count >= 16) break;
                ClassLibrary.Model.RouteClass temModel = globalList.Find(delegate(ClassLibrary.Model.RouteClass tm) { return tm.ID == model.LocationID; });
                if (count < 4)
                {
                    sb2.AppendLine("<li>");
                    sb2.AppendFormat("<a href='{4}/{2}/{3}.html' title='{1}' class='blk' target='_blank'><img class='lazy' data-original='{0}' alt='' width='222' height='138' /></a>",
                        SysConfig.UploadFilePathRoutesImg + model.Image.Split(',')[0], model.Title, temModel.ClassNamePY, model.ID, SysConfig.webSite).AppendLine();
                    sb2.AppendFormat("<p class='item_t'><a href='{4}/{2}/{3}.html' title='{1}' target='_blank'>{0}</a></p>",
                        Function.Clip(model.Title, 28, false), model.Title, temModel.ClassNamePY, model.ID, SysConfig.webSite).AppendLine();
                    sb2.AppendFormat("<p class='item_f' title='{0}'>{1}&nbsp;</p>", model.Bright, Function.Clip(model.Bright, 16, false)).AppendLine();
                    string tp = string.Format("&yen;{0}<span>起</span>", Convert.ToInt32(model.Price));
                    if (Convert.ToInt32(model.Price) == 0) tp = "电询";
                    sb2.AppendFormat("<p class='item_p'>{0}</p>", tp).AppendLine();
                    sb2.AppendLine("</li>");
                }
                else
                {
                    sb.AppendLine("<li>");
                    sb.AppendFormat("<p class='item_title'><a href='{4}/{2}/{3}.html' title='{1}' target='_blank'>{0}</a></p>",
                        Function.Clip(model.Title, 26, false), model.Title, temModel.ClassNamePY, model.ID, SysConfig.webSite).AppendLine();
                    string tp = string.Format("&yen;{0}起", Convert.ToInt32(model.Price));
                    if (Convert.ToInt32(model.Price) == 0) tp = "电询";
                    sb.AppendFormat("<div class='gnc_left_price'>{0}</div>", tp).AppendLine();
                    sb.AppendLine("</li>");
                }
                count++;
            }
            sb.AppendLine("</ul>");
            sb2.AppendLine("</ul>");
            Print(context, sb2.ToString() + sb.ToString());
        }
        
        private void Print(HttpContext context, string msg)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = "text/plain";
            context.Response.Write(msg);
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
