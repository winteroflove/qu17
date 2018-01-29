/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月22日 16:02:58 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [OrderDetail] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class OrderDetail
    {
        #region 定义变量
        
        private int _id = 0;
        private string _ordernumber = "";
        private string _username = "";
        private int _routeid = 0;
        private string _number = "";
        private string _routename = "";
        private decimal _routeprice = 0M;
        private string _routetime = "";
        private string _starttime = "";
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
        /// orderNumber
        /// </summary>
        public string orderNumber
        {
            set{ _ordernumber = value; }
            get{ return _ordernumber; }
        }
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName
        {
            set{ _username = value; }
            get{ return _username; }
        }
        /// <summary>
        /// routeID
        /// </summary>
        public int routeID
        {
            set{ _routeid = value; }
            get{ return _routeid; }
        }
        /// <summary>
        /// Number
        /// </summary>
        public string Number
        {
            set{ _number = value; }
            get{ return _number; }
        }
        /// <summary>
        /// RouteName
        /// </summary>
        public string RouteName
        {
            set{ _routename = value; }
            get{ return _routename; }
        }
        /// <summary>
        /// RoutePrice
        /// </summary>
        public decimal RoutePrice
        {
            set{ _routeprice = value; }
            get{ return _routeprice; }
        }
        /// <summary>
        /// RouteTime
        /// </summary>
        public string RouteTime
        {
            set{ _routetime = value; }
            get{ return _routetime; }
        }
        /// <summary>
        /// StartTime
        /// </summary>
        public string StartTime
        {
            set{ _starttime = value; }
            get{ return _starttime; }
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
        /// OrderDetail默认构造函数
        /// </summary>
        public OrderDetail()
        {
        }
        
        /// <summary>
        /// OrderDetail构造函数
        /// </summary>
        public OrderDetail(int id, string ordernumber, string username, int routeid, string number, string routename, decimal routeprice, string routetime, string starttime, DateTime createdtime)
        {
        	
        	_id = id;
        	_ordernumber = ordernumber;
        	_username = username;
        	_routeid = routeid;
        	_number = number;
        	_routename = routename;
        	_routeprice = routeprice;
        	_routetime = routetime;
        	_starttime = starttime;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
