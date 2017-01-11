using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Contracts;
using BookStore.Domain.PublishersAggregate;
using BookStore.Domain.Repositories;
using BookStore.Data;
using BookStore.Domain.BooksAggregate;
using BookStore.Data.Entities;

namespace BookStore.Service
{
    public class PublisherService : IPublisherService
    {
        IPublisherRepository publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }
        public PublisherService()
        {
            this.publisherRepository = new PublisherRepository(new BookStoreUnitOfWork());
        }
        public void Create(BookStore.Domain.PublishersAggregate.Publisher publisher)
        {
            if (publisher == null) { throw new Exception(); }
            publisherRepository.Add(publisher);
            publisherRepository.UnitOfWork.Commit();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(BookStore.Domain.PublishersAggregate.Publisher publisher)
        {
            throw new NotImplementedException();
        }

        //public List<BookStore.Domain.PublishersAggregate.Publisher> Get()
        //{
        //    throw new NotImplementedException();
        //}
        public List<Publisher> GetAll()
        {
            List<Publisher> publishers = new List<Publisher>();
            var publisherEntities = this.publisherRepository.GetAll();
            foreach (var item in publisherEntities)
            {
                var  publisher= new Publisher() { Id = item.Id, Address = item.Address, Name = item.Name };
                publishers.Add(publisher);
            }
            return publishers;
        }
        public BookStore.Domain.PublishersAggregate.Publisher Get(int id)
        {
            throw new NotImplementedException();
        }
        private Book Map(BookEntity book) { return new Book() { Id = book.Id, Author = book.AuthorName, DatePublished = book.DatePublished, ISBN = book.ISBN, Price = book.Price, Title = book.Title, PublisherId = book.PublisherId , Publisher = book.PublisherName}; }
    }
}
