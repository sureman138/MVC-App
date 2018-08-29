using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstMVCApp.Web.Models;
using MyFirstMVCApp.DataAccessLayer;


namespace MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


    }
}