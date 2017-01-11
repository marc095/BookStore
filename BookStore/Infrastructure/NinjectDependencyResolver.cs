using BookStore.Contracts;
using BookStore.Data;
using BookStore.Data.Contracts;
using BookStore.Domain.AuthorsAggregate;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.PublishersAggregate;
using BookStore.Domain.Repositories;
using BookStore.Service;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IBookService>().To<BookService>();
            kernel.Bind<IBookRepository>().To<BookRepository>();
            kernel.Bind<IPublisherRepository>().To<PublisherRepository>();
            kernel.Bind<IUnitOfWork>().To<BookStoreUnitOfWork>();
            kernel.Bind<IAuthorService>().To<AuthorService>();
            kernel.Bind<IAuthorRepository>().To<AuthorRepository>();
            kernel.Bind<IPublisherService>().To<PublisherService>();
        }
    }
}