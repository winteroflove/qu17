using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.testinolink;
using ClassLibrary.Common;

namespace ClassLibrary.BLL
{
    public class MsgLinks
    {
        string urlx = "https://sdk2.028lk.com/sdk2/";
        string CorpID = SysConfig.msgName;
        string Pwd = SysConfig.msgPass;
        LinkWS lws = new LinkWS();
        
        public string sendMsg(string telNo, string message){
            lws.Url = urlx + "LinkWS.asmx";
            string backMsg = "";
            try
            {
                int result = lws.BatchSend(CorpID, Pwd, telNo, message, "", "");
                if (result == 0)
                {
                    backMsg = "发送成功进入审核阶段！";
                }
                else if (result == 1)
                {
                    backMsg = "直接发送成功！！";
                }
                else if (result == -1)
                {
                    backMsg = "帐号未注册！";
                }
                else if (result == -2)
                {
                    backMsg = "其他错误！";
                }
                else if (result == -3)
                {
                    backMsg = "帐号或密码错误！";
                }
                else if (result == -4)
                {
                    backMsg = "一次提交信息不能超过600个手机号码！";
                }
                else if (result == -5)
                {
                    backMsg = "企业号帐户余额不足，请先充值再提交短信息！";
                }
                else if (result == -6)
                {
                    backMsg = "定时发送时间不是有效时间格式！";
                }
                else if (result == -8)
                {
                    backMsg = "发送内容需在3到250个字之间";
                }
                else if (result == -9)
                {
                    backMsg = "发送号码为空";
                }
            }
            catch (System.Net.WebException WebExcp)
            {
                backMsg = "网络错误，无法连接到服务器！";
            }
            return backMsg;
        }
    }
}
