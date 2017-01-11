using BookStore.Data.Entities;
using System;
using System.Linq;

namespace BookStore.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IQueryable<PublisherEntity> GetPublishers { get; }
        IQueryable<AuthorEntity> GetAuthors { get; }
        IQueryable<BookEntity> GetBooks { get; }

        void Commit();
    }
}
