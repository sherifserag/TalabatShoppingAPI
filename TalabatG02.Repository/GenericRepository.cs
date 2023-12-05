using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Repositories;
using TalabatG02.Core.Specifications;
using TalabatG02.Repository.Data;

namespace TalabatG02.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext dbContext;

        public GenericRepository(StoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region Static Quires
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {

            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            
            return await dbContext.Set<T>().FindAsync(id);
        } 
        #endregion

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

     

        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountBySpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync(); 
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvalutor<T>.GetQuery(dbContext.Set<T>(), spec);
        }

        public async Task Add(T entity)
         => await dbContext.Set<T>().AddAsync(entity);

        public void Update(T entity)
       => dbContext.Set<T>().Update(entity);

        public void Delete(T entity)
        => dbContext.Set<T>().Remove(entity);
    }
}
