using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawNet.Lib.DataContext.Repository
{
    public interface IRepository<out TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();
//        IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression = null);
//        Boolean GetAny(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression = null);
//        T GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression = null);
//        int Count(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression = null);
//        void DeleteRecord(T entity);
//        void DeleteRecords(IEnumerable<T> entities);
//        T InsertRecord(T entity);
//        void InsertRecords(IEnumerable<T> entities);
//        T UpdateRecord(T entity);
//        T CreateInstance();
    }

}
