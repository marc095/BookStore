using BookStore.Domain.AuthorsAggregate;
using BookStore.Domain.BooksAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class AuthorViewModel
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; }
        public static AuthorViewModel Map(Author a)
        {
            return new AuthorViewModel() { AuthorId = a.Id, FirstName = a.FirstName, LastName = a.LastName, Books = a.Books };
        }
    }
}