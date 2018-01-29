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
    /// 表[News]的数据访问类。
    /// </summary>
    public class News
    {
        #region  常用变量
        /// <summary>
        /// 表名
        /// </summary>
		private static readonly string table = "News";
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
        /// <param name="model">News对象</param>
        public int Add(ClassLibrary.Model.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("INSERT INTO {0}(", table));
            strSql.Append("newsClassID,routeClassID,Title,Editor,Source,ViewCount,Image,Content,CreatedTime,seoKeyword,seoDescription,IsDisplay,LocationID,IsSanxia,ZanCount,Ntag");
            strSql.Append(") VALUES (");
            strSql.Append("@newsClassID,@routeClassID,@Title,@Editor,@Source,@ViewCount,@Image,@Content,@CreatedTime,@seoKeyword,@seoDescription,@IsDisplay,@LocationID,@IsSanxia,@ZanCount,@Ntag)");
            SqlParameter[] parameters = {
					new SqlParameter("@newsClassID", SqlDbType.Int, 4),
					new SqlParameter("@routeClassID", SqlDbType.NVarChar, 100),
					new SqlParameter("@Title", SqlDbType.NVarChar, 100),
					new SqlParameter("@Editor", SqlDbType.NVarChar, 40),
					new SqlParameter("@Source", SqlDbType.NVarChar, 200),
					new SqlParameter("@ViewCount", SqlDbType.Int, 6),
					new SqlParameter("@Image", SqlDbType.NVarChar, 50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime, 8),
                    new SqlParameter("@seoKeyword", SqlDbType.NVarChar,100),
                    new SqlParameter("@seoDescription", SqlDbType.NVarChar, 200),
                    new SqlParameter("@IsDisplay", SqlDbType.Bit, 1),
                    new SqlParameter("@LocationID", SqlDbType.Int, 4),
                    new SqlParameter("@IsSanxia", SqlDbType.Bit, 1),
                    new SqlParameter("@ZanCount", SqlDbType.Int, 4),
                    new SqlParameter("@Ntag", SqlDbType.NVarChar, 100)};
			parameters[0].Value = model.newsClassID;
			parameters[1].Value = model.routeClassID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Editor;
			parameters[4].Value = model.Source;
			parameters[5].Value = model.ViewCount;
			parameters[6].Value = model.Image;
			parameters[7].Value = model.Content;
			parameters[8].Value = model.CreatedTime;
            parameters[9].Value = model.Keywords;
            parameters[10].Value = model.Description;
            parameters[11].Value = model.Display;
            parameters[12].Value = model.LocationID;
            parameters[13].Value = model.IsSanxia;
            parameters[14].Value = model.ZanCount;
            parameters[15].Value = model.Ntag;

            return SQLHelper.Execute(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">News对象</param>
        /// <returns>影响行数</returns>
        public int Update(ClassLibrary.Model.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("UPDATE {0} SET ", table));
            strSql.Append("newsClassID=@newsClassID,");
			strSql.Append("routeClassID=@routeClassID,");
			strSql.Append("Title=@Title,");
			strSql.Append("Editor=@Editor,");
			strSql.Append("Source=@Source,");
			strSql.Append("Image=@Image,");
			strSql.Append("Content=@Content,");
            strSql.Append("seoKeyword=@seoKeyword,");
            strSql.Append("seoDescription=@seoDescription,");
            strSql.Append("IsDisplay=@IsDisplay,");
            strSql.Append("LocationID=@LocationID,");
            strSql.Append("IsSanxia=@IsSanxia,");
            strSql.Append("Ntag=@Ntag");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int, 6),
					new SqlParameter("@newsClassID", SqlDbType.Int, 4),
					new SqlParameter("@routeClassID", SqlDbType.NVarChar, 100),
					new SqlParameter("@Title", SqlDbType.NVarChar, 100),
					new SqlParameter("@Editor", SqlDbType.NVarChar, 40),
					new SqlParameter("@Source", SqlDbType.NVarChar, 200),
					new SqlParameter("@Image", SqlDbType.NVarChar, 50),
					new SqlParameter("@Content", SqlDbType.Text),
                    new SqlParameter("@seoKeyword", SqlDbType.NVarChar, 100),
                    new SqlParameter("@seoDescription", SqlDbType.NVarChar, 200),
                    new SqlParameter("@IsDisplay", SqlDbType.Bit, 1),
                    new SqlParameter("@LocationID", SqlDbType.Int, 4),
                    new SqlParameter("@IsSanxia", SqlDbType.Bit, 1),
                    new SqlParameter("@Ntag", SqlDbType.NVarChar, 100)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.newsClassID;
			parameters[2].Value = model.routeClassID;
			parameters[3].Value = model.Title;
			parameters[4].Value = model.Editor;
			parameters[5].Value = model.Source;
			parameters[6].Value = model.Image;
			parameters[7].Value = model.Content;
            parameters[8].Value = model.Keywords;
            parameters[9].Value = model.Description;
            parameters[10].Value = model.Display;
            parameters[11].Value = model.LocationID;
            parameters[12].Value = model.IsSanxia;
            parameters[13].Value = model.Ntag;

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
                    new SqlParameter("@" + pk, SqlDbType.Int ,6)
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
        /// <returns>News对象</returns>
        public ClassLibrary.Model.News GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,newsClassID,routeClassID,Title,Editor,Source,ViewCount,Image,Content,CreatedTime,seoKeyword,seoDescription,IsDisplay,LocationID,IsSanxia,ZanCount,Ntag");
            strSql.Append(" FROM ");
            strSql.Append(table);
            strSql.Append(string.Format(" WHERE {0}=@{0}", pk));
            SqlParameter[] parameters = {
                    new SqlParameter("@" + pk, SqlDbType.Int ,6)};
            parameters[0].Value = ID;
            ClassLibrary.Model.News model = new ClassLibrary.Model.News();
            DataTable dt = SQLHelper.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["newsClassID"] != DBNull.Value)
				{
					model.newsClassID = Convert.ToInt32(dt.Rows[0]["newsClassID"]);
				}
                if (dt.Rows[0]["routeClassID"] != DBNull.Value)
				{
                    model.routeClassID = Convert.ToString(dt.Rows[0]["routeClassID"]);
				}
                if (dt.Rows[0]["Title"] != DBNull.Value)
				{
					model.Title = Convert.ToString(dt.Rows[0]["Title"]);
				}
                if (dt.Rows[0]["Editor"] != DBNull.Value)
				{
					model.Editor = Convert.ToString(dt.Rows[0]["Editor"]);
				}
                if (dt.Rows[0]["Source"] != DBNull.Value)
				{
					model.Source = Convert.ToString(dt.Rows[0]["Source"]);
				}
                if (dt.Rows[0]["ViewCount"] != DBNull.Value)
				{
					model.ViewCount = Convert.ToInt32(dt.Rows[0]["ViewCount"]);
				}
                if (dt.Rows[0]["Image"] != DBNull.Value)
				{
					model.Image = Convert.ToString(dt.Rows[0]["Image"]);
				}
                if (dt.Rows[0]["Content"] != DBNull.Value)
				{
					model.Content = Convert.ToString(dt.Rows[0]["Content"]);
				}
                if (dt.Rows[0]["CreatedTime"] != DBNull.Value)
				{
					model.CreatedTime = Convert.ToDateTime(dt.Rows[0]["CreatedTime"]);
				}
                if (dt.Rows[0]["Ntag"] != DBNull.Value)
				{
                    model.Ntag = Convert.ToString(dt.Rows[0]["Ntag"]);
                }
                if (dt.Rows[0]["seoKeyword"] != DBNull.Value)
                {
                    model.Keywords = Convert.ToString(dt.Rows[0]["seoKeyword"]);
                }
                if (dt.Rows[0]["seoDescription"] != DBNull.Value)
                {
                    model.Description = Convert.ToString(dt.Rows[0]["seoDescription"]);
                }
                if (dt.Rows[0]["IsDisplay"] != DBNull.Value)
                {
                    model.Display = Convert.ToBoolean(dt.Rows[0]["IsDisplay"]);
                }
                if (dt.Rows[0]["LocationID"] != DBNull.Value)
                {
                    model.LocationID = Convert.ToInt32(dt.Rows[0]["LocationID"]);
                }
                if (dt.Rows[0]["IsSanxia"] != DBNull.Value)
				{
                    model.IsSanxia = Convert.ToBoolean(dt.Rows[0]["IsSanxia"]);
                }
                if (dt.Rows[0]["ZanCount"] != DBNull.Value)
                {
                    model.ZanCount = Convert.ToInt32(dt.Rows[0]["ZanCount"]);
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
        public DataTable GetData(int top, string strWhere, string orderBy)
        {
            string sql = string.Empty;

            if (top == 0)
            {
                sql = "*";
            }
            else
            {
                sql = "top " + top + " * ";
            }
            return SQLHelper.GetData(sql, table, strWhere, getOrder(orderBy));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="orderBy">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetData(string strWhere, string orderBy)
        {
            return SQLHelper.GetData("ID,newsClassID,routeClassID,Title,Editor,Source,ViewCount,Image,Content,CreatedTime,seoKeyword,seoDescription,IsDisplay,LocationID,IsSanxia,ZanCount,Ntag", table, strWhere, getOrder(orderBy));
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
                    , "ID,newsClassID,routeClassID,Title,Editor,Source,ViewCount,Image,Content,CreatedTime,seoKeyword,seoDescription,IsDisplay,LocationID,IsSanxia,ZanCount,Ntag"
                    , table
                    , pk, strWhere, getOrder(orderBy));
        }
    
        #endregion  成员方法

        /// <summary>
        /// 上一篇
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataTable GetPrevData(int NewsID)
        {
            string strSql = "select top 1 * from News where isdisplay = 1 and ID<@NewsID order by ID desc";
            SqlParameter par = new SqlParameter("@NewsID",NewsID);

            return SQLHelper.Query(strSql, par);
        }

        /// <summary>
        /// 下一篇
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataTable GetNextData(int NewsID)
        {
            string strSql = "select top 1 * from News where isdisplay = 1 and ID>@NewsID order by ID asc";
            SqlParameter par = new SqlParameter("@NewsID", NewsID);

            return SQLHelper.Query(strSql, par);
        }
    }
}
