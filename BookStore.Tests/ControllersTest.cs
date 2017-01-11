using BookStore.Contracts;
using BookStore.Controllers;
using BookStore.Domain.AuthorsAggregate;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.PublishersAggregate;
using BookStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PagedList;
using System.Collections.Generic;
using System.Linq;
namespace BookStore.Tests
{
    [TestClass]
    public class ControllersTest
    {
        [TestMethod]
        public void AuthorController_Index()
        {
            Mock<IAuthorService> authors = new Mock<IAuthorService>();
            authors.Setup(a => a.GetAll()).Returns(new Author[] { new Author { Id = 1, FirstName = "Jack" } }.ToList());
            AuthorController target = new AuthorController(authors.Object);
            List<AuthorViewModel> list = (List<AuthorViewModel>)target.Index().Model;
            Assert.AreEqual(1, list[0].AuthorId);
            Assert.AreEqual("Jack", list[0].FirstName);
            Assert.IsTrue(list.Count() == 1);
        }
        [TestMethod]
        public void PublisherController_Index()
        {
            Mock<IPublisherService> mock = new Mock<IPublisherService>();
            mock.Setup(a => a.GetAll()).Returns(new Publisher[] { new Publisher { Id = 1, Name = "Orbit" } }.ToList());
            PublisherController target = new PublisherController(mock.Object);
            List<PublisherViewModel> list = (List<PublisherViewModel>)target.Index().Model;
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual("Orbit", list[0].Name);
            Assert.IsTrue(list.Count() == 1);
        }
        [TestMethod]
        public void BookController_Index()
        {
            Mock<IBookService> mock = new Mock<IBookService>();
            mock.Setup(a => a.GetAll()).Returns(new Book[] { new Book { Id = 1, Title = "Asp.Net" } }.ToList());
            BookController target = new BookController(mock.Object, null);
            var list = ((IPagedList<BookViewModel>)target.Index(1).Model);
            Assert.AreEqual(1, list[0].BookId);
            Assert.AreEqual("Asp.Net", list[0].Title);
            Assert.IsTrue(list.Count() == 1);
        }
        [TestMethod]
        public void Book_Create()
        {
            Mock<IBookService> mock = new Mock<IBookService>();
            mock.Setup(a => a.GetAll()).Returns(new Book[] { new Book { Id = 1, Title = "Asp.Net", PublisherId = 1 } }.ToList());
            mock.Setup(i => i.Creates(It.IsAny<Book>())).Returns(mock.Object.GetAll().Count());
            mock.Object.Creates(new Book { Id = 2 });
            mock.Object.Creates(new Book { Id = 3 });
            mock.Object.GetAll().Add(new Book { Id = 2 });
            Assert.AreEqual(mock.Object.GetAll().Count(), 2);
        }
    }
}
