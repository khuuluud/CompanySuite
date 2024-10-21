using LinkDev.CompanyBase.DAL.Models ;
using LinkDev.CompanyBase.DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.DAL.Persistance.Repositories._Generic
{
    public class GenericRepository<T> where T : ModelBase
    {
        private protected readonly ApplicationDbContext _DbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }


        public async Task<IEnumerable<T>> GetAllAsync(bool withAsNoTracking = true)
        {
            if (withAsNoTracking)
                return await _DbContext.Set<T>().Where(X => !X.IsDeleted).AsNoTracking().ToListAsync();
            return await _DbContext.Set<T>().Where(X => !X.IsDeleted).ToListAsync();
        }

        public  IQueryable<T> GetAllAsIQueryable()
        {
            return _DbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _DbContext.Set<T>().Add(entity);
           
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _DbContext.Set<T>().FindAsync(id);
        }

        public void Update( T entity)
        {
            _DbContext.Set<T>().Update(entity);
           
        }

        public void Delete( T entity)
        {
            entity.IsDeleted = true;
            _DbContext.Set<T>().Update(entity);
            
        }


    }
}
