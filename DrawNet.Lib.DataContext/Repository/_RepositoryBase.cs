using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawNet.Lib.DataContext.Tables;
using DrawNet.Lib.DataContext.Tables.Interface;

namespace DrawNet.Lib.DataContext.Repository
{
    public class RepositoryBase<TEntity> : ApplicationDbContext, IRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext Context;
        internal DbSet<TEntity> DbSet;

        public virtual IQueryable<TEntity> GetAll()
        {
            return this.GetAll( null );
        }

        public virtual IQueryable<TEntity> GetAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereExpression = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (whereExpression != null)
            {
                return query.Where(whereExpression);
            }
            else
            {
                return query;
            }
        }

        /*
        public virtual IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression = null)
        {
            IQueryable<T> table;
            if (whereExpression != null)
            {
                table = GetTable.Where(whereExpression);
            }
            else
            {
                table = GetTable;
            }
            return table;
        }
        public virtual Boolean GetAny(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression = null)
        {
            IQueryable<T> table;
            if (whereExpression != null)
            {
                table = GetTable.Where(whereExpression);
            }
            else
            {
                table = GetTable;
            }
            return table.Any();
        }
        public virtual T GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression = null)
        {
            T table;
            if (whereExpression != null)
            {
                table = GetTable.FirstOrDefault(whereExpression);
            }
            else
            {
                table = GetTable.FirstOrDefault();
            }
            return table;
        }
        public virtual int Count(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression = null)
        {
            IQueryable<T> table;
            if (whereExpression != null)
            {
                table = GetTable.Where(whereExpression);
            }
            else
            {
                table = GetTable;
            }
            return table.Count();
        }
        public virtual void DeleteRecord(T entity)
        {
            this.DataContextGroup.GetTable<T>().DeleteOnSubmit(entity);
            this.DataContextGroup.SubmitChanges();
        }
        public virtual void DeleteRecords(IEnumerable<T> entities)
        {
            this.DataContextGroup.GetTable<T>().DeleteAllOnSubmit(entities);
            this.DataContextGroup.SubmitChanges();
        }
        public virtual T InsertRecord(T entity)
        {
            this.DataContextGroup.GetTable<T>().InsertOnSubmit(entity);
            this.DataContextGroup.SubmitChanges();
            return entity;
        }
        public virtual void InsertRecords(IEnumerable<T> entities)
        {
            this.DataContextGroup.GetTable<T>().InsertAllOnSubmit(entities);
            this.DataContextGroup.SubmitChanges();
        }
        public virtual T UpdateRecord(T entity)
        {
            return UpdateRecord(entity, optionalIgnoreChangeConflicts: false, optionalRefreshMode: RefreshMode.KeepChanges);
        }
        public virtual T UpdateRecord(T entity, bool optionalIgnoreChangeConflicts = false, RefreshMode optionalRefreshMode = RefreshMode.KeepChanges)
        {
            if (optionalIgnoreChangeConflicts)
            {
                try
                {
                    this.DataContextGroup.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                catch (Exception e)
                {
                    if (string.Compare(e.Message, "Exception of type 'System.Data.Linq.ChangeConflictException' was thrown.", true) == 0)
                    {
                        if (this.DataContextGroup.ChangeConflicts != null)
                        {
                            foreach (ObjectChangeConflict objectChangeConflict in this.DataContextGroup.ChangeConflicts)
                            {
                                //RefreshMode.KeepChanges
                                //Keep current values that have changed, 
                                //updates other values with database values
                                objectChangeConflict.Resolve(optionalRefreshMode);
                            }
                        }
                    }
                    else
                    {
                        throw e;
                    }
                }
            }
            else
            {
                this.DataContextGroup.SubmitChanges();
            }
            return entity;
        }
        public T CreateInstance()
        {
            T entity = Activator.CreateInstance<T>();
            GetTable.InsertOnSubmit(entity);
            this.DataContextGroup.SubmitChanges();
            return entity;
        }
        public System.Data.Linq.ModifiedMemberInfo[] GetModifiedMembers(T entity)
        {
            return GetTable.GetModifiedMembers(entity);
        }
        #region Properties
        private string PrimaryKeyName
        {
            get { return TableMetadata.RowType.IdentityMembers[0].Name; }
        }
        private System.Data.Linq.Table<T> GetTable
        {
            get
            {
                return this.DataContextGroup.GetTable<T>();
            }
        }
        private System.Data.Linq.Mapping.MetaTable TableMetadata
        {
            get
            {
                return this.DataContextGroup.Mapping.GetTable(typeof(T));
            }
        }
        private System.Data.Linq.Mapping.MetaType ClassMetadata
        {
            get
            {
                return this.DataContextGroup.Mapping.GetMetaType(typeof(T));
            }
        }
        #endregion
        */
    }
}
