/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月16日 17:43:22 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [News] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class News
    {
        #region 定义变量
        
        private int _id = 0;
        private int _newsclassid = 0;
        private string _routeclassid = "";
        private string _title = "";
        private string _editor = "";
        private string _source = "";
        private int _viewcount = 0;
        private string _image = "";
        private string _content = "";
        private DateTime _createdtime = DateTime.Now;
        private string _keywords = "";
        private string _description = "";
        private bool _display = true;
        private int _locationId = 0;
        private bool _isSanxia = false;
        private int _zancount = 0;
        private string _ntag = "";
        #endregion

        #region 声明属性
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set{ _id = value; }
            get{ return _id; }
        }
        /// <summary>
        /// newsClassID
        /// </summary>
        public int newsClassID
        {
            set{ _newsclassid = value; }
            get{ return _newsclassid; }
        }
        /// <summary>
        /// routeClassID
        /// </summary>
        public string routeClassID
        {
            set{ _routeclassid = value; }
            get{ return _routeclassid; }
        }
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            set{ _title = value; }
            get{ return _title; }
        }
        /// <summary>
        /// Editor
        /// </summary>
        public string Editor
        {
            set{ _editor = value; }
            get{ return _editor; }
        }
        /// <summary>
        /// Source
        /// </summary>
        public string Source
        {
            set{ _source = value; }
            get{ return _source; }
        }
        /// <summary>
        /// ViewCount
        /// </summary>
        public int ViewCount
        {
            set{ _viewcount = value; }
            get{ return _viewcount; }
        }
        /// <summary>
        /// Image
        /// </summary>
        public string Image
        {
            set{ _image = value; }
            get{ return _image; }
        }
        /// <summary>
        /// Content
        /// </summary>
        public string Content
        {
            set{ _content = value; }
            get{ return _content; }
        }
        /// <summary>
        /// CreatedTime
        /// </summary>
        public DateTime CreatedTime
        {
            set{ _createdtime = value; }
            get{ return _createdtime; }
        }
        /// <summary>
        /// Ntag
        /// </summary>
        public string Ntag
        {
            set { _ntag = value; }
            get { return _ntag; }
        }
        /// <summary>
        /// Keywords
        /// </summary>
        public string Keywords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// Display
        /// </summary>
        public bool Display
        {
            set { _display = value; }
            get { return _display; }
        }
        /// <summary>
        /// LocationID
        /// </summary>
        public int LocationID
        {
            set { _locationId = value; }
            get { return _locationId; }
        }
        /// <summary>
        /// IsSanxia
        /// </summary>
        public bool IsSanxia
        {
            set { _isSanxia = value; }
            get { return _isSanxia; }
        }
        /// <summary>
        /// ZanCount
        /// </summary>
        public int ZanCount
        {
            set { _zancount = value; }
            get { return _zancount; }
        }
        /// <summary>
        /// News默认构造函数
        /// </summary>
        public News()
        {
        }
        
        /// <summary>
        /// News构造函数
        /// </summary>
        public News(int id, int newsclassid, string routeclassid, string title, string editor, string source, int viewcount, string image, string content, DateTime createdtime)
        {
        	
        	_id = id;
        	_newsclassid = newsclassid;
        	_routeclassid = routeclassid;
        	_title = title;
        	_editor = editor;
        	_source = source;
        	_viewcount = viewcount;
        	_image = image;
        	_content = content;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
