using System;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary.Common
{
    public class Pagination : PaginationAttribute
    {
        public Pagination()
        {
            prevText = "上一页";
            nextText = "下一页";
            firstText = "首页";
            lastText = "尾页";
            frontJumpText = "...";
            backJumpText = "...";

            frontBackNum = 2;
            jumpNum = 6;
        }

        public string pageForDynamic(int countRows, Int32 showRows, int curPage, params String[] URLparams)
        {
            _countRows = countRows;

            if (_countRows == 0) return "";

            if (_countRows % showRows == 0)
            {
                _countPage = _countRows / showRows;
            }
            else
            {
                _countPage = _countRows / showRows + 1;
            }

            if (HttpContext.Current.Request.QueryString["page"] != null)
            {
                bool requestPageIsNum = true;
                String curPageStr = HttpContext.Current.Request.QueryString["page"];
                foreach (Char ch in curPageStr)
                {
                    if (!char.IsNumber(ch))
                    {
                        requestPageIsNum = false;
                        break;
                    }
                }
                if (requestPageIsNum)
                {
                    _curPage = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
                    _curPage = _curPage < 1 ? 1 : _curPage;
                }
                else
                {
                    _curPage = 1;
                }
            }
            else
            {
                _curPage = 1;
            }

            if (_curPage > _countPage) _curPage = _countPage;

            int begin = (_curPage - 1) * showRows;
            int over = (_curPage * showRows) - 1;

            String paramList = String.Empty;
            String paramValue = String.Empty;
            String url = HttpContext.Current.Request.CurrentExecutionFilePath;

            foreach (String par in URLparams)
            {
                paramValue = HttpContext.Current.Request.QueryString[par];
                if (!String.IsNullOrEmpty(paramValue))
                {
                    paramValue = HttpUtility.UrlEncode(HttpUtility.UrlDecode(paramValue));

                    paramList += par + "=" + paramValue + "&";
                }
            }

            url += "?" + paramList + "page=";

            _firstURL = url + "1";
            _lastURL = url + _countPage.ToString();

            if (_curPage > 0)
                _prevURL = url + Convert.ToString(_curPage - 1);
            else
                _prevURL = firstURL;

            if (_curPage < _countPage)
                _nextURL = url + Convert.ToString(_curPage + 1);
            else
                _nextURL = lastURL;

            StringBuilder sbNumList = new StringBuilder();

            sbNumList.Append("<div class='pagination'>");

            if (!string.IsNullOrEmpty(firstText))
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", _firstURL, firstText);
            }

            if (_curPage == 1)
            {
                sbNumList.AppendFormat("<a>{0}</a>", prevText);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", _prevURL, prevText);
            }

            int startNumber = 0;
            if ((_curPage - frontBackNum) <= 1)
            {
                startNumber = 2;
            }
            else if ((_curPage + frontBackNum) >= (_countPage - 1))
            {
                startNumber = _countPage - (frontBackNum * 2 + 1);
                if (startNumber <= 2)
                {
                    startNumber = _curPage - frontBackNum;
                }
            }
            else
            {
                startNumber = _curPage - frontBackNum;
            }

            int endNumber = (startNumber + frontBackNum * 2) >= _countPage ? (_countPage - 1) : (startNumber + frontBackNum * 2);

            if (_curPage > frontBackNum + 2)
            {
                sbNumList.AppendFormat("<a href='{0}'>1</a>", firstURL);

                if (!string.IsNullOrEmpty(frontJumpText))
                {
                    int frontJumpNum = (_curPage - jumpNum) <= 1 ? 2 : (_curPage - jumpNum);
                    sbNumList.AppendFormat("<a href='{0}' title='{1}'>{2}</a>", (url + frontJumpNum), frontJumpNum, frontJumpText);
                }
            }
            else if (_curPage == 1)
            {
                sbNumList.Append("<span>1</span>");
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>1</a>", firstURL);
            }

            while (startNumber <= endNumber)
            {
                if (startNumber == _curPage)
                {
                    sbNumList.AppendFormat("<span>{0}</span>", startNumber);
                }
                else
                {
                    sbNumList.AppendFormat("<a href='{0}'>{1}</a>", (url + startNumber), startNumber);
                }
                startNumber++;
            }

            if (_countPage == 1)
            {
                sbNumList.Append(String.Empty);
            }
            else if (endNumber < _countPage - 1)
            {
                int backJumpNum = (_curPage + jumpNum) >= _countPage ? (_countPage - 1) : (_curPage + jumpNum);

                sbNumList.AppendFormat("<a href='{0}' title='{1}'>{2}</a>", (url + backJumpNum), backJumpNum, backJumpText);
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", lastURL, _countPage);
            }
            else if (_curPage == _countPage)
            {
                sbNumList.AppendFormat("<span>{0}</span>", _countPage);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", lastURL, _countPage);
            }

            if (_curPage == _countPage)
            {
                sbNumList.AppendFormat("<a>{0}</a>", nextText);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", nextURL, nextText);
            }

            if (!string.IsNullOrEmpty(lastText))
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", _lastURL, lastText);
            }

            StringBuilder gotoPageList = new StringBuilder();
            gotoPageList.Append("<select name=\"gotoPage\" id=\"gotoPage\" onchange=\"gotoPage('" + url + "')\">");
            for (int n = 1; n <= _countPage; n++)
            {
                gotoPageList.AppendFormat("<option value=\"{0}\">{0}/{1}</option>", n, _countPage);
            }
            gotoPageList.Append("</select>");
            sbNumList.Append(gotoPageList.ToString());

            sbNumList.Append("</div>");

            _pageNumList = sbNumList.ToString();

            return this._pageNumList;

        }
        public DataTable pagination(DataTable myTable, Int32 showRows, params String[] URLparams)
        {
            _countRows = myTable.Rows.Count;

            if (_countRows == 0) return myTable;

            if (_countRows % showRows == 0)
            {
                _countPage = _countRows / showRows;
            }
            else
            {
                _countPage = _countRows / showRows + 1;
            }

            if (HttpContext.Current.Request.QueryString["page"] != null)
            {
                bool requestPageIsNum = true;
                String curPageStr = HttpContext.Current.Request.QueryString["page"];
                foreach (Char ch in curPageStr)
                {
                    if (!char.IsNumber(ch))
                    {
                        requestPageIsNum = false;
                        break;
                    }
                }
                if (requestPageIsNum)
                {
                    _curPage = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
                    _curPage = _curPage < 1 ? 1 : _curPage;
                }
                else
                {
                    _curPage = 1;
                }
            }
            else
            {
                _curPage = 1;
            }

            if (_curPage > _countPage) _curPage = _countPage;

            int begin = (_curPage - 1) * showRows;
            int over = (_curPage * showRows) - 1;

            while (myTable.Rows.Count > _countRows - begin)
            {
                myTable.Rows.RemoveAt(0);
            }
            while (myTable.Rows.Count > over - begin + 1)
            {
                myTable.Rows.RemoveAt(over - begin + 1);
            }

            String paramList = String.Empty;
            String paramValue = String.Empty;
            String url = HttpContext.Current.Request.CurrentExecutionFilePath;

            foreach (String par in URLparams)
            {
                paramValue = HttpContext.Current.Request.QueryString[par];
                if (!String.IsNullOrEmpty(paramValue))
                {
                    paramValue = HttpUtility.UrlEncode(HttpUtility.UrlDecode(paramValue));

                    paramList += par + "=" + paramValue + "&";
                }
            }

            url += "?" + paramList + "page=";

            _firstURL = url + "1";
            _lastURL = url + _countPage.ToString();

            if (_curPage > 0)
                _prevURL = url + Convert.ToString(_curPage - 1);
            else
                _prevURL = firstURL;

            if (_curPage < _countPage)
                _nextURL = url + Convert.ToString(_curPage + 1);
            else
                _nextURL = lastURL;

            StringBuilder sbNumList = new StringBuilder();

            sbNumList.Append("<div class='pagination'>");

            if (!string.IsNullOrEmpty(firstText))
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", _firstURL, firstText);
            }

            if (_curPage == 1)
            {
                sbNumList.AppendFormat("<a>{0}</a>", prevText);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", _prevURL, prevText);
            }

            int startNumber = 0;
            if ((_curPage - frontBackNum) <= 1)
            {
                startNumber = 2;
            }
            else if ((_curPage + frontBackNum) >= (_countPage - 1))
            {
                startNumber = _countPage - (frontBackNum * 2 + 1);
                if (startNumber <= 2)
                {
                    startNumber = _curPage - frontBackNum;
                }
            }
            else
            {
                startNumber = _curPage - frontBackNum;
            }

            int endNumber = (startNumber + frontBackNum * 2) >= _countPage ? (_countPage - 1) : (startNumber + frontBackNum * 2);

            if (_curPage > frontBackNum + 2)
            {
                sbNumList.AppendFormat("<a href='{0}'>1</a>", firstURL);

                if (!string.IsNullOrEmpty(frontJumpText))
                {
                    int frontJumpNum = (_curPage - jumpNum) <= 1 ? 2 : (_curPage - jumpNum);
                    sbNumList.AppendFormat("<a href='{0}' title='{1}'>{2}</a>", (url + frontJumpNum), frontJumpNum, frontJumpText);
                }
            }
            else if (_curPage == 1)
            {
                sbNumList.Append("<span>1</span>");
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>1</a>", firstURL);
            }

            while (startNumber <= endNumber)
            {
                if (startNumber == _curPage)
                {
                    sbNumList.AppendFormat("<span>{0}</span>", startNumber);
                }
                else
                {
                    sbNumList.AppendFormat("<a href='{0}'>{1}</a>", (url + startNumber), startNumber);
                }
                startNumber++;
            }

            if (_countPage == 1)
            {
                sbNumList.Append(String.Empty);
            }
            else if (endNumber < _countPage - 1)
            {
                int backJumpNum = (_curPage + jumpNum) >= _countPage ? (_countPage - 1) : (_curPage + jumpNum);

                sbNumList.AppendFormat("<a href='{0}' title='{1}'>{2}</a>", (url + backJumpNum), backJumpNum, backJumpText);
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", lastURL, _countPage);
            }
            else if (_curPage == _countPage)
            {
                sbNumList.AppendFormat("<span>{0}</span>", _countPage);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", lastURL, _countPage);
            }

            if (_curPage == _countPage)
            {
                sbNumList.AppendFormat("<a>{0}</a>", nextText);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", nextURL, nextText);
            }

            if (!string.IsNullOrEmpty(lastText))
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", _lastURL, lastText);
            }

            StringBuilder gotoPageList = new StringBuilder();
            gotoPageList.Append("<select name=\"gotoPage\" id=\"gotoPage\" onchange=\"gotoPage('" + url + "')\">");
            for (int n = 1; n <= _countPage; n++)
            {
                gotoPageList.AppendFormat("<option value=\"{0}\">{0}/{1}</option>", n, _countPage);
            }
            gotoPageList.Append("</select>");
            sbNumList.Append(gotoPageList.ToString());

            sbNumList.Append("</div>");

            _pageNumList = sbNumList.ToString();

            return myTable;

        }

        public string pagination4(Int32 countRows, Int32 showRows, Int32 curPage, String URLparams)
        {
            _countRows = countRows;

            if (_countRows == 0) return string.Empty;

            if (_countRows % showRows == 0)
            {
                _countPage = _countRows / showRows;
            }
            else
            {
                _countPage = _countRows / showRows + 1;
            }

            _curPage = curPage;

            if (_curPage > _countPage) _curPage = _countPage;

            String paramList = String.Empty;
            String paramValue = String.Empty;
            String url = URLparams;

            _firstURL = url;
            if (_countPage == 1)
            {
                _lastURL = url;
            }
            else
            {
                _lastURL = url + "page" + _countPage.ToString();
            }

            //_firstURL = url + "1";

            url += "page";

            if (_curPage > 2)
                _prevURL = url + Convert.ToString(_curPage - 1);
            else
                _prevURL = firstURL;

            if (_curPage < _countPage)
                _nextURL = url + Convert.ToString(_curPage + 1);
            else
                _nextURL = lastURL;

            StringBuilder sbNumList = new StringBuilder();

            sbNumList.Append("<div class='pageinfo'>");

            if (!string.IsNullOrEmpty(firstText))
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", _firstURL, firstText);
            }

            if (_curPage == 1)
            {
                sbNumList.AppendFormat("<a class='provpage'><i></i>{0}</a>", prevText);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}' class='provpage'><i></i>{1}</a>", _prevURL, prevText);
            }

            int startNumber = 0;
            if ((_curPage - frontBackNum) <= 1)
            {
                startNumber = 2;
            }
            else if ((_curPage + frontBackNum) >= (_countPage - 1))
            {
                startNumber = _countPage - (frontBackNum * 2 + 1);
                if (startNumber <= 2)
                {
                    startNumber = _curPage - frontBackNum;
                }
            }
            else
            {
                startNumber = _curPage - frontBackNum;
            }

            int endNumber = (startNumber + frontBackNum * 2) >= _countPage ? (_countPage - 1) : (startNumber + frontBackNum * 2);

            if (_curPage > frontBackNum + 2)
            {
                sbNumList.AppendFormat("<a href='{0}'>1</a>", firstURL);

                if (!string.IsNullOrEmpty(frontJumpText))
                {
                    int frontJumpNum = (_curPage - jumpNum) <= 1 ? 2 : (_curPage - jumpNum);
                    sbNumList.AppendFormat("<a href='{0}' title='{1}'>{2}</a>", (url + frontJumpNum), frontJumpNum, frontJumpText);
                }
            }
            else if (_curPage == 1)
            {
                sbNumList.Append("<a class='on'>1</a>");
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>1</a>", firstURL);
            }

            while (startNumber <= endNumber)
            {
                if (startNumber == _curPage)
                {
                    sbNumList.AppendFormat("<a class='on'>{0}</a>", startNumber);
                }
                else
                {
                    sbNumList.AppendFormat("<a href='{0}'>{1}</a>", (url + startNumber), startNumber);
                }
                startNumber++;
            }

            if (_countPage == 1)
            {
                sbNumList.Append(String.Empty);
            }
            else if (endNumber < _countPage - 1)
            {
                int backJumpNum = (_curPage + jumpNum) >= _countPage ? (_countPage - 1) : (_curPage + jumpNum);

                sbNumList.AppendFormat("<a href='{0}' title='{1}'>{2}</a>", (url + backJumpNum), backJumpNum, backJumpText);
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", lastURL, _countPage);
            }
            else if (_curPage == _countPage)
            {
                sbNumList.AppendFormat("<a class='on'>{0}</a>", _countPage);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", lastURL, _countPage);
            }

            if (_curPage == _countPage)
            {
                sbNumList.AppendFormat("<a class='nextpage'>{0}<i></i></a>", nextText);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}' class='nextpage'>{1}<i></i></a>", nextURL, nextText);
            }

            if (!string.IsNullOrEmpty(lastText))
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", _lastURL, lastText);
            }

            if (_countPage > 7)
            {
                sbNumList.Append("<span>跳转到</span>");
                sbNumList.Append("<div class='morepage'>");
                sbNumList.AppendFormat("<div class='firstpage'>1/{0}</div>", _countPage);
                sbNumList.Append("<ul class='morepagelist'>");
                for (int k = 2; k <= _countPage; k++)
                {
                    sbNumList.AppendFormat("<li><a href='{0}'>{1}/{2}</a></li>", (url + k), k, _countPage);
                }
                sbNumList.Append("</ul>");
                sbNumList.Append("</div>");
            }

            sbNumList.Append("</div>");

            _pageNumList = sbNumList.ToString();

            return this.pageNumList;
        }
        //线路搜索分页
        public string pagination5(Int32 countRows, Int32 showRows, Int32 curPage, String URLparams)
        {
            _countRows = countRows;

            if (_countRows == 0) return string.Empty;

            if (_countRows % showRows == 0)
            {
                _countPage = _countRows / showRows;
            }
            else
            {
                _countPage = _countRows / showRows + 1;
            }

            _curPage = curPage;

            if (_curPage > _countPage) _curPage = _countPage;

            String paramList = String.Empty;
            String paramValue = String.Empty;
            String url = URLparams;

            _firstURL = url;
            if (_countPage == 1)
            {
                _lastURL = url;
            }
            else
            {
                _lastURL = url + "page" + _countPage.ToString();
            }

            //_firstURL = url + "1";

            url += "page";

            if (_curPage > 2)
                _prevURL = url + Convert.ToString(_curPage - 1);
            else
                _prevURL = firstURL;

            if (_curPage < _countPage)
                _nextURL = url + Convert.ToString(_curPage + 1);
            else
                _nextURL = lastURL;

            StringBuilder sbNumList = new StringBuilder();

            sbNumList.Append("<div class='pageinfo'>");

            if (!string.IsNullOrEmpty(firstText))
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", _firstURL, firstText);
            }

            if (_curPage == 1)
            {
                sbNumList.AppendFormat("<a class='provpage'><i></i>{0}</a>", prevText);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}' class='provpage'><i></i>{1}</a>", _prevURL, prevText);
            }

            int startNumber = 0;
            if ((_curPage - frontBackNum) <= 1)
            {
                startNumber = 2;
            }
            else if ((_curPage + frontBackNum) >= (_countPage - 1))
            {
                startNumber = _countPage - (frontBackNum * 2 + 1);
                if (startNumber <= 2)
                {
                    startNumber = _curPage - frontBackNum;
                }
            }
            else
            {
                startNumber = _curPage - frontBackNum;
            }

            int endNumber = (startNumber + frontBackNum * 2) >= _countPage ? (_countPage - 1) : (startNumber + frontBackNum * 2);

            if (_curPage > frontBackNum + 2)
            {
                sbNumList.AppendFormat("<a href='{0}'>1</a>", firstURL);

                if (!string.IsNullOrEmpty(frontJumpText))
                {
                    int frontJumpNum = (_curPage - jumpNum) <= 1 ? 2 : (_curPage - jumpNum);
                    sbNumList.AppendFormat("<a href='{0}' title='{1}'>{2}</a>", (url + frontJumpNum), frontJumpNum, frontJumpText);
                }
            }
            else if (_curPage == 1)
            {
                sbNumList.Append("<a class='on'>1</a>");
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>1</a>", firstURL);
            }

            while (startNumber <= endNumber)
            {
                if (startNumber == _curPage)
                {
                    sbNumList.AppendFormat("<a class='on'>{0}</a>", startNumber);
                }
                else
                {
                    sbNumList.AppendFormat("<a href='{0}'>{1}</a>", (url + startNumber), startNumber);
                }
                startNumber++;
            }

            if (_countPage == 1)
            {
                sbNumList.Append(String.Empty);
            }
            else if (endNumber < _countPage - 1)
            {
                int backJumpNum = (_curPage + jumpNum) >= _countPage ? (_countPage - 1) : (_curPage + jumpNum);

                sbNumList.AppendFormat("<a href='{0}' title='{1}'>{2}</a>", (url + backJumpNum), backJumpNum, backJumpText);
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", lastURL, _countPage);
            }
            else if (_curPage == _countPage)
            {
                sbNumList.AppendFormat("<a class='on'>{0}</a>", _countPage);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", lastURL, _countPage);
            }

            if (_curPage == _countPage)
            {
                sbNumList.AppendFormat("<a class='nextpage'>{0}<i></i></a>", nextText);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}' class='nextpage'>{1}<i></i></a>", nextURL, nextText);
            }

            if (!string.IsNullOrEmpty(lastText))
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", _lastURL, lastText);
            }
            sbNumList.Append("</div>");

            _pageNumList = sbNumList.ToString();

            return this.pageNumList;
        }
        public string paginationMip(Int32 countRows, Int32 showRows, Int32 curPage, String URLparams)
        {
            _countRows = countRows;

            if (_countRows == 0) return string.Empty;

            if (_countRows % showRows == 0)
            {
                _countPage = _countRows / showRows;
            }
            else
            {
                _countPage = _countRows / showRows + 1;
            }

            _curPage = curPage;

            if (_curPage > _countPage) _curPage = _countPage;
             
            if (_countPage < 2)
            {
                return string.Empty;
            }
            String url = URLparams;

            _firstURL = url;
            if (_countPage == 1)
            {
                _lastURL = url;
            }
            else
            {
                _lastURL = url + "page" + _countPage.ToString();
            }
            
            url += "page";

            if (_curPage > 2)
                _prevURL = url + Convert.ToString(_curPage - 1);
            else
                _prevURL = firstURL;

            if (_curPage < _countPage)
                _nextURL = url + Convert.ToString(_curPage + 1);
            else
                _nextURL = lastURL;

            StringBuilder sbNumList = new StringBuilder();

            sbNumList.Append("<div class='pageinfo'>");

            if (_curPage != 1)
            {
                sbNumList.AppendFormat("<span><a href='{0}' target='_blank'>{1}</a></span>", _prevURL, prevText);
            }
            sbNumList.AppendFormat("<span>第{0}页</span>", _curPage);
            if (_curPage != _countPage)
            {
                sbNumList.AppendFormat("<span><a href='{0}' target='_blank'>{1}</a></span>", _nextURL, nextText);
            }

            sbNumList.Append("</div>");

            _pageNumList = sbNumList.ToString();

            return this.pageNumList;
        }
        public String pagination(Int32 countRows, Int32 showRows, params String[] URLparams)
        {
            _countRows = countRows;

            if (_countRows == 0) return string.Empty;

            if (_countRows % showRows == 0)
            {
                _countPage = _countRows / showRows;
            }
            else
            {
                _countPage = _countRows / showRows + 1;
            }

            if (HttpContext.Current.Request.QueryString["page"] != null)
            {
                bool requestPageIsNum = true;
                String curPageStr = HttpContext.Current.Request.QueryString["page"];
                foreach (Char ch in curPageStr)
                {
                    if (!char.IsNumber(ch))
                    {
                        requestPageIsNum = false;
                        break;
                    }
                }
                if (requestPageIsNum)
                {
                    _curPage = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
                    _curPage = _curPage < 1 ? 1 : _curPage;
                }
                else
                {
                    _curPage = 1;
                }
            }
            else
            {
                _curPage = 1;
            }

            if (_curPage > _countPage) _curPage = _countPage;


            String paramList = String.Empty;
            String paramValue = String.Empty;
            String url = HttpContext.Current.Request.CurrentExecutionFilePath;

            foreach (String par in URLparams)
            {
                paramValue = HttpContext.Current.Request.QueryString[par];
                if (!String.IsNullOrEmpty(paramValue))
                {
                    paramValue = HttpUtility.UrlEncode(HttpUtility.UrlDecode(paramValue));

                    paramList += par + "=" + paramValue + "&";
                }
            }

            url += "?" + paramList + "page=";

            _firstURL = url + "1";
            _lastURL = url + _countPage.ToString();

            if (_curPage > 0)
                _prevURL = url + Convert.ToString(_curPage - 1);
            else
                _prevURL = firstURL;

            if (_curPage < _countPage)
                _nextURL = url + Convert.ToString(_curPage + 1);
            else
                _nextURL = lastURL;

            StringBuilder sbNumList = new StringBuilder();

            sbNumList.Append("<div class='pagination'>");

            if (_curPage == 1)
            {
                sbNumList.AppendFormat("<a>{0}</a>", prevText);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", _prevURL, prevText);
            }

            int startNumber = 0;
            if ((_curPage - frontBackNum) <= 1)
            {
                startNumber = 2;
            }
            else if ((_curPage + frontBackNum) >= (_countPage - 1))
            {
                startNumber = _countPage - (frontBackNum * 2 + 1);
                if (startNumber <= 2)
                {
                    startNumber = _curPage - frontBackNum;
                }
            }
            else
            {
                startNumber = _curPage - frontBackNum;
            }

            int endNumber = (startNumber + frontBackNum * 2) >= _countPage ? (_countPage - 1) : (startNumber + frontBackNum * 2);

            if (_curPage > frontBackNum + 2)
            {
                int frontJumpNum = (_curPage - jumpNum) <= 1 ? 2 : (_curPage - jumpNum);
                sbNumList.AppendFormat("<a href='{0}'>1</a>", firstURL);
                sbNumList.AppendFormat("<a href='{0}' title='{1}'>{2}</a>", (url + frontJumpNum), frontJumpNum, frontJumpText);
            }
            else if (_curPage == 1)
            {
                sbNumList.Append("<span>1</span>");
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>1</a>", firstURL);
            }

            while (startNumber <= endNumber)
            {
                if (startNumber == _curPage)
                {
                    sbNumList.AppendFormat("<span>{0}</span>", startNumber);
                }
                else
                {
                    sbNumList.AppendFormat("<a href='{0}'>{1}</a>", (url + startNumber), startNumber);
                }
                startNumber++;
            }

            if (_countPage == 1)
            {
                sbNumList.Append(String.Empty);
            }
            else if (endNumber < _countPage - 1)
            {
                int backJumpNum = (_curPage + jumpNum) >= _countPage ? (_countPage - 1) : (_curPage + jumpNum);

                sbNumList.AppendFormat("<a href='{0}' title='{1}'>{2}</a>", (url + backJumpNum), backJumpNum, backJumpText);
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", lastURL, _countPage);
            }
            else if (_curPage == _countPage)
            {
                sbNumList.AppendFormat("<span>{0}</span>", _countPage);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", lastURL, _countPage);
            }

            if (_curPage == _countPage)
            {
                sbNumList.AppendFormat("<a>{0}</a>", nextText);
            }
            else
            {
                sbNumList.AppendFormat("<a href='{0}'>{1}</a>", nextURL, nextText);
            }

            sbNumList.Append("</div>");

            _pageNumList = sbNumList.ToString();

            return this.pageNumList;
        }

    }

    public class PaginationAttribute
    {
        public string prevText;
        public string nextText;
        public string firstText;
        public string lastText;
        public string frontJumpText;
        public string backJumpText;

        protected string _prevURL = null;
        protected string _nextURL = null;
        protected string _firstURL = null;
        protected string _lastURL = null;
        protected string _pageNumList = null;

        protected int _curPage;
        protected int _countPage;
        protected int _countRows;

        private int _frontBackNum;
        private int _jumpNum;

        public string nextURL
        {
            get { return _nextURL; }
        }
        public string firstURL
        {
            get { return _firstURL; }
        }
        public string lastURL
        {
            get { return _lastURL; }
        }
        public string pageNumList
        {
            get { return _pageNumList; }
        }
        public int frontBackNum
        {
            get { return _frontBackNum; }
            set
            {
                if (value > 0)
                    _frontBackNum = value;
                else
                    _frontBackNum = 0;
            }
        }
        public int jumpNum
        {
            get { return _jumpNum; }
            set { _jumpNum = value; }
        }
    }


}