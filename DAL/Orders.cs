/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月22日 16:02:58 生成*/


/*----------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ClassLibrary.DAL
{
    /// <summary>
    /// 表[Orders]的数据访问类。
    /// </summary>
    public class Orders
    {
        #region  常用变量
        /// <summary>
        /// 表名
        /// </summary>
		private static readonly string table = "Orders";
		/// <summary>
        /// 主键列
        /// </summary>
        private static readonly string pk = "OrderNumber";
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
            object o = SQLHelper.Max(table, pk, "1=1");
            return (o == DBNull.Value) ? 1 : Convert.ToInt32(o) + 1;
        }
        
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="OrderNumber">主键OrderNumber</param>
        /// <returns>是否存在该记录</returns>
        public bool Exist(string OrderNumber)
        {
            return (Convert.ToInt32(SQLHelper.Count(table, string.Format("{0}='{1}'", pk, OrderNumber))) > 0);
        }
        
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>是否存在该记录</returns>
        public bool Exists(string strWhere)
        {
            return (Convert.ToInt32(SQLHelper.Count(table, strWhere)) > 0);
        }
        
        /// <summary>
        /// 获取指定条件的记录数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>记录总数</returns>
        public int Count(string strWhere)
        {
            return SQLHelper.Count(table, strWhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">Orders对象</param>
        public int Add(ClassLibrary.Model.Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("INSERT INTO {0}(", table));
            strSql.Append("OrderNumber,UserName,proTotalPrice,proQuantity,Linkman,Fax,Mobile,Telphone,Email,IdentityCard,ContractType,Payment,Remark,Status,CreatedTime");
            strSql.Append(") VALUES (");
            strSql.Append("@OrderNumber,@UserName,@proTotalPrice,@proQuantity,@Linkman,@Fax,@Mobile,@Telphone,@Email,@IdentityCard,@ContractType,@Payment,@Remark,@Status,@CreatedTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNumber", SqlDbType.VarChar, 32),
					new SqlParameter("@UserName", SqlDbType.NVarChar, 100),
					new SqlParameter("@proTotalPrice", SqlDbType.Decimal, 9),
					new SqlParameter("@Linkman", SqlDbType.NVarChar, 40),
					new SqlParameter("@Fax", SqlDbType.NVarChar, 40),
					new SqlParameter("@Mobile", SqlDbType.NVarChar, 40),
					new SqlParameter("@Telphone", SqlDbType.NVarChar, 40),
					new SqlParameter("@Email", SqlDbType.NVarChar, 100),
					new SqlParameter("@IdentityCard", SqlDbType.NVarChar, 40),
					new SqlParameter("@ContractType", SqlDbType.NVarChar, 20),
					new SqlParameter("@Payment", SqlDbType.NVarChar, 40),
					new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
					new SqlParameter("@Status", SqlDbType.NVarChar, 20),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime, 8),
                    new SqlParameter("@proQuantity", SqlDbType.NVarChar, 20)};
			parameters[0].Value = model.OrderNumber;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.proTotalPrice;
			parameters[3].Value = model.Linkman;
			parameters[4].Value = model.Fax;
			parameters[5].Value = model.Mobile;
			parameters[6].Value = model.Telphone;
			parameters[7].Value = model.Email;
			parameters[8].Value = model.IdentityCard;
			parameters[9].Value = model.ContractType;
			parameters[10].Value = model.Payment;
			parameters[11].Value = model.Remark;
			parameters[12].Value = model.Status;
			parameters[13].Value = model.CreatedTime;
            parameters[14].Value = model.proQuantity;
            return SQLHelper.Execute(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新多条记录
        /// </summary>
        /// <param name="sets">设置内容(例:id=1,name='aaa')</param>
        /// <param name="strWhere">条件</param>
        /// <returns>影响行数</returns>
        public int Updates(string sets, string strWhere)
        {
            return SQLHelper.Updates(table, sets, strWhere);
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
            return SQLHelper.Updates(table, sets, strWhere, pk, primaryKeyIns);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="OrderNumber">主键OrderNumber</param>
        /// <returns>影响行数</returns>
        public int Delete(string OrderNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("DELETE FROM {0} ", table));
            strSql.Append(string.Format(" WHERE {0}=@{0}", pk));
            SqlParameter[] parameters = {
                    new SqlParameter("@" + pk, SqlDbType.VarChar ,32)
                };
            parameters[0].Value = OrderNumber;
            return SQLHelper.Execute(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 按条件删除表中的数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>影响行数</returns>
        public int Deletes(string strWhere)
        {
            return SQLHelper.Deletes(table, strWhere);
        }
        
        /// <summary>
        /// 按条件删除指定主键集合的数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="primaryKeyIns">主键集合</param>
        /// <returns>影响行数</returns>
        public int Deletes(string strWhere, string primaryKeyIns)
        {
            return SQLHelper.Deletes(table, strWhere, pk, primaryKeyIns);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="OrderNumber">主键OrderNumber</param>
        /// <returns>Orders对象</returns>
        public ClassLibrary.Model.Orders GetModel(string OrderNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT OrderNumber,UserName,proQuantity,proTotalPrice,Linkman,Fax,Mobile,Telphone,Email,IdentityCard,ContractType,Payment,Remark,Status,CreatedTime");
            strSql.Append(" FROM ");
            strSql.Append(table);
            strSql.Append(string.Format(" WHERE {0}=@{0}", pk));
            SqlParameter[] parameters = {
                    new SqlParameter("@" + pk, SqlDbType.VarChar ,32)};
            parameters[0].Value = OrderNumber;
            ClassLibrary.Model.Orders model = new ClassLibrary.Model.Orders();
            DataTable dt = SQLHelper.Query(strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["OrderNumber"] != DBNull.Value)
				{
					model.OrderNumber = Convert.ToString(dt.Rows[0]["OrderNumber"]);
				}
                if (dt.Rows[0]["UserName"] != DBNull.Value)
				{
					model.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
				}
                if (dt.Rows[0]["proTotalPrice"] != DBNull.Value)
				{
					model.proTotalPrice = Convert.ToDecimal(dt.Rows[0]["proTotalPrice"]);
				}
                if (dt.Rows[0]["proQuantity"] != DBNull.Value)
                {
                    model.proQuantity = Convert.ToString(dt.Rows[0]["proQuantity"]);
                }
                if (dt.Rows[0]["Linkman"] != DBNull.Value)
				{
					model.Linkman = Convert.ToString(dt.Rows[0]["Linkman"]);
				}
                if (dt.Rows[0]["Fax"] != DBNull.Value)
				{
					model.Fax = Convert.ToString(dt.Rows[0]["Fax"]);
				}
                if (dt.Rows[0]["Mobile"] != DBNull.Value)
				{
					model.Mobile = Convert.ToString(dt.Rows[0]["Mobile"]);
				}
                if (dt.Rows[0]["Telphone"] != DBNull.Value)
				{
					model.Telphone = Convert.ToString(dt.Rows[0]["Telphone"]);
				}
                if (dt.Rows[0]["Email"] != DBNull.Value)
				{
					model.Email = Convert.ToString(dt.Rows[0]["Email"]);
				}
                if (dt.Rows[0]["IdentityCard"] != DBNull.Value)
				{
					model.IdentityCard = Convert.ToString(dt.Rows[0]["IdentityCard"]);
				}
                if (dt.Rows[0]["ContractType"] != DBNull.Value)
				{
					model.ContractType = Convert.ToString(dt.Rows[0]["ContractType"]);
				}
                if (dt.Rows[0]["Payment"] != DBNull.Value)
				{
					model.Payment = Convert.ToString(dt.Rows[0]["Payment"]);
				}
                if (dt.Rows[0]["Remark"] != DBNull.Value)
				{
					model.Remark = Convert.ToString(dt.Rows[0]["Remark"]);
				}
                if (dt.Rows[0]["Status"] != DBNull.Value)
				{
					model.Status = Convert.ToString(dt.Rows[0]["Status"]);
				}
                if (dt.Rows[0]["CreatedTime"] != DBNull.Value)
				{
					model.CreatedTime = Convert.ToDateTime(dt.Rows[0]["CreatedTime"]);
				}
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="orderBy">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetData(string strWhere, string orderBy)
        {
            return SQLHelper.GetData("OrderNumber,UserName,proQuantity,proTotalPrice,Linkman,Fax,Mobile,Telphone,Email,IdentityCard,ContractType,Payment,Remark,Status,CreatedTime", table, strWhere, getOrder(orderBy));
        }
        
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageNum">当前页码</param>
        /// <param name="strWhere">条件</param>
        /// <param name="orderBy">排序</param>
        /// <returns>分页数据集</returns>
        public DataSet GetPageData(int pageSize, int pageNum, string strWhere, string orderBy)
        {
            return SQLHelper.GetPageData(pageSize, pageNum
                    , "OrderNumber,UserName,proQuantity,proTotalPrice,Linkman,Fax,Mobile,Telphone,Email,IdentityCard,ContractType,Payment,Remark,Status,CreatedTime"
                    , table
                    , pk, strWhere, getOrder(orderBy));
        }
    
        #endregion  成员方法
    }
}
