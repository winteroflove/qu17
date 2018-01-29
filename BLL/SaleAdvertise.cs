using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common;
using ClassLibrary.Model;

namespace ClassLibrary.BLL
{
    //SaleAdvertise
    public partial class SaleAdvertise
    {

        private readonly ClassLibrary.DAL.SaleAdvertise dal = new ClassLibrary.DAL.SaleAdvertise();
        public SaleAdvertise()
        { }

        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ClassLibrary.Model.SaleAdvertise model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ClassLibrary.Model.SaleAdvertise model)
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
            return dal.Updates(sets, strWhere);
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
        public ClassLibrary.Model.SaleAdvertise GetModel(int ID)
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
        public List<ClassLibrary.Model.SaleAdvertise> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ClassLibrary.Model.SaleAdvertise> GetModelList(int Top, string strWhere, string filedOrder)
        {
            DataTable ds = dal.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ClassLibrary.Model.SaleAdvertise> DataTableToList(DataTable dt)
        {
            List<ClassLibrary.Model.SaleAdvertise> modelList = new List<ClassLibrary.Model.SaleAdvertise>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ClassLibrary.Model.SaleAdvertise model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ClassLibrary.Model.SaleAdvertise();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.LinkUrl = dt.Rows[n]["LinkUrl"].ToString();
                    model.Img = dt.Rows[n]["Img"].ToString();
                    model.RouteClassId = dt.Rows[n]["RouteClassId"].ToString();
                    if (dt.Rows[n]["CreatedTime"].ToString() != "")
                    {
                        model.CreatedTime = DateTime.Parse(dt.Rows[n]["CreatedTime"].ToString());
                    }
                    if (dt.Rows[n]["SaleOrder"].ToString() != "")
                    {
                        model.SaleOrder = int.Parse(dt.Rows[n]["SaleOrder"].ToString());
                    }
                    if (dt.Rows[n]["ExpiredTime"].ToString() != "")
                    {
                        model.ExpiredTime = DateTime.Parse(dt.Rows[n]["ExpiredTime"].ToString());
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