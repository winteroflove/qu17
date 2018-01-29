using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    /// <summary>
    /// SQLHelper 的摘要说明
    /// 功能：操作数据库的基础类
    /// 作者：HE
    /// 编写时间：2008-08-08
    /// </summary>
    public abstract class SQLHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string strConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }

        #region 基础部分

        /// <summary>
        /// 执行SQL语句返回影响行数的方法
        /// </summary>
        /// <param name="strSql">要执行的SQL语句</param>
        /// <returns>影响行数</returns>
        public static int Execute(string strSql)
        {
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                SqlCommand myCmd = new SqlCommand(strSql, sqlConnection);
                try
                {
					sqlConnection.Open();
                    return myCmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    myCmd.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// SQL事务执行多条SQL语句
        /// </summary>
        /// <param name="listSql">要执行的语句集合</param>
        /// <returns>影响总行数</returns>
        public static int Executes(List<string> listSql)
        {
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                sqlConnection.Open();
                using (SqlTransaction myTrans = sqlConnection.BeginTransaction())
                {
                    SqlCommand myCmd = new SqlCommand();
                    int count = 0;
                    try
                    {
                        myCmd.Connection = sqlConnection;
                        myCmd.Transaction = myTrans;
                        for (int i = 0; i < listSql.Count; i++)
                        {
                            myCmd.CommandText = listSql[i];
                            count += myCmd.ExecuteNonQuery();
                        }
                        myTrans.Commit();
                        return count;
                    }
                    catch
                    {
                        myTrans.Rollback();
                        throw;
                    }
                    finally
                    {
                        myCmd.Dispose();
                        sqlConnection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 事务执行多条SQL语句
        /// </summary>
        /// <param name="dicSql">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        /// <returns>影响总行数</returns>
        public static int Executes(Dictionary<string, SqlParameter[]> dicSql)
        {
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                sqlConnection.Open();
                using (SqlTransaction myTrans = sqlConnection.BeginTransaction())
                {
                    SqlCommand myCmd = new SqlCommand();
                    int count = 0;
                    try
                    {
                        myCmd.Connection = sqlConnection;
                        myCmd.Transaction = myTrans;
                        foreach (string key in dicSql.Keys)
                        {
                            string cmdText = key;
                            PrepareCommand(myCmd, sqlConnection, myTrans, cmdText, dicSql[key]);
                            count += myCmd.ExecuteNonQuery();
                        }
                        myTrans.Commit();
                        return count;
                    }
                    catch
                    {
                        myTrans.Rollback();
                        throw;
                    }
                    finally
                    {
                        myCmd.Dispose();
                        sqlConnection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句返回结果集中第一行的第一列的方法
        /// </summary>
        /// <param name="strSql">要执行的SQL语句</param>
        /// <returns>第一行的第一列的值</returns>
        public static object ExecuteScalar(string strSql)
        {
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                SqlCommand myCmd = new SqlCommand(strSql, sqlConnection);
                try
                {
                    sqlConnection.Open();
                    return myCmd.ExecuteScalar();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    myCmd.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句返回数据集的方法
        /// </summary>
        /// <param name="strSql">要执行的SQL语句</param>
        /// <returns>数据集</returns>
        public static DataTable Query(string strSql)
        {
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                //try
                //{
                    sqlConnection.Open();
                    SqlDataAdapter mySda = new SqlDataAdapter(strSql, sqlConnection);
                    DataTable dt = new DataTable();
                    mySda.Fill(dt);
                    return dt;
                //}
                //catch
                //{
                //    throw;
                //}
                //finally
                //{
                //    sqlConnection.Close();
                //}
            }
        }

        /// <summary>
        /// 执行多条SQL语句返回数据集的方法，Key为表名
        /// </summary>
        /// <param name="querys">要执行的语句集合</param>
        /// <returns>执行结果</returns>
        public static DataSet Querys(Dictionary<string, string> querys)
        {
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlDataAdapter mySda = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    foreach (string key in querys.Keys)
                    {
                        mySda = new SqlDataAdapter(querys[key], sqlConnection);
                        mySda.Fill(ds, key);
                    }
                    return ds;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        #endregion

        #region 扩展部分
        /// <summary>
        /// 获取指定表指定字段指定条件的最大值
        /// </summary>
        /// <param name="table">指定表</param>
        /// <param name="field">指定字段</param>
        /// <param name="strWhere">Where后面的条件</param>
        /// <returns>最大值</returns>
        public static object Max(string table, string field, string strWhere)
        {
            strWhere = (strWhere == "") ? "1=1" : strWhere;
            return SQLHelper.ExecuteScalar(string.Format("SELECT MAX({0}) FROM {1} WHERE {2}", field, table, strWhere));
        }

        /// <summary>
        /// 获取指定表指定字段指定条件的最小值
        /// </summary>
        /// <param name="table">指定表</param>
        /// <param name="field">指定字段</param>
        /// <param name="strWhere">Where后面的条件</param>
        /// <returns>最小值</returns>
        public static object Min(string table, string field, string strWhere)
        {
            strWhere = (strWhere == "") ? "1=1" : strWhere;
            return SQLHelper.ExecuteScalar(string.Format("SELECT MIN({0}) FROM {1} WHERE {2}", field, table, strWhere));
        }

        /// <summary>
        /// 获取指定表指定条件的记录数
        /// </summary>
        /// <param name="table">指定表</param>
        /// <param name="strWhere">Where后面的条件</param>
        /// <returns>记录数</returns>
        public static int Count(string table, string strWhere)
        {
            strWhere = (strWhere == "") ? "1=1" : strWhere;
            return Convert.ToInt32(SQLHelper.ExecuteScalar(string.Format("SELECT COUNT(1) FROM {0} WHERE {1}", table, strWhere)));
        }

        /// <summary>
        /// 获取指定表指定条件的指定字段的和
        /// </summary>
        /// <param name="field">字段</param>
        /// <param name="table">指定表</param>
        /// <param name="strWhere">Where后面的条件</param>
        /// <returns>记录数</returns>
        public static object Sum(string field, string table, string strWhere)
        {
            strWhere = (strWhere == "") ? "1=1" : strWhere;
            return SQLHelper.ExecuteScalar(string.Format("SELECT Sum({0}) FROM {1} WHERE {2}", field, table, strWhere));
        }

        /// <summary>
        /// 根据指定条件删除指定记录的方法
        /// </summary>
        /// <param name="table">要从那张表删除</param>
        /// <param name="strWhere">Where后面的条件</param>
        /// <returns>影响行数</returns>
        public static int Deletes(string table, string strWhere)
        {
            return SQLHelper.Execute(string.Format("DELETE FROM {0} WHERE {1}", table, strWhere));
        }

        /// <summary>
        /// 根据指定主键集合删除指定记录的方法
        /// </summary>
        /// <param name="table">要从那张表删除</param>
        /// <param name="primaryKey">主键列列名</param>
        /// <param name="primaryKeyIns">主键集合，以,号隔开</param>
        /// <returns>影响行数</returns>
        public static int Deletes(string table, string primaryKey, string primaryKeyIns)
        {
            return Deletes(table, "1=1", primaryKey, primaryKeyIns);
        }

        /// <summary>
        /// 根据指定主键集合删除指定记录的方法
        /// </summary>
        /// <param name="table">要从那张表删除</param>
        /// <param name="strWhere">Where后面的条件</param>
        /// <param name="primaryKey">主键列列名</param>
        /// <param name="primaryKeyIns">主键集合，以,号隔开</param>
        /// <returns>影响行数</returns>
        public static int Deletes(string table, string strWhere, string primaryKey, string primaryKeyIns)
        {
            strWhere = (strWhere == "") ? "1=1" : strWhere;
            return Deletes(table, string.Format("{0} AND {1} IN ({2})", strWhere, primaryKey, primaryKeyIns));
        }

        /// <summary>
        /// 根据指定条件指定记录的方法
        /// </summary>
        /// <param name="table">要从那张表更新</param>
        /// <param name="sets">设置内容</param>
        /// <param name="strWhere">Where后面的条件</param>
        /// <returns>影响行数</returns>
        public static int Updates(string table, string sets, string strWhere)
        {
            strWhere = (strWhere == "") ? "1=1" : strWhere;
            return SQLHelper.Execute(string.Format("UPDATE {0} SET {1} WHERE {2}", table, sets, strWhere));
        }

        /// <summary>
        /// 根据指定主键集合更新指定记录的方法
        /// </summary>
        /// <param name="table">要从那张表更新</param>
        /// <param name="sets">设置内容</param>
        /// <param name="primaryKey">主键列列名</param>
        /// <param name="primaryKeyIns">主键集合，以,号隔开</param>
        /// <returns>影响行数</returns>
        public static int Updates(string table, string sets, string primaryKey, string primaryKeyIns)
        {
            return Updates(table, sets, "1=1", primaryKey, primaryKeyIns);
        }

        /// <summary>
        /// 根据指定主键集合更新指定记录的方法
        /// </summary>
        /// <param name="table">要从那张表更新</param>
        /// <param name="sets">设置内容</param>
        /// <param name="strWhere">Where后面的条件</param>
        /// <param name="primaryKey">主键列列名</param>
        /// <param name="primaryKeyIns">主键集合，以,号隔开</param>
        /// <returns>影响行数</returns>
        public static int Updates(string table, string sets, string strWhere, string primaryKey, string primaryKeyIns)
        {
            return Updates(table, sets, string.Format("{0} AND {1} IN ({2})", strWhere, primaryKey, primaryKeyIns));
        }

        /// <summary>
        /// 根据指定条件返回指定数据的方法
        /// </summary>
        /// <param name="fields">要获取的字段</param>
        /// <param name="tables">要从那些表获取</param>
        /// <param name="strWhere">Where后面的条件，无需条件则传入1=1</param>
        /// <param name="orderBy">指定排序，无需排序则传入""</param>
        /// <returns>指定数据</returns>
        public static DataTable GetData(string fields, string tables, string strWhere, string orderBy)
        {
            strWhere = (strWhere == "") ? "1=1" : strWhere;
            orderBy = (orderBy == "") ? "" : "ORDER BY " + orderBy;
            return SQLHelper.Query(string.Format("SELECT {0} FROM {1} WHERE {2} {3}", fields, tables, strWhere, orderBy));
        }

        /// <summary>
        /// 根据指定条件返回指定数据的方法
        /// </summary>
        /// <param name="tables">要从那些表获取</param>
        /// <param name="strWhere">Where后面的条件，无需条件则传入1=1</param>
        /// <returns>指定数据</returns>
        public static DataTable GetData(string tables, string strWhere)
        {
            return GetData("*", tables, strWhere, "");
        }

        /// <summary>
        /// 根据指定条件返回指定数据的方法
        /// </summary>
        /// <param name="tables">要从那些表获取</param>
        /// <param name="strWhere">Where后面的条件，无需条件则传入1=1</param>
        /// <param name="orderBy">指定排序，无需排序则传入""</param>
        /// <returns>指定数据</returns>
        public static DataTable GetData(string tables, string strWhere, string orderBy)
        {
            return GetData("*", tables, strWhere, orderBy);

        }

        /// <summary>
        /// 获取分页数据的方法(sql2000)
        /// </summary>
        /// <param name="pageSize">每页获取条数</param>
        /// <param name="pageNum">当前页</param>
        /// <param name="fields">要获取的字段，必须指定特定的列名而不能是*</param>
        /// <param name="tables">要从那些表获取</param>
        /// <param name="primaryKey">主键列列名</param>
        /// <param name="strWhere">Where后面的条件，无需条件则传入1=1</param>
        /// <param name="orderBy">指定排序</param>
        /// <returns>分页结果数据集</returns>
        public static DataSet GetPageData(int pageSize, int pageNum, string fields, string tables, string primaryKey, string strWhere, string orderBy)
        {
            pageSize = (pageSize < 1) ? 1 : pageSize;
            pageNum = (pageNum < 1) ? 1 : pageNum;
            strWhere = (strWhere == "") ? "WHERE 1=1" : "WHERE " + strWhere;
            orderBy = (orderBy == "") ? "ORDER BY " + primaryKey + " DESC" : "ORDER BY " + orderBy;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Count", string.Format("SELECT COUNT(1) FROM {0} {1}", tables, strWhere));
            if (pageNum == 1)
            {
                dic.Add("Data", string.Format("SELECT TOP {0} {1} FROM {2} {3} {4}", pageSize, fields, tables, strWhere, orderBy));
            }
            else
            {
                dic.Add("Data", string.Format("SELECT TOP {0} {1} FROM {2} {3} AND {4} NOT IN(SELECT TOP {5} {4} FROM {2} {3} {6}) {6}", pageSize, fields, tables, strWhere, primaryKey, pageSize * (pageNum - 1), orderBy));
            }
            return SQLHelper.Querys(dic);
        }

        /// <summary>
        /// 获取分页数据的方法
        /// </summary>
        /// <param name="pageSize">每页获取条数</param>
        /// <param name="pageNum">当前页</param>
        /// <param name="fields">要获取的字段，必须指定特定的列名而不能是*</param>
        /// <param name="tables">要从那些表获取</param>
        /// <param name="primaryKey">主键列列名</param>
        /// <param name="orderBy">指定排序</param>
        /// <returns>分页结果数据集</returns>
        public static DataSet GetPageData(int pageSize, int pageNum, string fields, string tables, string primaryKey, string orderBy)
        {
            return GetPageData(pageSize, pageNum, fields, tables, primaryKey, "", orderBy);
        }

        #endregion

        #region 生成器使用的代码

        /// <summary>
        /// 执行SQL语句返回影响行数的方法
        /// </summary>
        /// <param name="strSql">要执行的SQL语句</param>
        /// <param name="cmdParms"></param>
        /// <returns>影响行数</returns>
        public static int Execute(string strSql, params SqlParameter[] cmdParms)
        {
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                SqlCommand myCmd = new SqlCommand();
                try
                {
                    PrepareCommand(myCmd, sqlConnection, null, strSql, cmdParms);
                    return myCmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    myCmd.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <param name="cmdParms"></param>
        /// <returns>DataTable</returns>
        public static DataTable Query(string strSql, params SqlParameter[] cmdParms)
        {
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                SqlCommand myCmd = new SqlCommand();
                PrepareCommand(myCmd, sqlConnection, null, strSql, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(myCmd))
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        myCmd.Dispose();
                        sqlConnection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 设置Sql Parameters
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion
    }
}
