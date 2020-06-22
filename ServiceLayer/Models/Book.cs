using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Repository.Support;
using AutoMapper;



namespace ServiceLayer.Models
{
    public class Book
    {
        //public int BookID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string PublicationYear { get; set; }
        public string PublicationInfo { get; set; }
        public int Pages { get; set; }
        public List<Author> AuthorList { get; set; }

        static private EBook _ebookObj = new EBook();

        static public Book getBook(string isbn)
        {
            BOOK bbook = _ebookObj.Read(isbn);
            Book bookObj = Mapper.Map<Book>(bbook);
            bookObj.Pages = bookObj.Pages;
            bookObj.Title = bookObj.Title;
            bookObj.PublicationInfo = bookObj.PublicationInfo;
            bookObj.PublicationYear = bookObj.PublicationYear;
            bookObj.AuthorList = Mapper.Map<List<AUTHOR>, List<Author>>(bbook.AUTHORs.ToList());
            return bookObj;
        }

        static public List<Book> getBookListBySearch(string searchString)
        {
            return Mapper.Map<List<BOOK>, List<Book>>(_ebookObj.List(searchString));
        }

        static public List<Book> getBookList()
        {
            return Mapper.Map<List<BOOK>, List<Book>>(_ebookObj.List());
        }

        static public List<Book> getSearchedBookList(string searchString)
        {
            return getBookList().FindAll(x => (x.Title == searchString));
        }

        static public void updateBook(Book bookObj)
        {
            _ebookObj.Update(Mapper.Map<BOOK>(bookObj));
        }

        static public void addBook(Book bookObj)
        {
            _ebookObj.Add(Mapper.Map<BOOK>(bookObj));
        }
        static public void deleteBook(Book bookObj)
        {
            _ebookObj.Delete(Mapper.Map<BOOK>(bookObj));
        }
    }
}
