using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceLayer.Mockups;

namespace ServiceLayer.Models
{
    public class BookDetails: Book
    {
        private string ISBN;
        
        public BookDetails()
        {
        }

        public BookDetails(string isbn)
        {
            this.ISBN = isbn;
            Book bookObj = Book.getBook(isbn);
            BookTitle = bookObj.Title;
            BookPages = bookObj.Pages;
            BookISBN = bookObj.ISBN;
            BookInfo = bookObj.PublicationInfo;
            BookPublicationYear = bookObj.PublicationYear;
            BookInfo = bookObj.PublicationInfo;
            AuthorsList = bookObj.AuthorList.ToList();
            NonAuthorsList = Author.getAuthorsList().Except(bookObj.AuthorList.ToList()).ToList();
            
        }

        static public Book ConvertToBook(BookDetails bookDetailsObj)
        {
            Book bookObj = bookDetailsObj.ISBN == null ? new Book()
                : Book.getBook(bookDetailsObj.ISBN);
            bookObj.Title = bookDetailsObj.Title;
            bookObj.Pages = bookDetailsObj.Pages;
            bookObj.PublicationYear = bookDetailsObj.PublicationYear;
            bookObj.PublicationInfo = bookDetailsObj.PublicationInfo;
            return bookObj;
        }
        public string BookPublicationYear { get; set; }

        public string BookInfo { get; set; }

        public string BookISBN { get; set; }

        public int BookPages { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string BookTitle { get; set; }
        public List<Author> AuthorsList { get; private set; }
        public List<Author> NonAuthorsList { get; set; }
    }
}