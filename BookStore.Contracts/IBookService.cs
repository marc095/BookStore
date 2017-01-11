using BookStore.Domain.AuthorsAggregate;
using BookStore.Domain.BooksAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Contracts
{
    public interface IBookService
    {
        Book Find(int? id);
        List<Book> GetAll();
        void Create(Book book);
        int Creates(Book book);
        void Edit(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}
