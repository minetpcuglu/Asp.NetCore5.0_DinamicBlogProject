using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogApiDemo.DataAccessLayer.Repository.BaseRepository.Interface
{
  public  interface IBaseRepositories<T> where T:class
    {
        Task<List<T>> GetAll();
        Task<List<T>> Get(Expression<Func<T, bool>> expression);
        Task<T> GetById(int id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> expression);
        Task<T> FindByDefault(Expression<Func<T, bool>> expression);
        Task<bool> Any(Expression<Func<T, bool>> expression);

        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

        Task Save();
    }
}
