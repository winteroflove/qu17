using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;

namespace WebUI.WebApp
{
    public partial class appShopCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Function.IsPostMethod())
            {
                if (Request.QueryString["ac"] == "order")
                {
                    SaveOrder();
                }
            }
        }
        //保存订单
        protected void SaveOrder()
        {
            string orderNumber = DateTime.Now.ToString("yyMMddHHssmmff");
            ClassLibrary.BLL.Orders orderBLL = new ClassLibrary.BLL.Orders();
            ClassLibrary.BLL.OrderDetail detailBLL = new ClassLibrary.BLL.OrderDetail();

            try
            {
                string[] products = Request.Form["productList"].Split('|');

                ClassLibrary.Model.Orders orderModel = new ClassLibrary.Model.Orders();

                orderModel.OrderNumber = orderNumber;
                orderModel.UserName = "";
                orderModel.proQuantity = Request.Form["adultnum"] + "," + Request.Form["childnum"];
                orderModel.proTotalPrice = Convert.ToDecimal(Request.Form["totalPrice"]);
                orderModel.Linkman = Request.Form["Linkman"];
                orderModel.Fax = "";
                orderModel.Mobile = Request.Form["Mobile"];
                orderModel.Telphone = Request.Form["Mobile"];
                orderModel.Email = "";
                orderModel.IdentityCard = "";
                orderModel.ContractType = Request.Form["ContractType"];
                orderModel.Payment = Request.Form["Payment"];
                orderModel.Remark = string.Empty;
                orderModel.Status = SysConfig.OrderType.未付款待处理.ToString();
                orderModel.CreatedTime = DateTime.Now;

                if (orderBLL.Add(orderModel) > 0)
                {
                    ClassLibrary.Model.OrderDetail detailModel;

                    //依次将订单详情信息插入表中
                    foreach (string pro in products)
                    {
                        if (pro == "") continue;
                        detailModel = new ClassLibrary.Model.OrderDetail();
                        detailModel.orderNumber = orderModel.OrderNumber;
                        detailModel.UserName = orderModel.UserName;
                        detailModel.routeID = Convert.ToInt32(pro.Split(',')[0]);
                        //string tempNum = pro.Split(',')[2];
                        //detailModel.Number = tempNum.Substring(0, tempNum.IndexOf("大")) + ",";
                        //tempNum = tempNum.Substring(tempNum.IndexOf("大") + 1);
                        //detailModel.Number += tempNum.Substring(0, tempNum.IndexOf("小"));
                        detailModel.Number = Request.Form["adultnum"] + "," + Request.Form["childnum"];
                        detailModel.RouteName = pro.Split(',')[1];
                        detailModel.RoutePrice = Convert.ToDecimal(Request.Form["totalPrice"]);
                        detailModel.RouteTime = pro.Split(',')[4];
                        detailModel.StartTime = pro.Split(',')[5];

                        detailBLL.Add(detailModel);
                    }

                    //扣钱
                    if (orderModel.Payment != SysConfig.Payment.支付宝.ToString())
                    {
                        Response.Redirect("/success/o" + orderModel.OrderNumber + ".html", false);
                        //Response.Redirect("/WebApp/appOrder.aspx?order=" + orderModel.OrderNumber, false);
                    }
                    else
                    {
                        //---use pay
                        string payURL = string.Format("/onlinepayment/alipay/default.aspx?order_no={0}&total_fee={1}",
                            orderModel.OrderNumber,
                            orderModel.proTotalPrice);

                        Response.Redirect(payURL, false);
                        //---
                    }

                }

                //发送短信
                ClassLibrary.BLL.MsgLinks msg = new ClassLibrary.BLL.MsgLinks();
                string customMsg = "尊敬的用户：您的订单" + orderNumber + "已提交成功，我们将尽快联系您，或拨打400-017-5761。";
                string webRoutName = products[0].Split(',')[1].Replace("【", "").Replace("】", "").Replace("[", "").Replace("]", "")
                    .Replace("(", "").Replace(")", "").Replace("（", "").Replace("）", "").Replace("...", "");
                string webMsg = "您有新订单" + orderNumber.Substring(10) + "！\n姓名：" + orderModel.Linkman + "\n电话：" + orderModel.Mobile + "\n日期：" + products[0].Split(',')[5]
                    + "\n线路：" + Function.Clip(webRoutName, 16, false) + "。";
                string backMsg = msg.sendMsg(orderModel.Mobile, customMsg);

                ClassLibrary.BLL.WebMeta bll = new ClassLibrary.BLL.WebMeta();
                ClassLibrary.Model.WebMeta webMeta = bll.GetModelList(string.Empty)[0];
                msg.sendMsg(webMeta.Telphone, webMsg);
            }
            catch (Exception ex)
            {
                //回滚数据
                orderBLL.Deletes("OrderNumber='" + orderNumber + "'");
                detailBLL.Deletes("orderNumber='" + orderNumber + "'");

                Response.Write("<script>alert('订单提交失败！');location.href='/shopcart/'</script>");
            }
        }
    }
}