using BookStore.Data.Contracts;
using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.BooksAggregate
{
     public  interface IBookRepository : IGenericRepository<Book>
    {
        List<BookEntity> GetAll();
        Book FindById(int? id);
    }
}
