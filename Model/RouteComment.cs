/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月21日 14:57:06 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [RouteComment] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class RouteComment
    {
        #region 定义变量
        
        private int _id = 0;
        private string _username = "";
        private string _nickname = "";
        private bool _anonymous = false;
        private int _routeid = 0;
        private byte _grade = 0;
        private string _email = "";
        private string _content = "";
        private bool _checked = false;
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
        /// UserName
        /// </summary>
        public string UserName
        {
            set{ _username = value; }
            get{ return _username; }
        }
        /// <summary>
        /// Nickname
        /// </summary>
        public string Nickname
        {
            set{ _nickname = value; }
            get{ return _nickname; }
        }
        /// <summary>
        /// Anonymous
        /// </summary>
        public bool Anonymous
        {
            set{ _anonymous = value; }
            get{ return _anonymous; }
        }
        /// <summary>
        /// routeID
        /// </summary>
        public int routeID
        {
            set{ _routeid = value; }
            get{ return _routeid; }
        }
        /// <summary>
        /// Grade
        /// </summary>
        public byte Grade
        {
            set{ _grade = value; }
            get{ return _grade; }
        }
        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            set{ _email = value; }
            get{ return _email; }
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
        /// Checked
        /// </summary>
        public bool Checked
        {
            set{ _checked = value; }
            get{ return _checked; }
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
        /// RouteComment默认构造函数
        /// </summary>
        public RouteComment()
        {
        }
        
        /// <summary>
        /// RouteComment构造函数
        /// </summary>
        public RouteComment(int id, string username, string nickname, bool anonymous, int routeid, byte grade, string email, string content, bool checkeds, DateTime createdtime)
        {
        	
        	_id = id;
        	_username = username;
        	_nickname = nickname;
        	_anonymous = anonymous;
        	_routeid = routeid;
        	_grade = grade;
        	_email = email;
        	_content = content;
        	_checked = checkeds;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
