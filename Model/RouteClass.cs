/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月16日 17:43:22 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [RouteClass] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class RouteClass
    {
        #region 定义变量
        
        private int _id = 0;
        private int _parentid = 0;
        private string _classname = "";
        private DateTime _createdtime = DateTime.Now;
        public bool Recommend = false;
        private string _classNamePY = "";
        private string _classimg = "";
        public bool IsHaidao = false;
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
        /// ParentID
        /// </summary>
        public int ParentID
        {
            set{ _parentid = value; }
            get{ return _parentid; }
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
        /// ClassNamePY
        /// </summary>
        public string ClassNamePY
        {
            set { _classNamePY = value; }
            get { return _classNamePY; }
        }
        /// <summary>
        /// SeoTitle
        /// </summary>		
        private string _seotitle = "";
        public string SeoTitle
        {
            get { return _seotitle; }
            set { _seotitle = value; }
        }
        /// <summary>
        /// SeoKeyword
        /// </summary>		
        private string _seokeyword = "";
        public string SeoKeyword
        {
            get { return _seokeyword; }
            set { _seokeyword = value; }
        }
        /// <summary>
        /// SeoDesc
        /// </summary>		
        private string _seodesc = "";
        public string SeoDesc
        {
            get { return _seodesc; }
            set { _seodesc = value; }
        }
        /// <summary>
        /// ClassLevel
        /// </summary>		
        private int _classlevel;
        public int ClassLevel
        {
            get { return _classlevel; }
            set { _classlevel = value; }
        }
        /// <summary>
        /// ClassOrder
        /// </summary>		
        private int _classorder = 999;
        public int ClassOrder
        {
            get { return _classorder; }
            set { _classorder = value; }
        }
        /// <summary>
        /// ClassImg
        /// </summary>
        public string ClassImg
        {
            get { return _classimg; }
            set { _classimg = value; }
        }
        /// <summary>
        /// RouteClass默认构造函数
        /// </summary>
        public RouteClass()
        {
        }
        
        /// <summary>
        /// RouteClass构造函数
        /// </summary>
        public RouteClass(int id, int parentid, string classname, DateTime createdtime)
        {
        	
        	_id = id;
        	_parentid = parentid;
        	_classname = classname;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
