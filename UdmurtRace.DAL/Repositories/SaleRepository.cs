using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdmurtRace.Domain.Abstractions.Repositories;
using UdmurtRace.Domain.Entities;

namespace UdmurtRace.DAL.Repositories
{
    public class SaleRepository<T> : ISaleRepository<T> where T : class
    {
        public readonly AppDbContext _db;
        public readonly DbSet<T> _dbset;
        public SaleRepository(AppDbContext db)
        {
            _db = db;
            _dbset = db.Set<T>();
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
            _db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return [.. _dbset];
        }

        public T? GetById(int id)
        {
            return _dbset.Find(id);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
            _db.SaveChanges();
        }
    }
}
