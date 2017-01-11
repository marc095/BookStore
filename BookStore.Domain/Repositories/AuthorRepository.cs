using BookStore.Domain.AuthorsAggregate;
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
   public class AuthorRepository : IAuthorRepository
    {
        BookStoreUnitOfWork unitOfWork;
        DbSet<AuthorEntity> dalAuthors;
        public AuthorRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (BookStoreUnitOfWork)unitOfWork;
            this.dalAuthors = this.unitOfWork.Context.Authors;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
               return this.unitOfWork;
            }
        }

        public void Add(Author entity)
        {
            var newAuthor = new AuthorEntity();
            DomainToDal.Map(newAuthor, entity);
            this.dalAuthors.Add(newAuthor);
            this.unitOfWork.Commit();
            entity.Id = newAuthor.Id;
        }

        public void Remove(int id)
        {
            var dalToRemove = new AuthorEntity { Id = id};
            this.dalAuthors.Attach(dalToRemove);
            this.dalAuthors.Remove(dalToRemove);
        }

        public void Update(Author entity)
        {
            var authorToUpdate = dalAuthors.SingleOrDefault(t=>t.Id == entity.Id);
            if (authorToUpdate == null) { new Exception(); }
            DomainToDal.Map(authorToUpdate, entity);
        }


        public List<AuthorEntity> GetAll()
        {
            return this.dalAuthors.ToList();
        }
    }
}
