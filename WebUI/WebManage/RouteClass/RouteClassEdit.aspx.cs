using System;
using System.Data;
using System.Text;
using ClassLibrary.Common;
using System.Web;
using System.IO;
using System.Drawing;

namespace WebUI.WebManage.RouteClass
{
    public partial class RouteClassEdit : System.Web.UI.Page
    {
        protected int maxClassID;

        protected bool recommend;
        protected string className;
        protected int parentId;
        protected int routeClassId;
        protected string routeClassList;
        protected int classLevel;
        protected string seoKeyword;
        protected string seoDesc;
        protected string classNamePinYin;
        protected string seoTitle;
        protected int classOrder;
        protected string image;
        protected bool ishaidao;

        ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            string strCid = Request.QueryString["cid"];
            if (Function.IsNumber(strCid))
            {
                maxClassID = Convert.ToInt32(strCid);
            }
            else
            {
                maxClassID = (int)SysConfig.RouteClass.国内旅游;
            }

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    routeClassId = Convert.ToInt32(Request.Form["ID"]);
                    EditRouteClass();
                }
            }
            else
            {
                GetArgument();
                BindData();
                BindRouteClass();
            }
        }

        public void BindRouteClass()
        {
            StringBuilder sb = new StringBuilder();
            if (routeClassId <= 5)
            {
                sb.Append("<option value='0'>顶层类型</option>");
            }
            else
            {

                ClassLibrary.BLL.RouteClass routeClassBLL = new ClassLibrary.BLL.RouteClass();
                DataTable myTable = ClassLibrary.BLL.WebClass.GetRouteTree(routeClassBLL.GetTableSubList(maxClassID, string.Empty));

                foreach (DataRow dr in myTable.Rows)
                {
                    sb.AppendFormat("<option value='{0}'>{1}</option>", dr["ID"].ToString(), dr["ClassName"].ToString());
                }
            }
            routeClassList = sb.ToString();
        }


        private void GetArgument()
        {
            string id = Request.QueryString["id"];

            if (Function.IsNumber(id))
            {
                routeClassId = Convert.ToInt32(id);
            }
            else
            {
                Function.goMessagePage("修改路线类型", "操作失败，参数错误!", "RouteClass/RouteClassList.aspx?cid=" + maxClassID);
            }
        }

        private void BindData()
        {

            DataTable myTable = routeClassBLL.GetData(" id =" + routeClassId);

            if (myTable.Rows.Count == 1)
            {
                routeClassId = Convert.ToInt32(myTable.Rows[0]["ID"]);
                parentId = Convert.ToInt32(myTable.Rows[0]["ParentID"]);

                className = myTable.Rows[0]["ClassName"].ToString();
                recommend = Convert.ToBoolean(myTable.Rows[0]["Recommend"]);

                classNamePinYin = myTable.Rows[0]["classNamePY"].ToString();
                seoKeyword = myTable.Rows[0]["SeoKeyword"].ToString();
                seoDesc = myTable.Rows[0]["SeoDesc"].ToString();
                classLevel = Convert.ToInt32(myTable.Rows[0]["ClassLevel"]);

                seoTitle = myTable.Rows[0]["SeoTitle"].ToString(); 
                classOrder = Convert.ToInt32(myTable.Rows[0]["ClassOrder"]);
                image = myTable.Rows[0]["ClassImg"].ToString();
                ishaidao = Convert.ToBoolean(myTable.Rows[0]["IsHaidao"]);
            }
            else
            {
                Function.goMessagePage("修改路线类型", "操作失败，数据不存在!", "RouteClass/RouteClassList.aspx?cid=" + maxClassID);
            }

        }

        private void EditRouteClass()
        {
            ClassLibrary.Model.RouteClass RouteClassModel = new ClassLibrary.Model.RouteClass();

            RouteClassModel.ID = routeClassId;
            RouteClassModel.ParentID = Convert.ToInt32(Request.Form["routeClassID"]);
            if (routeClassId == RouteClassModel.ParentID)
            {
                Response.Write("<script>alert('上级分类不能为本分类！');history.back(-1);</script>");
                return;
            }
            if (RouteClassModel.ParentID == 0)
            {
                RouteClassModel.ClassLevel = 1;
            }
            else
            {
                RouteClassModel.ClassLevel = routeClassBLL.GetModel(RouteClassModel.ParentID).ClassLevel + 1;
            }
            if (string.IsNullOrEmpty(Request.Form["ClassName"]))
            {
                Response.Write("<script>alert('请输入路线类型！');history.back(-1);</script>");
                return;
            }
            else
            {
                RouteClassModel.ClassName = Request.Form["ClassName"];
            }

            if (string.IsNullOrEmpty(Request.Form["ClassNamePinYin"]))
            {
                Response.Write("<script>alert('请输入城市拼音！');history.back(-1);</script>");
                return;
            }
            else
            {
                RouteClassModel.ClassNamePY = Request.Form["ClassNamePinYin"].Trim();
            }
            if (!string.IsNullOrEmpty(Request.Form["SeoTitle"]))
            {
                RouteClassModel.SeoTitle = Request.Form["SeoTitle"];
            }
            if (!string.IsNullOrEmpty(Request.Form["SeoKeywords"]))
            {
                RouteClassModel.SeoKeyword = Request.Form["SeoKeywords"];
            }
            if (!string.IsNullOrEmpty(Request.Form["SeoDescription"]))
            {
                RouteClassModel.SeoDesc = Request.Form["SeoDescription"];
            }
            if (!string.IsNullOrEmpty(Request.Form["classOrder"]) && Function.IsNumber(Request.Form["classOrder"]))
            {
                RouteClassModel.ClassOrder = Convert.ToInt32(Request.Form["classOrder"]);
            }
            RouteClassModel.Recommend = Convert.ToBoolean(Request.Form["Recommend"]);
            RouteClassModel.IsHaidao = Convert.ToBoolean(Request.Form["IsHaidao"]);

            //int nmaxid = Convert.ToInt32(Request.Form["maxid"]);
            //int nwidth = 61;
            //int nheight = 41;
            //if (nmaxid == (int)SysConfig.RouteClass.三峡旅游)
            //{
            //    nwidth = 50;
            //    nheight = 50;
            //}
            HttpPostedFile file = Request.Files["Image"];
            string oldImages = Request.Form["Image_Hidden"];
            if (file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                string fileName = Function.GetRandomTime() + ext;
                string fileFullPath = Server.MapPath(SysConfig.UploadFilePathClassImg);
                Function.CreatedDirectory(fileFullPath);
                file.SaveAs(fileFullPath + fileName);
                //缩图
                //Bitmap tmp = new Bitmap(fileFullPath + fileName);
                //Bitmap bmp0 = Function.MakeThumNail(tmp, nwidth, nheight);
                //tmp.Dispose();
                ////bmp0.Save(fileFullPath + fileName);
                //Function.SaveBitmapImg(bmp0, fileFullPath + fileName, ((long)100));
                //bmp0.Dispose();

                Function.DeleteFile(fileFullPath + oldImages);

                RouteClassModel.ClassImg = fileName;
            }
            else
            {
                RouteClassModel.ClassImg = oldImages;
            }


            if (routeClassBLL.Update(RouteClassModel) > 0)
            {
                Function.goMessagePage("修改路线类型", "操作成功", "RouteClass/RouteClassList.aspx?cid=" + maxClassID);
            }
            else
            {
                Function.goMessagePage("修改路线类型", "操作失败，请稍后再试", "RouteClass/RouteClassList.aspx?cid=" + maxClassID);
            }
        }
    }
}
