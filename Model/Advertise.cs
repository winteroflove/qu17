/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年2月11日 23:41:05 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [Advertise] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Advertise
    {
        #region 定义变量
        
        private int _id = 0;
        private int _positionid = 0;
        private string _img = "";
        private string _title = "";
        private string _linkurl = "";
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
        /// positionID
        /// </summary>
        public int positionID
        {
            set{ _positionid = value; }
            get{ return _positionid; }
        }
        /// <summary>
        /// Img
        /// </summary>
        public string Img
        {
            set{ _img = value; }
            get{ return _img; }
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
        /// LinkURL
        /// </summary>
        public string LinkURL
        {
            set{ _linkurl = value; }
            get{ return _linkurl; }
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
        /// Advertise默认构造函数
        /// </summary>
        public Advertise()
        {
        }
        
        /// <summary>
        /// Advertise构造函数
        /// </summary>
        public Advertise(int id, int positionid, string img, string title, string linkurl, DateTime createdtime)
        {
        	
        	_id = id;
        	_positionid = positionid;
        	_img = img;
        	_title = title;
        	_linkurl = linkurl;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
