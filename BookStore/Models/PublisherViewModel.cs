using BookStore.Domain.BooksAggregate;
using BookStore.Domain.PublishersAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class PublisherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Book> Books { get; set; }
        public static PublisherViewModel Map(Publisher p)
        {
            return new PublisherViewModel() { Id = p.Id, Address = p.Address, Name = p.Name, Books = p.Books };
        }
    }
}