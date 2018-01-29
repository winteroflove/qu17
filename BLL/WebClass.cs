using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ClassLibrary.Common;
using System.Text.RegularExpressions;

namespace ClassLibrary.BLL
{
    public class WebClass
    {

        #region =================后台线路类型树====================

        /// <summary>
        /// 樹分類算法
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRouteTree(DataTable dt)
        {
            DataTable newTable = new DataTable();
            newTable.Columns.Add("ID");
            newTable.Columns.Add("ClassName");

            DataRow[] drs = dt.Select("ParentID='0'");

            foreach (DataRow dr in drs)
            {
                DataRow newRow = newTable.NewRow();
                int Id = Convert.ToInt32(dr["ID"].ToString());
                string className = dr["ClassName"].ToString();
                bool HasChild = dt.Select("ParentID=" + Id).Length > 0;//是否有子節點

                string blank = "└";

                if (HasChild)
                {
                    blank = "├┬";
                }
                className = blank + className;

                newRow["ID"] = Id;
                newRow["ClassName"] = className;

                newTable.Rows.Add(newRow);
                //遞歸子分類方法
                BindNode(Id, dt, blank, newTable);
            }
            return newTable;
        }

        public static DataTable GetRouteTree(DataTable dt, int parentID)
        {
            DataTable newTable = new DataTable();
            newTable.Columns.Add("ID");
            newTable.Columns.Add("ClassName");

            DataRow[] drs = dt.Select("ParentID='" + parentID + "'");

            foreach (DataRow dr in drs)
            {
                DataRow newRow = newTable.NewRow();
                int Id = Convert.ToInt32(dr["ID"].ToString());
                string className = dr["ClassName"].ToString();
                bool HasChild = dt.Select("ParentID=" + Id).Length > 0;//是否有子節點

                string blank = "└";

                if (HasChild)
                {
                    blank = "├┬";
                }
                className = blank + className;

                newRow["ID"] = Id;
                newRow["ClassName"] = className;

                newTable.Rows.Add(newRow);
                //遞歸子分類方法
                BindNode(Id, dt, blank, newTable);
            }
            return newTable;
        }

        /// <summary>
        /// 遞歸子分類
        /// </summary>
        /// <param name="departmentId">父節點ID</param>
        /// <param name="dt"></param>
        /// <param name="blank">父節點前綴</param>
        /// <param name="newTable"></param>
        private static void BindNode(int Id, DataTable dt, string blank, DataTable newTable)
        {
            DataRow[] drs = dt.Select("ParentID=" + Id);
            foreach (DataRow dr in drs)
            {
                DataRow newRow = newTable.NewRow();
                int Ids = Convert.ToInt32(dr["ID"].ToString());
                string className = dr["ClassName"].ToString();
                bool isLast = Ids == Convert.ToInt32(drs[drs.Length - 1]["ID"].ToString());
                bool HasChild = dt.Select("ParentID=" + Ids).Length > 0;

                string blank2 = GetPreFix(isLast, HasChild, blank);

                className = blank2 + className;

                newRow["ID"] = Ids;
                newRow["ClassName"] = className;

                newTable.Rows.Add(newRow);
                BindNode(Ids, dt, blank2, newTable);
            }
        }

