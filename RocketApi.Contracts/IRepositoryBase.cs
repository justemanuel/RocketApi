using System;
using System.Linq;
using System.Linq.Expressions;

namespace RocketApi.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        T FindById(int id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
