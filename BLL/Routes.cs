/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月20日 22:13:28 生成*/


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
    /// 业务逻辑类 [Routes] 的摘要说明。
    /// </summary>
    public class Routes
    {
        #region  常用变量
        /// <summary>
        /// 数据操作实例
        /// </summary>
        private readonly ClassLibrary.DAL.Routes dal = new ClassLibrary.DAL.Routes();
        //private readonly IRoutes dal = DataAccess.CreateRoutes();
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
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="ID">主键ID</param>
        /// <returns>是否存在该记录</returns>
        public bool Exist(int ID)
        {
            return dal.Exist(ID);
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
        public int Add(ClassLibrary.Model.Routes model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">model对象</param>
        /// <returns>影响行数</returns>
        public int Update(ClassLibrary.Model.Routes model)
        {
            return dal.Update(model);
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
        /// <param name="ID">主键ID</param>
        /// <returns>影响行数</returns>
        public int Delete(int ID)
        {
            return dal.Delete(ID);
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
        /// <param name="ID">主键ID</param>
        /// <returns>Routes对象</returns>
        public ClassLibrary.Model.Routes GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

         /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>Routes集合</returns>
        public List<ClassLibrary.Model.Routes> GetModelList(string strWhere)
        {
            return GetModelList(0, strWhere, orderby);
        }

             /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>Routes集合</returns>
        public List<ClassLibrary.Model.Routes> GetModelList(int top, string strWhere)
        {
            return GetModelList(top, strWhere, orderby);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>Routes集合</returns>
        public List<ClassLibrary.Model.Routes> GetModelList(int top, string strWhere, string orderby)
        {
            DataTable dt = dal.GetData(top, strWhere, orderby);

            return GetModelList(dt);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>Routes集合</returns>
        public List<ClassLibrary.Model.Routes> GetModelList(DataTable dt)
        {
            List<ClassLibrary.Model.Routes> modelList = new List<ClassLibrary.Model.Routes>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ClassLibrary.Model.Routes model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ClassLibrary.Model.Routes();
                    if (dt.Rows[n]["ID"] != DBNull.Value)
					{
						model.ID = Convert.ToInt32(dt.Rows[n]["ID"]);
					}
                    if (dt.Rows[n]["routesClassID"] != DBNull.Value)
					{
                        model.routesClassID = Convert.ToString(dt.Rows[n]["routesClassID"]);
					}
                    if (dt.Rows[n]["ThemeID"] != DBNull.Value)
                    {
                        model.ThemeID = Convert.ToString(dt.Rows[n]["ThemeID"]);
                    }
                    if (dt.Rows[n]["routesPrentClassID"] != DBNull.Value)
					{
						model.routesPrentClassID = Convert.ToString(dt.Rows[n]["routesPrentClassID"]);
					}
                    if (dt.Rows[n]["Title"] != DBNull.Value)
					{
						model.Title = Convert.ToString(dt.Rows[n]["Title"]);
					}
                    if (dt.Rows[n]["Price"] != DBNull.Value)
					{
						model.Price = Convert.ToDecimal(dt.Rows[n]["Price"]);
					}
                    if (dt.Rows[n]["Image"] != DBNull.Value)
					{
						model.Image = Convert.ToString(dt.Rows[n]["Image"]);
					}
                    if (dt.Rows[n]["StartPosition"] != DBNull.Value)
					{
						model.StartPosition = Convert.ToString(dt.Rows[n]["StartPosition"]);
					}
                    if (dt.Rows[n]["Destination"] != DBNull.Value)
					{
						model.Destination = Convert.ToString(dt.Rows[n]["Destination"]);
					}
                    if (dt.Rows[n]["RouteTime"] != DBNull.Value)
					{
						model.RouteTime = Convert.ToString(dt.Rows[n]["RouteTime"]);
					}
                    if (dt.Rows[n]["TrafficModel"] != DBNull.Value)
					{
						model.TrafficModel = Convert.ToString(dt.Rows[n]["TrafficModel"]);
					}
                    if (dt.Rows[n]["DescriptionRoute"] != DBNull.Value)
					{
						model.DescriptionRoute = Convert.ToString(dt.Rows[n]["DescriptionRoute"]);
					}
                    if (dt.Rows[n]["DescriptionPrice"] != DBNull.Value)
					{
						model.DescriptionPrice = Convert.ToString(dt.Rows[n]["DescriptionPrice"]);
					}
                    if (dt.Rows[n]["ViewCount"] != DBNull.Value)
					{
						model.ViewCount = Convert.ToInt32(dt.Rows[n]["ViewCount"]);
					}
                    if (dt.Rows[n]["LastUpdateTimeRoute"] != DBNull.Value)
					{
						model.LastUpdateTimeRoute = Convert.ToDateTime(dt.Rows[n]["LastUpdateTimeRoute"]);
					}
                    if (dt.Rows[n]["LastUpdateTimePrice"] != DBNull.Value)
					{
						model.LastUpdateTimePrice = Convert.ToDateTime(dt.Rows[n]["LastUpdateTimePrice"]);
					}
                    if (dt.Rows[n]["RecommendHot"] != DBNull.Value)
					{
						model.RecommendHot = Convert.ToBoolean(dt.Rows[n]["RecommendHot"]);
					}
                    if (dt.Rows[n]["CreatedTime"] != DBNull.Value)
					{
						model.CreatedTime = Convert.ToDateTime(dt.Rows[n]["CreatedTime"]);
					}
                    if (dt.Rows[n]["SeoKeywords"] != DBNull.Value)
                    {
                        model.SeoKeywords = Convert.ToString(dt.Rows[n]["SeoKeywords"]);
                    }
                    if (dt.Rows[n]["SeoDescription"] != DBNull.Value)
                    {
                        model.SeoDescription = Convert.ToString(dt.Rows[n]["SeoDescription"]);
                    }
                    if (dt.Rows[n]["IsDisplay"] != DBNull.Value)
                    {
                        model.Display = Convert.ToBoolean(dt.Rows[n]["IsDisplay"]);
                    }
                    model.FirstTime = dt.Rows[n]["FirstTime"].ToString();

                    if (dt.Rows[n]["DetailType"] != DBNull.Value)
                    {
                        model.DetailType = Convert.ToBoolean(dt.Rows[n]["DetailType"]);
                    }
                    if (dt.Rows[n]["DateType"] != DBNull.Value)
                    {
                        model.DateType = Convert.ToBoolean(dt.Rows[n]["DateType"]);
                    }
                    if (dt.Rows[n]["DatePrice"] != DBNull.Value)
                    {
                        model.DatePrice = Convert.ToString(dt.Rows[n]["DatePrice"]);
                    }
                    if (dt.Rows[n]["ChildPrice"] != DBNull.Value)
                    {
                        model.ChildPrice = Convert.ToDecimal(dt.Rows[n]["ChildPrice"]);
                    }
                    if (dt.Rows[n]["AdvanceDays"] != DBNull.Value)
                    {
                        model.AdvanceDays = Convert.ToInt32(dt.Rows[n]["AdvanceDays"]);
                    }
                    if (dt.Rows[n]["RouteFeature"] != DBNull.Value)
                    {
                        model.RouteFeature = Convert.ToString(dt.Rows[n]["RouteFeature"]);
                    }
                    if (dt.Rows[n]["RouteNotice"] != DBNull.Value)
                    {
                        model.RouteNotice = Convert.ToString(dt.Rows[n]["RouteNotice"]);
                    }
                    if (dt.Rows[n]["RouteOrder"] != DBNull.Value)
                    {
                        model.Order = Convert.ToInt32(dt.Rows[n]["RouteOrder"]);
                    }
                    if (dt.Rows[n]["Supplier"] != DBNull.Value)
                    {
                        model.Supplier = Convert.ToString(dt.Rows[n]["Supplier"]);
                    }
                    if (dt.Rows[n]["seoTitle"] != DBNull.Value)
                    {
                        model.SeoTitle = Convert.ToString(dt.Rows[n]["seoTitle"]);
                    }
                    if (dt.Rows[n]["Bright"] != DBNull.Value)
                    {
                        model.Bright = Convert.ToString(dt.Rows[n]["Bright"]);
                    }
                    if (dt.Rows[n]["BoatName"] != DBNull.Value)
                    {
                        model.BoatName = Convert.ToString(dt.Rows[n]["BoatName"]);
                    }
                    if (dt.Rows[n]["LocationID"] != DBNull.Value)
                    {
                        model.LocationID = Convert.ToInt32(dt.Rows[n]["LocationID"]);
                    }
                    if (dt.Rows[n]["SupplierTel"] != DBNull.Value)
                    {
                        model.SupplierTel = Convert.ToString(dt.Rows[n]["SupplierTel"]);
                    }
                    if (dt.Rows[n]["appImg"] != DBNull.Value)
                    {
                        model.AppImg = Convert.ToString(dt.Rows[n]["appImg"]);
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
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="orderBy">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetData(int top, string strWhere, string orderBy)
        {
            return dal.GetData(top, strWhere, getOrder(orderBy));
        }
        #endregion  成员方法

        public DataTable GetRouteTop10()
        {
            return dal.GetRouteTop10();
        }

        public int UpdateRouteOrder(int routeId, int routeOrder)
        {
            return dal.UpdateRouteOrder(routeId, routeOrder); 
        }

        public int UpdateRoutePrice(int routeId, decimal routePrice)
        {
            return dal.UpdateRoutePrice(routeId, routePrice);
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
            return dal.GetPageData(pageSize, pageNum, strWhere, orderBy);
        }
        
        public int GetLastId()
        {
            DataTable dt = dal.GetLastId();
            int routeId = 0;
            if (dt.Rows[0]["routeId"] != DBNull.Value)
            {
                routeId = Convert.ToInt32(dt.Rows[0]["routeId"].ToString());
            }
            return routeId;
        }
        public string GetPriceLevel(string strWhere)
        {
            DataTable dt = dal.GetPriceLevel(strWhere);
            return GetPriceStr(dt);
        }
        public string GetPriceLevelCj(string strWhere)
        {
            DataTable dt = dal.GetPriceLevelCj(strWhere);
            return GetPriceStr(dt);
        }
        public string GetPriceStr(DataTable dt)
        {
            string priceLevel = "";

            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    priceLevel += dt.Rows[n]["vprice"].ToString() + ",";
                }
            }
            if (priceLevel != "") priceLevel = priceLevel.Substring(0, priceLevel.Length - 1);

            return priceLevel;
        }
        public string GetDaysLevel(string strWhere)
        {
            DataTable dt = dal.GetDaysLevel(strWhere);
            return GetDaysStr(dt);
        }
        public string GetDaysLevelCj(string strWhere)
        {
            DataTable dt = dal.GetDaysLevelCj(strWhere);
            return GetDaysStr(dt);
        }
        public string GetDaysStr(DataTable dt)
        {
            string daysLevel = "";

            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    daysLevel += dt.Rows[n]["sday"].ToString() + ",";
                }
            }
            if (daysLevel != "") daysLevel = daysLevel.Substring(0, daysLevel.Length - 1);

            return daysLevel;
        }
    }
}
