using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace ClassLibrary.Model
{
    //Customers
    public class Customers
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
        /// Name
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// QQ
        /// </summary>		
        private string _qq;
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }
        /// <summary>
        /// QQorder
        /// </summary>		
        private int _qqorder = 9;
        public int QQorder
        {
            get { return _qqorder; }
            set { _qqorder = value; }
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
        /// InUse
        /// </summary>		
        private bool _inuse;
        public bool InUse
        {
            get { return _inuse; }
            set { _inuse = value; }
        }
        /// <summary>
        /// QQtype
        /// </summary>		
        private int _qqtype;
        public int QQtype
        {
            get { return _qqtype; }
            set { _qqtype = value; }
        }
        /// <summary>
        /// Phone
        /// </summary>		
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
    }
}

