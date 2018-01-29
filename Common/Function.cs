using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Collections;

namespace ClassLibrary.Common
{
    public class Function
    {
        /// <summary> 
        /// 缩放图像
        /// </summary> 
        /// <param name="originalImagePath">图片原始路径</param>
        /// <param name="thumNailPath">保存路径</param>
        /// <param name="width">缩放图的宽</param>
        /// <param name="height">缩放图的高</param>
        /// <param name="model">缩放模式</param>
        public static Bitmap MakeThumNail(System.Drawing.Bitmap bmp, int width, int height)
        {

            int thumWidth = width;      //缩略图的宽度
            int thumHeight = height;    //缩略图的高度
            int x = 0;
            int y = 0;
            int originalWidth = bmp.Width;    //原始图片的宽度
            int originalHeight = bmp.Height;  //原始图片的高度

            //新建一个bmp图片
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(thumWidth, thumHeight);
            //新建一个画板
            System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量查值法
            graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量，低速度呈现平滑程度
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            graphic.Clear(System.Drawing.Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分
            graphic.DrawImage(bmp, new System.Drawing.Rectangle(0, 0, thumWidth, thumHeight), new System.Drawing.Rectangle(x, y, originalWidth, originalHeight), System.Drawing.GraphicsUnit.Pixel);

            graphic.Dispose();

            return bitmap;
        }

        public static void SaveBitmapImg(Bitmap bitmap, string path, long quality)
        {
            //设置 原图片 对象的 EncoderParameters 对象 
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            System.Drawing.Imaging.ImageCodecInfo ImgCodeInfo = null;
            System.Drawing.Imaging.ImageCodecInfo[] CodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            foreach (System.Drawing.Imaging.ImageCodecInfo ici in CodecInfo)
            { if (ici.MimeType == "image/jpeg") { ImgCodeInfo = ici; } }

            bitmap.Save(path, ImgCodeInfo, parameters);
        }

        public static string UpdateImgTagForMip(string content)
        {
            string rule = "<img[^>]+?></img>";
            string rule2 = "<img[^>]+?/>";
            string rule3 = "<img[^>]+?>";
            if (content.IndexOf("<img") > -1)
            {
                Match match = Regex.Match(content, rule);
                while (true)
                {
                    if (match.ToString() == "") break;
                    string tmpImg = match.ToString();
                    tmpImg = tmpImg.Replace("<img", "<mip-img layout='responsive'").Replace("</img>", "</mip-img>");
                    content = content.Replace(match.ToString(), tmpImg);
                    match = match.NextMatch();
                }
                match = Regex.Match(content, rule2);
                while (true)
                {
                    if (match.ToString() == "") break;
                    string tmpImg = match.ToString();
                    tmpImg = tmpImg.Replace("<img", "<mip-img layout='responsive'").Replace("/>", "></mip-img>");
                    content = content.Replace(match.ToString(), tmpImg);
                    match = match.NextMatch();
                }
                match = Regex.Match(content, rule3);
                while (true)
                {
                    if (match.ToString() == "") break;
                    string tmpImg = match.ToString();
                    tmpImg = tmpImg.Replace("<img", "<mip-img layout='responsive'").Replace(">", "></mip-img>");
                    content = content.Replace(match.ToString(), tmpImg);
                    match = match.NextMatch();
                }
            }
            return content;
        }
        public static string UpdateStyleForMip(string content)
        {
            string rule = "style=\"[^>]+?\"";
            if (content.IndexOf("style") > 0)
            {
                Match match = Regex.Match(content, rule);
                while (true)
                {
                    if (match.ToString() == "") break;
                    content = content.Replace(match.ToString(), "");
                    match = match.NextMatch();
                }
            }
            return content;
        }
        public static string AddTargetForMip(string content)
        {
            string rule = "<a [^>]+?>";
            if (content.IndexOf("<a ") > 0)
            {
                Match match = Regex.Match(content, rule);
                while (true)
                {
                    if (match.ToString() == "") break;
                    if (match.ToString().IndexOf("target") == -1)
                    {
                        string tmpA = match.ToString();
                        tmpA = tmpA.Replace("<a ", "<a target='_blank' ");
                        content = content.Replace(match.ToString(), tmpA);
                    }
                    match = match.NextMatch();
                }
            }
            return content;
        }
        public static string GetQueryString(string para)
        {
            string queryString = "";
            if (HttpContext.Current.Request.QueryString[para] != null)
            {
                queryString = HttpContext.Current.Request.QueryString[para].ToString();
                queryString = queryString.Replace(" ", "").Replace("'", "").Replace("--", "");
                queryString = HttpUtility.HtmlEncode(queryString);
            }
            else
            {
                queryString = "";
            }
            return queryString.Trim();
        }
        public static string GetFormString(string para)
        {
            string formString = "";
            if (HttpContext.Current.Request.Form[para] != null)
            {
                formString = HttpContext.Current.Request.Form[para].ToString();
                formString = formString.Trim().Replace("'", "").Replace("--", "");
                formString = HttpUtility.HtmlEncode(formString);
            }
            else
            {
                formString = "";
            }
            return formString.Trim();
        }
        public static bool IsInTagA(string content, string title)
        {
            return Regex.IsMatch(content, "<a[^>]+?>.*?" + title + ".*?</a>");
        }

        public static string ClearImg(string str)
        {
            Regex reg = new Regex(@"<img[^>]+?>");
            return reg.Replace(str, "");
        }

        public static bool IsInTagImg(string content, string title)
        {
            return Regex.IsMatch(content, "<img[^>]+?" + title + "+[^>]+?>");
        }

        public static int getTagACount(string content)
        {
            string tc = content.ToLower();
            int count = 0;
            while (tc.Contains("</a>"))
            {
                count++;
                tc = tc.Substring(tc.IndexOf("</a>") + 4);
            }
            return count;
        }

        public static bool IsNumber(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            Regex reg = new Regex(@"^-?\d{1,10}$");
            if (!reg.IsMatch(str))
                return false;
            return true;
        }
        public static bool IsNumberStr(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            Regex reg = new Regex(@"^\d+$");
            if (!reg.IsMatch(str))
                return false;
            return true;
        }
        public static bool IsChinese(string str)
        {
            return Regex.IsMatch(str, "^[\u4e00-\u9fa5]+$");
        }
        public static bool IsDecimal(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            Regex reg = new Regex(@"^-?\d{1,10}(\.\d{1,2})?$");
            if (!reg.IsMatch(str))
                return false;
            return true;
        }
        public static bool IsDecimal(string str,int lenInt,int lenDecimal)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            string regStr = string.Format(@"^-?\d{1,{0}}(\.\d{1,{1}})?$", lenInt, lenDecimal);
            Regex reg = new Regex(regStr);
            if (!reg.IsMatch(str))
                return false;
            return true;
        }
        public static bool IsDateTime(string str)
        {
            return Regex.IsMatch(str, @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
        }

        public static bool IsEmail(string str)
        {
            return Regex.IsMatch(str, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        public static bool IsNull(string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;

            return false;
        }

        public static string ToSortTime(DateTime dTime)
        {
            return dTime.ToString("yyyy-MM-dd");
        }

        public static string MD5(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();
        }

        public static string GetGUID()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToLower();
        }

        public static string GetRandomTime()
        {
            return DateTime.Now.ToString("yyMMddHHmmss") + GetRandomNum(4);
        }

        public static string GetOrderNumber()
        {
            string time = DateTime.Now.ToString("yyMMddHHssmm");
            string random = GetRandom(4);
            return time + random;
        }

        public static string GetRandom(int len)
        {
            string strLabel = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int num = 0;
            Random random = new Random();

            string strRandom = string.Empty;

            for (int i = 0; i < len; i++)
            {
                num = random.Next(0, strLabel.Length);
                strRandom += strLabel[num];
            }

            return strRandom;
        }
        public static string GetRandomNum(int len)
        {
            string strLabel = "1234567890";

            int num = 0;
            Random random = new Random();

            string strRandom = string.Empty;

            for (int i = 0; i < len; i++)
            {
                num = random.Next(0, strLabel.Length);
                strRandom += strLabel[num];
            }

            return strRandom;
        }
        public static string ClearHtml(string str)
        {
            Regex reg = new Regex(@"<[^>]+?>");
            return reg.Replace(str, "").Replace("\r\n", "").Replace("&nbsp;", "").Replace("　", "").Replace(" ", "");
        }

        public static string TextareaToHtml(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Replace(" ", "&nbsp;&nbsp;").Replace("\r\n", "<br />").Replace("\n", "<br />");
        }

        public static string ClearTextareaFormat(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Replace(" ", "").Replace("\r\n", "").Replace("\n", "");
        }

        public static string ClearSQLInject(string str)
        {
            Regex reg = new Regex(@"|'|-|");
            return reg.Replace(str, "");
        }

        public static string Clip(string str, int len)
        {
            return (Clip(str, len, false));
        }

        public static string Clip(string str, int len, bool ellipsis)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            if (str.Length <= len)
                return str;
            if (ellipsis)
                return str.Substring(0, len) + "...";
            else
                return str.Substring(0, len);
        }

        public static string CutString(string inputString, int len)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (mybyte.Length > len)
                tempString += "…";

            return tempString;
        }

