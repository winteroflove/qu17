using System;
using System.Collections.Generic;
using System.Web;
using ClassLibrary;
using System.Data;
using System.Text;
using ClassLibrary.Common;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Util;
using System.Net;
using Winista.Text.HtmlParser.Tags;

namespace WebUI.WebManage
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>

    public class Service : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            if (context.Request.QueryString["ac"] == null)
                return;

            string action = context.Request.QueryString["ac"];

            switch (action)
            {
                case "NewsDelete":
                    NewsDelete(context);
                    break;
                case "NewsClassDelete":
                    NewsClassDelete(context);
                    break;
                case "RouteClassDelete":
                    RouteClassDelete(context);
                    break;
                case "LinksDelete":
                    LinksDelete(context);
                    break;
                case "InternalLinkDelete":
                    InternalLinkDelete(context);
                    break;
                case "RouteDelete":
                    RouteDelete(context);
                    break;
                case "RouteCommentDelete":
                    RouteCommentDelete(context);
                    break;
                case "OrdersDelete":
                    OrdersDelete(context);
                    break;
                case "AdminDelete":
                    AdminDelete(context);
                    break;
                case "MemberDelete":
                    MemberDelete(context);
                    break;
                case "AdDelete":
                    AdDelete(context);
                    break;
                case "ScrollImageDelete":
                    ScrollImageDelete(context);
                    break;
                case "RouteOrderUpdate":
                    UpdateRouteOrder(context);
                    break;
                case "RoutePriceUpdate":
                    UpdateRoutePrice(context);
                    break;
                case "HiddenRoutes":
                    HiddenRoutes(context);
                    break;
                case "DisplayRoutes":
                    DisplayRoutes(context);
                    break;
                case "UpdateProvince":
                    UpdateProvince(context);
                    break;
                case "GetCity":
                    GetCity(context);
                    break;
                case "UpdateOrderDetailPrice":
                    UpdateOrderDetailPrice(context);
                    break;
                case "HiddenNews":
                    HiddenNews(context);
                    break;
                case "DisplayNews":
                    DisplayNews(context);
                    break;
                case "RefreshLinks":
                    RefreshLinks(context);
                    break;
                case "DeleteNews":
                    DeleteNews(context);
                    break;
                case "updateRouteImg":
                    updateRouteImg(context);
                    break;
                case "setNewsImg":
                    setNewsImg(context);
                    break;
                case "DeleteLinks":
                    DeleteLinks(context);
                    break;
                case "GrapBaiduMsg":
                    GrapBaiduMsg(context);
                    break;
                case "updateImgAddress":
                    updateImgAddress(context);
                    break;
                case "UpdateQQorder":
                    UpdateQQorder(context);
                    break;
                case "CustomerDelete":
                    CustomerDelete(context);
                    break;
                case "DisplayCustomer":
                    DisplayCustomer(context);
                    break;
                case "seoInfoDelete":
                    seoInfoDelete(context);
                    break;
                case "RouteTypeDelete":
                    RouteTypeDelete(context);
                    break;
                case "SaleAdvertiseDelete":
                    SaleAdvertiseDelete(context);
                    break;
                case "RouteCopy":
                    RouteCopy(context);
                    break;
                case "ResetPassword":
                    ResetPassword(context);
                    break;
                case "SaleOrderUpdate":
                    UpdateSaleOrder(context);
                    break;
            }
        }
        private void UpdateSaleOrder(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            string saleOrder = context.Request.QueryString["saleOrder"];

            ClassLibrary.BLL.SaleAdvertise saleBLL = new ClassLibrary.BLL.SaleAdvertise();

            if (saleBLL.Updates("SaleOrder = " + int.Parse(saleOrder), "ID = " + int.Parse(id)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void ResetPassword(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            ClassLibrary.BLL.Member mber = new ClassLibrary.BLL.Member();

            if (mber.Updates("Password = '" + Function.MD5("12345678") + "'", "id = " + id) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }
        private void RouteCopy(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
            ClassLibrary.Model.Routes routemodel = routeBll.GetModel(int.Parse(id));
            if (routemodel == null || routemodel.Title == "")
            {
                Print(context, "error");
                return;
            }
            string[] oldImgs = routemodel.Image.Split(',');
            string fileFullPath = context.Server.MapPath(SysConfig.UploadFilePathRoutesImg);
            string newImgs = "";
            for (int i = 0; i < oldImgs.Length; i++)
            {
                string ext = Path.GetExtension(oldImgs[i]);
                string fileName = Function.GetRandomTime() + ext;
                try
                {
                    File.Copy(fileFullPath + oldImgs[i], fileFullPath + fileName);
                } catch(Exception e) {
                    
                }
                newImgs += fileName + ",";
            }
            if (!string.IsNullOrEmpty(newImgs))
            {
                newImgs = newImgs.Substring(0, newImgs.Length - 1);
            }
            routemodel.Image = newImgs;
            routemodel.Display = false;
            routemodel.ViewCount = 0;
            routemodel.Order = 999;
            routemodel.FirstTime = DateTime.Now.ToString("yyyy-MM-dd");
            routemodel.CreatedTime = DateTime.Now;

            if (routeBll.Add(routemodel) > 0)
            {
                if (routemodel.DetailType)
                {
                    int routeId = routeBll.GetLastId();
                    ClassLibrary.BLL.RouteDetails rdBll = new ClassLibrary.BLL.RouteDetails();
                    List<ClassLibrary.Model.RouteDetails> detailList = rdBll.GetModelList("routeId = " + routemodel.ID);
                    foreach (ClassLibrary.Model.RouteDetails model in detailList)
                    {
                        model.RouteID = routeId;
                        rdBll.Add(model);
                    }
                    Print(context, "success");
                }
            }
            else
            {
                Print(context, "error");
            }
        }
        private void SaleAdvertiseDelete(HttpContext context)
        {
            ClassLibrary.BLL.SaleAdvertise bll = new ClassLibrary.BLL.SaleAdvertise();

            string strid = context.Request.QueryString["id"];
            string img = context.Request.QueryString["img"];

            if (bll.Delete(Convert.ToInt32(strid)))
            {
                ClassLibrary.Common.Function.DeleteFile(context.Server.MapPath(ClassLibrary.Common.SysConfig.UploadFilePathScrollImg + img));

                Print(context, "success");
            }
            else
            {
                Print(context, "error");
            }
        }
        private void RouteTypeDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
            if (routeBll.GetModelList("CHARINDEX('," + int.Parse(id) + ",',','+ThemeID+',')>0").Count > 0)
            {
                Print(context, "existdata");
                return;
            }
            ClassLibrary.BLL.RouteType routeClassBLL = new ClassLibrary.BLL.RouteType();

            if (routeClassBLL.Delete(int.Parse(id)))
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }
        private void DeleteLinks(HttpContext context)
        {
            string id = context.Request.QueryString["ids"];
            ClassLibrary.BLL.Links rbll = new ClassLibrary.BLL.Links();

            if (rbll.Deletes("id in (" + id + ")") > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }
        private void seoInfoDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.SeoInfo bll = new ClassLibrary.BLL.SeoInfo();

            if (bll.Delete(int.Parse(id)))
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }
        private void DisplayCustomer(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            bool inuse = !Convert.ToBoolean(context.Request.QueryString["inuse"]);

            ClassLibrary.BLL.Customers cBLL = new ClassLibrary.BLL.Customers();

            if (cBLL.UpdateInuse(int.Parse(id), inuse) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }
        private void CustomerDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.Customers bll = new ClassLibrary.BLL.Customers();

            if (bll.Delete(int.Parse(id)))
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }
        private void UpdateQQorder(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            string qqOrder = context.Request.QueryString["qqOrder"];

            ClassLibrary.BLL.Customers cBLL = new ClassLibrary.BLL.Customers();

            if (cBLL.UpdateOrder(int.Parse(id), int.Parse(qqOrder)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }
        private void updateImgAddress(HttpContext context)
        {
            ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
            ClassLibrary.BLL.RouteDetails rdBll = new ClassLibrary.BLL.RouteDetails();

            List<ClassLibrary.Model.Routes> routeList = routeBll.GetModelList("id > 677");
            foreach (ClassLibrary.Model.Routes model in routeList)
            {
                bool updated = false;
                if (model.RouteFeature.IndexOf("www.ytszg.com") > -1)
                {
                    model.RouteFeature = model.RouteFeature.Replace("www.ytszg.com", "www.qu17.com");
                    updated = true;
                }
                if (model.RouteFeature.IndexOf("file/newsImg/image") > -1)
                {
                    model.RouteFeature = model.RouteFeature.Replace("file/newsImg/image", "images");
                    updated = true;
                }
                if (model.DescriptionRoute.IndexOf("www.ytszg.com") > -1)
                {
                    model.DescriptionRoute = model.DescriptionRoute.Replace("www.ytszg.com", "www.qu17.com");
                    updated = true;
                }
                if (model.DescriptionRoute.IndexOf("file/newsImg/image") > -1)
                {
                    model.DescriptionRoute = model.DescriptionRoute.Replace("file/newsImg/image", "images");
                    updated = true;
                }
                if (model.RouteNotice.IndexOf("www.ytszg.com") > -1)
                {
                    model.RouteNotice = model.RouteNotice.Replace("www.ytszg.com", "www.qu17.com");
                    updated = true;
                }
                if (model.DescriptionPrice.IndexOf("www.ytszg.com") > -1)
                {
                    model.DescriptionPrice = model.DescriptionPrice.Replace("www.ytszg.com", "www.qu17.com");
                    updated = true;
                }
                if (updated)
                {
                    routeBll.Update(model);
                }
            }
            List<ClassLibrary.Model.RouteDetails> routedList = rdBll.GetModelList(" routeid > 677");
            foreach (ClassLibrary.Model.RouteDetails model in routedList)
            {
                bool updated = false;
                if (model.DayDetail.IndexOf("www.ytszg.com") > -1)
                {
                    model.DayDetail = model.DayDetail.Replace("www.ytszg.com", "www.qu17.com");
                    updated = true;
                }
                if (model.DayDetail.IndexOf("file/newsImg/image") > -1)
                {
                    model.DayDetail = model.DayDetail.Replace("file/newsImg/image", "images");
                    updated = true;
                }
                if (updated)
                {
                    rdBll.Update(model);
                }
            }
            Print(context, "success");
        }
        private string GetHtmlStr(string url)
        {
            HttpWebRequest oWebRqst = (HttpWebRequest)WebRequest.Create(url);
            oWebRqst.Timeout = 50000;
            oWebRqst.Headers.Set("Pragma", "no-cache");
            oWebRqst.UserAgent = "Mozilla-Firefox-Spider(Wenanry)";
            WebResponse oWebRps = oWebRqst.GetResponse();
            StreamReader oStreamRd = new StreamReader(oWebRps.GetResponseStream(), Encoding.GetEncoding("utf-8"));
            return oStreamRd.ReadToEnd();
        }
        private void GrapBaiduMsg(HttpContext context)
        {
            string sRslt = GetHtmlStr("http://www.yododo.com/ask/list/");
            ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
            List<ClassLibrary.Model.RouteClass> rcList = rcBll.GetModelList("classLevel = 3");

            Parser parser = Parser.CreateParser(sRslt, "utf-8");
            NodeFilter filterUL = new AndFilter(new TagNameFilter("ul"), new HasAttributeFilter("class", "miniarea-list clearfix"));
            NodeList liList = parser.Parse(filterUL);
            string links = liList[0].ToHtml();

            parser = Parser.CreateParser(links, "utf-8");
            NodeFilter filterLI = new TagNameFilter("li"); //new NodeClassFilter(typeof(ATag));
            NodeList nodelist = parser.Parse(filterLI);

            //string strGn = nodelist[1].ToHtml();
            string strCj = nodelist[0].ToHtml();

            //parser = Parser.CreateParser(nodelist.ToHtml(), "utf-8");
            NodeFilter filterA = new NodeClassFilter(typeof(ATag));
            /*NodeList aGnList = parser.Parse(filterA);
            for (int i = 0; i < aGnList.Count; i++)
            {
                ITag tag = getTag(aGnList[i]);
                string url = "http://www.yododo.com" + tag.GetAttribute("href") + "s1";  //已解决
                string className = tag.ToPlainTextString();
                if (className == "全部") continue;

                ClassLibrary.Model.RouteClass model = rcList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ClassName == className; });
                if (model == null) continue;
                
                paserData(aGnList[i], url, model.ID);
            }*/

            parser = Parser.CreateParser(strCj, "utf-8");
            NodeList areaCjList = parser.Parse(filterA);
            for (int i = 0; i < areaCjList.Count; i++)
            {
                ITag tag = getTag(areaCjList[i]);
                string url = "http://www.yododo.com" + tag.GetAttribute("href");  //各洲
                string className = tag.ToPlainTextString();
                if (className == "全部" || className == "中国") continue;

                parser = Parser.CreateParser(GetHtmlStr(url), "utf-8");
                //NodeFilter filterUL = new AndFilter(new TagNameFilter("ul"), new HasAttributeFilter("class", "miniarea-list clearfix"));
                NodeList liListCj = parser.Parse(filterUL);
                string linksCj = liListCj[0].ToHtml();

                parser = Parser.CreateParser(linksCj, "utf-8");
                //NodeFilter filterA = new NodeClassFilter(typeof(ATag));
                NodeList aCjList = parser.Parse(filterA);
                for (int j = 0; j < aCjList.Count; j++)
                {
                    ITag cjtag = getTag(aCjList[j]);
                    string url1 = "http://www.yododo.com" + cjtag.GetAttribute("href") + "s1";  //已解决
                    string className1 = cjtag.ToPlainTextString();
                    if (className1 == "全部") continue;

                    ClassLibrary.Model.RouteClass model = rcList.Find(delegate(ClassLibrary.Model.RouteClass rc) { return rc.ClassName == className1; });
                    if (model == null) continue;

                    paserData(aCjList[j], url1, model.ID);
                }
            }

            Print(context, "success");
        }
        private void paserData(INode node, string url, int routeId)
        {
            Parser parser = Parser.CreateParser(GetHtmlStr(url), "utf-8");
            NodeFilter filter = new AndFilter(new TagNameFilter("li"), new HasAttributeFilter("class", "clearfix"));
            NodeList msgList = parser.Parse(filter);
            //saveMessage(msgList, routeId);

            parser.Reset();
            NodeFilter pagefilter = new AndFilter(new TagNameFilter("div"), new HasAttributeFilter("class", "review-menu clearfix"));
            NodeList pageList = parser.Parse(pagefilter);

            parser = Parser.CreateParser(pageList.ToHtml(), "utf-8");
            NodeFilter filterA = new NodeClassFilter(typeof(ATag));
            NodeList pgList = parser.Parse(filterA);

            for (int i = 1; i < pgList.Count; i++)
            {
                string url2 = "http://www.yododo.com" + getTag(pgList[i]).GetAttribute("href");
                parser = Parser.CreateParser(GetHtmlStr(url2), "utf-8");
                //NodeFilter filter = new AndFilter(new TagNameFilter("li"), new HasAttributeFilter("class", "clearfix"));
                msgList = parser.Parse(filter);
                //saveMessage(msgList, routeId);
                if (i == 3) break;
            }
        }
        
        private ITag getTag(INode node)
        {
            if (node == null)
                return null;
            return node is ITag ? node as ITag : null;
        }
        private void setNewsImg(HttpContext context)
        {
            string ids = context.Request.QueryString["id"];
            ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
            List<ClassLibrary.Model.News> newsList = newsBll.GetModelList("newsClassID in ("+ids+") and charindex('<img',Content) > 0 and image = ''");
            foreach (ClassLibrary.Model.News model in newsList)
            {
                string rule = "<img[^>]+?>";
                Match match = Regex.Match(model.Content, rule);
                if (match.ToString() != "")
                {
                    string imgurl = match.ToString();
                    imgurl = imgurl.Substring(imgurl.IndexOf("src=") + 5);
                    imgurl = imgurl.Substring(0, imgurl.IndexOf("\""));
                    string fileFullPath = context.Server.MapPath(SysConfig.UploadFilePathNewsImg);
                    string fileName = Function.GetRandomTime() + Path.GetExtension(imgurl);

                    if (imgurl.IndexOf("file") != 1 && imgurl.IndexOf("ytszg.com") < 0) continue;
                    if (imgurl.IndexOf("ytszg.com") >= 0)
                    {
                        imgurl = imgurl.Replace("http://www.qu17.com", "").Replace("www.qu17.com", "");
                    }
                    imgurl = context.Server.MapPath(imgurl);
                    if (File.Exists(imgurl))
                    {
                        //缩图
                        Bitmap tmp = new Bitmap(imgurl);
                        Bitmap bmp0 = Function.MakeThumNail(tmp, 300, 186);
                        tmp.Dispose();
                        //bmp0.Save(fileFullPath + fileName);
                        Function.SaveBitmapImg(bmp0, fileFullPath + fileName, ((long)80));
                        bmp0.Dispose();

                        newsBll.Updates("image='" + fileName + "'", "id = " + model.ID);
                    }
                }
            }
            Print(context, "success");
        }
        private void updateRouteImg(HttpContext context)
        {
            ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
            List<ClassLibrary.Model.Routes> routeList = routeBll.GetModelList(string.Empty);
            string fileFullPath = context.Server.MapPath(SysConfig.UploadFilePathRoutesImg);
            foreach (ClassLibrary.Model.Routes model in routeList)
            {
                string fileName = model.Image.Split(',')[0];
                if (!File.Exists(fileFullPath + fileName)) continue;
                //缩图
                Bitmap tmp = new Bitmap(fileFullPath + fileName);
                Bitmap bmp0 = Function.MakeThumNail(tmp, 100, 64);
                tmp.Dispose();
                //bmp0.Save(fileFullPath + fileName);
                string ext = Path.GetExtension(fileName);
                string appfileName = Function.GetRandomTime() + ext;
                Function.SaveBitmapImg(bmp0, fileFullPath + appfileName, ((long)90));
                bmp0.Dispose();

                routeBll.Updates("appImg = '" + appfileName + "'", "id = " + model.ID);
            }
            Print(context, "success");
        }
        
        private void DeleteNews(HttpContext context)
        {
            string id = context.Request.QueryString["ids"];
            ClassLibrary.BLL.News rbll = new ClassLibrary.BLL.News();

            if (rbll.Deletes("id in (" + id + ")") > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }
        private void RefreshLinks(HttpContext context)
        {
            ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
            ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
            ClassLibrary.BLL.RouteDetails rdBll = new ClassLibrary.BLL.RouteDetails();
            ClassLibrary.BLL.InternalLink linkBll = new ClassLibrary.BLL.InternalLink();
            List<ClassLibrary.Model.InternalLink> linkList = linkBll.GetModelList(string.Empty);

            List<ClassLibrary.Model.News> newsList = newsBll.GetModelList("");
            foreach (ClassLibrary.Model.News model in newsList)
            {
                string tmpContent = ClassLibrary.BLL.WebClass.addInternelLink(model.Content, ClassLibrary.Common.SysConfig.linkCount, linkList);
                if (model.Content != tmpContent)
                {
                    model.Content = tmpContent;
                    newsBll.Update(model);
                }
            }

            List<ClassLibrary.Model.Routes> routeList = routeBll.GetModelList("");
            foreach (ClassLibrary.Model.Routes model in routeList)
            {
                model.RouteFeature = ClassLibrary.BLL.WebClass.addInternelLink(model.RouteFeature, 1, linkList);
                model.DescriptionRoute = ClassLibrary.BLL.WebClass.addInternelLink(model.DescriptionRoute, 3, linkList);
                model.DescriptionPrice = ClassLibrary.BLL.WebClass.addInternelLink(model.DescriptionPrice, 1, linkList);
                model.RouteNotice = ClassLibrary.BLL.WebClass.addInternelLink(model.RouteNotice, 1, linkList);
                routeBll.Update(model);
                if (model.DetailType)
                {
                    List<ClassLibrary.Model.RouteDetails> rdList = rdBll.GetModelList("routeid=" + model.ID);
                    foreach (ClassLibrary.Model.RouteDetails model2 in rdList)
                    {
                        string tmpDetail = ClassLibrary.BLL.WebClass.addInternelLink(model2.DayDetail, 1, linkList);
                        if (model2.DayDetail != tmpDetail)
                        {
                            model2.DayDetail = tmpDetail;
                            rdBll.Update(model2);
                        }
                    }
                }
            }

            Print(context, "success");
        }
        private void HiddenNews(HttpContext context)
        {
            string id = context.Request.QueryString["ids"];
            ClassLibrary.BLL.News rbll = new ClassLibrary.BLL.News();

            if (rbll.Updates("IsDisplay = 0", "id in (" + id + ")") > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void DisplayNews(HttpContext context)
        {
            string id = context.Request.QueryString["ids"];
            ClassLibrary.BLL.News rbll = new ClassLibrary.BLL.News();

            if (rbll.Updates("IsDisplay = 1", "id in (" + id + ")") > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }
        private void UpdateOrderDetailPrice(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            string orderno = context.Request.QueryString["no"];
            string price = context.Request.QueryString["price"];
            ClassLibrary.BLL.OrderDetail odBLL = new ClassLibrary.BLL.OrderDetail();
            ClassLibrary.BLL.Orders oBLL = new ClassLibrary.BLL.Orders();

            if (odBLL.Updates("RoutePrice = " + price, "id = " + id) > 0)
            {
                string set = string.Format("proTotalPrice = (select SUM(RoutePrice) from OrderDetail where orderNumber = '{0}')", orderno);
                oBLL.Updates(set, "OrderNumber = " + orderno);
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }
        private void GetCity(HttpContext context)
        {
            string ids = context.Request.QueryString["ids"];

            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
            DataTable myTable = routeClassBLL.GetData("parentid in (" + ids + ")", "parentid");

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in myTable.Rows)
            {
                sb.AppendFormat("<input name='ScenicCheckBox' onclick='LocationChange(this)'  type='checkbox' value='{0}' />{1}&nbsp;&nbsp;", dr["ID"].ToString(), dr["ClassName"].ToString());
            }

            /*if (sb.ToString() == "")
            {
                myTable = routeClassBLL.GetData("id in (" + ids + ")", "parentid");
                foreach (DataRow dr in myTable.Rows)
                {
                    sb.AppendFormat("<input name='ScenicCheckBox' type='checkbox' value='{0}' />{1}&nbsp;&nbsp;", dr["ID"].ToString(), dr["ClassName"].ToString());
                }
            }*/

            Print(context, sb.ToString());
        }
        private void UpdateProvince(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            StringBuilder sb = new StringBuilder("");

            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();

            int classlevel = 3;
            if (Int32.Parse(id) == 3)  //三峡
            {
                classlevel = 2;
            }
            List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetSubList(Int32.Parse(id), "ClassLevel = " + classlevel,"classOrder Asc");

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                sb.AppendFormat("<input name='ProvinceCheckBox' onclick='ProvinceChange(this)' type='checkbox' value='{0}' />{1}&nbsp;&nbsp;", model.ID, model.ClassName);
            }

            Print(context, sb.ToString());

        }
        private void HiddenRoutes(HttpContext context)
        {
            string id = context.Request.QueryString["ids"];
            ClassLibrary.BLL.Routes rbll = new ClassLibrary.BLL.Routes();

            if (rbll.Updates("IsDisplay = 0", "id in (" + id + ")") > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void DisplayRoutes(HttpContext context)
        {
            string id = context.Request.QueryString["ids"];
            ClassLibrary.BLL.Routes rbll = new ClassLibrary.BLL.Routes();

            if (rbll.Updates("IsDisplay = 1", "id in (" + id + ")") > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }
        
        private void NewsDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            string img = context.Request.QueryString["img"];

            ClassLibrary.BLL.News newsBLL = new ClassLibrary.BLL.News();

            if (newsBLL.Delete(int.Parse(id)) > 0)
            {
                if (!string.IsNullOrEmpty(img))
                {
                    ClassLibrary.Common.Function.DeleteFile(context.Server.MapPath(ClassLibrary.Common.SysConfig.UploadFilePathNewsImg) + img);
                }

                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void NewsClassDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.NewsClass newsClassBLL = new ClassLibrary.BLL.NewsClass();

            if (newsClassBLL.Delete(int.Parse(id)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void RouteClassDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.Routes routeBll = new ClassLibrary.BLL.Routes();
            if (routeBll.GetModelList("CHARINDEX('," + int.Parse(id) + ",',','+routesPrentClassID+',')>0").Count > 0)
            {
                Print(context, "existdata");
                return;
            }
            ClassLibrary.BLL.News newsBll = new ClassLibrary.BLL.News();
            if (newsBll.GetModelList("CHARINDEX('," + int.Parse(id) + ",',','+routeClassID+',')>0").Count > 0)
            {
                Print(context, "existdata");
                return;
            }
            ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();

            if (routeClassBLL.Delete(int.Parse(id)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void InternalLinkDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.InternalLink linksBLL = new ClassLibrary.BLL.InternalLink();

            if (linksBLL.Delete(int.Parse(id)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void LinksDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.Links linksBLL = new ClassLibrary.BLL.Links();

            if (linksBLL.Delete(int.Parse(id)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void RouteDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();

            if (routeBLL.Delete(int.Parse(id)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void UpdateRouteOrder(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            string routeOrder = context.Request.QueryString["routeOrder"];

            ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();

            if (routeBLL.UpdateRouteOrder(int.Parse(id), int.Parse(routeOrder)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void UpdateRoutePrice(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            string routePrice = context.Request.QueryString["routePrice"];

            ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();

            if (routeBLL.UpdateRoutePrice(int.Parse(id), decimal.Parse(routePrice)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void RouteCommentDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.RouteComment routeCommentBLL = new ClassLibrary.BLL.RouteComment();

            if (routeCommentBLL.Delete(int.Parse(id)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void OrdersDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.Orders ordersBLL = new ClassLibrary.BLL.Orders();
            ClassLibrary.BLL.OrderDetail orderDetailBLL = new ClassLibrary.BLL.OrderDetail();

            if (ordersBLL.Deletes(" OrderNumber='"+id+"'") > 0)
            {
                if (orderDetailBLL.Deletes(" orderNumber='" + id + "'") > 0)
                    Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void AdminDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.Admin adminBLL = new ClassLibrary.BLL.Admin();

            if (adminBLL.Delete(int.Parse(id)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void MemberDelete(HttpContext context)
        {
            string id = context.Request.QueryString["id"];

            ClassLibrary.BLL.Member memberBLL = new ClassLibrary.BLL.Member();

            if (memberBLL.Delete(int.Parse(id)) > 0)
            {
                Print(context, "success");
            }
            else
            {
                Print(context, "errors");
            }
        }

        private void AdDelete(HttpContext context)
        {
            ClassLibrary.BLL.Advertise adBLL = new ClassLibrary.BLL.Advertise();

            string advertiseID = context.Request.QueryString["id"];
            string img = context.Request.QueryString["img"];

            if (adBLL.Delete(Convert.ToInt32(advertiseID)) > 0)
            {
                ClassLibrary.Common.Function.DeleteFile(context.Server.MapPath(ClassLibrary.Common.SysConfig.UploadFilePathAdImg + img));

                Print(context, "success");
            }
            else
            {
                Print(context, "error");
            }
        }

        private void ScrollImageDelete(HttpContext context)
        {
            ClassLibrary.BLL.ScrollImages bll = new ClassLibrary.BLL.ScrollImages();

            string strid = context.Request.QueryString["id"];
            string img = context.Request.QueryString["img"];

            if (bll.Delete(Convert.ToInt32(strid)) > 0)
            {
                ClassLibrary.Common.Function.DeleteFile(context.Server.MapPath(ClassLibrary.Common.SysConfig.UploadFilePathScrollImg + img));

                Print(context, "success");
            }
            else
            {
                Print(context, "error");
            }

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
