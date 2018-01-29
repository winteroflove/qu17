using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common;
using ClassLibrary.Model;

namespace ClassLibrary.BLL
{
    //SeoInfo
    public partial class SeoInfo
    {

        private readonly ClassLibrary.DAL.SeoInfo dal = new ClassLibrary.DAL.SeoInfo();
        public SeoInfo()
        { }

        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ClassLibrary.Model.SeoInfo model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ClassLibrary.Model.SeoInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ClassLibrary.Model.SeoInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ClassLibrary.Model.SeoInfo> GetModelList(int Top, string strWhere, string filedOrder)
        {
            DataTable ds = dal.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ClassLibrary.Model.SeoInfo> GetModelList(string strWhere, string filedOrder)
        {
            DataTable ds = dal.GetList(0, strWhere, filedOrder);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ClassLibrary.Model.SeoInfo> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ClassLibrary.Model.SeoInfo> DataTableToList(DataTable dt)
        {
            List<ClassLibrary.Model.SeoInfo> modelList = new List<ClassLibrary.Model.SeoInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ClassLibrary.Model.SeoInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ClassLibrary.Model.SeoInfo();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["RouteClassID"].ToString() != "")
                    {
                        model.RouteClassID = int.Parse(dt.Rows[n]["RouteClassID"].ToString());
                    }
                    if (dt.Rows[n]["MaxClassId"].ToString() != "")
                    {
                        model.MaxClassId = int.Parse(dt.Rows[n]["MaxClassId"].ToString());
                    }
                    if (dt.Rows[n]["ThemeId"].ToString() != "")
                    {
                        model.ThemeId = int.Parse(dt.Rows[n]["ThemeId"].ToString());
                    }
                    model.Price = dt.Rows[n]["Price"].ToString();
                    if (dt.Rows[n]["Days"].ToString() != "")
                    {
                        model.Days = int.Parse(dt.Rows[n]["Days"].ToString());
                    }
                    model.SeoTitle = dt.Rows[n]["SeoTitle"].ToString();
                    model.SeoKeyword = dt.Rows[n]["SeoKeyword"].ToString();
                    model.SeoDescription = dt.Rows[n]["SeoDescription"].ToString();
                    if (dt.Rows[n]["CreatedTime"].ToString() != "")
                    {
                        model.CreatedTime = DateTime.Parse(dt.Rows[n]["CreatedTime"].ToString());
                    }

                    if (dt.Rows[n]["Month"].ToString() != "")
                    {
                        model.Month = int.Parse(dt.Rows[n]["Month"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetAllList()
        {
            return GetList("");
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
        #endregion

    }
}