using System.Collections.Generic;
using System.Web.Mvc;
using ServerSideProject.Models;
using ServerSideProject.ViewModels;

namespace ServerSideProject.Controllers
{
    [RoutePrefix("Books")]
    public class BooksController : Controller
    {
        // GET: Books
        public ViewResult Index()
        {
            var books = GetBooks();
            return View(books);
        }

        public ActionResult Random()
        {
            var book = new Book {Name = "4-hour body"};
            var users = new List<Author>
            {
                new Author {Name = "Johan Andersson"},
                new Author {Name = "Kalle Karlsson"}
            };

            var viewModel = new BookRentedViewModel
            {
                Book = book,
                Users = users
            };

            return View(viewModel);
        }

        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book {Id = 1, AuthorName = "Tim Ferris", Name = "4-hour body", ReleaseYear = 2019},
                new Book {Id = 2, AuthorName = "Tim Ferris", Name = "4-hour workweek", ReleaseYear = 2019},
                new Book {Id = 3, AuthorName = "Tim Ferris", Name = "Tribe of Mentors", ReleaseYear = 2019},
                new Book {Id = 4, AuthorName = "Tony Robbins", Name = "Money Master Game", ReleaseYear = 2019},
                new Book {Id = 5, AuthorName = "Tony Robbins", Name = "Awaken the Giant Within", ReleaseYear = 2019},
                new Book {Id = 6, AuthorName = "Napoleon Hill", Name = "Think and Grow Rich", ReleaseYear = 2019},
                new Book
                {
                    Id = 7, AuthorName = "Dale Carnegie", Name = "How to win friends and influens people",
                    ReleaseYear = 2019
                }
            };
        }
    }
}