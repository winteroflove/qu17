/*----------------------------------------*/



/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [Admin] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Admin
    {
        #region 定义变量
        
        private int _id = 0;
        private string _username = "";
        private string _password = "";
        private string _pwoer = "";
        private DateTime _createtime = DateTime.Now;
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
        /// Power
        /// </summary>
        public string Power
        {
            set{ _pwoer = value; }
            get{ return _pwoer; }
        }
        /// <summary>
        /// CreatedTime
        /// </summary>
        public DateTime CreatedTime
        {
            set{ _createtime = value; }
            get{ return _createtime; }
        }
        
        /// <summary>
        /// Admin默认构造函数
        /// </summary>
        public Admin()
        {
        }
        
        /// <summary>
        /// Admin构造函数
        /// </summary>
        public Admin(int id, string username, string password, string pwoer, DateTime createtime)
        {
        	
        	_id = id;
        	_username = username;
        	_password = password;
        	_pwoer = pwoer;
        	_createtime = createtime;
        }
        #endregion
    }
}
