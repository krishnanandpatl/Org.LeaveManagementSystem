using Microsoft.EntityFrameworkCore;
using Org.LeaveManagementSystem.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.LeaveManagementSystem.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LeaveManagementDBContext _dBContext;

        public GenericRepository(LeaveManagementDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dBContext.AddAsync(entity);
            await _dBContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dBContext.Set<T>().Remove(entity);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int Id)
        {
            var entity = await Get(Id);
            return entity != null;
        }

        public async Task<T> Get(int Id)
        {
            return await _dBContext.Set<T>().FindAsync(Id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dBContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dBContext.Entry(entity).State=EntityState.Modified;
            await _dBContext.SaveChangesAsync();
        }
    }
}
