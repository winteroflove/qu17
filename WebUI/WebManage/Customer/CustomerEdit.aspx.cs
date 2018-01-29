using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibrary.Common;
using System.Text;

namespace WebUI.WebManage.Customer
{
    public partial class CustomerEdit : System.Web.UI.Page
    {
        protected int cid;
        protected int qqtype;

        protected ClassLibrary.Model.Customers cmodel = new ClassLibrary.Model.Customers();

        ClassLibrary.BLL.Customers cBll = new ClassLibrary.BLL.Customers();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "edit")
                {
                    cid = Convert.ToInt32(Request.Form["ID"]);
                    EditCustomer();
                }
            }
            else
            {
                GetArgument();
                BindCustomer();
            }
        }

        private void GetArgument()
        {
            string id = Request.QueryString["id"];

            if (Function.IsNumber(id))
            {
                cid = Convert.ToInt32(id);
            }
            else
            {
                Function.goMessagePage("修改客服", "操作失败，参数错误!", "Customer/CustomerList.aspx");
            }
        }

        private void EditCustomer()
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
            cModel.ID = cid;

            if (cBll.Update(cModel))
            {
                Function.goMessagePage("修改客服", "操作成功", "Customer/CustomerList.aspx");
            }
            else
            {
                Function.goMessagePage("修改客服", "操作失败，请稍后再试", "Customer/CustomerList.aspx");
            }
        }

        private void BindCustomer()
        {
            cmodel = cBll.GetModel(cid);
            qqtype = cmodel.QQtype;
        }

    }
}
