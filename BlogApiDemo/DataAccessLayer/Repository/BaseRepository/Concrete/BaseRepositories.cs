using BlogApiDemo.DataAccessLayer.Repository.BaseRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogApiDemo.DataAccessLayer.Repository.BaseRepository.Concrete
{
    public class BaseRepositories<T> : IBaseRepositories<T> where T : class
    {
        private readonly Context _context;
        private readonly DbSet<T> _table;
        public BaseRepositories(Context context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
            await _table.AddAsync(entity);
            await Save();
        }


        public async Task<bool> Any(Expression<Func<T, bool>> expression) => await _table.AnyAsync(expression);

        public async Task Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await Save();
        }

        public async Task<T> FindByDefault(Expression<Func<T, bool>> expression) => await _table.FirstAsync(expression);


        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression) => await _table.Where(expression).FirstOrDefaultAsync();

        public async Task<List<T>> Get(Expression<Func<T, bool>> expression) => await _table.Where(expression).ToListAsync();


        public async Task<List<T>> GetAll() => await _table.ToListAsync();


        public async Task<T> GetById(int id) => await _table.FindAsync(id);

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;

            await Save();
        }
    }
}
