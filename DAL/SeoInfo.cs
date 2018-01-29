using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary.DAL
{
    //SeoInfo
    public partial class SeoInfo
    {
        /// <summary>
        /// 表名
        /// </summary>
        private static readonly string table = "SeoInfo";
        /// <summary>
        /// 主键列
        /// </summary>
        private static readonly string pk = "ID";
        /// <summary>
        /// 排序
        /// </summary>
        private static readonly string orderby = " ID DESC";
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
        /// 增加一条数据
        /// </summary>
        public int Add(ClassLibrary.Model.SeoInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SeoInfo(");
            strSql.Append("RouteClassID,ThemeId,Price,Days,SeoTitle,SeoKeyword,SeoDescription,CreatedTime,MaxClassId,Month");
            strSql.Append(") values (");
            strSql.Append("@RouteClassID,@ThemeId,@Price,@Days,@SeoTitle,@SeoKeyword,@SeoDescription,@CreatedTime,@MaxClassId,@Month");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@RouteClassID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ThemeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Price", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@Days", SqlDbType.Int,4) ,            
                        new SqlParameter("@SeoTitle", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SeoKeyword", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@SeoDescription", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@MaxClassId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Month", SqlDbType.Int,4)
            };

            parameters[0].Value = model.RouteClassID;
            parameters[1].Value = model.ThemeId;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.Days;
            parameters[4].Value = model.SeoTitle;
            parameters[5].Value = model.SeoKeyword;
            parameters[6].Value = model.SeoDescription;
            parameters[7].Value = model.CreatedTime;
            parameters[8].Value = model.MaxClassId;
            parameters[9].Value = model.Month;

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
        public bool Update(ClassLibrary.Model.SeoInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SeoInfo set ");

            strSql.Append(" RouteClassID = @RouteClassID , ");
            strSql.Append(" ThemeId = @ThemeId , ");
            strSql.Append(" Price = @Price , ");
            strSql.Append(" Days = @Days , ");
            strSql.Append(" SeoTitle = @SeoTitle , ");
            strSql.Append(" SeoKeyword = @SeoKeyword , ");
            strSql.Append(" SeoDescription = @SeoDescription , ");
            strSql.Append(" CreatedTime = @CreatedTime , ");
            strSql.Append(" MaxClassId = @MaxClassId , ");
            strSql.Append(" Month = @Month  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RouteClassID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ThemeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Price", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@Days", SqlDbType.Int,4) ,            
                        new SqlParameter("@SeoTitle", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SeoKeyword", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@SeoDescription", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@MaxClassId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Month", SqlDbType.Int,4)
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.RouteClassID;
            parameters[2].Value = model.ThemeId;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.Days;
            parameters[5].Value = model.SeoTitle;
            parameters[6].Value = model.SeoKeyword;
            parameters[7].Value = model.SeoDescription;
            parameters[8].Value = model.CreatedTime;
            parameters[9].Value = model.MaxClassId;
            parameters[10].Value = model.Month;

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
            strSql.Append("delete from SeoInfo ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
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
            strSql.Append("delete from SeoInfo ");
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
        public ClassLibrary.Model.SeoInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, RouteClassID, ThemeId, Price, Days, SeoTitle, SeoKeyword, SeoDescription, CreatedTime, MaxClassId, Month ");
            strSql.Append("  from SeoInfo ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            ClassLibrary.Model.SeoInfo model = new ClassLibrary.Model.SeoInfo();
            DataTable ds = SQLHelper.Query(strSql.ToString(), parameters);

            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Rows[0]["ID"].ToString());
                }
                if (ds.Rows[0]["RouteClassID"].ToString() != "")
                {
                    model.RouteClassID = int.Parse(ds.Rows[0]["RouteClassID"].ToString());
                }
                if (ds.Rows[0]["MaxClassId"].ToString() != "")
                {
                    model.MaxClassId = int.Parse(ds.Rows[0]["MaxClassId"].ToString());
                }
                if (ds.Rows[0]["ThemeId"].ToString() != "")
                {
                    model.ThemeId = int.Parse(ds.Rows[0]["ThemeId"].ToString());
                }
                model.Price = ds.Rows[0]["Price"].ToString();
                if (ds.Rows[0]["Days"].ToString() != "")
                {
                    model.Days = int.Parse(ds.Rows[0]["Days"].ToString());
                }
                model.SeoTitle = ds.Rows[0]["SeoTitle"].ToString();
                model.SeoKeyword = ds.Rows[0]["SeoKeyword"].ToString();
                model.SeoDescription = ds.Rows[0]["SeoDescription"].ToString();
                if (ds.Rows[0]["CreatedTime"].ToString() != "")
                {
                    model.CreatedTime = DateTime.Parse(ds.Rows[0]["CreatedTime"].ToString());
                }
                if (ds.Rows[0]["Month"].ToString() != "")
                {
                    model.Month = int.Parse(ds.Rows[0]["Month"].ToString());
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
            strSql.Append(" FROM SeoInfo ");
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
            strSql.Append(" FROM SeoInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SQLHelper.Query(strSql.ToString());
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
            return SQLHelper.GetPageData(pageSize, pageNum
                    , "ID,RouteClassID,ThemeId,Price,Days,SeoTitle,SeoKeyword,SeoDescription,CreatedTime,MaxClassId,Month"
                    , table
                    , pk, strWhere, getOrder(orderBy));
        }

    }
}

