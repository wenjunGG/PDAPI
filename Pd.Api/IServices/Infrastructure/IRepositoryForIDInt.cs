using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Infrastructure
{
    public interface IRepositoryForIDInt<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Save(int? id, T entity);
        void Delete(int id);
        void Delete(T item);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(int id);
        IQueryable<T> GetAllEnt();
        IQueryable<T> GetAllEnt(bool deleted);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(bool deleted);
        IQueryable<T> GetAll(Expression<Func<T, bool>> where);
        int Commit();
        Task<int> CommitAsync();
        int RemoveSql(string where = "");
        int UpdateSql(string update, string where = "");
    }
}
