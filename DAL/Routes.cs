/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月20日 22:13:28 生成*/


/*----------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ClassLibrary.DAL
{
    /// <summary>
    /// 表[Routes]的数据访问类。
    /// </summary>
    public class Routes
    {
        #region  常用变量
        /// <summary>
        /// 表名
        /// </summary>
		private static readonly string table = "Routes";
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
        /// <param name="model">Routes对象</param>
        public int Add(ClassLibrary.Model.Routes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("INSERT INTO {0}(", table));
            strSql.Append("routesClassID,routesPrentClassID,Title,Price,Image,StartPosition,Destination,RouteTime,TrafficModel,DescriptionRoute,DescriptionPrice," + 
                "ViewCount,LastUpdateTimeRoute,LastUpdateTimePrice,RecommendHot,CreatedTime,ThemeID,SeoKeywords,SeoDescription,RouteOrder,IsDisplay,FirstTime," +
                "DetailType,ChildPrice,DatePrice,DateType,AdvanceDays,RouteFeature,RouteNotice,Supplier,seoTitle,Bright,BoatName,LocationID,SupplierTel,appImg");
            strSql.Append(") VALUES (");
            strSql.Append("@routesClassID,@routesPrentClassID,@Title,@Price,@Image,@StartPosition,@Destination,@RouteTime,@TrafficModel,@DescriptionRoute,@DescriptionPrice," +
                "@ViewCount,@LastUpdateTimeRoute,@LastUpdateTimePrice,@RecommendHot,@CreatedTime,@ThemeID,@SeoKeywords,@SeoDescription,@RouteOrder,@IsDisplay,@FirstTime," +
                "@DetailType,@ChildPrice,@DatePrice,@DateType,@AdvanceDays,@RouteFeature,@RouteNotice,@Supplier,@seoTitle,@Bright,@BoatName,@LocationID,@SupplierTel,@appImg)");
            SqlParameter[] parameters = {
					new SqlParameter("@routesClassID", SqlDbType.NVarChar, 20),
					new SqlParameter("@routesPrentClassID", SqlDbType.NVarChar, 200),
					new SqlParameter("@Title", SqlDbType.NVarChar, 200),
					new SqlParameter("@Price", SqlDbType.Decimal, 9),
					new SqlParameter("@Image", SqlDbType.NVarChar, 400),
					new SqlParameter("@StartPosition", SqlDbType.NVarChar, 60),
					new SqlParameter("@Destination", SqlDbType.NVarChar, 60),
					new SqlParameter("@RouteTime", SqlDbType.NVarChar, 40),
					new SqlParameter("@TrafficModel", SqlDbType.NVarChar, 40),
					new SqlParameter("@DescriptionRoute", SqlDbType.NText),
					new SqlParameter("@DescriptionPrice", SqlDbType.NText),
					new SqlParameter("@ViewCount", SqlDbType.Int, 4),
					new SqlParameter("@LastUpdateTimeRoute", SqlDbType.DateTime, 8),
					new SqlParameter("@LastUpdateTimePrice", SqlDbType.DateTime, 8),
					new SqlParameter("@RecommendHot", SqlDbType.Bit, 1),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime, 8),
                    new SqlParameter("@ThemeID", SqlDbType.NVarChar, 50),
                    new SqlParameter("@SeoKeywords",SqlDbType.NVarChar,500),
                    new SqlParameter("@SeoDescription",SqlDbType.NVarChar,500),
                    new SqlParameter("@RouteOrder", SqlDbType.Int, 9),
                    new SqlParameter("@IsDisplay", SqlDbType.Bit, 1),
                    new SqlParameter("@FirstTime", SqlDbType.NVarChar, 10),
                    new SqlParameter("@DetailType", SqlDbType.Bit, 1),
                    new SqlParameter("@ChildPrice", SqlDbType.Decimal, 9),
                    new SqlParameter("@DatePrice", SqlDbType.NVarChar, 2000),
                    new SqlParameter("@DateType", SqlDbType.Bit, 1),
                    new SqlParameter("@AdvanceDays", SqlDbType.Int, 4),
                    new SqlParameter("@RouteFeature", SqlDbType.NText),
                    new SqlParameter("@RouteNotice", SqlDbType.NText),
                    new SqlParameter("@Supplier", SqlDbType.NVarChar, 20),
                    new SqlParameter("@seoTitle", SqlDbType.NVarChar, 100),
                    new SqlParameter("@Bright", SqlDbType.NVarChar, 100),
                    new SqlParameter("@BoatName", SqlDbType.NVarChar, 10),
                    new SqlParameter("@LocationID", SqlDbType.Int, 4),
                    new SqlParameter("@SupplierTel", SqlDbType.NVarChar, 20),
                    new SqlParameter("@appImg", SqlDbType.NVarChar, 50)};
			parameters[0].Value = model.routesClassID;
			parameters[1].Value = model.routesPrentClassID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.Image;
			parameters[5].Value = model.StartPosition;
			parameters[6].Value = model.Destination;
			parameters[7].Value = model.RouteTime;
			parameters[8].Value = model.TrafficModel;
			parameters[9].Value = model.DescriptionRoute;
			parameters[10].Value = model.DescriptionPrice;
			parameters[11].Value = model.ViewCount;
			parameters[12].Value = model.LastUpdateTimeRoute;
			parameters[13].Value = model.LastUpdateTimePrice;
			parameters[14].Value = model.RecommendHot;
			parameters[15].Value = model.CreatedTime;
            parameters[16].Value = model.ThemeID;
            parameters[17].Value = model.SeoKeywords;
            parameters[18].Value = model.SeoDescription;
            parameters[19].Value = model.Order;
            parameters[20].Value = model.Display;
            parameters[21].Value = model.FirstTime;
            parameters[22].Value = model.DetailType;
            parameters[23].Value = model.ChildPrice;
            parameters[24].Value = model.DatePrice;
            parameters[25].Value = model.DateType;
            parameters[26].Value = model.AdvanceDays;
            parameters[27].Value = model.RouteFeature;
            parameters[28].Value = model.RouteNotice;
            parameters[29].Value = model.Supplier;
            parameters[30].Value = model.SeoTitle;
            parameters[31].Value = model.Bright;
            parameters[32].Value = model.BoatName;
            parameters[33].Value = model.LocationID;
            parameters[34].Value = model.SupplierTel;
            parameters[35].Value = model.AppImg;

            return SQLHelper.Execute(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Routes对象</param>
        /// <returns>影响行数</returns>
        public int Update(ClassLibrary.Model.Routes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("UPDATE {0} SET ", table));
            strSql.Append("routesClassID=@routesClassID,");
			strSql.Append("routesPrentClassID=@routesPrentClassID,");
			strSql.Append("Title=@Title,");
			strSql.Append("Price=@Price,");
			strSql.Append("Image=@Image,");
			strSql.Append("StartPosition=@StartPosition,");
			strSql.Append("Destination=@Destination,");
			strSql.Append("RouteTime=@RouteTime,");
			strSql.Append("TrafficModel=@TrafficModel,");
			strSql.Append("DescriptionRoute=@DescriptionRoute,");
			strSql.Append("DescriptionPrice=@DescriptionPrice,");
			strSql.Append("ViewCount=@ViewCount,");
			strSql.Append("LastUpdateTimeRoute=@LastUpdateTimeRoute,");
			strSql.Append("LastUpdateTimePrice=@LastUpdateTimePrice,");
			strSql.Append("RecommendHot=@RecommendHot,");
			strSql.Append("CreatedTime=@CreatedTime,");
            strSql.Append("ThemeID=@ThemeID,");
            strSql.Append("SeoKeywords=@SeoKeywords,");
            strSql.Append("SeoDescription=@SeoDescription,");
            strSql.Append("RouteOrder=@RouteOrder,");
            strSql.Append("IsDisplay=@IsDisplay,"); ;
            strSql.Append("DetailType=@DetailType,");
            strSql.Append("ChildPrice=@ChildPrice,");
            strSql.Append("DatePrice=@DatePrice,");
            strSql.Append("DateType=@DateType,");
            strSql.Append("AdvanceDays=@AdvanceDays,");
            strSql.Append("RouteFeature=@RouteFeature,");
            strSql.Append("RouteNotice=@RouteNotice,");
            strSql.Append("Supplier=@Supplier,");
            strSql.Append("seoTitle=@seoTitle,");
            strSql.Append("Bright=@Bright,");
            strSql.Append("BoatName=@BoatName,");
            strSql.Append("LocationID=@LocationID,");
            strSql.Append("SupplierTel=@SupplierTel,");
            strSql.Append("appImg=@appImg ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int, 6),
					new SqlParameter("@routesClassID", SqlDbType.NVarChar, 20),
					new SqlParameter("@routesPrentClassID", SqlDbType.NVarChar, 200),
					new SqlParameter("@Title", SqlDbType.NVarChar, 200),
					new SqlParameter("@Price", SqlDbType.Decimal, 9),
					new SqlParameter("@Image", SqlDbType.NVarChar, 400),
					new SqlParameter("@StartPosition", SqlDbType.NVarChar, 60),
					new SqlParameter("@Destination", SqlDbType.NVarChar, 60),
					new SqlParameter("@RouteTime", SqlDbType.NVarChar, 40),
					new SqlParameter("@TrafficModel", SqlDbType.NVarChar, 40),
					new SqlParameter("@DescriptionRoute", SqlDbType.NText),
					new SqlParameter("@DescriptionPrice", SqlDbType.NText),
					new SqlParameter("@ViewCount", SqlDbType.Int, 6),
					new SqlParameter("@LastUpdateTimeRoute", SqlDbType.DateTime, 8),
					new SqlParameter("@LastUpdateTimePrice", SqlDbType.DateTime, 8),
					new SqlParameter("@RecommendHot", SqlDbType.Bit, 1),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime, 8),
                    new SqlParameter("@ThemeID",SqlDbType.NVarChar,50),
                    new SqlParameter("@SeoKeywords",SqlDbType.NVarChar,500),
                    new SqlParameter("@SeoDescription",SqlDbType.NVarChar,500),
                    new SqlParameter("@RouteOrder", SqlDbType.Int, 9),
                    new SqlParameter("@IsDisplay", SqlDbType.Bit, 1),
                    new SqlParameter("@DetailType", SqlDbType.Bit, 1),
                    new SqlParameter("@ChildPrice", SqlDbType.Decimal, 9),
                    new SqlParameter("@DatePrice", SqlDbType.NVarChar, 2000),
                    new SqlParameter("@DateType", SqlDbType.Bit, 1),
                    new SqlParameter("@AdvanceDays", SqlDbType.Int, 4),
                    new SqlParameter("@RouteFeature", SqlDbType.NText),
                    new SqlParameter("@RouteNotice", SqlDbType.NText),
                    new SqlParameter("@Supplier",SqlDbType.NVarChar, 20),
                    new SqlParameter("@seoTitle", SqlDbType.NVarChar, 100),
                    new SqlParameter("@Bright", SqlDbType.NVarChar, 100),
                    new SqlParameter("@BoatName", SqlDbType.NVarChar, 10),
                    new SqlParameter("@LocationID", SqlDbType.Int, 4),
                    new SqlParameter("@SupplierTel",SqlDbType.NVarChar, 20),
                    new SqlParameter("@appImg",SqlDbType.NVarChar, 50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.routesClassID;
			parameters[2].Value = model.routesPrentClassID;
			parameters[3].Value = model.Title;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Image;
			parameters[6].Value = model.StartPosition;
			parameters[7].Value = model.Destination;
			parameters[8].Value = model.RouteTime;
			parameters[9].Value = model.TrafficModel;
			parameters[10].Value = model.DescriptionRoute;
			parameters[11].Value = model.DescriptionPrice;
			parameters[12].Value = model.ViewCount;
			parameters[13].Value = model.LastUpdateTimeRoute;
			parameters[14].Value = model.LastUpdateTimePrice;
			parameters[15].Value = model.RecommendHot;
			parameters[16].Value = model.CreatedTime;
            parameters[17].Value = model.ThemeID;
            parameters[18].Value = model.SeoKeywords;
            parameters[19].Value = model.SeoDescription;
            parameters[20].Value = model.Order;
            parameters[21].Value = model.Display;
            parameters[22].Value = model.DetailType;
            parameters[23].Value = model.ChildPrice;
            parameters[24].Value = model.DatePrice;
            parameters[25].Value = model.DateType;
            parameters[26].Value = model.AdvanceDays;
            parameters[27].Value = model.RouteFeature;
            parameters[28].Value = model.RouteNotice;
            parameters[29].Value = model.Supplier;
            parameters[30].Value = model.SeoTitle;
            parameters[31].Value = model.Bright;
            parameters[32].Value = model.BoatName;
            parameters[33].Value = model.LocationID;
            parameters[34].Value = model.SupplierTel;
            parameters[35].Value = model.AppImg;
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
        /// <returns>Routes对象</returns>
        public ClassLibrary.Model.Routes GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT *");
            strSql.Append(" FROM ");
            strSql.Append(table);
            strSql.Append(string.Format(" WHERE {0}=@{0}", pk));
            SqlParameter[] parameters = {
                    new SqlParameter("@" + pk, SqlDbType.Int ,6)};
            parameters[0].Value = ID;
            ClassLibrary.Model.Routes model = new ClassLibrary.Model.Routes();
            DataTable dt = SQLHelper.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["routesClassID"] != DBNull.Value)
				{
                    model.routesClassID = Convert.ToString(dt.Rows[0]["routesClassID"]);
				}
                if (dt.Rows[0]["routesPrentClassID"] != DBNull.Value)
				{
					model.routesPrentClassID = Convert.ToString(dt.Rows[0]["routesPrentClassID"]);
				}
                if (dt.Rows[0]["ThemeID"] != DBNull.Value)
                {
                    model.ThemeID = Convert.ToString(dt.Rows[0]["ThemeID"]);
                }
                if (dt.Rows[0]["Title"] != DBNull.Value)
				{
					model.Title = Convert.ToString(dt.Rows[0]["Title"]);
				}
                if (dt.Rows[0]["Price"] != DBNull.Value)
				{
					model.Price = Convert.ToDecimal(dt.Rows[0]["Price"]);
				}
                if (dt.Rows[0]["Image"] != DBNull.Value)
				{
					model.Image = Convert.ToString(dt.Rows[0]["Image"]);
				}
                if (dt.Rows[0]["StartPosition"] != DBNull.Value)
				{
					model.StartPosition = Convert.ToString(dt.Rows[0]["StartPosition"]);
				}
                if (dt.Rows[0]["Destination"] != DBNull.Value)
				{
					model.Destination = Convert.ToString(dt.Rows[0]["Destination"]);
				}
                if (dt.Rows[0]["RouteTime"] != DBNull.Value)
				{
					model.RouteTime = Convert.ToString(dt.Rows[0]["RouteTime"]);
				}
                if (dt.Rows[0]["TrafficModel"] != DBNull.Value)
				{
					model.TrafficModel = Convert.ToString(dt.Rows[0]["TrafficModel"]);
				}
                if (dt.Rows[0]["DescriptionRoute"] != DBNull.Value)
				{
					model.DescriptionRoute = Convert.ToString(dt.Rows[0]["DescriptionRoute"]);
				}
                if (dt.Rows[0]["DescriptionPrice"] != DBNull.Value)
				{
					model.DescriptionPrice = Convert.ToString(dt.Rows[0]["DescriptionPrice"]);
				}
                if (dt.Rows[0]["ViewCount"] != DBNull.Value)
				{
					model.ViewCount = Convert.ToInt32(dt.Rows[0]["ViewCount"]);
				}
                if (dt.Rows[0]["LastUpdateTimeRoute"] != DBNull.Value)
				{
					model.LastUpdateTimeRoute = Convert.ToDateTime(dt.Rows[0]["LastUpdateTimeRoute"]);
				}
                if (dt.Rows[0]["LastUpdateTimePrice"] != DBNull.Value)
				{
					model.LastUpdateTimePrice = Convert.ToDateTime(dt.Rows[0]["LastUpdateTimePrice"]);
				}
                if (dt.Rows[0]["RecommendHot"] != DBNull.Value)
				{
					model.RecommendHot = Convert.ToBoolean(dt.Rows[0]["RecommendHot"]);
				}
                if (dt.Rows[0]["CreatedTime"] != DBNull.Value)
				{
					model.CreatedTime = Convert.ToDateTime(dt.Rows[0]["CreatedTime"]);
				}
                if (dt.Rows[0]["SeoKeywords"] != DBNull.Value)
                {
                    model.SeoKeywords = Convert.ToString(dt.Rows[0]["SeoKeywords"]);
                }
                if (dt.Rows[0]["SeoDescription"] != DBNull.Value)
                {
                    model.SeoDescription = Convert.ToString(dt.Rows[0]["SeoDescription"]);
                }
                if (dt.Rows[0]["IsDisplay"] != DBNull.Value)
                {
                    model.Display = Convert.ToBoolean(dt.Rows[0]["IsDisplay"]);
                }
                model.FirstTime = dt.Rows[0]["FirstTime"].ToString();

                if (dt.Rows[0]["DetailType"] != DBNull.Value)
                {
                    model.DetailType = Convert.ToBoolean(dt.Rows[0]["DetailType"]);
                }
                if (dt.Rows[0]["DateType"] != DBNull.Value)
                {
                    model.DateType = Convert.ToBoolean(dt.Rows[0]["DateType"]);
                }
                if (dt.Rows[0]["DatePrice"] != DBNull.Value)
                {
                    model.DatePrice = Convert.ToString(dt.Rows[0]["DatePrice"]);
                }
                if (dt.Rows[0]["ChildPrice"] != DBNull.Value)
                {
                    model.ChildPrice = Convert.ToDecimal(dt.Rows[0]["ChildPrice"]);
                }
                if (dt.Rows[0]["AdvanceDays"] != DBNull.Value)
                {
                    model.AdvanceDays = Convert.ToInt32(dt.Rows[0]["AdvanceDays"]);
                }
                if (dt.Rows[0]["RouteFeature"] != DBNull.Value)
                {
                    model.RouteFeature = Convert.ToString(dt.Rows[0]["RouteFeature"]);
                }
                if (dt.Rows[0]["RouteNotice"] != DBNull.Value)
                {
                    model.RouteNotice = Convert.ToString(dt.Rows[0]["RouteNotice"]);
                }
                if (dt.Rows[0]["RouteOrder"] != DBNull.Value)
                {
                    model.Order = Convert.ToInt32(dt.Rows[0]["RouteOrder"]);
                }
                if (dt.Rows[0]["Supplier"] != DBNull.Value)
                {
                    model.Supplier = Convert.ToString(dt.Rows[0]["Supplier"]);
                }
                if (dt.Rows[0]["seoTitle"] != DBNull.Value)
                {
                    model.SeoTitle = Convert.ToString(dt.Rows[0]["seoTitle"]);
                }
                if (dt.Rows[0]["Bright"] != DBNull.Value)
                {
                    model.Bright = Convert.ToString(dt.Rows[0]["Bright"]);
                }
                if (dt.Rows[0]["BoatName"] != DBNull.Value)
                {
                    model.BoatName = Convert.ToString(dt.Rows[0]["BoatName"]);
                }
                if (dt.Rows[0]["LocationID"] != DBNull.Value)
                {
                    model.LocationID = Convert.ToInt32(dt.Rows[0]["LocationID"]);
                }
                if (dt.Rows[0]["SupplierTel"] != DBNull.Value)
                {
                    model.SupplierTel = Convert.ToString(dt.Rows[0]["SupplierTel"]);
                }
                if (dt.Rows[0]["appImg"] != DBNull.Value)
                {
                    model.AppImg = Convert.ToString(dt.Rows[0]["appImg"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>数据表</returns>
        public DataTable GetData(string strWhere)
        {
            return GetData(0, strWhere, orderby);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>数据表</returns>
        public DataTable GetData(int top, string strWhere)
        {
            return GetData(top, strWhere, orderby);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="orderBy">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetData(string strWhere, string orderBy)
        {
            return GetData(0, strWhere, orderBy);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="top">前几条</param>
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
                    , "ID,routesClassID,routesPrentClassID,Title,Price,Image,StartPosition,Destination,RouteTime,TrafficModel,DescriptionRoute,DescriptionPrice," +
                    "ViewCount,LastUpdateTimeRoute,LastUpdateTimePrice,RecommendHot,CreatedTime,ThemeID,RouteOrder,IsDisplay,FirstTime,DetailType,ChildPrice,DatePrice," +
                    "DateType,AdvanceDays,RouteFeature,RouteNotice,Supplier,ThemeId,SeoKeywords,SeoDescription,SeoTitle,Bright,BoatName,LocationID,SupplierTel,appImg"
                    , table
                    , pk, strWhere, getOrder(orderBy));
        }
    
        #endregion  成员方法;

        public DataTable GetRouteTop10()
        {
            string strSql = "select top 10 ID,Title,Image,DescriptionRoute,routesClassId from Routes where IsDisplay = 1 order by CreatedTime desc";

            return SQLHelper.Query(strSql);
        }

        public int UpdateRouteOrder(int routeId, int routeOrder) 
        {
            return SQLHelper.Updates(table, "routeOrder = '" + routeOrder + "'", "Id = '" + routeId + "'");
        }

        public int UpdateRoutePrice(int routeId, decimal routePrice)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("UPDATE {0} SET ", table));
            strSql.Append("Price=@Price,");
            strSql.Append("LastUpdateTimePrice=@LastUpdateTimePrice");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int, 6),
					new SqlParameter("@Price", SqlDbType.Decimal, 9),
					new SqlParameter("@LastUpdateTimePrice", SqlDbType.DateTime, 8)};
            parameters[0].Value = routeId;
            parameters[1].Value = routePrice;
            parameters[2].Value = DateTime.Now;
            return SQLHelper.Execute(strSql.ToString(), parameters);
        }
        
        public DataTable GetLastId()
        {
            string strSql = "SELECT IDENT_CURRENT('" + table + "') as routeId";

            return SQLHelper.Query(strSql);
        }
        public DataTable GetPriceLevel(string strWhere)
        {
            string strSql = "select distinct case when price < 500 then '0-500' when Price < 1500 then '500-1500' when Price < 3000 then '1500-3000' when Price < 10000 then '3000-10000' else '10000-0' end as vprice from Routes where IsDisplay = 1";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " and " + strWhere;
            }
            return SQLHelper.Query(strSql);
        }
        public DataTable GetPriceLevelCj(string strWhere)
        {
            string strSql = "select distinct case when price < 3000 then '0-3000' when Price < 8000 then '3000-8000' when Price < 15000 then '8000-15000' when Price < 20000 then '15000-20000' else '20000-0' end as vprice from Routes where IsDisplay = 1";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " and " + strWhere;
            }
            return SQLHelper.Query(strSql);
        }
        public DataTable GetDaysLevel(string strWhere)
        {
            string strSql = "select distinct case when routetime >= 7 then 7 else RouteTime end as sday from Routes where IsDisplay = 1";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " and " + strWhere;
            }
            strSql += " order by sday ";
            return SQLHelper.Query(strSql);
        }
        public DataTable GetDaysLevelCj(string strWhere)
        {
            string strSql = "select distinct case when routetime >= 11 then 11 when routetime <= 5 then 5 else RouteTime end as sday from Routes where IsDisplay = 1";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " and " + strWhere;
            }
            strSql += " order by sday ";
            return SQLHelper.Query(strSql);
        }
    }
}
