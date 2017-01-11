using BookStore.Domain.AuthorsAggregate;
using BookStore.Domain.BooksAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Contracts
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        void Create(Author author);
        void Edit(Author author);
        Author Get(int id);
       // List<Book> GetAuthor(int authorId);
        void Delete(int id);
    }
}
