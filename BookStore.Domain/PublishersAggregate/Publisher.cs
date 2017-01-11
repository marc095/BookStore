using BookStore.Domain.BooksAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.PublishersAggregate
{
   public class Publisher
    {
        public Publisher()
        {
            this.Books = new List<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Book> Books { get; set; }
    }
}
