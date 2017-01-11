using BookStore.Data.Contracts;
using BookStore.Data.Entities;
using System.Linq;

namespace BookStore.Data
{
    public class BookStoreUnitOfWork : IUnitOfWork
    {
        private BookStoreEntities context;
        public BookStoreUnitOfWork()
        {
            context = new BookStoreEntities();
        }
        public BookStoreEntities Context
        {
            get { return this.context; }
        }
        public IQueryable<BookEntity> GetBooks
        {
            get { return context.Books; }
        }
        public IQueryable<AuthorEntity> GetAuthors
        {
            get { return context.Authors; }
        }
        public IQueryable<PublisherEntity> GetPublishers
        {
            get { return context.Publishers; }
        }
        public void Commit()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
