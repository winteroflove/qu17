using System;
using System.Collections.Generic;
using System.Web;

namespace ClassLibrary.Common
{
    public class UserInfo
    {
        String userCookieName;

        public UserInfo()
        {
            userCookieName = CookieName.MemberInfo.ToString();
        }
        public UserInfo(String CookieName)
        {
            userCookieName = HttpUtility.UrlEncode(CookieName);
        }
        public UserInfo(CookieName cookieName)
        {
            userCookieName = HttpUtility.UrlEncode(cookieName.ToString());
        }

        public string GetInfo(LoginInfo li)
        {
            return GetCookie(HttpUtility.UrlEncode(li.ToString()), userCookieName);
        }

        private string GetCookie(String cookieKey, String cookieName)
        {
            HttpCookie cook = HttpContext.Current.Request.Cookies[cookieName];

            String value = String.Empty;

            if (cook == null)
            {
                return value;
            }
            value = cook.Values[cookieKey];

            return HttpUtility.UrlDecode(value);
        }

        public Boolean IsLogin()
        {
            HttpCookie cook = HttpContext.Current.Request.Cookies[userCookieName];

            if (cook == null)
                return false;

            return true;
        }

        public void SetCookExpires(int days)
        {
            if (IsLogin())
            {
                HttpCookie cook = HttpContext.Current.Request.Cookies[userCookieName];
                cook.Expires = DateTime.Now.AddDays(days);
                HttpContext.Current.Response.Cookies.Add(cook);
            }
        }

        public void CreatedCookie(Dictionary<String, String> userInfo)
        {
            HttpCookie cook = new HttpCookie(userCookieName);

            foreach (KeyValuePair<String, String> pair in userInfo)
            {
                String key = HttpUtility.UrlEncode(pair.Key);
                String value = HttpUtility.UrlEncode(pair.Value);
                cook.Values[key] = value;
            }
            
            HttpContext.Current.Response.Cookies.Add(cook);
        }


        public void ChangeCookieValue(LoginInfo li, String value)
        {
            ChangeCookieValue(li.ToString(), value);
        }
        public void ChangeCookieValue(String key, String value)
        {
            if (IsLogin())
            {
                HttpCookie cook = HttpContext.Current.Request.Cookies[userCookieName];
                cook.Values[key] = value;
                HttpContext.Current.Response.Cookies.Add(cook);
            }
        }

        public void UserLogout()
        {
            HttpCookie cook = HttpContext.Current.Request.Cookies[userCookieName];
            ClearCookie(cook);
        }

        public void ClearCookie(HttpCookie cook)
        {
            if (cook != null)
            {
                cook.Values.Clear();
                cook.Expires = DateTime.Now.AddDays(-1024);
                HttpContext.Current.Response.Cookies.Add(cook);
            }
        }

        public static void ChekcPower()
        {
            UserInfo u = new UserInfo(CookieName.AdminInfo);
            if (!u.IsLogin())
            {
                HttpContext.Current.Response.Write("<script>alert('您还没有登录，请登录！');top.location.href='/WebManage/login.aspx'</script>");
            }
            else
            {
                string userName = u.GetInfo(LoginInfo.UserName);
                string power = u.GetInfo(LoginInfo.AdminPower);
                string url = HttpContext.Current.Request.Url.PathAndQuery.ToLower().Replace("/webmanage/", "");
                if (url.Contains("?")) url = url.Substring(0, url.IndexOf("?"));
                if (userName != "admin" && power.ToLower().IndexOf(url) == -1)
                {
                    Function.goMessagePage("没有权限，请设置权限后重新登录!");
                }
            }
        }
    }

    public enum CookieName
    {
        MemberInfo,
        AdminInfo,
        UserLanguage
    }

    public enum LoginInfo
    {
        ID,
        UserName,
        Nickname,
        AdminPower
    }
}
