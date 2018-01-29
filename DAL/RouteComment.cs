/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月21日 14:57:06 生成*/


/*----------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ClassLibrary.DAL
{
    /// <summary>
    /// 表[RouteComment]的数据访问类。
    /// </summary>
    public class RouteComment
    {
        #region  常用变量
        /// <summary>
        /// 表名
        /// </summary>
		private static readonly string table = "RouteComment";
		/// <summary>
        /// 主键列
        /// </summary>
		private static readonly string pk = "ID";
		/// <summary>
        /// 排序
        /// </summary>
		private static readonly string orderby = " ID DESC";
        
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
        /// <param name="ID">主键ID</param>
        /// <returns>是否存在该记录</returns>
        public bool Exist(int ID)
        {
            return (Convert.ToInt32(SQLHelper.Count(table, string.Format("{0}='{1}'", pk, ID))) > 0);
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
        /// <param name="model">RouteComment对象</param>
        public int Add(ClassLibrary.Model.RouteComment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("INSERT INTO {0}(", table));
            strSql.Append("UserName,Nickname,Anonymous,routeID,Grade,Email,Content,Checked,CreatedTime");
            strSql.Append(") VALUES (");
            strSql.Append("@UserName,@Nickname,@Anonymous,@routeID,@Grade,@Email,@Content,@Checked,@CreatedTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar, 100),
					new SqlParameter("@Nickname", SqlDbType.NVarChar, 60),
					new SqlParameter("@Anonymous", SqlDbType.Bit, 1),
					new SqlParameter("@routeID", SqlDbType.Int, 4),
					new SqlParameter("@Grade", SqlDbType.TinyInt, 1),
					new SqlParameter("@Email", SqlDbType.NVarChar, 100),
					new SqlParameter("@Content", SqlDbType.NVarChar, 200),
					new SqlParameter("@Checked", SqlDbType.Bit, 1),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Nickname;
			parameters[2].Value = model.Anonymous;
			parameters[3].Value = model.routeID;
			parameters[4].Value = model.Grade;
			parameters[5].Value = model.Email;
			parameters[6].Value = model.Content;
			parameters[7].Value = model.Checked;
			parameters[8].Value = model.CreatedTime;
            return SQLHelper.Execute(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">RouteComment对象</param>
        /// <returns>影响行数</returns>
        public int Update(ClassLibrary.Model.RouteComment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("UPDATE {0} SET ", table));
            strSql.Append("UserName=@UserName,");
			strSql.Append("Nickname=@Nickname,");
			strSql.Append("Anonymous=@Anonymous,");
			strSql.Append("routeID=@routeID,");
			strSql.Append("Grade=@Grade,");
			strSql.Append("Email=@Email,");
			strSql.Append("Content=@Content,");
			strSql.Append("Checked=@Checked,");
			strSql.Append("CreatedTime=@CreatedTime");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int, 4),
					new SqlParameter("@UserName", SqlDbType.NVarChar, 100),
					new SqlParameter("@Nickname", SqlDbType.NVarChar, 60),
					new SqlParameter("@Anonymous", SqlDbType.Bit, 1),
					new SqlParameter("@routeID", SqlDbType.Int, 4),
					new SqlParameter("@Grade", SqlDbType.TinyInt, 1),
					new SqlParameter("@Email", SqlDbType.NVarChar, 100),
					new SqlParameter("@Content", SqlDbType.NVarChar, 200),
					new SqlParameter("@Checked", SqlDbType.Bit, 1),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime, 8)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Nickname;
			parameters[3].Value = model.Anonymous;
			parameters[4].Value = model.routeID;
			parameters[5].Value = model.Grade;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.Content;
			parameters[8].Value = model.Checked;
			parameters[9].Value = model.CreatedTime;
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
        /// <param name="ID">主键ID</param>
        /// <returns>影响行数</returns>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("DELETE FROM {0} ", table));
            strSql.Append(string.Format(" WHERE {0}=@{0}", pk));
            SqlParameter[] parameters = {
                    new SqlParameter("@" + pk, SqlDbType.Int ,4)
                };
            parameters[0].Value = ID;
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
        /// <param name="ID">主键ID</param>
        /// <returns>RouteComment对象</returns>
        public ClassLibrary.Model.RouteComment GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,UserName,Nickname,Anonymous,routeID,Grade,Email,Content,Checked,CreatedTime");
            strSql.Append(" FROM ");
            strSql.Append(table);
            strSql.Append(string.Format(" WHERE {0}=@{0}", pk));
            SqlParameter[] parameters = {
                    new SqlParameter("@" + pk, SqlDbType.Int ,4)};
            parameters[0].Value = ID;
            ClassLibrary.Model.RouteComment model = new ClassLibrary.Model.RouteComment();
            DataTable dt = SQLHelper.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["UserName"] != DBNull.Value)
				{
					model.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
				}
                if (dt.Rows[0]["Nickname"] != DBNull.Value)
				{
					model.Nickname = Convert.ToString(dt.Rows[0]["Nickname"]);
				}
                if (dt.Rows[0]["Anonymous"] != DBNull.Value)
				{
					model.Anonymous = Convert.ToBoolean(dt.Rows[0]["Anonymous"]);
				}
                if (dt.Rows[0]["routeID"] != DBNull.Value)
				{
					model.routeID = Convert.ToInt32(dt.Rows[0]["routeID"]);
				}
                if (dt.Rows[0]["Grade"] != DBNull.Value)
				{
					model.Grade = Convert.ToByte(dt.Rows[0]["Grade"]);
				}
                if (dt.Rows[0]["Email"] != DBNull.Value)
				{
					model.Email = Convert.ToString(dt.Rows[0]["Email"]);
				}
                if (dt.Rows[0]["Content"] != DBNull.Value)
				{
					model.Content = Convert.ToString(dt.Rows[0]["Content"]);
				}
                if (dt.Rows[0]["Checked"] != DBNull.Value)
				{
					model.Checked = Convert.ToBoolean(dt.Rows[0]["Checked"]);
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
            return SQLHelper.GetData("ID,UserName,Nickname,Anonymous,routeID,Grade,Email,Content,Checked,CreatedTime", table, strWhere, getOrder(orderBy));
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
                    , "ID,UserName,Nickname,Anonymous,routeID,Grade,Email,Content,Checked,CreatedTime"
                    , table
                    , pk, strWhere, getOrder(orderBy));
        }

        public int UpdateCheck(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("UPDATE {0} SET ", table));
            strSql.Append("Checked='"+true+"'");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int, 4)};
            parameters[0].Value = ID;
            return SQLHelper.Execute(strSql.ToString(), parameters);
        }
    
        #endregion  成员方法


    }
}
