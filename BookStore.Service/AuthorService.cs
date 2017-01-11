using BookStore.Contracts;
using BookStore.Data.Entities;
using BookStore.Domain.AuthorsAggregate;
using BookStore.Domain.BooksAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service
{
    public class AuthorService : IAuthorService
    {
        IAuthorRepository authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public void Create(BookStore.Domain.AuthorsAggregate.Author author)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(BookStore.Domain.AuthorsAggregate.Author author)
        {
            throw new NotImplementedException();
        }

        public List<BookStore.Domain.AuthorsAggregate.Author> Get()
        {
            throw new NotImplementedException();
        }

        public BookStore.Domain.AuthorsAggregate.Author Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAll()
        {
            List<Author> authors = new List<Author>();
            var authorsEntities = this.authorRepository.GetAll();
            foreach (var item in authorsEntities)
            {
                var author = new Author() {  Id = item.Id, FirstName = item.FirstName, LastName = item.LastName };
                authors.Add(author);
            }
            return authors;
        }

        private Book Map(BookEntity from)
        {
            return new Book()
            {
                Id = from.Id,
                Title = from.Title,
                DatePublished = from.DatePublished,
                ISBN = from.ISBN,
                Price = from.Price,
                PublisherId = from.PublisherId,
                Author = from.AuthorName,
                Publisher = from.PublisherName
            };
        }
    }
}
