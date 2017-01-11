using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Context
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookStoreEntities>
    {
        protected override void Seed(BookStoreEntities context)
        {
            //AuthorEntity a1 = new AuthorEntity() { Id =1 , FirstName = "N.K.", LastName= "Jemisin"  };
            //PublisherEntity p1 = new PublisherEntity() { Id = 1, Name = " Orbit" , Address = "UK/London" };
            //BookEntity b1 = new BookEntity() {  Id =1 , Title = "The Fifth Season (The Broken Earth)" , Author = a1.FirstName , DatePublished =  new DateTime(2015-08-04), ISBN= "0316229296", Price = 9.52m, PublisherId = p1.Id};
            //p1.Books.Add(b1);


            //AuthorEntity a2 = new AuthorEntity() { Id = 2, FirstName = "N.K.", LastName = "Jemisin" };
            //PublisherEntity p2 = new PublisherEntity() { Id = 2, Name = " Orbit", Address = "UK/London" };
            //BookEntity b2 = new BookEntity() { Id = 2, Title = "The Fifth Season (The Broken Earth)", Author = a1.FirstName, DatePublished = new DateTime(2015 - 08 - 04), ISBN = "0316229296", Price = 9.52m, PublisherId = p1.Id };
            //p2.Books.Add(b2);

            //context.Authors.Add(a2);
            //context.Books.Add(b2);
            //context.Publishers.Add(p2);

            base.Seed(context);
        }
    }
}
