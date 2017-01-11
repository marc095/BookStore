using BookStore.Domain.Basket;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.Mappers;
using BookStore.Models;
using System.Linq;
using System.Web.Mvc;
namespace BookStore.Controllers
{
    public class BasketController : Controller
    {
        private IBookRepository books;

        public BasketController(IBookRepository books)
        {
            this.books = books;
        }
        // GET: Basket
        private Basket GetBasket()
        {
            Basket basket = (Basket)Session["Basket"];
            if (basket == null)
            {
                basket = new Basket();
                Session["Basket"] = basket;
            }
            return basket;
        }

        public RedirectToRouteResult AddToBasket(int bookId, string returnUrl)
        {
            var bookEntity = books.UnitOfWork.GetBooks.FirstOrDefault(b => b.Id == bookId);
            Book book = DomainToDal.Map(bookEntity);
            if (book != null)
            {
                GetBasket().Add(book, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromBasket(int bookId, string returnUrl)
        {
            var bookEntity = books.UnitOfWork.GetBooks.FirstOrDefault(b => b.Id == bookId);
            Book book = DomainToDal.Map(bookEntity);
            if (book != null)
            {
                GetBasket().Remove(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new BasketVewModel { Basket = GetBasket(), ReturnUrl = returnUrl });
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetBasket());
        }
    }
}