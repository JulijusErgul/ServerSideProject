using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ServerSideProject.Models;

namespace ServerSideProject.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ViewResult Index()
        {
            var authors = GetAuthors();
            return View(authors);
        }

        [Route("UserDetails")]
        public ActionResult UserDetails(int id)
        {
            var authors = GetAuthors().SingleOrDefault(a => a.Id == id);

            if (authors == null) return HttpNotFound();
            return View(authors);
        }

        private IEnumerable<Author> GetAuthors()
        {
            return new List<Author>
            {
                new Author {Id = 1, Name = "Tim Ferris"},
                new Author {Id = 2, Name = "Tony Robbins"},
                new Author {Id = 3, Name = "Napoleon Hill"},
                new Author {Id = 4, Name = "Dale Carnegie"}
            };
        }
    }
}