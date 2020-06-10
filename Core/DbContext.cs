using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SqlSugar;

namespace ducky_api_server.Core
{
    public class DbContext<T> where T : class, new()
    {
        public SqlSugarClient Db;
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Server=localhost;Database=dat;uid=dat;pwd=YANG@lixu1212",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            //Print sql
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                // Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                // Console.WriteLine();
            };
        }
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <returns></returns>
        public virtual T GetSingle()
        {
            try
            {
                return Db.Queryable<T>().First();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="expression">检索表达式</param>
        /// <returns></returns>
        public virtual T GetSingle(Expression<Func<T, bool>> expression)
        {
            try
            {
                return Db.Queryable<T>().First(expression);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetAll()
        {
            try
            {
                return Db.Queryable<T>().ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="expression">检索表达式</param>
        /// <returns></returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> expression)
        {
            try
            {
                return Db.Queryable<T>().Where(expression).ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="expression">检索表达式</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> expression, int pageIndex = 1, int pageSize = 30)
        {
            if (expression == null)
            {
                throw new ArgumentException("expression is null");
            }
            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 30;
            }
            try
            {
                return Db.Queryable<T>().Where(expression).ToPageList(pageIndex, pageSize);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 插入单条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Insert(T entity)
        {
            try
            {
                return Db.Insertable(entity).ExecuteCommand() > 0;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 插入单条数据，并返回主键id
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="selectId"></param>
        /// <returns></returns>
        public virtual long Insert(T entity,bool selectId = false)
        {
            try
            {
                if (selectId)
                {
                    return Db.Insertable(entity).ExecuteReturnBigIdentity();
                }
                else
                {
                    return Db.Insertable(entity).ExecuteCommand();
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}