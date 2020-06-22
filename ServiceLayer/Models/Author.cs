using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Support;
using Repository;
using AutoMapper;

namespace ServiceLayer.Models
{
    public class Author
    {
        public string Aid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthYear { get; set; }
        public string AddBookReference { get; set; }
        public string RemoveBookReference { get; set; }
        public virtual List<Book> BooksList { get; set; }
        static private EAuthor _eAuthorObj = new EAuthor();


        //Hämtar en specifik författare
        static public Author getAuthor(int id)
        {
            AUTHOR aauthor = _eAuthorObj.Read(id);
            Author authorObj = Mapper.Map<Author>(aauthor);
            authorObj.FirstName = authorObj.FirstName;
            authorObj.LastName = authorObj.LastName;
            authorObj.BirthYear = authorObj.BirthYear;
            authorObj.BooksList = Mapper.Map<List<BOOK>, List<Book>>(aauthor.BOOKs.ToList());
            return authorObj;
        }

        public static List<Author> getAuthorsListBySearch(string searchString)
        {
            return Mapper.Map<List<AUTHOR>, List<Author>>(_eAuthorObj.List(searchString));
        }

        //Ger oss en lista med alla Authors
        static public List<Author> getAuthorsList()
        {
            return Mapper.Map<List<AUTHOR>,List<Author>>(_eAuthorObj.List());
        }

        static public void updateAuthor(Author updateAuthorObj)
        {
            Author authorObj = Author.getAuthor(Convert.ToInt32(updateAuthorObj.Aid));
            authorObj.FirstName = updateAuthorObj.FirstName;
            authorObj.LastName = updateAuthorObj.LastName;
            authorObj.BirthYear = updateAuthorObj.BirthYear;
            _eAuthorObj.Update(Mapper.Map<AUTHOR>(authorObj));
            _eAuthorObj.addBookReference(Convert.ToInt32(updateAuthorObj.Aid), updateAuthorObj.AddBookReference);
            _eAuthorObj.removeBookReference(Convert.ToInt32(updateAuthorObj.Aid), updateAuthorObj.RemoveBookReference);
        }

        static public void addAuthor(Author authorObj)
        {
            int returnValue = _eAuthorObj.Add(Mapper.Map<AUTHOR>(authorObj));
        }

        static public void deleteAuthor(Author authorObj)
        {
            _eAuthorObj.Delete(Mapper.Map<AUTHOR>(authorObj));
        }
    }
}
