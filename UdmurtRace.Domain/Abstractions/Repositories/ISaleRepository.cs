using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdmurtRace.Domain.Abstractions.Repositories
{
    public interface ISaleRepository<T>
    {
        T? GetById(int id);
        List<T?>? GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

