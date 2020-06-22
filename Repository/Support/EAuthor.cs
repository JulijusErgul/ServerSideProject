using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Repository.Support
{
    public class EAuthor
    {
        public EAuthor() { }
        public EAuthor(int Aid)
        {
            _authorObj = this.Read(Aid);
        }
        private AUTHOR _authorObj = null;
        public AUTHOR AuthorObj { get { return _authorObj; } }

        public AUTHOR Read(int Aid)
        {
            using (var db = new LibraryDBEntities1())
            {
                return db.AUTHORs.Include(a => a.BOOKs).FirstOrDefault(a => a.Aid == Aid);
            }
        }
        public List<AUTHOR> List()
        {
            using(var db = new LibraryDBEntities1())
            {
                db.AUTHORs.Load();
                var query = db.AUTHORs.OrderBy(x => x.Aid);
                return query.ToList();
            }
        }

        public List<AUTHOR>List(string searchString)
        {
            using(var db = new LibraryDBEntities1())
            {
                db.AUTHORs.Load();
                var query = db.AUTHORs.Where(a => a.FirstName.Contains(searchString) || a.LastName.Contains(searchString));
                return query.ToList();
            }
        }

        public void Update(AUTHOR authorObj)
        {
            using(var db = new LibraryDBEntities1())
            {
                db.AUTHORs.Attach(authorObj);
                db.Entry(authorObj).State = EntityState.Modified;
                Shared.save(db);
            }
        }

        public int Add(AUTHOR authorObj)
        {
            int newAid = 0;
            using(var db = new LibraryDBEntities1())
            {
                using(DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try { 
                        db.AUTHORs.Load();
                        newAid = authorObj.Aid = (db.AUTHORs.ToList().Max(x => x.Aid) + 1);
                        db.AUTHORs.Add(authorObj);
                        Shared.save(db);
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
            return newAid;
        }
       /*
        public void RemoveProjectReference(int depid, int projid)
        {
            using (var db = new dbprojectEntities())
            {
                _departmentObj = db.departments.ToList().Find(d => d.depid == depid);
                if(_departmentObj.projects1.ToList().Exists(x => x.projid == projid)) //Check that there is a row in the intermediate table
                {
                    project projectObject = db.projects.ToList().Find(p => p.projid == projid); 
                    _departmentObj.projects1.Remove(projectObject);
                    db.SaveChanges();
                }
            }
        }*/
        public void removeBookReference(int aId, string removeISBN)
        {
            using(var db = new LibraryDBEntities1())
            {
                _authorObj = db.AUTHORs.Include(x => x.BOOKs).ToList().Find(a => a.Aid == aId);
                if(_authorObj.BOOKs.ToList().Exists(b => b.ISBN == removeISBN))
                {
                    BOOK bookObj = db.BOOKs.ToList().Find(b => b.ISBN == removeISBN);
                    _authorObj.BOOKs.Remove(bookObj);
                    Shared.save(db);
                }
            }
        }
 /*public void AddProjectReference(int depid, int projid)
        {
            using (var db = new dbprojectEntities())
            {
                //Create a department object which has loaded all the projects in "projects1"
                _departmentObj = db.departments.Include(x => x.projects1).ToList().Find(d => d.depid == depid);
                //The department-project should not exist in the intermediate table
                if (!_departmentObj.projects1.ToList().Exists(p => p.projid == projid))
                {
                    project projectObject = db.projects.ToList().Find(p => p.projid == projid); //Get the project object
                    _departmentObj.projects1.Add(projectObject); //Add the project to the list
                    db.SaveChanges();
                }
            }
        }
        */

        public void addBookReference(int aId, string addISBN)
        {
            using (var db = new LibraryDBEntities1())
            {
                _authorObj = db.AUTHORs.Include(x => x.BOOKs).ToList().Find(a => a.Aid == aId);

                if (!_authorObj.BOOKs.ToList().Exists(b => b.ISBN == addISBN))
                {
                    BOOK bookObj = db.BOOKs.ToList().Find(b => b.ISBN == addISBN);
                    _authorObj.BOOKs.Add(bookObj);
                    Shared.save(db);
                }
            }
        }

        public void Delete(AUTHOR authorObj)
        {
            using(var db = new LibraryDBEntities1())
            {
                using(DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        _authorObj = db.AUTHORs.Find(authorObj.Aid);
                        db.AUTHORs.Remove(_authorObj);
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