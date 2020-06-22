using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Mockups;
using ServiceLayer.Models;

namespace ServersideProject.Controllers
{
    public class UpdateController : Controller
    {
        /*
         UPDATE Functions for the Author
             */
        public ActionResult EditAuthor(string Aid)
        {
            AuthorDetails authorDetailsObj = new AuthorDetails(Aid);
            return View(authorDetailsObj);
        }
        [HttpPost]
        public RedirectToRouteResult EditAuthor(string AuthorId, string authorFirstName, string authorLastName, string authorBirthYear, string removeBook, string addBook)
        {
            return RedirectToAction("UpdateAuthor", new Author {
                Aid = AuthorId,
                FirstName = authorFirstName,
                LastName = authorLastName,
                BirthYear = authorBirthYear,
                AddBookReference = addBook,
                RemoveBookReference = removeBook
            });
        }

        public RedirectToRouteResult UpdateAuthor(Author authorObj)
        {
            Author.updateAuthor(authorObj);
            return RedirectToAction("ListAuthors", "List");
        }

        /*
         UPDATE Functions for the Admin
             */
        /*public ActionResult EditAdmin(string id)
        {
            Repository repo = (Repository)Session["repo"];
            AdminDetails adminDetailsObj = new AdminDetails(id, repo);
            ViewBag.adminFirstName = adminDetailsObj.FirstName;
            ViewBag.adminLastName = adminDetailsObj.LastName;
            ViewBag.adminEmail = adminDetailsObj.Email;
            return View(adminDetailsObj);
        }
        [HttpPost]
        public RedirectToRouteResult EditAdmin(string adminId, string adminFirstName, string adminLastName, string adminEmail)
        {
            TempData["AdminID"] = Convert.ToInt32(adminId);
            TempData["AdminFirstName"] = adminFirstName;
            TempData["AdminLastName"] = adminLastName;
            TempData["AdminEmail"] = adminEmail;

            return RedirectToAction("UpdateAdmin");
        }

        public RedirectToRouteResult UpdateAdmin()
        {
            Repository repo = (Repository)Session["repo"];
            Admin adminObj = repo.AdminList.Find(x => x.AdminID == Convert.ToInt32(TempData["AdminID"]));
            adminObj.FirstName = Convert.ToString(TempData["AdminFirstName"]);
            adminObj.LastName = Convert.ToString(TempData["AdminLastName"]);
            adminObj.Email = Convert.ToString(TempData["AdminEmail"]);
            Session["repo"] = repo;
            return RedirectToAction("ListAdministrators", "List");
        }
        */
        
         //UPDATE Functions for the Book
             
        public ActionResult EditBook(string isbn)
        {
            BookDetails bookDetailsObj = new BookDetails(isbn);
            return View(bookDetailsObj);
        }
        [HttpPost]
        public RedirectToRouteResult EditBook(string bookTitle, string bookPages, string bookPublicationYear, string bookPublicationInfo, string bookISBN)
        {
            return RedirectToAction("UpdateBook", new Book {
                ISBN = bookISBN,
                Title = bookTitle,
                Pages = Convert.ToInt32(bookPages),
                PublicationYear = bookPublicationYear,
                PublicationInfo = bookPublicationInfo
            });
        }

        public RedirectToRouteResult UpdateBook(Book bookObj)
        {
            Book.updateBook(bookObj);
            return RedirectToAction("ListBooks", "List");

        }
    }
}