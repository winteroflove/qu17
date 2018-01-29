using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using System.Data;
using System.Text;
using System.Collections;

namespace WebUI.WebManage.Customer
{
    public partial class CustomerList : System.Web.UI.Page
    {
        protected string customerList = "";

        ClassLibrary.BLL.Customers cBll = new ClassLibrary.BLL.Customers();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibrary.Common.UserInfo.ChekcPower();

            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "add")
                {
                    AddCustomer();
                }
            }
            else
            {
                BindCustomers();
            }
        }

        private void AddCustomer()
        {
            ClassLibrary.Model.Customers cModel = new ClassLibrary.Model.Customers();
            cModel.Name = Request.Form["CName"];
            cModel.QQ = Request.Form["QQNumber"];
            cModel.Phone = Request.Form["Phone"];
            if (Request.Form["QQorder"] != "")
            {
                cModel.QQorder = Convert.ToInt32(Request.Form["QQorder"]);
            }
            cModel.InUse = Convert.ToBoolean(Request.Form["InUse"]);
            cModel.QQtype = Convert.ToInt32(Request.Form["QQtype"]);

            if (cBll.Add(cModel) > 0)
            {
                Function.goMessagePage("添加客服", "操作成功", "Customer/CustomerList.aspx");
            }
            else
            {
                Function.goMessagePage("添加客服", "操作失败，请稍后再试", "Customer/CustomerList.aspx");
            }
        }

        private void BindCustomers()
        {
            DataTable myTable = cBll.GetList(string.Empty, "QQtype Asc");
            StringBuilder sb = new StringBuilder();
            List<ClassLibrary.Model.Customers> list = cBll.DataTableToList(myTable);

            foreach (ClassLibrary.Model.Customers model in list)
            {
                sb.AppendFormat("<tr id='tr_{0}'>", model.ID);
                sb.AppendFormat("<td align='center'>{0}</td>", "客服");
                sb.AppendFormat("<td align='center'>{0}</td>", model.Name);
                sb.AppendFormat("<td align='center'>{0}</td>", model.QQ);
                //sb.AppendFormat("<td align='center'>{0}</td>", model.QQorder);
                sb.AppendFormat("<td align='center'><input type='text' id='QQorder_{1}' value='{0}' maxlength='2' size='3'/><input type='button' class='button' value='修改' size='3' onclick='UpdateQQorder({1})' /></td>", model.QQorder, model.ID);
                sb.Append("<td align='center'>");
                sb.AppendFormat("<a href='javascript:void(0)' onclick='DisplayCustomer({0},\"{1}\")'>{2}</a>　", model.ID, model.InUse, model.InUse?"停用":"启用");
                sb.AppendFormat("<a href='CustomerEdit.aspx?id={0}'>修改</a>　", model.ID);
                sb.AppendFormat("<a href='javascript:void(0)' onclick='CustomerDelete({0})'>删除</a>", model.ID);
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            if (sb.Length == 0)
            {
                sb.Append("<tr><td colspan='5'>无</td></tr>");
            }

            customerList = sb.ToString();
        }
    }
}
