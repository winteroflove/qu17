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
    public partial class RouteAdd : System.Web.UI.Page
    {
        protected string themeList;
        protected string routeClassList;
        protected string trafficModelList;

        ClassLibrary.BLL.Routes routesBLL = new ClassLibrary.BLL.Routes();
        ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
        ClassLibrary.BLL.RouteType rtBll = new ClassLibrary.BLL.RouteType();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    AddRoute();
                }
            }
            else
            {
                ClassLibrary.Common.UserInfo.ChekcPower();

                BindTheme();
                BindRouteClass();
                BindTrafficModel();
            }
        }
        public void BindRouteClass()
        {
            //DataTable myTable = ClassLibrary.BLL.WebClass.GetRouteTree(routeClassBLL.GetData(string.Empty));

            StringBuilder sb = new StringBuilder();

            List<ClassLibrary.Model.RouteClass> list = routeClassBLL.GetSubList(1, "ClassLevel = 3");

            foreach (ClassLibrary.Model.RouteClass model in list)
            {
                sb.AppendFormat("<input name='ProvinceCheckBox' onclick='ProvinceChange(this)' type='checkbox' value='{0}' />{1}&nbsp;&nbsp;", model.ID, model.ClassName);
            }

            routeClassList = sb.ToString();
        }
        private void BindTheme()
        {
            StringBuilder sb = new StringBuilder();
            DataTable myTable = rtBll.GetAllList();

            foreach (DataRow dr in myTable.Rows)
            {
                //sb.AppendFormat("<option value='{0}'>{1}</option>", dr["ID"].ToString(), dr["ClassName"].ToString());
                sb.AppendFormat("<input name='ThemeID' type='checkbox' value='{0}' />{1}&nbsp;&nbsp;", dr["ID"].ToString(), dr["ClassName"].ToString());
            }
            themeList = sb.ToString();
        }

        public void BindTrafficModel()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string temp in Enum.GetNames(typeof(SysConfig.TrafficModel)))
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", temp.ToString(), temp.ToString());
            }

            trafficModelList = sb.ToString();
        }

        public void AddRoute()
        {
            decimal price = 0;
            int routeOrder = 0;
            ClassLibrary.Model.Routes routeModel = new ClassLibrary.Model.Routes();

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
                routeModel.RouteTime = Request.Form["xing_day"];
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
            string[] subRCIds = province.Split(',');

            routeModel.RouteFeature = ClassLibrary.BLL.WebClass.addInternelLink(Request.Form["RouteFeature"], 1, null);
            if (!routeModel.DetailType)
            {
                routeModel.DescriptionRoute = ClassLibrary.BLL.WebClass.addInternelLink(Request.Form["DescriptionRoute"], SysConfig.linkCount, null);
            }

            routeModel.Image = string.Empty;

            //图片
            HttpFileCollection files = Request.Files;

            if (files.Count == 0)
            {
                Response.Write("<script>alert('没有检测到图片文件，至少要选择一张线路图！');history.back(-1);</script>");
                return;
            }
            /*if (files.Count == 1)
            {
                Response.Write("<script>alert('请至少要选择2张线路图！');history.back(-1);</script>");
                return;
            }*/

            int size = 0;

            string fileFullPath = Server.MapPath(SysConfig.UploadFilePathRoutesImg);
            Function.CreatedDirectory(fileFullPath);

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
                        Bitmap bmp0 = Function.MakeThumNail(tmp, 100, 64);//121*75
                        tmp.Dispose();
                        //bmp0.Save(fileFullPath + fileName);
                        string appfileName = DateTime.Now.ToString("yyMMddHHmmssffff") + ext;
                        Function.SaveBitmapImg(bmp0, fileFullPath + appfileName, ((long)90));
                        bmp0.Dispose();
                        routeModel.AppImg = appfileName;
                    }
                    routeModel.Image += fileName + ",";
                }
            }

            if (!string.IsNullOrEmpty(routeModel.Image))
            {
                routeModel.Image = routeModel.Image.Substring(0, routeModel.Image.Length - 1);
            }

            //end
  
            if (routesBLL.Add(routeModel) > 0)
            {
                routeModel.ID = routesBLL.GetLastId();
                if (routeModel.DetailType)
                {
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
                        //routeDetailModel.Lunch = Convert.ToBoolean(Request.Form["route_" + j + "_3"]);
                        //routeDetailModel.Dinner = Convert.ToBoolean(Request.Form["route_" + j + "_4"]);
                        routeDetailModel.Hotel = Request.Form["route_" + j + "_5"];

                        routeDetailBll.Add(routeDetailModel);
                    }
                }
                Function.goMessagePage("添加路线", "操作成功", "Routes/RouteList.aspx");
            }
            else
            {
                Function.goMessagePage("添加路线", "操作失败，请稍后再试", "Routes/RouteList.aspx");
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
