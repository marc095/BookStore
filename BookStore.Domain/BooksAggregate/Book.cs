using BookStore.Domain.AuthorsAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.BooksAggregate
{
   public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string ISBN { get; set; }
        public DateTime DatePublished { get; set; }
        public int? PublisherId { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
    }
}
