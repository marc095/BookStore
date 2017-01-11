using BookStore.Data.Entities;
using System.Data.Entity;

namespace BookStore.Data
{
    public class BookStoreEntities:DbContext
    {
        static BookStoreEntities()
        {
            //Database.SetInitializer();
        }

        public BookStoreEntities():base("TestEntities1")
        {

        }

        #region Entity Sets
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<PublisherEntity> Publishers { get; set; }
        #endregion
    }
}