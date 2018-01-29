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
    /// 业务逻辑类 [RouteClass] 的摘要说明。
    /// </summary>
    public class RouteClass
    {
        #region  常用变量
        /// <summary>
        /// 数据操作实例
        /// </summary>
        private readonly ClassLibrary.DAL.RouteClass dal = new ClassLibrary.DAL.RouteClass();
        //private readonly IRouteClass dal = DataAccess.CreateRouteClass();
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
        public int Add(ClassLibrary.Model.RouteClass model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">model对象</param>
        /// <returns>影响行数</returns>
        public int Update(ClassLibrary.Model.RouteClass model)
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
        /// <returns>RouteClass对象</returns>
        public ClassLibrary.Model.RouteClass GetModel(int ID)
        {
            return dal.GetModel(ID);
        }
        
         /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>RouteClass集合</returns>
        public List<ClassLibrary.Model.RouteClass> GetModelList(string strWhere)
        {
            return GetModelList(strWhere, "ID ASC");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>RouteClass集合</returns>
        public List<ClassLibrary.Model.RouteClass> GetModelList(string strWhere ,string orderBy)
        {
            DataTable dt = GetData(strWhere, orderBy);

            return GetList(dt);
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
        /// 通过父ID，获取所有子级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public DataTable GetTableSubList(int parentID, string strWherre)
        {
            return dal.GetSubList(parentID, strWherre);
        }

      
        /// <summary>
        /// 获得所有子
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<ClassLibrary.Model.RouteClass> GetSubList(int parentID)
        {
            return GetSubList(parentID, string.Empty);
        }

        /// <summary>
        /// 通过父ID，获取所有子级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public List<ClassLibrary.Model.RouteClass> GetSubList(int parentID, string strWherre)
        {
            DataTable dt = dal.GetSubList(parentID, strWherre);

            return GetList(dt);
        }
        /// <summary>
        /// 通过父ID，获取所有子级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public List<ClassLibrary.Model.RouteClass> GetSubList(int parentID, string strWherre, string orderBy)
        {
            DataTable dt = dal.GetSubList(parentID, strWherre, orderBy);

            return GetList(dt);
        }
        /// <summary>
        /// 通过父ID，获取所有子级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public List<ClassLibrary.Model.RouteClass> GetSubList(string parentIDs, string strWherre)
        {
            DataTable dt = dal.GetSubList(parentIDs, strWherre);

            return GetList(dt);
        }
        /// <summary>
        /// 通过子ID，获取所有父级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public DataTable GetTableParentList(int subID, string strWherre, string orderBy)
        {
            return dal.GetParentList(subID, strWherre, orderBy);
        }

        /// <summary>
        /// 通过子ID，获取所有父级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public List<ClassLibrary.Model.RouteClass> GetParentList(int subID, string strWherre, string orderBy)
        {
            DataTable dt = dal.GetParentList(subID, strWherre, orderBy);

            return GetList(dt);
        }
        /// <summary>
        /// 通过子IDs，获取所有父级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public List<ClassLibrary.Model.RouteClass> GetParentList(string subIDs, string strWherre)
        {
            DataTable dt = dal.GetParentList(subIDs, strWherre);

            return GetList(dt);
        }
        /// <summary>
        /// 通过子IDs，获取所有父级
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="strWherre"></param>
        /// <returns></returns>
        public List<ClassLibrary.Model.RouteClass> GetParentList(string subIDs, string strWherre, string orderBy)
        {
            DataTable dt = dal.GetParentList(subIDs, strWherre, orderBy);

            return GetList(dt);
        }
        public List<ClassLibrary.Model.RouteClass> GetList(DataTable dt)
        {
            List<ClassLibrary.Model.RouteClass> modelList = new List<ClassLibrary.Model.RouteClass>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ClassLibrary.Model.RouteClass model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ClassLibrary.Model.RouteClass();
                    if (dt.Rows[n]["ID"] != DBNull.Value)
                    {
                        model.ID = Convert.ToInt32(dt.Rows[n]["ID"]);
                    }
                    if (dt.Rows[n]["ParentID"] != DBNull.Value)
                    {
                        model.ParentID = Convert.ToInt32(dt.Rows[n]["ParentID"]);
                    }
                    if (dt.Rows[n]["ClassName"] != DBNull.Value)
                    {
                        model.ClassName = Convert.ToString(dt.Rows[n]["ClassName"]);
                    }
                    if (dt.Rows[n]["CreatedTime"] != DBNull.Value)
                    {
                        model.CreatedTime = Convert.ToDateTime(dt.Rows[n]["CreatedTime"]);
                    }
                    if (dt.Rows[n]["Recommend"] != DBNull.Value)
                    {
                        model.Recommend = Convert.ToBoolean(dt.Rows[n]["Recommend"]);
                    }
                    if (dt.Rows[n]["seoTitle"] != DBNull.Value)
                    {
                        model.SeoTitle = Convert.ToString(dt.Rows[n]["seoTitle"]);
                    }
                    if (dt.Rows[n]["seoKeyword"] != DBNull.Value)
                    {
                        model.SeoKeyword = Convert.ToString(dt.Rows[n]["seoKeyword"]);
                    }
                    if (dt.Rows[n]["seoDesc"] != DBNull.Value)
                    {
                        model.SeoDesc = Convert.ToString(dt.Rows[n]["seoDesc"]);
                    }
                    if (dt.Rows[n]["classlevel"] != DBNull.Value)
                    {
                        model.ClassLevel = Convert.ToInt32(dt.Rows[n]["classlevel"]);
                    }
                    if (dt.Rows[n]["classNamePY"] != DBNull.Value)
                    {
                        model.ClassNamePY = Convert.ToString(dt.Rows[n]["classNamePY"]);
                    }
                    if (dt.Rows[n]["ClassOrder"] != DBNull.Value)
                    {
                        model.ClassOrder = Convert.ToInt32(dt.Rows[n]["ClassOrder"]);
                    }
                    if (dt.Rows[n]["ClassImg"] != DBNull.Value)
                    {
                        model.ClassImg = Convert.ToString(dt.Rows[n]["ClassImg"]);
                    }
                    if (dt.Rows[n]["IsHaidao"] != DBNull.Value)
                    {
                        model.IsHaidao = Convert.ToBoolean(dt.Rows[n]["IsHaidao"]);
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

 
        
        #endregion  成员方法
    }
}
