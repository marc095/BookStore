using BookStore.Contracts;
using BookStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        IAuthorService authorService;
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }
        // GET: Author
        public ViewResult Index()
        {
            var authors = new List<AuthorViewModel>();

            foreach (var a in this.authorService.GetAll())
            {
                var author = AuthorViewModel.Map(a);
                authors.Add(author);
            }
            return View(authors);
        }
    }
}