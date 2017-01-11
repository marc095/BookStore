using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Contracts
{
    public interface IGenericRepository<T> : IRepository 
        where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
    }
}
