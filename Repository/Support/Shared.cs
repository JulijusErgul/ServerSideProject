using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using System.IO;

namespace Repository.Support
{
    public class Shared
    {
        static public void save(LibraryDBEntities1 db)
        {
            try
            {
                db.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {
                FileStream fs = File.Open("c:\\error\\ErrorList", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach(var eVError in ex.EntityValidationErrors)
                {
                    foreach(var vError in eVError.ValidationErrors)
                    {
                        sw.WriteLine("Property: " + vError.PropertyName + "Error: " + vError.ErrorMessage);
                    }
                }
                sw.Close();
                sw = null;
            }
            catch(Exception ex)
            {
                FileStream fs = File.Open("c:\\error\\ErrorList", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("Error: " + ex.Message);
                sw.Close();
                sw = null;
            }
        }
    }
}