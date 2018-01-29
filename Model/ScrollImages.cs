/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月20日 16:38:40 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [ScrollImages] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class ScrollImages
    {
        #region 定义变量
        
        private int _id = 0;
        private string _title = "";
        private string _img = "";
        private string _linkurl = "";
        private DateTime _createdtime = DateTime.Now;
        private bool _indexImg = false;
        private int _imgClassId = 0;
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
        /// IndexImg
        /// </summary>
        public bool IndexImg
        {
            set { _indexImg = value; }
            get { return _indexImg; }
        }

        /// <summary>
        /// ImgClassId
        /// </summary>
        public int ImgClassId
        {
            set { _imgClassId = value; }
            get { return _imgClassId; }
        }
        #endregion
    }
}
