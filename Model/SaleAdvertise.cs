using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace ClassLibrary.Model
{
    //SaleAdvertise
    public class SaleAdvertise
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
        /// Title
        /// </summary>		
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// LinkUrl
        /// </summary>		
        private string _linkurl;
        public string LinkUrl
        {
            get { return _linkurl; }
            set { _linkurl = value; }
        }
        /// <summary>
        /// Img
        /// </summary>		
        private string _img;
        public string Img
        {
            get { return _img; }
            set { _img = value; }
        }
        /// <summary>
        /// RouteClassId
        /// </summary>		
        private string _routeclassid;
        public string RouteClassId
        {
            get { return _routeclassid; }
            set { _routeclassid = value; }
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
        /// SaleOrder
        /// </summary>		
        private int _saleorder = 999;
        public int SaleOrder
        {
            get { return _saleorder; }
            set { _saleorder = value; }
        }
        /// <summary>
        /// ExpiredTime
        /// </summary>		
        private DateTime _expiredtime = DateTime.Now;
        public DateTime ExpiredTime
        {
            get { return _expiredtime; }
            set { _expiredtime = value; }
        }

    }
}

