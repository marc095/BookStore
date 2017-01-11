using BookStore.Domain.PublishersAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Contracts
{
   public interface IPublisherService
    {
        List<Publisher> GetAll();
        void Create(Publisher publisher);
        void Edit(Publisher publisher);
        Publisher Get(int id);
        void Delete(int id);
    }
}
