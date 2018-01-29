using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Text;
using ClassLibrary.Common;

namespace WebUI.WebManage.Advertise
{
    public partial class AdvertiseList : System.Web.UI.Page
    {
        protected string dataAdList;

        ClassLibrary.BLL.Advertise adBLL = new ClassLibrary.BLL.Advertise();
        ClassLibrary.BLL.AdPosition adPositionBLL = new ClassLibrary.BLL.AdPosition();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            binderAdList();
        }

        //广告列表
        private void binderAdList()
        {
            List<ClassLibrary.Model.Advertise> list = adBLL.GetModelList(string.Empty);

            StringBuilder sb = new StringBuilder();

            int rowIndex = 0;

            foreach (ClassLibrary.Model.Advertise model in list)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", model.ID);

                sb.AppendFormat("<td>{0}</td>", ++rowIndex);

                if (model.Img.LastIndexOf(".swf") > -1)
                {
                    sb.Append("<td><strong>FLASH</strong></td>");
                }
                else
                {
                    sb.AppendFormat("<td><img width='100' height='60' src='{0}' /></td>", SysConfig.UploadFilePathAdImg + model.Img);
                }
                sb.AppendFormat("<td>{0}</td>", model.Title);
                sb.AppendFormat("<td align='center'>{0}</td>", GetAdPosition(model.positionID));
                sb.AppendFormat("<td align='center'>{0}</td>", model.CreatedTime.ToString("yyyy-MM-dd"));

                sb.Append("<td align='center'>");
                sb.AppendFormat("<a href='AdvertiseEdit.aspx?adid={0}&position={1}'>修改</a>", model.ID, model.positionID);
                sb.AppendFormat("　<a href='javascript:void(0)' onclick='advertiseDelete({0},\"{1}\")'>删除</a>", model.ID, model.Img);
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='6'>没有相关记录</td></tr>");
            }

            dataAdList = sb.ToString();
        }

        private string GetAdPosition(int positionID)
        {
            return adPositionBLL.GetModel(positionID).Description;
        }

    }
}
