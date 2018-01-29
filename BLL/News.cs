/*----------------------------------------*/
/*此代码由阿里星星代码生成器 2011年1月16日 17:43:22 生成*/


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
    /// 业务逻辑类 [News] 的摘要说明。
    /// </summary>
    public class News
    {
        #region  常用变量
        /// <summary>
        /// 数据操作实例
        /// </summary>
        private readonly ClassLibrary.DAL.News dal = new ClassLibrary.DAL.News();
        //private readonly INews dal = DataAccess.CreateNews();
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
        public int Add(ClassLibrary.Model.News model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">model对象</param>
        /// <returns>影响行数</returns>
        public int Update(ClassLibrary.Model.News model)
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
        /// <returns>News对象</returns>
        public ClassLibrary.Model.News GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

		/// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>News集合</returns>
        public List<ClassLibrary.Model.News> GetModelList(string strWhere)
        {
            return GetModelList(0, strWhere);
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>News集合</returns>
        public List<ClassLibrary.Model.News> GetModelList(int top, string strWhere)
        {
            DataTable dt = dal.GetData(top, strWhere, "createdtime desc");
            return GetModelList(dt);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>News集合</returns>
        public List<ClassLibrary.Model.News> GetModelList(int top, string strWhere, string orderBy)
        {
            DataTable dt = dal.GetData(top, strWhere, orderBy);
            return GetModelList(dt);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>News集合</returns>
        public List<ClassLibrary.Model.News> GetModelList(DataTable dt)
        {
            List<ClassLibrary.Model.News> modelList = new List<ClassLibrary.Model.News>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ClassLibrary.Model.News model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ClassLibrary.Model.News();
                    if (dt.Rows[n]["ID"] != DBNull.Value)
                    {
                        model.ID = Convert.ToInt32(dt.Rows[n]["ID"]);
                    }
                    if (dt.Rows[n]["newsClassID"] != DBNull.Value)
                    {
                        model.newsClassID = Convert.ToInt32(dt.Rows[n]["newsClassID"]);
                    }
                    if (dt.Rows[n]["routeClassID"] != DBNull.Value)
                    {
                        model.routeClassID = Convert.ToString(dt.Rows[n]["routeClassID"]);
                    }
                    if (dt.Rows[n]["Title"] != DBNull.Value)
                    {
                        model.Title = Convert.ToString(dt.Rows[n]["Title"]);
                    }
                    if (dt.Rows[n]["Editor"] != DBNull.Value)
                    {
                        model.Editor = Convert.ToString(dt.Rows[n]["Editor"]);
                    }
                    if (dt.Rows[n]["Source"] != DBNull.Value)
                    {
                        model.Source = Convert.ToString(dt.Rows[n]["Source"]);
                    }
                    if (dt.Rows[n]["ViewCount"] != DBNull.Value)
                    {
                        model.ViewCount = Convert.ToInt32(dt.Rows[n]["ViewCount"]);
                    }
                    if (dt.Rows[n]["Image"] != DBNull.Value)
                    {
                        model.Image = Convert.ToString(dt.Rows[n]["Image"]);
                    }
                    if (dt.Rows[n]["Content"] != DBNull.Value)
                    {
                        model.Content = Convert.ToString(dt.Rows[n]["Content"]);
                    }
                    if (dt.Rows[n]["CreatedTime"] != DBNull.Value)
                    {
                        model.CreatedTime = Convert.ToDateTime(dt.Rows[n]["CreatedTime"]);
                    }
                    if (dt.Rows[n]["Ntag"] != DBNull.Value)
                    {
                        model.Ntag = Convert.ToString(dt.Rows[n]["Ntag"]);
                    }
                    if (dt.Rows[n]["seoKeyword"] != DBNull.Value)
                    {
                        model.Keywords = Convert.ToString(dt.Rows[n]["seoKeyword"]);
                    }
                    if (dt.Rows[n]["seoDescription"] != DBNull.Value)
                    {
                        model.Description = Convert.ToString(dt.Rows[n]["seoDescription"]);
                    }
                    if (dt.Rows[n]["IsDisplay"] != DBNull.Value)
                    {
                        model.Display = Convert.ToBoolean(dt.Rows[n]["IsDisplay"]);
                    }
                    if (dt.Rows[n]["LocationID"] != DBNull.Value)
                    {
                        model.LocationID = Convert.ToInt32(dt.Rows[n]["LocationID"]);
                    }
                    if (dt.Rows[n]["IsSanxia"] != DBNull.Value)
                    {
                        model.IsSanxia = Convert.ToBoolean(dt.Rows[n]["IsSanxia"]);
                    }
                    if (dt.Rows[n]["ZanCount"] != DBNull.Value)
                    {
                        model.ZanCount = Convert.ToInt32(dt.Rows[n]["ZanCount"]);
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

        /// <summary>
        /// 上一篇
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataTable GetPrevData(int NewsID)
        {
            return dal.GetPrevData(NewsID);
        }

        /// <summary>
        /// 下一篇
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataTable GetNextData(int NewsID)
        {
            return dal.GetNextData(NewsID);
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
    }
}
