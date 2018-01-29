using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common;
using ClassLibrary.Model;

namespace ClassLibrary.BLL
{
    //RouteDetails
    public partial class RouteDetails
    {

        private readonly ClassLibrary.DAL.RouteDetails dal = new ClassLibrary.DAL.RouteDetails();
        public RouteDetails()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ClassLibrary.Model.RouteDetails model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ClassLibrary.Model.RouteDetails model)
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
        /// 删除线路数据
        /// </summary>
        public bool DeleteByRouteId(int ID)
        {
            return dal.DeleteByRouteId(ID);
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
        public ClassLibrary.Model.RouteDetails GetModel(int ID)
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
        public List<ClassLibrary.Model.RouteDetails> GetModelList(string strWhere)
        {
            DataTable dt = dal.GetList(strWhere);
            return DataTableToList(dt);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ClassLibrary.Model.RouteDetails> DataTableToList(DataTable dt)
        {
            List<ClassLibrary.Model.RouteDetails> modelList = new List<ClassLibrary.Model.RouteDetails>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ClassLibrary.Model.RouteDetails model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ClassLibrary.Model.RouteDetails();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["RouteID"].ToString() != "")
                    {
                        model.RouteID = int.Parse(dt.Rows[n]["RouteID"].ToString());
                    }
                    if (dt.Rows[n]["DayOrder"].ToString() != "")
                    {
                        model.DayOrder = int.Parse(dt.Rows[n]["DayOrder"].ToString());
                    }
                    model.DayDetail = dt.Rows[n]["DayDetail"].ToString();
                    model.DayTitle = dt.Rows[n]["DayTitle"].ToString();

                    if (dt.Rows[n]["BreakFast"].ToString() != "")
                    {
                        model.BreakFast = Convert.ToBoolean(dt.Rows[n]["BreakFast"].ToString());
                    }

                    if (dt.Rows[n]["Lunch"].ToString() != "")
                    {
                        model.Lunch = Convert.ToBoolean(dt.Rows[n]["Lunch"].ToString());
                    }
                    if (dt.Rows[n]["Dinner"].ToString() != "")
                    {
                        model.Dinner = Convert.ToBoolean(dt.Rows[n]["Dinner"].ToString());
                    }
                    if (dt.Rows[n]["BreakFastDesc"].ToString() != "")
                    {
                        model.Breakfastdesc = dt.Rows[n]["BreakFastDesc"].ToString();
                    }
                    else
                    {
                        model.Breakfastdesc = "";
                    }
                    if (dt.Rows[n]["LunchDesc"].ToString() != "")
                    {
                        model.Lunchdesc = dt.Rows[n]["LunchDesc"].ToString();
                    }
                    else
                    {
                        model.Lunchdesc = "";
                    }
                    if (dt.Rows[n]["DinnerDesc"].ToString() != "")
                    {
                        model.Dinnerdesc = dt.Rows[n]["DinnerDesc"].ToString();
                    }
                    else
                    {
                        model.Dinnerdesc = "";
                    }
                    if (dt.Rows[n]["Hotel"].ToString() != "")
                    {
                        model.Hotel = dt.Rows[n]["Hotel"].ToString();
                    }
                    else
                    {
                        model.Hotel = "";
                    }
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["titletype"].ToString() != "")
                    {
                        model.Titletype = Convert.ToBoolean(dt.Rows[n]["titletype"].ToString());
                    }
                    if (dt.Rows[n]["scenicnum"].ToString() != "")
                    {
                        model.Scenicnum = Convert.ToInt32(dt.Rows[n]["scenicnum"].ToString());
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
        #endregion

    }
}