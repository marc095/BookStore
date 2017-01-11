using BookStore.Domain.BooksAggregate;
using BookStore.Domain.PublishersAggregate;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal? Price { get; set; }
        public string ISBN { get; set; }
        public Publisher Publisher { get; set; }
        public int? PublisherId { get; set; }

        [Display(Name = "Publisher")]
        public string PublisherName { get; set; }
        [Display(Name = "Date")]
        public DateTime DatePublished { get; set; }

        public static BookViewModel Map(Book b)
        {
            return new BookViewModel()
            {
                Author = b.Author,
                BookId = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Price = b.Price,
                DatePublished = b.DatePublished,
                PublisherName = b.Publisher
                ,
                PublisherId = b.PublisherId
            };
        }
    }
}
