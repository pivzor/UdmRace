using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdmurtRace.Domain.Abstractions.Repositories;

namespace UdmurtRace.DAL.Repositories
{
    public class ClientRepository<T> : IClientRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _dbset;

        public ClientRepository(AppDbContext db)
        {
            _db = db;
            _dbset = db.Set<T>();
        }

        // Синхронные методы
        public void Add(T entity)
        {
            _dbset.Add(entity);
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
            _db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T? GetById(int id)
        {
            return _dbset.Find(id);
        }

        // Асинхронные методы
        public async Task<List<T>?> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbset.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
