using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace ClassLibrary.Model
{
	 	//RouteDetails
		public class RouteDetails
	{
   		     
      	/// <summary>
		/// ID
        /// </summary>		
		private int _id;
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// RouteID
        /// </summary>		
		private int _routeid;
        public int RouteID
        {
            get{ return _routeid; }
            set{ _routeid = value; }
        }        
		/// <summary>
		/// DayOrder
        /// </summary>		
		private int _dayorder;
        public int DayOrder
        {
            get{ return _dayorder; }
            set{ _dayorder = value; }
        }        
		/// <summary>
		/// DayDetail
        /// </summary>		
        private string _daydetail = "";
        public string DayDetail
        {
            get{ return _daydetail; }
            set{ _daydetail = value; }
        }        
		/// <summary>
		/// BreakFast
        /// </summary>		
        private bool _breakfast = false;
        public bool BreakFast
        {
            get{ return _breakfast; }
            set{ _breakfast = value; }
        }        
		/// <summary>
		/// Lunch
        /// </summary>		
        private bool _lunch = false;
        public bool Lunch
        {
            get{ return _lunch; }
            set{ _lunch = value; }
        }        
		/// <summary>
		/// Dinner
        /// </summary>		
        private bool _dinner = false;
        public bool Dinner
        {
            get{ return _dinner; }
            set{ _dinner = value; }
        }        
		/// <summary>
		/// Hotel
        /// </summary>		
        private string _hotel = "";
        public string Hotel
        {
            get{ return _hotel; }
            set{ _hotel = value; }
        }        
		/// <summary>
		/// CreateTime
        /// </summary>		
        private DateTime _createtime = DateTime.Now;
        public DateTime CreateTime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }

        /// <summary>
        /// DayTitle
        /// </summary>		
        private string _dayTitle = "";
        public string DayTitle
        {
            get { return _dayTitle; }
            set { _dayTitle = value; }
        }
        private string _breakfastdesc = "";
        public string Breakfastdesc
        {
            get { return _breakfastdesc; }
            set { _breakfastdesc = value; }
        }
        private string _lunchdesc = "";
        public string Lunchdesc
        {
            get { return _lunchdesc; }
            set { _lunchdesc = value; }
        }
        private string _dinnerdesc = "";
        public string Dinnerdesc
        {
            get { return _dinnerdesc; }
            set { _dinnerdesc = value; }
        }
        private bool _titletype = false;
        public bool Titletype
        {
            get { return _titletype; }
            set { _titletype = value; }
        }
        private int _scenicnum = 0;
        public int Scenicnum
        {
            get { return _scenicnum; }
            set { _scenicnum = value; }
        }

        /// <summary>
        /// RouteDetail默认构造函数
        /// </summary>
        public RouteDetails()
        {
        }
	}
}

