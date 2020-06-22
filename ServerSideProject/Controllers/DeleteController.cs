using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Mockups;
using ServiceLayer.Models;


namespace ServersideProject.Controllers
{
    public class DeleteController : Controller
    {


        public RedirectToRouteResult DeleteAuthor(string aId)
        {
            Author.deleteAuthor(Author.getAuthor(Convert.ToInt32(aId)));
            return RedirectToAction("ListAuthors", "List");
        }

        public RedirectToRouteResult DeleteBook(string isbn)
        {
            Book.deleteBook(Book.getBook(Convert.ToString(isbn)));
            return RedirectToAction("ListBooks", "List");
        }

        /*[HttpDelete]
        public ActionResult DeleteAdmin(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("ListAdministrators", "List");
        }
        */
    }
}