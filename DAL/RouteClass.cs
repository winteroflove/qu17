/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月16日 17:43:22 生成*/


/*----------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ClassLibrary.DAL
{
    /// <summary>
    /// 表[RouteClass]的数据访问类。
    /// </summary>
    public class RouteClass
    {
        #region  常用变量
        /// <summary>
        /// 表名
        /// </summary>
		private static readonly string table = "RouteClass";
		/// <summary>
        /// 主键列
        /// </summary>
		private static readonly string pk = "ID";
		/// <summary>
        /// 排序
        /// </summary>
		private static readonly string orderby = " ID ASC";
        
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
        /// <param name="model">RouteClass对象</param>
        public int Add(ClassLibrary.Model.RouteClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("INSERT INTO {0}(", table));
            strSql.Append("ParentID,ClassName,CreatedTime,Recommend,seoTitle,seoKeyword,seoDesc,classlevel,classNamePY,ClassOrder,ClassImg,IsHaidao");
            strSql.Append(") VALUES (");
            strSql.Append("@ParentID,@ClassName,@CreatedTime,@Recommend,@seoTitle,@seoKeyword,@seoDesc,@classlevel,@classNamePY,@ClassOrder,@ClassImg,@IsHaidao)");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int, 4),
					new SqlParameter("@ClassName", SqlDbType.NVarChar, 40),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime, 8),
                    new SqlParameter("@Recommend", SqlDbType.Bit, 1),
                    new SqlParameter("@seoTitle", SqlDbType.NVarChar, 80),
                    new SqlParameter("@seoKeyword", SqlDbType.NVarChar, 100),
                    new SqlParameter("@seoDesc", SqlDbType.NVarChar, 200),
                    new SqlParameter("@classlevel", SqlDbType.Int, 4),
                    new SqlParameter("@classNamePY", SqlDbType.NVarChar, 15),
                    new SqlParameter("@ClassOrder", SqlDbType.Int, 4),
                    new SqlParameter("@ClassImg", SqlDbType.NVarChar, 50),
                    new SqlParameter("@IsHaidao", SqlDbType.Bit, 1)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.ClassName;
			parameters[2].Value = model.CreatedTime;
            parameters[3].Value = model.Recommend;
            parameters[4].Value = model.SeoTitle;
            parameters[5].Value = model.SeoKeyword;
            parameters[6].Value = model.SeoDesc;
            parameters[7].Value = model.ClassLevel;
            parameters[8].Value = model.ClassNamePY;
            parameters[9].Value = model.ClassOrder;
            parameters[10].Value = model.ClassImg;
            parameters[11].Value = model.IsHaidao;

            return SQLHelper.Execute(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">RouteClass对象</param>
        /// <returns>影响行数</returns>
        public int Update(ClassLibrary.Model.RouteClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("UPDATE {0} SET ", table));
            strSql.Append("ParentID=@ParentID,");
			strSql.Append("ClassName=@ClassName,");
			strSql.Append("CreatedTime=@CreatedTime,");
            strSql.Append("Recommend=@Recommend,");
            strSql.Append("seoTitle=@seoTitle,");
            strSql.Append("seoKeyword=@seoKeyword,");
            strSql.Append("seoDesc=@seoDesc,");
            strSql.Append("classlevel=@classlevel,");
            strSql.Append("classNamePY=@classNamePY,");
            strSql.Append("ClassOrder=@ClassOrder,");
            strSql.Append("ClassImg=@ClassImg,");
            strSql.Append("IsHaidao=@IsHaidao");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int, 4),
					new SqlParameter("@ParentID", SqlDbType.Int, 4),
					new SqlParameter("@ClassName", SqlDbType.NVarChar, 40),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime, 8),
                    new SqlParameter("@Recommend", SqlDbType.Bit, 1),
                    new SqlParameter("@seoTitle", SqlDbType.NVarChar, 80),
                    new SqlParameter("@seoKeyword", SqlDbType.NVarChar, 100),
                    new SqlParameter("@seoDesc", SqlDbType.NVarChar, 200),
                    new SqlParameter("@classlevel", SqlDbType.Int, 4),
                    new SqlParameter("@classNamePY", SqlDbType.NVarChar, 15),
                    new SqlParameter("@ClassOrder", SqlDbType.Int, 4),
                    new SqlParameter("@ClassImg", SqlDbType.NVarChar, 50),
                    new SqlParameter("@IsHaidao", SqlDbType.Bit, 1)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ParentID;
			parameters[2].Value = model.ClassName;
			parameters[3].Value = model.CreatedTime;
            parameters[4].Value = model.Recommend;
            parameters[5].Value = model.SeoTitle;
            parameters[6].Value = model.SeoKeyword;
            parameters[7].Value = model.SeoDesc;
            parameters[8].Value = model.ClassLevel;
            parameters[9].Value = model.ClassNamePY;
            parameters[10].Value = model.ClassOrder;
            parameters[11].Value = model.ClassImg;
            parameters[12].Value = model.IsHaidao;

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
        /// <returns>RouteClass对象</returns>
        public ClassLibrary.Model.RouteClass GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,ParentID,ClassName,CreatedTime,Recommend,seoTitle,seoKeyword,seoDesc,classlevel,classNamePY,ClassOrder,ClassImg,IsHaidao");
            strSql.Append(" FROM ");
            strSql.Append(table);
            strSql.Append(string.Format(" WHERE {0}=@{0}", pk));
            SqlParameter[] parameters = {
                    new SqlParameter("@" + pk, SqlDbType.Int ,4)};
            parameters[0].Value = ID;
            ClassLibrary.Model.RouteClass model = new ClassLibrary.Model.RouteClass();
            DataTable dt = SQLHelper.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ParentID"] != DBNull.Value)
				{
					model.ParentID = Convert.ToInt32(dt.Rows[0]["ParentID"]);
				}
                if (dt.Rows[0]["ClassName"] != DBNull.Value)
				{
					model.ClassName = Convert.ToString(dt.Rows[0]["ClassName"]);
				}
                if (dt.Rows[0]["CreatedTime"] != DBNull.Value)
				{
					model.CreatedTime = Convert.ToDateTime(dt.Rows[0]["CreatedTime"]);
				}
                if (dt.Rows[0]["Recommend"] != DBNull.Value)
                {
                    model.Recommend = Convert.ToBoolean(dt.Rows[0]["Recommend"]);
                }
                if (dt.Rows[0]["seoTitle"] != DBNull.Value)
                {
                    model.SeoTitle = Convert.ToString(dt.Rows[0]["seoTitle"]);
                }
                if (dt.Rows[0]["seoKeyword"] != DBNull.Value)
                {
                    model.SeoKeyword = Convert.ToString(dt.Rows[0]["seoKeyword"]);
                }
                if (dt.Rows[0]["seoDesc"] != DBNull.Value)
                {
                    model.SeoDesc = Convert.ToString(dt.Rows[0]["seoDesc"]);
                }
                if (dt.Rows[0]["classlevel"] != DBNull.Value)
                {
                    model.ClassLevel = Convert.ToInt32(dt.Rows[0]["classlevel"]);
                }
                if (dt.Rows[0]["classNamePY"] != DBNull.Value)
                {
                    model.ClassNamePY = Convert.ToString(dt.Rows[0]["classNamePY"]);
                }
                if (dt.Rows[0]["ClassOrder"] != DBNull.Value)
                {
                    model.ClassOrder = Convert.ToInt32(dt.Rows[0]["ClassOrder"]);
                }
                if (dt.Rows[0]["ClassImg"] != DBNull.Value)
                {
                    model.ClassImg = Convert.ToString(dt.Rows[0]["ClassImg"]);
                }
                if (dt.Rows[0]["IsHaidao"] != DBNull.Value)
                {
                    model.IsHaidao = Convert.ToBoolean(dt.Rows[0]["IsHaidao"]);
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
            return SQLHelper.GetData("ID,ParentID,ClassName,CreatedTime,Recommend,seoTitle,seoKeyword,seoDesc,classlevel,classNamePY,ClassOrder,ClassImg,IsHaidao", table, strWhere, getOrder(orderBy));
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
                    , "ID,ParentID,ClassName,CreatedTime,Recommend,seoTitle,seoKeyword,seoDesc,classlevel,classNamePY,ClassOrder,ClassImg,IsHaidao"
                    , table
                    , pk, strWhere, getOrder(orderBy));
        }
    
        #endregion  成员方法

        /// <summary>
        /// 通过父ID，获取所有子级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public DataTable GetSubList(int parentID, string strWherre)
        {
            string strSql = @"with newTable as
                                (
                                    select ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,seoKeyword,seoDesc,classlevel,classNamePY,ClassOrder,ClassImg,IsHaidao from RouteClass where ID=@ParentID
                                    union all
                                    select RouteClass.* from RouteClass inner join newTable on RouteClass.ParentID=newTable.ID
                                )
                            select ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,seoKeyword,seoDesc,classlevel,classNamePY,ClassOrder,ClassImg,IsHaidao from newTable";

            if (!string.IsNullOrEmpty(strWherre))
            {
                strSql += " where " + strWherre;
            }

            SqlParameter par = new SqlParameter("ParentID", parentID);

            return SQLHelper.Query(strSql, par);
        }
        /// <summary>
        /// 通过父ID，获取所有子级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public DataTable GetSubList(int parentID, string strWherre, string orderBy)
        {
            string strSql = @"with newTable as
                                (
                                    select ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,seoKeyword,seoDesc,classlevel,classNamePY,ClassOrder,ClassImg,IsHaidao from RouteClass where ID=@ParentID
                                    union all
                                    select RouteClass.* from RouteClass inner join newTable on RouteClass.ParentID=newTable.ID
                                )
                            select ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,seoKeyword,seoDesc,classlevel,classNamePY,ClassOrder,ClassImg,IsHaidao from newTable";

            if (!string.IsNullOrEmpty(strWherre))
            {
                strSql += " where " + strWherre;
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                strSql += " order by " + orderBy;
            }
            SqlParameter par = new SqlParameter("ParentID", parentID);

            return SQLHelper.Query(strSql, par);
        }
        /// <summary>
        /// 通过父ID，获取所有子级
        /// </summary>
        /// <param name="parentIDs"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public DataTable GetSubList(string parentIDs, string strWherre)
        {
            string strSql = "with newTable as ( select ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,SeoKeyword,SeoDesc,ClassLevel,classNamePY,ClassOrder,ClassImg,IsHaidao from routeClass where ID in (" + parentIDs + ")";
            strSql += " union all select routeClass.* from routeClass inner join newTable on routeClass.ParentID=newTable.ID )";
            strSql += " select distinct ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,SeoKeyword,SeoDesc,ClassLevel,classNamePY,ClassOrder,ClassImg,IsHaidao from newTable";

            if (!string.IsNullOrEmpty(strWherre))
            {
                strSql += " where " + strWherre;
            }

            return SQLHelper.Query(strSql);
        }
        /// <summary>
        /// 通过子ID，获取所有父级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public DataTable GetParentList(int subID, string strWherre, string orderBy)
        {
            string strSql = @"with newTable as
                                (
                                    select ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,seoKeyword,seoDesc,classlevel,classNamePY,ClassOrder,ClassImg,IsHaidao from RouteClass where ID=@subID
                                    union all
                                    select RouteClass.* from RouteClass inner join newTable on RouteClass.ID=newTable.ParentID
                                )
                            select ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,seoKeyword,seoDesc,classlevel,classNamePY,ClassOrder,ClassImg,IsHaidao from newTable";

            if (!string.IsNullOrEmpty(strWherre))
            {
                strSql += " where " + strWherre;
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                strSql += " order by " + orderBy;
            }
            else
            {
                strSql += " order by ID ASC";
            }

            SqlParameter par = new SqlParameter("subID", subID);

            return SQLHelper.Query(strSql, par);
        }
        /// <summary>
        /// 通过子ID，获取所有父级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public DataTable GetParentList(string subIDs, string strWherre)
        {
            string strSql = "with newTable as ( select ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,SeoKeyword,SeoDesc,ClassLevel,classNamePY,ClassOrder,ClassImg,IsHaidao from routeClass where ID in (" + subIDs + ")";
            strSql += " union all select routeClass.* from routeClass inner join newTable on routeClass.ID=newTable.ParentID )";
            strSql += " select distinct ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,SeoKeyword,SeoDesc,ClassLevel,classNamePY,ClassOrder,ClassImg,IsHaidao from newTable";

            if (!string.IsNullOrEmpty(strWherre))
            {
                strSql += " where " + strWherre;
            }

            strSql += " order by ID ASC";

            return SQLHelper.Query(strSql);
        }
        /// <summary>
        /// 通过子ID，获取所有父级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public DataTable GetParentList(string subIDs, string strWherre, string orderBy)
        {
            string strSql = "with newTable as ( select ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,SeoKeyword,SeoDesc,ClassLevel,classNamePY,ClassOrder,ClassImg,IsHaidao from routeClass where ID in (" + subIDs + ")";
            strSql += " union all select routeClass.* from routeClass inner join newTable on routeClass.ID=newTable.ParentID )";
            strSql += " select distinct ID,ParentID,ClassName,Recommend,CreatedTime,seoTitle,SeoKeyword,SeoDesc,ClassLevel,classNamePY,ClassOrder,ClassImg,IsHaidao from newTable";

            if (!string.IsNullOrEmpty(strWherre))
            {
                strSql += " where " + strWherre;
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                strSql += " order by " + orderBy;
            }
            else
            {
                strSql += " order by ID ASC";
            }

            return SQLHelper.Query(strSql);
        }
    }
}
