using System;
using System.Collections.Generic;
using System.Linq;
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
                ConnectionString = "Server=localhost;Database=dat;uid=dat;pwd=YANG@lixu1212;Port=3306;",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            //Print sql
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
        }

        public Expressionable<T> SqlExpression
        {
            get
            {
                return Expressionable.Create<T>();
            }
        }

        public ISugarQueryable<T> GetQueryExpression()
        {
            return Db.Queryable<T>();
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
        /// 获取数据
        /// </summary>
        /// <param name="expression">检索表达式</param>
        /// <returns></returns>
        public virtual List<T> GetList(Expressionable<T> expression = null)
        {
            try
            {
                if (expression != null)
                {
                    return Db.Queryable<T>().Where(expression.ToExpression()).ToList();
                }
                else
                {
                    return Db.Queryable<T>().ToList();
                }
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
        /// 分页查询
        /// </summary>
        /// <param name="expression">检索表达式</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public virtual List<T> GetList(Expressionable<T> expression, int pageIndex, int pageSize,ref int total)
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
                return Db.Queryable<T>().Where(expression.ToExpression()).ToPageList(pageIndex, pageSize,ref total);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public virtual List<T> GetList(ISugarQueryable<T> expression,int pageIndex,int pageSize,ref int total)
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
                return expression.ToPageList(pageIndex, pageSize,ref total);
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
        /// <param name="selectId">是否返回自增主键</param>
        /// <returns></returns>
        public virtual long Insert(T entity, bool selectId = false)
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
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual bool InsertAll(List<T> list)
        {
            if (list == null)
            {
                return false;
            }
            if (list.Count == 0)
            {
                return true;
            }
            try
            {
                return Db.Insertable<T>(list).ExecuteCommand() > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public virtual bool Update(T entity)
        {
            try
            {
                return Db.Updateable(entity).ExecuteCommand() > 0;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public virtual bool Update(T entity, Expression<Func<T, bool>> predicate, Expression<Func<T, object>> updateColumns)
        {
            try
            {
                return Db.Updateable(entity).Where(predicate).UpdateColumns(updateColumns).ExecuteCommand() > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public virtual bool Delete(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate can't be null");
            }
            try
            {
                return Db.Deleteable<T>().Where(predicate).ExecuteCommand() > 0;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}