        /// <summary>
        /// 用於樹的前綴
        /// </summary>
        /// <param name="IsLast">是否是同級節點中的最後一個</param>
        /// <param name="HasChild">本節點是否擁有子節點</param>
        /// <param name="ParentString">父節點的前綴符號</param>
        /// <returns>本节点的前缀</returns>
        private static string GetPreFix(bool isLast, bool hasChild, string parentString)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(parentString))
            {
                parentString = parentString.Remove(parentString.Length - 1).Replace("├", "│").Replace("└", "　");
                result += parentString;
            }
            if (isLast)
            {
                result += "└";
            }
            else
            {
                result += "├";
            }
            if (hasChild)
            {
                result += "┬";
            }
            else
            {
                result += "─";
            }
            return result;
        }

        #endregion


        #region ===================广告======================


        /// <summary>
        /// 图片广告html
        /// </summary>
        /// <param name="adPosition"></param>
        /// <returns></returns>
        public static string GetAdByImageList(SysConfig.AdPosition adPosition)
        {
            bool isswf = false;
            bool fileExists = false;
            string filePath = string.Empty;
            StringBuilder sb = new StringBuilder();

            ClassLibrary.BLL.Advertise adbll = new ClassLibrary.BLL.Advertise();
            List<ClassLibrary.Model.Advertise> list = adbll.GetModelList("positionID=" + (int)adPosition);

            foreach (ClassLibrary.Model.Advertise model in list)
            {
                filePath = ClassLibrary.Common.SysConfig.UploadFilePathAdImg + model.Img;
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(filePath)))
                {
                    fileExists = true;
                }
                if (filePath.LastIndexOf(".swf") > -1)
                {
                    isswf = true;
                }

                if (isswf)
                {
                    if (fileExists)
                        sb.AppendFormat("<script type='text/javascript'>swfobject('{0}');</script>", filePath);
                }
                else
                {
                    if (string.IsNullOrEmpty(model.LinkURL))
                    {
                        sb.AppendFormat("<img alt='{0}' src='{1}' />", model.Title, filePath);
                    }
                    else
                    {
                        sb.AppendFormat("<a href='{0}' title='{1}' target='_blank'><img alt='{1}' src='{2}' /></a>",
                        model.LinkURL, model.Title, filePath);
                    }
                }

            }

            return sb.ToString();
        }


        #endregion

        #region
        public static string addInternelLink(string content, int linkCount, List<ClassLibrary.Model.InternalLink> list)
        {
            if (content == null) return "";

            int len = content.Length;
            if (len > 200)
            {
                int acount = Function.getTagACount(content);
                if (acount < 3)
                {
                    int count = (linkCount + acount) > 3 ? (3 - acount) : linkCount;
                    List<ClassLibrary.Model.InternalLink> linkList = new List<ClassLibrary.Model.InternalLink>();
                    if (list != null && list.Count > 0)
                    {
                        foreach (ClassLibrary.Model.InternalLink model in list)
                        {
                            linkList.Add(model);
                        }
                    }
                    else
                    {
                        ClassLibrary.BLL.InternalLink linkBll = new ClassLibrary.BLL.InternalLink();
                        linkList = linkBll.GetModelList(string.Empty);
                    }

                    linkList = setListSortNone(linkList);
                    foreach (ClassLibrary.Model.InternalLink model in linkList)
                    {
                        if (content.Contains(model.Title) && !Function.IsInTagA(content.ToLower(), model.Title))
                        {
                            if (model.LinkURL.IndexOf("http://") == -1) model.LinkURL = "http://" + model.LinkURL;
                            if (Function.IsInTagImg(content, model.Title))
                            {
                                if (!Function.ClearImg(content).Contains(model.Title)) continue;
                                string rule = "<img[^>]+?" + model.Title + "+[^>]+?>";
                                Match match = Regex.Match(content, rule);
                                int index = 0;
                                int length = 0;
                                string temcontent = "";
                                while (true)
                                {
                                    if (match.ToString() == "")
                                    {
                                        string str1 = content.Substring(0, content.IndexOf(model.Title));
                                        string str2 = content.Substring(content.IndexOf(model.Title) + model.Title.Length);
                                        string str3 = string.Format("<a href=\"{0}\" title=\"{1}\" target=\"_blank\">{1}</a>", model.LinkURL, model.Title);
                                        content = str1 + str3 + str2;
                                        break;
                                    }
                                    else
                                    {
                                        index = match.Index;
                                        length = match.Length;
                                        if (content.Substring(0, index).Contains(model.Title))
                                        {
                                            string str1 = content.Substring(0, content.IndexOf(model.Title));
                                            string str2 = content.Substring(content.IndexOf(model.Title) + model.Title.Length);
                                            string str3 = string.Format("<a href=\"{0}\" title=\"{1}\" target=\"_blank\">{1}</a>", model.LinkURL, model.Title);
                                            content = str1 + str3 + str2;
                                            break;
                                        }
                                        temcontent += content.Substring(0, index + length);
                                        content = content.Substring(index + length);
                                        match = Regex.Match(content, rule);
                                    }
                                }
                                content = temcontent + content;
                                count--;
                            }
                            else
                            {
                                count--;
                                string str1 = content.Substring(0, content.IndexOf(model.Title));
                                string str2 = content.Substring(content.IndexOf(model.Title) + model.Title.Length);
                                string str3 = string.Format("<a href=\"{0}\" title=\"{1}\" target=\"_blank\">{1}</a>", model.LinkURL, model.Title);
                                content = str1 + str3 + str2;
                                if (count <= 0) break;
                            }
                        }
                    }
                }
            }
            return content;
        }

        public static List<ClassLibrary.Model.InternalLink> setListSortNone(List<ClassLibrary.Model.InternalLink> list)
        {
            int len = list.Count;
            int count = list.Count;
            List<ClassLibrary.Model.InternalLink> newList = new List<ClassLibrary.Model.InternalLink>();
            Random ran = new Random();
            for (int i = 0; i < count; i++)
            {
                int index = ran.Next(len);
                newList.Add(list[index]);
                len--;
                list.RemoveAt(index);
            }
            return newList;
        }

        #endregion
    }
}
