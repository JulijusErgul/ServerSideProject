using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Repository.Support
{
    public class EBook
    {
        public EBook(){}
        public EBook(string bookISBN)
        {
            _bookObj = this.Read(bookISBN);
        }

        public BOOK BookObj { get { return _bookObj; } }

        private BOOK _bookObj = null;
        public BOOK Read(string bookISBN)
        {
            using(var db = new LibraryDBEntities1())
            {
                db.BOOKs.Load();
                return db.BOOKs.Include(x => x.AUTHORs).ToList().Find(b => b.ISBN == bookISBN); ;
            }
        }
        public List<BOOK> List()
        {
            using(var db = new LibraryDBEntities1())
            {
                var query = db.BOOKs.OrderBy(x => x.Title);
                return query.ToList();
            }
        }

        public List<BOOK> List(string searchString)
        {
            using(var db = new LibraryDBEntities1())
            {
                var query = db.BOOKs.Where(b => b.Title.Contains(searchString) || b.ISBN.Contains(searchString));
                return query.ToList();
            }
        }

        public string Add(BOOK bookObj)
        {
            string newBookISBN = "";
            using(var db = new LibraryDBEntities1())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.BOOKs.Load();
                        newBookISBN = bookObj.ISBN = (db.BOOKs.ToList().Max(b => b.ISBN) + 1);
                        db.BOOKs.Add(bookObj);
                        Shared.save(db);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
            return newBookISBN;
        }

        public void Update(BOOK bookObj)
        {
            using (var db = new LibraryDBEntities1())
            {
                db.BOOKs.Attach(bookObj);
                db.Entry(bookObj).State = EntityState.Modified;
                Shared.save(db);
            }
        }

        public void Delete(BOOK bookObj)
        {
            using(var db = new LibraryDBEntities1())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        _bookObj = db.BOOKs.Find(bookObj.ISBN);
                        
                        foreach(var item in _bookObj.AUTHORs.ToList())
                        {
                            _bookObj.AUTHORs.Remove(item);
                        }
                        db.BOOKs.Remove(_bookObj);
                        Shared.save(db);
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}