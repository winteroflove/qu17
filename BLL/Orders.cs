/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月22日 16:02:58 生成*/


/*----------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Model;
//using ClassLibrary.IDAL;
//using ClassLibrary.DALFactory;

namespace ClassLibrary.BLL
{
    /// <summary>
    /// 业务逻辑类 [Orders] 的摘要说明。
    /// </summary>
    public class Orders
    {
        #region  常用变量
        /// <summary>
        /// 数据操作实例
        /// </summary>
        private readonly ClassLibrary.DAL.Orders dal = new ClassLibrary.DAL.Orders();
        //private readonly IOrders dal = DataAccess.CreateOrders();
        /// <summary>
        /// 排序
        /// </summary>
		private static readonly string orderby = " CreatedTime DESC";
        
        #endregion

        #region  成员方法

		/// <summary>
		/// 获取排序
		/// </summary>
		/// <param name="orderBy"></param>
		/// <returns></returns>
		private string getOrder(string orderBy)
		{
			return (string.IsNullOrEmpty(orderBy)) ? orderby : orderBy;
		}

        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns>最大ID</returns>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="proQuantity">主键OrderNumber</param>
        /// <returns>是否存在该记录</returns>
        public bool Exist(string OrderNumber)
        {
            return dal.Exist(OrderNumber);
        }
        
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>是否存在该记录</returns>
        public bool Exists(string strWhere)
        {
			if (string.IsNullOrEmpty(strWhere))
            {
                return false;
            }
            return dal.Exists(strWhere);
        }
        
        /// <summary>
        /// 获取指定条件的记录数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>记录总数</returns>
        public int Count(string strWhere)
        {
            return dal.Count(strWhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">model对象</param>
        public int Add(ClassLibrary.Model.Orders model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// 更新多条记录
        /// </summary>
        /// <param name="sets">设置内容(例:id=1,name='aaa')</param>
        /// <param name="strWhere">条件</param>
        /// <returns>影响行数</returns>
        public int Updates(string sets, string strWhere)
        {
			if (string.IsNullOrEmpty(sets) || sets.Split('=').Length <= 0)
            {
                return -1;
            }
            return dal.Updates(sets, strWhere);
        }
        
        /// <summary>
        /// 更新多条记录
        /// </summary>
        /// <param name="sets">设置内容</param>
        /// <param name="strWhere">条件</param>
        /// <param name="primaryKeyIns">主键集合</param>
        /// <returns>影响行数</returns>
        public int Updates(string sets, string strWhere, string primaryKeyIns)
        {
			if (string.IsNullOrEmpty(sets) || sets.Split('=').Length <= 0 || string.IsNullOrEmpty(primaryKeyIns))
            {
                return -1;
            }
            return dal.Updates(sets, strWhere, primaryKeyIns);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="OrderNumber">主键OrderNumber</param>
        /// <returns>影响行数</returns>
        public int Delete(string OrderNumber)
        {
            return dal.Delete(OrderNumber);
        }
        
        /// <summary>
        /// 按条件删除表中的数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>影响行数</returns>
        public int Deletes(string strWhere)
        {
            return dal.Deletes(strWhere);
        }
        
        /// <summary>
        /// 按条件删除指定主键集合的数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="primaryKeyIns">主键集合</param>
        /// <returns>影响行数</returns>
        public int Deletes(string strWhere, string primaryKeyIns)
        {
			if (string.IsNullOrEmpty(primaryKeyIns))
            {
                return -1;
            }
            return dal.Deletes(strWhere, primaryKeyIns);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="OrderNumber">主键OrderNumber</param>
        /// <returns>Orders对象</returns>
        public ClassLibrary.Model.Orders GetModel(string OrderNumber)
        {
            return dal.GetModel(OrderNumber);
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>Orders集合</returns>
        public List<ClassLibrary.Model.Orders> GetModelList(string strWhere)
        {
            DataTable dt = GetData(strWhere);
            List<ClassLibrary.Model.Orders> modelList = new List<ClassLibrary.Model.Orders>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ClassLibrary.Model.Orders model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ClassLibrary.Model.Orders();
                    if (dt.Rows[n]["OrderNumber"] != DBNull.Value)
					{
						model.OrderNumber = Convert.ToString(dt.Rows[n]["OrderNumber"]);
					}
                    if (dt.Rows[n]["UserName"] != DBNull.Value)
					{
						model.UserName = Convert.ToString(dt.Rows[n]["UserName"]);
					}
                    if (dt.Rows[n]["proQuantity"] != DBNull.Value)
					{
                        model.proQuantity = Convert.ToString(dt.Rows[n]["proQuantity"]);
					}
                    if (dt.Rows[n]["proTotalPrice"] != DBNull.Value)
					{
						model.proTotalPrice = Convert.ToDecimal(dt.Rows[n]["proTotalPrice"]);
					}
                    if (dt.Rows[n]["Linkman"] != DBNull.Value)
					{
						model.Linkman = Convert.ToString(dt.Rows[n]["Linkman"]);
					}
                    if (dt.Rows[n]["Fax"] != DBNull.Value)
					{
						model.Fax = Convert.ToString(dt.Rows[n]["Fax"]);
					}
                    if (dt.Rows[n]["Mobile"] != DBNull.Value)
					{
						model.Mobile = Convert.ToString(dt.Rows[n]["Mobile"]);
					}
                    if (dt.Rows[n]["Telphone"] != DBNull.Value)
					{
						model.Telphone = Convert.ToString(dt.Rows[n]["Telphone"]);
					}
                    if (dt.Rows[n]["Email"] != DBNull.Value)
					{
						model.Email = Convert.ToString(dt.Rows[n]["Email"]);
					}
                    if (dt.Rows[n]["IdentityCard"] != DBNull.Value)
					{
						model.IdentityCard = Convert.ToString(dt.Rows[n]["IdentityCard"]);
					}
                    if (dt.Rows[n]["ContractType"] != DBNull.Value)
					{
						model.ContractType = Convert.ToString(dt.Rows[n]["ContractType"]);
					}
                    if (dt.Rows[n]["Payment"] != DBNull.Value)
					{
						model.Payment = Convert.ToString(dt.Rows[n]["Payment"]);
					}
                    if (dt.Rows[n]["Remark"] != DBNull.Value)
					{
						model.Remark = Convert.ToString(dt.Rows[n]["Remark"]);
					}
                    if (dt.Rows[n]["Status"] != DBNull.Value)
					{
						model.Status = Convert.ToString(dt.Rows[n]["Status"]);
					}
                    if (dt.Rows[n]["CreatedTime"] != DBNull.Value)
					{
						model.CreatedTime = Convert.ToDateTime(dt.Rows[n]["CreatedTime"]);
					}
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>数据表</returns>
        public DataTable GetData(string strWhere)
        {
            return GetData(strWhere, orderby);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="orderBy">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetData(string strWhere, string orderBy)
        {
            return dal.GetData(strWhere, getOrder(orderBy));
        }
        
        #endregion  成员方法
    }
}
