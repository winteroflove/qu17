﻿/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月20日 16:38:40 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [Links] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Links
    {
        #region 定义变量
        
        private int _id = 0;
        private string _title = "";
        private string _img = "";
        private string _linkurl = "";
        private DateTime _createdtime = DateTime.Now;
        private int _linkClass = 0;
        #endregion

        #region 声明属性
        /// <summary>
        /// LinkClass
        /// </summary>
        public int LinkClass
        {
            set { _linkClass = value; }
            get { return _linkClass; }
        }
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
        /// Img
        /// </summary>
        public string Img
        {
            set{ _img = value; }
            get{ return _img; }
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
        /// Links默认构造函数
        /// </summary>
        public Links()
        {
        }
        
        /// <summary>
        /// Links构造函数
        /// </summary>
        public Links(int id, string title, string img, string linkurl, DateTime createdtime)
        {
        	
        	_id = id;
        	_title = title;
        	_img = img;
        	_linkurl = linkurl;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
