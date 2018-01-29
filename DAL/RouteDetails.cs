using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary.DAL
{
    //RouteDetails
    public partial class RouteDetails
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ClassLibrary.Model.RouteDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into routedetails(");
            strSql.Append("RouteID,DayOrder,DayDetail,BreakFast,Lunch,Dinner,Hotel,CreateTime,DayTitle,breakfastdesc,lunchdesc,dinnerdesc,titletype,scenicnum ");
            strSql.Append(") values (");
            strSql.Append("@RouteID,@DayOrder,@DayDetail,@BreakFast,@Lunch,@Dinner,@Hotel,@CreateTime,@DayTitle,@breakfastdesc,@lunchdesc,@dinnerdesc,@titletype,@scenicnum");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@RouteID", SqlDbType.Int,6) ,
                        new SqlParameter("@DayOrder", SqlDbType.Int,4) ,
                        new SqlParameter("@DayDetail", SqlDbType.NText) ,
                        new SqlParameter("@BreakFast", SqlDbType.Bit,1) , 
                        new SqlParameter("@Lunch", SqlDbType.Bit,1) ,
                        new SqlParameter("@Dinner", SqlDbType.Bit,1) ,
                        new SqlParameter("@Hotel", SqlDbType.NVarChar,20) , 
                        new SqlParameter("@CreateTime", SqlDbType.DateTime,8),
                        new SqlParameter("@DayTitle", SqlDbType.NVarChar,500),
                        new SqlParameter("@breakfastdesc", SqlDbType.NVarChar,50),
                        new SqlParameter("@lunchdesc", SqlDbType.NVarChar,50),
                        new SqlParameter("@dinnerdesc", SqlDbType.NVarChar,50),
                        new SqlParameter("@titletype", SqlDbType.Bit,1),
                        new SqlParameter("@scenicnum", SqlDbType.Int,4)};

            parameters[0].Value = model.RouteID;
            parameters[1].Value = model.DayOrder;
            parameters[2].Value = model.DayDetail;
            parameters[3].Value = model.BreakFast;
            parameters[4].Value = model.Lunch;
            parameters[5].Value = model.Dinner;
            parameters[6].Value = model.Hotel;
            parameters[7].Value = model.CreateTime;
            parameters[8].Value = model.DayTitle;
            parameters[9].Value = model.Breakfastdesc;
            parameters[10].Value = model.Lunchdesc;
            parameters[11].Value = model.Dinnerdesc;
            parameters[12].Value = model.Titletype;
            parameters[13].Value = model.Scenicnum;

            object obj = SQLHelper.Execute(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ClassLibrary.Model.RouteDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update routedetails set ");

            strSql.Append(" RouteID = @RouteID , ");
            strSql.Append(" DayOrder = @DayOrder , ");
            strSql.Append(" DayDetail = @DayDetail , ");
            strSql.Append(" BreakFast = @BreakFast , ");
            strSql.Append(" Lunch = @Lunch , ");
            strSql.Append(" Dinner = @Dinner , ");
            strSql.Append(" Hotel = @Hotel , ");
            strSql.Append(" CreateTime = @CreateTime,  ");
            strSql.Append(" DayTitle = @DayTitle,  ");
            strSql.Append(" breakfastdesc = @breakfastdesc,  ");
            strSql.Append(" lunchdesc = @lunchdesc,  ");
            strSql.Append(" dinnerdesc = @dinnerdesc,  ");
            strSql.Append(" titletype = @titletype,  ");
            strSql.Append(" scenicnum = @scenicnum  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,6) ,            
                        new SqlParameter("@RouteID", SqlDbType.Int,6) ,            
                        new SqlParameter("@DayOrder", SqlDbType.Int,4) ,            
                        new SqlParameter("@DayDetail", SqlDbType.NText) ,            
                        new SqlParameter("@BreakFast", SqlDbType.Bit,1) , 
                        new SqlParameter("@Lunch", SqlDbType.Bit,1) ,
                        new SqlParameter("@Dinner", SqlDbType.Bit,1) ,          
                        new SqlParameter("@Hotel", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime),             
                        new SqlParameter("@DayTitle", SqlDbType.NVarChar,500),
                        new SqlParameter("@breakfastdesc", SqlDbType.NVarChar,50),
                        new SqlParameter("@lunchdesc", SqlDbType.NVarChar,50),
                        new SqlParameter("@dinnerdesc", SqlDbType.NVarChar,50),
                        new SqlParameter("@titletype", SqlDbType.Bit,1),
                        new SqlParameter("@scenicnum", SqlDbType.Int,4)};

            parameters[0].Value = model.ID;
            parameters[1].Value = model.RouteID;
            parameters[2].Value = model.DayOrder;
            parameters[3].Value = model.DayDetail;
            parameters[4].Value = model.BreakFast;
            parameters[5].Value = model.Lunch;
            parameters[6].Value = model.Dinner;
            parameters[7].Value = model.Hotel;
            parameters[8].Value = model.CreateTime;
            parameters[9].Value = model.DayTitle;
            parameters[10].Value = model.Breakfastdesc;
            parameters[11].Value = model.Lunchdesc;
            parameters[12].Value = model.Dinnerdesc;
            parameters[13].Value = model.Titletype;
            parameters[14].Value = model.Scenicnum;

            int rows = SQLHelper.Execute(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from routedetails ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,6)
			};
            parameters[0].Value = ID;


            int rows = SQLHelper.Execute(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除线路数据
        /// </summary>
        public bool DeleteByRouteId(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from routedetails ");
            strSql.Append(" where RouteID=@RouteID");
            SqlParameter[] parameters = {
					new SqlParameter("@RouteID", SqlDbType.Int,6)
			};
            parameters[0].Value = ID;


            int rows = SQLHelper.Execute(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from routedetails ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = SQLHelper.Execute(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ClassLibrary.Model.RouteDetails GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RouteID,DayOrder,DayDetail,BreakFast,Lunch,Dinner,Hotel,CreateTime,DayTitle,breakfastdesc,lunchdesc,dinnerdesc,titletype,scenicnum  ");
            strSql.Append("  from routedetails ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,6)
			};
            parameters[0].Value = ID;


            ClassLibrary.Model.RouteDetails model = new ClassLibrary.Model.RouteDetails();
            DataTable ds = SQLHelper.Query(strSql.ToString(), parameters);

            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Rows[0]["ID"].ToString());
                }
                if (ds.Rows[0]["RouteID"].ToString() != "")
                {
                    model.RouteID = int.Parse(ds.Rows[0]["RouteID"].ToString());
                }
                if (ds.Rows[0]["DayOrder"].ToString() != "")
                {
                    model.DayOrder = int.Parse(ds.Rows[0]["DayOrder"].ToString());
                }
                model.DayDetail = ds.Rows[0]["DayDetail"].ToString();
                model.DayTitle = ds.Rows[0]["DayTitle"].ToString();

                if (ds.Rows[0]["BreakFast"].ToString() != "")
                {
                    model.BreakFast = Convert.ToBoolean(ds.Rows[0]["BreakFast"].ToString());
                }
                if (ds.Rows[0]["Lunch"].ToString() != "")
                {
                    model.Lunch = Convert.ToBoolean(ds.Rows[0]["Lunch"].ToString());
                }
                if (ds.Rows[0]["Dinner"].ToString() != "")
                {
                    model.Dinner = Convert.ToBoolean(ds.Rows[0]["Dinner"].ToString());
                }
                if (ds.Rows[0]["BreakFastDesc"].ToString() != "")
                {
                    model.Breakfastdesc = ds.Rows[0]["BreakFastDesc"].ToString();
                }
                else
                {
                    model.Breakfastdesc = "";
                }
                if (ds.Rows[0]["LunchDesc"].ToString() != "")
                {
                    model.Lunchdesc = ds.Rows[0]["LunchDesc"].ToString();
                }
                else
                {
                    model.Lunchdesc = "";
                }
                if (ds.Rows[0]["DinnerDesc"].ToString() != "")
                {
                    model.Dinnerdesc = ds.Rows[0]["DinnerDesc"].ToString();
                }
                else
                {
                    model.Dinnerdesc = "";
                }
                if (ds.Rows[0]["Hotel"].ToString() != "")
                {
                    model.Hotel = ds.Rows[0]["Hotel"].ToString();
                }
                else
                {
                    model.Hotel = "";
                }
                if (ds.Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Rows[0]["CreateTime"].ToString());
                }
                if (ds.Rows[0]["titletype"].ToString() != "")
                {
                    model.Titletype = Convert.ToBoolean(ds.Rows[0]["titletype"].ToString());
                }
                if (ds.Rows[0]["scenicnum"].ToString() != "")
                {
                    model.Scenicnum = Convert.ToInt32(ds.Rows[0]["scenicnum"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM routedetails ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SQLHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM routedetails ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SQLHelper.Query(strSql.ToString());
        }
    }
}

