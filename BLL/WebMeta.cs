/*----------------------------------------*/



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
    /// 业务逻辑类 [WebMeta] 的摘要说明。
    /// </summary>
    public class WebMeta
    {
        #region  常用变量
        /// <summary>
        /// 数据操作实例
        /// </summary>
        private readonly ClassLibrary.DAL.WebMeta dal = new ClassLibrary.DAL.WebMeta();
        //private readonly IWebMeta dal = DataAccess.CreateWebMeta();
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
        public int Add(ClassLibrary.Model.WebMeta model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">model对象</param>
        /// <returns>影响行数</returns>
        public int Update(ClassLibrary.Model.WebMeta model)
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
        /// <returns>WebMeta对象</returns>
        public ClassLibrary.Model.WebMeta GetModel(int ID)
        {
            return dal.GetModel(ID);
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>WebMeta集合</returns>
        public List<ClassLibrary.Model.WebMeta> GetModelList(string strWhere)
        {
            DataTable dt = GetData(strWhere);
            List<ClassLibrary.Model.WebMeta> modelList = new List<ClassLibrary.Model.WebMeta>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ClassLibrary.Model.WebMeta model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ClassLibrary.Model.WebMeta();
                    if (dt.Rows[n]["ID"] != DBNull.Value)
					{
						model.ID = Convert.ToInt32(dt.Rows[n]["ID"]);
					}
                    if (dt.Rows[n]["Title"] != DBNull.Value)
					{
						model.Title = Convert.ToString(dt.Rows[n]["Title"]);
					}
                    if (dt.Rows[n]["Keyword"] != DBNull.Value)
					{
						model.Keyword = Convert.ToString(dt.Rows[n]["Keyword"]);
					}
                    if (dt.Rows[n]["Description"] != DBNull.Value)
					{
						model.Description = Convert.ToString(dt.Rows[n]["Description"]);
					}
                    if (dt.Rows[n]["Telphone"] != DBNull.Value)
					{
						model.Telphone = Convert.ToString(dt.Rows[n]["Telphone"]);
                    }
                    if (dt.Rows[n]["QQ"] != DBNull.Value)
                    {
                        model.QQ = Convert.ToString(dt.Rows[n]["QQ"]);
                    }
					if (dt.Rows[n]["OnlineService"] != DBNull.Value)
                    {
                        model.OnlineService = Convert.ToString(dt.Rows[n]["OnlineService"]);
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
