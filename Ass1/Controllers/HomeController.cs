using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ass1.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ass1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                // https://github.com/rustd/AspnetIdentitySample/blob/master/AspnetIdentitySample/Controllers/HomeController.cs
                // Instantiate the ASP.NET Identity system
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                // Get the current logged in User and look up the user in ASP.NET Identity
                var currentUser = manager.FindById(User.Identity.GetUserId()); 

                ViewBag.Message = TimeHelper.getTime(currentUser.Latitude, currentUser.Longitude);                
            }

        return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }       
    }
}