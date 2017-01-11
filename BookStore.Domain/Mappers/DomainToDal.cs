using BookStore.Data.Entities;
using BookStore.Domain.AuthorsAggregate;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.PublishersAggregate;
using System.Linq;

namespace BookStore.Domain.Mappers
{
    public static class DomainToDal
    {
        public static void Map(AuthorEntity to, Author from)
        {
            to.Id = from.Id;
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            // to.Email = from.Email;
            to.Books = from.Books.Select(d => Map(d)).ToList();
        }

        public static void Map(BookEntity to, Book from)
        {
            to.Id = from.Id;
            to.PublisherId = from.PublisherId;
            to.Title = from.Title;
            to.Price = from.Price;
            to.AuthorName = from.Author;
            to.ISBN = from.ISBN;
            to.DatePublished = from.DatePublished;
            to.PublisherId = from.PublisherId;
            to.PublisherName = from.Publisher;
        }
        public static void Map(PublisherEntity to, Publisher from)
        {
            to.Id = from.Id;
            to.Name = from.Name;
            to.Address = from.Address;
            to.Books = from.Books.Select(d => Map(d)).ToList();
        }

        public static BookEntity Map(Book from)
        {
            return new BookEntity()
            {
                Id = from.Id,
                Title = from.Title,
                DatePublished = from.DatePublished,
                ISBN = from.ISBN,
                Price = from.Price,
                PublisherId = from.PublisherId,
                AuthorName = from.Author,
                PublisherName = from.Publisher
            };
        }


        public static Book Map(BookEntity from)
        {
            return new Book()
            {
                Id = from.Id,
                Title = from.Title,
                DatePublished = from.DatePublished,
                ISBN = from.ISBN,
                Price = from.Price,
                PublisherId = from.PublisherId,
                Author = from.AuthorName
            };
        }
    }
}
