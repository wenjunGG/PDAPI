using IServices.ISysServices;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly ApplicationDb _dataContext;
        private readonly IDbSet<T> _dbset;
        private readonly IUserInfo _userInfo;

        protected RepositoryBase(IDatabaseFactory databaseFactory, IUserInfo userInfo)
        {
            _dataContext = databaseFactory.Get();
            _userInfo = userInfo;
            _dbset = _dataContext.Set<T>();
        }

        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            var ientity = entity as IDbSetBase;
            if (ientity != null)
            {
                ientity.UserId = _userInfo.UserId;
                ientity.UpdatedDate = DateTime.Now;
            }

            _dbset.Attach(ientity as T);
            _dataContext.Entry(entity as T).State = EntityState.Modified;
        }

        /// <summary>
        ///     添加或者更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public virtual void Save(Guid? id, T entity)
        {
            var ientity = entity as IDbSetBase;
            if (ientity != null)
            {
                ientity.UserId = _userInfo.UserId;

                if (id.HasValue)
                {
                    Update(ientity as T);
                }
                else
                {
                    Add(ientity as T);
                }
            }
            else
            {
                if (id.HasValue)
                {
                    Update(entity);
                }
                else
                {
                    Add(entity);
                }
            }
        }

        /// <summary>
        ///     标记删除
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(Guid id)
        {
            T item = GetById(id);
            Delete(item);
        }

        /// <summary>
        ///     标记删除
        /// </summary>
        /// <param name="item"></param>
        public virtual void Delete(T item)
        {
            var entity = item as IDbSetBase;
            if (entity != null)
            {
                entity.Deleted = true;
                entity.UserId = _userInfo.UserId;
                entity.UpdatedDate = DateTime.Now;

            }
        }

        /// <summary>
        ///     标记删除
        /// </summary>
        /// <param name="where"></param>
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            foreach (T item in GetAll(where))
            {
                Delete(item);
            }
        }

        /// <summary>
        ///     物理删除
        /// </summary>
        /// <param name="item"></param>
        public virtual void Remove(T item)
        {
            _dbset.Remove(item);
        }


        /// <summary>
        ///     获取单个记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(Guid id)
        {
            return _dbset.Find(id);
        }

        /// <summary>
        ///     获取全部企业数据
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAllEnt()
        {
            return GetAllEnt(false);
        }

        /// <summary>
        ///     获取全部企业数据
        /// </summary>
        /// <param name="deleted"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetAllEnt(bool deleted)
        {
            //创建一个参数c
            ParameterExpression param = Expression.Parameter(typeof(T), "c");

            //c.City=="London"
            Expression left = Expression.Property(param, "Deleted");
            Expression right = Expression.Constant(deleted);
            Expression filter = Expression.Equal(left, right);

            Expression<Func<T, bool>> end = Expression.Lambda<Func<T, bool>>(filter, new[] { param });

            Expression<Func<T, DateTime>> order =
                Expression.Lambda<Func<T, DateTime>>(Expression.Property(param, "UpdatedDate"), param);

            return _dbset.Where(end).OrderByDescending(order);
        }

        /// <summary>
        ///     获取用户所在企业数据
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return GetAllEnt(false);
        }

        /// <summary>
        ///     获取用户所在企业数据
        /// </summary>
        /// <param name="deleted"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll(bool deleted)
        {
            //创建一个参数c
            ParameterExpression param = Expression.Parameter(typeof(T), "c");
            //c.City=="London"
            Expression left = Expression.Property(param, "EnterpriseId");
            Expression right = Expression.Constant(_userInfo.EnterpriseId);
            Expression filter = Expression.Equal(left, right);

            Expression<Func<T, bool>> end = Expression.Lambda<Func<T, bool>>(filter, new[] { param });

            return GetAllEnt(deleted).Where(end);
        }

        /// <summary>
        ///     获取符合条件的用户所在企业数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return GetAllEnt().Where(where);
        }


        public int Commit()
        {
            return _dataContext.Commit();
        }

        public Task<int> CommitAsync()
        {
            return _dataContext.CommitAsync();
        }

        /// <summary>
        ///     是否有符合条件的数据
        /// </summary>
        /// <param name="fieldname">字段名</param>
        /// <param name="value">数据</param>
        /// <param name="Id">忽略的Id</param>
        /// <param name="withinProject">是否在当前项目中</param>
        /// <param name="deleted"></param>
        /// <returns></returns>
        public virtual bool HasItem(string fieldname, string value, Guid? Id, bool deleted = false)
        {
            //创建一个参数c
            ParameterExpression param = Expression.Parameter(typeof(T), "c");
            //c.City=="London"
            Expression left = Expression.Property(param, fieldname);
            Expression right = Expression.Constant(value);
            Expression filter = Expression.Equal(left, right);

            Expression<Func<T, bool>> end = Expression.Lambda<Func<T, bool>>(filter, new[] { param });

            if (Id.HasValue)
            {
                ParameterExpression param1 = Expression.Parameter(typeof(T), "c");
                //c.City=="London"
                Expression left1 = Expression.Property(param, "Id");
                Expression right1 = Expression.Constant(Id.Value);
                Expression filter1 = Expression.NotEqual(left1, right1);
                Expression<Func<T, bool>> end1 = Expression.Lambda<Func<T, bool>>(filter1, new[] { param });


                return GetAll(deleted).Where(end).Where(end1).Any();

            }
            else
            {

                return GetAll(deleted).Where(end).Any();
            }
        }


        /// <summary>
        /// Sql 物理删除
        /// </summary>
        /// <param name="where">where condition</param>
        public virtual int RemoveSql(string where = "")
        {
            Type objType = typeof(T);
            var tableobj = objType.GetCustomAttributes(typeof(TableAttribute), true);
            string tableName = "";
            foreach (object obj in tableobj)
            {
                TableAttribute attr = obj as TableAttribute;
                if (attr != null)
                {
                    tableName = attr.Name;//表名只有获取一次  
                    break;
                }
            }
            if (tableName == "")
            {
                tableName = objType.Name;
            }

            string sql = "delete from " + tableName + " where 1=1 ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += sql + " and  " + where;
            }
            return _dataContext.Database.ExecuteSqlCommand(sql, new object[] { });
        }

        /// <summary>
        /// Sql 更新
        /// </summary>
        /// <param name="update"></param>
        /// <param name="where"></param>
        public virtual int UpdateSql(string update, string where = "")
        {
            Type objType = typeof(T);
            var tableobj = objType.GetCustomAttributes(typeof(TableAttribute), true);
            string tableName = "";
            foreach (object obj in tableobj)
            {
                TableAttribute attr = obj as TableAttribute;
                if (attr != null)
                {
                    tableName = attr.Name;//表名只有获取一次  
                    break;
                }
            }
            if (tableName == "")
            {
                tableName = objType.Name;
            }
            string sql = "update " + tableName + " set " + update + "  where 1=1";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += sql + " and  " + where;
            }
            return _dataContext.Database.ExecuteSqlCommand(sql, new object[] { });
        }


    }
}
