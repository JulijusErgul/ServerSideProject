using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Mockups;
using ServiceLayer.Models;

namespace ServersideProject.Controllers
{
    public class CreateController : Controller
    {
        List<string> errorMessages = new List<string>();
        
        // GET: Create
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult AddAuthor(List<string>  errors)
        {
            if(errors != null)
                ViewData["errorMessages"] = errors;
            return View(new Author());
        }
        [HttpPost]
        public RedirectToRouteResult AddAuthor(Author authorObj)
        {
            return RedirectToAction("StoreAuthor", authorObj);
            
        }

      
        public RedirectToRouteResult StoreAuthor(Author authorObj)
        {
            Author.addAuthor(authorObj);
            return RedirectToAction("ListAuthors", "List");
        }

        public ActionResult AddBook()
        {
            return View(new BookDetails());
        }
        [HttpPost]
        public RedirectToRouteResult AddBook(BookDetails bookDetailObj)
        {

                return RedirectToAction("StoreBook", BookDetails.ConvertToBook(bookDetailObj));
        }

        public RedirectToRouteResult StoreBook(Book bookObj)
        {
            Book.addBook(bookObj);
            return RedirectToAction("ListBooks", "List");
        }

        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult CreateAdmin(string AdminID, string FirstName, string LastName, string Email)
        {
            TempData["AdminID"] = Convert.ToInt32(AdminID);
            TempData["AdminFirstName"] = FirstName;
            TempData["AdminLastName"] = LastName;
            TempData["AdminEmail"] = Email;

            return RedirectToAction("SaveAdmin");
        }

        public RedirectToRouteResult SaveAdmin()
        { 
            return RedirectToAction("ListAdministrators", "List");
        }
    }
}