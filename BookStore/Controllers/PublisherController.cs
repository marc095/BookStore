using BookStore.Contracts;
using BookStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class PublisherController : Controller
    {
        IPublisherService publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }
        // GET: Publisher
        public ViewResult Index()
        {
            var publishers = new List<PublisherViewModel>();

            foreach (var p in this.publisherService.GetAll())
            {
                var publisher = PublisherViewModel.Map(p);
                publishers.Add(publisher);
            }
            return View(publishers);
        }

    }
}