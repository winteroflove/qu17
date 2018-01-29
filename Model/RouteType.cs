using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace ClassLibrary.Model
{
    //RouteType
    public class RouteType
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// ClassName
        /// </summary>		
        private string _classname;
        public string ClassName
        {
            get { return _classname; }
            set { _classname = value; }
        }
        /// <summary>
        /// Recommend
        /// </summary>		
        private bool _recommend;
        public bool Recommend
        {
            get { return _recommend; }
            set { _recommend = value; }
        }
        /// <summary>
        /// CreatedTime
        /// </summary>		
        private DateTime _createdtime = DateTime.Now;
        public DateTime CreatedTime
        {
            get { return _createdtime; }
            set { _createdtime = value; }
        }
        /// <summary>
        /// seoTitle
        /// </summary>		
        private string _seotitle;
        public string seoTitle
        {
            get { return _seotitle; }
            set { _seotitle = value; }
        }
        /// <summary>
        /// seoKeyword
        /// </summary>		
        private string _seokeyword;
        public string seoKeyword
        {
            get { return _seokeyword; }
            set { _seokeyword = value; }
        }
        /// <summary>
        /// seoDesc
        /// </summary>		
        private string _seodesc;
        public string seoDesc
        {
            get { return _seodesc; }
            set { _seodesc = value; }
        }
        /// <summary>
        /// classNamePY
        /// </summary>		
        private string _classnamepy;
        public string classNamePY
        {
            get { return _classnamepy; }
            set { _classnamepy = value; }
        }
        /// <summary>
        /// ClassOrder
        /// </summary>		
        private int _classorder;
        public int ClassOrder
        {
            get { return _classorder; }
            set { _classorder = value; }
        }
        /// <summary>
        /// ClassImg
        /// </summary>		
        private string _classimg;
        public string ClassImg
        {
            get { return _classimg; }
            set { _classimg = value; }
        }
        /// <summary>
        /// AppClassImg
        /// </summary>		
        private string _appClassimg;
        public string AppClassImg
        {
            get { return _appClassimg; }
            set { _appClassimg = value; }
        }
    }
}

