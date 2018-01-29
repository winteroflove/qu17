using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary.DAL
{
    //Customers
    public partial class Customers
    {
        /// <summary>
        /// 表名
        /// </summary>
        private static readonly string table = "Customers";
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ClassLibrary.Model.Customers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Customers(");
            strSql.Append("Name,QQ,QQorder,CreatedTime,InUse,QQtype,Phone");
            strSql.Append(") values (");
            strSql.Append("@Name,@QQ,@QQorder,@CreatedTime,@InUse,@QQtype,@Phone");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Name", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@QQ", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@QQorder", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@InUse", SqlDbType.Bit,1) ,            
                        new SqlParameter("@QQtype", SqlDbType.Int,4) ,             
                        new SqlParameter("@Phone", SqlDbType.NVarChar, 20)
            };

            parameters[0].Value = model.Name;
            parameters[1].Value = model.QQ;
            parameters[2].Value = model.QQorder;
            parameters[3].Value = model.CreatedTime;
            parameters[4].Value = model.InUse;
            parameters[5].Value = model.QQtype;
            parameters[6].Value = model.Phone;

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
        public bool Update(ClassLibrary.Model.Customers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Customers set ");

            strSql.Append(" Name = @Name , ");
            strSql.Append(" QQ = @QQ , ");
            strSql.Append(" QQorder = @QQorder , ");
            strSql.Append(" CreatedTime = @CreatedTime , ");
            strSql.Append(" InUse = @InUse , ");
            strSql.Append(" QQtype = @QQtype , ");
            strSql.Append(" Phone = @Phone ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@QQ", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@QQorder", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@InUse", SqlDbType.Bit,1) ,            
                        new SqlParameter("@QQtype", SqlDbType.Int,4) ,             
                        new SqlParameter("@Phone", SqlDbType.NVarChar, 20)
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.QQ;
            parameters[3].Value = model.QQorder;
            parameters[4].Value = model.CreatedTime;
            parameters[5].Value = model.InUse;
            parameters[6].Value = model.QQtype;
            parameters[7].Value = model.Phone;

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
            strSql.Append("delete from Customers ");
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
            strSql.Append("delete from Customers ");
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
        public ClassLibrary.Model.Customers GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, Name, QQ, QQorder, CreatedTime, InUse, QQtype, Phone ");
            strSql.Append("  from Customers ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            ClassLibrary.Model.Customers model = new ClassLibrary.Model.Customers();
            DataTable ds = SQLHelper.Query(strSql.ToString(), parameters);

            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Rows[0]["ID"].ToString());
                }
                model.Name = ds.Rows[0]["Name"].ToString();
                model.QQ = ds.Rows[0]["QQ"].ToString();
                if (ds.Rows[0]["QQorder"].ToString() != "")
                {
                    model.QQorder = int.Parse(ds.Rows[0]["QQorder"].ToString());
                }
                if (ds.Rows[0]["CreatedTime"].ToString() != "")
                {
                    model.CreatedTime = DateTime.Parse(ds.Rows[0]["CreatedTime"].ToString());
                }
                if (ds.Rows[0]["InUse"].ToString() != "")
                {
                    if ((ds.Rows[0]["InUse"].ToString() == "1") || (ds.Rows[0]["InUse"].ToString().ToLower() == "true"))
                    {
                        model.InUse = true;
                    }
                    else
                    {
                        model.InUse = false;
                    }
                }
                if (ds.Rows[0]["QQtype"].ToString() != "")
                {
                    model.QQtype = Convert.ToInt32(ds.Rows[0]["QQtype"].ToString());
                }
                model.Phone = ds.Rows[0]["Phone"].ToString();
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
            strSql.Append(" FROM Customers ");
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
            strSql.Append(" FROM Customers ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SQLHelper.Query(strSql.ToString());
        }

        public int UpdateOrder(int Id, int qqOrder)
        {
            return SQLHelper.Updates(table, "QQorder = '" + qqOrder + "'", "Id = '" + Id + "'");
        }

        public int UpdateInuse(int Id, bool inuse)
        {
            return SQLHelper.Updates(table, "InUse = '" + inuse + "'", "Id = '" + Id + "'");
        }
    }
}

