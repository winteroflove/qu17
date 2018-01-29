using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common;
using ClassLibrary.Model;

namespace ClassLibrary.BLL
{
    //Customers
    public partial class Customers
    {

        private readonly ClassLibrary.DAL.Customers dal = new ClassLibrary.DAL.Customers();
        public Customers()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ClassLibrary.Model.Customers model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ClassLibrary.Model.Customers model)
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
        public ClassLibrary.Model.Customers GetModel(int ID)
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
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere, string filedOrder)
        {
            return dal.GetList(0, strWhere, filedOrder);
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
        public List<ClassLibrary.Model.Customers> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ClassLibrary.Model.Customers> DataTableToList(DataTable dt)
        {
            List<ClassLibrary.Model.Customers> modelList = new List<ClassLibrary.Model.Customers>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ClassLibrary.Model.Customers model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ClassLibrary.Model.Customers();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.QQ = dt.Rows[n]["QQ"].ToString();
                    if (dt.Rows[n]["QQorder"].ToString() != "")
                    {
                        model.QQorder = int.Parse(dt.Rows[n]["QQorder"].ToString());
                    }
                    if (dt.Rows[n]["CreatedTime"].ToString() != "")
                    {
                        model.CreatedTime = DateTime.Parse(dt.Rows[n]["CreatedTime"].ToString());
                    }
                    if (dt.Rows[n]["InUse"].ToString() != "")
                    {
                        if ((dt.Rows[n]["InUse"].ToString() == "1") || (dt.Rows[n]["InUse"].ToString().ToLower() == "true"))
                        {
                            model.InUse = true;
                        }
                        else
                        {
                            model.InUse = false;
                        }
                    }
                    if (dt.Rows[n]["QQtype"].ToString() != "")
                    {
                        model.QQtype = Convert.ToInt32(dt.Rows[n]["QQtype"].ToString());
                    }
                    model.Phone = dt.Rows[n]["Phone"].ToString();
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

        public int UpdateOrder(int Id, int qqOrder)
        {
            return dal.UpdateOrder(Id, qqOrder);
        }

        public int UpdateInuse(int Id, bool inuse)
        {
            return dal.UpdateInuse(Id, inuse);
        }
        #endregion

    }
}