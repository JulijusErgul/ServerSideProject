using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Mockups;

namespace ServersideProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Repo repo = new Repo();
            Session["repo"] = repo;
            return View();
        }
    }
}