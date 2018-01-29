using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary.DAL
{
    //SaleAdvertise
    public partial class SaleAdvertise
    {
        #region  常用变量
        /// <summary>
        /// 表名
        /// </summary>
        private static readonly string table = "SaleAdvertise";
        /// <summary>
        /// 主键列
        /// </summary>
        private static readonly string pk = "ID";
        /// <summary>
        /// 排序
        /// </summary>
        private static readonly string orderby = " ID DESC";

        #endregion
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
        public int Add(ClassLibrary.Model.SaleAdvertise model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SaleAdvertise(");
            strSql.Append("Title,LinkUrl,Img,RouteClassId,CreatedTime,SaleOrder,ExpiredTime");
            strSql.Append(") values (");
            strSql.Append("@Title,@LinkUrl,@Img,@RouteClassId,@CreatedTime,@SaleOrder,@ExpiredTime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Title", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@LinkUrl", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@Img", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@RouteClassId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime),
                        new SqlParameter("@SaleOrder", SqlDbType.Int,4),
                        new SqlParameter("@ExpiredTime", SqlDbType.DateTime)
            };

            parameters[0].Value = model.Title;
            parameters[1].Value = model.LinkUrl;
            parameters[2].Value = model.Img;
            parameters[3].Value = model.RouteClassId;
            parameters[4].Value = model.CreatedTime;
            parameters[5].Value = model.SaleOrder;
            parameters[6].Value = model.ExpiredTime;

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
        public bool Update(ClassLibrary.Model.SaleAdvertise model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SaleAdvertise set ");

            strSql.Append(" Title = @Title , ");
            strSql.Append(" LinkUrl = @LinkUrl , ");
            strSql.Append(" Img = @Img , ");
            strSql.Append(" RouteClassId = @RouteClassId , ");
            strSql.Append(" CreatedTime = @CreatedTime , ");
            strSql.Append(" SaleOrder = @SaleOrder , ");
            strSql.Append(" ExpiredTime = @ExpiredTime  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Title", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@LinkUrl", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@Img", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@RouteClassId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime),
                        new SqlParameter("@SaleOrder", SqlDbType.Int,4),
                        new SqlParameter("@ExpiredTime", SqlDbType.DateTime)
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.LinkUrl;
            parameters[3].Value = model.Img;
            parameters[4].Value = model.RouteClassId;
            parameters[5].Value = model.CreatedTime;
            parameters[6].Value = model.SaleOrder;
            parameters[7].Value = model.ExpiredTime;

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
        /// 更新多条记录
        /// </summary>
        /// <param name="sets">设置内容(例:id=1,name='aaa')</param>
        /// <param name="strWhere">条件</param>
        /// <returns>影响行数</returns>
        public int Updates(string sets, string strWhere)
        {
            return SQLHelper.Updates(table, sets, strWhere);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SaleAdvertise ");
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
            strSql.Append("delete from SaleAdvertise ");
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
        public ClassLibrary.Model.SaleAdvertise GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, Title, LinkUrl, Img, RouteClassId, CreatedTime, SaleOrder, ExpiredTime ");
            strSql.Append("  from SaleAdvertise ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            ClassLibrary.Model.SaleAdvertise model = new ClassLibrary.Model.SaleAdvertise();
            DataTable ds = SQLHelper.Query(strSql.ToString(), parameters);

            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Rows[0]["ID"].ToString());
                }
                model.Title = ds.Rows[0]["Title"].ToString();
                model.LinkUrl = ds.Rows[0]["LinkUrl"].ToString();
                model.Img = ds.Rows[0]["Img"].ToString();
                model.RouteClassId = ds.Rows[0]["RouteClassId"].ToString();
                if (ds.Rows[0]["CreatedTime"].ToString() != "")
                {
                    model.CreatedTime = DateTime.Parse(ds.Rows[0]["CreatedTime"].ToString());
                }
                if (ds.Rows[0]["SaleOrder"].ToString() != "")
                {
                    model.SaleOrder = int.Parse(ds.Rows[0]["SaleOrder"].ToString());
                }
                if (ds.Rows[0]["ExpiredTime"].ToString() != "")
                {
                    model.ExpiredTime = DateTime.Parse(ds.Rows[0]["ExpiredTime"].ToString());
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
            strSql.Append(" FROM SaleAdvertise ");
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
            strSql.Append(" FROM SaleAdvertise ");
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
                    , "ID, Title, LinkUrl, Img, RouteClassId, CreatedTime, SaleOrder, ExpiredTime "
                    , table
                    , pk, strWhere, getOrder(orderBy));
        }
    }
}

