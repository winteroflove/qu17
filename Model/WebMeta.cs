/*----------------------------------------*/



/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [WebMeta] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class WebMeta
    {
        #region 定义变量
        
        private int _id = 0;
        private string _title = "";
        private string _keyword = "";
        private string _description = "";
        private string _telphone = "";
        private DateTime _createdtime = DateTime.Now;

        public string QQ = "";
		public string OnlineService = "";
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
        /// Title
        /// </summary>
        public string Title
        {
            set{ _title = value; }
            get{ return _title; }
        }
        /// <summary>
        /// Keyword
        /// </summary>
        public string Keyword
        {
            set{ _keyword = value; }
            get{ return _keyword; }
        }
        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            set{ _description = value; }
            get{ return _description; }
        }
        /// <summary>
        /// Telphone
        /// </summary>
        public string Telphone
        {
            set{ _telphone = value; }
            get{ return _telphone; }
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
        /// WebMeta默认构造函数
        /// </summary>
        public WebMeta()
        {
        }
        
        /// <summary>
        /// WebMeta构造函数
        /// </summary>
        public WebMeta(int id, string title, string keyword, string description, string telphone, DateTime createdtime)
        {
        	
        	_id = id;
        	_title = title;
        	_keyword = keyword;
        	_description = description;
        	_telphone = telphone;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
