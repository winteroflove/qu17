/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月22日 16:02:58 生成*/


/*----------------------------------------*/
using System;
namespace ClassLibrary.Model
{
    /// <summary>
    /// 表: [Orders] 的实体类。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Orders
    {
        #region 定义变量
        
        private string _ordernumber = "";
        private string _username = "";
        private string _proquantity = "";
        private decimal _prototalprice = 0M;
        private string _linkman = "";
        private string _fax = "";
        private string _mobile = "";
        private string _telphone = "";
        private string _email = "";
        private string _identitycard = "";
        private string _contracttype = "";
        private string _payment = "";
        private string _remark = "";
        private string _status = "未处理";
        private DateTime _createdtime = DateTime.Now;
        #endregion

        #region 声明属性
        
        /// <summary>
        /// OrderNumber
        /// </summary>
        public string OrderNumber
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
        /// proQuantity
        /// </summary>
        public string proQuantity
        {
            set{ _proquantity = value; }
            get{ return _proquantity; }
        }
        /// <summary>
        /// proTotalPrice
        /// </summary>
        public decimal proTotalPrice
        {
            set{ _prototalprice = value; }
            get{ return _prototalprice; }
        }
        /// <summary>
        /// Linkman
        /// </summary>
        public string Linkman
        {
            set{ _linkman = value; }
            get{ return _linkman; }
        }
        /// <summary>
        /// Fax
        /// </summary>
        public string Fax
        {
            set{ _fax = value; }
            get{ return _fax; }
        }
        /// <summary>
        /// Mobile
        /// </summary>
        public string Mobile
        {
            set{ _mobile = value; }
            get{ return _mobile; }
        }
        /// <summary>
        /// Telphone
        /// </summary>
        public string Telphone
        {
            set{ _telphone = value; }
            get{ return _telphone; }
        }
        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            set{ _email = value; }
            get{ return _email; }
        }
        /// <summary>
        /// IdentityCard
        /// </summary>
        public string IdentityCard
        {
            set{ _identitycard = value; }
            get{ return _identitycard; }
        }
        /// <summary>
        /// ContractType
        /// </summary>
        public string ContractType
        {
            set{ _contracttype = value; }
            get{ return _contracttype; }
        }
        /// <summary>
        /// Payment
        /// </summary>
        public string Payment
        {
            set{ _payment = value; }
            get{ return _payment; }
        }
        /// <summary>
        /// Remark
        /// </summary>
        public string Remark
        {
            set{ _remark = value; }
            get{ return _remark; }
        }
        /// <summary>
        /// Status
        /// </summary>
        public string Status
        {
            set{ _status = value; }
            get{ return _status; }
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
        /// Orders默认构造函数
        /// </summary>
        public Orders()
        {
        }
        
        /// <summary>
        /// Orders构造函数
        /// </summary>
        public Orders(string ordernumber, string username, string proquantity, decimal prototalprice, string linkman, string fax, string mobile, string telphone, string email, string identitycard, string contracttype, string payment, string remark, string status, DateTime createdtime)
        {
        	
        	_ordernumber = ordernumber;
        	_username = username;
        	_proquantity = proquantity;
        	_prototalprice = prototalprice;
        	_linkman = linkman;
        	_fax = fax;
        	_mobile = mobile;
        	_telphone = telphone;
        	_email = email;
        	_identitycard = identitycard;
        	_contracttype = contracttype;
        	_payment = payment;
        	_remark = remark;
        	_status = status;
        	_createdtime = createdtime;
        }
        #endregion
    }
}
