using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using System.IO;

namespace WebUI.WebManage.Links
{
    public partial class ImportLinks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    AddLinks();
                }
            }
        }
        private void AddLinks()
        {
            if (Request.Files.Count == 0)
            {
                Response.Write("<script>alert('请选择链接文件...');history.back(-1);</script>");
                return;
            }
            HttpPostedFile file = Request.Files[0];
            int fileLen = file.ContentLength;
            if (fileLen <= 0)
            {
                Response.Write("<script>alert('链接文件为空，请重新上传！');history.back(-1);</script>");
                return;
            }
            string ext = Path.GetExtension(file.FileName);
            if (ext != ".txt")
            {
                Response.Write("<script>alert('仅支持txt链接文件，请重新上传！');history.back(-1);</script>");
                return;
            }
            byte[] input = new byte[fileLen];
            Stream str = file.InputStream;
            str.Read(input, 0, fileLen);
            str.Position = 0;
            System.IO.StreamReader sr = new System.IO.StreamReader(str, System.Text.Encoding.Default);
            string link = sr.ReadLine();
            int i = 1;
            ClassLibrary.Model.Links model = new ClassLibrary.Model.Links();
            ClassLibrary.BLL.Links bll = new ClassLibrary.BLL.Links();
            ClassLibrary.BLL.RouteClass rcBll = new ClassLibrary.BLL.RouteClass();
            List<ClassLibrary.Model.RouteClass> rcList = rcBll.GetModelList(string.Empty);
            while (link != null && link.Trim() != "")
            {
                string[] lks = link.Split('^');
                if (lks.Length != 3)
                {
                    Response.Write("<script>alert('第" + i + "行数据有问题，请检查后重新上传后面部分数据！');history.back(-1);</script>");
                    return;
                }
                model.Title = lks[0].Trim();
                model.LinkURL = lks[1].Trim();
                if (model.LinkURL.IndexOf("http://") != 0) model.LinkURL = "http://" + lks[1];
                if (Function.IsNumberStr(lks[2]))
                {
                    ClassLibrary.Model.RouteClass rc = rcList.Find(delegate(ClassLibrary.Model.RouteClass trc) { return trc.ID == Convert.ToInt32(lks[2]); });
                    if (rc == null)
                    {
                        Response.Write("<script>alert('第" + i + "行数据目的地ID无效，请检查后重新上传后面部分数据！');history.back(-1);</script>");
                        return;
                    }
                    model.LinkClass = Convert.ToInt32(lks[2]);
                }
                else
                {
                    Response.Write("<script>alert('第" + i + "行数据目的地ID出错，请检查后重新上传后面部分数据！');history.back(-1);</script>");
                    return;
                }
                if (bll.Add(model) > 0)
                {
                    link = sr.ReadLine();
                    i++;
                }
                else
                {
                    Response.Write("<script>alert('第" + i + "行数据添加出错，请检查后重新上传后面部分数据！');history.back(-1);</script>");
                    return;
                }
            }
            str.Close();
            sr.Close();
            Function.goMessagePage("批量导入友情链接", "成功导入" + (i - 1) + "个链接", "Links/LinksList.aspx");
        }
    }
}