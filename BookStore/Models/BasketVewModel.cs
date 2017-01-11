using BookStore.Domain.Basket;

namespace BookStore.Models
{
    public class BasketVewModel
    {
        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }
    }
}