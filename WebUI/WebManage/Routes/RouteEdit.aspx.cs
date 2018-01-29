using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using ClassLibrary.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace WebUI.WebManage.Routes
{
    public partial class RouteEdit : System.Web.UI.Page
    {
        protected string themeList;

        protected string themeID;
        protected string routeClassList;
        protected string trafficModelList;
        protected int routeClassId;
        protected int routeParentId;
        protected string title;
        protected decimal price;
        protected decimal routeOrder;
        protected string startPosition;
        protected string destination;
        protected string routeTime;
        protected string trafficModel1;
        protected string trafficModel2;
        protected string startTime;
        protected string descriptionRoute;
        protected string descriptionPrice;
        protected string seoKeywords;
        protected string seoDescription;
        protected int routeId;
        protected int viewCount;
        protected bool detailType;
        protected bool dateType;
        protected string mainPlace;
        protected string datePrice;
        protected decimal childPrice;
        protected int advanceDays;
        protected int routePoint;
        protected string routeFeature;
        protected string routeNotice;
        protected bool isdisplay;
        protected string routeParentClassIds;
        protected string checkedClassIds;
        protected string routeSubClassList;
        protected int parentClassId;
        protected string routeDetails;
        protected bool recommendHot;
        protected string supplierName;
        protected string supplierTel;
        protected string seoTitle;
        protected string bright;
        protected string slogan1;
        protected string slogan2;
        protected string slogan3;
        protected string boatName;
        protected string locationids;
        protected string routeImage;
        protected string image;
        protected string appImage;
        protected List<ClassLibrary.Model.RouteDetails> routeList = new List<ClassLibrary.Model.RouteDetails>();

        ClassLibrary.BLL.Routes routeBLL = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
        ClassLibrary.Model.Routes myModel = new ClassLibrary.Model.Routes();
        ClassLibrary.BLL.RouteDetails routeDetailBll = new ClassLibrary.BLL.RouteDetails();
        ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    routeId = Convert.ToInt32(Request.Form["ID"]);
                    EditRoute();
                }
            }
            else
            {
                GetArgument();
                BindTrafficModel();
                BindData();
                BindTheme();
                BindRouteClass();
                BindRouteSubClass();
                BindRouteLocation();
            }
        }
        private void BindRouteLocation()
        {
            StringBuilder sb = new StringBuilder();
            int classlevel = 2;
            int maxrid = Convert.ToInt32(myModel.routesClassID.Split(',')[0]);
            if (maxrid > 2) classlevel = 1;
            List<ClassLibrary.Model.RouteClass> ltnList = routeClassBLL.GetModelList("id in (" + myModel.routesPrentClassID + ") and classLevel > " + classlevel);
            foreach (ClassLibrary.Model.RouteClass lt in ltnList)
            {
                sb.AppendFormat("<input name='locationid' type='radio' value='{0}' {1} />{2}", lt.ID, myModel.LocationID == lt.ID ? "checked='checked'" : "", lt.ClassName);
            }
            locationids = sb.ToString();
        }

        private void GetArgument()
        {
            string id = Request.QueryString["id"];

            if (Function.IsNumber(id))
            {
                routeId = Convert.ToInt32(id);
            }
            else
            {
                Function.goMessagePage("修改路线", "操作失败，参数错误!", "Routes/RouteList.aspx");
            }
        }

        private void BindTheme()
        {
            StringBuilder sb = new StringBuilder();
            DataTable myTable = rtBll.GetAllList();
            themeID = "," + themeID + ",";
            foreach (DataRow dr in myTable.Rows)
            {
                if (themeID.Contains("," + dr["ID"] + ","))
                {
                    sb.AppendFormat("<input name='ThemeID' type='checkbox' value='{0}' checked />{1}&nbsp;&nbsp;", dr["ID"].ToString(), dr["ClassName"].ToString());
                }
                else
                {
                    sb.AppendFormat("<input name='ThemeID' type='checkbox' value='{0}' />{1}&nbsp;&nbsp;", dr["ID"].ToString(), dr["ClassName"].ToString());
                }
            }

            themeList = sb.ToString();
        }

        public void BindRouteClass()
        {
            int tempLevel = 3;
            if (routeParentId == 5 || routeParentId == 3)
            {
                tempLevel = 2;
            }
            List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetSubList(routeParentId, "ClassLevel = " + tempLevel);

            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            string strClassIds = "," + routeParentClassIds + ",";

            for (int i = 0; i < list.Count; i++)
            {
                ClassLibrary.Model.RouteClass rc = list[i];
                sb2.Append(rc.ID + ",");
                if (strClassIds.Contains("," + rc.ID.ToString() + ","))
                {
                    sb.AppendFormat("<input name='ProvinceCheckBox' onclick='ProvinceChange(this)' type='checkbox' value='{0}' checked />{1}&nbsp;&nbsp;", rc.ID, rc.ClassName);
                }
                else
                {
                    sb.AppendFormat("<input name='ProvinceCheckBox' onclick='ProvinceChange(this)' type='checkbox' value='{0}' />{1}&nbsp;&nbsp;", rc.ID, rc.ClassName);
                }
            }

            routeClassList = sb.ToString();
            checkedClassIds = sb2.ToString().Substring(0, sb2.Length - 1);
        }
        public void BindRouteSubClass()
        {
            string[] classid = routeParentClassIds.Split(',');
            StringBuilder sb = new StringBuilder();

            foreach (string text in classid)
            {
                if (text != "")
                {
                    ClassLibrary.Model.RouteClass model = routeClassBLL.GetModel(Convert.ToInt32(text));
                    if (model.ClassLevel == 3 || model.ParentID == (int)ClassLibrary.Common.SysConfig.RouteClass.三峡旅游)
                    {
                        DataTable myTable = routeClassBLL.GetData("parentID=" + text);
                        foreach (DataRow dr in myTable.Rows)
                        {
                            if ((","+routeParentClassIds+",").Contains("," + dr["ID"].ToString() + ","))
                            {
                                sb.AppendFormat("<input name='ScenicCheckBox' onclick='LocationChange(this)' type='checkbox' value='{0}' checked />{1}&nbsp;&nbsp;", dr["ID"].ToString(), dr["ClassName"].ToString());
                            }
                            else
                            {
                                sb.AppendFormat("<input name='ScenicCheckBox' onclick='LocationChange(this)' type='checkbox' value='{0}' />{1}&nbsp;&nbsp;", dr["ID"].ToString(), dr["ClassName"].ToString());
                            }
                        }
                    }
                }

            }
            routeSubClassList = sb.ToString();
        }
        public void BindTrafficModel()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string temp in Enum.GetNames(typeof(SysConfig.TrafficModel)))
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>",temp.ToString(),temp.ToString());
            }

            trafficModelList = sb.ToString();
        }


        private void BindData()
        {
            myModel = routeBLL.GetModel(routeId);

            if (myModel != null)
            {
                themeID = myModel.ThemeID;
                routeClassId = Int32.Parse(myModel.routesClassID.Split(',')[1]);
                routeParentId = Int32.Parse(myModel.routesClassID.Split(',')[0]);
                trafficModel1 = myModel.TrafficModel.Substring(0, 2);
                trafficModel2 = myModel.TrafficModel.Substring(4, 2);
                title = myModel.Title;
                price = Convert.ToInt32(myModel.Price);
                routeOrder = myModel.Order;
                startPosition = myModel.StartPosition;
                routeTime = myModel.RouteTime;
                descriptionRoute = myModel.DescriptionRoute;
                descriptionPrice = myModel.DescriptionPrice;
                recommendHot = myModel.RecommendHot;
                destination = myModel.Destination;
                supplierName = myModel.Supplier;
                supplierTel = myModel.SupplierTel;
                seoTitle = myModel.SeoTitle;
                bright = myModel.Bright;
                boatName = myModel.BoatName;
                image = myModel.Image;
                appImage = myModel.AppImg;

                string[] images = myModel.Image.Split(',');
                StringBuilder sbri = new StringBuilder();
                for (int i = 0; i < images.Length; i++)
                {
                    sbri.AppendLine("<div>");
                    sbri.AppendLine("<input type='file' name='Image' onchange='CheckImgFile(this)' />");
                    sbri.AppendFormat("<img src='{0}' width='70' height='50' />", ClassLibrary.Common.SysConfig.UploadFilePathRoutesImg + images[i]);
                    sbri.AppendLine("</div>");
                }
                routeImage = sbri.ToString();
                seoKeywords = myModel.SeoKeywords;
                seoDescription = myModel.SeoDescription;
                viewCount = myModel.ViewCount;
                detailType = myModel.DetailType;
                dateType = myModel.DateType;
                datePrice = "";

                if (myModel.DatePrice != "")
                {
                    string[] tmpDatePrice = myModel.DatePrice.Split('|');
                    string cDate = DateTime.Now.ToShortDateString().ToString();
                    for (int k = 0; k < tmpDatePrice.Length; k++)
                    {
                        string tmpPrices = tmpDatePrice[k];
                        if (tmpPrices == "") continue;
                        string[] tmpPrice = tmpPrices.Split(',');
                        TimeSpan ts = DateTime.Parse(tmpPrice[0]) - DateTime.Now;
                        if (ts.TotalDays > 0)
                        {
                            datePrice += tmpPrices + "|";
                        }
                    }
                }
                childPrice = Convert.ToInt32(myModel.ChildPrice);
                advanceDays = myModel.AdvanceDays;
                routeFeature = myModel.RouteFeature;
                routeNotice = myModel.RouteNotice;
                isdisplay = myModel.Display;
                routeParentClassIds = myModel.routesPrentClassID;
                if (detailType)
                {
                    routeList = routeDetailBll.GetModelList("RouteID = '" + routeId + "' order by dayOrder");
                    StringBuilder sb = new StringBuilder();
                    for (int i = 1; i <= routeList.Count; i++)
                    {
                        ClassLibrary.Model.RouteDetails detail = routeList[i - 1];
                        sb.AppendFormat("<div class='fieldset xingcheng-by-day' id='day_{0}'>", i);
                        //sb.AppendFormat("<dl><dd><b>第{0}天：<input class='text' id='route_{0}_0' name='route_{0}_0'  style='width:300px;' value='{1}'/></b>{2}</dd></dl>", i, detail.DayTitle, (i != 1) ? ("&nbsp;<a id='remove_day" + i + "' href='#' onclick='xingcheng_remove_day();return false;' style='display:" + ((i == routeList.Count) ? "" : "none") + "'>删除第" + i + "天行程</a>") : "");

                        sb.AppendFormat("<dl><dd><b>第{0}天：<input type='radio' name='rdo_title_{0}' value='False' {1} onclick='checkTitle(this,{0})' />按标题<input class='text' id='route_{0}_0' name='route_{0}_0' value='{3}'  style='width:300px;{2}' />",
                            i, detail.Titletype ? "" : "checked='checked'", detail.Titletype ? "display:none;" : "", detail.Titletype ? "" : detail.DayTitle);
                        sb.AppendFormat("<input type='radio' name='rdo_title_{0}' value='True' {1} onclick='checkTitle(this,{0})' />按景点</b>{2}</dd></dl>",
                            i, detail.Titletype ? "checked='checked'" : "", (i != 1) ? ("&nbsp;<a id='remove_day" + i + "' href='#' onclick='xingcheng_remove_day();return false;' style='display:" + ((i == routeList.Count) ? "" : "none") + "'>删除第" + i + "天行程</a>") : "");

                        if (detail.Titletype)
                        {
                            string[] dtitle = new string[detail.Scenicnum];
                            string[] dslt = new string[detail.Scenicnum - 1];
                            string tle = detail.DayTitle;
                            dtitle[0] = tle.Substring(0,tle.IndexOf("<em"));
                            for (int m = 1; m < detail.Scenicnum; m++)
                            {
                                tle = tle.Substring(tle.IndexOf("tfc") + 3);
                                dslt[m - 1] = tle.Substring(0, tle.IndexOf("'"));
                                tle = tle.Substring(tle.IndexOf("</em>") + 5);
                                if (m == detail.Scenicnum - 1)
                                {
                                    dtitle[m] = tle;
                                }
                                else
                                {
                                    dtitle[m] = tle.Substring(0, tle.IndexOf("<em"));
                                }
                            }
                            //555<em class='tfc2'></em>444<em class='tfc3'></em>333<em class='tfc1'></em>222<em class='tfc2'></em>111<em class='tfc3'></em>900

                            sb.AppendFormat("<dl class='titleByJd' id='jd_title_{0}'><dd><input class='text' id='route_{0}_0_0' name='route_{0}_0_0' size='10' value='{1}' /></dd>", i, dtitle[0]);
                            for (int n = 1; n < detail.Scenicnum; n++)
                            {
                                sb.AppendFormat("<dd><select name='s_route_{0}_0_{1}'><option value='1' {2}>=飞机=</option><option value='2' {3}>=汽车=</option><option value='3' {4}>=轮船=</option><option value='4' {5}>=火车=</option></select>",
                                    i, n - 1, dslt[n - 1] == "1" ? "selected" : "", dslt[n - 1] == "2" ? "selected" : "", dslt[n - 1] == "3" ? "selected" : "", dslt[n - 1] == "4" ? "selected" : "");
                                sb.AppendFormat("<input class='text' id='route_{0}_0_{1}' name='route_{0}_0_{1}' size='10' value='{2}' /></dd>", i, n, dtitle[n]);
                            }
                            sb.AppendFormat("<a href='#?' onclick='xingcheng_add_jd({0});'>+添加</a><a href='#?' onclick='xingcheng_remove_jd({0});'>-减少</a>", i);
                            sb.AppendFormat("<input type='hidden' id='jd_title_sc{0}' name='jd_title_sc{0}' value='{1}' /></dl>", i, detail.Scenicnum);
                        }

                        sb.AppendFormat("<dl><dt>行程安排：</dt>");
                        sb.AppendFormat("<dd><div class='add_del_box'>");
                        sb.AppendFormat("<textarea id='route_{0}_1' name='route_{0}_1' style='width:700px;' rows='15'>{1}</textarea>", i, detail.DayDetail);
                        sb.AppendFormat("</div></dd></dl>");
                        sb.AppendFormat("<dl class='hotel'><dd>");
                        sb.AppendFormat("<div class='floatL'>早餐：<input id='route_{0}_2' name='route_{0}_2' type='checkbox' {2} /><input class='text text160' id='route_{0}_6' name='route_{0}_6' type='text' size='20' value='{1}' /></div>", i, detail.Breakfastdesc, detail.BreakFast ? "checked" : "");
                        sb.AppendFormat("<div class='floatL'>中餐：<input id='route_{0}_3' name='route_{0}_3' type='checkbox' {2} /><input class='text text160' id='route_{0}_7' name='route_{0}_7' type='text' size='20' value='{1}' /></div>", i, detail.Lunchdesc, detail.Lunch ? "checked" : "");
                        sb.AppendFormat("<div class='floatL'>晚餐：<input id='route_{0}_4' name='route_{0}_4' type='checkbox' {2} /><input class='text text160' id='route_{0}_8' name='route_{0}_8' type='text' size='20' value='{1}' /></div>", i, detail.Dinnerdesc, detail.Dinner ? "checked" : "");
                        sb.AppendFormat("</dd></dl>");
                        sb.AppendFormat("<dl><dt>住宿：<input type='text' class='text text160' id='route_{0}_5' name='route_{0}_5' value='{1}'/></dt></dl></div>", i, detail.Hotel);
                    }
                    routeDetails = sb.ToString();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendFormat("<div class='fieldset xingcheng-by-day' id='day_1'>");
                    //sb.AppendFormat("<dl><dd><b>第1天：<input class='text' id='route_1_0' name='route_1_0'  style='width:300px;' /></b></dd></dl>");

                    sb.AppendFormat("<dl><dd><b>第1天：<input type='radio' name='rdo_title_1' value='False' checked='checked' onclick='checkTitle(this,1)' />按标题<input class='text' id='route_1_0' name='route_1_0'  style='width:300px;' />");
                    sb.AppendFormat("<input type='radio' name='rdo_title_1' value='True' onclick='checkTitle(this,1)' />按景点</b></dd></dl>");
                    
                    sb.AppendFormat("<dl><dt>行程安排：</dt>");
                    sb.AppendFormat("<dd><div class='add_del_box'>");
                    sb.AppendFormat("<textarea id='route_1_1' name='route_1_1' style='width:700px;' rows='15'></textarea>");
                    sb.AppendFormat("</div></dd></dl>");
                    sb.AppendFormat("<dl class='hotel'><dd>");
                    sb.AppendFormat("<div class='floatL'>早餐：<input id='route_1_2' name='route_1_2' type='checkbox' /><input class='text text160' id='route_1_6' name='route_1_6' type='text' size='20' /></div>");
                    sb.AppendFormat("<div class='floatL'>中餐：<input id='route_1_3' name='route_1_3' type='checkbox' /><input class='text text160' id='route_1_7' name='route_1_7' type='text' size='20' /></div>");
                    sb.AppendFormat("<div class='floatL'>晚餐：<input id='route_1_4' name='route_1_4' type='checkbox' /><input class='text text160' id='route_1_8' name='route_1_8' type='text' size='20' /></div>");
                    sb.AppendFormat("</dd></dl>");
                    sb.AppendFormat("<dl><dt>住宿：<input type='text' class='text text160' id='route_1_5' name='route_1_5' /></dt></dl></div>");

                    routeDetails = sb.ToString();
                }
            }
            else
            {
                Function.goMessagePage("修改路线", "操作失败，数据不存在!", "Routes/RouteList.aspx");
            }
        }

        private void EditRoute()
        {
            decimal price = 0;
            int routeOrder = 0;
            ClassLibrary.Model.Routes routeModel = new ClassLibrary.Model.Routes();

            routeModel.ID = routeId;

            routeModel.routesPrentClassID = "";
            routeModel.Title = Request.Form["Title"];

            if (Decimal.TryParse(Request.Form["Price"], out price))
            {
                routeModel.Price = price;
            }
            else
            {
                Response.Write("<script>alert('成人价格错误！');history.back(-1);</script>");
                return;
            }
            if (Request.Form["ChildPrice"] == "")
            {
                routeModel.ChildPrice = 0;
            }
            else if (Decimal.TryParse(Request.Form["ChildPrice"], out price))
            {
                routeModel.ChildPrice = price;
            }
            else
            {
                Response.Write("<script>alert('小孩价格错误！');history.back(-1);</script>");
                return;
            }
            if (Request.Form["routeOrder"] == "")
            {
                routeModel.Order = 9999;
            }
            else if (int.TryParse(Request.Form["routeOrder"], out routeOrder))
            {
                routeModel.Order = routeOrder;
            }
            else
            {
                Response.Write("<script>alert('线路排序错误！');history.back(-1);</script>");
                return;
            }
            int advanceDay = 0;
            if (int.TryParse(Request.Form["AdvanceDays"], out advanceDay))
            {
                routeModel.AdvanceDays = advanceDay;
            }


            routeModel.ThemeID = Request.Form["ThemeID"];
            if (routeModel.ThemeID == null) routeModel.ThemeID = "";
            //routeModel.routesPrentClassID = ParentClassIDList(routeModel.routesClassID);
            routeModel.StartPosition = Request.Form["StartPosition"];
            routeModel.RouteTime = Request.Form["RouteTime"];
            routeModel.TrafficModel = Request.Form["TrafficModel1"] + "去 " + Request.Form["TrafficModel2"] + "回";
            //routeModel.DescriptionRoute = Request.Form["DescriptionRoute"];
            routeModel.DescriptionPrice = ClassLibrary.BLL.WebClass.addInternelLink(Request.Form["DescriptionPrice"], 1, null);
            routeModel.RecommendHot = Convert.ToBoolean(Request.Form["RecommendHot"]);
            routeModel.SeoKeywords = Request.Form["SeoKeywords"];
            routeModel.SeoDescription = Request.Form["SeoDescription"];
            //routeModel.RouteFeature = Request.Form["RouteFeature"];
            routeModel.RouteNotice = ClassLibrary.BLL.WebClass.addInternelLink(Request.Form["RouteNotice"], 1, null);
            routeModel.Display = Convert.ToBoolean(Request.Form["Isdisplay"]);
            routeModel.ViewCount = Convert.ToInt32(Request.Form["ViewCount"]);
            routeModel.Destination = Request.Form["Destination"];
            routeModel.Supplier = Request.Form["SupplierName"];
            routeModel.SupplierTel = Request.Form["SupplierTel"];
            routeModel.DateType = Convert.ToBoolean(Request.Form["DateType"]);
            routeModel.SeoTitle = Request.Form["SeoTitle"];
            routeModel.Bright = Request.Form["RouteBright"];
            routeModel.BoatName = Request.Form["BoatName"];
            routeModel.LocationID = Convert.ToInt32(Request.Form["locationid"]);
            if (routeModel.LocationID == 0)
            {
                Response.Write("<script>alert('请正确选择线路地址！');history.back(-1);</script>");
                return;
            }
            if (routeModel.DateType)
            {
                routeModel.DatePrice = Request.Form["DatePrice"];
            }

            routeModel.DetailType = Convert.ToBoolean(Request.Form["DetailType"]);
            if (routeModel.DetailType)
            {
                routeModel.RouteTime = Request.Form["xing_day"];
                /*for (int j = 1; j <= Int32.Parse(routeModel.RouteTime); j++)
                {
                    if (Request.Form["route_" + j + "_0"] == null)
                    {
                        Response.Write("<script>alert('请输入第 " + j + " 天标题');history.back(-1);</script>");
                        return;
                    }
                    if (Request.Form["route_" + j + "_1"] == null)
                    {
                        Response.Write("<script>alert('请输入第 " + j + " 天行程');history.back(-1);</script>");
                        return;
                    }
                }*/
                routeModel.DescriptionRoute = Request.Form["route_1_1"];
            }

            string province = Request.Form["ProvinceCheckBox"];
            if (province == null || province == "")
            {
                Response.Write("<script>alert('请选择线路目的地省市！');history.back(-1);</script>");
                return;
            }
            routeModel.routesPrentClassID = ParentClassIDList(province) + ",";

            string scenic = Request.Form["ScenicCheckBox"];
            if (scenic == null) scenic = "";

            string[] temScenics = scenic.Split(',');
            foreach (string temScenic in temScenics)
            {
                if (!routeModel.routesPrentClassID.Contains(temScenic))
                {
                    routeModel.routesPrentClassID += temScenic + ",";
                }
            }
            routeModel.routesPrentClassID = routeModel.routesPrentClassID.Substring(0, routeModel.routesPrentClassID.Length - 1);

            int routeParentID = Convert.ToInt32(Request.Form["routeParentID"]);

            if (scenic != "")
            {
                string[] scenicIds = scenic.Split(',');
                routeModel.routesClassID = routeParentID + "," + scenicIds[0];
            }
            else
            {
                string[] scenicIds = province.Split(',');
                routeModel.routesClassID = routeParentID + "," + scenicIds[0];
            }

            //string[] subRCIds = province.Split(',');

            routeModel.RouteFeature = ClassLibrary.BLL.WebClass.addInternelLink(Request.Form["RouteFeature"], 1, null);
            if (!routeModel.DetailType)
            {
                routeModel.DescriptionRoute = ClassLibrary.BLL.WebClass.addInternelLink(Request.Form["DescriptionRoute"], 1, null);
            }

            //图片
            HttpFileCollection files = Request.Files;

            int size = 0;
            string fileFullPath = Server.MapPath(SysConfig.UploadFilePathRoutesImg);
            Function.CreatedDirectory(fileFullPath);
            string oldAppImage = Request.Form["appImage_Hidden"];
            routeModel.AppImg = oldAppImage;

            if (files.Count > 0)
            {
                string[] oldImages = Request.Form["Image_Hidden"].Split(',');

                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    size = file.ContentLength;

                    if (size > 0)
                    {
                        string ext = Path.GetExtension(file.FileName);
                        string fileName = DateTime.Now.ToString("yyMMddHHmmssffff") + ext;

                        file.SaveAs(fileFullPath + fileName);
                        if (i == 0)
                        {
                            //缩图
                            Bitmap tmp = new Bitmap(fileFullPath + fileName);
                            Bitmap bmp0 = Function.MakeThumNail(tmp, 100, 64);
                            tmp.Dispose();
                            string appfileName = DateTime.Now.ToString("yyMMddHHmmssffff") + ext;
                            Function.SaveBitmapImg(bmp0, fileFullPath + appfileName, ((long)90));
                            //bmp0.Save(fileFullPath + fileName);
                            bmp0.Dispose();
                            routeModel.AppImg = appfileName;

                            if (oldAppImage != "") Function.DeleteFile(fileFullPath + oldAppImage);
                        }
                        routeModel.Image += fileName + ",";

                        if (oldImages.Length > i)
                        {
                            Function.DeleteFile(fileFullPath + oldImages[i]);
                        }
                    }
                    else //没有新图片时使用对应的旧图
                    {
                        if (oldImages.Length > i)
                        {
                            routeModel.Image += oldImages[i] + ",";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(routeModel.Image))
                {
                    routeModel.Image = routeModel.Image.Substring(0, routeModel.Image.Length - 1);
                }
            }
            else
            {
                routeModel.Image = Request.Form["Image_Hidden"];
            }
            if (routeModel.AppImg == "")
            {
                string fileName = routeModel.Image.Split(',')[0];
                //缩图
                Bitmap tmp = new Bitmap(fileFullPath + fileName);
                Bitmap bmp0 = Function.MakeThumNail(tmp, 100, 64);
                tmp.Dispose();
                string ext = Path.GetExtension(fileName);
                string appfileName = Function.GetRandomTime() + ext;
                Function.SaveBitmapImg(bmp0, fileFullPath + appfileName, ((long)90));
                bmp0.Dispose();

                routeModel.AppImg = appfileName;
            }

            //end

            if (routeBLL.Update(routeModel) > 0)
            {
                bool oldDetailType = Convert.ToBoolean(Request.Form["DetailType_Hidden"]);
                if (oldDetailType)
                {
                    //delete
                    ClassLibrary.BLL.RouteDetails routeDetailBll = new ClassLibrary.BLL.RouteDetails();

                    routeDetailBll.DeleteByRouteId(routeId);
                }
                if (routeModel.DetailType)
                {
                    //update
                    ClassLibrary.Model.RouteDetails routeDetailModel;
                    ClassLibrary.BLL.RouteDetails routeDetailBll = new ClassLibrary.BLL.RouteDetails();

                    for (int j = 1; j <= Int32.Parse(routeModel.RouteTime); j++)
                    {
                        routeDetailModel = new ClassLibrary.Model.RouteDetails();
                        routeDetailModel.RouteID = routeModel.ID;
                        routeDetailModel.DayOrder = j;
                        routeDetailModel.DayTitle = Request.Form["route_" + j + "_0"];
                        if (Convert.ToBoolean(Request.Form["rdo_title_" + j]))
                        {
                            routeDetailModel.DayTitle = Request.Form["route_" + j + "_0_0"];
                            int snum = Convert.ToInt32(Request.Form["jd_title_sc" + j]);
                            for (int k = 1; k < snum; k++)
                            {
                                routeDetailModel.DayTitle += "<em class='tfc" + Request.Form["s_route_" + j + "_0_" + (k - 1)] + "'></em>";
                                routeDetailModel.DayTitle += Request.Form["route_" + j + "_0_" + k];
                            }
                            routeDetailModel.Titletype = true;
                            routeDetailModel.Scenicnum = snum;
                        }
                        routeDetailModel.DayDetail = ClassLibrary.BLL.WebClass.addInternelLink(Request.Form["route_" + j + "_1"], 1, null);
                        routeDetailModel.Breakfastdesc = Request.Form["route_" + j + "_6"];
                        routeDetailModel.Lunchdesc = Request.Form["route_" + j + "_7"];
                        routeDetailModel.Dinnerdesc = Request.Form["route_" + j + "_8"];
                        if (Request.Form["route_" + j + "_2"] != null)
                        {
                            routeDetailModel.BreakFast = true;
                        }
                        if (Request.Form["route_" + j + "_3"] != null)
                        {
                            routeDetailModel.Lunch = true;
                        }
                        if (Request.Form["route_" + j + "_4"] != null)
                        {
                            routeDetailModel.Dinner = true;
                        }
                        routeDetailModel.Hotel = Request.Form["route_" + j + "_5"];

                        routeDetailBll.Add(routeDetailModel);
                    }
                }
                Function.goMessagePage("修改路线", "操作成功", "Routes/RouteList.aspx");
            }
            else
            {
                Function.goMessagePage("修改路线", "操作失败，请稍后再试", "Routes/RouteList.aspx");
            }
        }

        //获取当前子的所有父ID
        private string ParentClassIDList(int subClassID)
        {
            string str = string.Empty;

            List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetParentList(subClassID, string.Empty, String.Empty);

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                str += model.ID + ",";
            }

            if (!string.IsNullOrEmpty(str))
            {
                str = str.Substring(0, str.Length - 1);
            }
            else
            {
                str = subClassID.ToString();
            }

            return str;
        }
        //获取当前子的所有父ID
        private string ParentClassIDList(string subClassIDs)
        {
            string str = string.Empty;

            List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetParentList(subClassIDs, string.Empty);

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                str += model.ID + ",";
            }

            if (!string.IsNullOrEmpty(str))
            {
                str = str.Substring(0, str.Length - 1);
            }
            else
            {
                str = subClassIDs.ToString();
            }

            return str;
        }
        //获取当前子的所有子ID
        private string SubClassIDList(string subClassIDs)
        {
            string str = string.Empty;

            List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetSubList(subClassIDs, string.Empty);

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                str += model.ID + ",";
            }

            if (!string.IsNullOrEmpty(str))
            {
                str = str.Substring(0, str.Length - 1);
            }
            else
            {
                str = subClassIDs.ToString();
            }

            return str;
        }
        
    }
}
