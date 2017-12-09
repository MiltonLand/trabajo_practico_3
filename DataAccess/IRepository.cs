using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    interface IRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAll(List<Expression<Func<T, object>>> includes);

        T Single(Expression<Func<T, bool>> predicate);
        T Single(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes);

        List<T> Filter(Expression<Func<T, bool>> predicate);
        List<T> Filter(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes);

        void Create(T entity);
        void Update(T entity);

        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
    }
}