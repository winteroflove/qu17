/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月20日 11:58:40 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [SystemArticle] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SystemArticle
    {
        #region 定义变量
        
        private int _id = 0;
        private int _classid = 0;
        private string _title = "";
        private string _content = "";
        private DateTime _createdtime = DateTime.Now;
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
        /// classID
        /// </summary>
        public int classID
        {
            set{ _classid = value; }
            get{ return _classid; }
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
        /// SystemArticle默认构造函数
        /// </summary>
        public SystemArticle()
        {
        }
        
        /// <summary>
        /// SystemArticle构造函数
        /// </summary>
        public SystemArticle(int id, int classid, string title, string content, DateTime createdtime)
        {
        	
        	_id = id;
        	_classid = classid;
        	_title = title;
        	_content = content;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
