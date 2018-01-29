using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary.DAL
{
    //RouteType
    public partial class RouteType
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ClassLibrary.Model.RouteType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RouteType(");
            strSql.Append("ClassName,Recommend,CreatedTime,seoTitle,seoKeyword,seoDesc,classNamePY,ClassOrder,ClassImg,AppClassImg");
            strSql.Append(") values (");
            strSql.Append("@ClassName,@Recommend,@CreatedTime,@seoTitle,@seoKeyword,@seoDesc,@classNamePY,@ClassOrder,@ClassImg,@AppClassImg");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ClassName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@Recommend", SqlDbType.Bit,1) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@seoTitle", SqlDbType.NVarChar,80) ,            
                        new SqlParameter("@seoKeyword", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@seoDesc", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@classNamePY", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@ClassOrder", SqlDbType.Int,4) ,            
                        new SqlParameter("@ClassImg", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AppClassImg",SqlDbType.NVarChar,50)
            };

            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.Recommend;
            parameters[2].Value = model.CreatedTime;
            parameters[3].Value = model.seoTitle;
            parameters[4].Value = model.seoKeyword;
            parameters[5].Value = model.seoDesc;
            parameters[6].Value = model.classNamePY;
            parameters[7].Value = model.ClassOrder;
            parameters[8].Value = model.ClassImg;
            parameters[9].Value = model.AppClassImg;

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
        public bool Update(ClassLibrary.Model.RouteType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RouteType set ");

            strSql.Append(" ClassName = @ClassName , ");
            strSql.Append(" Recommend = @Recommend , ");
            strSql.Append(" CreatedTime = @CreatedTime , ");
            strSql.Append(" seoTitle = @seoTitle , ");
            strSql.Append(" seoKeyword = @seoKeyword , ");
            strSql.Append(" seoDesc = @seoDesc , ");
            strSql.Append(" classNamePY = @classNamePY , ");
            strSql.Append(" ClassOrder = @ClassOrder , ");
            strSql.Append(" ClassImg = @ClassImg , ");
            strSql.Append(" AppClassImg = @AppClassImg  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ClassName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@Recommend", SqlDbType.Bit,1) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@seoTitle", SqlDbType.NVarChar,80) ,            
                        new SqlParameter("@seoKeyword", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@seoDesc", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@classNamePY", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@ClassOrder", SqlDbType.Int,4) ,            
                        new SqlParameter("@ClassImg", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AppClassImg", SqlDbType.NVarChar,50)    
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.Recommend;
            parameters[3].Value = model.CreatedTime;
            parameters[4].Value = model.seoTitle;
            parameters[5].Value = model.seoKeyword;
            parameters[6].Value = model.seoDesc;
            parameters[7].Value = model.classNamePY;
            parameters[8].Value = model.ClassOrder;
            parameters[9].Value = model.ClassImg;
            parameters[10].Value = model.AppClassImg;

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
            strSql.Append("delete from RouteType ");
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
            strSql.Append("delete from RouteType ");
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
        public ClassLibrary.Model.RouteType GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ClassName, Recommend, CreatedTime, seoTitle, seoKeyword, seoDesc, classNamePY, ClassOrder, ClassImg, AppClassImg ");
            strSql.Append("  from RouteType ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            ClassLibrary.Model.RouteType model = new ClassLibrary.Model.RouteType();
            DataTable ds = SQLHelper.Query(strSql.ToString(), parameters);

            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Rows[0]["ID"].ToString());
                }
                model.ClassName = ds.Rows[0]["ClassName"].ToString();
                if (ds.Rows[0]["Recommend"].ToString() != "")
                {
                    if ((ds.Rows[0]["Recommend"].ToString() == "1") || (ds.Rows[0]["Recommend"].ToString().ToLower() == "true"))
                    {
                        model.Recommend = true;
                    }
                    else
                    {
                        model.Recommend = false;
                    }
                }
                if (ds.Rows[0]["CreatedTime"].ToString() != "")
                {
                    model.CreatedTime = DateTime.Parse(ds.Rows[0]["CreatedTime"].ToString());
                }
                model.seoTitle = ds.Rows[0]["seoTitle"].ToString();
                model.seoKeyword = ds.Rows[0]["seoKeyword"].ToString();
                model.seoDesc = ds.Rows[0]["seoDesc"].ToString();
                model.classNamePY = ds.Rows[0]["classNamePY"].ToString();
                if (ds.Rows[0]["ClassOrder"].ToString() != "")
                {
                    model.ClassOrder = int.Parse(ds.Rows[0]["ClassOrder"].ToString());
                }
                model.ClassImg = ds.Rows[0]["ClassImg"].ToString();
                model.AppClassImg = ds.Rows[0]["AppClassImg"].ToString();
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
            strSql.Append(" FROM RouteType ");
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
            strSql.Append(" FROM RouteType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SQLHelper.Query(strSql.ToString());
        }


    }
}

