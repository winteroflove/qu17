/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月16日 17:43:22 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [NewsClass] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class NewsClass
    {
        #region 定义变量
        
        private int _id = 0;
        private string _classname = "";
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
        /// ClassName
        /// </summary>
        public string ClassName
        {
            set{ _classname = value; }
            get{ return _classname; }
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
        /// NewsClass默认构造函数
        /// </summary>
        public NewsClass()
        {
        }
        
        /// <summary>
        /// NewsClass构造函数
        /// </summary>
        public NewsClass(int id, string classname, DateTime createdtime)
        {
        	
        	_id = id;
        	_classname = classname;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