        public static string GetEMailEntryURL(string EmailAddress)
        {
            Dictionary<string, string> mailList = new Dictionary<string, string>();
            mailList.Add("@126.com", "http://126.com");
            mailList.Add("@163.com", "http://mail.163.com");
            mailList.Add("@yeah.net", "http://www.yeah.net");
            mailList.Add("@188.com", "http://www.188.com");
            mailList.Add("@sina.com", "http://mail.sina.com");
            mailList.Add("@sina.cn", "http://mail.sina.com.cn/cnmail");
            mailList.Add("@sohu.com", "http://mail.sohu.com");
            mailList.Add("@tom.com", "http://mail.tom.com");
            mailList.Add("@gmail.com", "http://gmail.google.com");
            mailList.Add("@hotmail.com", "http://www.hotmail.com");
            mailList.Add("@139.com", "http://mail.10086.cn");
            mailList.Add("@qq.com", "http://mail.qq.com");
            mailList.Add("@21cn.com", "http://mail.21cn.com");
            mailList.Add("@yahoo.com.cn", "http://mail.cn.yahoo.com");
            mailList.Add("@yahoo.cn", "http://mail.cn.yahoo.com");
            mailList.Add("@foxmail.com", "http://www.foxmail.com");
            mailList.Add("@189.cn", "http://www.189.cn");
            mailList.Add("@263.net", "http://www.263.net");
            mailList.Add("@eyou.com", "http://www.eyou.com");
            mailList.Add("@wo.com.cn", "http://mail.wo.com.cn");

            string result = string.Empty;

            foreach (KeyValuePair<string, string> pair in mailList)
            {
                if (EmailAddress.EndsWith(pair.Key))
                {
                    result = pair.Value;
                    break;
                }
            }

            return result;
        }

