using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceLayer.Mockups;
using Repository;
using Repository.Support;


namespace ServiceLayer.Models
{
    public class AuthorDetails : Author
    {
        public AuthorDetails(string Aid)
        {
            this.AuthorID = Convert.ToInt32(Aid);
            Author authorObj = Author.getAuthor(AuthorID);
            this.FirstName = authorObj.FirstName;
            this.LastName = authorObj.LastName;
            this.BirthYear = authorObj.BirthYear;
            this.BooksList = authorObj.BooksList.ToList();
            NonBookList = Book.getBookList().Except(authorObj.BooksList.ToList()).ToList();
        }

        public string BirthYear { get; set; }

        public string LastName { get; set; }
        
        public string FirstName { get; set; }

        public int AuthorID { get; set; }

        public virtual List<Book> BooksList { get; set; }
        public List<Book> NonBookList { get; private set; }
    }
}