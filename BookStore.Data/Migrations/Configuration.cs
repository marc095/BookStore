namespace BookStore.Data.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.Data.BookStoreEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookStore.Data.BookStoreEntities context)
        {
            context.Authors.AddOrUpdate(new AuthorEntity() { Id = 1, FirstName = "N.K.", LastName = "Jemisin" });
            context.Publishers.AddOrUpdate(new PublisherEntity() { Id = 1, Name = "Orbit", Address = "UK/London" });
            context.Books.AddOrUpdate(new BookEntity() { Id = 1, Title = "The Fifth Season (The Broken Earth)", AuthorName = "N.K. Jemisin", DatePublished = new DateTime(2015, 04, 08), ISBN = "0316229296", Price = 9.52m, PublisherId = 1 , AuthorId = 1, PublisherName = "Orbit" });

            context.Authors.AddOrUpdate(new AuthorEntity() { Id = 2, FirstName = "Ann", LastName = "Leckie" });
          //  context.Publishers.AddOrUpdate(new PublisherEntity() { Id = 2, Name = "Orbit", Address = "UK/London" });
            context.Books.AddOrUpdate(new BookEntity() { Id = 2, Title = "Ancillary Mercy (Imperial Radch)", AuthorName = "Ann Leckie", DatePublished = new DateTime(2015 ,10 , 06), ISBN = " 0316246689", Price = 9.51m, PublisherId = 1, AuthorId = 2, PublisherName = "Orbit" });

            context.Authors.AddOrUpdate(new AuthorEntity() { Id = 3, FirstName = "Jim", LastName = "Butcher" });
            context.Publishers.AddOrUpdate(new PublisherEntity() { Id = 2, Name = "Roc", Address = "UK/London" });
            context.Books.AddOrUpdate(new BookEntity() { Id = 3, Title = "The Cinder Spires: The Aeronaut's Windlass", AuthorName = "Jim Butcher", DatePublished = new DateTime(2015 , 07 , 12), ISBN = " 0451466810", Price = 9.99m, PublisherId = 2, AuthorId = 3, PublisherName = "Roc" });

            context.Authors.AddOrUpdate(new AuthorEntity() { Id = 4, FirstName = "Neal", LastName = "Stephenson" });
            context.Publishers.AddOrUpdate(new PublisherEntity() { Id = 3, Name = "William Morrow", Address = "UK/London" });
            context.Books.AddOrUpdate(new BookEntity() { Id = 4, Title = "Seveneves: A Novel", AuthorName = "Neal Stephenson", DatePublished = new DateTime(2015 , 05 , 10), ISBN = "0062190377", Price = 23.48m, PublisherId = 3, AuthorId = 4, PublisherName = "William Morrow" });
        }
    }
}
