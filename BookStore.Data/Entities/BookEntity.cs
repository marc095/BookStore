using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class BookEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50), MinLength(1)]
        public string Title { get; set; }
        public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public AuthorEntity Author{ get; set; }
        public int? PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public PublisherEntity Publisher { get; set; }
        [Display(Name = "Author")]
        public string AuthorName { get; set; }
        [Display(Name ="Publisher")]
        public string PublisherName { get; set; }

        public decimal? Price { get; set; }
        public string ISBN { get; set; }

        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePublished { get; set; }

        //public virtual PublisherEntity Publishers { get; set; }
       // public ICollection<AuthorEntity> Authors { get; set; }
    }
}
