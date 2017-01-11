using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Data.Contracts;
using BookStore.Data.Entities;

namespace BookStore.Domain.AuthorsAggregate
{
    public interface IAuthorRepository:IGenericRepository<Author>
    {
        List<AuthorEntity> GetAll();
    }
}
