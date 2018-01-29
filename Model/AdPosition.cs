/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年2月11日 23:41:05 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [AdPosition] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class AdPosition
    {
        #region 定义变量
        
        private int _id = 0;
        private string _name = "";
        private string _description = "";
        private string _size = "";

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
        /// Name
        /// </summary>
        public string Name
        {
            set{ _name = value; }
            get{ return _name; }
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
        /// Size
        /// </summary>
        public string Size
        {
            set { _size = value; }
            get { return _size; }
        }
        
        /// <summary>
        /// AdPosition默认构造函数
        /// </summary>
        public AdPosition()
        {
        }
        
        /// <summary>
        /// AdPosition构造函数
        /// </summary>
        public AdPosition(int id, string name, string description)
        {
        	
        	_id = id;
        	_name = name;
        	_description = description;
        }
        #endregion
    }
}
