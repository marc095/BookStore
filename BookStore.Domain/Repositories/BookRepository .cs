using BookStore.Data;
using BookStore.Data.Contracts;
using BookStore.Data.Entities;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Domain.Repositories
{
    public class BookRepository : IBookRepository
    {
        BookStoreUnitOfWork unitOfWork;
        DbSet<BookEntity> dalBooks;
        // private IBookRepository _bookRepository = null;
        //public BookRepository()
        //{
        //    this.unitOfWork = new BookStoreUnitOfWork();
        //    this.dalBooks = this.unitOfWork.Context.Books;
        //}
        public BookRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (BookStoreUnitOfWork)unitOfWork;
            this.dalBooks = this.unitOfWork.Context.Books;
        }
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public void Add(Book entity)
        {
            var newBook = new BookEntity();
            DomainToDal.Map(newBook, entity);
            this.dalBooks.Add(newBook);
            this.unitOfWork.Commit();
            entity.Id = newBook.Id;
        }
        public Book FindById(int? id)
        {
            var bookEntity = this.dalBooks.Find(id);
            var book = Map(bookEntity);
            return book;
        }
        public void Remove(int id)
        {
            var dalToRemove = new BookEntity { Id = id };
            this.dalBooks.Attach(dalToRemove);
            this.dalBooks.Remove(dalToRemove);
        }

        public void Update(Book entity)
        {
            var bookToUpdate = dalBooks.SingleOrDefault(t => t.Id == entity.Id);
            if (bookToUpdate == null) { new Exception(); }
            DomainToDal.Map(bookToUpdate, entity);
            this.UnitOfWork.Commit();
        }
        public List<BookEntity> GetAll()
        {
            return this.dalBooks.ToList();
        }

        public static Book Map(BookEntity from)
        {
            return new Book()
            {
                Id = from.Id,
                Title = from.Title,
                Author = from.AuthorName,
                DatePublished = from.DatePublished,
                ISBN = from.ISBN,
                Price = from.Price,
                PublisherId = from.PublisherId,
                Publisher = from.PublisherName
            };
        }


        //public IBookRepository BookRepo
        //{
        //    get
        //    {
        //        if (this._bookRepository == null)
        //            this._bookRepository = new BookRepository();
        //        return this._bookRepository;
        //    }
        //}

    }
}
