using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ServerSideProject.Models;

namespace ServerSideProject.Controllers
{
    [RoutePrefix("Users")]
    public class UsersController : Controller
    {
        // GET: Users
        [Route("Index")]
        public ViewResult Index()
        {
            var users = GetUsers();
            return View(users);
        }

        public ActionResult Login()
        {
            return View();
        }

        [Route("UserDetails")]
        public ActionResult UserDetails(int id)
        {
            var users = GetUsers().SingleOrDefault(u => u.Id == id);

            if (users == null) return HttpNotFound();
            return View(users);
        }

        private IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User {Id = 1, Administrator = true, Name = "Johan Andersson", SecurityNumber = "197802252626"},
                new User {Id = 2, Administrator = true, Name = "Petter Karlsson", SecurityNumber = "196509083805"},
                new User {Id = 3, Administrator = false, Name = "Björn Berg", SecurityNumber = "198905060708"},
                new User {Id = 4, Administrator = false, Name = "Stig Larsson", SecurityNumber = "197312050604"}
            };
        }
    }
}