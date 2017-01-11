using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Contracts;
using BookStore.Domain.Repositories;
using BookStore.Domain.BooksAggregate;
using System.Data.Entity.Infrastructure;
using BookStore.Domain.PublishersAggregate;
using BookStore.Domain.AuthorsAggregate;
using BookStore.Data;

namespace BookStore.Service
{
    public class BookService : IBookService
    {
        IBookRepository bookRepository;
      
        public BookService()
        {
            this.bookRepository = new BookRepository(new BookStoreUnitOfWork());
        }
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Create(Book book)
        {
            if (book == null) { throw new Exception(); }
            bookRepository.Add(book);
            bookRepository.UnitOfWork.Commit();
        }
        public int Creates(Book book)
        {
            if (book == null) { throw new Exception(); }
            bookRepository.Add(book);
            bookRepository.UnitOfWork.Commit();
            return bookRepository.UnitOfWork.GetBooks.Count();
        }
        public void Update(Book book)
        {
            this.bookRepository.Update(book);
        }
        public void Delete(int id)
        {
            try
            {
                bookRepository.Remove(id);
                bookRepository.UnitOfWork.Commit();
            }
            catch { }
        }

        public void Edit(BookStore.Domain.BooksAggregate.Book book)
        {
            try
            {
                bookRepository.Update(book);
            }
            catch { }
            bookRepository.UnitOfWork.Commit();
        }

        public Book Find(int? id)
        {
            var book = this.bookRepository.FindById(id);
            return book;
        }

      public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            var booksEntities = this.bookRepository.GetAll();
            foreach (var item in booksEntities)
            {
                var book = new Book() { Id = item.Id, Author = item.AuthorName , DatePublished = item.DatePublished, ISBN = item.ISBN, Price = item.Price, Title = item.Title, PublisherId = item.PublisherId, Publisher= item.PublisherName };
                books.Add(book);
            }
            return books;
        }
    }
}
