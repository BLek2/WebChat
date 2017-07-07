using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Models;
using System.Net;
using System.Net.Mail;

namespace WebChat.Controllers
{
    public class HomeController : Controller
    {
        UserContext DbUser = new UserContext();
        // GET: Home
        [HttpGet]
        public ActionResult LoginForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginForm(string login, string password)
        {

            return View();
        }
        [HttpGet]
        public ActionResult RegisterForm()
        {
            return View(DbUser.Users);
        }
        [HttpPost]
        public ActionResult RegisterForm(string nickname, string email, string password)
        {
            
            
            return View();
        }
        

    }
}