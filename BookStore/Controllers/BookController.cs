using BookStore.Contracts;
using BookStore.Data.Entities;
using BookStore.Domain.BooksAggregate;
using BookStore.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;
        IPublisherService publisherService;

        public BookController(IBookService bookService, IPublisherService publisherService)
        {
            this.bookService = bookService;
            this.publisherService = publisherService;
        }
        // GET: Book
        public ViewResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var books = new List<BookViewModel>();

            foreach (var b in this.bookService.GetAll())
            {
                var book = BookViewModel.Map(b);
                books.Add(book);
            }
            return View(books.ToPagedList(pageNumber, pageSize));
        }


        // GET: /Books/Create

        public ActionResult Create()
        {
            ViewBag.PublishersName = InitDropDownList();
            return View();
        }

        private SelectList InitDropDownList()
        {
            return new SelectList(this.publisherService.GetAll().OrderBy(p => p.Name), "Id", "Name");
        }

        // POST: /Books/Create
        [HttpPost]
        public ActionResult Create(BookViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                var publisher = (from s in this.publisherService.GetAll()
                                 where s.Id == bookVM.PublisherId
                                 select s).FirstOrDefault();
                if (publisher != null)
                {
                    bookVM.PublisherName = publisher.Name;

                    Book book = new Book()
                    {
                        Id = bookVM.BookId,
                        Author = bookVM.Author,
                        ISBN = bookVM.ISBN,
                        Price = bookVM.Price,
                        PublisherId = bookVM.PublisherId,
                        Title = bookVM.Title,
                        Publisher = bookVM.PublisherName,
                        DatePublished = bookVM.DatePublished
                    };
                    this.bookService.Create(book);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.PublishersName = InitDropDownList();
            return View(bookVM);
        }


        // GET: /Books/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = this.bookService.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        #region Edit

        // POST: /Books/Edit/
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                this.bookService.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        #endregion



        // GET: /Books/Delete/
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = this.bookService.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Books/Delete/
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.bookService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchTerm)
        {

            List<BookViewModel> bookVMs = new List<BookViewModel>();
            var books = (from b in this.bookService.GetAll()
                         where b.Title.Contains(searchTerm)
                         select b).ToList();

            foreach (var b in books)
            {
                bookVMs.Add(new BookViewModel()
                {
                    Title = b.Title,
                    Author = b.Author,
                    ISBN = b.ISBN,
                    Price = b.Price,
                    BookId = b.Id,
                    PublisherName = b.Publisher,
                    DatePublished = b.DatePublished
                });
            }
            if (bookVMs.Count == 1)
                return View("Details", bookVMs[0]);
            else
                return View("Index", bookVMs);
        }


        // GET: /Books/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookViewModel book = (from b in this.bookService.GetAll()
                                  join s in this.publisherService.GetAll() on b.PublisherId equals s.Id
                                  where b.Id == id
                                  select new BookViewModel
                                  {
                                      BookId = b.Id,
                                      Author = b.Author,
                                      ISBN = b.ISBN,
                                      Price = b.Price,
                                      Title = b.Title,
                                      PublisherName = b.Publisher,
                                      DatePublished = b.DatePublished
                                  }).SingleOrDefault();

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        #region Methods
        private Book Map(BookEntity from)
        {
            return new Book()
            {
                Id = from.Id,
                Title = from.Title,
                DatePublished = from.DatePublished,
                ISBN = from.ISBN,
                Price = from.Price,
                PublisherId = from.PublisherId,
                Author = from.AuthorName,
                Publisher = from.PublisherName
            };
        }
        #endregion
    }
}