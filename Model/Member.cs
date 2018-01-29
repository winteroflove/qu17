/*----------------------------------------*/



/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [Member] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Member
    {
        #region 定义变量
        
        private int _id = 0;
        private string _username = "";
        private string _password = "";
        private string _nickname = "";
        private string _telphone = "";
        private string _qq = "";
        private string _safetyquestion = "";
        private string _safetyanswer = "";
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
        /// Password
        /// </summary>
        public string Password
        {
            set{ _password = value; }
            get{ return _password; }
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
        /// Telphone
        /// </summary>
        public string Telphone
        {
            set{ _telphone = value; }
            get{ return _telphone; }
        }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ
        {
            set{ _qq = value; }
            get{ return _qq; }
        }
        /// <summary>
        /// SafetyQuestion
        /// </summary>
        public string SafetyQuestion
        {
            set{ _safetyquestion = value; }
            get{ return _safetyquestion; }
        }
        /// <summary>
        /// SafetyAnswer
        /// </summary>
        public string SafetyAnswer
        {
            set{ _safetyanswer = value; }
            get{ return _safetyanswer; }
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
        /// Member默认构造函数
        /// </summary>
        public Member()
        {
        }
        
        /// <summary>
        /// Member构造函数
        /// </summary>
        public Member(int id, string username, string password, string nickname, string telphone, string qq, string safetyquestion, string safetyanswer, DateTime createdtime)
        {
        	
        	_id = id;
        	_username = username;
        	_password = password;
        	_nickname = nickname;
        	_telphone = telphone;
        	_qq = qq;
        	_safetyquestion = safetyquestion;
        	_safetyanswer = safetyanswer;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