		public static string GetFirstDomain()
        {
            Regex reg = new Regex(@"[a-z0-9\-]+(\.com\.cn|\.net\.cn|\.com.hk|\.com|\.net|\.cn)");

            return reg.Match(HttpContext.Current.Request.Url.DnsSafeHost).Value;
        }

        public static string GetAppSettings(string key)
        {
            if (ConfigurationManager.AppSettings[key] == null)
            {
                return string.Empty;
            }
            return ConfigurationManager.AppSettings[key];
        }

        public static int GetIntAppSettings(string key)
        {
            return Convert.ToInt32(GetAppSettings(key));
        }

        public static bool IsPostMethod()
        {
            string met = HttpContext.Current.Request.ServerVariables["Request_Method"];
            if (met == "POST")
            {
                return true;
            }
            return false;
        }

        public static bool IsLocalURL()
        {
            string met = HttpContext.Current.Request.ServerVariables["Request_Method"];
            if (met == "POST")
            {
                if (HttpContext.Current.Request.UrlReferrer == null)
                {
                    return true;
                }
                else
                {
                    string url = HttpContext.Current.Request.UrlReferrer.DnsSafeHost;

                    if (url.IndexOf("??") != -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }

        public static string GetIp()
        {
            string ip = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null)
                {
                    if (HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"] != null)
                    {
                        ip = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"].ToString();
                    }
                    else if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
                    {
                        ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                    }
                }
                else
                {
                    ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
            }
            else if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return ip;
        }

        public static string[] BubbleSort(string[] r)
        {
            int i, j;
            string temp;

            bool exchange;

            for (i = 0; i < r.Length; i++)
            {
                exchange = false;

                for (j = r.Length - 2; j >= i; j--)
                {
                    if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)
                    {
                        temp = r[j + 1];
                        r[j + 1] = r[j];
                        r[j] = temp;

                        exchange = true;
                    }
                }

                if (!exchange)
                {
                    break;
                }
            }
            return r;
        }

        public static string GetWeek(DateTime dtime)
        {
            string week = string.Empty;

            switch (dtime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    week = "星期一";
                    break;
                case DayOfWeek.Tuesday:
                    week = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    week = "星期三";
                    break;
                case DayOfWeek.Thursday:
                    week = "星期四";
                    break;
                case DayOfWeek.Friday:
                    week = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    week = "星期六";
                    break;
                case DayOfWeek.Sunday:
                    week = "星期日";
                    break;
            }

            return week;
        }

        public static string GetIntervalTimeTip(DateTime dtime)
        {
            string timeTip = string.Empty;

            DateTime oldTime = dtime;
            DateTime nowTime = DateTime.Now;

            TimeSpan timeSpan = nowTime - oldTime;

            int day = timeSpan.Days;
            int hours = timeSpan.Hours;
            int minutes = timeSpan.Minutes;
            int seconds = timeSpan.Seconds;

            if (day > 0 && day < 4)
            {
                timeTip = day.ToString() + "天前";
            }
            else if (day >= 4)
            {
                timeTip = oldTime.ToString("yyyy年MM月dd日");
            }
            else if (hours != 0)
            {
                timeTip = hours.ToString() + "小时前";
            }
            else if (minutes != 0)
            {
                timeTip = minutes.ToString() + "分钟前";
            }
            else if (seconds != 0)
            {
                timeTip = seconds.ToString() + "秒钟前";
            }
            else
            {
                timeTip = "1秒钟前";
            }

            return timeTip;
        }

        public static void DeleteFile(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public static void CreatedDirectory(string fullPath)
        {
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
        }

        public static void UploadFile(string controlName, string savePath, out string newFileName)
        {
            newFileName = string.Empty;

            HttpPostedFile file = HttpContext.Current.Request.Files[controlName];
            if (file.ContentLength != 0)
            {
                newFileName = Path.GetFileName(file.FileName);
                string filePath = HttpContext.Current.Server.MapPath(savePath);

                Function.CreatedDirectory(filePath);

                if (File.Exists(filePath + newFileName))
                {
                    newFileName = DateTime.Now.ToString("yyMMddHHssmm") + "_" + newFileName;
                }

                if (newFileName.Length > 50)
                {
                    newFileName = newFileName.Substring(newFileName.Length - 50);
                }

                file.SaveAs(filePath + newFileName);
            }

        }

        public static void ThumbnailImage(string oldImagePath, string newImagePath, int newWidth, int newHeight)
        {
            string originalFilename = oldImagePath;
            string strGoodFile = newImagePath;

            Image image = Image.FromFile(originalFilename);

            Size size = new Size(newWidth, newHeight);
            Image bitmap = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(bitmap);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            image.Dispose();

            bitmap.Save(strGoodFile, GetFormat(strGoodFile));

            image.Dispose();
            g.Dispose();

        }
        private static ImageFormat GetFormat(string path)
        {
            string ext = path.Substring(path.LastIndexOf(".") + 1);
            switch (ext.ToLower())
            {   
                case "jpg":
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "bmp":
                    return ImageFormat.Bmp;
                case "png":
                    return ImageFormat.Png;
                case "gif":
                    return ImageFormat.Gif;
                default:
                    return ImageFormat.Jpeg;
            }
        }

        public static void goMessagePage(string msg)
        {
            goMessagePage("", msg, "", MessageIcon.Non);
        }

        public static void goMessagePage(string title, string msg)
        {
            goMessagePage(title, msg, "", MessageIcon.Non);
        }

        public static void goMessagePage(string title, string msg,string backUrl)
        {
            goMessagePage(title, msg, backUrl, MessageIcon.Non);
        }

        public static void goMessagePage(string title, string msg, MessageIcon icon)
        {
            goMessagePage(title, msg, "", icon);
        }

        public static void goMessagePage(string title, string msg, string backUrl, MessageIcon icon)
        {            
            title = HttpUtility.UrlEncode(title);
            msg = HttpUtility.UrlEncode(HttpUtility.HtmlEncode(msg));
            backUrl = HttpUtility.UrlEncode(HttpUtility.HtmlEncode(backUrl));
            string iconStr = icon == MessageIcon.Non ? "" : icon.ToString();
            HttpContext.Current.Response.Redirect(string.Format("/WebManage/tips.aspx?result={0}&msg={1}&title={2}&url={3}", iconStr, msg, title, backUrl));
        }

        public enum MessageIcon
        {
            Warning,
            Success,
            Failure,
            Non
        }

    }


    /// <summary>
    ///DES加解密类
    /// </summary>
    public class Encryptclass
    {

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <returns>解密后的字符串</returns>
        public string Decrypt(string name, string name2, string password)
        {
            string cipher;
            char[] key = new char[8];
            if (name.Length > 8)
                name = name.Remove(8);
            name.CopyTo(0, key, 0, name.Length);

            char[] iv = new char[8];
            if (name2.Length > 8)
                name2 = name2.Remove(8);
            name2.CopyTo(0, iv, 0, name2.Length);
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            SymmetricAlgorithm serviceProvider = new DESCryptoServiceProvider();
            serviceProvider.Key = Encoding.ASCII.GetBytes(key);
            serviceProvider.IV = Encoding.ASCII.GetBytes(iv);
            byte[] contentArray = Convert.FromBase64String(password);
            MemoryStream memoryStream = new MemoryStream(contentArray);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, serviceProvider.CreateDecryptor(), CryptoStreamMode.Read);
            StreamReader streamReader = new StreamReader(cryptoStream);
            cipher = streamReader.ReadToEnd();
            streamReader.Dispose();
            cryptoStream.Dispose();
            memoryStream.Dispose();
            serviceProvider.Clear();
            return cipher;
        }

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <returns>加密后的字符串</returns>
        public string Encrypt(string name, string name2, string password)
        {
            string cipher;
            char[] key = new char[8];
            if (name.Length > 8)
                name = name.Remove(8);
            name.CopyTo(0, key, 0, name.Length);

            char[] iv = new char[8];
            if (name2.Length > 8)
                name2 = name2.Remove(8);
            name2.CopyTo(0, iv, 0, name2.Length);
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            SymmetricAlgorithm serviceProvider = new DESCryptoServiceProvider();
            serviceProvider.Key = Encoding.ASCII.GetBytes(key);
            serviceProvider.IV = Encoding.ASCII.GetBytes(iv);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, serviceProvider.CreateEncryptor(), CryptoStreamMode.Write);
            StreamWriter streamWriter = new StreamWriter(cryptoStream);
            streamWriter.Write(password);
            streamWriter.Dispose();
            cryptoStream.Dispose();
            byte[] signData = memoryStream.ToArray();
            memoryStream.Dispose();
            serviceProvider.Clear();
            cipher = Convert.ToBase64String(signData);
            return cipher;
        }

    }
}
