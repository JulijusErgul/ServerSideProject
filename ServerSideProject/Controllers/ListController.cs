using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Models;
using ServiceLayer.Mockups;
using PagedList;

namespace ServersAideProject.Controllers
{
    
    public class ListController : Controller
    {
        public ActionResult ListAuthors(int? page, string searchString)
        {
            List<Author> authors;

            if (!String.IsNullOrEmpty(searchString))
            {
                authors = Author.getAuthorsListBySearch(searchString);
            }
            else
            {
                authors = Author.getAuthorsList();
            }
            
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(authors.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult AuthorDetails(string Aid)
        {
            AuthorDetails authorDetailsObj = new AuthorDetails(Aid);
            return View(authorDetailsObj);
        }
   /*

        public ActionResult ListAdministrators()
        {
            //Repository repo = (Repository)Session["repo"];
            //return View(repo.AdminList);
            return View();
        }
  
        public ActionResult AdminDetails(string Aid)
        {
            /*Repository repo = (Repository)Session["repo"];
            AdminDetails adminDetailsObj = new AdminDetails(Aid, repo);
            return View(adminDetailsObj);
            return View();
        }
*/

        public ActionResult ListBooks(int? page, string searchString)
        {
            List<Book> books;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = Book.getBookListBySearch(searchString);
            }
            else { 
                books = Book.getBookList();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(books.ToPagedList(pageNumber, pageSize));   
        }
        public ActionResult BookDetails(string isbn)
        {
            BookDetails bookDetailsObj = new BookDetails(isbn);
            return View(bookDetailsObj);
        }
    }
}