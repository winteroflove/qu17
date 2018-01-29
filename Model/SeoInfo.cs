using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace ClassLibrary.Model
{
    //SeoInfo
    public class SeoInfo
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
        /// RouteClassID
        /// </summary>		
        private int _routeclassid = 0;
        public int RouteClassID
        {
            get { return _routeclassid; }
            set { _routeclassid = value; }
        }
        /// <summary>
        /// MaxClassId
        /// </summary>		
        private int _maxClassId = 0;
        public int MaxClassId
        {
            get { return _maxClassId; }
            set { _maxClassId = value; }
        }
        /// <summary>
        /// ThemeId
        /// </summary>		
        private int _themeid = 0;
        public int ThemeId
        {
            get { return _themeid; }
            set { _themeid = value; }
        }
        /// <summary>
        /// Price
        /// </summary>		
        private string _price;
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// Days
        /// </summary>		
        private int _days = 0;
        public int Days
        {
            get { return _days; }
            set { _days = value; }
        }
        /// <summary>
        /// SeoTitle
        /// </summary>		
        private string _seotitle;
        public string SeoTitle
        {
            get { return _seotitle; }
            set { _seotitle = value; }
        }
        /// <summary>
        /// SeoKeyword
        /// </summary>		
        private string _seokeyword;
        public string SeoKeyword
        {
            get { return _seokeyword; }
            set { _seokeyword = value; }
        }
        /// <summary>
        /// SeoDescription
        /// </summary>		
        private string _seodescription;
        public string SeoDescription
        {
            get { return _seodescription; }
            set { _seodescription = value; }
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
        /// Month
        /// </summary>		
        private int _month = 0;
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }
    }
}

