using BookStore.Domain.BooksAggregate;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Domain.Basket
{
    public class Basket
    {
        private List<PushCart> carts = new List<PushCart>();
        public IEnumerable<PushCart> Carts { get { return this.carts; } }
        public void Add(Book book, int quantity)
        {
            PushCart cart = this.carts.Where(c => c.Book.Id == book.Id).FirstOrDefault();
            if (cart == null)
            {
                this.carts.Add(new PushCart { Book = book, Quantity = quantity });
            }
            else
            {
                cart.Quantity += quantity;
            }
        }
        public void Remove(Book book)
        {
            this.carts.RemoveAll(b => b.Book.Id == book.Id);
        }
        public void Clear()
        {
            this.carts.Clear();
        }
        public decimal? Total()
        {
            return this.carts.Sum(b => b.Book.Price * b.Quantity);
        }
    }
    public class PushCart
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
