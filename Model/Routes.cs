/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月20日 22:13:28 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [Routes] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Routes
    {
        #region 定义变量
        
        private int _id = 0;
        private string _routesclassid = "";
        private string _routesprentclassid = "";
        private string _title = "";
        private decimal _price = 0M;
        private int _order = 999;
        private string _image = "";
        private string _startposition = "";
        private string _destination = "";
        private string _routetime = "";
        private string _trafficmodel = "";
        private string _descriptionroute = "";
        private string _descriptionprice = "";
        private int _viewcount = 0;
        private DateTime _lastupdatetimeroute = DateTime.Now;
        private DateTime _lastupdatetimeprice = DateTime.Now;
        private bool _recommendhot = false;
        private DateTime _createdtime = DateTime.Now;
        private string _firstTime = DateTime.Now.ToString("yyyy-MM-dd");
        public string ThemeID = "";

        public string SeoKeywords = "";
        public string SeoDescription = "";
        public string SeoTitle = "";
        private bool _display = true;
        private string _routefeature = "";
        private string _routenotice = "";
        private decimal _childprice = 0M;
        private string _dateprice = "";
        private bool _datetype = false;
        private int _advancedays = 0;
        private bool _detailType = false;
        private string _supplier = "";
        private string _bright = "";
        private string _boatname = "";
        private int _locationId = 0;
        private string _supplierTel = "";
        private string _appimg = "";
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
        /// routesClassID
        /// </summary>
        public string routesClassID
        {
            set{ _routesclassid = value; }
            get{ return _routesclassid; }
        }
        /// <summary>
        /// routesPrentClassID
        /// </summary>
        public string routesPrentClassID
        {
            set{ _routesprentclassid = value; }
            get{ return _routesprentclassid; }
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
        /// Price
        /// </summary>
        public decimal Price
        {
            set{ _price = value; }
            get{ return _price; }
        }
        /// <summary>
        /// Order
        /// </summary>
        public int Order
        {
            set { _order = value; }
            get { return _order; }
        }
        /// <summary>
        /// Image
        /// </summary>
        public string Image
        {
            set{ _image = value; }
            get{ return _image; }
        }
        /// <summary>
        /// StartPosition
        /// </summary>
        public string StartPosition
        {
            set{ _startposition = value; }
            get{ return _startposition; }
        }
        /// <summary>
        /// Destination
        /// </summary>
        public string Destination
        {
            set{ _destination = value; }
            get{ return _destination; }
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
        /// TrafficModel
        /// </summary>
        public string TrafficModel
        {
            set{ _trafficmodel = value; }
            get{ return _trafficmodel; }
        }
        /// <summary>
        /// DescriptionRoute
        /// </summary>
        public string DescriptionRoute
        {
            set{ _descriptionroute = value; }
            get{ return _descriptionroute; }
        }
        /// <summary>
        /// DescriptionPrice
        /// </summary>
        public string DescriptionPrice
        {
            set{ _descriptionprice = value; }
            get{ return _descriptionprice; }
        }
        /// <summary>
        /// ViewCount
        /// </summary>
        public int ViewCount
        {
            set{ _viewcount = value; }
            get{ return _viewcount; }
        }
        /// <summary>
        /// LastUpdateTimeRoute
        /// </summary>
        public DateTime LastUpdateTimeRoute
        {
            set{ _lastupdatetimeroute = value; }
            get{ return _lastupdatetimeroute; }
        }
        /// <summary>
        /// LastUpdateTimePrice
        /// </summary>
        public DateTime LastUpdateTimePrice
        {
            set{ _lastupdatetimeprice = value; }
            get{ return _lastupdatetimeprice; }
        }
        /// <summary>
        /// RecommendHot
        /// </summary>
        public bool RecommendHot
        {
            set{ _recommendhot = value; }
            get{ return _recommendhot; }
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
        /// FirstTime
        /// </summary>
        public string FirstTime
        {
            set { _firstTime = value; }
            get { return _firstTime; }
        }
        /// <summary>
        /// Display
        /// </summary>
        public bool Display
        {
            set { _display = value; }
            get { return _display; }
        }
        public bool DetailType
        {
            set { _detailType = value; }
            get { return _detailType; }
        }
        public decimal ChildPrice
        {
            set { _childprice = value; }
            get { return _childprice; }
        }
        public string DatePrice
        {
            set { _dateprice = value; }
            get { return _dateprice; }
        }
        public bool DateType
        {
            set { _datetype = value; }
            get { return _datetype; }
        }
        public int AdvanceDays
        {
            set { _advancedays = value; }
            get { return _advancedays; }
        }
        public string RouteFeature
        {
            set { _routefeature = value; }
            get { return _routefeature; }
        }
        public string RouteNotice
        {
            set { _routenotice = value; }
            get { return _routenotice; }
        }
        public string Supplier
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
        public string SupplierTel
        {
            set { _supplierTel = value; }
            get { return _supplierTel; }
        }
        public string AppImg
        {
            set { _appimg = value; }
            get { return _appimg; }
        }
        public string Bright
        {
            set { _bright = value; }
            get { return _bright; }
        }
        public string BoatName
        {
            set { _boatname = value; }
            get { return _boatname; }
        }
        public int LocationID
        {
            set { _locationId = value; }
            get { return _locationId; }
        }
        /// <summary>
        /// Routes默认构造函数
        /// </summary>
        public Routes()
        {
        }
        
        /// <summary>
        /// Routes构造函数
        /// </summary>
        public Routes(int id, string routesclassid, string routesprentclassid, string title, decimal price, string image, string startposition, string destination, string routetime, string trafficmodel, string descriptionroute, string descriptionprice, int viewcount, DateTime lastupdatetimeroute, DateTime lastupdatetimeprice, bool recommendhot, DateTime createdtime)
        {
        	
        	_id = id;
        	_routesclassid = routesclassid;
        	_routesprentclassid = routesprentclassid;
        	_title = title;
        	_price = price;
        	_image = image;
        	_startposition = startposition;
        	_destination = destination;
        	_routetime = routetime;
        	_trafficmodel = trafficmodel;
        	_descriptionroute = descriptionroute;
        	_descriptionprice = descriptionprice;
        	_viewcount = viewcount;
        	_lastupdatetimeroute = lastupdatetimeroute;
        	_lastupdatetimeprice = lastupdatetimeprice;
        	_recommendhot = recommendhot;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
