using BookStore.Domain.PublishersAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Contracts;
using BookStore.Data;
using BookStore.Data.Entities;
using System.Data.Entity;
using BookStore.Domain.Mappers;

namespace BookStore.Domain.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        BookStoreUnitOfWork unitOfWork;
        DbSet<PublisherEntity> dalPublishers;
        public PublisherRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (BookStoreUnitOfWork)unitOfWork;
            this.dalPublishers = this.unitOfWork.Context.Publishers;
        }
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public void Add(Publisher entity)
        {
            var newPublisher = new PublisherEntity();
            DomainToDal.Map(newPublisher, entity);
            this.dalPublishers.Add(newPublisher);
            this.unitOfWork.Commit();
            entity.Id = newPublisher.Id;
        }

        public void Remove(int id)
        {
            var dalToRemove = new PublisherEntity { Id = id };
            this.dalPublishers.Attach(dalToRemove);
            this.dalPublishers.Remove(dalToRemove);
        }
        public List<PublisherEntity> GetAll()
        {

            // return unitOfWork.Context.Publishers.ToList();
            return this.dalPublishers.ToList();
        }
        public void Update(Publisher entity)
        {
            var publisherToUpdate = dalPublishers.SingleOrDefault(t => t.Id == entity.Id);
            if (publisherToUpdate == null) { new Exception(); }
            DomainToDal.Map(publisherToUpdate, entity);
        }
    }
}
