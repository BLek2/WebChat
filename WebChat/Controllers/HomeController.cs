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

            IEnumerable<User> users = DbUser.Users;

            foreach (var b in users)
            {
                if(b.NickName == login && b.Password == password)
                {
                    HttpCookie cookie = new HttpCookie("NickName");
                    cookie.Value = login;
                    cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookie);




                    return RedirectToAction("Room","Chat");
                }
            }

            
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
            IQueryable<User> NickNames = DbUser.Users;
             foreach(var b in NickNames)
            {
                   if(b.NickName == nickname)
                {
                    return View();
                }
                   if(b.Email == email)
                {
                    return View();
                }
                
            }
            User user = new User
            {
                NickName = nickname,
                Email = email,
                Password = password
            };
            DbUser.Users.Add(user);
            DbUser.SaveChanges();

            return View();
        }
        

    }
}