using BookStore.Domain.Basket;
using BookStore.Domain.BooksAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BookStore.Tests
{
    [TestClass]
    public class BasketTest
    {
        [TestMethod]
        public void Add_To_Basket()
        {
            //Arrange
            Book b1 = new Book { Id = 1, Title = "B1" };
            Book b2 = new Book { Id = 2, Title = "B2" };
            Basket target = new Basket();
            //Act
            target.Add(b1, 1);
            target.Add(b2, 1);

            //Assert
            Assert.AreEqual(target.Carts.Count(), 2);
        }
        [TestMethod]
        public void Remove_From_Basket()
        {
            //Arrange
            Book b1 = new Book { Id = 1, Title = "B1" };
            Book b2 = new Book { Id = 2, Title = "B2" };
            Basket target = new Basket();
            //Act
            target.Add(b1, 1);
            target.Add(b2, 1);
            target.Remove(b1);
            //Assert
            Assert.AreEqual(target.Carts.Count(), 1);
            Assert.AreEqual(target.Carts.ToArray()[0].Book.Id, 2);
            Assert.AreEqual(target.Carts.ToArray()[0].Quantity, 1);
        }
        [TestMethod]
        public void Clear_Basket()
        {
            //Arrange
            Book b1 = new Book { Id = 1, Title = "B1" };
            Book b2 = new Book { Id = 2, Title = "B2" };
            Basket target = new Basket();
            //Act
            target.Add(b1, 1);
            target.Add(b2, 1);
            target.Clear();
            //Assert
            Assert.AreEqual(target.Carts.Count(), 0);
        }
        [TestMethod]
        public void Add_Basket_Quantity()
        {
            //Arrange
            Book b1 = new Book { Id = 1, Title = "B1" };
            Basket target = new Basket();
            //Act
            target.Add(b1, 1);
            target.Add(b1, 1);
            PushCart[] array = target.Carts.ToArray();
            //Assert
            Assert.AreEqual(array[0].Quantity, 2);
        }
    }
}
