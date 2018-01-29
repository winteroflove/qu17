using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common;
using ClassLibrary.Model;

namespace ClassLibrary.BLL
{
    //RouteType
    public partial class RouteType
    {

        private readonly ClassLibrary.DAL.RouteType dal = new ClassLibrary.DAL.RouteType();
        public RouteType()
        { }

        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ClassLibrary.Model.RouteType model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ClassLibrary.Model.RouteType model)
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
        public ClassLibrary.Model.RouteType GetModel(int ID)
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
        public List<ClassLibrary.Model.RouteType> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ClassLibrary.Model.RouteType> GetModelList(string strWhere, string filedOrder)
        {
            DataTable ds = dal.GetList(0, strWhere, filedOrder);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ClassLibrary.Model.RouteType> DataTableToList(DataTable dt)
        {
            List<ClassLibrary.Model.RouteType> modelList = new List<ClassLibrary.Model.RouteType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ClassLibrary.Model.RouteType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ClassLibrary.Model.RouteType();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.ClassName = dt.Rows[n]["ClassName"].ToString();
                    if (dt.Rows[n]["Recommend"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Recommend"].ToString() == "1") || (dt.Rows[n]["Recommend"].ToString().ToLower() == "true"))
                        {
                            model.Recommend = true;
                        }
                        else
                        {
                            model.Recommend = false;
                        }
                    }
                    if (dt.Rows[n]["CreatedTime"].ToString() != "")
                    {
                        model.CreatedTime = DateTime.Parse(dt.Rows[n]["CreatedTime"].ToString());
                    }
                    model.seoTitle = dt.Rows[n]["seoTitle"].ToString();
                    model.seoKeyword = dt.Rows[n]["seoKeyword"].ToString();
                    model.seoDesc = dt.Rows[n]["seoDesc"].ToString();
                    model.classNamePY = dt.Rows[n]["classNamePY"].ToString();
                    if (dt.Rows[n]["ClassOrder"].ToString() != "")
                    {
                        model.ClassOrder = int.Parse(dt.Rows[n]["ClassOrder"].ToString());
                    }
                    model.ClassImg = dt.Rows[n]["ClassImg"].ToString();
                    model.AppClassImg = dt.Rows[n]["AppClassImg"].ToString();

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
        #endregion

    }
}